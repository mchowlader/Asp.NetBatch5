using AutoMapper;
using SchoolManagement.Present.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Present.Services
{
    public class StudentService
    {
        private readonly IPresentUnitOfWork _presentUnitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IPresentUnitOfWork presentUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _presentUnitOfWork = presentUnitOfWork;
        }
    }
}
