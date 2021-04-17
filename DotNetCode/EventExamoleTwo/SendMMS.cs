using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExamoleTwo
{
    public class SendMMS
    {
       public static void MMS(List<Contact> contacts ) 
        {
            foreach(var item in contacts)
            {
                Console.WriteLine($"Hi Buddy! this is your mms{item.Number}");
            }
        }
    }
}
