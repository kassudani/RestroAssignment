using System;
using Restaurant.Class.NewCustomer;

namespace Restaurant.DelegatesAndEvents
{
    class SendBillViaMail
    {
        public delegate void SendBillEventHandler(object source, EventArgs args);
        public event SendBillEventHandler SentMail;

        public void PayBill(Customer customer)
        {
            Console.WriteLine($"-------------------------------------------");
            Console.WriteLine($"Event Triggered\nHello {customer.CustomerName}\nAmount to be paid is: {customer.BillAmount} ");
            Console.WriteLine($"-------------------------------------------");

            OnSentBill();
        }

        protected virtual void OnSentBill()
        {
            if (SentMail != null)
            {
                SentMail(this, EventArgs.Empty);
            }
        }
    }
}
