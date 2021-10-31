using System;

namespace Delegates
{
    class Program
    {
       delegate void Perform(string text);

        static void Main(string[] args)
        {
            var printer = new Printer();
            var text = "Hello World";
            var logic = new Perform(printer.Print2);
            ProcessText(text,logic);
        }


        public static void PrintMethod(string text)
        {
            Console.WriteLine($">>>  { text}  <<<");
        }
        static void ProcessText(string text, Perform perform)
        {
            if(!string.IsNullOrWhiteSpace(text))
            { 
                perform(text);
            }
        }
    }
}
