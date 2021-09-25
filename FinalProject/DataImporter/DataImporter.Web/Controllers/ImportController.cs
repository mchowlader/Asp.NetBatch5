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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Imports()
        {
            var model = _scope.Resolve<UploadModel>();
            var id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            model.LoadGroupProperty(id);
            var groupData = model.groupsList;
            groupData.Insert(0, new Transfer.BusinessObjects.Group { Id = 0, GroupName = "Select Group" });
            ViewBag.data = groupData;
            return View(model);
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
            return View(model);
        }

        //tomorrow work start here
        public IActionResult CreateImport(int groupId)
        {
            var model = _scope.Resolve<CreateImportModel>();
            model.CreateImportHistory(groupId);
            return View(model);
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
       
        public IActionResult Test()
        {
            var model = _scope.Resolve<ListImportModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Test(ListImportModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);

                if (model.XlsFile != null)
                {
                    string path = Path.Combine(this._webHostEnvironment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.GetFileName(model.XlsFile.FileName);
                    string filePath = Path.Combine(path, fileName);


                    FileInfo file = new FileInfo(Path.Combine(path, fileName));
                    using (var stream = new MemoryStream())
                    {
                        model.XlsFile.CopyToAsync(stream);
                        using (var package = new ExcelPackage(stream))
                        {
                            package.SaveAs(file);
                            //save excel file in your wwwroot folder and get this excel file from wwwroot
                        }
                    }

                    using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var excelReader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = excelReader.AsDataSet();

                            //excelReader.IsFirstRowAsColumnNames = true;
                            DataTable dt = result.Tables[0];

                            var dataSet = new List<ListImportModel>();

                            for(var i = 0; i < dt.Rows.Count && i < 5; i++)
                            {
                                var array = new string[dt.Columns.Count];

                                for(var j = 0; j < array.Length; j++)
                                {
                                    array[j] = dt.Rows[i][j].ToString();
                                }

                                dataSet.Add(new ListImportModel { lists = array });
                            }
                            return (IActionResult)dataSet;//problem
                        }
                    }
                }
            }
            return View();
        }



    }
}
