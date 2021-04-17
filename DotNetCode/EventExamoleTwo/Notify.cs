using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExamoleTwo
{
    public class Notify
    {
        public delegate void SendMessage(List<Contact> contactsList);

        public event SendMessage notification;

        public void Notifier(List<Contact> userData)
        {
            notification(userData);
        }
    }
}
