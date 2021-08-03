using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Booking.Exceptions
{
    public class DuplicateIdException : Exception
    {
        public DuplicateIdException(string message)
            : base(message) { }
    }
}
