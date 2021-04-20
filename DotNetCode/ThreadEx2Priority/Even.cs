using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadEx2Priority
{
    public class Even
    {
        public void EvenNumberPrint()
        {
            for (var i = 0; i < 10; i++)
            {
                if (i % 2 != 1)
                {
                    Console.WriteLine($"Even : {i}");
                }

                Thread.Sleep(500);
            }
        }
    }
}
