using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model.PizzaHut
{
    class TableModel
    {
        public int TableNumber { get; set; }
        public bool IsTableAvailable { get; set; }
        public List<TableModel> Tables { get; set; }
    }
}
