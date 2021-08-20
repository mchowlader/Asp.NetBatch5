using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //(Roles = "Admin")
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }


    }
}
