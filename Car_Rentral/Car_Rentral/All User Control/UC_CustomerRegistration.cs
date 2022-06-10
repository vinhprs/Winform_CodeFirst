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

namespace DBMS_ManagerCar.All_User_Control
{
    
    public partial class UC_CustomerRegistration : UserControl
    {
        Context context = new Context();
        function fn = new function();
        addCar car = new addCar();
        RentralTransact rentralTransact = new RentralTransact();

        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String query,ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while(sdr.Read())
            {
                for(int i=0;i < sdr.FieldCount;i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }    
            }
            sdr.Close();
        }

        double renTime;
        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtRoomNo.Items.Clear();
            //txtPrice.Clear();

            int seat = int.Parse(txtSeat.Text);

            var getCar = context.Cars.Join(
                    context.Categories,
                    category => category.CateGoryId,
                    car => car.CategoryId, (car, category)
                    => new { Category = category, Car = car })
                    .Where(r => r.Category.Seat == seat && r.Car.Available == true)
                    .Select(r => r.Car.CarName).ToList();

            txtRoomNo.DataSource = getCar;
            txtRoomNo.DisplayMember = "CarName";
            
        }
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            renTime = double.Parse(txtTime.Text);
            double cost = car.rentralCost(txtRoomNo.Text, renTime);

            txtPrice.Text = cost.ToString();
            } catch
            {
                MessageBox.Show("ERROR! Please select time first!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            if(txtName.Text !="" && txtContact.Text != "" && txtGender.Text != "" && txtDoB.Text != "" && txtAddress.Text !="")
            {
                String name = txtName.Text;
                String num = txtContact.Text;
                String gen = txtGender.Text;
                DateTime dob = DateTime.Parse(txtDoB.Text);
                String address = txtAddress.Text;
                String carName = txtRoomNo.Text;
                bool status = false;

                rentralTransact.insertCusANDupdateCarStatus(name, num, gen, dob, address, carName);
                MessageBox.Show("Car named '"+txtRoomNo.Text+"' is rented succesfully!", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                rentralTransact.newBooking(txtName.Text, txtRoomNo.Text, DateTime.Parse(txtCheckIn.Text), renTime, status);
            }
            else
            {
                MessageBox.Show("All fields are madetory.", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtGender.SelectedIndex = -1;
            txtDoB.ResetText();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtSeat.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtTime.Clear();
            txtPrice.Clear();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            //clearAll();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
