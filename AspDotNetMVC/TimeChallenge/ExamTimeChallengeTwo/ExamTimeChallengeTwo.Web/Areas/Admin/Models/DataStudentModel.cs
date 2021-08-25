using ExamTimeChallengeTwo.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using ExamTimeChallenge.Web.Models;

namespace ExamTimeChallengeTwo.Web.Areas.Admin.Models
{
    public class DataStudentModel
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public DataStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public DataStudentModel(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;
            _studentService = studentService;
        }

        internal object GetStudentData(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _studentService.GetStudentData(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] {"Name", "Address","DateOfBirth" }));

            return new
            {
                recordsTotsl = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Address,
                            record.DateOfBirth.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
