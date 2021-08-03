using AttendanceSystem.Present.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.Services
{
    public interface IAttendanceService
    {
        void CreateAttendance(Attendance attendance);
        (IList<Attendance> records, int total, int totalDisplay) GetAttendance(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Attendance GetAttendance(int id);
        void UpdateAttendance(Attendance attendance);
        void DeleteAttendance(int id);
    }
}
