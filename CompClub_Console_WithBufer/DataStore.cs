using System;
using System.Collections.Generic;

namespace CompClub_Console
{

    /// Хранилище всех данных приложения (работает как in-memory база данных).   
    public static class DataStore
    {
        public static List<Guest> Guests { get; } = new List<Guest>();
        public static List<Client> Clients { get; } = new List<Client>();
        public static List<Component> Components { get; } = new List<Component>();
        public static List<Dish> Dishes { get; } = new List<Dish>();
        public static List<Order> Orders { get; } = new List<Order>();

        public static int TotalSeats { get; } = 10;

        /// Заполняет хранилище тестовыми данными.       
        public static void InitializeData()
        {
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

            Clients.Add(new Client
            {
                Name = "Иван",
                IsVIP = false,
                PhoneNumber = "123456789",
                AccumulatedBonus = 50,
                RegistrationDate = DateTime.Now.AddMonths(-2),
                HasMembershipCard = true,
                Discount = 10
            });

            var comp1 = new Component { Name = "Булка", Quantity = 1, Unit = "шт" };
            var comp2 = new Component { Name = "Котлета", Quantity = 1, Unit = "шт" };
            Components.AddRange(new List<Component> { comp1, comp2 });

            var dish = new Dish { Name = "Бургер", Price = 250 };
            dish.Components.AddRange(new List<Component> { comp1, comp2 });
            Dishes.Add(dish);

            Orders.Add(new Order
            {
                Dishes = new List<Dish> { dish },
                Status = OrderStatus.Ready
            });
        }
    }
}
