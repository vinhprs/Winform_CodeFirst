using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_ManagerCar.Models;
using DBMS_ManagerCar.CRUD;

namespace DBMS_ManagerCar.All_User_Control
{
    public partial class UC_CustomerDetail : UserControl
    {
        function fn = new function();
        Context context = new Context();

        public UC_CustomerDetail()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                var resultCus = context.Customers.Join(
                    context.Bookings,
                    booking => booking.CustomerId,
                    customer => customer.CustomerId, (customer, booking)
                    => new { Booking = booking, Customer = customer }
                )
                .Join(
                    context.Cars,
                    car => car.Booking.CarId,
                    booking => booking.CarId, (booking, car)
                    => new
                    {
                        CustomerId = booking.Customer.CustomerId,
                        CustomerName = booking.Customer.CustomerName,
                        DOB = booking.Customer.DOB,
                        MobileNum = booking.Customer.ContactNum,
                        Gender = booking.Customer.Gender,
                        Address = booking.Customer.Address,
                        CarName = car.CarName,
                        Status = booking.Booking.BillStatus
                    }).ToList();
                guna2DataGridView2.DataSource = resultCus;
            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                var resultCus = context.Customers.Join(
                    context.Bookings,
                    booking => booking.CustomerId,
                    customer => customer.CustomerId, (customer, booking)
                    => new { Booking = booking, Customer = customer }
                )
                .Join(
                    context.Cars,
                    car => car.Booking.CarId,
                    booking => booking.CarId, (booking, car)
                    => new
                    {
                        CustomerId = booking.Customer.CustomerId,
                        CustomerName = booking.Customer.CustomerName,
                        DOB = booking.Customer.DOB,
                        MobileNum = booking.Customer.ContactNum,
                        Gender = booking.Customer.Gender,
                        Address = booking.Customer.Address,
                        CarName = car.CarName,
                        Status = booking.Booking.BillStatus
                    }).Where(c => c.Status == false)
                .ToList();
                guna2DataGridView2.DataSource = resultCus;
            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                var resultCus = context.Customers.Join(
                     context.Bookings,
                     booking => booking.CustomerId,
                     customer => customer.CustomerId, (customer, booking)
                     => new { Booking = booking, Customer = customer }
                 )
                 .Join(
                     context.Cars,
                     car => car.Booking.CarId,
                     booking => booking.CarId, (booking, car)
                     => new
                     {
                         CustomerId = booking.Customer.CustomerId,
                         CustomerName = booking.Customer.CustomerName,
                         DOB = booking.Customer.DOB,
                         MobileNum = booking.Customer.ContactNum,
                         Gender = booking.Customer.Gender,
                         Address = booking.Customer.Address,
                         CarName = car.CarName,
                         Status = booking.Booking.BillStatus
                     }).Where(c =>c.Status == true)
                 .ToList();
                guna2DataGridView2.DataSource = resultCus;
            }
            else if (txtSearchBy.SelectedIndex == 3)
            {
                var maxCost = context.Bookings
                                .Max(b => b.Total);
                var id = context.Bookings
                            .Where(b => b.Total == maxCost)
                            .Select(b => b.CustomerId);

                var resultCus = context.Customers.Join(
                    context.Bookings,
                    booking => booking.CustomerId,
                    customer => customer.CustomerId, (customer, booking)
                    => new { Booking = booking, Customer = customer }
                )
                .Join(
                    context.Cars,
                    car => car.Booking.CarId,
                    booking => booking.CarId, (booking, car)
                    => new
                    {
                        CustomerId = booking.Customer.CustomerId,
                        CustomerName = booking.Customer.CustomerName,
                        DOB = booking.Customer.DOB,
                        MobileNum = booking.Customer.ContactNum,
                        Gender = booking.Customer.Gender,
                        Address = booking.Customer.Address,
                        CarName = car.CarName,
                        Status = booking.Booking.BillStatus
                    }).Where(c => c.CustomerId == id.FirstOrDefault())
                .ToList();

                guna2DataGridView2.DataSource = resultCus;
            }
        }
        private void UC_CustomerDetail_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
