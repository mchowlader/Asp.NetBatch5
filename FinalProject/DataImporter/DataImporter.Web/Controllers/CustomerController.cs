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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Group()
        {
            return View();
        }
        public IActionResult CreateGroup()
        {
            var model = new CreateGroupModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateGroup(CreateGroupModel model)
        {
            model.CreateGroupName();
            return View(model);
        }

        public IActionResult CustomFields()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult ImportData()
        {
            return View();
        }
        public IActionResult Imports()
        {
            return View();
        }

        public IActionResult Exports()
        {
            return View();
        }


    }
}
