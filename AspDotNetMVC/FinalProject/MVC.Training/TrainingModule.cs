using Autofac;
using MVC.Data;
using MVC.Training.Contexts;
using MVC.Training.Repositories;
using MVC.Training.Services;
using MVC.Training.UnitOfWorks;
using MVC.Traning.Contexts;
using System;

namespace MVC.Traning
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingDbContext>().AsSelf()
                 .WithParameter("connectionString", _connectionString)
                 .WithParameter("migrationsAssemblyName", _migrationAssemblyName)
                 .InstancePerLifetimeScope();
            builder.RegisterType<TrainingDbContext>().As<ITrainingDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
                .InstancePerLifetimeScope();
             builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
