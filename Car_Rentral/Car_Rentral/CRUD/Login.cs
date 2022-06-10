using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS_ManagerCar.Models;
using System.Windows.Forms;

namespace DBMS_ManagerCar.CRUD
{
    public class Login
    {
        Context context = new Context();

        // Create account for employee
        public void newEmp(string name, string phoneNumber, string gender, string mail,
            string username, string password, string role, double salary )
        {
            var createdEmployee = new Employee
            {
                    EmployeeName = name,
                    MobileNum = phoneNumber,
                    Gender = gender,
                    Email = mail,
                    UserName = username,
                    PassWord = password,
                    Role = role,
                    Salary = salary
            };
            try {
                var countAccountExisted = context.Employees.Where(existedEmployee => username == existedEmployee.UserName || mail == existedEmployee.Email).Count();
                if (countAccountExisted >= 1)
                {
                    MessageBox.Show("Cannot create employee because this email or username is already existed");
                } else
                {
                    context.Employees.Add(createdEmployee);
                    context.SaveChanges();
                    MessageBox.Show("Employee created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Xóa tài khoản nhân viên
        public void deleteEmp(int id)
        {
            var toDelete = context.Employees.Find(id);

            context.Employees.Remove(toDelete);
            context.SaveChanges();
        }
    }
}
