using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapTemplatesWithLoginForm.Areas.Admin.Models
{
    public class UserInfo
    {
        public string First { get; set; }

        public string Last { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
