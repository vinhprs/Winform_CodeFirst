using System;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using DBMS_ManagerCar.Models;

namespace DBMS_ManagerCar.CRUD
{
    public class RentralTransact
    {
        Context context = new Context();

        // Thêm vào bảng Customer khi có khách hàng mới thuê xe
        public void insertCusANDupdateCarStatus(string name, string mobileNum, string gender,
            DateTime DOB, string address, string carName)
        {
            var newCus = new Customer
            {
                CustomerName = name,
                ContactNum = mobileNum,
                Gender = gender,
                DOB = DOB,
                Address = address
            };
            context.Customers.Add(newCus);

            var carId = context.Cars
                        .Where(c => c.CarName == carName)
                        .Select(c => c.CarId);
            var updateCar = context.Cars.Find(carId.First());
            updateCar.Available = false;

            context.SaveChanges();
        }

        // Tạo ra đơn booking khi có khách hàng thuê xe
        public void newBooking(string customerName, string carName, DateTime BookingDate, double price, bool status)
        {
            var customerId = context.Customers
                                .Where(cus => cus.CustomerName == customerName)
                                .Select(cus => cus.CustomerId);
            var carId = context.Cars
                                .Where(c => c.CarName == carName)
                                .Select(c => c.CarId);

            var toInsertBooking = new Booking
            {
                CustomerId = customerId.First(),
                CarId = carId.First(),
                BookingDate = BookingDate,
                Total = price,
                BillStatus = status
            };

            context.Bookings.Add(toInsertBooking);
            context.SaveChanges();
        }

        // Tìm kiếm khách hàng theo tên
        public void findCustomer(string cusName)
        {
            var cusId = context.Customers
                        .Where(c => c.CustomerName == cusName)
                        .Select(c => c.CustomerId);

            var resultCus = context.Customers
                            .Where(c => c.CustomerName.Contains(cusName))
                            .Select(c => new
                            {
                                c.CustomerId,
                                c.CustomerName,
                                c.DOB,
                                c.ContactNum,
                                c.Gender,
                                c.Address
                            });
        }

        // Xác nhận đơn book cho khách hàng và tạo hóa đơn
        public void paid(int id)
        {
            var bookingId = context.Bookings
                            .Where(b => b.CustomerId == id)
                            .Select(b => b.BookingId);
            var toUpdate = context.Bookings.Find(bookingId.First());
            // da xac nhan
            toUpdate.BillStatus = true;

            context.SaveChanges();
        }

        // Tạo bill 
        public void newBillDetail(string cusName, DateTime paidDate)
        {
            var cusId = context.Customers
                            .Where(c => c.CustomerName == cusName)
                            .Select(c => c.CustomerId);
            var bookingId = context.Bookings
                             .Where(b => b.CustomerId == cusId.FirstOrDefault())
                             .Select(b => b.BookingId);
            var cost = context.Bookings.Select(b => b.Total);

            var newInsert = new BillDetail
            {
                BookingId = bookingId.First(),
                CustomerId = cusId.FirstOrDefault(),
                TotalCost = cost.First(),
                BillCreateDate = paidDate
            };

            context.BillDetails.Add(newInsert);
            context.SaveChanges();
        }
    }
}
