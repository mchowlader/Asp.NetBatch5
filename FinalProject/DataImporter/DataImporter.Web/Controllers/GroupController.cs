using DataImporter.Common.Utilities;
using DataImporter.User.Contexts;
using DataImporter.Web.Models;
using DataImporter.Web.Models.Groups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private ApplicationDbContext _dbContext;
        public GroupController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Groups()
        {
            return View();
        }
      
        //ok
        [HttpPost]
        public IActionResult CreateGroup(CreateGroupModel model)
        {
            model.CreateGroup();
            return RedirectToAction(nameof(Groups));
        }
        
        //ok
        public JsonResult GetGroupData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListGroupModel();
            var data = model.GetGroups(dataTableModel);
            return Json(data);
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
            return RedirectToAction(nameof(Groups));
        }

        public IActionResult Contacts()
        {
            var model = new ContactsModel();
            model.LoadGroupProperty();
            var groupData = model.groupsList;
            groupData.Insert(0, new Transfer.BusinessObjects.Group { Id = 0, Name = "Select Group" });
            ViewBag.data = groupData;
            return View(model);
        }

        //public IActionResult DropDown(ContactsModel model)
        //{
        //    model.LoadGroupProperty();
        //    var groupData = model.groupsList;
        //    groupData.Insert(0, new Transfer.BusinessObjects.Group {Id = 0, Name = "Select Group" });
        //    ViewBag.data = groupData;
        //    return RedirectToAction(nameof(Contacts));
        //}


        //var cl = model.createGroupList;
        //cl.Insert(0, new Group { Id = 0, GroupName = "Select Group" });
        //    ViewBag.message = cl;
        //    return View(model);

}
}
