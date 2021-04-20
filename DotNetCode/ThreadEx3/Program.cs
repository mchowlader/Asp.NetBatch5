using System;
using System.Threading;

namespace ThreadEx3
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = Thread.CurrentThread;
            var x = thread.Name = "Current Thread";
            Console.WriteLine($"{x}");
        }
    }
}
