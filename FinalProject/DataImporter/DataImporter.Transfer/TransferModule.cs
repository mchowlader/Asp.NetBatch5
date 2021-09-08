using Autofac;
using DataImporter.Transfer.Contexts;
using System;

namespace DataImporter.Transfer
{
    public class TransferModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TransferModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransferDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TransferDbContext>().As<ITransferDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
