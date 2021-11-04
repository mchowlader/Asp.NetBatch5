using ExamTimeChallenge.Web.Areas.Admin.Models;
using ExamTimeChallenge.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTimeChallenge.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;        }
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
                    ModelState.AddModelError("", "Failed to create course");
                    _logger.LogError(ex, "Create Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            var model = new ListCourseModel();
            return View(model);
        }

        public JsonResult GetCourseData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListCourseModel();
            var data = model.LoadModelData(dataTableModel);
            return Json(data);
        }

       
        public IActionResult Edit(int id)
        {
            var model = new EditCourseModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCourseModel model)
        {
            model.UpdateCourse();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new ListCourseModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
