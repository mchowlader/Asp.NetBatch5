using System;

namespace Delegates
{
    class Program
    {
        public delegate void Something(string item);

        static void Main(string[] args)
        {
            var text = "Hi Buddy";
            Something logic = PrintProcess;             //same2
            var logic2 = new Something(PrintProcess2);  //same2

            PrintText(text, logic);         //same1
            PrintText(text, logic2);        //same1
            PrintText(text, PrintProcess);   //same1

            //logic("text");
            //PrintProcess("ak");
        }

        public static void PrintProcess (string textPrint)
        {
            Console.WriteLine($">>>{textPrint}<<<");
        }

        public static void PrintProcess2(string textPrint2)
        {
            Console.WriteLine($"---{textPrint2}---");
        }

        public static void PrintText(string text, Something item)
        {
            if(!string.IsNullOrWhiteSpace(text))
                item(text);
        }
    }
}
