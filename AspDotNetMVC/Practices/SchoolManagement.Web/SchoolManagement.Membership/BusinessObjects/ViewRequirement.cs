using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Membership.BusinessObjects
{
    public class ViewRequirement : IAuthorizationRequirement
    {
        public ViewRequirement()
        {
        }
    }
}
