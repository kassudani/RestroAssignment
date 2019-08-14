using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Class.Admin;
using Restaurant.Class.NewCustomer;

namespace Restaurant.Interface
{
    interface IRestro
    {
        //void GoToRestro(CustomerClass customer, AdminClass admin);
        //int ShowAndReadTheMenuChoice();
        //void ShowAllTheTablesInRestro();
        //void ShowOnlyAvailableTable();
        //void ShowAllItemsOfRestro();
        //void ShowOnlyAvailableItem();
        //void PutOrder(CustomerClass customer);
        int BookTable(Customer customer);
        void ShowTables();
        void ShowItems();
        void PlaceOrder(AdminClass admin, Customer customer);
    }
}
