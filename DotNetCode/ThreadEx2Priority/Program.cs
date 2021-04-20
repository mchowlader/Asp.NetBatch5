using System;
using System.Threading;

namespace ThreadEx2Priority
{
    class Program
    {
        static void Main(string[] args)
        {
            Odd odd = new Odd();
            Even even = new Even();
            Numerical numerical = new Numerical();

            //odd.OddNumberPrint();
            //even.EvenNumberPrint();
            //numerical.NumericalNumberPrint();

            Thread oddTh = new Thread(odd.OddNumberPrint);
            Thread evenTh = new Thread(even.EvenNumberPrint);
            Thread numericalTh = new Thread(numerical.NumericalNumberPrint);

            numericalTh.Priority = ThreadPriority.Lowest;
            evenTh.Priority = ThreadPriority.Normal;
            oddTh.Priority = ThreadPriority.Normal;

            numericalTh.Start();
            evenTh.Start();
            oddTh.Start();


        }
    }
}
