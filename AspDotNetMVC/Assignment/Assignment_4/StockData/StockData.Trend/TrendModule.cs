using Autofac;
using StockData.Trend.Contexts;
using System;

namespace StockData.Trend
{
    public class TrendModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrendModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrendDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TrendDbContext>().As<ITrendDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            //builder.RegisterType<StudentRepository>().As<IStudentRepository>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<CourseRepository>().As<ICourseRepository>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<CourseService>().As<ICourseService>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
