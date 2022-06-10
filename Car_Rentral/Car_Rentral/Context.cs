using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DBMS_ManagerCar.Models;
using DBMS_ManagerCar.Maps;
namespace DBMS_ManagerCar
{
    public class Context : DbContext
    {
        public Context()
            : base("name=MyContextDB")
        {
            Database.SetInitializer<Context>(new Initializer());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufactor> Manufactors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ManufactorMap());
            modelBuilder.Configurations.Add(new BillMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
