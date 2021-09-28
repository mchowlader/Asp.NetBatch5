using Autofac;
using DataImporter.Common.Utilities;
using DataImporter.User.Entities;
using DataImporter.Web.Models.Imports;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ImportController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        public ImportController(ILifetimeScope scope, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment, ILogger<ImportController> logger)
        {
            _scope = scope;
            _logger = logger;
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
                try
                {
                    model.UploadExcelFile();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "File Already Exit");
                    _logger.LogError(ex, "File Already Exit");
                    return View(model);
                }
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
        //ok
        public IActionResult CreateImport(UploadModel model)
        {
            var Createmodel = _scope.Resolve<CreateImportModel>();
            if(ModelState.IsValid)
            {
                model.Resolve(_scope);
                Createmodel.CreateImportHistory(model.Id, model.FilePath,model.FileName);

            }
            return RedirectToAction(nameof(Imports));
        }
        //ok
        public IActionResult Imports()
        {
            return View();
        }
        //ok
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
