using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_ManagerCar.CRUD;
using DBMS_ManagerCar.Models;

namespace DBMS_ManagerCar.All_User_Control
{
    public partial class UC_UserCheckOut : UserControl
    {
        Context context = new Context();
        function fn = new function();
        RentralTransact rentralTransact = new RentralTransact();

        public UC_UserCheckOut()
        {
            InitializeComponent();
        }

        private void UC_UserCheckOut_Load(object sender, EventArgs e)
        {
            var getCustomer = context.Customers.Join(
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
                    }).Where(r => r.Status == false).ToList();

            guna2DataGridView1.DataSource = getCustomer;

        }

        private void customUserCheckout_Load()
        {
            var getCustomer = context.Customers.Join(
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
                   }).Where(r => r.Status == false).ToList();

            guna2DataGridView1.DataSource = getCustomer;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "")
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
                    }).Where(c => c.CustomerName.Contains(txtName.Text) && c.Status == false)
                .ToList();

                guna2DataGridView1.DataSource = resultCus;

            }
            else
            {
                var getCustomer = context.Customers.Join(
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
                    }).Where(r => r.Status == false).ToList();

                guna2DataGridView1.DataSource = getCustomer;
            }
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                try
                {

                    id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtCarName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Select customer", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtBookingDate.Text;
                    rentralTransact.paid(id);

                    MessageBox.Show("Order Confirm!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    customUserCheckout_Load();

                    rentralTransact.newBillDetail(txtCName.Text, DateTime.Parse(txtBookingDate.Text));
                    MessageBox.Show("New bill is created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtCarName.Clear();
            txtCheckOut.ResetText();
        }

        private void UC_UserCheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
