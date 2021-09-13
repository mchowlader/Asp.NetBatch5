using DataImporter.Common.Utilities;
using DataImporter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Controllers
{
    public class CustomerController : Controller
    {

        public IActionResult Group()
        {
            return View();
        }
        public IActionResult CreateGroup()
        {
            var model = new CreateGroupModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateGroup(CreateGroupModel model)
        {
            model.CreateGroup();
            return View(model);
        }
        public JsonResult GetGroupData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListGroupModel();
            var data = model.GetGroups(dataTableModel);
            return Json(data);
        }
        
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult ImportData()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Imports()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult Exports()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult EditGroup()
        {
            return View();
        }

        public IActionResult DeleteGroup(int id)
        {
            var model = new ListGroupModel();
            model.GroupDelete(id);
            return RedirectToAction(nameof(Group));
        }


    }
}
