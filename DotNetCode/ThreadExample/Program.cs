using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Thread thread1 = new Thread(program.PrintOne);

            Thread thread2 = new Thread(program.PrintTwo);

            thread1.Start();
            thread2.Start();

            thread1.Priority = ThreadPriority.Lowest;
            thread2.Priority = ThreadPriority.Highest;




        }

        public void PrintOne()
        {
            for(int i = 0; i <= 10; i++)
            {
                if(i % 2 != 1)
                    Console.WriteLine($"Even : {i}");
                Thread.Sleep(500);
            }
               
        }

        public void PrintTwo()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine($"Odd : {i}");
                Thread.Sleep(500);
            }

        }
    }
}
