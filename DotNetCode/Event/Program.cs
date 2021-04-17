using System;

namespace Event
{
    class Program
    {
        public delegate void Notify(string address, string message);

        public event Notify Notificarions;

        static void Main(string[] args)
        {
            var instance = new Program();
            instance.Notificarions += EmailService;
            instance.Notificarions("mithun.howlader222@gmail.com", "Hello Sir!");

            //instance.Notificarions -= EmailService;

            instance.Notificarions += SMS;
            instance.Notificarions("+8801833395475", "Hello Buddy");


        }

        public static void EmailService(string address, string message)
        {
            Console.WriteLine($"To :{address}, {message}");
        }

        public static void SMS(string mobileNnumber, string message)
        {
            Console.WriteLine($"To :{mobileNnumber}, {message}");
        }

    }
}
