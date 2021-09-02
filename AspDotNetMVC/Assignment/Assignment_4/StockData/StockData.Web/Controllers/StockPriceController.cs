using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockData.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockData.Web.Controllers
{
    public class StockPriceController : Controller
    {
        private readonly ILogger<StockPriceController> _logger;

        public StockPriceController(ILogger<StockPriceController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new CreateStockPriceModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateStockPriceModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateStockPric();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Stock Pric");
                    _logger.LogError(ex, "Create Stock Pric Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetStockPriceData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListStockPriceModel();
            var data = model.GetStockPrice(dataTablesModel);
            return Json(data);
        }

        //public IActionResult Edit(int id)
        //{
        //    var model = new EditCompanyModel();
        //    model.LoadModelData(id);
        //    return View(model);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Edit(EditCompanyModel model)
        //{
        //    model.UpdateCompany();
        //    return View(model);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Delete(int id)
        //{
        //    var model = new ListCompanyModel();

        //    model.Delete(id);

        //    return RedirectToAction(nameof(Data));
        //}

    }
}
