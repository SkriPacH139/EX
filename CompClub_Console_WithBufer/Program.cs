using System;
using System.Collections.Generic;
using System.Linq;

namespace CompClub_Console
{

    #region Program Core

    class Program
    {
        static void Main()
        {
            // Инициализируем буфер
            ConsoleBuffer.Init();

            DataStore.InitializeData();

            // Основной цикл программы
            RunMainMenu();

            // Освобождаем ресурсы
            ConsoleBuffer.Dispose();
        }

        static void RunMainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Компьютерный клуб ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 3, "1. Зал для гостей");
                ConsoleBuffer.Write(2, 4, "2. Склад");
                ConsoleBuffer.Write(2, 5, "3. Буфет");
                ConsoleBuffer.Write(2, 6, "4. Управление клиентами");
                ConsoleBuffer.Write(2, 6, "5. Отчеты");
                ConsoleBuffer.Write(2, 7, "0. Выход");
                ConsoleBuffer.Write(2, 8, "Выберите пункт меню: ");
                ConsoleBuffer.Render();

                int key;
                do
                {
                    key = ConsoleBuffer.ReadKeyNonBlocking();
                    ConsoleBuffer.Render();
                }
                while (key == 0);

                switch (key)
                {
                    case '1':
                        ManageHall();
                        break;
                    case '2':
                        ManageInventory();
                        break;
                    case '3':
                        ManageKitchen();
                        break;
                    case '4':
                        ManageClients();
                        break;
                    case '5':
                        ShowReports();
                        break;
                    case '0':
                        exit = true;
                        break;
                    default:
                        ShowMessage("Неверный выбор, нажмите любую клавишу для продолжения...");
                        break;

                }
            }
        }
        static void ShowMessage(string message)
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 2, message, ConsoleColor.Red);
            ConsoleBuffer.Render();

            // Ждём любую клавишу
            while (ConsoleBuffer.ReadKeyNonBlocking() == 0) { }
        }


        #region Зал для гостей
        static void ManageHall()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Зал для гостей ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 2, $"Свободных мест: {DataStore.TotalSeats - DataStore.Guests.Count} из {DataStore.TotalSeats}");

                int line = 4;
                foreach (var guest in DataStore.Guests)
                {
                    ConsoleBuffer.Write(2, (short)line++, $"Имя: {guest.Name}, VIP: {guest.IsVIP}, Начало: {guest.StartTime}, Место: {guest.SeatNumber}, Тариф: {guest.Tariff}, Минут: {guest.RentalMinutes}");
                }

                line++;
                ConsoleBuffer.Write(2, (short)line++, "1. Добавить гостя");
                ConsoleBuffer.Write(2, (short)line++, "2. Завершить сеанс гостя");
                ConsoleBuffer.Write(2, (short)line++, "0. Назад");
                ConsoleBuffer.Write(2, (short)line++, "Выберите действие: ");

                ConsoleBuffer.Render();

                int key;
                do { key = ConsoleBuffer.ReadKeyNonBlocking(); } while (key == 0);

                switch (key)
                {
                    case '1':
                        AddGuest();
                        break;
                    case '2':
                        FinishGuestSession();
                        break;
                    case '0':
                        back = true;
                        break;
                    default:
                        ShowMessage("Неверный выбор. Нажмите любую клавишу...");
                        break;
                }
            }
        }

        static void AddGuest()
        {
            Console.Clear(); // Можно убрать, если всё делать через ConsoleBuffer

            if (DataStore.Guests.Count >= DataStore.TotalSeats)
            {
                ShowMessage("Нет свободных мест!");
                return;
            }

            Guest newGuest = new Guest();
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Добавление нового гостя ====", ConsoleColor.Green);
            ConsoleBuffer.Write(2, 3, "Введите имя гостя: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(22, 3);
            newGuest.Name = Console.ReadLine();

            ConsoleBuffer.Write(2, 4, "VIP статус (true/false): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(30, 4);
            bool isVip;
            Boolean.TryParse(Console.ReadLine(), out isVip);
            newGuest.IsVIP = isVip;

            newGuest.StartTime = DateTime.Now;
            newGuest.Tariff = 1.5;
            newGuest.RentalMinutes = 0;

            // Определение первого свободного места
            int seat = 1;
            var occupiedSeats = DataStore.Guests.Select(g => g.SeatNumber).ToHashSet();
            while (occupiedSeats.Contains(seat) && seat <= DataStore.TotalSeats)
                seat++;

            if (seat > DataStore.TotalSeats)
            {
                ShowMessage("Нет свободных мест!");
                return;
            }

            newGuest.SeatNumber = seat;
            DataStore.Guests.Add(newGuest);
            ShowMessage("Гость добавлен успешно!");
        }

        static void FinishGuestSession()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Завершение сеанса гостя ====", ConsoleColor.Green);
            ConsoleBuffer.Write(2, 3, "Введите номер места гостя: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(33, 3);
            int seat;
            int.TryParse(Console.ReadLine(), out seat);

            Guest guest = DataStore.Guests.Find(g => g.SeatNumber == seat);
            if (guest == null)
            {
                ShowMessage("Гость с таким местом не найден!");
                return;
            }

            ConsoleBuffer.Write(2, 4, "Введите количество минут аренды: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(38, 4);
            int minutes;
            int.TryParse(Console.ReadLine(), out minutes);

            guest.RentalMinutes = minutes;
            double cost = guest.CalculateCost();

            ConsoleBuffer.Write(2, 6, $"Сеанс завершен. Сумма к оплате: {cost}", ConsoleColor.Yellow);
            DataStore.Guests.Remove(guest);
            ConsoleBuffer.Write(2, 8, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }
        #endregion

        #region Склад

        static void ManageInventory()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Склад ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 2, "Список комплектующих:");

                int line = 4;
                foreach (var comp in DataStore.Components)
                {
                    ConsoleBuffer.Write(2, (short)line++, $"Название: {comp.Name}, Категория: {comp.Category}, Кол-во: {comp.Quantity}, Цена: {comp.Price}");
                }

                line++;
                ConsoleBuffer.Write(2, (short)line++, "1. Добавить товар");
                ConsoleBuffer.Write(2, (short)line++, "2. Списать/Передать товар");
                ConsoleBuffer.Write(2, (short)line++, "3. Поиск по названию/категории");
                ConsoleBuffer.Write(2, (short)line++, "0. Назад");
                ConsoleBuffer.Write(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.Render();

                int key;
                do { key = ConsoleBuffer.ReadKeyNonBlocking(); } while (key == 0);

                switch (key)
                {
                    case '1':
                        AddComponent();
                        break;
                    case '2':
                        WriteOffComponent();
                        break;
                    case '3':
                        SearchComponent();
                        break;
                    case '0':
                        back = true;
                        break;
                    default:
                        ShowMessage("Неверный выбор. Нажмите любую клавишу...");
                        break;
                }
            }
        }

        static void AddComponent()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Добавление нового товара ====", ConsoleColor.Green);
            Component comp = new Component();

            ConsoleBuffer.Write(2, 3, "Введите название товара: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(30, 3);
            comp.Name = Console.ReadLine();

            ConsoleBuffer.Write(2, 4, "Введите категорию товара: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(31, 4);
            comp.Category = Console.ReadLine();

            ConsoleBuffer.Write(2, 5, "Введите количество: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(23, 5);
            int qty;
            int.TryParse(Console.ReadLine(), out qty);
            comp.Quantity = qty;

            ConsoleBuffer.Write(2, 6, "Введите цену: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(18, 6);
            double price;
            double.TryParse(Console.ReadLine(), out price);
            comp.Price = price;

            DataStore.Components.Add(comp);
            ShowMessage("Товар добавлен успешно!");
        }

        static void WriteOffComponent()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Списание/Передача товара ====", ConsoleColor.Green);
            ConsoleBuffer.Write(2, 3, "Введите название товара: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(28, 3);
            string name = Console.ReadLine();

            Component comp = DataStore.Components.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (comp == null)
            {
                ShowMessage("Товар не найден!");
                return;
            }

            ConsoleBuffer.Write(2, 4, "Введите количество для списания: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(35, 4);
            int qty;
            int.TryParse(Console.ReadLine(), out qty);

            if (qty > comp.Quantity)
            {
                ShowMessage("Недостаточно товара для списания!");
            }
            else
            {
                comp.Quantity -= qty;
                ShowMessage("Операция выполнена успешно!");
            }
        }

        static void SearchComponent()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Поиск товара ====", ConsoleColor.Green);
            ConsoleBuffer.Write(2, 3, "Введите название или категорию: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(36, 3);
            string searchTerm = Console.ReadLine();

            var results = DataStore.Components.FindAll(c =>
                c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Category.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Результаты поиска ====", ConsoleColor.Yellow);
            int line = 3;

            if (results.Count == 0)
            {
                ConsoleBuffer.Write(2, (short)line++, "Товар не найден!");
            }
            else
            {
                foreach (var comp in results)
                {
                    ConsoleBuffer.Write(2, (short)line++, $"Название: {comp.Name}, Категория: {comp.Category}, Кол-во: {comp.Quantity}, Цена: {comp.Price}");
                }
            }

            ConsoleBuffer.Write(2, (short)++line, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        #endregion

        #region Буффет (Кухня)

        static void ManageKitchen()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Буффет ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 2, "Список заказов:");

                int line = 4;
                foreach (var order in DataStore.Orders)
                {
                    ConsoleBuffer.Write(2, (short)line++, $"Номер: {order.OrderNumber}, Клиент: {order.ClientName}, Блюдо: {order.SelectedDish.Name}, Статус: {order.Status}");
                }

                line++;
                ConsoleBuffer.Write(2, (short)line++, "1. Добавить заказ");
                ConsoleBuffer.Write(2, (short)line++, "2. Изменить статус заказа");
                ConsoleBuffer.Write(2, (short)line++, "3. Управление блюдами");
                ConsoleBuffer.Write(2, (short)line++, "0. Назад");
                ConsoleBuffer.Write(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.Render();

                int key;
                do { key = ConsoleBuffer.ReadKeyNonBlocking(); } while (key == 0);

                switch (key)
                {
                    case '1': AddOrder(); break;
                    case '2': ChangeOrderStatus(); break;
                    case '3': ManageDishes(); break;
                    case '0': back = true; break;
                    default: ShowMessage("Неверный выбор."); break;
                }
            }
        }

        static void AddOrder()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Добавление заказа ====", ConsoleColor.Green);

            Order order = new Order();

            ConsoleBuffer.Write(2, 3, "Введите имя клиента: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(26, 3);
            order.ClientName = Console.ReadLine();

            ConsoleBuffer.Write(2, 4, "Введите номер заказа: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(26, 4);
            int.TryParse(Console.ReadLine(), out int orderNumber);
            order.OrderNumber = orderNumber;

            ConsoleBuffer.Write(2, 5, "Выберите блюдо:");
            int line = 6;
            for (int i = 0; i < DataStore.Dishes.Count; i++)
            {
                ConsoleBuffer.Write(4, (short)line++, $"{i + 1}. {DataStore.Dishes[i].Name} - {DataStore.Dishes[i].Price} руб.");
            }
            ConsoleBuffer.Render();
            Console.SetCursorPosition(2, line);
            int.TryParse(Console.ReadLine(), out int dishChoice);

            if (dishChoice >= 1 && dishChoice <= DataStore.Dishes.Count)
            {
                order.SelectedDish = DataStore.Dishes[dishChoice - 1];
                order.Status = OrderStatus.InProcess;
                DataStore.Orders.Add(order);
                ShowMessage("Заказ добавлен успешно!");
            }
            else
            {
                ShowMessage("Неверный выбор блюда.");
            }
        }

        static void ChangeOrderStatus()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Изменение статуса ====", ConsoleColor.Yellow);
            ConsoleBuffer.Write(2, 3, "Введите номер заказа: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(26, 3);
            int.TryParse(Console.ReadLine(), out int number);

            Order order = DataStore.Orders.Find(o => o.OrderNumber == number);
            if (order == null)
            {
                ShowMessage("Заказ не найден!");
                return;
            }

            ConsoleBuffer.Write(2, 5, "1. InProcess");
            ConsoleBuffer.Write(2, 6, "2. Ready");
            ConsoleBuffer.Write(2, 7, "3. Delivered");
            ConsoleBuffer.Write(2, 8, "Выберите новый статус: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(28, 8);
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": order.Status = OrderStatus.InProcess; break;
                case "2": order.Status = OrderStatus.Ready; break;
                case "3": order.Status = OrderStatus.Delivered; break;
                default: ShowMessage("Неверный статус."); return;
            }
            ShowMessage("Статус обновлен.");
        }

        static void ManageDishes()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Управление блюдами ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 2, "Список блюд:");

                int line = 4;
                for (int i = 0; i < DataStore.Dishes.Count; i++)
                {
                    var d = DataStore.Dishes[i];
                    ConsoleBuffer.Write(2, (short)line++, $"{i + 1}. {d.Name}, Категория: {d.Category}, Цена: {d.Price} руб.");
                }

                line++;
                ConsoleBuffer.Write(2, (short)line++, "1. Добавить блюдо");
                ConsoleBuffer.Write(2, (short)line++, "2. Редактировать блюдо");
                ConsoleBuffer.Write(2, (short)line++, "3. Удалить блюдо");
                ConsoleBuffer.Write(2, (short)line++, "4. Фильтрация по категории");
                ConsoleBuffer.Write(2, (short)line++, "0. Назад");
                ConsoleBuffer.Write(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.Render();

                int key;
                do { key = ConsoleBuffer.ReadKeyNonBlocking(); } while (key == 0);

                switch (key)
                {
                    case '1': AddDish(); break;
                    case '2': EditDish(); break;
                    case '3': DeleteDish(); break;
                    case '4': FilterDishes(); break;
                    case '0': back = true; break;
                    default: ShowMessage("Неверный выбор."); break;
                }
            }
        }

        static void AddDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Добавление блюда ====", ConsoleColor.Green);

            Dish dish = new Dish();

            ConsoleBuffer.Write(2, 3, "Название: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(12, 3);
            dish.Name = Console.ReadLine();

            ConsoleBuffer.Write(2, 4, "Категория: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(13, 4);
            dish.Category = Console.ReadLine();

            ConsoleBuffer.Write(2, 5, "Цена: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(9, 5);
            double.TryParse(Console.ReadLine(), out double price);
            dish.Price = price;

            DataStore.Dishes.Add(dish);
            ShowMessage("Блюдо добавлено.");
        }

        static void EditDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Редактирование блюда ====", ConsoleColor.Green);
            ConsoleBuffer.Write(2, 3, "Введите номер блюда: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(26, 3);
            int.TryParse(Console.ReadLine(), out int index);

            if (index < 1 || index > DataStore.Dishes.Count)
            {
                ShowMessage("Неверный номер.");
                return;
            }

            var dish = DataStore.Dishes[index - 1];

            ConsoleBuffer.Write(2, 5, $"Название ({dish.Name}): ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(22 + dish.Name.Length, 5);
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName)) dish.Name = newName;

            ConsoleBuffer.Write(2, 6, $"Категория ({dish.Category}): ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(24 + dish.Category.Length, 6);
            string newCat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCat)) dish.Category = newCat;

            ConsoleBuffer.Write(2, 7, $"Цена ({dish.Price}): ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(19 + dish.Price.ToString().Length, 7);
            if (double.TryParse(Console.ReadLine(), out double newPrice)) dish.Price = newPrice;

            ShowMessage("Блюдо обновлено.");
        }

        static void DeleteDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Удаление блюда ====", ConsoleColor.Red);
            ConsoleBuffer.Write(2, 3, "Введите номер блюда: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(26, 3);
            int.TryParse(Console.ReadLine(), out int index);

            if (index < 1 || index > DataStore.Dishes.Count)
            {
                ShowMessage("Неверный номер.");
                return;
            }

            DataStore.Dishes.RemoveAt(index - 1);
            ShowMessage("Блюдо удалено.");
        }

        static void FilterDishes()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Фильтрация по категории ====", ConsoleColor.Yellow);
            ConsoleBuffer.Write(2, 3, "Введите категорию: ");
            ConsoleBuffer.Render(); Console.SetCursorPosition(22, 3);
            string category = Console.ReadLine();

            var filtered = DataStore.Dishes.FindAll(d => d.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0);

            int line = 5;
            if (filtered.Count == 0)
            {
                ConsoleBuffer.Write(2, (short)line++, "Блюда не найдены.");
            }
            else
            {
                foreach (var d in filtered)
                {
                    ConsoleBuffer.Write(2, (short)line++, $"Название: {d.Name}, Категория: {d.Category}, Цена: {d.Price}");
                }
            }

            ConsoleBuffer.Write(2, (short)(line + 1), "Нажмите любую клавишу...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        #endregion

        #region Управление клиентами

        static void ManageClients()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Управление клиентами ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 2, "Список клиентов:");

                int line = 4;
                for (int i = 0; i < DataStore.Clients.Count; i++)
                {
                    var c = DataStore.Clients[i];
                    ConsoleBuffer.Write(2, (short)line++, $"{i + 1}. Имя: {c.Name}, Телефон: {c.PhoneNumber}, VIP: {c.IsVIP}, Бонусы: {c.AccumulatedBonus}, Дата регистрации: {c.RegistrationDate.ToShortDateString()}, Карта: {c.HasMembershipCard}, Скидка: {c.Discount}%");
                }

                line++;
                ConsoleBuffer.Write(2, (short)line++, "1. Добавить клиента");
                ConsoleBuffer.Write(2, (short)line++, "2. Редактировать клиента");
                ConsoleBuffer.Write(2, (short)line++, "3. Удалить клиента");
                ConsoleBuffer.Write(2, (short)line++, "4. Поиск клиентов");
                ConsoleBuffer.Write(2, (short)line++, "0. Назад");
                ConsoleBuffer.Write(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.Render();

                int key;
                do { key = ConsoleBuffer.ReadKeyNonBlocking(); } while (key == 0);

                switch (key)
                {
                    case '1': AddClient(); break;
                    case '2': EditClient(); break;
                    case '3': DeleteClient(); break;
                    case '4': SearchClient(); break;
                    case '0': back = true; break;
                    default:
                        ShowMessage("Неверный выбор. Нажмите любую клавишу...");
                        break;
                }
            }
        }

        static void AddClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Добавление клиента ====", ConsoleColor.Green);

            Client client = new Client();

            ConsoleBuffer.Write(2, 3, "Введите имя клиента: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(24, 3);
            client.Name = Console.ReadLine();

            ConsoleBuffer.Write(2, 4, "Введите номер телефона: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(27, 4);
            client.PhoneNumber = Console.ReadLine();

            ConsoleBuffer.Write(2, 5, "VIP статус (true/false): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(26, 5);
            bool.TryParse(Console.ReadLine(), out bool isVip);
            client.IsVIP = isVip;

            client.RegistrationDate = DateTime.Now;

            ConsoleBuffer.Write(2, 6, "Наличие членской карты (true/false): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(38, 6);
            bool.TryParse(Console.ReadLine(), out bool hasCard);
            client.HasMembershipCard = hasCard;

            ConsoleBuffer.Write(2, 7, "Введите размер скидки (%): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(26, 7);
            double.TryParse(Console.ReadLine(), out double discount);
            client.Discount = discount;

            client.AccumulatedBonus = 0;

            DataStore.Clients.Add(client);
            ShowMessage("Клиент добавлен успешно!");
        }

        static void EditClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Редактирование клиента ====", ConsoleColor.Yellow);
            ConsoleBuffer.Write(2, 3, "Введите номер клиента для редактирования: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(41, 3);

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > DataStore.Clients.Count)
            {
                ShowMessage("Неверный номер клиента.");
                return;
            }

            Client client = DataStore.Clients[index - 1];

            ConsoleBuffer.Write(2, 5, $"Новое имя (текущее: {client.Name}): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(25 + client.Name.Length, 5);
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
                client.Name = newName;

            ConsoleBuffer.Write(2, 6, $"Новый телефон (текущее: {client.PhoneNumber}): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(33 + client.PhoneNumber.Length, 6);
            string newPhone = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPhone))
                client.PhoneNumber = newPhone;

            ConsoleBuffer.Write(2, 7, $"VIP статус (текущее: {client.IsVIP}) (true/false): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(40, 7);
            if (bool.TryParse(Console.ReadLine(), out bool isVip))
                client.IsVIP = isVip;

            ConsoleBuffer.Write(2, 8, $"Наличие членской карты (текущее: {client.HasMembershipCard}) (true/false): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(50, 8);
            if (bool.TryParse(Console.ReadLine(), out bool hasCard))
                client.HasMembershipCard = hasCard;

            ConsoleBuffer.Write(2, 9, $"Размер скидки (текущее: {client.Discount}%): ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(34 + client.Discount.ToString().Length, 9);
            if (double.TryParse(Console.ReadLine(), out double discount))
                client.Discount = discount;

            ShowMessage("Клиент обновлен.");
        }

        static void DeleteClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Удаление клиента ====", ConsoleColor.Red);
            ConsoleBuffer.Write(2, 3, "Введите номер клиента для удаления: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(38, 3);

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > DataStore.Clients.Count)
            {
                ShowMessage("Неверный номер клиента.");
                return;
            }

            DataStore.Clients.RemoveAt(index - 1);
            ShowMessage("Клиент удален.");
        }

        static void SearchClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Поиск клиентов ====", ConsoleColor.Green);
            ConsoleBuffer.Write(2, 3, "Введите имя или номер телефона: ");
            ConsoleBuffer.Render();
            Console.SetCursorPosition(34, 3);

            string searchTerm = Console.ReadLine();

            var results = DataStore.Clients.FindAll(c =>
                c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.PhoneNumber.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Результаты поиска ====", ConsoleColor.Yellow);

            int line = 3;
            if (results.Count == 0)
            {
                ConsoleBuffer.Write(2, (short)line++, "Клиенты не найдены.");
            }
            else
            {
                foreach (var client in results)
                {
                    ConsoleBuffer.Write(2, (short)line++, $"Имя: {client.Name}, Телефон: {client.PhoneNumber}, VIP: {client.IsVIP}, Бонусы: {client.AccumulatedBonus}, Дата регистрации: {client.RegistrationDate.ToShortDateString()}, Карта: {client.HasMembershipCard}, Скидка: {client.Discount}%");
                }
            }

            ConsoleBuffer.Write(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        #endregion

        #region Отчеты

        static void ShowReports()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.Write(2, 1, "==== Отчеты ====", ConsoleColor.Cyan);
                ConsoleBuffer.Write(2, 3, "1. Ежедневная выручка");
                ConsoleBuffer.Write(2, 4, "2. Самые популярные товары на складе (топ-5)");
                ConsoleBuffer.Write(2, 5, "3. Часто заказываемые блюда");
                ConsoleBuffer.Write(2, 6, "4. Статистика посещений гостей");
                ConsoleBuffer.Write(2, 7, "0. Назад");
                ConsoleBuffer.Write(2, 9, "Выберите действие: ");
                ConsoleBuffer.Render();

                int key;
                do { key = ConsoleBuffer.ReadKeyNonBlocking(); } while (key == 0);

                switch (key)
                {
                    case '1':
                        ReportRevenue();
                        break;
                    case '2':
                        ReportPopularComponents();
                        break;
                    case '3':
                        ReportPopularDishes();
                        break;
                    case '4':
                        ReportGuestStatistics();
                        break;
                    case '0':
                        back = true;
                        break;
                    default:
                        ShowMessage("Неверный выбор. Нажмите любую клавишу...");
                        break;
                }
            }
        }

        static void ReportRevenue()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Ежедневная выручка ====", ConsoleColor.Green);

            double hallRevenue = 100; // примерные значения
            double kitchenRevenue = 0;
            foreach (var order in DataStore.Orders)
            {
                if (order.Status == OrderStatus.Delivered)
                    kitchenRevenue += order.SelectedDish.Price;
            }
            double vipRevenue = 50;

            ConsoleBuffer.Write(2, 3, $"Зал: {hallRevenue} руб.");
            ConsoleBuffer.Write(2, 4, $"Кухня: {kitchenRevenue} руб.");
            ConsoleBuffer.Write(2, 5, $"VIP: {vipRevenue} руб.");

            ConsoleBuffer.Write(2, 7, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        static void ReportPopularComponents()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Самые популярные товары на складе (топ-5) ====", ConsoleColor.Green);

            var topComponents = new List<Component>(DataStore.Components);
            topComponents.Sort((a, b) => b.Quantity.CompareTo(a.Quantity));

            int count = Math.Min(5, topComponents.Count);
            int line = 3;
            for (int i = 0; i < count; i++)
            {
                ConsoleBuffer.Write(2, (short)line++, $"{i + 1}. {topComponents[i].Name} - Количество: {topComponents[i].Quantity}");
            }

            ConsoleBuffer.Write(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        static void ReportPopularDishes()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Часто заказываемые блюда ====", ConsoleColor.Green);

            Dictionary<string, int> dishCount = new Dictionary<string, int>();
            foreach (var order in DataStore.Orders)
            {
                if (dishCount.ContainsKey(order.SelectedDish.Name))
                    dishCount[order.SelectedDish.Name]++;
                else
                    dishCount[order.SelectedDish.Name] = 1;
            }

            int line = 3;
            foreach (var kvp in dishCount)
            {
                ConsoleBuffer.Write(2, (short)line++, $"Блюдо: {kvp.Key}, Заказов: {kvp.Value}");
            }

            ConsoleBuffer.Write(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        static void ReportGuestStatistics()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.Write(2, 1, "==== Статистика посещений гостей ====", ConsoleColor.Green);

            ConsoleBuffer.Write(2, 3, $"Количество текущих гостей: {DataStore.Guests.Count}");

            ConsoleBuffer.Write(2, 5, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.Render();
            WaitAnyKey();
        }

        #endregion

        static void WaitAnyKey()
        {
            while (ConsoleBuffer.ReadKeyNonBlocking() == 0) { }
        }
    }
}
#endregion
