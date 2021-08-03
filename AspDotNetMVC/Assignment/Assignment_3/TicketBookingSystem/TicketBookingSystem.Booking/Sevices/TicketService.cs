using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.Exceptions;
using TicketBookingSystem.Booking.UnitOfWorks;

namespace TicketBookingSystem.Booking.Sevices
{
    public class TicketService : ITicketService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;

        public TicketService(IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitOfWork = bookingUnitOfWork;
        }

        public void CreateTicket(Ticket ticket)
        {
            var customersAll = _bookingUnitOfWork.Customers.GetAll();

           foreach(var customer in customersAll)
            {
                if (customer.Id == ticket.CustomerId)

                {
                    _bookingUnitOfWork.Tickets.Add(
                     new Entities.Ticket()
                     {
                         CustomerId = ticket.CustomerId,
                         Destination = ticket.Destination,
                         TicketFee = ticket.TicketFee
                     });
                    _bookingUnitOfWork.Save();
                }
            }
        }

        public void DeleteTicket(int id)
        {
            _bookingUnitOfWork.Tickets.Remove(id);
            _bookingUnitOfWork.Save();
        }

        public (IList<Ticket> records, int total, int totalDisplay) GetTicketData(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var ticketData = _bookingUnitOfWork.Tickets.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.CustomerId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from ticket in ticketData.data
                              select new Ticket()
                              {
                                  CustomerId = ticket.CustomerId,
                                  Destination = ticket.Destination,
                                  TicketFee = ticket.TicketFee,
                                  Id = ticket.Id
                              }).ToList();

            return (resultData, ticketData.total, ticketData.totalDisplay);

        }

        public Ticket GetTicketData(int id)
        {
            var ticket = _bookingUnitOfWork.Tickets.GetById(id);

            if (ticket == null) return null;

            return new Ticket()
            {
                Id = ticket.Id,
                CustomerId = ticket.CustomerId,
                Destination = ticket.Destination,
                TicketFee = ticket.TicketFee
            };
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new InvalidOperationException("ticket is missing");
            if (IsIdAlreadyUsed(ticket.CustomerId, ticket.Id))
                throw new DuplicateIdException("Product name already used in other Product");

            var ticketEntity = _bookingUnitOfWork.Tickets.GetById(ticket.Id);
      
            if (ticketEntity != null)
            {
                ticketEntity.Id = ticket.Id;
                ticketEntity.CustomerId = ticket.CustomerId;
                ticketEntity.Destination = ticket.Destination;
                ticketEntity.TicketFee = ticket.TicketFee;

                _bookingUnitOfWork.Save();
            }

            else
                throw new InvalidOperationException("Couldn't find product");
        }

        private bool IsIdAlreadyUsed(int id, int customerId) =>
            _bookingUnitOfWork.Tickets.GetCount(x => x.CustomerId == customerId && x.Id != id ) > 0;
    }
}
