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

        public IActionResult Create()
        {
            var model = new CreateCourseModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseModel model)
        {
            if(ModelState.IsValid)
            {
                try 
                { 
                    model.CreateCourse();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(" ", "Faield to create course");
                    _logger.LogError(ex, "Create Course Failed");
                }
            }
            return View(model);
        }

        public IActionResult Edit()
        {
            var model = new EditListModel();
            return View(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(EditListModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(nameof(Index));
        }

        public IActionResult Data()
        {
            var model = new CourseListModel();
            model.LoadModelData();
            return View(model);
        }
    }
}
