using System;
using System.Windows;
using System.Windows.Navigation;

namespace Comp_Club
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

                case "buffet":

                    break;

                case "adminPanel":
                    Height = 450;
                    Width = 800;

                    break;

                default:

                    break;
            }
            
        }

        private void mainMenu()
        {
            if (logBox.Text == "Admin" && passBox.Password == "Admin")
            {
                logBox.Visibility = Visibility.Hidden;
                passBox.Visibility = Visibility.Hidden;
                enterBut.Visibility = Visibility.Hidden;                
                textLogo.Visibility = Visibility.Hidden;
                adminPanel.Visibility = Visibility.Hidden;

                menuNav.Visibility = Visibility.Visible;               
                reportsItem.Visibility = Visibility.Visible;
                reportsItem.IsEnabled = true;
            }
               

            else
            {
                logBox.Visibility = Visibility.Hidden;
                passBox.Visibility = Visibility.Hidden;
                enterBut.Visibility = Visibility.Hidden;
                menuNav.Visibility = Visibility.Visible;
                textLogo.Visibility = Visibility.Hidden;
            }

            MainFrame.Content = new MonitoringPage();
            SaizeChange("hallItem");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainMenu();
        }

        private void hallItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MonitoringPage();
            SaizeChange("hallItem");
        }

        private void vipClientItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new VIPClientPage();
            SaizeChange("vipClientItem");
        }

        private void reportsItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new reportsPage();
            SaizeChange("reportsItem");
        }

        private void adminPanel_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();            
        }
    }
}
