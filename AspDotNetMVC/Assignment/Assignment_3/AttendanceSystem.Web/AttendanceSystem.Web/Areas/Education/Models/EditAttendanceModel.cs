using System;
using System.ComponentModel.DataAnnotations;
using AttendanceSystem.Present.BusinessObjects;
using AttendanceSystem.Present.Services;
using Autofac;

namespace AttendanceSystem.Web.Areas.Education.Models
{
    public class EditAttendanceModel
    {
        [Required, Range(1, 100000)]
        public int? Id { get; set; }
        [Required, Range(1, 100000)]
        public int? StudentId { get; set; }
        [Required, Range(typeof(DateTime), "01/01/2021", "01/01/2030")]
        public DateTime? Date { get; set; }

        private readonly IAttendanceService _attendanceService;
        public EditAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public EditAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal void LoadAttendanceData(int id)
        {
            var attendance = _attendanceService.GetAttendance(id);

            StudentId = attendance?.StudentId;
            Date = attendance?.Date;
            Id = attendance?.Id;
        }

        internal void Update()
        {
            var attendance = new Attendance()
            {
                Id = Id.HasValue ? Id.Value : 0,
                StudentId = StudentId.HasValue ? StudentId.Value : 0,
                Date = Date.HasValue ? Date.Value: DateTime.MinValue
            };

            _attendanceService.UpdateAttendance(attendance);
        }
    }
}
