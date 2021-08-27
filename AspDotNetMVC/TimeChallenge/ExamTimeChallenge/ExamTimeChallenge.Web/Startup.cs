using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExamTimeChallenge.Membership;
using ExamTimeChallenge.Membership.BusinessObjects;
using ExamTimeChallenge.Membership.Contexts;
using ExamTimeChallenge.Membership.Entities;
using ExamTimeChallenge.Membership.Services;
using ExamTimeChallenge.Training;
using ExamTimeChallenge.Training.Contexts;
using ExamTimeChallenge.Web.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Web
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
        }

        private(string connectionString, string migrationsAssemblyName) GetConnectionAndAssemblyName()
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
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                    options.Cookie.Name = "CustomerPortal.Identity";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                })

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

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccess", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Student");
                });

                options.AddPolicy("ViewPermission", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new ViewRequirement());
                });

                options.AddPolicy("ApiPermission", policy =>
                {
                    policy.AuthenticationSchemes.Clear();
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new ApiRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, ViewRequirementHandler>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{Id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Id?}");

                endpoints.MapRazorPages();

            });

        }
    }
}
