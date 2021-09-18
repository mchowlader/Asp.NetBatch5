using DataImporter.Transfer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DataImporter.Transfer.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Group> Groups { get; set; }
    }
}
