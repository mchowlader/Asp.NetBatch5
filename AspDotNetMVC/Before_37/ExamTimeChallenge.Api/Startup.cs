using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExamTimeChallenge.Membership;
using ExamTimeChallenge.Membership.BusinessObjects;
using ExamTimeChallenge.Membership.Contexts;
using ExamTimeChallenge.Membership.Entities;
using ExamTimeChallenge.Membership.Services;
using ExamTimeChallenge.Training;
using ExamTimeChallenge.Training.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            WebHostEnvironment = env;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public static ILifetimeScope AutofacContainer { get; set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionInfo = GetConnectionAndAssemblyName();

            builder.RegisterModule(new TrainingModule(connectionInfo.connectionString,
                connectionInfo.migrationsAssemblyName));
            builder.RegisterModule(new MembershipModule(connectionInfo.connectionString,
                connectionInfo.migrationsAssemblyName));
            builder.RegisterModule(new ApiModule());
        }

        private (string connectionString, string migrationsAssemblyName) GetConnectionAndAssemblyName()
        {
            var connectionString = "DefaultConnection";
            var connectionStringName = Configuration.GetConnectionString(connectionString);
            var migrationsAssemblyName = typeof(Startup).Assembly.FullName;

            return (connectionStringName, migrationsAssemblyName);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionInfo = GetConnectionAndAssemblyName();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionInfo.connectionString,
                    x => x.MigrationsAssembly(connectionInfo.migrationsAssemblyName)));

            services.AddDbContext<TrainingDbContext>(options =>
                options.UseSqlServer(connectionInfo.connectionString,
                    x => x.MigrationsAssembly(connectionInfo.migrationsAssemblyName)));

            // Identity customization started here
            services
                .AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager>()
                .AddRoleManager<RoleManager>()
                .AddSignInManager<SignInManager>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"]
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AccessPermission", policy =>
                {
                    policy.AuthenticationSchemes.Clear();
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new ApiRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, ApiRequirementHandler>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExamTimeChallenge.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExamTimeChallenge.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
