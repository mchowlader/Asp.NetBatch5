﻿using DemoProject.Data;
using DemoProject.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Training.Repositories
{
    public interface ICourseRepository : IRepository<Course, int>
    {

    }
}
