using System;
using System.Windows;
using System.Windows.Navigation;

namespace Comp_Club
{
    public partial class MainWindow : Window
    {
        // Инициализация главного окна
        public MainWindow()
        {
            InitializeComponent();
        }

        // Изменяет размеры окна в зависимости от выбранного пункта меню
        private void SaizeChange(string str)
        {
            switch (str)
            {
                case "hallItem":
                    Height = 750;
                    Width = 1250;
                    break;
                case "vipClientItem":
                    Height = 700;
                    Width = 800;
                    break;
                case "reportsItem":
                    Height = 750;
                    Width = 1250;
                    break;
                case "adminPanel":
                    Height = 450;
                    Width = 800;
                    break;
                default:
                    break;
            }
        }

        // Отображает главное меню после ввода логина/пароля
        private void mainMenu()
        {
            bool isAdmin = logBox.Text == "Admin" && passBox.Password == "Admin";
            logBox.Visibility = Visibility.Hidden;
            passBox.Visibility = Visibility.Hidden;
            enterBut.Visibility = Visibility.Hidden;
            textLogo.Visibility = Visibility.Hidden;

            if (isAdmin)
            {
                adminPanel.Visibility = Visibility.Hidden;
                reportsItem.Visibility = Visibility.Visible;
                reportsItem.IsEnabled = true;
            }
            else
            {
                adminPanel.Visibility = Visibility.Visible;
            }

            menuNav.Visibility = Visibility.Visible;
            MainFrame.Content = new MonitoringPage();
            SaizeChange("hallItem");
        }

        // Обработчик кнопки входа
        private void Button_Click(object sender, RoutedEventArgs e) => mainMenu();

        // Переход на страницу мониторинга
        private void hallItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MonitoringPage();
            SaizeChange("hallItem");
        }

        // Переход на страницу VIP-клиентов
        private void vipClientItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new VIPClientPage();
            SaizeChange("vipClientItem");
        }

        // Переход на страницу отчетов
        private void reportsItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new reportsPage();
            SaizeChange("reportsItem");
        }

        // Открывает новое окно администратора
        private void adminPanel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
