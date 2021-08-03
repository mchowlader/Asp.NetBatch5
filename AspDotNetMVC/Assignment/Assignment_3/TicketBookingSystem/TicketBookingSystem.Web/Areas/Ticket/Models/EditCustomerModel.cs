using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Sevices;
using Autofac;
using System.ComponentModel.DataAnnotations;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Ticket.Models
{
    public class EditCustomerModel
    {
        [Required, Range(1, 50000)]
        public int? Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int? Age { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;

        public EditCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public EditCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal void LoadModelData(int id)
        {
            var customer = _customerService.GetCustomers(id);

            Id = customer?.Id;
            Name = customer.Name;
            Age = customer?.Age;
            Address = customer?.Address;
        }

        internal void Update()
        {
            var customer = new Customer()
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Age = Age.HasValue? Age.Value : 0,
                Address = Address
            
            };

            _customerService.UpdateCustomer(customer);
        }
    }
}
