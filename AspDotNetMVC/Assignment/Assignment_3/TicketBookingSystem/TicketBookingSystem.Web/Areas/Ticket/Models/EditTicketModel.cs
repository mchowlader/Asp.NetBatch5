using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Sevices;
using Autofac;
using System.ComponentModel.DataAnnotations;

namespace TicketBookingSystem.Web.Areas.Ticket.Models
{
    public class EditTicketModel
    {
        [Required, Range(1, 50000)]
        public int? Id { get; set; }
        [Required, Range(1, 100000)]
        public int? CustomerId { get; set; }
        [Required, MaxLength(100, ErrorMessage = "less than 100 ")]
        public string Destination { get; set; }
        [Required, Range(1, 100000)]
        public int? TicketFee { get; set; }

        private readonly ITicketService _ticketService;

        public EditTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }

        public EditTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        internal void LoadModelData(int id)
        {
            var ticket = _ticketService.GetTicketData(id);

            Id = ticket?.Id;
            CustomerId = ticket?.CustomerId;
            Destination = ticket.Destination;
            TicketFee = ticket?.TicketFee;
            
        }

        internal void Update()
        {
            var ticket = new Booking.BusinessObjects.Ticket()
            {
                Id = Id.HasValue ? Id.Value : 0,
                CustomerId = CustomerId.HasValue? CustomerId.Value : 0,
                Destination = Destination,
                TicketFee = TicketFee.HasValue? TicketFee.Value : 0
            };

            _ticketService.UpdateTicket(ticket);
        }
    }
}
