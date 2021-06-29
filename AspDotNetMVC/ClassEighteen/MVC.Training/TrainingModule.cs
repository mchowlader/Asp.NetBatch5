using Autofac;
using MVC.Training.Contexts;
using MVC.Training.Services;
using System;

namespace MVC.Training
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

            builder.RegisterType<CourseService>().As<ICoursesService>().InstancePerLifetimeScope();

            base.Load(builder);

    
        }
    }
}
