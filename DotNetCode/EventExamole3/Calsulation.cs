using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExamole3
{
   public class Calsulation
    {
        public delegate void dgCalculation();

        public event dgCalculation evMath;

        public void Sometthing()
        {
            var numOne = Convert.ToInt32(Console.ReadLine());
            var numTwo = Convert.ToInt32(Console.ReadLine());
            var sum = numOne + numTwo;

            if(sum % 2 == 0)
            {
                if(evMath != null)
                    evMath();

                else
                    Console.WriteLine($"This is a only Even Number");
            }

            else
                Console.WriteLine($"Event not fire");

        }
    }
}
