using AttendanceSystem.Present.BusinessObjects;
using AttendanceSystem.Present.Common;
using AttendanceSystem.Present.Exceptions;
using AttendanceSystem.Present.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceSystem.Present.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IPresentUnitOfWork _presentUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;

        public AttendanceService(IPresentUnitOfWork presentUnitOfWork, IDateTimeUtility dateTimeUtility)
        {
            _presentUnitOfWork = presentUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
        }

        public void CreateAttendance(Attendance attendance)
        {
            if (attendance == null)
                throw new InvalidOperationException("Attendance missing");
            if (attendance.StudentId.ToString() == null)
                throw new InvalidOperationException("StudentId missing");
            if (attendance.Date.ToString() == null)
                throw new InvalidOperationException("Date missing");
            if (IsDuplicateDate(attendance.Date))
                throw new InvalidOperationException("Attendance already added");
            if (IsValidDate(attendance.Date))
                throw new DateTimeException("invalid Date");
            if (IsValidStudent(attendance.StudentId))
            {
                _presentUnitOfWork.Attendances.Add(
               new Entities.Attendance()
               {
                   StudentId = attendance.StudentId,
                   Date = attendance.Date
               });

                _presentUnitOfWork.Save();
            }

            else
                throw new InvalidOperationException("invalid student");
           
        }

     

        public (IList<Attendance> records, int total, int totalDisplay) GetAttendance(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
             var attendanceData = _presentUnitOfWork.Attendances.GetDynamic(
                 string.IsNullOrWhiteSpace(searchText)? null: x => x.StudentId.ToString().Contains(searchText),
                 sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from record in attendanceData.data
                         select new Attendance()
                         {
                             StudentId = record.StudentId,
                             Date = record.Date,
                             Id = record.Id
                         }).ToList();

            return (resultData, attendanceData.total, attendanceData.totalDisplay);
        }

        public Attendance GetAttendance(int id)
        {
            var attendance = _presentUnitOfWork.Attendances.GetById(id);

            if (attendance == null) return null;

            return new Attendance()
            {
                StudentId = attendance.StudentId,
                Date = attendance.Date,
                Id = attendance.Id
            };

        }

        public void UpdateAttendance(Attendance attendance)
        {
            if (attendance == null)
                throw new InvalidOperationException("Attendance is missing");
            if (IsDateAlreadyUsed(attendance.Date))
                throw new DuplicateValueException("Date already used");

            var attendanceEntity = _presentUnitOfWork.Attendances.GetById(attendance.Id);

            if(attendanceEntity != null)
            {
                attendanceEntity.Id = attendance.Id;
                attendanceEntity.StudentId = attendance.StudentId;
                attendanceEntity.Date = attendance.Date;

                _presentUnitOfWork.Save();
            }
        }

        public void DeleteAttendance(int id)
        {
            _presentUnitOfWork.Attendances.Remove(id);
            _presentUnitOfWork.Save();
        }

        private bool IsDateAlreadyUsed(DateTime date) =>
            _presentUnitOfWork.Attendances.GetCount(x => x.Date == date) > 0;
        private bool IsValidDate(DateTime date) =>
            date.Subtract(_dateTimeUtility.Now).TotalDays > 0;
        private bool IsValidStudent(int studentId) =>
         _presentUnitOfWork.Students.GetCount(x => x.Id == studentId) > 0;
        private bool IsDuplicateDate(DateTime date) =>
            _presentUnitOfWork.Attendances.GetCount(x => x.Date == date) > 0;

       
    }
}
