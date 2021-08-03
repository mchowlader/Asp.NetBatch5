using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.Sevices;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Ticket.Models
{
    public class ListCustomerModel
    {

        private readonly ICustomerService _customerService;

        public ListCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public ListCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal object GetCustomers(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _customerService.GetCustomers(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Name", "Age", "Address" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                           record.Name,
                           record.Age.ToString(),
                           record.Address,
                           record.Id.ToString()
                        }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
