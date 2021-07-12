using Microsoft.AspNetCore.Mvc;
using MVC.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult CreateCourse()
        {
            var model = new CreateCourseModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateCourse(CreateCourseModel model)
        {
            model.CreateCourse();
            return View(model);
        }

        public IActionResult CourseTable()
        {
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }
    }
}
