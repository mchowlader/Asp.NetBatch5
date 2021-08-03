using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Sevices;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Ticket.Models
{
    public class CreateCustomerModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, Range(1,100)]
        public int Age { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;

        public CreateCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public CreateCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal void CreateCustomer()
        {
            var customer = new Customer()
            {
                Name = Name,
                Age = Age,
                Address = Address
            };
            _customerService.CreateCustomer(customer);
        }
    }
}
