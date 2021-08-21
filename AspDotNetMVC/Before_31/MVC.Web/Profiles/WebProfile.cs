using AutoMapper;
using MVC.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = MVC.Training.BusinessObjects;

namespace MVC.Web.Profiles
{
    public class WebProfile : Profile
    {
        public  WebProfile()
        {
            CreateMap<BO.Course, CreateCourseModel>().ReverseMap();
            CreateMap<BO.Course, CourseListModel>().ReverseMap();
            CreateMap<BO.Course, EditListModel>().ReverseMap();
        }
    }
}
