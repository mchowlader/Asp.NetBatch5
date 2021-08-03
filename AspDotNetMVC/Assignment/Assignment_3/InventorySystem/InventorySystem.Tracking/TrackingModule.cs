using Autofac;
using InventorySystem.Tracking.Contexts;
using InventorySystem.Tracking.Repositories;
using InventorySystem.Tracking.Services;
using InventorySystem.Tracking.UnitOfWorks;
using System;

namespace InventorySystem.Tracking
{
    public class TrackingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;

        public TrackingModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrackinDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<TrackinDbContext>().As<ITrackinDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<TrackingUnitOfWork>().As<ITrackingUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<StockService>().As<IStockService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<StockRepository>().As<IStockRepository>()
              .InstancePerLifetimeScope();

            base.Load(builder); 
        }

    }
}
