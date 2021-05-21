using Autofac;
using HtmlAndTagHelper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAndTagHelper
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDatabaseService>().As<IDatabaseService>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
