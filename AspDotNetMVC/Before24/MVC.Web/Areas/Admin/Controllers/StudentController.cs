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

        public IActionResult Data()
        {
            var model = new StudentListModelcs();
            model.LoadStudentDataModel();
            return View(model);
        }

        public IActionResult Form()
        {
            var model = new CreateStudentModel();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Form(CreateStudentModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateStudent();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Student");
                    _logger.LogError(ex, "Create course failed");
                }
            }
            
            return View(model);
        }


    }
}
