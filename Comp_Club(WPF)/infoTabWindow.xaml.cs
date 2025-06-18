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

        // Конструктор: задаёт контекст зала и таблицы, загружает текущее состояние аренды
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

        #region Клиенты

        // Заполняет выпадающий список клиентов из базы и добавляет пункт незарегистрированного
        private void LoadClients()
        {
            var clients = new List<Client>
            {
                new Client { ClientID = -1, Name = "Незарегистрированный пользователь" }
            };

            var dbClients = Entities.Instance.Clients
                .AsEnumerable()
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

        // Переключает видимость поля имени для незарегистрированного клиента
        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is Client selectedClient)
            {
                if (selectedClient.ClientID == -1)
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

        #region Логика аренды и логирования

        // Закрывает просроченные аренды из логов предыдущих дней
        private void CloseExpiredRentalsForPreviousDays()
        {
            string baseDir = Path.Combine("Logs", tableName);
            if (!Directory.Exists(baseDir)) return;

            var oldFiles = Directory.GetFiles(baseDir, "*.log")
                .Where(f => !f.Contains(DateTime.Today.ToString("yyyy-MM-dd")));

            foreach (var file in oldFiles)
                CloseExpiredRentalsInFile(file);
        }

        // Закрывает просроченные аренды из сегодняшнего лога
        private void CloseExpiredRentals()
        {
            string logPath = Path.Combine("Logs", tableName, logFileName);
            CloseExpiredRentalsInFile(logPath);
        }

        // Переводит статус активных аренды в "Закрыта" при просрочке
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
                    int statusIdx = -1, endIdx = -1;
                    for (int j = i + 1; j < lines.Count && !lines[j].StartsWith("==="); j++)
                    {
                        if (lines[j].StartsWith("Статус:")) statusIdx = j;
                        if (lines[j].StartsWith("Окончание:")) endIdx = j;
                    }
                    if (statusIdx != -1 && endIdx != -1)
                    {
                        var endTimeStr = lines[endIdx].Substring("Окончание:".Length).Trim();
                        if (DateTime.TryParseExact(endTimeStr, "HH:mm", null,
                            System.Globalization.DateTimeStyles.None, out DateTime endTime))
                        {
                            var fullEnd = new DateTime(logDate.Year, logDate.Month,
                                logDate.Day, endTime.Hour, endTime.Minute, 0);
                            if (lines[statusIdx].Contains("Активна") && DateTime.Now > fullEnd)
                            {
                                lines[statusIdx] = "Статус: Закрыта";
                                updated = true;
                            }
                        }
                    }
                }
            }
            if (updated)
                File.WriteAllLines(logPath, lines);
        }

        // Загружает счётчик для незарегистрированных клиентов из лога
        private void LoadnoRegClientId()
        {
            string logPath = Path.Combine("Logs", tableName, logFileName);
            if (!File.Exists(logPath)) { noRegClientId = -1; return; }

            var lines = File.ReadAllLines(logPath);
            var counterLine = lines.FirstOrDefault(l => l.StartsWith("#client_counter:"));
            if (counterLine != null)
            {
                var parts = counterLine.Substring("#client_counter:".Length).Split(':');
                if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime date)
                    && int.TryParse(parts[1], out int cnt) && date == DateTime.Today)
                {
                    noRegClientId = cnt;
                    return;
                }
            }
            noRegClientId = -1;
            UpdatenoRegClientIdInLog(lines.ToList(), logPath);
        }

        // Обновляет счётчик незарегистрированных клиентов в логе
        private void UpdatenoRegClientIdInLog(List<string> lines, string logPath)
        {
            string newCounter = $"#client_counter:{DateTime.Today:yyyy-MM-dd}:{++clientCounter}";
            int idx = lines.FindIndex(l => l.StartsWith("#client_counter:"));
            if (idx != -1) lines[idx] = newCounter;
            else lines.Insert(0, newCounter);

            Directory.CreateDirectory(Path.GetDirectoryName(logPath));
            File.WriteAllLines(logPath, lines);
        }

        // Загружает и отображает последнюю активную аренду
        private void LoadActiveRental()
        {
            string logPath = Path.Combine("Logs", tableName, logFileName);
            if (!File.Exists(logPath)) { ClearRentalUI(); return; }

            var lines = File.ReadAllLines(logPath);
            List<string> current = null, lastClosed = null, nextActive = null;
            bool afterClosed = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith("=== АРЕНДА")) current = new List<string> { line };
                else if (current != null)
                {
                    if (line.StartsWith("==="))
                    {
                        if (current.Any(l => l.Contains("Закрыта"))) { lastClosed = new List<string>(current); afterClosed = true; nextActive = null; }
                        else if (afterClosed && current.Any(l => l.Contains("Активна"))) nextActive = new List<string>(current);
                        current = new List<string> { line };
                    }
                    else current.Add(line);
                }
            }
            if (current != null && current.Count > 0)
            {
                if (current.Any(l => l.Contains("Закрыта"))) { lastClosed = new List<string>(current); nextActive = null; }
                else if (afterClosed && current.Any(l => l.Contains("Активна"))) nextActive = new List<string>(current);
            }
            if (nextActive != null) ProcessEntry(nextActive); else ClearRentalUI();
        }

        // Разбирает запись лога и заполняет UI
        private bool ProcessEntry(List<string> entry)
        {
            try
            {
                int clientId = int.Parse(entry.FirstOrDefault(l => l.StartsWith("Клиент ID:"))
                    .Split(':')[1].Trim());
                noRegClient = entry.FirstOrDefault(l => l.StartsWith("Имя:"))
                    .Split(':')[1].Trim();

                priceRent = double.Parse(entry.FirstOrDefault(l => l.StartsWith("Стоимость:"))
                    .Split(':')[1].Trim());
                var times = entry.Where(l => l.StartsWith("Начало:") || l.StartsWith("Окончание:")).ToList();
                var today = DateTime.Today;
                rentalStart = DateTime.Parse($"{today:yyyy-MM-dd} {times[0].Split(':')[1].Trim()}");
                rentalEnd = DateTime.Parse($"{today:yyyy-MM-dd} {times[1].Split(':')[1].Trim()}");

                ClientIdTextBlock.Text = clientId.ToString();
                if (clientId < 0)
                {
                    ClientComboBox.SelectedValue = -1;
                    UnregisteredNamePanel.Visibility = Visibility.Visible;
                    UnregisteredClientNameTextBox.Text = noRegClient;
                }
                else ClientComboBox.SelectedValue = clientId;

                ShowRentalInfo();
                RentButton.IsEnabled = false;
                ExtendButton.IsEnabled = true;
                CloseRentButton.IsEnabled = true;
                ClientComboBox.IsEnabled = false;
                UnregisteredClientNameTextBox.IsEnabled = false;

                return true;
            }
            catch { return false; }
        }

        // Запись аренды: открытие или закрытие
        private void LogRental(bool isClosing = false)
        {
            if (!rentalStart.HasValue || !rentalEnd.HasValue) return;

            var dir = Path.Combine("Logs", tableName);
            Directory.CreateDirectory(dir);
            var logPath = Path.Combine(dir, logFileName);

            string clientId = ClientIdTextBlock.Text;
            string entry = $"=== АРЕНДА ===\n" +
                           $"Клиент ID: {clientId}\n" +
                           $"Имя: {noRegClient}\n" +
                           $"Зал: {hallName}\n" +
                           $"Стоимость: {priceRent}\n" +
                           $"Начало: {rentalStart.Value:HH:mm}\n" +
                           $"Окончание: {rentalEnd.Value:HH:mm}\n" +
                           (isClosing ? "Статус: Закрыта\n" : "Статус: Активна\n") +
                           new string('-', 30) + "\n";

            var lines = File.Exists(logPath) ? File.ReadAllLines(logPath).ToList() : new List<string>();
            int startIdx = lines.FindIndex(l => l.StartsWith("=== АРЕНДА ===") &&
                lines.SkipWhile(x => x != l).Skip(1).TakeWhile(x => !x.StartsWith("===")).Any(x => x.Contains($"Клиент ID: {clientId}")));
            if (startIdx != -1)
            {
                int endIdx = startIdx + 1;
                while (endIdx < lines.Count && !lines[endIdx].StartsWith("===")) endIdx++;
                lines.RemoveRange(startIdx, endIdx - startIdx);
                lines.InsertRange(startIdx, entry.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)));
            }
            else lines.AddRange(entry.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)));

            UpdatenoRegClientIdInLog(lines, logPath);
            File.WriteAllLines(logPath, lines);
        }

        // Рассчитывает цену аренды, учитывая предыдущие расчёты
        private void priceCalculate(double hours) => priceRent = priceRent == 0
            ? priceReturn(tableID, hours)
            : priceRent + priceReturn(tableID, hours);

        // Возвращает стоимость за дополнительные часы в зависимости от типа столика
        private double priceReturn(int id, double hours)
        {
            if (id < 28) return bet * hours * betPK;
            if (id <= 36) return bet * hours * betCon;
            if (id <= 47) return bet * hours * betPK * betVip;
            return bet * hours * betCon * betVip;
        }

        #endregion

        #region Работа с UI (аренда)

        private void ShowRentalInfo()
        {
            StartTimeTextBlock.Text = rentalStart?.ToString("HH:mm") ?? "";
            EndTimeTextBlock.Text = rentalEnd?.ToString("HH:mm") ?? "";
            RentalDurationTextBlock.Text = (rentalStart.HasValue && rentalEnd.HasValue)
                ? (rentalEnd.Value - rentalStart.Value).TotalHours.ToString("F1") : "";
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

        // Обрабатывает начало новой аренды
        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is not Client sel) { MessageBox.Show("Выберите клиента."); return; }
            string clientName = sel.ClientID == -1
                ? UnregisteredClientNameTextBox.Text.Trim()
                : sel.Name;
            if (sel.ClientID == -1 && string.IsNullOrWhiteSpace(clientName))
            { MessageBox.Show("Введите имя незарегистрированного клиента."); return; }

            rentalStart = DateTime.Now;
            double hours = RentalHoursComboBox.SelectedIndex == 0 ? 0.5 : RentalHoursComboBox.SelectedIndex;
            rentalEnd = rentalStart.Value.AddHours(hours);

            if (sel.ClientID == -1) noRegClientId--;
            noRegClient = clientName;
            priceCalculate(hours);

            ShowRentalInfo();
            LogRental();

            RentButton.IsEnabled = false;
            ExtendButton.IsEnabled = true;
            CloseRentButton.IsEnabled = true;
            ClientComboBox.IsEnabled = false;
            UnregisteredClientNameTextBox.IsEnabled = false;
        }

        private void ExtendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!rentalEnd.HasValue) return;
            double addH = RentalHoursComboBox.SelectedIndex == 0 ? 0.5 : RentalHoursComboBox.SelectedIndex;
            rentalEnd = rentalEnd.Value.AddHours(addH);
            priceCalculate(addH);
            ShowRentalInfo();
            LogRental();
        }

        private void CloseRentButton_Click(object sender, RoutedEventArgs e)
        {
            LogRental(true);
            ClearRentalUI();
        }

    }
}
#endregion
