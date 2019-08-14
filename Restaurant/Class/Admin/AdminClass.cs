using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Restaurant.Class.McD;
using Restaurant.Class.NewCustomer;
using Restaurant.Class.Pizza_Hut;

namespace Restaurant.Class.Admin
{
    class AdminClass : Customer
    {
        public List<Customer> CustomersList = new List<Customer>();

        public void AddCustomerToList(List<Customer> customerList)
        {
            CustomersList.AddRange(customerList);
        }
        public void ShowFunctionalityOfAdmin(AdminClass admin)
        {
            ShowFunctionalityOfAdmin:
            Console.WriteLine("1. Customer List\n2. Show All Tables \n3. Show Menu List\n4. Exit");
            Console.WriteLine("\n Choose an Option: \n");
            var choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    GetCustomerInformation(admin);
                    break;

                case 2:
                    Console.WriteLine("1. McD\n2. Pizza Hut");
                    var option2 = Convert.ToInt16(Console.ReadLine());
                    if (option2 == 1)
                    {
                        RestroMcD.ShowAllTheTablesInRestro();
                    }
                    else if (option2 == 2)
                    {
                        RestroPizzaHut.ShowAllTheTablesInRestro();
                    }
                    break;

                case 3:
                    Console.WriteLine("1. McD\n2. Pizza Hut");
                    var option3 = Convert.ToInt16(Console.ReadLine());
                    if (option3 == 1)
                    {
                        RestroMcD.ShowAllTheItemsInRestro();
                    }
                    else if (option3 == 2)
                    {
                        RestroPizzaHut.ShowAllTheItemsInRestro();
                    }
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("\nSelect appropriate Option\n");
                    ShowFunctionalityOfAdmin(admin);
                    break;
            }
            askAgain:
            Console.WriteLine("Do you want to continue \n1. Yes\n2.No");
            var option = Convert.ToInt16(Console.ReadLine());
            if (option == 1)
            {
                goto ShowFunctionalityOfAdmin;
            }
            else if(option == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Option");
                goto askAgain;
            }
        }

        private void GetCustomerInformation(AdminClass admin)
        {
            int count = 1;
            ConsoleTable table = new ConsoleTable("Sr.No", "Customer Name","Amount paid", "Table No.","Restaurant Name");
            foreach (var currentCustomer in admin.CustomersList)
            {
                table.AddRow(count++, currentCustomer.CustomerName, currentCustomer.BillAmount, currentCustomer.TableId, currentCustomer.RestroName);
            }
            table.Write(Format.Alternative);
        }
    }
}
