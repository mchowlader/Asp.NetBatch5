using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapPractices_v2.Areas.User.Models
{
    public class UserInfo
    {
        //public string First = "First Name";

        public string First { get; set; }

        public string Last { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
    }
}
