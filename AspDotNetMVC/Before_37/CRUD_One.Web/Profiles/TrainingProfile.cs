using AutoMapper;
using CRUD_One.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = CRUD_One.Training.BusinessObjects;

namespace CRUD_One.Web.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<BO.Course, CreateCourseModel>().ReverseMap();
            CreateMap<BO.Course, ListCourseModel>().ReverseMap();
            CreateMap<BO.Course, EditCourseModel>().ReverseMap();
        }
    }
}
