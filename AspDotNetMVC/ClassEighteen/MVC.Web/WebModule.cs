using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Web
{
    public class WebModule : Module
    {
        public WebModule() 
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }

    }

}
