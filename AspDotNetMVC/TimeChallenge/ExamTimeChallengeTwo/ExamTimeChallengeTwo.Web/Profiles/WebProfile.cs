using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamTimeChallengeTwo.Web.Areas.Admin.Models;
using BO = ExamTimeChallengeTwo.Training.BusinessObjects;

namespace ExamTimeChallengeTwo.Web.Profiles
{
    public class WebProfile : Profile
    {
       public WebProfile()
        {
            CreateMap<BO.Student, CreateStudentModel>().ReverseMap();
            CreateMap<BO.Student, DataStudentModel>().ReverseMap();
        }
    }
}
