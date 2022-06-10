using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_ManagerCar.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DOB { get; set; }
        public string ContactNum { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool UserStatus { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
