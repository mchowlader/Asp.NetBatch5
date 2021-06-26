using Autofac;
using MVC.Training.Contexts;
using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;

        private readonly string _migrationAssemblyName;

        public TrainingModule(string connectionName, string migrationAssemblyName)
        {
            _connectionString = connectionName;

            _migrationAssemblyName = migrationAssemblyName;
        }



        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
