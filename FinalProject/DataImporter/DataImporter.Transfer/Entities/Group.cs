using DataImporter.Data;
using DataImporter.User.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Entities
{
    public class Group : IEntity<int>
    {
        public int Id { get ; set ; }
        public Guid UserId { get ; set ; }
        public string Name { get ; set ; }
        public DateTime DateTime { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
