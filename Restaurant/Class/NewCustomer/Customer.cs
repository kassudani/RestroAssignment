using Restaurant.Class.Admin;
using Restaurant.Interface;
using Restaurant.Model.McD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Class.NewCustomer
{
    class Customer
    {
        public string CustomerName { get; set; }
        public string RestroName { get; set; }
        public int TableId { get; set; }
        public long BillAmount { get; set; }
        public List<OrderedItemModel> ListOfItemOrder { get; set; }

        internal void UpdateInformation(AdminClass admin, IRestro restro, Customer customer)
        {
            SetCustomersName();
            var choice = ChooseWhatToDo(restro,customer);
            ProceedAsPerTheChoice(customer, admin, restro, choice);
        }

        private void ProceedAsPerTheChoice(Customer customer, AdminClass admin, IRestro restro, int choice)
        {
            int ans;
            switch (choice)
            {
                case 1:
                    restro.ShowTables();
                    break;
                case 2:
                    restro.ShowItems();
                    break;
                case 3:
                    restro.PlaceOrder(admin, customer);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            askAgain:
            Console.WriteLine("Do you want to continue:\n1. Yes\n2. No");
            ans = Convert.ToInt16(Console.ReadLine());
            if (ans == 1)
            {
                Program.Start(admin);
            }
            else if(ans == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Option");
                goto askAgain;
            }
        }


        private int ChooseWhatToDo(IRestro restro, Customer customer)
        {
            int option;
            do
            {
                Console.WriteLine("1. Available tables");
                Console.WriteLine("2. Available Items");
                Console.WriteLine("3. Order Items");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Choice");
                option = Convert.ToInt16(Console.ReadLine());
            } while (option == null);
            return option;
            
        }

        private void ChooseTable(IRestro restro, Customer customer)
        {
            TableId = restro.BookTable(customer);
        }

        private void SetCustomersName()
        {
            Console.WriteLine("Enter your Name");
            CustomerName = Console.ReadLine();
        }
    }
}
