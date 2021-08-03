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
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new CreateTicketModel();
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateTicketModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateTicket();

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid Customer");
                    _logger.LogError(ex, "Failed to booking ticket");
                }
            }
            return View(model);
        }

        public IActionResult Data()
        {
            return View();
        }

        public JsonResult GetTicketData()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ListTicketModel();
            var data = model.GetTicketData(tableModel);

            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditTicketModel();
            model.LoadModelData(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditTicketModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.Update();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to update ticket");
                    _logger.LogError(ex, "Update Product Failed");
                }
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = new ListTicketModel();
            model.Delete(id);
            return RedirectToAction(nameof(Data));
        }

    }
}
