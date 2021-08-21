using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialMedia.Web.Areas.Account.Models;
using SocialMedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Areas.Account.Controllers
{
    [Area("Account"), Authorize]
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
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateUser();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create user");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetUserdata()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListUserModel();
            var data = model.GetUsers(dataTableModel);

            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditUserModel();
            model.LoadModeldata(id);

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
            var model = new ListUserModel();
            model.DeleteUser(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
