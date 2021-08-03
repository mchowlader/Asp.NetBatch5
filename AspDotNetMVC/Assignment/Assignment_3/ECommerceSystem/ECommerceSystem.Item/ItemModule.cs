using Autofac;
using ECommerceSystem.Item.Contexts;
using ECommerceSystem.Item.Repositories;
using ECommerceSystem.Item.Services;
using ECommerceSystem.Item.UnitOfWorks;
using System;

namespace ECommerceSystem.Item
{
    public class ItemModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrstionAssemblyName;
        public ItemModule(string connectionString, string migrstionAssemblyName)
        {
            _connectionString = connectionString;
            _migrstionAssemblyName = migrstionAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrstionAssemblyName", _migrstionAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ItemDbContext>().As<IItemDbContext>()
              .WithParameter("connectionString", _connectionString)
              .WithParameter("migrstionAssemblyName", _migrstionAssemblyName)
              .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ItemUnitOfWork>().As<IItemUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }


    }
}
