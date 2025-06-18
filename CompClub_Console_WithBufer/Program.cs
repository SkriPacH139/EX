using CompClub_Console;
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
                ConsoleBuffer.WriteAt(2, 1, "==== Компьютерный клуб ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 3, "1. Зал для гостей");
                //ConsoleBuffer.WriteAt(2, 4, "2. Склад");
                //ConsoleBuffer.WriteAt(2, 5, "3. Буфет");
                //ConsoleBuffer.WriteAt(2, 4, "2. Управление клиентами");
                ConsoleBuffer.WriteAt(2, 4, "2. Отчеты");
                ConsoleBuffer.WriteAt(2, 5, "0. Выход");
                ConsoleBuffer.WriteAt(2, 7, "Выберите пункт меню: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do
                {
                    key = ConsoleBuffer.ReadKeyCode();
                    ConsoleBuffer.PresentBuffer();
                }
                while (key == 0);

                switch (key)
                {
                    case '1':
                        ManageHall();
                        break;
                    case '_':
                       //ManageInventory();
                        break;
                    case '-':
                        //ManageKitchen();
                        break;
                    case '=':
                        //ManageClients();
                        break;
                    case '2':
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
            ConsoleBuffer.WriteAt(2, 2, message, (ushort)ConsoleColor.Red);
            ConsoleBuffer.PresentBuffer();

            // Ждём любую клавишу
            while (ConsoleBuffer.ReadKeyCode() == 0) { }
        }


        #region Зал для гостей
        static void ManageHall()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.WriteAt(2, 1, "==== Зал для гостей ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 2, $"Свободных мест: {DataStore.TotalSeats - DataStore.Guests.Count} из {DataStore.TotalSeats}");

                int line = 4;
                foreach (var guest in DataStore.Guests)
                {
                    ConsoleBuffer.WriteAt(2, (short)line++, $"Имя: {guest.Name}, VIP: {guest.IsVIP}, Начало: {guest.StartTime}, Место: {guest.SeatNumber}, Тариф: {guest.Tariff}, Минут: {guest.RentalMinutes}");
                }

                line++;                
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");

                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

                switch (key)
                {
                    case '-':
                        //AddGuest();
                        break;
                    case '_':
                        //FinishGuestSession();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление нового гостя ====", (ushort)ConsoleColor.Green);
            ConsoleBuffer.WriteAt(2, 3, "Введите имя гостя: ");
            ConsoleBuffer.PresentBuffer();
            newGuest.Name = ReadInputAt(22, 3);

            ConsoleBuffer.WriteAt(2, 4, "VIP статус (true/false): ");
            ConsoleBuffer.PresentBuffer();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Завершение сеанса гостя ====", (ushort)ConsoleColor.Green);
            ConsoleBuffer.WriteAt(2, 3, "Введите номер места гостя: ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(33, 3);
            int seat;
            int.TryParse(Console.ReadLine(), out seat);

            Guest guest = DataStore.Guests.Find(g => g.SeatNumber == seat);
            if (guest == null)
            {
                ShowMessage("Гость с таким местом не найден!");
                return;
            }

            ConsoleBuffer.WriteAt(2, 4, "Введите количество минут аренды: ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(38, 4);
            int minutes;
            int.TryParse(Console.ReadLine(), out minutes);

            guest.RentalMinutes = minutes;
            double cost = guest.CalculateCost();

            ConsoleBuffer.WriteAt(2, 6, $"Сеанс завершен. Сумма к оплате: {cost}", (ushort)ConsoleColor.Yellow);
            DataStore.Guests.Remove(guest);
            ConsoleBuffer.WriteAt(2, 8, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
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
                ConsoleBuffer.WriteAt(2, 1, "==== Склад ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 2, "Список комплектующих:");

                int line = 4;
                foreach (var comp in DataStore.Components)
                {
                    ConsoleBuffer.WriteAt(2, (short)line++, $"Название: {comp.Name}, Категория: {comp.Category}, Кол-во: {comp.Quantity}, Цена: {comp.Price}");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить товар");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Списать/Передать товар");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Поиск по названию/категории");
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

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
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление нового товара ====", (ushort)ConsoleColor.Green);
            Component comp = new Component();

            ConsoleBuffer.WriteAt(2, 3, "Введите название товара: ");
            ConsoleBuffer.PresentBuffer();
            comp.Name = ReadInputAt(30, 3);

            ConsoleBuffer.WriteAt(2, 4, "Введите категорию товара: ");
            ConsoleBuffer.PresentBuffer();
            comp.Category = ReadInputAt(31, 4);

            ConsoleBuffer.WriteAt(2, 5, "Введите количество: ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(23, 5);
            int qty;
            int.TryParse(Console.ReadLine(), out qty);
            comp.Quantity = qty;

            ConsoleBuffer.WriteAt(2, 6, "Введите цену: ");
            ConsoleBuffer.PresentBuffer();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Списание/Передача товара ====", (ushort)ConsoleColor.Green);
            ConsoleBuffer.WriteAt(2, 3, "Введите название товара: ");
            ConsoleBuffer.PresentBuffer();
            string name = ReadInputAt(28, 3);

            Component comp = DataStore.Components.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (comp == null)
            {
                ShowMessage("Товар не найден!");
                return;
            }

            ConsoleBuffer.WriteAt(2, 4, "Введите количество для списания: ");
            ConsoleBuffer.PresentBuffer();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Поиск товара ====", (ushort)ConsoleColor.Green);
            ConsoleBuffer.WriteAt(2, 3, "Введите название или категорию: ");
            ConsoleBuffer.PresentBuffer();
            string searchTerm = ReadInputAt(36, 3);

            var results = DataStore.Components.FindAll(c =>
                c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Category.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Результаты поиска ====", (ushort)ConsoleColor.Yellow);
            int line = 3;

            if (results.Count == 0)
            {
                ConsoleBuffer.WriteAt(2, (short)line++, "Товар не найден!");
            }
            else
            {
                foreach (var comp in results)
                {
                    ConsoleBuffer.WriteAt(2, (short)line++, $"Название: {comp.Name}, Категория: {comp.Category}, Кол-во: {comp.Quantity}, Цена: {comp.Price}");
                }
            }

            ConsoleBuffer.WriteAt(2, (short)++line, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
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
                ConsoleBuffer.WriteAt(2, 1, "==== Буффет ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 2, "Список заказов:");

                int line = 4;
                foreach (var order in DataStore.Orders)
                {
                    ConsoleBuffer.WriteAt(2, (short)line++, $"Номер: {order.OrderNumber}, Клиент: {order.ClientName}, Блюдо: {order.SelectedDish.Name}, Статус: {order.Status}");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить заказ");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Изменить статус заказа");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Управление блюдами");
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

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
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление заказа ====", (ushort)ConsoleColor.Green);

            Order order = new Order();

            ConsoleBuffer.WriteAt(2, 3, "Введите имя клиента: ");
            ConsoleBuffer.PresentBuffer(); order.ClientName = ReadInputAt(26, 3);

            ConsoleBuffer.WriteAt(2, 4, "Введите номер заказа: ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(26, 4);
            int.TryParse(Console.ReadLine(), out int orderNumber);
            order.OrderNumber = orderNumber;

            ConsoleBuffer.WriteAt(2, 5, "Выберите блюдо:");
            int line = 6;
            for (int i = 0; i < DataStore.Dishes.Count; i++)
            {
                ConsoleBuffer.WriteAt(4, (short)line++, $"{i + 1}. {DataStore.Dishes[i].Name} - {DataStore.Dishes[i].Price} руб.");
            }
            ConsoleBuffer.PresentBuffer();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Изменение статуса ====", (ushort)ConsoleColor.Yellow);
            ConsoleBuffer.WriteAt(2, 3, "Введите номер заказа: ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(26, 3);
            int.TryParse(Console.ReadLine(), out int number);

            Order order = DataStore.Orders.Find(o => o.OrderNumber == number);
            if (order == null)
            {
                ShowMessage("Заказ не найден!");
                return;
            }

            ConsoleBuffer.WriteAt(2, 5, "1. InProcess");
            ConsoleBuffer.WriteAt(2, 6, "2. Ready");
            ConsoleBuffer.WriteAt(2, 7, "3. Delivered");
            ConsoleBuffer.WriteAt(2, 8, "Выберите новый статус: ");
            ConsoleBuffer.PresentBuffer(); string input = ReadInputAt(28, 8);

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
                ConsoleBuffer.WriteAt(2, 1, "==== Управление блюдами ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 2, "Список блюд:");

                int line = 4;
                for (int i = 0; i < DataStore.Dishes.Count; i++)
                {
                    var d = DataStore.Dishes[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. {d.Name}, Категория: {d.Category}, Цена: {d.Price} руб.");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить блюдо");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Редактировать блюдо");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Удалить блюдо");
                ConsoleBuffer.WriteAt(2, (short)line++, "4. Фильтрация по категории");
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

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
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление блюда ====", (ushort)ConsoleColor.Green);

            Dish dish = new Dish();

            ConsoleBuffer.WriteAt(2, 3, "Название: ");
            ConsoleBuffer.PresentBuffer(); dish.Name = ReadInputAt(12, 3);

            ConsoleBuffer.WriteAt(2, 4, "Категория: ");
            ConsoleBuffer.PresentBuffer(); dish.Category = ReadInputAt(13, 4);

            ConsoleBuffer.WriteAt(2, 5, "Цена: ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(9, 5);
            double.TryParse(Console.ReadLine(), out double price);
            dish.Price = price;

            DataStore.Dishes.Add(dish);
            ShowMessage("Блюдо добавлено.");
        }

        static void EditDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Редактирование блюда ====", (ushort)ConsoleColor.Green);
            ConsoleBuffer.WriteAt(2, 3, "Введите номер блюда: ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(26, 3);
            int.TryParse(Console.ReadLine(), out int index);

            if (index < 1 || index > DataStore.Dishes.Count)
            {
                ShowMessage("Неверный номер.");
                return;
            }

            var dish = DataStore.Dishes[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Название ({dish.Name}): ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(22 + dish.Name.Length, 5);
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName)) dish.Name = newName;

            ConsoleBuffer.WriteAt(2, 6, $"Категория ({dish.Category}): ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(24 + dish.Category.Length, 6);
            string newCat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCat)) dish.Category = newCat;

            ConsoleBuffer.WriteAt(2, 7, $"Цена ({dish.Price}): ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(19 + dish.Price.ToString().Length, 7);
            if (double.TryParse(Console.ReadLine(), out double newPrice)) dish.Price = newPrice;

            ShowMessage("Блюдо обновлено.");
        }

        static void DeleteDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Удаление блюда ====", (ushort)ConsoleColor.Red);
            ConsoleBuffer.WriteAt(2, 3, "Введите номер блюда: ");
            ConsoleBuffer.PresentBuffer(); Console.SetCursorPosition(26, 3);
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
            ConsoleBuffer.WriteAt(2, 1, "==== Фильтрация по категории ====", (ushort)ConsoleColor.Yellow);
            ConsoleBuffer.WriteAt(2, 3, "Введите категорию: ");
            ConsoleBuffer.PresentBuffer(); string category = ReadInputAt(22, 3);

            var filtered = DataStore.Dishes.FindAll(d => d.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0);

            int line = 5;
            if (filtered.Count == 0)
            {
                ConsoleBuffer.WriteAt(2, (short)line++, "Блюда не найдены.");
            }
            else
            {
                foreach (var d in filtered)
                {
                    ConsoleBuffer.WriteAt(2, (short)line++, $"Название: {d.Name}, Категория: {d.Category}, Цена: {d.Price}");
                }
            }

            ConsoleBuffer.WriteAt(2, (short)(line + 1), "Нажмите любую клавишу...");
            ConsoleBuffer.PresentBuffer();
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
                ConsoleBuffer.WriteAt(2, 1, "==== Управление клиентами ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 2, "Список клиентов:");

                int line = 4;
                for (int i = 0; i < DataStore.Clients.Count; i++)
                {
                    var c = DataStore.Clients[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. Имя: {c.Name}, Телефон: {c.PhoneNumber}, VIP: {c.IsVIP}, Бонусы: {c.AccumulatedBonus}, Дата регистрации: {c.RegistrationDate.ToShortDateString()}, Карта: {c.HasMembershipCard}, Скидка: {c.Discount}%");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить клиента");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Редактировать клиента");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Удалить клиента");
                ConsoleBuffer.WriteAt(2, (short)line++, "4. Поиск клиентов");
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

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
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление клиента ====", (ushort)ConsoleColor.Green);

            Client client = new Client();

            ConsoleBuffer.WriteAt(2, 3, "Введите имя клиента: ");
            ConsoleBuffer.PresentBuffer();
            client.Name = ReadInputAt(24, 3);

            ConsoleBuffer.WriteAt(2, 4, "Введите номер телефона: ");
            ConsoleBuffer.PresentBuffer();
            client.PhoneNumber = ReadInputAt(27, 4);

            ConsoleBuffer.WriteAt(2, 5, "VIP статус (true/false): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(26, 5);
            bool.TryParse(Console.ReadLine(), out bool isVip);
            client.IsVIP = isVip;

            client.RegistrationDate = DateTime.Now;

            ConsoleBuffer.WriteAt(2, 6, "Наличие членской карты (true/false): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(38, 6);
            bool.TryParse(Console.ReadLine(), out bool hasCard);
            client.HasMembershipCard = hasCard;

            ConsoleBuffer.WriteAt(2, 7, "Введите размер скидки (%): ");
            ConsoleBuffer.PresentBuffer();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Редактирование клиента ====", (ushort)ConsoleColor.Yellow);
            ConsoleBuffer.WriteAt(2, 3, "Введите номер клиента для редактирования: ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(41, 3);

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > DataStore.Clients.Count)
            {
                ShowMessage("Неверный номер клиента.");
                return;
            }

            Client client = DataStore.Clients[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Новое имя (текущее: {client.Name}): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(25 + client.Name.Length, 5);
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
                client.Name = newName;

            ConsoleBuffer.WriteAt(2, 6, $"Новый телефон (текущее: {client.PhoneNumber}): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(33 + client.PhoneNumber.Length, 6);
            string newPhone = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPhone))
                client.PhoneNumber = newPhone;

            ConsoleBuffer.WriteAt(2, 7, $"VIP статус (текущее: {client.IsVIP}) (true/false): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(40, 7);
            if (bool.TryParse(Console.ReadLine(), out bool isVip))
                client.IsVIP = isVip;

            ConsoleBuffer.WriteAt(2, 8, $"Наличие членской карты (текущее: {client.HasMembershipCard}) (true/false): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(50, 8);
            if (bool.TryParse(Console.ReadLine(), out bool hasCard))
                client.HasMembershipCard = hasCard;

            ConsoleBuffer.WriteAt(2, 9, $"Размер скидки (текущее: {client.Discount}%): ");
            ConsoleBuffer.PresentBuffer();
            Console.SetCursorPosition(34 + client.Discount.ToString().Length, 9);
            if (double.TryParse(Console.ReadLine(), out double discount))
                client.Discount = discount;

            ShowMessage("Клиент обновлен.");
        }

        static void DeleteClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Удаление клиента ====", (ushort)ConsoleColor.Red);
            ConsoleBuffer.WriteAt(2, 3, "Введите номер клиента для удаления: ");
            ConsoleBuffer.PresentBuffer();
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
            ConsoleBuffer.WriteAt(2, 1, "==== Поиск клиентов ====", (ushort)ConsoleColor.Green);
            ConsoleBuffer.WriteAt(2, 3, "Введите имя или номер телефона: ");
            ConsoleBuffer.PresentBuffer();
            string searchTerm = ReadInputAt(34, 3);

            var results = DataStore.Clients.FindAll(c =>
                c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.PhoneNumber.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Результаты поиска ====", (ushort)ConsoleColor.Yellow);

            int line = 3;
            if (results.Count == 0)
            {
                ConsoleBuffer.WriteAt(2, (short)line++, "Клиенты не найдены.");
            }
            else
            {
                foreach (var client in results)
                {
                    ConsoleBuffer.WriteAt(2, (short)line++, $"Имя: {client.Name}, Телефон: {client.PhoneNumber}, VIP: {client.IsVIP}, Бонусы: {client.AccumulatedBonus}, Дата регистрации: {client.RegistrationDate.ToShortDateString()}, Карта: {client.HasMembershipCard}, Скидка: {client.Discount}%");
                }
            }

            ConsoleBuffer.WriteAt(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
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
                ConsoleBuffer.WriteAt(2, 1, "==== Отчеты ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 3, "1. Ежедневная выручка");
                ConsoleBuffer.WriteAt(2, 4, "2. Самые популярные товары на складе (топ-5)");
                //ConsoleBuffer.WriteAt(2, 5, "3. Часто заказываемые блюда");
                ConsoleBuffer.WriteAt(2, 5, "3. Статистика посещений гостей");
                ConsoleBuffer.WriteAt(2, 6, "0. Назад");
                ConsoleBuffer.WriteAt(2, 8, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

                switch (key)
                {
                    case '1':
                        ReportRevenue();
                        break;
                    case '2':
                        ReportPopularComponents();
                        break;
                    case '-':
                        //ReportPopularDishes();
                        break;
                    case '3':
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
            ConsoleBuffer.WriteAt(2, 1, "==== Ежедневная выручка ====", (ushort)ConsoleColor.Green);

            double hallRevenue = 100; // примерные значения
            double kitchenRevenue = 0;
            foreach (var order in DataStore.Orders)
            {
                if (order.Status == OrderStatus.Delivered)
                    kitchenRevenue += order.SelectedDish.Price;
            }
            double vipRevenue = 50;

            ConsoleBuffer.WriteAt(2, 3, $"Зал: {hallRevenue} руб.");
            ConsoleBuffer.WriteAt(2, 4, $"Кухня: {kitchenRevenue} руб.");
            ConsoleBuffer.WriteAt(2, 5, $"VIP: {vipRevenue} руб.");

            ConsoleBuffer.WriteAt(2, 7, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
            WaitAnyKey();
        }

        static void ReportPopularComponents()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Самые популярные товары на складе (топ-5) ====", (ushort)ConsoleColor.Green);

            var topComponents = new List<Component>(DataStore.Components);
            topComponents.Sort((a, b) => b.Quantity.CompareTo(a.Quantity));

            int count = Math.Min(5, topComponents.Count);
            int line = 3;
            for (int i = 0; i < count; i++)
            {
                ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. {topComponents[i].Name} - Количество: {topComponents[i].Quantity}");
            }

            ConsoleBuffer.WriteAt(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
            WaitAnyKey();
        }

        static void ReportPopularDishes()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Часто заказываемые блюда ====", (ushort)ConsoleColor.Green);

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
                ConsoleBuffer.WriteAt(2, (short)line++, $"Блюдо: {kvp.Key}, Заказов: {kvp.Value}");
            }

            ConsoleBuffer.WriteAt(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
            WaitAnyKey();
        }

        static void ReportGuestStatistics()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Статистика посещений гостей ====", (ushort)ConsoleColor.Green);

            ConsoleBuffer.WriteAt(2, 3, $"Количество текущих гостей: {DataStore.Guests.Count}");

            ConsoleBuffer.WriteAt(2, 5, "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();
            WaitAnyKey();
        }

        #endregion

        static void WaitAnyKey()
        {
            while (ConsoleBuffer.ReadKeyCode() == 0) { }
        }

        static string ReadInputAt(int x, int y)
        {
            ConsoleBuffer.Dispose();
            Console.SetCursorPosition(x, y);
            string input = Console.ReadLine();
            ConsoleBuffer.Init();
            return input;
        }
    }
}
#endregion

    

