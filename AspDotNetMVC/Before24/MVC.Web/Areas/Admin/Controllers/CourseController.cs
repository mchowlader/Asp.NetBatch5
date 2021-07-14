using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CourseController> _logger;
        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }
        public IActionResult Form()
        {
            var model = new CreateCourseModelcs();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Form(CreateCourseModelcs model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateCourse();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "failed to create course");
                    _logger.LogError(ex, "Course create failed");
                }
            }

            return View(model);
        }

    }
}
