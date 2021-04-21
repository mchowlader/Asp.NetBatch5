using System;

namespace DelegateExample
{
    public delegate void thisDelegate(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;
            thisDelegate test1 = Sum;

            ApplySum(a,b,test1);
                    
        }

        public static void Sum(int b, int c)
        {
            Console.WriteLine($"Here is sum result >> {b+c}");
        }

        public static void ApplySum(int text2,int text, thisDelegate thisDelegate)
        {
            thisDelegate(text, text2);
        }
    }
}
