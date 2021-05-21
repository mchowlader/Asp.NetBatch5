using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAndTagHelper.Service
{
    public class SimpleDatabaseService : IDatabaseService
    {
        private IDriverService _driverService; 

        public SimpleDatabaseService(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public string GetName()
        {
            return "SimpleSatabaseService";
        }
    }
}
