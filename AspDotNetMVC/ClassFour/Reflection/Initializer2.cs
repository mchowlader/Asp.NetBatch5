using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
   public class Initializer2: IInitializer
    {
        public Initializer2(int a)
        {

        }

        public void InitStartup()
        {
            Console.WriteLine("Startup project setup 2");
            //Initializer
        }

   }
}
