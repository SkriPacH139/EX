using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;


namespace Comp_Club
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        public AddClients()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string discountText = DiscountTextBox.Text.Trim();
            string vipLevel = VIPLevelTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите имя клиента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(discountText, out decimal discount))
            {
                MessageBox.Show("Введите корректное число для скидки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ComputerClubDB"].ConnectionString;
            string query = "INSERT INTO Clients (Name, Phone, Email, Discount, VIP_Level) VALUES (@Name, @Phone, @Email, @Discount, @VIP_Level)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@VIP_Level", string.IsNullOrEmpty(vipLevel) ? (object)DBNull.Value : vipLevel);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Клиент успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }        
    }
}
