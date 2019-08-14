using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.PizzaHut
{
    class OrderedItemModel
    {
        public int OrderedItemQuantity { get; set; }
        public ItemModel OrderedItem { get; set; }
    }
}
