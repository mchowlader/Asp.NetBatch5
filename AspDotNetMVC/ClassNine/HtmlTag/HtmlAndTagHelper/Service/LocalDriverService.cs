using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAndTagHelper.Service
{
    public class LocalDriverService : IDriverService
    {
        public string DriverName()
        {
            return "LocalDriverService";
        }
    }
}
