using System;
using System.Collections.Generic;
using System.Linq;

namespace CompClub_Console
{
    /// Заказ, включающий одно или несколько блюд.
    public class Order
    {
        public List<Dish> Dishes { get; set; } = new List<Dish>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.InProcess;
        public int OrderNumber { get; set; }
        public string ClientName { get; set; }
        public Dish SelectedDish { get; set; }

        //>Общая сумма заказа
        public double TotalCost
        {
            get
            {
                if (Dishes != null && Dishes.Count > 0)
                    return Dishes.Sum(d => d.Price);
                else if (SelectedDish != null)
                    return SelectedDish.Price;
                return 0;
            }
        }
    }
}