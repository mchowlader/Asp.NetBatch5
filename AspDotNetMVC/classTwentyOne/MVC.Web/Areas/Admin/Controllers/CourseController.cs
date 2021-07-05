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
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }
        public IActionResult Enroll()
        {
            var model = new EnrollStudentModel();
            return View(nameof(Index));
        }
        [HttpPost]
        public IActionResult Enroll(EnrollStudentModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(nameof(Index));
        }
    }
}
