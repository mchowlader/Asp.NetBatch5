using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
   public class Pdoduct  : Production
    {
        public delegate void dg(int xxx);

        public event dg ev;

    }
}
