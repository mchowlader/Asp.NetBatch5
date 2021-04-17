using System;
using System.Threading;

namespace ThreadEx
{
   public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var threadOne = new Thread(Even);
            var threadTwo = new Thread(new ThreadStart(program.Odd));

            threadOne.Start();
            threadTwo.Start();
         
        }

        public void Odd()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine($"Odd :{i} ");
                }
                Thread.Sleep(500);
            }
        }

        static void Even()
        {
            for(int i = 0; i <= 10; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine($"Even :{i} ");                   
                }
                Thread.Sleep(500);
            }
            
        }
    }
}
