using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = ExamTimeChallenge.Training.Entities;
using BO = ExamTimeChallenge.Training.BusinessObjects;

namespace ExamTimeChallenge.Training.Profiles
{
    public class TrainingProfile : Profile
    {
       public TrainingProfile()
        {
            CreateMap<BO.Course, EO.Course>().ReverseMap();
        }
    }
}
