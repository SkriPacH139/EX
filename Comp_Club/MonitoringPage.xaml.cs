using System.Collections.Generic;
using System.Windows.Controls;

namespace Comp_Club
{
    /// <summary>
    /// Логика взаимодействия для MonitoringPage.xaml
    /// </summary>
    public partial class MonitoringPage : Page
    {
        private List<string> hallName = new List<string> { "Зал 1", "Зал 2", "Зал 3", "VIP" };
        public MonitoringPage()
        {
            InitializeComponent();
        }

        private void infoClick(string idName, string hall, int ID)
        {
            infoTabWindow newWindow = new infoTabWindow(idName, hall, ID);
            newWindow.Show();
        }

        #region Зал 1
        private void PK01_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK01.Name, hallName[0], 1);
        private void PK02_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK02.Name, hallName[0], 2);
        private void PK03_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK03.Name, hallName[0], 3);
        private void PK04_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK04.Name, hallName[0], 4);
        private void PK05_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK05.Name, hallName[0], 5);
        private void PK06_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK06.Name, hallName[0], 6);
        private void PK07_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK07.Name, hallName[0], 7);
        private void PK08_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK08.Name, hallName[0], 8);
        private void PK09_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK09.Name, hallName[0], 9);
        private void PK10_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK10.Name, hallName[0], 10);
        #endregion

        #region Зал 2        
        private void PK11_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK11.Name, hallName[1], 11);
        private void PK12_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK12.Name, hallName[1], 12);
        private void PK13_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK13.Name, hallName[1], 13);
        private void PK14_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK14.Name, hallName[1], 14);
        private void PK15_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK15.Name, hallName[1], 15);
        private void PK16_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK16.Name, hallName[1], 16);
        private void PK17_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK17.Name, hallName[1], 17);
        private void PK18_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK18.Name, hallName[1], 18);
        private void PK19_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK19.Name, hallName[1], 19);
        private void PK20_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK20.Name, hallName[1], 20);
        #endregion

        #region Зал 3
        private void PK21_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK21.Name, hallName[2], 21);
        private void PK22_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK22.Name, hallName[2], 22);
        private void PK23_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK23.Name, hallName[2], 23);
        private void PK24_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK24.Name, hallName[2], 24);
        private void PK25_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK25.Name, hallName[2], 25);
        private void PK26_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK26.Name, hallName[2], 26);
        private void PK27_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK27.Name, hallName[2], 27);
        private void PK28_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK28.Name, hallName[2], 28);

        private void Con1_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con1.Name, hallName[2], 29);
        private void Con2_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con2.Name, hallName[2], 30);
        private void Con3_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con3.Name, hallName[2], 31);
        private void Con4_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con4.Name, hallName[2], 32);
        private void Con5_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con5.Name, hallName[2], 33);
        private void Con6_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con6.Name, hallName[2], 34);
        private void Con7_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con7.Name, hallName[2], 35);
        private void Con8_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con8.Name, hallName[2], 36);
        #endregion

        #region Зал VIP
        private void PK29_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK29.Name, hallName[3], 37);
        private void PK30_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK30.Name, hallName[3], 38);
        private void PK31_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK31.Name, hallName[3], 39);
        private void PK32_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK32.Name, hallName[3], 40);
        private void PK33_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK33.Name, hallName[3], 41);
        private void PK34_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK34.Name, hallName[3], 42);
        private void PK35_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK35.Name, hallName[3], 43);
        private void PK36_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK36.Name, hallName[3], 44);
        private void PK37_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK37.Name, hallName[3], 45);
        private void PK38_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(PK38.Name, hallName[3], 46);

        private void Con9_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con9.Name, hallName[3], 47);
        private void Con10_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con10.Name, hallName[3], 48);
        private void Con11_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con11.Name, hallName[3], 49);
        private void Con12_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con12.Name, hallName[3], 50);
        private void Con13_Click(object sender, System.Windows.RoutedEventArgs e) => infoClick(Con13.Name, hallName[3], 51);
        #endregion
    }
}
