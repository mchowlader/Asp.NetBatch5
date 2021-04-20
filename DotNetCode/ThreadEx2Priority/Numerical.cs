using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadEx2Priority
{
   public class Numerical
    {
        public void NumericalNumberPrint()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Numerical : {i}");
                Thread.Sleep(250);
            }
        }
    }
}
