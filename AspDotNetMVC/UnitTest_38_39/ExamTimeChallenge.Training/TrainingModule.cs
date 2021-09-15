using Autofac;
using ExamTimeChallenge.Training.Contexts;
using ExamTimeChallenge.Training.Repositories;
using ExamTimeChallenge.Training.Services;
using ExamTimeChallenge.Training.UnitOfWorks;
using System;

namespace ExamTimeChallenge.Training
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

            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
