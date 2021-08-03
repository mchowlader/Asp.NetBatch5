using InventorySystem.Web.Areas.Management.Models;
using InventorySystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var model = new CreateStockModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateStockModel model)
        {if(ModelState.IsValid)
            {
                try
                {
                    model.CreateStock();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to add stock");
                    _logger.LogError(ex, "----Failed----");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetStockData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListStockModel();
            var data = model.GetStocks(dataTableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditStockModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditStockModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Update stock");
                    _logger.LogError(ex, "----Failed----");
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new ListStockModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
