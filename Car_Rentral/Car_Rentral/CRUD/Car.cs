using System;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using DBMS_ManagerCar.Models;
using System.Windows.Forms;


namespace DBMS_ManagerCar.CRUD
{
    public class addCar
    {
        Context context = new Context();

       

        // Thêm xe
        public void InsertCar(string category, string manufactor, string carname, int price, string color, bool available)
        {


            using (var context = new Context())
            {
                var cID = context.Categories
                    .Where(ct => ct.CategoryName == category)
                    .Select(ct => ct.CategoryId);
                var manuID = context.Manufactors
                    .Where(mn => mn.ManufactorName == manufactor)
                    .Select(mn => mn.ManufactorId);
                var newCar = new Car
                {
                    ManufactorId = manuID.First(),
                    CateGoryId = cID.First(),
                    CarName = carname,
                    Price = price,
                    Color = color,
                    Available = available
                };

                try
                {
                    var count = context.Cars.Where(car => car.CarName == carname && car.CateGoryId == cID.FirstOrDefault() && car.ManufactorId == manuID.FirstOrDefault()).Count();
                    if (count == 1)
                    {
                        MessageBox.Show("This car is already existed");
                    } else
                    {
                        context.Cars.Add(newCar);
                        MessageBox.Show("Car added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        context.SaveChanges();
                    }

                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                }

            }
        }

        // Xóa xe
        public void deleteCar(int id)
        { 

            using (var context = new Context())
            {
                var toDelete = context.Cars.Find(id);
                context.Cars.Remove(toDelete);
                context.SaveChanges();
            }


        }

        // Update xe
        public void updateCar(string category, string manufactor, string carname, int price, string color, bool available, int id)
        {
            using (var context = new Context())
            {
                var cID = context.Categories
                    .Where(ct => ct.CategoryName == category)
                    .Select(ct => ct.CategoryId);
                var manuID = context.Manufactors
                    .Where(mn => mn.ManufactorName == manufactor)
                    .Select(mn => mn.ManufactorId);

                var toUpdate = context.Cars.Find(id);

                toUpdate.ManufactorId = manuID.First();
                toUpdate.CateGoryId = cID.First();
                toUpdate.CarName = carname;
                toUpdate.Price = price;
                toUpdate.Color = color;
                toUpdate.Available = available;
                context.SaveChanges();
            }
        }

        // Hiển thị tên xe với số chỗ ngồi được chọn
        public void getCarFromSeat(int seat)
        {
            using (var context = new Context())
            {
                var getCar = context.Cars.Join(
                        context.Categories,
                        category => category.CateGoryId,
                        car => car.CategoryId,
                        (car, category) => new
                        {
                            carName = car.CarName,
                            rSeat = category.Seat,
                            availabe = car.Available
                        }
                    ).Where(record => record.rSeat == seat && record.availabe == true)
                    .ToList();
            }
        }

        // Tính tiền thuê xe
        public double rentralCost(string name, double renTime)
        {
            
            double result = 0;
            var price = context.Cars
                            .Where(c => c.CarName == name)
                            .Select(c => c.Price);
            result = price.First() * renTime;

            return result;
        }
    }
}
