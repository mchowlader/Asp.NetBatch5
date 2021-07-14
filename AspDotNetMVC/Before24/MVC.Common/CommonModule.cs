using Autofac;
using MVC.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeUnity>().As<IDateTimeUnity>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
