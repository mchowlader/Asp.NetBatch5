using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Booking.Sevices
{
    public interface ITicketService
    {
        void CreateTicket(Ticket ticket);
        (IList<Ticket> records, int total, int totalDisplay) GetTicketData(int pageIndex,
            int pageSize, string searchText, string sortText);
        Ticket GetTicketData(int id);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
    }
}
