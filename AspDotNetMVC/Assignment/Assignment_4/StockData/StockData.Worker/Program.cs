using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using StockData.Trend;
using StockData.Trend.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class Program
    {
        private static string _connectionString;
        private static string _migrationAssemblyName;
        private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(_configuration)
                .CreateLogger();
            try
            {
                Log.Information("Application Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static ILifetimeScope AutofacContainer { get; set; }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureContainer<ContainerBuilder>(builder => {
                    builder.RegisterModule(
                        new WorkerModule(_connectionString, _migrationAssemblyName, _configuration));
                    builder.RegisterModule(
                        new TrendModule(_connectionString, _migrationAssemblyName));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    _connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");

                    _migrationAssemblyName = typeof(Worker).Assembly.FullName;

                    services.AddHostedService<Worker>();

                    services.AddDbContext<TrendDbContext>(options =>
                        options.UseSqlServer(_connectionString, b =>
                            b.MigrationsAssembly(_migrationAssemblyName)));

                });
    }
}
