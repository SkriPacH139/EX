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
                ConsoleBuffer.WriteAt(2, 4, "2. Склад");
                ConsoleBuffer.WriteAt(2, 5, "3. Буфет");
                ConsoleBuffer.WriteAt(2, 6, "4. Управление клиентами");
                ConsoleBuffer.WriteAt(2, 6, "5. Отчеты");
                ConsoleBuffer.WriteAt(2, 7, "0. Выход");
                ConsoleBuffer.WriteAt(2, 8, "Выберите пункт меню: ");
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
                for (int i = 0; i < DataStore.Guests.Count; i++)
                {
                    var g = DataStore.Guests[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. Имя: {g.Name}, Возраст: {g.Age}, В клубе с: {g.JoinTime}");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить гостя");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Редактировать гостя");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Удалить гостя");
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

                switch (key)
                {
                    case '1': AddGuest(); break;
                    case '2': EditGuest(); break;
                    case '3': DeleteGuest(); break;
                    case '0': back = true; break;
                    default: ShowMessage("Неверный выбор."); break;
                }
            }
        }

        static void AddGuest()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление гостя ====", (ushort)ConsoleColor.Green);

            if (DataStore.Guests.Count >= DataStore.TotalSeats)
            {
                ShowMessage("Нет свободных мест.");
                return;
            }

            Guest guest = new Guest();

            ConsoleBuffer.WriteAt(2, 3, "Введите имя гостя: ");
            ConsoleBuffer.PresentBuffer();
            guest.Name = ReadInputAt(22, 3);

            ConsoleBuffer.WriteAt(2, 4, "Введите возраст: ");
            ConsoleBuffer.PresentBuffer();
            int.TryParse(ReadInputAt(18, 4), out int age);
            guest.Age = age;

            guest.JoinTime = DateTime.Now;

            DataStore.Guests.Add(guest);
            ShowMessage("Гость успешно добавлен!");
        }

        static void EditGuest()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Редактирование гостя ====", (ushort)ConsoleColor.Yellow);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер гостя для редактирования: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(45, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Guests.Count)
            {
                ShowMessage("Неверный номер гостя.");
                return;
            }

            Guest guest = DataStore.Guests[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Текущее имя: {guest.Name}. Новое имя (Enter — оставить): ");
            ConsoleBuffer.PresentBuffer();
            string newName = ReadInputAt(52, 5);
            if (!string.IsNullOrWhiteSpace(newName))
                guest.Name = newName;

            ConsoleBuffer.WriteAt(2, 6, $"Возраст (текущий: {guest.Age}): ");
            ConsoleBuffer.PresentBuffer();
            string ageInput = ReadInputAt(34, 6);
            if (int.TryParse(ageInput, out int newAge))
                guest.Age = newAge;

            ShowMessage("Гость успешно обновлён.");
        }

        static void DeleteGuest()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Удаление гостя ====", (ushort)ConsoleColor.Red);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер гостя для удаления: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(43, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Guests.Count)
            {
                ShowMessage("Неверный номер гостя.");
                return;
            }

            Guest guest = DataStore.Guests[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Удалить гостя {guest.Name}? (y/n): ");
            ConsoleBuffer.PresentBuffer();
            string confirm = ReadInputAt(36, 5).Trim().ToLower();

            if (confirm == "y" || confirm == "д")
            {
                DataStore.Guests.RemoveAt(index - 1);
                ShowMessage("Гость удалён.");
            }
            else
            {
                ShowMessage("Удаление отменено.");
            }
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
                ConsoleBuffer.WriteAt(2, 2, "Список компонентов:");

                int line = 4;
                for (int i = 0; i < DataStore.Components.Count; i++)
                {
                    var c = DataStore.Components[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. Название: {c.Name}, Количество: {c.Quantity}, Единица: {c.Unit}");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить компонент");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Редактировать компонент");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Удалить компонент");
                ConsoleBuffer.WriteAt(2, (short)line++, "0. Назад");
                ConsoleBuffer.WriteAt(2, (short)line++, "Выберите действие: ");
                ConsoleBuffer.PresentBuffer();

                int key;
                do { key = ConsoleBuffer.ReadKeyCode(); } while (key == 0);

                switch (key)
                {
                    case '1': AddComponent(); break;
                    case '2': EditComponent(); break;
                    case '3': DeleteComponent(); break;
                    case '0': back = true; break;
                    default: ShowMessage("Неверный выбор."); break;
                }
            }
        }

        static void AddComponent()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Добавление компонента ====", (ushort)ConsoleColor.Green);

            Component component = new Component();

            ConsoleBuffer.WriteAt(2, 3, "Введите название компонента: ");
            ConsoleBuffer.PresentBuffer();
            component.Name = ReadInputAt(33, 3);

            ConsoleBuffer.WriteAt(2, 4, "Введите количество: ");
            ConsoleBuffer.PresentBuffer();
            int.TryParse(ReadInputAt(22, 4), out int quantity);
            component.Quantity = quantity;

            ConsoleBuffer.WriteAt(2, 5, "Введите единицу измерения (шт, кг и т.п.): ");
            ConsoleBuffer.PresentBuffer();
            component.Unit = ReadInputAt(43, 5);

            DataStore.Components.Add(component);
            ShowMessage("Компонент успешно добавлен.");
        }

        static void EditComponent()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Редактирование компонента ====", (ushort)ConsoleColor.Yellow);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер компонента для редактирования: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(49, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Components.Count)
            {
                ShowMessage("Неверный номер компонента.");
                return;
            }

            Component component = DataStore.Components[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Название (текущее: {component.Name}): ");
            ConsoleBuffer.PresentBuffer();
            string newName = ReadInputAt(35, 5);
            if (!string.IsNullOrWhiteSpace(newName))
                component.Name = newName;

            ConsoleBuffer.WriteAt(2, 6, $"Количество (текущее: {component.Quantity}): ");
            ConsoleBuffer.PresentBuffer();
            string qtyInput = ReadInputAt(39, 6);
            if (int.TryParse(qtyInput, out int newQty))
                component.Quantity = newQty;

            ConsoleBuffer.WriteAt(2, 7, $"Единица измерения (текущая: {component.Unit}): ");
            ConsoleBuffer.PresentBuffer();
            string newUnit = ReadInputAt(45, 7);
            if (!string.IsNullOrWhiteSpace(newUnit))
                component.Unit = newUnit;

            ShowMessage("Компонент успешно обновлён.");
        }

        static void DeleteComponent()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Удаление компонента ====", (ushort)ConsoleColor.Red);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер компонента для удаления: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(45, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Components.Count)
            {
                ShowMessage("Неверный номер компонента.");
                return;
            }

            Component component = DataStore.Components[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Удалить компонент {component.Name}? (y/n): ");
            ConsoleBuffer.PresentBuffer();
            string confirm = ReadInputAt(38, 5).Trim().ToLower();

            if (confirm == "y" || confirm == "д")
            {
                DataStore.Components.RemoveAt(index - 1);
                ShowMessage("Компонент удалён.");
            }
            else
            {
                ShowMessage("Удаление отменено.");
            }
        }        
        #endregion

        #region Буффет (Кухня)

        static void ManageKitchen()
        {
            bool back = false;
            while (!back)
            {
                ConsoleBuffer.Clear();
                ConsoleBuffer.WriteAt(2, 1, "==== Буфет ====", (ushort)ConsoleColor.Cyan);
                ConsoleBuffer.WriteAt(2, 2, "Меню:");

                int line = 4;
                for (int i = 0; i < DataStore.Dishes.Count; i++)
                {
                    var d = DataStore.Dishes[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. Название: {d.Name}, Цена: {d.Price}, Ингредиенты: {string.Join(", ", d.Ingredients.Select(c => c.Name))}");
                }

                line++;
                ConsoleBuffer.WriteAt(2, (short)line++, "1. Добавить блюдо");
                ConsoleBuffer.WriteAt(2, (short)line++, "2. Редактировать блюдо");
                ConsoleBuffer.WriteAt(2, (short)line++, "3. Удалить блюдо");
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

            ConsoleBuffer.WriteAt(2, 3, "Введите название блюда: ");
            ConsoleBuffer.PresentBuffer();
            dish.Name = ReadInputAt(27, 3);

            ConsoleBuffer.WriteAt(2, 4, "Введите цену блюда: ");
            ConsoleBuffer.PresentBuffer();
            double.TryParse(ReadInputAt(23, 4), out double price);
            dish.Price = price;

            dish.Ingredients = new List<Component>();

            if (DataStore.Components.Count == 0)
            {
                ShowMessage("Нет компонентов на складе. Добавьте их сначала.");
                return;
            }

            ConsoleBuffer.WriteAt(2, 6, "Введите номера ингредиентов через запятую (напр. 1,3,5): ");
            int line = 8;
            for (int i = 0; i < DataStore.Components.Count; i++)
            {
                var c = DataStore.Components[i];
                ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. {c.Name}");
            }

            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(53, 6);
            var parts = input.Split(',');

            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int idx) &&
                    idx > 0 && idx <= DataStore.Components.Count)
                {
                    dish.Ingredients.Add(DataStore.Components[idx - 1]);
                }
            }

            DataStore.Dishes.Add(dish);
            ShowMessage("Блюдо успешно добавлено.");
        }

        static void EditDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Редактирование блюда ====", (ushort)ConsoleColor.Yellow);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер блюда для редактирования: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(45, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Dishes.Count)
            {
                ShowMessage("Неверный номер блюда.");
                return;
            }

            Dish dish = DataStore.Dishes[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Название (текущее: {dish.Name}): ");
            ConsoleBuffer.PresentBuffer();
            string newName = ReadInputAt(32, 5);
            if (!string.IsNullOrWhiteSpace(newName))
                dish.Name = newName;

            ConsoleBuffer.WriteAt(2, 6, $"Цена (текущая: {dish.Price}): ");
            ConsoleBuffer.PresentBuffer();
            string priceInput = ReadInputAt(27, 6);
            if (double.TryParse(priceInput, out double newPrice))
                dish.Price = newPrice;

            ConsoleBuffer.WriteAt(2, 7, "Обновить ингредиенты? (y/n): ");
            ConsoleBuffer.PresentBuffer();
            string confirm = ReadInputAt(31, 7).Trim().ToLower();

            if (confirm == "y" || confirm == "д")
            {
                dish.Ingredients.Clear();

                int line = 9;
                for (int i = 0; i < DataStore.Components.Count; i++)
                {
                    var c = DataStore.Components[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. {c.Name}");
                }

                ConsoleBuffer.WriteAt(2, (short)(line + 1), "Введите номера ингредиентов через запятую: ");
                ConsoleBuffer.PresentBuffer();
                string ingrInput = ReadInputAt(50, line + 1);
                var parts = ingrInput.Split(',');

                foreach (var part in parts)
                {
                    if (int.TryParse(part.Trim(), out int idx) &&
                        idx > 0 && idx <= DataStore.Components.Count)
                    {
                        dish.Ingredients.Add(DataStore.Components[idx - 1]);
                    }
                }
            }

            ShowMessage("Блюдо обновлено.");
        }

        static void DeleteDish()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Удаление блюда ====", (ushort)ConsoleColor.Red);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер блюда для удаления: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(42, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Dishes.Count)
            {
                ShowMessage("Неверный номер блюда.");
                return;
            }

            Dish dish = DataStore.Dishes[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Удалить блюдо {dish.Name}? (y/n): ");
            ConsoleBuffer.PresentBuffer();
            string confirm = ReadInputAt(34, 5).Trim().ToLower();

            if (confirm == "y" || confirm == "д")
            {
                DataStore.Dishes.RemoveAt(index - 1);
                ShowMessage("Блюдо удалено.");
            }
            else
            {
                ShowMessage("Удаление отменено.");
            }
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

        static string ReadInputAt(int x, int y)
        {
            ConsoleBuffer.Dispose();
            Console.SetCursorPosition(x, y);
            string input = Console.ReadLine();
            ConsoleBuffer.Init();
            return input;
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
            bool.TryParse(ReadInputAt(29, 5), out bool isVip);
            client.IsVIP = isVip;

            client.RegistrationDate = DateTime.Now;

            ConsoleBuffer.WriteAt(2, 6, "Наличие членской карты (true/false): ");
            ConsoleBuffer.PresentBuffer();
            bool.TryParse(ReadInputAt(39, 6), out bool hasCard);
            client.HasMembershipCard = hasCard;

            ConsoleBuffer.WriteAt(2, 7, "Скидка (в процентах): ");
            ConsoleBuffer.PresentBuffer();
            int.TryParse(ReadInputAt(26, 7), out int discount);
            client.Discount = discount;

            client.AccumulatedBonus = 0;

            DataStore.Clients.Add(client);

            ShowMessage("Клиент успешно добавлен!");
        }

        static void EditClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Редактирование клиента ====", (ushort)ConsoleColor.Yellow);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер клиента для редактирования: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(44, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Clients.Count)
            {
                ShowMessage("Неверный номер клиента.");
                return;
            }

            Client client = DataStore.Clients[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Текущее имя: {client.Name}. Новое имя (Enter — оставить): ");
            ConsoleBuffer.PresentBuffer();
            string newName = ReadInputAt(52, 5);
            if (!string.IsNullOrWhiteSpace(newName))
                client.Name = newName;

            ConsoleBuffer.WriteAt(2, 6, $"Текущий телефон: {client.PhoneNumber}. Новый (Enter — оставить): ");
            ConsoleBuffer.PresentBuffer();
            string newPhone = ReadInputAt(60, 6);
            if (!string.IsNullOrWhiteSpace(newPhone))
                client.PhoneNumber = newPhone;

            ConsoleBuffer.WriteAt(2, 7, $"VIP (текущий: {client.IsVIP}). Новый (true/false): ");
            ConsoleBuffer.PresentBuffer();
            string vipInput = ReadInputAt(49, 7);
            if (bool.TryParse(vipInput, out bool newVip))
                client.IsVIP = newVip;

            ConsoleBuffer.WriteAt(2, 8, $"Карта (текущая: {client.HasMembershipCard}). Новая (true/false): ");
            ConsoleBuffer.PresentBuffer();
            string cardInput = ReadInputAt(55, 8);
            if (bool.TryParse(cardInput, out bool newCard))
                client.HasMembershipCard = newCard;

            ConsoleBuffer.WriteAt(2, 9, $"Скидка (текущая: {client.Discount}): ");
            ConsoleBuffer.PresentBuffer();
            string discountInput = ReadInputAt(39, 9);
            if (int.TryParse(discountInput, out int newDiscount))
                client.Discount = newDiscount;

            ShowMessage("Данные клиента обновлены.");
        }

        static void DeleteClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Удаление клиента ====", (ushort)ConsoleColor.Red);

            ConsoleBuffer.WriteAt(2, 3, "Введите номер клиента для удаления: ");
            ConsoleBuffer.PresentBuffer();
            string input = ReadInputAt(42, 3);

            if (!int.TryParse(input, out int index) || index < 1 || index > DataStore.Clients.Count)
            {
                ShowMessage("Неверный номер клиента.");
                return;
            }

            Client client = DataStore.Clients[index - 1];

            ConsoleBuffer.WriteAt(2, 5, $"Вы уверены, что хотите удалить клиента {client.Name}? (y/n): ");
            ConsoleBuffer.PresentBuffer();
            string confirm = ReadInputAt(63, 5).Trim().ToLower();

            if (confirm == "y" || confirm == "д")
            {
                DataStore.Clients.RemoveAt(index - 1);
                ShowMessage("Клиент удалён.");
            }
            else
            {
                ShowMessage("Удаление отменено.");
            }
        }

        static void SearchClient()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Поиск клиентов ====", (ushort)ConsoleColor.Cyan);

            ConsoleBuffer.WriteAt(2, 3, "Введите часть имени для поиска: ");
            ConsoleBuffer.PresentBuffer();
            string query = ReadInputAt(37, 3).Trim().ToLower();

            var results = DataStore.Clients
                .Where(c => c.Name != null && c.Name.ToLower().Contains(query))
                .ToList();

            ConsoleBuffer.Clear();
            if (results.Count == 0)
            {
                ConsoleBuffer.WriteAt(2, 2, "Клиенты не найдены.");
            }
            else
            {
                ConsoleBuffer.WriteAt(2, 1, "Найденные клиенты:", (ushort)ConsoleColor.Green);
                int line = 3;
                for (int i = 0; i < results.Count; i++)
                {
                    var c = results[i];
                    ConsoleBuffer.WriteAt(2, (short)line++, $"{i + 1}. Имя: {c.Name}, Телефон: {c.PhoneNumber}, VIP: {c.IsVIP}, Бонусы: {c.AccumulatedBonus}, Дата регистрации: {c.RegistrationDate.ToShortDateString()}, Карта: {c.HasMembershipCard}, Скидка: {c.Discount}%");
                }
            }

            ConsoleBuffer.PresentBuffer();
            while (ConsoleBuffer.ReadKeyCode() == 0) { }
        }

        #endregion

        #region Отчеты

        static void ShowReports()
        {
            ConsoleBuffer.Clear();
            ConsoleBuffer.WriteAt(2, 1, "==== Отчёты ====", (ushort)ConsoleColor.Cyan);

            int line = 3;

            ConsoleBuffer.WriteAt(2, (short)line++, $"Гостей в зале: {DataStore.Guests.Count} из {DataStore.TotalSeats}");
            ConsoleBuffer.WriteAt(2, (short)line++, $"Всего клиентов: {DataStore.Clients.Count}");
            ConsoleBuffer.WriteAt(2, (short)line++, $"Доступных блюд: {DataStore.Dishes.Count}");
            ConsoleBuffer.WriteAt(2, (short)line++, $"Компонентов на складе: {DataStore.Components.Count}");

            // Подсчёт заказов (если реализованы)
            if (DataStore.Orders != null && DataStore.Orders.Count > 0)
            {
                int totalOrders = DataStore.Orders.Count;
                double totalRevenue = DataStore.Orders.Sum(o => o.TotalCost);
                ConsoleBuffer.WriteAt(2, (short)line++, $"Всего заказов: {totalOrders}");
                ConsoleBuffer.WriteAt(2, (short)line++, $"Общая выручка: {totalRevenue} руб.");
            }

            ConsoleBuffer.WriteAt(2, (short)(line + 1), "Нажмите любую клавишу для возврата...");
            ConsoleBuffer.PresentBuffer();

            while (ConsoleBuffer.ReadKeyCode() == 0) { }
        }        
        #endregion
    }
}
#endregion
