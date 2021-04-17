using System;

namespace EventExamoleTwo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Notify notify = new Notify();
           

            notify.notification += new Notify.SendMessage(new SendSMS().Send);
            notify.notification += new Notify.SendMessage(new SendEmail().Send);
            notify.notification += new Notify.SendMessage(SendMMS.MMS);
            notify.Notifier(Contact.contacts);

            //Contact contact = new Contact();
            //notify.Notifier(contact.contacts2);  //problem
        }
    }
}
