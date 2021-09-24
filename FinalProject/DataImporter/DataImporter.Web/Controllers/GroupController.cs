using DataImporter.Common.Utilities;
using DataImporter.User.Contexts;
using DataImporter.User.Entities;
using DataImporter.User.Services;
using DataImporter.Web.Models;
using DataImporter.Web.Models.Groups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Autofac;

namespace DataImporter.Web.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private ApplicationDbContext _dbContext;
        private readonly ILifetimeScope _scope;
        private UserManager<ApplicationUser> _userManager;
        public GroupController(ILifetimeScope scope, ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _scope = scope;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Groups()
        {
            return View();
        }

        //ok
        [HttpPost]
        public IActionResult CreateGroup(CreateGroupModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                model.UserId = _userManager.GetUserId(HttpContext.User);
                model.CreateGroup();
            }

            return RedirectToAction(nameof(Groups));
        }

        //ok
        public JsonResult GetGroupDataByUser()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<ListGroupModel>();
            //model.UserId = _userManager.GetUserId(HttpContext.User);
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            var data = model.GetGroupsByUser(dataTableModel,id);
            return Json(data);
        }


        //href = "#" data-id = '${data}' value = '${data}'>
        //onclick="window.location.href='/Group/EditGroup/${data}'" value='${data}'>



        //IActionResult
        public PartialViewResult EditGroup(int id)
        {
            var model = _scope.Resolve<EditGroupModel>();

            model.EditGroup(id);
            //return RedirectToAction(nameof(Groups));
            //return PartialView("Groups", model);//problem
            return PartialView(model);//problem
            //return RedirectToAction(nameof(Groups));

            //need to correction this portion. return to partial view with load data for edit 
        }

        public IActionResult UpdateGroup()
        {
            return View();
        }

        //ok
        public IActionResult DeleteGroup(int id)
        {
            var model = _scope.Resolve<ListGroupModel>();
            model.GroupDelete(id);
            return RedirectToAction(nameof(Groups));
        }

        public IActionResult Contacts()
        {
            var model = _scope.Resolve<ContactsModel>();
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            model.LoadGroupProperty(id);
            var groupData = model.groupsList;
            groupData.Insert(0, new Transfer.BusinessObjects.Group { Id = 0, GroupName = "Select Group" });
            ViewBag.data = groupData;
            return View(model);
        }

        public IActionResult EmailGroup()
        {
            
            return RedirectToAction(nameof(Groups));
        }

        public IActionResult ViewGroupData()
        {

            return RedirectToAction(nameof(Contacts));
        }

    }
}
