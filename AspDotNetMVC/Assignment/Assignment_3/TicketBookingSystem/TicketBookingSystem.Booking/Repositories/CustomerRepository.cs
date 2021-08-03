﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Contexts;
using TicketBookingSystem.Booking.Entities;
using TicketBookingSystem.Data;

namespace TicketBookingSystem.Booking.Repositories
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        private readonly IBookingDbContext _bookingDbContext;

        public CustomerRepository(IBookingDbContext bookingDbContext)
            : base((DbContext)bookingDbContext) { }
    }
}
