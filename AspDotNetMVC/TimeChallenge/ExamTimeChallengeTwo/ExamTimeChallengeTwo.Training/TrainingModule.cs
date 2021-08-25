using Autofac;
using ExamTimeChallengeTwo.Training.Contexts;
using ExamTimeChallengeTwo.Training.Repositories;
using ExamTimeChallengeTwo.Training.Services;
using ExamTimeChallengeTwo.Training.UnitOfWorks;
using System;

namespace ExamTimeChallengeTwo.Training
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

            builder.RegisterType<StudentService>().As<IStudentService>()
              .InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
             .InstancePerLifetimeScope();
            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
             .InstancePerLifetimeScope();

            base.Load(builder);
        }
        
    }
}
