using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger
    {
        //This is the main singleton concept
        private static Logger _logger;

        private Logger()
        {

        }

        public static Logger CreateLogger()
        {
            if (_logger == null)
                _logger = new Logger();

            return _logger;
        }


        // ##Note:- if i want addtional purpuse we can add this type of code

        //private static Logger _logger;

        //private Logger(string FileName)
        //{
        //    _logFileName = FileName; 
        //}

        //public static Logger CreateLogger(string FileName)
        //{
        //    if (_logger == null) //##Multithread purpuse need to look thread, otherwise faield to incosistent restult.
        //        _logger = new Logger(FileName);

        //    return _logger;
        //}




        //private string _logFileName;
        //public void WriteLog(string message, Exception exception)
        //{
        //    //demo method
        //}

    }
}
