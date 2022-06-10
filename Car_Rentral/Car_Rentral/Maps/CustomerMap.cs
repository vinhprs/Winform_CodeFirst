using DBMS_ManagerCar.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBMS_ManagerCar.Maps
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            Property(c => c.ContactNum)
                .IsRequired()
                .HasMaxLength(10);
            Property(c => c.CustomerName)
                .IsRequired();
            Property(c => c.Email)
                .IsOptional();
            Property(c => c.DOB)
                .IsOptional()
                .HasPrecision(10);

        }
    }
}
