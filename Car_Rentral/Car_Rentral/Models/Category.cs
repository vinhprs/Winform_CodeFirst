using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_ManagerCar.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Seat { get; set; }
        public string Fuel { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
