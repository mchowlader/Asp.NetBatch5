using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAndTagHelper.Models
{
    public class SampleView
    {
       public string Name { get; set; }

       public string Password { get; set; }

       public string ConfirmPassword { get; set; }

        public SampleView()
        {
            Name = "name";
            Password = "password";
            ConfirmPassword = "confirm password";
        }

        public void Latter()
        {
            List<string> ts = new List<string>() { "A", "B", "C" };
        }
       


    }
}
