using Autofac;
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
        private readonly ILifetimeScope _scope;
        public ImportController(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Imports()
        {
            var model = _scope.Resolve<ImportModel>();
            model.LoadGroupProperty();
            var groupData = model.groupsList;
            groupData.Insert(0, new Transfer.BusinessObjects.Group { Id = 0, GroupName = "Select Group" });
            ViewBag.data = groupData;
            return View(model);
        }
    }
}
