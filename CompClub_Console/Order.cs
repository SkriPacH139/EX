
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
