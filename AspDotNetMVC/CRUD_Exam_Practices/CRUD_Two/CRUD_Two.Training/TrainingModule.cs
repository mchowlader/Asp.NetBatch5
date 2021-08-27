using Autofac;
using CRUD_Two.Training.Context;
using System;

namespace CRUD_Two.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public TrainingModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();

            //builder.RegisterType<TrainingDbContext>().As<ITrainingDbContext>()
            //    .WithMetadata("connectionString", _connectionString)
            //    .WithMetadata("migrationsAssemblyName", _migrationsAssemblyName)
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
