using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using TicketBookingSystem.Booking.Sevices;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Ticket.Models
{
    public class ListTicketModel
    {
        private readonly ITicketService _ticketService;

        public ListTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }

        public ListTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        internal object GetTicketData(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _ticketService.GetTicketData(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "CustomerId", "Destination", "TicketFee" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from ticket in data.records
                        select new string[]
                        {
                            ticket.CustomerId.ToString(),
                            ticket.Destination,
                            ticket.TicketFee.ToString(),
                            ticket.Id.ToString()
                        }).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _ticketService.DeleteTicket(id);
        }
    }

}


