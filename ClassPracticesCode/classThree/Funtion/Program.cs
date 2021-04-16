using System;

namespace Funtion
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = "Vegas, House - 007";
            Address(x, Home);
        }

        public static string Home(string add)
        {
            Console.WriteLine($"My Address: {add}");
            return add;
        }

        public static string Address(string address ,Func<string,string> home)
        {
            home(address);
            return default;
        }
    }
}
