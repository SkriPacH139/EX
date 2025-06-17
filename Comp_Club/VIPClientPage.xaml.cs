using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Configuration;
using System.Windows;
using System;
using System.Linq;

namespace Comp_Club
{
    /// <summary>
    /// Логика взаимодействия для VIPClientPage.xaml
    /// </summary>
    public partial class VIPClientPage : Page
    {
        public VIPClientPage()
        {
            InitializeComponent();
            LoadClients();
        }

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

            var dbClients = Entities.Instance.Clients
                .AsEnumerable() // загружаем данные в память
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

            VIPClientDataGrid.ItemsSource = clients;
        }

        private void addBut_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddClients addWindow = new AddClients
            {
                Owner = Window.GetWindow(this)
            };

            if (addWindow.ShowDialog() == true)
            {
                LoadClients(); // Обновляем список после добавления
            }
        }

        private void remBut_Click(object sender, RoutedEventArgs e)
        {
            if (VIPClientDataGrid.SelectedItem is Client selectedClient && selectedClient.ClientID != -1)
            {
                var result = MessageBox.Show($"Удалить клиента {selectedClient.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var clientToDelete = Entities.Instance.Clients.FirstOrDefault(c => c.ClientID == selectedClient.ClientID);
                        if (clientToDelete != null)
                        {
                            Entities.Instance.Clients.Remove(clientToDelete);
                            Entities.Instance.SaveChanges();

                            MessageBox.Show("Клиент удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadClients(); // Обновляем список
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении клиента:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
    }
}
