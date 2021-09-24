using Autofac;
using DataImporter.Common.Utilities;
using DataImporter.User.Entities;
using DataImporter.Web.Models.Imports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly UserManager<ApplicationUser> _userManager;
        public ImportController(ILifetimeScope scope, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Imports()
        {
            var model = _scope.Resolve<ImportModel>();
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            model.LoadGroupProperty(id);
            var groupData = model.groupsList;
            groupData.Insert(0, new Transfer.BusinessObjects.Group { Id = 0, GroupName = "Select Group" });
            ViewBag.data = groupData;
            return View(model);
        }

        public JsonResult GetImportsData()
        {
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            var importDataTable = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<ListImportModel>();
            var data = model.GetImportsData(importDataTable, id);
            return Json(data);
        }
    }
}
