using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Web.Areas.Admin.Controllers
{
    //[Area("Admin"), Authorize(Policy = "StudentAccess")]
    //[Area("Admin"), Authorize(Policy = "RestrictedArea")]  //ClaimBased
    [Area("Admin"), Authorize(Policy = "viewPermission")]   //HandelerBased
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
