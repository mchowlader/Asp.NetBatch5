using Autofac;
using MVC.Common.Utilities;
using System;

namespace MVC.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
