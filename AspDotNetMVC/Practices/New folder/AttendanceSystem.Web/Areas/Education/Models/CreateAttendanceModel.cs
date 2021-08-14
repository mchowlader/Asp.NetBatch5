using AttendanceSystem.Present.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.ComponentModel.DataAnnotations;
using AttendanceSystem.Present.BusinessObjects;

namespace AttendanceSystem.Web.Areas.Education.Models
{
    public class CreateAttendanceModel
    {
        [Required, Range(1, 100000)]
        public int StudentId { get; set; }
        [Required, Range(typeof(DateTime), "01/01/2021", "01/01/2030")]
        public DateTime Date { get; set; }

        private readonly IAttendanceService _attendanceService;
        public CreateAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public CreateAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal void CreateAttendance()
        {
            var attendance = new Attendance() 
            {
                StudentId = StudentId,
                Date = Date
            };

            _attendanceService.CreateAttendance(attendance);
        }
    }
}
