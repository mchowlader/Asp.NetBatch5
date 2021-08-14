using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Present.Exceptions
{
    class DateTimeException : Exception
    {
        public DateTimeException(string message)
            : base(message) { }
    }
}
