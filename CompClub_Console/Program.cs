using System;
using System.Collections.Generic;

// Консольное приложение управления компьютерным клубом
namespace CompClub_Console
{
    // Класс управления основными процессами
    public class Program
    {
        static List<Guest> guests = new List<Guest>();
        static List<Client> clients = new List<Client>();
        static List<Component> components = new List<Component>();
        static List<Dish> dishes = new List<Dish>();
        static List<Order> orders = new List<Order>();
        static int totalSeats = 10;
        // Главный цикл меню
        public static void Main(string[] args)
        {
            InitializeData();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("==== Компьютерный клуб ====");
                Console.WriteLine("1. Зал для гостей");
                Console.WriteLine("2. Склад");
                Console.WriteLine("3. Буффет");
                Console.WriteLine("4. Управление клиентами");
                Console.WriteLine("5. Отчеты");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ManageHall();
                        break;
                    case "2":
                        ManageInventory();
                        break;
                    case "3":
                        ManageKitchen();
                        break;
                    case "4":
                        ManageClients();
                        break;
                    case "5":
                        ShowReports();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор, нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Инициализация начальных данных
        static void InitializeData()
        {
            guests.Add(new Guest
            {
                Name = "Иван",
                IsVIP = false,
                StartTime = DateTime.Now.AddMinutes(-30),
                SeatNumber = 1,
                Tariff = 1.5,
                RentalMinutes = 30
            });
            guests.Add(new Guest
            {
                Name = "Петр",
                IsVIP = true,
                StartTime = DateTime.Now.AddMinutes(-45),
                SeatNumber = 2,
                Tariff = 1.5,
                RentalMinutes = 45
            });
            clients.Add(new Client
            {
                Name = "Иван",
                IsVIP = false,
                PhoneNumber = "123456789",
                AccumulatedBonus = 50,
                RegistrationDate = DateTime.Now.AddMonths(-1),
                HasMembershipCard = true,
                Discount = 5
            });
            clients.Add(new Client
            {
                Name = "Ольга",
                IsVIP = true,
                PhoneNumber = "987654321",
                AccumulatedBonus = 150,
                RegistrationDate = DateTime.Now.AddMonths(-3),
                HasMembershipCard = true,
                Discount = 10
            });
            components.Add(new Component
            {
                Name = "Мышь Logitech",
                Category = "Мыши",
                Quantity = 10,
                Price = 15
            });
            components.Add(new Component
            {
                Name = "Клавиатура Corsair",
                Category = "Клавиатуры",
                Quantity = 5,
                Price = 50
            });
            components.Add(new Component
            {
                Name = "Видеокарта Nvidia",
                Category = "Видеокарты",
                Quantity = 2,
                Price = 300
            });
            dishes.Add(new Dish
            {
                Name = "Бургер",
                Category = "Фастфуд",
                Price = 5
            });
            dishes.Add(new Dish
            {
                Name = "Салат",
                Category = "Здоровая еда",
                Price = 4
            });
            orders.Add(new Order
            {
                ClientName = "Иван",
                OrderNumber = 1,
                SelectedDish = dishes[0],
                Status = OrderStatus.InProcess
            });
        }
        #region Зал для гостей
        // Управление залом для гостей
        static void ManageHall()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("==== Зал для гостей ====");
                Console.WriteLine($"Свободных мест: {totalSeats - guests.Count} из {totalSeats}");
                Console.WriteLine("Список гостей:");
                foreach (var guest in guests)
                {
                    Console.WriteLine($"Имя: {guest.Name}, VIP: {guest.IsVIP}, Начало: {guest.StartTime}, Место: {guest.SeatNumber}, Тариф: {guest.Tariff}, Минут: {guest.RentalMinutes}");
                }
                Console.WriteLine();
                Console.WriteLine("1. Добавить гостя");
                Console.WriteLine("2. Завершить сеанс гостя");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddGuest();
                        break;
                    case "2":
                        FinishGuestSession();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Добавление нового гостя
        static void AddGuest()
        {
            Console.Clear();
            Console.WriteLine("==== Добавление нового гостя ====");
            if (guests.Count >= totalSeats)
            {
                Console.WriteLine("Нет свободных мест!");
                Console.WriteLine("Нажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }
            Guest newGuest = new Guest();
            Console.Write("Введите имя гостя: ");
            newGuest.Name = Console.ReadLine();
            Console.Write("VIP статус (true/false): ");
            bool isVip;
            Boolean.TryParse(Console.ReadLine(), out isVip);
            newGuest.IsVIP = isVip;
            newGuest.StartTime = DateTime.Now;
            newGuest.Tariff = 1.5;
            newGuest.RentalMinutes = 0;
            int seat = 1;
            List<int> occupiedSeats = new List<int>();
            foreach (var g in guests)
            {
                occupiedSeats.Add(g.SeatNumber);
            }
            while (occupiedSeats.Contains(seat) && seat <= totalSeats)
            {
                seat++;
            }
            if (seat > totalSeats)
            {
                Console.WriteLine("Нет свободных мест!");
                Console.WriteLine("Нажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }
            newGuest.SeatNumber = seat;
            guests.Add(newGuest);
            Console.WriteLine("Гость добавлен успешно!");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Завершение сеанса гостя
        static void FinishGuestSession()
        {
            Console.Clear();
            Console.WriteLine("==== Завершение сеанса гостя ====");
            Console.Write("Введите номер места гостя для завершения сеанса: ");
            int seat;
            int.TryParse(Console.ReadLine(), out seat);
            Guest guest = guests.Find(g => g.SeatNumber == seat);
            if (guest == null)
            {
                Console.WriteLine("Гость с таким местом не найден!");
                Console.WriteLine("Нажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }
            Console.Write("Введите количество минут аренды: ");
            int minutes;
            int.TryParse(Console.ReadLine(), out minutes);
            guest.RentalMinutes = minutes;
            double cost = guest.CalculateCost();
            Console.WriteLine($"Сеанс завершен. Сумма к оплате: {cost}");
            guests.Remove(guest);
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        #endregion
        #region Склад
        // Управление складом
        static void ManageInventory()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("==== Склад ====");
                Console.WriteLine("Список комплектующих:");
                foreach (var comp in components)
                {
                    Console.WriteLine($"Название: {comp.Name}, Категория: {comp.Category}, Количество: {comp.Quantity}, Цена: {comp.Price}");
                }
                Console.WriteLine();
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Списать/Передать товар");
                Console.WriteLine("3. Поиск по названию/категории");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddComponent();
                        break;
                    case "2":
                        WriteOffComponent();
                        break;
                    case "3":
                        SearchComponent();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Добавление нового товара
        static void AddComponent()
        {
            Console.Clear();
            Console.WriteLine("==== Добавление нового товара ====");
            Component comp = new Component();
            Console.Write("Введите название товара: ");
            comp.Name = Console.ReadLine();
            Console.Write("Введите категорию товара: ");
            comp.Category = Console.ReadLine();
            Console.Write("Введите количество: ");
            int qty;
            int.TryParse(Console.ReadLine(), out qty);
            comp.Quantity = qty;
            Console.Write("Введите цену: ");
            double price;
            double.TryParse(Console.ReadLine(), out price);
            comp.Price = price;
            components.Add(comp);
            Console.WriteLine("Товар добавлен успешно!");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Списание или передача товара
        static void WriteOffComponent()
        {
            Console.Clear();
            Console.WriteLine("==== Списание/Передача товара ====");
            Console.Write("Введите название товара для списания: ");
            string name = Console.ReadLine();
            Component comp = components.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (comp == null)
            {
                Console.WriteLine("Товар не найден!");
            }
            else
            {
                Console.Write("Введите количество для списания: ");
                int qty;
                int.TryParse(Console.ReadLine(), out qty);
                if (qty > comp.Quantity)
                {
                    Console.WriteLine("Недостаточно товара для списания!");
                }
                else
                {
                    comp.Quantity -= qty;
                    Console.WriteLine("Операция выполнена успешно!");
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Поиск товара на складе
        static void SearchComponent()
        {
            Console.Clear();
            Console.WriteLine("==== Поиск товара ====");
            Console.Write("Введите название или категорию: ");
            string searchTerm = Console.ReadLine();
            var results = components.FindAll(c => c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                   c.Category.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
            if (results.Count == 0)
            {
                Console.WriteLine("Товар не найден!");
            }
            else
            {
                foreach (var comp in results)
                {
                    Console.WriteLine($"Название: {comp.Name}, Категория: {comp.Category}, Количество: {comp.Quantity}, Цена: {comp.Price}");
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        #endregion
        #region Буффет (Кухня)
        // Управление заказами и кухней
        static void ManageKitchen()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("==== Буффет ====");
                Console.WriteLine("Список заказов:");
                foreach (var order in orders)
                {
                    Console.WriteLine($"Номер заказа: {order.OrderNumber}, Клиент: {order.ClientName}, Блюдо: {order.SelectedDish.Name}, Статус: {order.Status}");
                }
                Console.WriteLine();
                Console.WriteLine("1. Добавить заказ");
                Console.WriteLine("2. Изменить статус заказа");
                Console.WriteLine("3. Управление блюдами");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddOrder();
                        break;
                    case "2":
                        ChangeOrderStatus();
                        break;
                    case "3":
                        ManageDishes();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Создание нового заказа
        static void AddOrder()
        {
            Console.Clear();
            Console.WriteLine("==== Добавление заказа ====");
            Order order = new Order();
            Console.Write("Введите имя клиента: ");
            order.ClientName = Console.ReadLine();
            Console.Write("Введите номер заказа: ");
            int orderNumber;
            int.TryParse(Console.ReadLine(), out orderNumber);
            order.OrderNumber = orderNumber;
            Console.WriteLine("Выберите блюдо из списка:");
            for (int i = 0; i < dishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dishes[i].Name} - {dishes[i].Price} руб.");
            }
            int dishChoice;
            int.TryParse(Console.ReadLine(), out dishChoice);
            if (dishChoice >= 1 && dishChoice <= dishes.Count)
            {
                order.SelectedDish = dishes[dishChoice - 1];
            }
            else
            {
                Console.WriteLine("Неверный выбор блюда, заказ не добавлен.");
                Console.WriteLine("Нажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }
            order.Status = OrderStatus.InProcess;
            orders.Add(order);
            Console.WriteLine("Заказ добавлен успешно!");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Изменение статуса заказа
        static void ChangeOrderStatus()
        {
            Console.Clear();
            Console.WriteLine("==== Изменение статуса заказа ====");
            Console.Write("Введите номер заказа: ");
            int orderNumber;
            int.TryParse(Console.ReadLine(), out orderNumber);
            Order order = orders.Find(o => o.OrderNumber == orderNumber);
            if (order == null)
            {
                Console.WriteLine("Заказ не найден!");
            }
            else
            {
                Console.WriteLine("Выберите новый статус:");
                Console.WriteLine("1. InProcess");
                Console.WriteLine("2. Ready");
                Console.WriteLine("3. Delivered");
                string statusChoice = Console.ReadLine();
                switch (statusChoice)
                {
                    case "1":
                        order.Status = OrderStatus.InProcess;
                        break;
                    case "2":
                        order.Status = OrderStatus.Ready;
                        break;
                    case "3":
                        order.Status = OrderStatus.Delivered;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
                Console.WriteLine("Статус изменен.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Управление меню блюд
        static void ManageDishes()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("==== Управление блюдами ====");
                Console.WriteLine("Список блюд:");
                for (int i = 0; i < dishes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {dishes[i].Name}, Категория: {dishes[i].Category}, Цена: {dishes[i].Price}");
                }
                Console.WriteLine();
                Console.WriteLine("1. Добавить блюдо");
                Console.WriteLine("2. Редактировать блюдо");
                Console.WriteLine("3. Удалить блюдо");
                Console.WriteLine("4. Фильтрация блюд (по категории)");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDish();
                        break;
                    case "2":
                        EditDish();
                        break;
                    case "3":
                        DeleteDish();
                        break;
                    case "4":
                        FilterDishes();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Добавление нового блюда
        static void AddDish()
        {
            Console.Clear();
            Console.WriteLine("==== Добавление нового блюда ====");
            Dish dish = new Dish();
            Console.Write("Введите название блюда: ");
            dish.Name = Console.ReadLine();
            Console.Write("Введите категорию блюда: ");
            dish.Category = Console.ReadLine();
            Console.Write("Введите цену блюда: ");
            double price;
            double.TryParse(Console.ReadLine(), out price);
            dish.Price = price;
            dishes.Add(dish);
            Console.WriteLine("Блюдо добавлено успешно!");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Редактирование блюда
        static void EditDish()
        {
            Console.Clear();
            Console.WriteLine("==== Редактирование блюда ====");
            Console.Write("Введите номер блюда для редактирования: ");
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > dishes.Count)
            {
                Console.WriteLine("Неверный номер блюда.");
            }
            else
            {
                Dish dish = dishes[index - 1];
                Console.Write($"Новое название (текущее: {dish.Name}): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                    dish.Name = newName;
                Console.Write($"Новая категория (текущее: {dish.Category}): ");
                string newCategory = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCategory))
                    dish.Category = newCategory;
                Console.Write($"Новая цена (текущее: {dish.Price}): ");
                string newPrice = Console.ReadLine();
                double price;
                if (double.TryParse(newPrice, out price))
                    dish.Price = price;
                Console.WriteLine("Блюдо обновлено.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Удаление блюда
        static void DeleteDish()
        {
            Console.Clear();
            Console.WriteLine("==== Удаление блюда ====");
            Console.Write("Введите номер блюда для удаления: ");
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > dishes.Count)
            {
                Console.WriteLine("Неверный номер блюда.");
            }
            else
            {
                dishes.RemoveAt(index - 1);
                Console.WriteLine("Блюдо удалено.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Фильтрация блюд по категории
        static void FilterDishes()
        {
            Console.Clear();
            Console.WriteLine("==== Фильтрация блюд ====");
            Console.Write("Введите категорию для фильтрации: ");
            string category = Console.ReadLine();
            var filtered = dishes.FindAll(d => d.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0);
            if (filtered.Count == 0)
            {
                Console.WriteLine("Блюда не найдены.");
            }
            else
            {
                foreach (var dish in filtered)
                {
                    Console.WriteLine($"Название: {dish.Name}, Категория: {dish.Category}, Цена: {dish.Price}");
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        #endregion
        #region Управление клиентами
        // Управление клиентами
        static void ManageClients()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("==== Управление клиентами ====");
                Console.WriteLine("Список клиентов:");
                for (int i = 0; i < clients.Count; i++)
                {
                    Client c = clients[i];
                    Console.WriteLine($"{i + 1}. Имя: {c.Name}, Телефон: {c.PhoneNumber}, VIP: {c.IsVIP}, Бонусы: {c.AccumulatedBonus}, Дата регистрации: {c.RegistrationDate.ToShortDateString()}, Карта: {c.HasMembershipCard}, Скидка: {c.Discount}%");
                }
                Console.WriteLine();
                Console.WriteLine("1. Добавить клиента");
                Console.WriteLine("2. Редактировать клиента");
                Console.WriteLine("3. Удалить клиента");
                Console.WriteLine("4. Поиск клиентов");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        EditClient();
                        break;
                    case "3":
                        DeleteClient();
                        break;
                    case "4":
                        SearchClient();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Добавление нового клиента
        static void AddClient()
        {
            Console.Clear();
            Console.WriteLine("==== Добавление клиента ====");
            Client client = new Client();
            Console.Write("Введите имя клиента: ");
            client.Name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            client.PhoneNumber = Console.ReadLine();
            Console.Write("VIP статус (true/false): ");
            bool isVip;
            Boolean.TryParse(Console.ReadLine(), out isVip);
            client.IsVIP = isVip;
            client.RegistrationDate = DateTime.Now;
            Console.Write("Наличие членской карты (true/false): ");
            bool hasCard;
            Boolean.TryParse(Console.ReadLine(), out hasCard);
            client.HasMembershipCard = hasCard;
            Console.Write("Введите размер скидки (например, 5 для 5%): ");
            double discount;
            double.TryParse(Console.ReadLine(), out discount);
            client.Discount = discount;
            client.AccumulatedBonus = 0;
            clients.Add(client);
            Console.WriteLine("Клиент добавлен успешно!");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Редактирование данных клиента
        static void EditClient()
        {
            Console.Clear();
            Console.WriteLine("==== Редактирование клиента ====");
            Console.Write("Введите номер клиента для редактирования: ");
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > clients.Count)
            {
                Console.WriteLine("Неверный номер клиента.");
            }
            else
            {
                Client client = clients[index - 1];
                Console.Write($"Новое имя (текущее: {client.Name}): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                    client.Name = newName;
                Console.Write($"Новый телефон (текущее: {client.PhoneNumber}): ");
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPhone))
                    client.PhoneNumber = newPhone;
                Console.Write($"VIP статус (текущее: {client.IsVIP}) (true/false): ");
                bool isVip;
                if (Boolean.TryParse(Console.ReadLine(), out isVip))
                    client.IsVIP = isVip;
                Console.Write($"Наличие членской карты (текущее: {client.HasMembershipCard}) (true/false): ");
                bool hasCard;
                if (Boolean.TryParse(Console.ReadLine(), out hasCard))
                    client.HasMembershipCard = hasCard;
                Console.Write($"Размер скидки (текущее: {client.Discount}%): ");
                double discount;
                if (double.TryParse(Console.ReadLine(), out discount))
                    client.Discount = discount;
                Console.WriteLine("Клиент обновлен.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Удаление клиента
        static void DeleteClient()
        {
            Console.Clear();
            Console.WriteLine("==== Удаление клиента ====");
            Console.Write("Введите номер клиента для удаления: ");
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > clients.Count)
            {
                Console.WriteLine("Неверный номер клиента.");
            }
            else
            {
                clients.RemoveAt(index - 1);
                Console.WriteLine("Клиент удален.");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Поиск клиентов
        static void SearchClient()
        {
            Console.Clear();
            Console.WriteLine("==== Поиск клиентов ====");
            Console.Write("Введите имя или номер телефона: ");
            string searchTerm = Console.ReadLine();
            var results = clients.FindAll(c => c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                               c.PhoneNumber.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
            if (results.Count == 0)
            {
                Console.WriteLine("Клиенты не найдены.");
            }
            else
            {
                foreach (var client in results)
                {
                    Console.WriteLine($"Имя: {client.Name}, Телефон: {client.PhoneNumber}, VIP: {client.IsVIP}, Бонусы: {client.AccumulatedBonus}, Дата регистрации: {client.RegistrationDate.ToShortDateString()}, Карта: {client.HasMembershipCard}, Скидка: {client.Discount}%");
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        #endregion
        #region Отчеты
        // Функции отчетности
        static void ShowReports()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("==== Отчеты ====");
                Console.WriteLine("1. Ежедневная выручка");
                Console.WriteLine("2. Самые популярные товары на складе (топ-5)");
                Console.WriteLine("3. Часто заказываемые блюда");
                Console.WriteLine("4. Статистика посещений гостей");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ReportRevenue();
                        break;
                    case "2":
                        ReportPopularComponents();
                        break;
                    case "3":
                        ReportPopularDishes();
                        break;
                    case "4":
                        ReportGuestStatistics();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Отчет по выручке
        static void ReportRevenue()
        {
            Console.Clear();
            Console.WriteLine("==== Ежедневная выручка ====");
            double hallRevenue = 100;
            double kitchenRevenue = 0;
            foreach (var order in orders)
            {
                if (order.Status == OrderStatus.Delivered)
                {
                    kitchenRevenue += order.SelectedDish.Price;
                }
            }
            double vipRevenue = 50;
            Console.WriteLine($"Зал: {hallRevenue} руб.");
            Console.WriteLine($"Кухня: {kitchenRevenue} руб.");
            Console.WriteLine($"VIP: {vipRevenue} руб.");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Топ-5 популярных товаров
        static void ReportPopularComponents()
        {
            Console.Clear();
            Console.WriteLine("==== Самые популярные товары на складе (топ-5) ====");
            var topComponents = new List<Component>(components);
            topComponents.Sort((a, b) => b.Quantity.CompareTo(a.Quantity));
            int count = Math.Min(5, topComponents.Count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {topComponents[i].Name} - Количество: {topComponents[i].Quantity}");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Часто заказываемые блюда
        static void ReportPopularDishes()
        {
            Console.Clear();
            Console.WriteLine("==== Часто заказываемые блюда ====");
            Dictionary<string, int> dishCount = new Dictionary<string, int>();
            foreach (var order in orders)
            {
                if (dishCount.ContainsKey(order.SelectedDish.Name))
                    dishCount[order.SelectedDish.Name]++;
                else
                    dishCount[order.SelectedDish.Name] = 1;
            }
            foreach (var kvp in dishCount)
            {
                Console.WriteLine($"Блюдо: {kvp.Key}, Заказов: {kvp.Value}");
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        // Статистика текущих гостей
        static void ReportGuestStatistics()
        {
            Console.Clear();
            Console.WriteLine("==== Статистика посещений гостей ====");
            Console.WriteLine($"Количество текущих гостей: {guests.Count}");
            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
        #endregion
    }
}
