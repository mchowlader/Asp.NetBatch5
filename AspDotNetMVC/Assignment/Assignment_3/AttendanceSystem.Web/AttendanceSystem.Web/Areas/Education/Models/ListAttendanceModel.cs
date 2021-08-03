using AttendanceSystem.Present.Services;
using AttendanceSystem.Web.Models;
using Autofac;
using System.Linq;

namespace AttendanceSystem.Web.Areas.Education.Models
{
    public class ListAttendanceModel
    {
        private readonly IAttendanceService _attendanceService;
        public ListAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public ListAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal object GetAttendance(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _attendanceService.GetAttendance(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "StudentId", "Date" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.StudentId.ToString(),
                            record.Date.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };

        }

        internal void Delete(int id)
        {
            _attendanceService.DeleteAttendance(id);
        }
    }
}
