using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger l1 = new Logger(); //Note : If i want to create but we can not.

            Logger l1 = Logger.CreateLogger(); //note:- so we can easyly use our create default instance, but could not ceate new instance.

        }
    }
}
