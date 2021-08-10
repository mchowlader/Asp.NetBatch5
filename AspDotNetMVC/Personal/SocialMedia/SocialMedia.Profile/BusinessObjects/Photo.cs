using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Account.BusinessObjects
{
    public class Photo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
    }
}
