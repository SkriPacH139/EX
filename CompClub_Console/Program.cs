using System;
using System.Collections.Generic;

namespace CompClub_Console
{
    public class Program
    {
        // Списки данных (данные при запуске всегда одинаковы)
        static List<Guest> guests = new List<Guest>();
        static List<Client> clients = new List<Client>();
        static List<Component> components = new List<Component>();
        static List<Dish> dishes = new List<Dish>();
        static List<Order> orders = new List<Order>();

        static int totalSeats = 10; // Общее количество мест в зале

        public static void Main(string[] args)  // Главная точка входа в программу
        {
            InitializeData();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Компьютерный клуб ====");  // Отображение заголовка раздела
                Console.WriteLine("1. Зал для гостей");  // Вывод текста в консоль
                Console.WriteLine("2. Склад");  // Вывод текста в консоль
                Console.WriteLine("3. Буффет");  // Вывод текста в консоль
                Console.WriteLine("4. Управление клиентами");  // Вывод текста в консоль
                Console.WriteLine("5. Отчеты");  // Вывод текста в консоль
                Console.WriteLine("0. Выход");  // Вывод текста в консоль
                Console.Write("Выберите пункт меню: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        ManageHall();
                        break;
                    case "2":  // Пункт меню
                        ManageInventory();
                        break;
                    case "3":  // Пункт меню
                        ManageKitchen();
                        break;
                    case "4":  // Пункт меню
                        ManageClients();
                        break;
                    case "5":  // Пункт меню
                        ShowReports();
                        break;
                    case "0":  // Пункт меню
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор, нажмите любую клавишу для продолжения...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void InitializeData()  // Инициализация начальных данных
        {
            // Инициализация гостей
            guests.Add(new Guest  // Добавление гостя
            {
                Name = "Иван",
                IsVIP = false,
                StartTime = DateTime.Now.AddMinutes(-30),
                SeatNumber = 1,
                Tariff = 1.5,
                RentalMinutes = 30
            });
            guests.Add(new Guest  // Добавление гостя
            {
                Name = "Петр",
                IsVIP = true,
                StartTime = DateTime.Now.AddMinutes(-45),
                SeatNumber = 2,
                Tariff = 1.5,
                RentalMinutes = 45
            });

            // Инициализация клиентов
            clients.Add(new Client  // Добавление клиента
            {
                Name = "Иван",
                IsVIP = false,
                PhoneNumber = "123456789",
                AccumulatedBonus = 50,
                RegistrationDate = DateTime.Now.AddMonths(-1),
                HasMembershipCard = true,
                Discount = 5
            });
            clients.Add(new Client  // Добавление клиента
            {
                Name = "Ольга",
                IsVIP = true,
                PhoneNumber = "987654321",
                AccumulatedBonus = 150,
                RegistrationDate = DateTime.Now.AddMonths(-3),
                HasMembershipCard = true,
                Discount = 10
            });

            // Инициализация товаров на складе
            components.Add(new Component  // Добавление товара на склад
            {
                Name = "Мышь Logitech",
                Category = "Мыши",
                Quantity = 10,
                Price = 15
            });
            components.Add(new Component  // Добавление товара на склад
            {
                Name = "Клавиатура Corsair",
                Category = "Клавиатуры",
                Quantity = 5,
                Price = 50
            });
            components.Add(new Component  // Добавление товара на склад
            {
                Name = "Видеокарта Nvidia",
                Category = "Видеокарты",
                Quantity = 2,
                Price = 300
            });

            // Инициализация блюд
            dishes.Add(new Dish  // Добавление блюда
            {
                Name = "Бургер",
                Category = "Фастфуд",
                Price = 5
            });
            dishes.Add(new Dish  // Добавление блюда
            {
                Name = "Салат",
                Category = "Здоровая еда",
                Price = 4
            });

            // Инициализация заказов
            orders.Add(new Order  // Добавление заказа
            {
                ClientName = "Иван",
                OrderNumber = 1,
                SelectedDish = dishes[0],
                Status = OrderStatus.InProcess
            });
        }

        #region Зал для гостей

        static void ManageHall()  // Метод: ManageHall
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Зал для гостей ====");  // Отображение заголовка раздела
                Console.WriteLine($"Свободных мест: {totalSeats - guests.Count} из {totalSeats}");  // Вывод текста в консоль
                Console.WriteLine("Список гостей:");  // Вывод текста в консоль
                foreach (var guest in guests)  // Перебор элементов
                {
                    Console.WriteLine($"Имя: {guest.Name}, VIP: {guest.IsVIP}, Начало: {guest.StartTime}, Место: {guest.SeatNumber}, Тариф: {guest.Tariff}, Минут: {guest.RentalMinutes}");  // Вывод текста в консоль
                }
                Console.WriteLine();  // Вывод текста в консоль
                Console.WriteLine("1. Добавить гостя");  // Вывод текста в консоль
                Console.WriteLine("2. Завершить сеанс гостя");  // Вывод текста в консоль
                Console.WriteLine("0. Назад");  // Вывод текста в консоль
                Console.Write("Выберите действие: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        AddGuest();
                        break;
                    case "2":  // Пункт меню
                        FinishGuestSession();
                        break;
                    case "0":  // Пункт меню
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void AddGuest()  // Метод: AddGuest
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Добавление нового гостя ====");  // Отображение заголовка раздела
            if (guests.Count >= totalSeats)  // Условная проверка
            {
                Console.WriteLine("Нет свободных мест!");  // Вывод текста в консоль
                Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
                Console.ReadKey();  // Ожидание нажатия клавиши
                return;
            }
            Guest newGuest = new Guest();
            Console.Write("Введите имя гостя: ");  // Вывод текста в консоль
            newGuest.Name = Console.ReadLine();
            Console.Write("VIP статус (true/false): ");  // Вывод текста в консоль
            bool isVip;
            Boolean.TryParse(Console.ReadLine(), out isVip);
            newGuest.IsVIP = isVip;
            newGuest.StartTime = DateTime.Now;
            newGuest.Tariff = 1.5;
            newGuest.RentalMinutes = 0;
            // Определение первого свободного места
            int seat = 1;
            List<int> occupiedSeats = new List<int>();  // Создание списка
            foreach (var g in guests)  // Перебор элементов
            {
                occupiedSeats.Add(g.SeatNumber);
            }
            while (occupiedSeats.Contains(seat) && seat <= totalSeats)
            {
                seat++;
            }
            if (seat > totalSeats)  // Условная проверка
            {
                Console.WriteLine("Нет свободных мест!");  // Вывод текста в консоль
                Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
                Console.ReadKey();  // Ожидание нажатия клавиши
                return;
            }
            newGuest.SeatNumber = seat;
            guests.Add(newGuest);  // Добавление гостя
            Console.WriteLine("Гость добавлен успешно!");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void FinishGuestSession()  // Метод: FinishGuestSession
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Завершение сеанса гостя ====");  // Отображение заголовка раздела
            Console.Write("Введите номер места гостя для завершения сеанса: ");  // Вывод текста в консоль
            int seat;
            int.TryParse(Console.ReadLine(), out seat);
            Guest guest = guests.Find(g => g.SeatNumber == seat);
            if (guest == null)  // Условная проверка
            {
                Console.WriteLine("Гость с таким местом не найден!");  // Вывод текста в консоль
                Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
                Console.ReadKey();  // Ожидание нажатия клавиши
                return;
            }
            Console.Write("Введите количество минут аренды: ");  // Вывод текста в консоль
            int minutes;
            int.TryParse(Console.ReadLine(), out minutes);
            guest.RentalMinutes = minutes;
            double cost = guest.CalculateCost();
            Console.WriteLine($"Сеанс завершен. Сумма к оплате: {cost}");  // Вывод текста в консоль
            // Освобождение места
            guests.Remove(guest);
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        #endregion

        #region Склад

        static void ManageInventory()  // Метод: ManageInventory
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Склад ====");  // Отображение заголовка раздела
                Console.WriteLine("Список комплектующих:");  // Вывод текста в консоль
                foreach (var comp in components)  // Перебор элементов
                {
                    Console.WriteLine($"Название: {comp.Name}, Категория: {comp.Category}, Количество: {comp.Quantity}, Цена: {comp.Price}");  // Вывод текста в консоль
                }
                Console.WriteLine();  // Вывод текста в консоль
                Console.WriteLine("1. Добавить товар");  // Вывод текста в консоль
                Console.WriteLine("2. Списать/Передать товар");  // Вывод текста в консоль
                Console.WriteLine("3. Поиск по названию/категории");  // Вывод текста в консоль
                Console.WriteLine("0. Назад");  // Вывод текста в консоль
                Console.Write("Выберите действие: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        AddComponent();
                        break;
                    case "2":  // Пункт меню
                        WriteOffComponent();
                        break;
                    case "3":  // Пункт меню
                        SearchComponent();
                        break;
                    case "0":  // Пункт меню
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void AddComponent()  // Метод: AddComponent
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Добавление нового товара ====");  // Отображение заголовка раздела
            Component comp = new Component();
            Console.Write("Введите название товара: ");  // Вывод текста в консоль
            comp.Name = Console.ReadLine();
            Console.Write("Введите категорию товара: ");  // Вывод текста в консоль
            comp.Category = Console.ReadLine();
            Console.Write("Введите количество: ");  // Вывод текста в консоль
            int qty;
            int.TryParse(Console.ReadLine(), out qty);
            comp.Quantity = qty;
            Console.Write("Введите цену: ");  // Вывод текста в консоль
            double price;
            double.TryParse(Console.ReadLine(), out price);
            comp.Price = price;
            components.Add(comp);  // Добавление товара на склад
            Console.WriteLine("Товар добавлен успешно!");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void WriteOffComponent()  // Метод: WriteOffComponent
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Списание/Передача товара ====");  // Отображение заголовка раздела
            Console.Write("Введите название товара для списания: ");  // Вывод текста в консоль
            string name = Console.ReadLine();
            Component comp = components.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (comp == null)  // Условная проверка
            {
                Console.WriteLine("Товар не найден!");  // Вывод текста в консоль
            }
            else
            {
                Console.Write("Введите количество для списания: ");  // Вывод текста в консоль
                int qty;
                int.TryParse(Console.ReadLine(), out qty);
                if (qty > comp.Quantity)  // Условная проверка
                {
                    Console.WriteLine("Недостаточно товара для списания!");  // Вывод текста в консоль
                }
                else
                {
                    comp.Quantity -= qty;
                    Console.WriteLine("Операция выполнена успешно!");  // Вывод текста в консоль
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void SearchComponent()  // Метод: SearchComponent
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Поиск товара ====");  // Отображение заголовка раздела
            Console.Write("Введите название или категорию: ");  // Вывод текста в консоль
            string searchTerm = Console.ReadLine();
            var results = components.FindAll(c => c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||  // Создание списка
                                                   c.Category.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
            if (results.Count == 0)  // Условная проверка
            {
                Console.WriteLine("Товар не найден!");  // Вывод текста в консоль
            }
            else
            {
                foreach (var comp in results)  // Перебор элементов
                {
                    Console.WriteLine($"Название: {comp.Name}, Категория: {comp.Category}, Количество: {comp.Quantity}, Цена: {comp.Price}");  // Вывод текста в консоль
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        #endregion

        #region Буффет (Кухня)

        static void ManageKitchen()  // Метод: ManageKitchen
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Буффет ====");  // Отображение заголовка раздела
                Console.WriteLine("Список заказов:");  // Вывод текста в консоль
                foreach (var order in orders)  // Перебор элементов
                {
                    Console.WriteLine($"Номер заказа: {order.OrderNumber}, Клиент: {order.ClientName}, Блюдо: {order.SelectedDish.Name}, Статус: {order.Status}");  // Вывод текста в консоль
                }
                Console.WriteLine();  // Вывод текста в консоль
                Console.WriteLine("1. Добавить заказ");  // Вывод текста в консоль
                Console.WriteLine("2. Изменить статус заказа");  // Вывод текста в консоль
                Console.WriteLine("3. Управление блюдами");  // Вывод текста в консоль
                Console.WriteLine("0. Назад");  // Вывод текста в консоль
                Console.Write("Выберите действие: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        AddOrder();
                        break;
                    case "2":  // Пункт меню
                        ChangeOrderStatus();
                        break;
                    case "3":  // Пункт меню
                        ManageDishes();
                        break;
                    case "0":  // Пункт меню
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void AddOrder()  // Метод: AddOrder
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Добавление заказа ====");  // Отображение заголовка раздела
            Order order = new Order();
            Console.Write("Введите имя клиента: ");  // Вывод текста в консоль
            order.ClientName = Console.ReadLine();
            Console.Write("Введите номер заказа: ");  // Вывод текста в консоль
            int orderNumber;
            int.TryParse(Console.ReadLine(), out orderNumber);
            order.OrderNumber = orderNumber;
            Console.WriteLine("Выберите блюдо из списка:");  // Вывод текста в консоль
            for (int i = 0; i < dishes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dishes[i].Name} - {dishes[i].Price} руб.");  // Вывод текста в консоль
            }
            int dishChoice;
            int.TryParse(Console.ReadLine(), out dishChoice);
            if (dishChoice >= 1 && dishChoice <= dishes.Count)  // Условная проверка
            {
                order.SelectedDish = dishes[dishChoice - 1];
            }
            else
            {
                Console.WriteLine("Неверный выбор блюда, заказ не добавлен.");  // Вывод текста в консоль
                Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
                Console.ReadKey();  // Ожидание нажатия клавиши
                return;
            }
            order.Status = OrderStatus.InProcess;
            orders.Add(order);  // Добавление заказа
            Console.WriteLine("Заказ добавлен успешно!");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void ChangeOrderStatus()  // Метод: ChangeOrderStatus
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Изменение статуса заказа ====");  // Отображение заголовка раздела
            Console.Write("Введите номер заказа: ");  // Вывод текста в консоль
            int orderNumber;
            int.TryParse(Console.ReadLine(), out orderNumber);
            Order order = orders.Find(o => o.OrderNumber == orderNumber);
            if (order == null)  // Условная проверка
            {
                Console.WriteLine("Заказ не найден!");  // Вывод текста в консоль
            }
            else
            {
                Console.WriteLine("Выберите новый статус:");  // Вывод текста в консоль
                Console.WriteLine("1. InProcess");  // Вывод текста в консоль
                Console.WriteLine("2. Ready");  // Вывод текста в консоль
                Console.WriteLine("3. Delivered");  // Вывод текста в консоль
                string statusChoice = Console.ReadLine();
                switch (statusChoice)
                {
                    case "1":  // Пункт меню
                        order.Status = OrderStatus.InProcess;
                        break;
                    case "2":  // Пункт меню
                        order.Status = OrderStatus.Ready;
                        break;
                    case "3":  // Пункт меню
                        order.Status = OrderStatus.Delivered;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");  // Вывод текста в консоль
                        break;
                }
                Console.WriteLine("Статус изменен.");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void ManageDishes()  // Метод: ManageDishes
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Управление блюдами ====");  // Отображение заголовка раздела
                Console.WriteLine("Список блюд:");  // Вывод текста в консоль
                for (int i = 0; i < dishes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {dishes[i].Name}, Категория: {dishes[i].Category}, Цена: {dishes[i].Price}");  // Вывод текста в консоль
                }
                Console.WriteLine();  // Вывод текста в консоль
                Console.WriteLine("1. Добавить блюдо");  // Вывод текста в консоль
                Console.WriteLine("2. Редактировать блюдо");  // Вывод текста в консоль
                Console.WriteLine("3. Удалить блюдо");  // Вывод текста в консоль
                Console.WriteLine("4. Фильтрация блюд (по категории)");  // Вывод текста в консоль
                Console.WriteLine("0. Назад");  // Вывод текста в консоль
                Console.Write("Выберите действие: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        AddDish();
                        break;
                    case "2":  // Пункт меню
                        EditDish();
                        break;
                    case "3":  // Пункт меню
                        DeleteDish();
                        break;
                    case "4":  // Пункт меню
                        FilterDishes();
                        break;
                    case "0":  // Пункт меню
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void AddDish()  // Метод: AddDish
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Добавление нового блюда ====");  // Отображение заголовка раздела
            Dish dish = new Dish();
            Console.Write("Введите название блюда: ");  // Вывод текста в консоль
            dish.Name = Console.ReadLine();
            Console.Write("Введите категорию блюда: ");  // Вывод текста в консоль
            dish.Category = Console.ReadLine();
            Console.Write("Введите цену блюда: ");  // Вывод текста в консоль
            double price;
            double.TryParse(Console.ReadLine(), out price);
            dish.Price = price;
            dishes.Add(dish);  // Добавление блюда
            Console.WriteLine("Блюдо добавлено успешно!");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void EditDish()  // Метод: EditDish
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Редактирование блюда ====");  // Отображение заголовка раздела
            Console.Write("Введите номер блюда для редактирования: ");  // Вывод текста в консоль
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > dishes.Count)  // Условная проверка
            {
                Console.WriteLine("Неверный номер блюда.");  // Вывод текста в консоль
            }
            else
            {
                Dish dish = dishes[index - 1];
                Console.Write($"Новое название (текущее: {dish.Name}): ");  // Вывод текста в консоль
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))  // Условная проверка
                    dish.Name = newName;
                Console.Write($"Новая категория (текущее: {dish.Category}): ");  // Вывод текста в консоль
                string newCategory = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCategory))  // Условная проверка
                    dish.Category = newCategory;
                Console.Write($"Новая цена (текущее: {dish.Price}): ");  // Вывод текста в консоль
                string newPrice = Console.ReadLine();
                double price;
                if (double.TryParse(newPrice, out price))  // Условная проверка
                    dish.Price = price;
                Console.WriteLine("Блюдо обновлено.");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void DeleteDish()  // Метод: DeleteDish
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Удаление блюда ====");  // Отображение заголовка раздела
            Console.Write("Введите номер блюда для удаления: ");  // Вывод текста в консоль
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > dishes.Count)  // Условная проверка
            {
                Console.WriteLine("Неверный номер блюда.");  // Вывод текста в консоль
            }
            else
            {
                dishes.RemoveAt(index - 1);
                Console.WriteLine("Блюдо удалено.");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void FilterDishes()  // Метод: FilterDishes
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Фильтрация блюд ====");  // Отображение заголовка раздела
            Console.Write("Введите категорию для фильтрации: ");  // Вывод текста в консоль
            string category = Console.ReadLine();
            var filtered = dishes.FindAll(d => d.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0);  // Создание списка
            if (filtered.Count == 0)  // Условная проверка
            {
                Console.WriteLine("Блюда не найдены.");  // Вывод текста в консоль
            }
            else
            {
                foreach (var dish in filtered)  // Перебор элементов
                {
                    Console.WriteLine($"Название: {dish.Name}, Категория: {dish.Category}, Цена: {dish.Price}");  // Вывод текста в консоль
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        #endregion

        #region Управление клиентами

        static void ManageClients()  // Метод: ManageClients
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Управление клиентами ====");  // Отображение заголовка раздела
                Console.WriteLine("Список клиентов:");  // Вывод текста в консоль
                for (int i = 0; i < clients.Count; i++)
                {
                    Client c = clients[i];
                    Console.WriteLine($"{i + 1}. Имя: {c.Name}, Телефон: {c.PhoneNumber}, VIP: {c.IsVIP}, Бонусы: {c.AccumulatedBonus}, Дата регистрации: {c.RegistrationDate.ToShortDateString()}, Карта: {c.HasMembershipCard}, Скидка: {c.Discount}%");  // Вывод текста в консоль
                }
                Console.WriteLine();  // Вывод текста в консоль
                Console.WriteLine("1. Добавить клиента");  // Вывод текста в консоль
                Console.WriteLine("2. Редактировать клиента");  // Вывод текста в консоль
                Console.WriteLine("3. Удалить клиента");  // Вывод текста в консоль
                Console.WriteLine("4. Поиск клиентов");  // Вывод текста в консоль
                Console.WriteLine("0. Назад");  // Вывод текста в консоль
                Console.Write("Выберите действие: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        AddClient();
                        break;
                    case "2":  // Пункт меню
                        EditClient();
                        break;
                    case "3":  // Пункт меню
                        DeleteClient();
                        break;
                    case "4":  // Пункт меню
                        SearchClient();
                        break;
                    case "0":  // Пункт меню
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void AddClient()  // Метод: AddClient
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Добавление клиента ====");  // Отображение заголовка раздела
            Client client = new Client();
            Console.Write("Введите имя клиента: ");  // Вывод текста в консоль
            client.Name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");  // Вывод текста в консоль
            client.PhoneNumber = Console.ReadLine();
            Console.Write("VIP статус (true/false): ");  // Вывод текста в консоль
            bool isVip;
            Boolean.TryParse(Console.ReadLine(), out isVip);
            client.IsVIP = isVip;
            client.RegistrationDate = DateTime.Now;
            Console.Write("Наличие членской карты (true/false): ");  // Вывод текста в консоль
            bool hasCard;
            Boolean.TryParse(Console.ReadLine(), out hasCard);
            client.HasMembershipCard = hasCard;
            Console.Write("Введите размер скидки (например, 5 для 5%): ");  // Вывод текста в консоль
            double discount;
            double.TryParse(Console.ReadLine(), out discount);
            client.Discount = discount;
            client.AccumulatedBonus = 0;
            clients.Add(client);  // Добавление клиента
            Console.WriteLine("Клиент добавлен успешно!");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void EditClient()  // Метод: EditClient
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Редактирование клиента ====");  // Отображение заголовка раздела
            Console.Write("Введите номер клиента для редактирования: ");  // Вывод текста в консоль
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > clients.Count)  // Условная проверка
            {
                Console.WriteLine("Неверный номер клиента.");  // Вывод текста в консоль
            }
            else
            {
                Client client = clients[index - 1];
                Console.Write($"Новое имя (текущее: {client.Name}): ");  // Вывод текста в консоль
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))  // Условная проверка
                    client.Name = newName;
                Console.Write($"Новый телефон (текущее: {client.PhoneNumber}): ");  // Вывод текста в консоль
                string newPhone = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPhone))  // Условная проверка
                    client.PhoneNumber = newPhone;
                Console.Write($"VIP статус (текущее: {client.IsVIP}) (true/false): ");  // Вывод текста в консоль
                bool isVip;
                if (Boolean.TryParse(Console.ReadLine(), out isVip))  // Условная проверка
                    client.IsVIP = isVip;
                Console.Write($"Наличие членской карты (текущее: {client.HasMembershipCard}) (true/false): ");  // Вывод текста в консоль
                bool hasCard;
                if (Boolean.TryParse(Console.ReadLine(), out hasCard))  // Условная проверка
                    client.HasMembershipCard = hasCard;
                Console.Write($"Размер скидки (текущее: {client.Discount}%): ");  // Вывод текста в консоль
                double discount;
                if (double.TryParse(Console.ReadLine(), out discount))  // Условная проверка
                    client.Discount = discount;
                Console.WriteLine("Клиент обновлен.");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void DeleteClient()  // Метод: DeleteClient
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Удаление клиента ====");  // Отображение заголовка раздела
            Console.Write("Введите номер клиента для удаления: ");  // Вывод текста в консоль
            int index;
            int.TryParse(Console.ReadLine(), out index);
            if (index < 1 || index > clients.Count)  // Условная проверка
            {
                Console.WriteLine("Неверный номер клиента.");  // Вывод текста в консоль
            }
            else
            {
                clients.RemoveAt(index - 1);
                Console.WriteLine("Клиент удален.");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void SearchClient()  // Метод: SearchClient
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Поиск клиентов ====");  // Отображение заголовка раздела
            Console.Write("Введите имя или номер телефона: ");  // Вывод текста в консоль
            string searchTerm = Console.ReadLine();
            var results = clients.FindAll(c => c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||  // Создание списка
                                               c.PhoneNumber.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
            if (results.Count == 0)  // Условная проверка
            {
                Console.WriteLine("Клиенты не найдены.");  // Вывод текста в консоль
            }
            else
            {
                foreach (var client in results)  // Перебор элементов
                {
                    Console.WriteLine($"Имя: {client.Name}, Телефон: {client.PhoneNumber}, VIP: {client.IsVIP}, Бонусы: {client.AccumulatedBonus}, Дата регистрации: {client.RegistrationDate.ToShortDateString()}, Карта: {client.HasMembershipCard}, Скидка: {client.Discount}%");  // Вывод текста в консоль
                }
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        #endregion

        #region Отчеты

        static void ShowReports()  // Метод: ShowReports
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();  // Очистка экрана
                Console.WriteLine("==== Отчеты ====");  // Отображение заголовка раздела
                Console.WriteLine("1. Ежедневная выручка");  // Вывод текста в консоль
                Console.WriteLine("2. Самые популярные товары на складе (топ-5)");  // Вывод текста в консоль
                Console.WriteLine("3. Часто заказываемые блюда");  // Вывод текста в консоль
                Console.WriteLine("4. Статистика посещений гостей");  // Вывод текста в консоль
                Console.WriteLine("0. Назад");  // Вывод текста в консоль
                Console.Write("Выберите действие: ");  // Вывод текста в консоль
                string choice = Console.ReadLine();
                switch (choice)  // Обработка выбранного действия из меню
                {
                    case "1":  // Пункт меню
                        ReportRevenue();
                        break;
                    case "2":  // Пункт меню
                        ReportPopularComponents();
                        break;
                    case "3":  // Пункт меню
                        ReportPopularDishes();
                        break;
                    case "4":  // Пункт меню
                        ReportGuestStatistics();
                        break;
                    case "0":  // Пункт меню
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");  // Вывод текста в консоль
                        Console.ReadKey();  // Ожидание нажатия клавиши
                        break;
                }
            }
        }

        static void ReportRevenue()  // Метод: ReportRevenue
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Ежедневная выручка ====");  // Отображение заголовка раздела
            double hallRevenue = 100;
            double kitchenRevenue = 0;
            foreach (var order in orders)  // Перебор элементов
            {
                if (order.Status == OrderStatus.Delivered)  // Условная проверка
                {
                    kitchenRevenue += order.SelectedDish.Price;
                }
            }
            double vipRevenue = 50;
            Console.WriteLine($"Зал: {hallRevenue} руб.");  // Вывод текста в консоль
            Console.WriteLine($"Кухня: {kitchenRevenue} руб.");  // Вывод текста в консоль
            Console.WriteLine($"VIP: {vipRevenue} руб.");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void ReportPopularComponents()  // Метод: ReportPopularComponents
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Самые популярные товары на складе (топ-5) ====");  // Отображение заголовка раздела
            var topComponents = new List<Component>(components);  // Создание списка
            topComponents.Sort((a, b) => b.Quantity.CompareTo(a.Quantity));
            int count = Math.Min(5, topComponents.Count);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {topComponents[i].Name} - Количество: {topComponents[i].Quantity}");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void ReportPopularDishes()  // Метод: ReportPopularDishes
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Часто заказываемые блюда ====");  // Отображение заголовка раздела
            Dictionary<string, int> dishCount = new Dictionary<string, int>();
            foreach (var order in orders)  // Перебор элементов
            {
                if (dishCount.ContainsKey(order.SelectedDish.Name))  // Условная проверка
                    dishCount[order.SelectedDish.Name]++;
                else
                    dishCount[order.SelectedDish.Name] = 1;
            }
            foreach (var kvp in dishCount)  // Перебор элементов
            {
                Console.WriteLine($"Блюдо: {kvp.Key}, Заказов: {kvp.Value}");  // Вывод текста в консоль
            }
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        static void ReportGuestStatistics()  // Метод: ReportGuestStatistics
        {
            Console.Clear();  // Очистка экрана
            Console.WriteLine("==== Статистика посещений гостей ====");  // Отображение заголовка раздела
            Console.WriteLine($"Количество текущих гостей: {guests.Count}");  // Вывод текста в консоль
            Console.WriteLine("Нажмите любую клавишу для возврата...");  // Вывод текста в консоль
            Console.ReadKey();  // Ожидание нажатия клавиши
        }

        #endregion
    }
}
