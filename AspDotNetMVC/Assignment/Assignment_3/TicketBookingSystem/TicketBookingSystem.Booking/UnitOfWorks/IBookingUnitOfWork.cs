using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Repositories;
using TicketBookingSystem.Data;

namespace TicketBookingSystem.Booking.UnitOfWorks
{
    public interface IBookingUnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get; }
        public ITicketRepository Tickets { get; }
    }
}
