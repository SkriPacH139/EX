using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompClub_Console
{
    public static class DataStore
    {
        public static List<Guest> Guests { get; } = new List<Guest>();
        public static List<Client> Clients { get; } = new List<Client>();
        public static List<Component> Components { get; } = new List<Component>();
        public static List<Dish> Dishes { get; } = new List<Dish>();
        public static List<Order> Orders { get; } = new List<Order>();

        public static int TotalSeats { get; } = 10;

        public static void InitializeData()
        {
            // Гости
            Guests.Add(new Guest
            {
                Name = "Иван",
                IsVIP = false,
                StartTime = DateTime.Now.AddMinutes(-30),
                SeatNumber = 1,
                Tariff = 1.5,
                RentalMinutes = 30
            });

            Guests.Add(new Guest
            {
                Name = "Петр",
                IsVIP = true,
                StartTime = DateTime.Now.AddMinutes(-45),
                SeatNumber = 2,
                Tariff = 1.5,
                RentalMinutes = 45
            });

            // Клиенты
            Clients.Add(new Client
            {
                Name = "Иван",
                IsVIP = false,
                PhoneNumber = "123456789",
                AccumulatedBonus = 50,
                RegistrationDate = DateTime.Now.AddMonths(-1),
                HasMembershipCard = true,
                Discount = 5
            });

            Clients.Add(new Client
            {
                Name = "Ольга",
                IsVIP = true,
                PhoneNumber = "987654321",
                AccumulatedBonus = 150,
                RegistrationDate = DateTime.Now.AddMonths(-3),
                HasMembershipCard = true,
                Discount = 10
            });

            // Склад
            Components.Add(new Component
            {
                Name = "Мышь Logitech",
                Category = "Мыши",
                Quantity = 10,
                Price = 15
            });

            Components.Add(new Component
            {
                Name = "Клавиатура Corsair",
                Category = "Клавиатуры",
                Quantity = 5,
                Price = 50
            });

            Components.Add(new Component
            {
                Name = "Видеокарта Nvidia",
                Category = "Видеокарты",
                Quantity = 2,
                Price = 300
            });

            // Блюда
            Dishes.Add(new Dish
            {
                Name = "Бургер",
                Category = "Фастфуд",
                Price = 5
            });

            Dishes.Add(new Dish
            {
                Name = "Салат",
                Category = "Здоровая еда",
                Price = 4
            });

            // Заказы
            Orders.Add(new Order
            {
                ClientName = "Иван",
                OrderNumber = 1,
                SelectedDish = Dishes[0],
                Status = OrderStatus.InProcess
            });
        }
    }
}
