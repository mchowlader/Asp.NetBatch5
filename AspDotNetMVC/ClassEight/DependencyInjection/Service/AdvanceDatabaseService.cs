﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Service
{
    public class AdvanceDatabaseService : IDatabaseService
    {
        public string GetName()
        {
            return "AdvanceDatabaseService";
        }
    }
}
