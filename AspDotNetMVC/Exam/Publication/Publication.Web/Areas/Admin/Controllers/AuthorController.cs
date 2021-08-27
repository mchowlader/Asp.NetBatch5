using Microsoft.AspNetCore.Mvc;
using Publication.Web.Areas.Admin.Models;
using Publication.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            var model = new CreateAuthorModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateAuthorModel model)
        {
            model.CreateAuthor();
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetAuthorData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListAuthorModel();
            var data = model.LoadModelData(dataTableModel);

            return Json(data);
        }

        //public IActionResult Edit(int id)
        //{
        //    var model = new EditBookModel();
        //    model.LoadModelData(id);
        //    return View(model);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Edit(EditBookModel model)
        //{
        //    model.UpdateBook();
        //    return View(model);
        //}

        //public IActionResult Delete(int id)
        //{
        //    var model = new ListBookModel();
        //    model.Delete(id);
        //    return RedirectToAction(nameof(Data));
        //}
    }
}
