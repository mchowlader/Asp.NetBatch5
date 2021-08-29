using Autofac;
using AutoMapper;
using CRUD_One.Training.Services;
using ExamTimeChallenge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_One.Web.Areas.Admin.Models
{
    public class ListCourseModel
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public ListCourseModel()
        {
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        public ListCourseModel(IMapper mapper, ICourseService courseService)
        {
            _mapper = mapper;
            _courseService = courseService;
        }

        internal object loadModelData(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _courseService.GetCourseData(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "Title","Fees","StartDate"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                       select new string[]
                       {
                           record.Title,
                           record.Fees.ToString(),
                           record.StartDate.ToString(),
                           record.Id.ToString()
                       }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _courseService.DeleteCourse(id);
        }
    }
}
