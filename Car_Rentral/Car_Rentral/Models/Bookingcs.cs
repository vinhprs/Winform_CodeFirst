using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_ManagerCar.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        // Foreign key [CustomerID]
        public virtual Customer Customer { get; set; }
        public int CarId { get; set; }
        // Foreign key [CarID]
        public virtual Car Car { get; set; }
        public DateTime? BookingDate { get; set; }
        public double Total { get; set; }
        public bool BillStatus { get; set; }
    }
}
