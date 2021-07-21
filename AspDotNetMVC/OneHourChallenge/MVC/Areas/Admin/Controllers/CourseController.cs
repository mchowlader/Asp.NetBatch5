using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }

        public IActionResult Form()
        {
            var model = new CreateCourseModel();
            return View(model);
        }

        public IActionResult Form(CreateCourseModel model)
        {
            model.CreateCourse();
            return View(model);
        }
    }
}
