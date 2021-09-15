using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Web.Areas.Admin.Controllers

{
    //[Area("Admin"), Authorize(Policy = "AdminAccess")]
    [Area("Admin"), Authorize(Policy = "ViewPermission")]
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
