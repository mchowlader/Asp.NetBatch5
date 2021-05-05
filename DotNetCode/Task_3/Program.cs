using System;
using System.Linq;
using System.Reflection;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.BaseType.Name == nameof(BaseModel)
                       select t.Name;
            foreach(var item in type)
            {
                Console.WriteLine(item);
            }
        }
    }
}
