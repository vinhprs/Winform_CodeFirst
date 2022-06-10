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
    public  partial class frm_DBMS : Form
    {
        function fn = new function();
        Context context = new Context();
        public static String getUserName;
        public frm_DBMS()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            var getEmp = context.Employees
                            .Where(u => u.UserName == txtUsername.Text &&
                            u.PassWord == txtPassword.Text)
                            .Select(u => new
                            {
                                u.UserName,
                                u.PassWord,
                                u.Role
                            }).ToList();


            getUserName = txtUsername.Text;

            if (getEmp.Count !=0)
            {
                labelError.Visible = false;
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
            
        }
        public String textBoxValue()
        {
            String s = getUserName;
            return s;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_DBMS_Load(object sender, EventArgs e)
        {

        }
    }
}
