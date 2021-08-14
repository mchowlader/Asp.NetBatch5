using AttendanceSystem.Web.Areas.Education.Models;
using AttendanceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Education.Controllers
{
    [Area("Education")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new CreateStudentModel();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateStudent();

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Roll Already Exit");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }
        public JsonResult GetStudentData()
        {
            var dataTable = new DataTablesAjaxRequestModel(Request);
            var model = new ListStudentModel();
            var data = model.GetStudents(dataTable);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditStudentModel();
            model.LoadStudentData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Update Failed");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var model = new ListStudentModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }

    }
}
