using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Booking.Sevices
{
    public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, 
            int pageSize, string searchText, string SortText);
        Customer GetCustomers(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
