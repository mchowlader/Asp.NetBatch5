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
      
        //ok
        [HttpPost]
        public IActionResult CreateGroup(CreateGroupModel model)
        {
            model.CreateGroup();
            return RedirectToAction(nameof(Group));

        }
        
        //ok
        public JsonResult GetGroupData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListGroupModel();
            var data = model.GetGroups(dataTableModel);
            return Json(data);
        }

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

        public IActionResult EditGroup(int id)
        {
            var model = new EditGroupModel();
            model.EditGroup(id);
            //return RedirectToAction(nameof(Group));
            return PartialView( "Partial/_EditGroupPartial", model);//problem
        }

        //ok
        public IActionResult DeleteGroup(int id)
        {
            var model = new ListGroupModel();
            model.GroupDelete(id);
            return RedirectToAction(nameof(Group));
        }
        
        
        //[HttpPost]
        //public IActionResult Group(EditGroupModel model)
        //{
        //    return PartialView();
        //}
    }
}
