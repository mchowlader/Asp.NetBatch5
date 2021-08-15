﻿using SchoolManagement.Data;
using SchoolManagement.Present.Contexts;
using SchoolManagement.Present.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.Repositories
{
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(PresentDbContext context)
            : base(context)
        {

        }
    }
}
