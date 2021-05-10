using DependencyInjection.Models;
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
            SampleView sampleView = new SampleView();
            return View(sampleView);
        }

        public IActionResult SampleView()
        {

            SampleView sampleView2 = new SampleView(); 
            var name = _databaseService.GetName();

            return View(sampleView2);
           
        }

        public IActionResult Privacy()
        {


            return View();

        }

        public IActionResult Change()
        {
            return View();
        }
    }
}
