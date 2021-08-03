using AttendanceSystem.Present.Common;
using AttendanceSystem.Present.Contexts;
using AttendanceSystem.Present.Repositories;
using AttendanceSystem.Present.Services;
using AttendanceSystem.Present.UnitOfWorks;
using Autofac;
using System;

namespace AttendanceSystem.Present
{
    public class PresentModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public PresentModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PresentDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<PresentDbContext>().As<IPresentDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<PresentUnitOfWork>().As<IPresentUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AttendanceService>().As<IAttendanceService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<AttendanceRepository>().As<IAttendanceRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
