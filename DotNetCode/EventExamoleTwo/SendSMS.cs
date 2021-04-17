using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExamoleTwo
{
    public class SendSMS : ISend
    {
        public void Send(List<Contact> data)
        {
            foreach(var item in data)
            {
                Console.WriteLine($"Hi Dude! this is a sms {item.Number}");
            }
        }
    }
}
