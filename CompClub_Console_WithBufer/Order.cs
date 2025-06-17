using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompClub_Console
{
    public class Order
    {
        public string ClientName { get; set; }
        public int OrderNumber { get; set; }
        public Dish SelectedDish { get; set; }
        public OrderStatus Status { get; set; }
    }
}
