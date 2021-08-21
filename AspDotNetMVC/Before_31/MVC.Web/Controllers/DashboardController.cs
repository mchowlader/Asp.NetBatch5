using Microsoft.AspNetCore.Mvc;
using MVC.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Web.Controllers
{
    public class DashboardController : Controller
    {
        private IDatabaseService _databaseService;

        public DashboardController(IDatabaseService databaseService )
        {
            _databaseService = databaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Summery()
        {
            var name = _databaseService.GetName();

            return View();
        }
    }
}
