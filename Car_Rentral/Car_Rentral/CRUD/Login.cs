using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS_ManagerCar.Models;

namespace DBMS_ManagerCar.CRUD
{
    public class Login
    {
        Context context = new Context();

        // Tạo tài khoản cho nhân viên
        public void newEmp(string name, string mobile, string gender, string mail,
            string username, string password, string role, double salary )
        {
            var insertEmp = new Employee
            {
                    EmployeeName = name,
                    MobileNum = mobile,
                    Gender = gender,
                    Email = mail,
                    UserName = username,
                    PassWord = password,
                    Role = role,
                    Salary = salary
            };

            context.Employees.Add(insertEmp);
            context.SaveChanges();
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
