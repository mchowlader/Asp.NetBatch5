using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExamoleTwo
{
    public class SendEmail : ISend
    {
        public void Send(List<Contact> data)
        {
            foreach(var item in data)
            {
                Console.WriteLine($"Hello Sir! this is a email{item.Email}");
            }
        }
    }
}
