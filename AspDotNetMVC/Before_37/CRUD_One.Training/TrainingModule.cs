using Autofac;
using CRUD_One.Training.Contexts;
using CRUD_One.Training.Repositories;
using CRUD_One.Training.Services;
using CRUD_One.Training.UnitOfWorks;
using System;

namespace CRUD_One.Training
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

            builder.RegisterType<TrainingDbContext>().As<ITrainingDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseService>().As<ICourseService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
              .InstancePerLifetimeScope();

            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }

}
