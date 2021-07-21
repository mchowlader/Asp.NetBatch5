using MVC.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MVC.Training.BusinessObjects;
using MVC.Web.Models;

namespace MVC.Web.Areas.Admin.Models
{
    public class CourseListModel
    {
        public IList<Course> Courses { get; set; }

        private readonly ICourseService _courseService;
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        internal void LoadModelData()
        {
            Courses = _courseService.GetAllCourses();
        }

        internal object GetCourses(DataTablesAjaxRequestModel tablesModel)
        {
            var data = _courseService.GetCourses(
                
                tablesModel.PageIndex,
                tablesModel.PageSize,
                tablesModel.SearchText,
                tablesModel.GetSortText(new string[] { "Titel", "Fees", "StartDate"}));

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
                        }
                      ).ToArray()
            };

        }
    }
}
//FormanImageUrl(record.Image?.firstDefault()?.Location