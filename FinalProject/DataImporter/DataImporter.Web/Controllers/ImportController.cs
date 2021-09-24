using Autofac;
using DataImporter.Common.Utilities;
using DataImporter.User.Entities;
using DataImporter.Web.Models.Imports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public IActionResult Index()
        {
            return View();
        }


        public ActionResult File()
        {
            var model = _scope.Resolve<ListImportModel>();
            return View(model);
        }
        [HttpPost]
        public ActionResult File(ListImportModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                string rootFolder = $"{_webHostEnvironment.WebRootPath}\\Uploads";
                string uploadFile = model.XlsFile.FileName;
                model.ExcelFileName = Path.GetFileNameWithoutExtension(model.XlsFile.FileName);

                FileInfo file = new FileInfo(Path.Combine(rootFolder, uploadFile));
                using (var stream = new MemoryStream())
                {
                    model.XlsFile.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        package.SaveAs(file);
                        //save excel file in your wwwroot folder and get this excel file from wwwroot
                    }
                }

              }
            //After save excel file in wwwroot and then

            //using (ExcelPackage package = new ExcelPackage(file))
            //{
            //    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            //    if (worksheet == null)
            //    {
            //        //return or alert message here
            //    }
            //    else
            //    {
            //        //read excel file data and add data in  model.StaffInfoViewModel.StaffList
            //        var rowCount = worksheet.Dimension.Rows;
            //        for (int row = 2; row <= rowCount; row++)
            //        {
            //            model.StaffInfoViewModel.StaffList.Add(new StaffInfoViewModel
            //            {
            //                FirstName = (worksheet.Cells[row, 1].Value ?? string.Empty).ToString().Trim(),
            //                LastName = (worksheet.Cells[row, 2].Value ?? string.Empty).ToString().Trim(),
            //                Email = (worksheet.Cells[row, 3].Value ?? string.Empty).ToString().Trim(),
            //            });
            //        }

            //    }
            //}


            //return same view and  pass view model 
            return View(model);
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
