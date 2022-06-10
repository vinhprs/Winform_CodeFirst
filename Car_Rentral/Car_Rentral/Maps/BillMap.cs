using DBMS_ManagerCar.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBMS_ManagerCar.Maps
{
    public class BillMap : EntityTypeConfiguration<BillDetail>
    {
        public BillMap()
        {
            Property(b => b.BillCreateDate)
                 .HasPrecision(10);

        }
    }
}
