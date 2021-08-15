using Autofac;
using SchoolManagement.Present.Contexts;
using SchoolManagement.Present.Repositories;
using SchoolManagement.Present.Services;
using SchoolManagement.Present.UnitOfWorks;
using System;

namespace SchoolManagement.Present
{
    public class PresentModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public PresentModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PresentDbContext>().AsSelf()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();
            builder.RegisterType<PresentDbContext>().As<IPresentDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TopicRepository>().As<ITopicRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PresentUnitOfWork>().As<IPresentUnitOfWork>()
               .InstancePerLifetimeScope(); 
            builder.RegisterType<StudentService>().As<IStudentService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
