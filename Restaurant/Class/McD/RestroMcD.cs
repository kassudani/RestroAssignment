using Restaurant.Interface;
using System;
using System.Collections.Generic;
using Restaurant.DelegatesAndEvents;
using Restaurant.Model.McD;
using Restaurant.Class.Admin;
using Restaurant.Class.NewCustomer;
using ConsoleTables;

namespace Restaurant.Class.McD
{
    class RestroMcD : IRestro
    {
        public List<Customer> CustomerList = new List<Customer>();
        public static List<ItemModel> items = new List<ItemModel>();
        public static List<TableModel> tables = new List<TableModel>();
        List<OrderedItemModel> orderedItemList = new List<OrderedItemModel>();
        private AdminClass admin = null;

        public static void SetMenuItems()
        {
            items.Add(new ItemModel { ItemId = 1, ItemName = "Chicken McGrill", ItemPrice = 80, IsItemAvailable = true });
            items.Add(new ItemModel { ItemId = 2, ItemName = "Chicken Nuggets", ItemPrice = 180, IsItemAvailable = false });
            items.Add(new ItemModel { ItemId = 3, ItemName = "Veg McGrill", ItemPrice = 90, IsItemAvailable = true });
            items.Add(new ItemModel { ItemId = 4, ItemName = "McAloo Tikki", ItemPrice = 80, IsItemAvailable = true });
            items.Add(new ItemModel { ItemId = 5, ItemName = "McEgg", ItemPrice = 100, IsItemAvailable = true });
            items.Add(new ItemModel { ItemId = 6, ItemName = "McChicken", ItemPrice = 140, IsItemAvailable = true });
        }

        public static void ShowAllTheTablesInRestro()
        {
            ConsoleTable table = new ConsoleTable("Table No.", "Availability");
            foreach (TableModel tableAvailable in tables)
            {
                table.AddRow( tableAvailable.TableNumber, tableAvailable.IsTableAvailable);
            }
            table.Write(Format.Alternative);
        }

        internal static void ShowAllTheItemsInRestro()
        {
            ConsoleTable table = new ConsoleTable("Item Id", "Item Name", "Item Price");
            foreach (ItemModel itemCurrent in items)
            {
                table.AddRow(itemCurrent.ItemId, itemCurrent.ItemName, itemCurrent.ItemPrice);
            }
            table.Write(Format.Alternative);
        }

        public static void SetTables()
        {
            tables.Add(new TableModel { TableNumber = 1, IsTableAvailable = true });
            tables.Add(new TableModel { TableNumber = 2, IsTableAvailable = true });
            tables.Add(new TableModel { TableNumber = 3, IsTableAvailable = true });
            tables.Add(new TableModel { TableNumber = 4, IsTableAvailable = true });
        }

        public int BookTable(NewCustomer.Customer customer)
        {
        BookTable:
            ShowTables();
            Console.WriteLine("Enter the table number to book");
            int tableToBook = Convert.ToInt32(Console.ReadLine());
            foreach (TableModel tableAvailable in tables)
            {
                if ((tableAvailable.TableNumber == tableToBook) && tableAvailable.IsTableAvailable)
                {
                    //Console.WriteLine(tableAvailable.getSetTableNumber + " " + ((tableAvailable.getSetIsTableAvailabile) ? "Available" : "Booked"));
                    Console.WriteLine("Booked");
                    tableAvailable.IsTableAvailable = false;
                    customer.TableId = tableToBook;
                    break;
                }
                else if ((tableAvailable.TableNumber == tableToBook) && !tableAvailable.IsTableAvailable)
                {
                    Console.WriteLine("Table is already booked");
                    goto BookTable;
                }
            }
            return tableToBook;
        }

        public void ShowTables()
        {
            ConsoleTable table = new ConsoleTable("Table No.", "Availability");
            foreach (TableModel tableAvailable in tables)
            {
                if (tableAvailable.IsTableAvailable)
                {
                    table.AddRow(tableAvailable.TableNumber, tableAvailable.IsTableAvailable);
                }
            }
            table.Write(Format.Alternative);
        }

        public void ShowItems()
        {
            ConsoleTable table = new ConsoleTable("Item Id", "Item Name" , "Item Price");
            foreach (ItemModel itemCurrent in items)
            {
                if (itemCurrent.IsItemAvailable)
                {
                    table.AddRow(itemCurrent.ItemId, itemCurrent.ItemName,itemCurrent.ItemPrice);
                }
            }
            table.Write(Format.Alternative);
        }

        public void PlaceOrder(AdminClass admin, NewCustomer.Customer customer)
        {
            this.admin = admin;
            customer.RestroName = "McD";
            BookTable(customer);
            OrderItems(customer);
            Bill(customer);
            var sendBillViaMail = new SendBillViaMail();
            var mailService = new MailService();
            sendBillViaMail.SentMail += mailService.OnSentMail;
            sendBillViaMail.PayBill(customer);
        }

        private void Bill(NewCustomer.Customer customer)
        {
            Console.WriteLine("Your Bill is:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Customer Name: {customer.CustomerName}");
            Console.WriteLine("---------------------------------------------");
            long total = 0;
            int count = 1;
            List<OrderedItemModel> oList = orderedItemList;
            ConsoleTable table = new ConsoleTable("Sr. No.", "Item Id", "Item Name", "Item Quantity", "Item Price");
            foreach (OrderedItemModel ol in oList)
            {
                total = total + (ol.OrderedItemQuantity * ol.OrderedItem.ItemPrice);
                table.AddRow(count++, ol.OrderedItem.ItemId, ol.OrderedItem.ItemName, ol.OrderedItemQuantity, ol.OrderedItemQuantity * ol.OrderedItem.ItemPrice);
            }
            table.Write(Format.Alternative);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Total amount is: {total}");
            Console.WriteLine("---------------------------------------------");
            customer.BillAmount = total;
            CustomerList.Add(customer);
            admin.AddCustomerToList(CustomerList);

        }

        private void OrderItems(NewCustomer.Customer customer)
        {
            int ans;
            do
            {
            SelectItem:
                ShowItems();
                Console.WriteLine("Enter item to order");
                int iId = Convert.ToInt16(Console.ReadLine());
                ItemModel obj = null;
                
                foreach (ItemModel item in items)
                {
                    if (item.ItemId == iId && item.IsItemAvailable)
                    {
                        obj = item;
                        break;
                    }
                    else if (item.ItemId == iId && !item.IsItemAvailable)
                    {
                        Console.WriteLine("Item is either not available or It is an Invalid Option");
                        goto SelectItem;
                    }
                }
                OrderedItemModel orderedItemsTemp = new OrderedItemModel();
                Console.WriteLine($"Enter quantity of {obj.ItemName}");

                orderedItemsTemp.OrderedItemQuantity = Convert.ToInt16(Console.ReadLine());
                orderedItemsTemp.OrderedItem = obj;
                orderedItemList.Add(orderedItemsTemp);
                Console.WriteLine("\nDo You want to order more items\n1. Yes\n2. No\n");
                ans = Convert.ToInt16(Console.ReadLine());
            } while (ans == 1);
        }
    }
}
