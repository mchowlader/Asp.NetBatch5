using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DataImporter.User.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
