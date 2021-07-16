using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MVC.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();
            var emailInfo = new EmailConnectionInfo
            {
                FromEmail = "spyshadaw@gmail.com",
                ToEmail = "provan.howlader@gmail.com",
                MailServer = "smtp.gmail.com",
                EmailSubject = "An Log Error Occured in TestProject, Please Check it",
                Port = 465,
                EnableSsl = true,
                NetworkCredentials = new NetworkCredential("spyshadaw@gmail.com", "@682672Spyshadaw@")
            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Email(emailInfo)
                //.WriteTo.MSSqlServer("Server=DESKTOP-VCDQ38S\\SQLEXPRESS;Database=Before24;User Id=ASP_B5;Password=682672;",
                // sinkOptions: new MSSqlServerSinkOptions {TableName = "Log"})
                .ReadFrom.Configuration(configBuilder)
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:80");
                });
    }

}

//outputTemplate: "Time:{Timestamp:HH:mm:ss}\t\n{Level:u3}\t\n" +
//                        "{SourceContext}\t\n{Message}{NewLine}{Exception}",
//                            LogEventLevel.Fatal,
//                            1
