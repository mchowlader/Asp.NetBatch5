using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Web.Areas.Ticket.Models;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Ticket.Controllers
{
    [Area("Ticket")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateCustomerModel();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateCustomerModel model)
        {
            model.CreateCustomer();
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetCustomerData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListCustomerModel();
            var data = model.GetCustomers(dataTablesModel);

            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditCustomerModel();
            model.LoadModelData(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCustomerModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to update customer");  
                    _logger.LogError(ex, "Update customer failed");
                }
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new ListCustomerModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }


    }
}
