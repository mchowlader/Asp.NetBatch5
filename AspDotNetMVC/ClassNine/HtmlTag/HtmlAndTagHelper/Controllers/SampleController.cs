using HtmlAndTagHelper.Models;
using HtmlAndTagHelper.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAndTagHelper.Controllers
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
            SampleView view = new SampleView();
            return View(view);
        }

        public IActionResult SignIn()
        {
            SampleView view = new SampleView();
            return View(view);
        }

        public IActionResult LogIn()
        {
           
            return View();

            var name = _databaseService.GetName();
        }

        public IActionResult Account()
        {

            return View();
        }

    }
}
