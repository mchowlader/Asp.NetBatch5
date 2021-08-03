using ECommerceSystem.Item.Exceptions;
using ECommerceSystem.Web.Areas.Admin.Models;
using ECommerceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.CreateProduct();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create product");
                    _logger.LogError(ex, "Create Product Failed");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            //var model = new ProductListModel();
            return View();
        }

        public JsonResult GetProductData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListProductModel();
            var data = model.GetProducts(dataTablesModel);

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
                catch(DuplicateNameException ex)
                {
                    ModelState.AddModelError("", "Failed to update product");
                    _logger.LogError(ex, "Update Product Failed");
                }
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new ListProductModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }
    }
}
