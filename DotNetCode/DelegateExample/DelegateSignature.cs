using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
   public class DelegateSignature
    {
        public delegate void thisDelegate(int a, int b);

        public event thisDelegate thisEvent;

       
    }
}
