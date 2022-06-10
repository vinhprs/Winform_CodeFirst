using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_ManagerCar.CRUD;
using DBMS_ManagerCar.Models;

namespace DBMS_ManagerCar.All_User_Control
{
    public partial class btnEditCar : UserControl
    {
        Context context = new Context();
        addCar car = new addCar();
        function fn = new function();
        String query;

        public btnEditCar()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            var getCustomer = context.Categories.Join(
                    context.Cars,
                    car => car.CategoryId,
                    category => category.CateGoryId, (category, car)
                    => new { Car = car, Category = category }
                )
                .Join(
                    context.Manufactors,
                    manufactor => manufactor.Car.ManufactorId,
                    car => car.ManufactorId, (car, manufactor)
                    => new
                    {
                       CarID = car.Car.CarId,
                       ManufactorName = manufactor.ManufactorName,
                       CategoryName = car.Category.CategoryName,
                       Seat = car.Category.Seat,
                       CarName = car.Car.CarName,
                       Color = car.Car.Color,
                       Price = car.Car.Price,
                       Available = car.Car.Available
                    }).Where(r => r.Available == true)
                .ToList();

            DataGridView1.DataSource = getCustomer;
        }
        private void customLoad()
        {
            var getCustomer = context.Categories.Join(
                     context.Cars,
                     car => car.CategoryId,
                     category => category.CateGoryId, (category, car)
                     => new { Car = car, Category = category }
                 )
                 .Join(
                     context.Manufactors,
                     manufactor => manufactor.Car.ManufactorId,
                     car => car.ManufactorId, (car, manufactor)
                     => new
                     {
                         CarID = car.Car.CarId,
                         ManufactorName = manufactor.ManufactorName,
                         CategoryName = car.Category.CategoryName,
                         Seat = car.Category.Seat,
                         CarName = car.Car.CarName,
                         Color = car.Car.Color,
                         Price = car.Car.Price,
                         Available = car.Car.Available
                     }).Where(r => r.Available == true)
                 .ToList();

            DataGridView1.DataSource = getCustomer;
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (txtColor.Text != "" && txtType.Text != "" && txtCar.Text != "" && txtPrice.Text != "" && txtManu.Text != "")
            {
                String color = txtColor.Text;
                String type = txtType.Text;
                String carName = txtCar.Text;
                int price = int.Parse(txtPrice.Text);
                String manu = txtManu.Text;
                bool available = true;

              
                car.InsertCar(type, manu, carName, price, color, available);
                              customLoad();
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        int id;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id = int.Parse(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            } catch
            {
                MessageBox.Show("Click too fast!.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                car.deleteCar(id);

                MessageBox.Show("Car deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customLoad();
                clearAll();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtColor.Text != "" && txtType.Text != "" && txtCar.Text != "" && txtPrice.Text != "" && txtManu.Text != "")
            {

                String color = txtColor.Text;
                String type = txtType.Text;
                String carName = txtCar.Text;
                int price = int.Parse(txtPrice.Text);
                String manu = txtManu.Text;
                bool available = true;
                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    car.updateCar(type, manu, carName, price, color, available, id);

                    MessageBox.Show("Car edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    customLoad();
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
            txtCar.Clear();
            txtType.SelectedIndex = -1;
            // txtCar.SelectedIndex = -1;
            txtPrice.Clear();
        }


        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }

        private void txtColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtManu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
