using Autofac;
using DataImporter.Transfer.Services;
using DataImporter.User.Contexts;
using System;

namespace DataImporter.User
{
    public class UserModule : Module
    {

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public UserModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();



            base.Load(builder);
        }

    }
}
