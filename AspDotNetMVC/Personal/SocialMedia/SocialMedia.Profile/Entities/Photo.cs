using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Account.Entities
{
    public class Photo : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public User User { get; set; }
    }
}
