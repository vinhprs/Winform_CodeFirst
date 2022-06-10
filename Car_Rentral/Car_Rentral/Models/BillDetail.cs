using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DBMS_ManagerCar.Models
{
    public class BillDetail
    {

        [Key]
        public int BillId { get; set; }
        public int BookingId { get; set; }
        // Foreign key [BookingID]
        public virtual Booking Booking { get; set; }
        public int CustomerId { get; set; }
        // Foreign key [CustomerID]
        public virtual Customer Customer { get; set; }
        public double TotalCost { get; set; }
        public DateTime BillCreateDate { get; set; }
    }
}
