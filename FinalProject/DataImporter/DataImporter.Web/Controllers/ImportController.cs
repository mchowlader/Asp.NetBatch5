using Autofac;
using DataImporter.Common.Utilities;
using DataImporter.User.Entities;
using DataImporter.Web.Models.Imports;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataImporter.Web.Controllers
{
    [Authorize]
    public class ImportController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        public ImportController(ILifetimeScope scope, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _scope = scope;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        //ok
        public IActionResult Upload()
        {
            return View();
        }
        //ok
        [HttpPost]
        public IActionResult Upload(UploadModel model)
        {
            if(ModelState.IsValid)
            {
                model.Resolve(_scope);
                model.UploadExcelFile();
            }
            return RedirectToAction(nameof(PreviewExcel),model);
        }
        public IActionResult PreviewExcel(UploadModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                model.PreviewExcelData();
            }
            return View(model);
        }
        //tomorrow work start here
        public IActionResult CreateImport(int groupId)
        {
            var model = _scope.Resolve<CreateImportModel>();
            //model.CreateImportHistory(groupId);
            return View(model);
        }
        //ok
        public IActionResult Imports()
        {
            return View();
        }
        //importsHistory
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
