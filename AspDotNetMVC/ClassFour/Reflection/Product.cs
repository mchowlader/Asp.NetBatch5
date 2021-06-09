using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
   public class Product
    {
        public string Name { get; set; }

        public int Code { get; set; }

        public double Weight { get; set; }

        public double Price { get; set; }


        public bool IsAvailavle()
        {
            return true;
        }
    }
}
