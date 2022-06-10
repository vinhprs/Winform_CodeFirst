using DBMS_ManagerCar.Models;
using System.Data.Entity.ModelConfiguration;

namespace DBMS_ManagerCar.Maps
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            Property(ct => ct.CategoryName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            Property(ct => ct.Seat)
                .IsRequired();
        }
    }
}
