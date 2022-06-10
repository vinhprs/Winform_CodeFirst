using DBMS_ManagerCar.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBMS_ManagerCar.Maps
{
    public class ManufactorMap : EntityTypeConfiguration<Manufactor>
    {
        public ManufactorMap()
        {
            Property(m => m.ManufactorName)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
