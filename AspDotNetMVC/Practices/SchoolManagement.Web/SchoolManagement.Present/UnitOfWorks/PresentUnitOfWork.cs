using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Present.Contexts;
using SchoolManagement.Present.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.UnitOfWorks
{
    public class PresentUnitOfWork : UnitOfWork, IPresentUnitOfWork
    {
        public ITopicRepository Topics { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }

        public PresentUnitOfWork(IPresentDbContext context,
            ITopicRepository topicRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository)
            : base((DbContext)context)
        {
            Topics = topicRepository;
            Students = studentRepository;
            Courses = courseRepository;
        }

   
    }
}
