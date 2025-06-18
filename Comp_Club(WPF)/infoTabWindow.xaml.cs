using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Comp_Club
{
    public partial class infoTabWindow : Window
    {
        #region Поля и переменные

        private DateTime? rentalStart;
        private DateTime? rentalEnd;

        private double priceRent = 0;
        private double bet = 180;
        private double betPK = 1.8;
        private double betVip = 3.5;
        private double betCon = 1.5;

        private int tableID;
        private int noRegClientId = -1;
        private int clientCounter = 0;
        private string noRegClient = " ";

        private string logFileName;
        private string hallName;
        private string tableName;
        #endregion


        #region Конструктор

        public infoTabWindow(string table, string hall, int ID)
        {
            InitializeComponent();

            hallName = hall;
            tableName = table;
            logFileName = DateTime.Today.ToString("yyyy-MM-dd") + ".log";
            tableID = ID;

            RoomNameTextBlock.Text = hallName;

            CloseExpiredRentalsForPreviousDays();
            CloseExpiredRentals();
            LoadnoRegClientId();
            LoadActiveRental();
            LoadClients();
        }
        #endregion


        #region Клиенты

        private void LoadClients()
        {
            

            var clients = new List<Client>
            {
                new Client
                {
                    ClientID = -1,
                    Name = "Незарегистрированный пользователь"
                }
            };

            // Загружаем EF-объекты в память, затем проецируем в нужный класс
            var dbClients = Entities.Instance.Clients
                .AsEnumerable() // переводит запрос в память
                .Select(c => new Client
                {
                    ClientID = c.ClientID,
                    Name = c.Name,
                    Phone = c.Phone,
                    Email = c.Email,
                    Discount = c.Discount,
                    VIP_Level = c.VIP_Level
                });

            clients.AddRange(dbClients);

            ClientComboBox.ItemsSource = clients;
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is Client selectedClient)
            {
                if (selectedClient.ClientID == -1)  // незарегистрированный
                {
                    UnregisteredNamePanel.Visibility = Visibility.Visible;
                    ClientIdTextBlock.Text = noRegClientId.ToString();

                }
                else
                {
                    UnregisteredNamePanel.Visibility = Visibility.Collapsed;
                    UnregisteredClientNameTextBox.Text = string.Empty;
                    ClientIdTextBlock.Text = selectedClient.ClientID.ToString();
                }
            }
        }

        #endregion    

        #region Работа с логами и арендой

        private void CloseExpiredRentalsForPreviousDays()
        {
            string baseDir = Path.Combine("Logs", tableName);
            if (!Directory.Exists(baseDir)) return;

            var oldFiles = Directory.GetFiles(baseDir, "*.log")
                .Where(f => !f.Contains(DateTime.Today.ToString("yyyy-MM-dd")));

            foreach (var file in oldFiles)
                CloseExpiredRentalsInFile(file);
        }

        private void CloseExpiredRentals()
        {
            string logPath = Path.Combine("Logs", tableName, logFileName);
            CloseExpiredRentalsInFile(logPath);
        }

        private void CloseExpiredRentalsInFile(string logPath)
        {
            if (!File.Exists(logPath)) return;

            var lines = File.ReadAllLines(logPath).ToList();
            DateTime logDate = DateTime.Today;

            if (lines.Count > 0 && lines[0].StartsWith("#client_counter:"))
            {
                var parts = lines[0].Split(':');
                if (parts.Length >= 3 && DateTime.TryParse(parts[1], out DateTime parsedDate))
                    logDate = parsedDate;
            }

            bool updated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("=== АРЕНДА"))
                {
                    int statusIndex = -1, endTimeIndex = -1;

                    for (int j = i + 1; j < lines.Count && !lines[j].StartsWith("==="); j++)
                    {
                        if (lines[j].StartsWith("Статус:")) statusIndex = j;
                        if (lines[j].StartsWith("Окончание:")) endTimeIndex = j;
                    }

                    if (statusIndex != -1 && endTimeIndex != -1)
                    {
                        string status = lines[statusIndex].Substring("Статус:".Length).Trim();
                        string endTimeStr = lines[endTimeIndex].Substring("Окончание:".Length).Trim();

                        if (DateTime.TryParseExact(endTimeStr, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime endTime))
                        {
                            var fullEndTime = new DateTime(logDate.Year, logDate.Month, logDate.Day, endTime.Hour, endTime.Minute, 0);

                            if (status == "Активна" && DateTime.Now > fullEndTime)
                            {
                                lines[statusIndex] = "Статус: Закрыта";
                                updated = true;
                            }
                        }
                    }
                }
            }

            if (updated)
                File.WriteAllLines(logPath, lines);
        }

        private void LoadnoRegClientId()
        {
            string logPath = Path.Combine("Logs", tableName, logFileName);

            if (!File.Exists(logPath))
            {
                noRegClientId = -1;
                return;
            }

            var lines = File.ReadAllLines(logPath);
            string counterLine = lines.FirstOrDefault(l => l.StartsWith("#client_counter:"));

            if (counterLine != null)
            {
                var parts = counterLine.Substring("#client_counter:".Length).Split(':');
                if (parts.Length == 2 &&
                    DateTime.TryParse(parts[0], out DateTime date) &&
                    int.TryParse(parts[1], out int counter) &&
                    date == DateTime.Today)
                {
                    noRegClientId = counter;
                    return;
                }
            }

            noRegClientId = -1;
            UpdatenoRegClientIdInLog(lines.ToList(), logPath);
        }

        private void UpdatenoRegClientIdInLog(List<string> lines, string logPath)
        {
            string newCounter = " ";

            if (noRegClient != " ")            
                 newCounter = $"#client_counter:{DateTime.Today:yyyy-MM-dd}:{++clientCounter}";
            else
                newCounter = $"#client_counter:{DateTime.Today:yyyy-MM-dd}:{++clientCounter}";



            int idx = lines.FindIndex(l => l.StartsWith("#client_counter:"));

            if (idx != -1)
                lines[idx] = newCounter;
            else
                lines.Insert(0, newCounter);

            Directory.CreateDirectory(Path.GetDirectoryName(logPath));
            File.WriteAllLines(logPath, lines);
        }

        private void LoadActiveRental()
        {
            string logPath = Path.Combine("Logs", tableName, logFileName);
            if (!File.Exists(logPath))
            {
                ClearRentalUI();
                return;
            }

            var lines = File.ReadAllLines(logPath);
            List<string> currentEntry = null;
            List<string> lastClosedEntry = null;
            List<string> lastActiveEntryAfterClosed = null;
            bool afterLastClosed = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.StartsWith("=== АРЕНДА"))
                    currentEntry = new List<string> { line };
                else if (currentEntry != null)
                {
                    if (line.StartsWith("==="))
                    {
                        if (currentEntry.Any(l => l.StartsWith("Статус: Закрыта")))
                        {
                            lastClosedEntry = new List<string>(currentEntry);
                            afterLastClosed = true;
                            lastActiveEntryAfterClosed = null;
                        }
                        else if (currentEntry.Any(l => l.StartsWith("Статус: Активна")) && afterLastClosed)
                        {
                            lastActiveEntryAfterClosed = new List<string>(currentEntry);
                        }
                        currentEntry = new List<string> { line };
                    }
                    else
                    {
                        currentEntry.Add(line);
                    }
                }
            }

            if (currentEntry != null && currentEntry.Count > 0)
            {
                afterLastClosed = true;
                if (currentEntry.Any(l => l.StartsWith("Статус: Закрыта")))
                {
                    lastClosedEntry = new List<string>(currentEntry);
                    lastActiveEntryAfterClosed = null;
                }
                else if (currentEntry.Any(l => l.StartsWith("Статус: Активна")) && afterLastClosed)
                {
                    lastActiveEntryAfterClosed = new List<string>(currentEntry);
                }
            }

            if (lastActiveEntryAfterClosed != null)
            {
                if (!ProcessEntry(lastActiveEntryAfterClosed))
                    ClearRentalUI();
            }
            else
            {
                ClearRentalUI();
            }
        }

        private bool ProcessEntry(List<string> entry)
        {
            try
            {
                int clientIdStr = int.Parse(entry.FirstOrDefault(l => l.StartsWith("Клиент ID:"))?.Split(new[] { ':' }, 2)[1].Trim());
                noRegClient = entry.FirstOrDefault(l => l.StartsWith("Имя:"))?.Split(new[] { ':' }, 2)[1].Trim();
                string room = entry.FirstOrDefault(l => l.StartsWith("Зал:"))?.Split(new[] { ':' }, 2)[1].Trim();
                priceRent = double.Parse(entry.FirstOrDefault(l => l.StartsWith("Стоимость:"))?.Split(new[] { ':' }, 2)[1].Trim());
                string start = entry.FirstOrDefault(l => l.StartsWith("Начало:"))?.Split(new[] { ':' }, 2)[1].Trim();
                string end = entry.FirstOrDefault(l => l.StartsWith("Окончание:"))?.Split(new[] { ':' }, 2)[1].Trim();
                

                if (string.IsNullOrEmpty(room) || string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
                    return false;

                RoomNameTextBlock.Text = room;
                ClientIdTextBlock.Text = clientIdStr.ToString();
                priceTextBlock.Text = priceRent.ToString();

                if (clientIdStr < 0)
                {
                    ClientComboBox.SelectedValue = -1;
                    UnregisteredNamePanel.Visibility = Visibility.Visible;
                    UnregisteredClientNameTextBox.Text = noRegClient;
                }
                else
                    ClientComboBox.SelectedValue = clientIdStr;


                DateTime today = DateTime.Today;
                rentalStart = DateTime.Parse($"{today:yyyy-MM-dd} {start}");
                rentalEnd = DateTime.Parse($"{today:yyyy-MM-dd} {end}");


                ShowRentalInfo();

                RentButton.IsEnabled = false;
                ExtendButton.IsEnabled = true;
                CloseRentButton.IsEnabled = true;
                ClientComboBox.IsEnabled = false;
                UnregisteredClientNameTextBox.IsEnabled = false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void LogRental(bool isClosing = false)
        {
            if (!rentalStart.HasValue || !rentalEnd.HasValue) return;

            string dir = Path.Combine("Logs", tableName);
            Directory.CreateDirectory(dir);

            string logPath = Path.Combine(dir, logFileName);

            string clientId = ClientIdTextBlock.Text;
            string room = hallName;

            string entry = $"=== АРЕНДА ===\n" +
                           $"Клиент ID: {clientId}\n" +
                           $"Имя: {noRegClient}\n" +
                           $"Зал: {room}\n" +
                           $"Стоимость: {priceRent}\n" +
                           $"Начало: {rentalStart.Value:HH:mm}\n" +
                           $"Окончание: {rentalEnd.Value:HH:mm}\n" +
                           (isClosing ? "Статус: Закрыта\n" : "Статус: Активна\n") +
                           new string('-', 30) + "\n";

            var lines = File.Exists(logPath) ? File.ReadAllLines(logPath).ToList() : new List<string>();

            int startIndex = -1;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith("=== АРЕНДА ==="))
                {
                    bool matchClient = false, matchHall = false;

                    for (int j = i + 1; j < lines.Count && !lines[j].StartsWith("==="); j++)
                    {
                        if (lines[j].StartsWith("Клиент ID: " + clientId)) matchClient = true;
                        if (lines[j].StartsWith("Зал: " + room)) matchHall = true;
                    }

                    if (matchClient && matchHall)
                    {
                        startIndex = i;
                        break;
                    }
                }
            }

            if (startIndex != -1)
            {
                int endIndex = startIndex + 1;
                while (endIndex < lines.Count && !lines[endIndex].StartsWith("==="))
                    endIndex++;

                lines.RemoveRange(startIndex, endIndex - startIndex);
                lines.InsertRange(startIndex, entry.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)));
            }
            else
            {
                lines.AddRange(entry.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)));
            }

            UpdatenoRegClientIdInLog(lines, logPath);
            File.WriteAllLines(logPath, lines);
        }

        private void priceCalculate(double hours) => priceRent = priceRent == 0 ? priceReturn(tableID, hours) : priceRent += priceReturn(tableID, hours);      
        
        private double priceReturn(int id, double hours)
        {
            if (id < 28)
                return priceRent = bet * hours * betPK;

            else if (id > 28 && id <= 36)
                return priceRent = bet * hours * betCon;

            else if (id > 36 && id <= 47)
                return priceRent = bet * hours * betPK * betVip;

            else
                return priceRent = bet * hours * betCon * betVip;
        }
        #endregion


        #region Работа с UI (аренда, кнопки)

        private void ShowRentalInfo()
        {
            StartTimeTextBlock.Text = rentalStart?.ToString("HH:mm") ?? "";
            EndTimeTextBlock.Text = rentalEnd?.ToString("HH:mm") ?? "";
            RentalDurationTextBlock.Text = (rentalStart.HasValue && rentalEnd.HasValue) ?
                (rentalEnd.Value - rentalStart.Value).TotalHours.ToString("F1") : "";
            priceTextBlock.Text = priceRent.ToString();
            RoomNameTextBlock.Text = hallName;
        }

        private void ClearRentalUI()
        {
            RoomNameTextBlock.Text = hallName;
            ClientIdTextBlock.Text = "";
            StartTimeTextBlock.Text = "";
            EndTimeTextBlock.Text = "";
            RentalDurationTextBlock.Text = "";
            noRegClient = " ";
            priceTextBlock.Text = "";

            RentButton.IsEnabled = true;
            ExtendButton.IsEnabled = false;
            CloseRentButton.IsEnabled = false;
            ClientComboBox.IsEnabled = true;
            UnregisteredClientNameTextBox.IsEnabled = true;

            rentalStart = null;
            rentalEnd = null;
        }        

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is not Client selectedClient)
            {
                MessageBox.Show("Выберите клиента.");
                return;
            }

            string clientName;
            if (selectedClient.ClientID == -1)
            {
                clientName = UnregisteredClientNameTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(clientName))
                {
                    MessageBox.Show("Введите имя незарегистрированного клиента.");
                    return;
                }
            }
            else
            {
                clientName = selectedClient.Name;
            }

            string clientId = selectedClient.ClientID == -1 ? noRegClientId.ToString() : selectedClient.ClientID.ToString();

            double hours = RentalHoursComboBox.SelectedIndex == 0 ? 0.5 : RentalHoursComboBox.SelectedIndex;

            rentalStart = DateTime.Now;
            rentalEnd = rentalStart.Value.AddHours(hours);

            
            ClientIdTextBlock.Text = clientId;           
            

            RentButton.IsEnabled = false;
            ExtendButton.IsEnabled = true;
            CloseRentButton.IsEnabled = true;
            ClientComboBox.IsEnabled = false;
            UnregisteredClientNameTextBox.IsEnabled = false;

            if (selectedClient.ClientID == -1)
                noRegClientId--;  // уменьшаем счетчик для следующих незарегистрированных

            noRegClient = clientName;

            priceCalculate(hours);
            ShowRentalInfo();
            LogRental();    
        }

        private void ExtendButton_Click(object sender, RoutedEventArgs e)
        {
            double addHours = RentalHoursComboBox.SelectedIndex == 0 ? 0.5 : RentalHoursComboBox.SelectedIndex;
            if (rentalEnd.HasValue)
            {
                rentalEnd = rentalEnd.Value.AddHours(addHours);
                priceCalculate(addHours);
                ShowRentalInfo();
                LogRental();                
            }
        }

        private void CloseRentButton_Click(object sender, RoutedEventArgs e)
        {
            LogRental(true);           
            ClearRentalUI();
            
        }
        #endregion
    }
}
