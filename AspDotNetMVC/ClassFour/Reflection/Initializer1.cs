﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
   public class Initializer1: IInitializer
    {
        public void InitStartup()
        {
            Console.WriteLine("Startup Project setup 1");
        }
    }
}
