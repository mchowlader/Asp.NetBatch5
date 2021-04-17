using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExamoleTwo
{
    public class Contact
    {
        public string Email { get; set; }

        public string Number { get; set; }

      public static List<Contact> contacts = new List<Contact>()
        {
            new Contact{Email = "abc@gmail.com", Number = "+8801XXXXXXXX1"},
            new Contact{Email = "def@gmail.com", Number = "+8801XXXXXXXX2"},
            new Contact{Email = "ghi@gmail.com", Number = "+8801XXXXXXXX3"},
            new Contact{Email = "jkl@gmail.com", Number = "+8801XXXXXXXX4"},
            new Contact{Email = "mno@gmail.com", Number = "+8801XXXXXXXX5"}
        };

        public List<Contact> contacts2 = new List<Contact>()
        {
            new Contact{Email = "abc@gmail.com", Number = "+8801XXXXXXXX1"},
            new Contact{Email = "def@gmail.com", Number = "+8801XXXXXXXX2"},
            new Contact{Email = "ghi@gmail.com", Number = "+8801XXXXXXXX3"},
            new Contact{Email = "jkl@gmail.com", Number = "+8801XXXXXXXX4"},
            new Contact{Email = "mno@gmail.com", Number = "+8801XXXXXXXX5"}
        };
    }
}
