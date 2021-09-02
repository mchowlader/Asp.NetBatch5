using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockData.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateCompanyModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateCompany();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Company");
                    _logger.LogError(ex, "Create Company Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetCompanyData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListCompanyModel();
            var data = model.GetCompany(dataTablesModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditCompanyModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCompanyModel model)
        {
            model.UpdateCompany();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ListCompanyModel();

            model.Delete(id);

            return RedirectToAction(nameof(Data));
        }
    }
}
