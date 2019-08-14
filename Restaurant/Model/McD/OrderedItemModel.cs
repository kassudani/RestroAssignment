using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.McD
{
    class OrderedItemModel : ItemModel
    {
        public int OrderedItemQuantity { get; set; }
        public ItemModel OrderedItem { get; set; }
    }
}
