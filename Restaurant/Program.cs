using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Class.Admin;
using Restaurant.Class.McD;
using Restaurant.Class.NewCustomer;
using Restaurant.Class.Pizza_Hut;
using Restaurant.Interface;

namespace Restaurant
{
    class Program
    {
        public static AdminClass admin = new AdminClass();

        static void Main(string[] args)
        {
            InitializeLists();
            Start(admin);
            Console.ReadKey();
        }

        private static void InitializeLists()
        {
            RestroMcD.SetMenuItems();
            RestroMcD.SetTables();
            RestroPizzaHut.SetMenuItems();
            RestroPizzaHut.SetTables();
        }

        public static void Start(AdminClass admin)
        {
            IRestro restro = null;
            Console.WriteLine("Select a Restaurant");
            Console.WriteLine("1. McD \n2.Pizza Hut");
            var choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    restro = new RestroMcD();
                    ChooseYourRole(restro, admin);
                    break;
                case 2:
                    restro = new RestroPizzaHut();
                    ChooseYourRole(restro, admin);
                    break;
            }
        }

        private static void ChooseYourRole(IRestro restro, AdminClass admin)
        {
            Console.WriteLine("\nChoose Your Role\n");
            Console.WriteLine("1. Admin\n2. Customer\n3.Exit");
            Console.WriteLine("---------------------------------------------");
            var choice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("---------------------------------------------");
            switch (choice)
            {
                case 1:
                    admin.ShowFunctionalityOfAdmin(admin);
                    break;
                case 2:
                    Customer customer = new Customer();
                    customer.UpdateInformation(admin, restro,customer);
                    break;
            }
        }
    }
}
    

