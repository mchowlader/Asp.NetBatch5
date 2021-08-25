using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeChallenge.Web.Areas.Admin.Models;
using TimeChallenge.Web.Models;

namespace TimeChallenge.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateUserModel();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateUser();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "failed to create user.");
                    _logger.LogError(ex, "failed to create new user.");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetUserData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new DataUserModel();
            var data = model.GetUsersData(dataTableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditUserModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditUserModel model)
        {
            model.Update();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new DataUserModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
