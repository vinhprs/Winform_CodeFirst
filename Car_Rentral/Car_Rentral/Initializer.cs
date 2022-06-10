using System.Collections.Generic;
using System.Data.Entity;
using DBMS_ManagerCar.Models;

namespace DBMS_ManagerCar
{
    public class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            // Khoi tao NSX
            IList<Manufactor> manufactors = new List<Manufactor>();
            manufactors.Add(new Manufactor() { ManufactorName = "Mercedes Benz" });
            manufactors.Add(new Manufactor() { ManufactorName = "BMW" });
            manufactors.Add(new Manufactor() { ManufactorName = "Toyota" });
            manufactors.Add(new Manufactor() { ManufactorName = "Ferari" });
            manufactors.Add(new Manufactor() { ManufactorName = "Vinfast" });
            manufactors.Add(new Manufactor() { ManufactorName = "RollRoyce" });
            context.Manufactors.AddRange(manufactors);

            // Khoi tao loai xe
            IList<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                CategoryName = "XEKHACH",
                Seat = 40,
                Fuel = "DAU"
            });
            categories.Add(new Category()
            {
                CategoryName = "GIADINH",
                Seat = 4,
                Fuel = "DIEN"
            });
            categories.Add(new Category()
            {
                CategoryName = "THETHAO",
                Seat = 2,
                Fuel = "DAU"
            });
            categories.Add(new Category()
            {
                CategoryName = "PHOTHONG",
                Seat = 7,
                Fuel = "XANG"
            });
            context.Categories.AddRange(categories);

            // khoi tao nhan vien
            IList<Employee> employees = new List<Employee>();
            employees.Add(new Employee()
            {
                EmployeeName = "Nguyen Cao Hong Vinh",
                MobileNum = "0916272466",
                Gender = "Male",
                Email = "vinhnguyen19052002@gmail.com",
                UserName = "vinhprs",
                PassWord = "1234",
                Role = "Admin",
                Salary = 20000
            }) ;
            employees.Add(new Employee()
            {
                EmployeeName = "Huynh Ngoc Tuan Kiet",
                MobileNum = "0915274566",
                Gender = "Male",
                Email = "tuankiet@gmail.com",
                UserName = "tuankiet",
                PassWord = "123",
                Role = "Employee",
                Salary = 10000
            });
            context.Employees.AddRange(employees);

            /*
            // Khoi tao xe
            IList<Car> cars = new List<Car>();
            cars.Add(new Car()
            {
                ManufactorId = 2,
                CateGoryId = 3,
                CarName = "I8",
                Price = 200000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 3,
                CateGoryId = 1,
                CarName = "Camry",
                Price = 250000,
                Available = true,
                Color = "Blue"
            });
            cars.Add(new Car()
            {
                ManufactorId = 1,
                CateGoryId = 4,
                CarName = "E-200",
                Price = 300000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 6,
                CateGoryId = 2,
                CarName = "Phantom",
                Price = 320000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 5,
                CateGoryId = 3,
                CarName = "LUX A",
                Price = 270000,
                Available = true,
                Color = "Black"
            });
            cars.Add(new Car()
            {
                ManufactorId = 4,
                CateGoryId = 2,
                CarName = "812",
                Price = 280000,
                Available = true,
                Color = "Green"
            });
            cars.Add(new Car()
            {
                ManufactorId = 1,
                CateGoryId = 1,
                CarName = "Maybach S650",
                Price = 220000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 5,
                CateGoryId = 4,
                CarName = "VF8",
                Price = 210000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 6,
                CateGoryId = 4,
                CarName = "Dawn",
                Price = 250000,
                Available = true,
                Color = "Black"
            });
            cars.Add(new Car()
            {
                ManufactorId = 1,
                CateGoryId = 2,
                CarName = "C-250",
                Price = 420000,
                Available = true,
                Color = "Blue"
            });
            cars.Add(new Car()
            {
                ManufactorId = 3,
                CateGoryId = 2,
                CarName = "Innova",
                Price = 520000,
                Available = true,
                Color = "Green"
            });
            cars.Add(new Car()
            {
                ManufactorId = 2,
                CateGoryId = 3,
                CarName = "640i",
                Price = 120000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 4,
                CateGoryId = 1,
                CarName = "488",
                Price = 2800000,
                Available = true,
                Color = "Green"
            });
            cars.Add(new Car()
            {
                ManufactorId = 4,
                CateGoryId = 4,
                CarName = "F8",
                Price = 290000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 5,
                CateGoryId = 4,
                CarName = "President",
                Price = 720000,
                Available = true,
                Color = "Blue"
            });
            cars.Add(new Car()
            {
                ManufactorId = 2,
                CateGoryId = 2,
                CarName = "218i",
                Price = 120000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 1,
                CateGoryId = 3,
                CarName = "R31",
                Price = 240000,
                Available = true,
                Color = "Black"
            });
            cars.Add(new Car()
            {
                ManufactorId = 6,
                CateGoryId = 1,
                CarName = "C-300",
                Price = 260000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 3,
                CateGoryId = 1,
                CarName = "Falcon",
                Price = 230000,
                Available = true,
                Color = "Blue"
            });
            cars.Add(new Car()
            {
                ManufactorId = 3,
                CateGoryId = 2,
                CarName = "I10",
                Price = 260000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 6,
                CateGoryId = 4,
                CarName = "Roma",
                Price = 330000,
                Available = true,
                Color = "Green"
            });
            cars.Add(new Car()
            {
                ManufactorId = 2,
                CateGoryId = 3,
                CarName = "Black Badge",
                Price = 350000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 4,
                CateGoryId = 2,
                CarName = "Cullinan",
                Price = 510000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 1,
                CateGoryId = 2,
                CarName = "S450",
                Price = 910000,
                Available = true,
                Color = "Blue"
            });
            cars.Add(new Car()
            {
                ManufactorId = 1,
                CateGoryId = 1,
                CarName = "C-200",
                Price = 230000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 5,
                CateGoryId = 4,
                CarName = "A8",
                Price = 130000,
                Available = true,
                Color = "Green"
            });
            cars.Add(new Car()
            {
                ManufactorId = 4,
                CateGoryId = 2,
                CarName = "AMG",
                Price = 540000,
                Available = true,
                Color = "Black"
            });
            cars.Add(new Car()
            {
                ManufactorId = 3,
                CateGoryId = 3,
                CarName = "M23",
                Price = 760000,
                Available = true,
                Color = "Red"
            });
            cars.Add(new Car()
            {
                ManufactorId = 3,
                CateGoryId = 1,
                CarName = "B123",
                Price = 1330000,
                Available = true,
                Color = "White"
            });
            cars.Add(new Car()
            {
                ManufactorId = 2,
                CateGoryId = 4,
                CarName = "AMD23",
                Price = 450000,
                Available = true,
                Color = "Green"
            });
            context.Cars.AddRange(cars);
            */
            base.Seed(context);
        }
    }
}
