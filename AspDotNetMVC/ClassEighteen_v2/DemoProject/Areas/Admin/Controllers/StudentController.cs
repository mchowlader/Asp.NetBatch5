using DemoProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentData(StudentListModel model)
        {
            model.LoadModelStudentData();
            return View(model);
        }

        public IActionResult StudentRegistration()
        {
            var model = new CreateStudentModel();
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult StudentRegistration(CreateStudentModel model)
        {
            model.CerateStudent();
            return View(model);
        }
    }
}
