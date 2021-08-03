using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Contexts;
using TicketBookingSystem.Booking.Repositories;
using TicketBookingSystem.Data;

namespace TicketBookingSystem.Booking.UnitOfWorks
{
    public class BookingUnitOfWork : UnitOfWork, IBookingUnitOfWork
    {
        public ICustomerRepository Customers { get; private set; }
        public ITicketRepository Tickets { get; private set; }

        public BookingUnitOfWork(IBookingDbContext bookingDbContext,
            ICustomerRepository customerRepository,
            ITicketRepository ticketRepository)
            : base((DbContext)bookingDbContext) 
        {
            Customers = customerRepository;
            Tickets = ticketRepository;
        }

    }
}
