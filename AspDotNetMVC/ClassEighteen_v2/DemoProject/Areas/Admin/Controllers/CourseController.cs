using DemoProject.Areas.Admin.Models;
using DemoProject.Training.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Areas.Admin.Controllers
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
            var model = new EnrollStudentModel();
            return View(model);
        }
    }
}
