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
            return View();
        }

        public IActionResult CustomFields()
        {
            return View();
        }

        public IActionResult Contacts()
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
