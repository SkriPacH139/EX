using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace Comp_Club
{
    public partial class VIPClientPage : Page
    {
        // Инициализация страницы VIP-клиентов и загрузка списка
        public VIPClientPage()
        {
            InitializeComponent();
            LoadClients();
        }

        // Загружает зарегистрированных и незарегистрированных клиентов в таблицу
        private void LoadClients()
        {
            var clients = new List<Client>
            {
                new Client { ClientID = -1, Name = "Незарегистрированный пользователь" }
            };

            var dbClients = Entities.Instance.Clients
                .AsEnumerable() // переводим запрос в память
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
            VIPClientDataGrid.ItemsSource = clients; // отображаем в гриде
        }

        // Открывает окно добавления нового клиента и обновляет список после сохранения
        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddClients { Owner = Window.GetWindow(this) };
            if (addWindow.ShowDialog() == true)
                LoadClients();
        }

        // Удаляет выбранного клиента из базы после подтверждения
        private void remBut_Click(object sender, RoutedEventArgs e)
        {
            if (VIPClientDataGrid.SelectedItem is Client selectedClient && selectedClient.ClientID != -1)
            {
                var result = MessageBox.Show(
                    $"Удалить клиента {selectedClient.Name}?",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var clientToDelete = Entities.Instance.Clients
                            .FirstOrDefault(c => c.ClientID == selectedClient.ClientID);
                        if (clientToDelete != null)
                        {
                            Entities.Instance.Clients.Remove(clientToDelete);
                            Entities.Instance.SaveChanges();

                            MessageBox.Show("Клиент удалён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadClients();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении клиента:\n{ex.Message}",
                                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.",
                                "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
