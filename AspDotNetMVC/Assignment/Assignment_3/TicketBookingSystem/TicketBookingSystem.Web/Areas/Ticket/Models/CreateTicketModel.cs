using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using TicketBookingSystem.Booking.Sevices;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Ticket.Models
{
    public class CreateTicketModel
    {
        [Required, Range(1, 100000)]
        public int CustomerId { get; set; }
        [Required, MaxLength(100, ErrorMessage = "less than 100 ")]
        public string Destination { get; set; }
        [Required, Range(1, 100000)]
        public int TicketFee { get; set; }

        private readonly ITicketService _ticketService;

        public CreateTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }

        public CreateTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        internal void CreateTicket()
        {
            var ticket = new Booking.BusinessObjects.Ticket() 
            {
                CustomerId = CustomerId,
                Destination = Destination,
                TicketFee = TicketFee
            };
            _ticketService.CreateTicket(ticket);
        }

    }
}
