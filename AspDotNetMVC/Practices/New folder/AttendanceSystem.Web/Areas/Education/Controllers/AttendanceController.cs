using AttendanceSystem.Web.Areas.Education.Models;
using AttendanceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AttendanceSystem.Web.Areas.Education.Controllers
{
    [Area("Education")]
    public class AttendanceController : Controller
    {
        private readonly ILogger<AttendanceController> _logger;
        public AttendanceController(ILogger<AttendanceController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateAttendanceModel();
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateAttendanceModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateAttendance();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to add addendance");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetAttendanceData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListAttendanceModel();
            var data = model.GetAttendance(dataTablesModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditAttendanceModel();
            model.LoadAttendanceData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditAttendanceModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to attendance update");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new ListAttendanceModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
