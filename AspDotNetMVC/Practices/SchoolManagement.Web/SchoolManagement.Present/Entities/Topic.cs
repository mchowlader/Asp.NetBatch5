﻿using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.Entities
{
    public class Topic : IEntity<int>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
