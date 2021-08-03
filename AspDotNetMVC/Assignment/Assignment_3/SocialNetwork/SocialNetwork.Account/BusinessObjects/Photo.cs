using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Account.BusinessObjects
{
    public class Photo
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string PhotoFileName { get; set; }
    }
}
