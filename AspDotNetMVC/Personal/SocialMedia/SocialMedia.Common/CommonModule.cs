using Autofac;
using SocialMedia.Common.Utilities;
using System;

namespace SocialMedia.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
             .InstancePerLifetimeScope();
            
            base.Load(builder);
        }
    }
}
