using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = CRUD_One.Training.BusinessObjects;
using EO = CRUD_One.Training.Entities;

namespace CRUD_One.Training.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<BO.Course, EO.Course>().ReverseMap();
        }
    }
}
