using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DelegatesAndEvents
{
    class MailService
    {
        public void OnSentMail(object source, EventArgs args)
        {
            Console.WriteLine($"Bill sent by mail");
            Console.WriteLine($"-------------------------------------------");
        }
    }
}
