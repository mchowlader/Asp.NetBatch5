using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Web.Areas.Account.Controllers
{
    [Area("Account"), Authorize(Policy = "Restriction")]
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
