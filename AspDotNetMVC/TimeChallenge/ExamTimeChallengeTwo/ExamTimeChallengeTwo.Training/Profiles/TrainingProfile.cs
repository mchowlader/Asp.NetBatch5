using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = ExamTimeChallengeTwo.Training.Entities;
using BO = ExamTimeChallengeTwo.Training.BusinessObjects;

namespace ExamTimeChallengeTwo.Training
{
    public class TrainingProfile : Profile
    {
       public TrainingProfile()
        {
            CreateMap<BO.Student, EO.Student>().ReverseMap();
        }
    }
}
