using Microsoft.AspNetCore.Mvc;
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
            model.CreateStudent();
            return View(model);
        }


    }
}
