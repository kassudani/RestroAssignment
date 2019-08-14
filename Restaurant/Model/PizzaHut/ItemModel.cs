using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.PizzaHut
{
    class ItemModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public long ItemPrice { get; set; }

        public bool IsItemAvailable { get; set; }
    }
}
