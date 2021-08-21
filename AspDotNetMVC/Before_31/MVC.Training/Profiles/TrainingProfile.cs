using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = MVC.Training.BusinessObjects;
using EO = MVC.Traning.Entities;

namespace MVC.Training.Profiles
{
    public class TrainingProfile : Profile
    {
       public TrainingProfile()
        {
            CreateMap<BO.Course, EO.Course>().ReverseMap();
            CreateMap<BO.Student, EO.Student>().ReverseMap();
        }
    }
}
