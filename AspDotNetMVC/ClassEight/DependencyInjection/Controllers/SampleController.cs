using DependencyInjection.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    public class SampleController : Controller
    {
        private IDatabaseService _databaseService;

        public SampleController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SampleView()
        {
            var name = _databaseService.GetName();

            return View();
           
        }
    }
}
