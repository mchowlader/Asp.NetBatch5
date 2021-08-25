using ExamTimeChallenge.Web.Models;
using ExamTimeChallengeTwo.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTimeChallengeTwo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateStudent();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Create to faild student");
                    _logger.LogError(ex, "Failed create");
                }
            }
            
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetStudent()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new DataStudentModel();
            var data = model.GetStudentData(dataTableModel);
            return Json(data);
        }
    }
}
