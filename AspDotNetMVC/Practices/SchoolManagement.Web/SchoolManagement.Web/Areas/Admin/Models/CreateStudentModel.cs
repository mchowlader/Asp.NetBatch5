using AutoMapper;
using SchoolManagement.Present.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace SchoolManagement.Web.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public CreateStudentModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public CreateStudentModel(IStudentService studentService, IMapper mapper)
        {
            _mapper = mapper;
            _studentService = studentService;
        }
    }
}
