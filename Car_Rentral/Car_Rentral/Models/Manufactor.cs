using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DBMS_ManagerCar.Models
{
    public class Manufactor
    {

        public int ManufactorId { get; set; }
        public string ManufactorName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }

}
