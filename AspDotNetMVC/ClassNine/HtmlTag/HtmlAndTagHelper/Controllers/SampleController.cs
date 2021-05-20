using HtmlAndTagHelper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAndTagHelper.Controllers
{
    public class SampleController : Controller
    {
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
        }

    }
}
