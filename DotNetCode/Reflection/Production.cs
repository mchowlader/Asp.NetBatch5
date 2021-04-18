using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Production
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public List<int> count;

        int x;

        public void Something(string some)
        {
            Console.WriteLine($"This is Reflection");
        }

        public Production()
        {
            Name = "Reflection";
        }

        public Production(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

    }
}
