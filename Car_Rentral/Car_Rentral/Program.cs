using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_ManagerCar.Models;
namespace DBMS_ManagerCar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var context = new Context())
            {

                var car1 = new Car
                {
                    ManufactorId = 2,
                    CateGoryId = 3,
                    CarName = "I8",
                    Price = 200000,
                    Available = true,
                    Color = "Red"
                };
                var car2 = new Car
                {
                    ManufactorId = 3,
                    CateGoryId = 1,
                    CarName = "Camry",
                    Price = 250000,
                    Available = true,
                    Color = "Blue"
                };
                var car3 = new Car
                {
                    ManufactorId = 1,
                    CateGoryId = 4,
                    CarName = "E-200",
                    Price = 300000,
                    Available = true,
                    Color = "White"
                };
                var car4 = new Car
                {
                    ManufactorId = 6,
                    CateGoryId = 2,
                    CarName = "Phantom",
                    Price = 320000,
                    Available = true,
                    Color = "Red"
                };
                var car5 = new Car
                {
                    ManufactorId = 5,
                    CateGoryId = 3,
                    CarName = "LUX A",
                    Price = 270000,
                    Available = true,
                    Color = "Black"
                };
                var car6 = new Car
                {
                    ManufactorId = 4,
                    CateGoryId = 2,
                    CarName = "812",
                    Price = 280000,
                    Available = true,
                    Color = "Green"
                };
                var car7 = new Car
                {
                    ManufactorId = 1,
                    CateGoryId = 1,
                    CarName = "Maybach S650",
                    Price = 220000,
                    Available = true,
                    Color = "White"
                };
                var car8 = new Car
                {
                    ManufactorId = 5,
                    CateGoryId = 4,
                    CarName = "VF8",
                    Price = 210000,
                    Available = true,
                    Color = "Red"
                };
                var car9 = new Car
                {
                    ManufactorId = 6,
                    CateGoryId = 4,
                    CarName = "Dawn",
                    Price = 250000,
                    Available = true,
                    Color = "Black"
                };
                var car10 = new Car
                {
                    ManufactorId = 1,
                    CateGoryId = 2,
                    CarName = "C-250",
                    Price = 420000,
                    Available = true,
                    Color = "Blue"
                };

                if (!context.Database.Exists())
                {

                    context.Cars.Add(car1);
                    context.Cars.Add(car2);
                    context.Cars.Add(car3);
                    context.Cars.Add(car4);
                    context.Cars.Add(car5);
                    context.Cars.Add(car6);
                    context.Cars.Add(car7);
                    context.Cars.Add(car8);
                    context.Cars.Add(car9);
                    context.Cars.Add(car10);

                    context.SaveChanges();
                }
            }
            Application.Run(new frm_DBMS());
        }
    }
}
