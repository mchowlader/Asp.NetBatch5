using DemoProject.Areas.Admin.Models;
using DemoProject.Training.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enroll(EnrollStudentModel model)
        {
            if(ModelState.IsValid)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Enroll()
        {
            return View();
        }
        public IActionResult CreateCourse()
        {
            var model = new CreateCourseModel();
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult CreateCourse(CreateCourseModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateCourse();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create course");
                    _logger.LogError(ex, "Course create failed");
                }
            }
            return View(model);
        }

        public IActionResult DataTable()
        {
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }
    }
}
