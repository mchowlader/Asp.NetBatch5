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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
           
        }

        public IActionResult Create()
        {
            var model = new CreateProductModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductModel model)
        {
            model.CreateProduct();
            return View(model);

        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetProductData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListProductModel();
            var data = model.GetProduct(dataTableModel);

            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditProductModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Update Product");
                    _logger.LogError(ex, "----Failed----");
                }
            }
            return View();
        }
        
        public IActionResult Delete(int id)
        {
            var model = new ListProductModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
