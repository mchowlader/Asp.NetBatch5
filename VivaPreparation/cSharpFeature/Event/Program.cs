using System;

namespace Event
{
    class Program
    { 
        public delegate void Notify(string address, string message);
        public event Notify Notifications;

        static void Main(string[] args)
        {
            var instance = new Program();
            //event subscribe system
            instance.Notifications += EmailNotification;  
            instance.Notifications += SMSNotification;
            instance.Notifications("mithun.howlader222@gmail.com", "Hello MR.");

            instance.Notifications -= EmailNotification;
            instance.Notifications("mithun.howlader222@gmail.com", "Hello MR.");


        }

        public static void EmailNotification(string address, string message)
        {
            Console.WriteLine($"Sending Email to {address} with message {message}");
        }

        public static void SMSNotification(string mobileMumber, string message)
        {
            Console.WriteLine($"Sending sms to {mobileMumber} with message {message}");
        }
    }
}
