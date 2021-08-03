using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Web.Areas.Netizen.Models;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Netizen.Controllers
{
    [Area("Netizen")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateMemberModel();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateMemberModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateMember();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Filed to create");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetMemberData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListMemberModel();
            var data = model.GetMembers(dataTableModel);

            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditMemberModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditMemberModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Update");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new ListMemberModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
