using Autofac;
using Microsoft.Extensions.Configuration;
using StockData.Trend.Contexts;
using StockData.Trend.Services;
using StockData.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class WorkerModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public WorkerModule(string connectionStringName, string migrationAssemblyName,
            IConfiguration configuration)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyModel>().AsSelf();
            builder.RegisterType<StockPriceModel>().AsSelf();
            builder.RegisterType<MarketStatus>().AsSelf();

            builder.RegisterType<CompanyService>().As<ICompanyService>()
                .InstancePerLifetimeScope(); 
            builder.RegisterType<StockPriceService>().As<IStockPriceService>()
                .InstancePerLifetimeScope();
          
            base.Load(builder);
        }
    }
}
