using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Common.Utilities
{
    public class DateTimeUnity : IDateTimeUnity
    {
        public DateTime NowTime
        {
            get
            {
                return DateTime.Now;
            }
        }

    }
}
