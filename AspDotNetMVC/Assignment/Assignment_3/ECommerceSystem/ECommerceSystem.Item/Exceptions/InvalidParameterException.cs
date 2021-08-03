using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Item.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string meassge)
            : base(meassge) { }
    }
}
