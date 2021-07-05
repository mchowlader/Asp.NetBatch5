using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Training.Exceptions
{
    public class DuplicateTitelException : Exception
    {
        public DuplicateTitelException(string message)
            : base(message) { }
    }
}
