using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Comp_Club
{
    public partial class AddClients : Window
    {
        // Инициализирует окно добавления клиента
        public AddClients()
        {
            InitializeComponent(); // инициализация компонентов
        }

        // Обработчик кнопки "Добавить": собирает данные и сохраняет клиента в БД
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // считываем и обрезаем ввод
            string name = NameTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string discountText = DiscountTextBox.Text.Trim();
            string vipLevel = VIPLevelTextBox.Text.Trim();

            // проверяем обязательное поле
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите имя клиента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // проверяем формат скидки
            if (!decimal.TryParse(discountText, out decimal discount))
            {
                MessageBox.Show("Введите корректную скидку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["ComputerClubDB"].ConnectionString;
            string query = "INSERT INTO Clients (Name, Phone, Email, Discount, VIP_Level) VALUES (@Name, @Phone, @Email, @Discount, @VIP_Level)";

            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@VIP_Level", string.IsNullOrEmpty(vipLevel) ? (object)DBNull.Value : vipLevel);

                    conn.Open(); // открыть соединение
                    cmd.ExecuteNonQuery(); // выполнить запрос
                }

                MessageBox.Show("Клиент добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Обработчик кнопки "Отмена": закрывает окно без сохранения
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close(); 
        }
    }
}
