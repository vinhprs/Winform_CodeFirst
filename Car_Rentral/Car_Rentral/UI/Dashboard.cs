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

namespace DBMS_ManagerCar
{
    public partial class Dashboard : Form
    {
        Context context = new Context();
        function fn = new function();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            

            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
            
        }

        private void btnAddCars_Click(object sender, EventArgs e)
        {
            
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            uC_UserCheckOut1.Visible = true;
            uC_UserCheckOut1.BringToFront();

            
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            uC_CustomerDetail1.Visible = true;
            uC_CustomerDetail1.BringToFront();

            
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();

        }


        private void uC_AddRoom1_Load(object sender, EventArgs e)
        {

        }

        private void uC_AddRoom1_Load_1(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Employee1.Visible = false;

            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            btnAddCars.PerformClick();
            frm_DBMS frm1 = new frm_DBMS();
            String userName = frm1.textBoxValue();

            var userRole = context.Employees
                            .Where(em => em.UserName == userName)
                            .Select(em => em.Role).First();
            
        }

        private void uC_AddRoom1_Load_2(object sender, EventArgs e)
        {

        }

        private void uC_CustomerRegistration1_Load(object sender, EventArgs e)
        {

        }

        private void uC_CustomerDetail1_Load(object sender, EventArgs e)
        {

        }

        private void uC_Employee1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_DBMS fo = new frm_DBMS();
            fo.Show();
        }

        private void uC_CustomerRegistration1_Load_1(object sender, EventArgs e)
        {

        }

        private void uC_UserCheckOut1_Load(object sender, EventArgs e)
        {

        }
    }
}
