using AttendanceSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AttendanceSystem.Present.Services;

namespace AttendanceSystem.Web.Areas.Education.Models
{
    public class ListStudentModel
    {
        private readonly IStudentService _studentService;

        public ListStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public ListStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        internal object GetStudents(DataTablesAjaxRequestModel dataTable)
        {
            var data = _studentService.GetStudents(
                dataTable.PageIndex,
                dataTable.PageSize,
                dataTable.SearchText,
                dataTable.GetSortText(new string[] {"Name", "StudentRollNumber"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from student in data.records
                       select new string[]
                       {
                           student.Name,
                           student.StudentRollNumber.ToString(),
                           student.Id.ToString()
                       }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
