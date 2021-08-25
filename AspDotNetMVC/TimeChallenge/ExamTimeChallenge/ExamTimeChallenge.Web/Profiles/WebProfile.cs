using AutoMapper;
using ExamTimeChallenge.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = ExamTimeChallenge.Training.BusinessObjects;

namespace ExamTimeChallenge.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<BO.Course, CreateCourseModel>().ReverseMap();
            CreateMap<BO.Course, EditCourseModel>().ReverseMap();
            CreateMap<BO.Course, ListCourseModel>().ReverseMap();
        }
    }
}
