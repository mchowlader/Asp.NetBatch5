using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadEx2Priority
{
    public class Odd
    {
        public void OddNumberPrint()
        {
            for(var i = 0; i < 10; i++)
            {
                if(i % 2 != 0)
                {
                    Console.WriteLine($"Odd : {i}");
                }
                Thread.Sleep(500);
            }
        }
    }
}
