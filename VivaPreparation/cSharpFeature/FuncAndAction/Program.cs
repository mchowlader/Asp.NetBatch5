using System;

namespace FuncAndAction
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Hello World";
            PrintProcess(text, PrintLogic);
        }

        public static void PrintLogic(string text)
        {
            Console.WriteLine($"***{text}***");
        }

        static void PrintProcess (string text, Action<string> action)
        {
            if(!string.IsNullOrWhiteSpace(text))
            {
                action(text);
            }
        }
    }
}
