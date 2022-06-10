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

namespace DBMS_ManagerCar.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        Login login = new Login();
        Context context = new Context();
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtEname.Text !="" && txtEContactNo.Text != "" && txtEGender.Text != "" && txtEmail.Text != ""
                && txtUserName.Text != "" && txtEPassword.Text != "")
            {
                String name = txtEname.Text;
                String mobile = txtEContactNo.Text;
                String gen = txtEGender.Text;
                String mail = txtEmail.Text;
                String userName = txtUserName.Text;
                String pass = txtEPassword.Text;
                String role = txtRole.Text;
                Double salary = double.Parse( txtSalary.Text);
                if(!mail.Contains("@gmail.com"))
                {
                    MessageBox.Show("Not a valid email!", "Try again!...!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    login.newEmp(name,mobile,gen,mail,userName,pass,role,salary);

                    MessageBox.Show("Employee created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearAll();
                    getMaxID();
                }
            }
            else
            {
                MessageBox.Show("Please, Fil all Fields!", "Warning...!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
           if(txtID.Text != "")
            {
                if(MessageBox.Show("Are you sure?","Comfirm...!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes) {

                    login.deleteEmp(int.Parse(txtID.Text));
                    MessageBox.Show("Employee deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1_SelectedIndexChanged(this, null);
                }
                
            }
        }
        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        public void getMaxID() 
        {
            var maxId = context.Employees
                            .Max(e => e.EmployeeId);
            

            if (maxId.ToString() != "" )
            {
                int num = int.Parse(maxId.ToString());
                LabelToSet.Text = (num + 1).ToString();
            }
        }

        public void clearAll()
        {
            txtEname.Clear();
            txtEContactNo.Clear();
            txtEGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtEPassword.Clear();
            txtRole.SelectedIndex = -1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabEmployee.SelectedIndex == 1)
            {
                getEmployee(guna2DataGridView1);
            }
            else if(tabEmployee.SelectedIndex == 2)
            {
                getEmployee(guna2DataGridView2);
            }
        }
        public void getEmployee(DataGridView dgv)
        {
            var noneAdmin = context.Employees
                            .Where(e => e.Role == "Employee")
                            .Select(e => new
                            {
                                e.EmployeeId,
                                e.EmployeeName,
                                e.MobileNum,
                                e.Gender,
                                e.Email,
                                e.UserName,
                                e.PassWord,
                                e.Role,
                                e.Salary
                            }).ToList();
            dgv.DataSource = noneAdmin;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
