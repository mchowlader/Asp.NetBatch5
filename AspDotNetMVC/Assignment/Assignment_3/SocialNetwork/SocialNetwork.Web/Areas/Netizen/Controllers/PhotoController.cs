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
    public class PhotoController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public PhotoController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreatePhotoModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreatePhotoModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreatePhoto();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetPhotoData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListPhotoModel();
            var data = model.GetPhotos(dataTableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditPhotoModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditPhotoModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to update");
                    _logger.LogError(ex, "Failed");
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new ListPhotoModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
