using DataImporter.Web.Models.Imports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Imports()
        {
            var model = new ImportModel();
            model.LoadGroupProperty();
            var groupData = model.groupsList;
            groupData.Insert(0, new Transfer.BusinessObjects.Group { Id = 0, Name = "Select Group" });
            ViewBag.data = groupData;
            return View(model);
        }
    }
}
