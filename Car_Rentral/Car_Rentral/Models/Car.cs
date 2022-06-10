using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_ManagerCar.Models
{
    public class Car
    {
        public Car()
        {

        }

        public int CarId { get; set; }
        public int ManufactorId { get; set; }
        public int CateGoryId { get; set; }
        // Foreign key [ManufactorID]
        public virtual Manufactor Manufactor { get; set; }
        // Foreign key [CategoryID]
        public virtual Category Category { get; set; }

        public string CarName { get; set; }
        public int Price { get; set; }
        public bool? Available { get; set; }
        public string Color { get; set; }

    }
}
