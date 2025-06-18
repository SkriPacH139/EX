using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Comp_Club
{
    /// <summary>
    /// Логика взаимодействия для reportsPage.xaml
    /// </summary>
    public partial class reportsPage : Page
    {
        public reportsPage()
        {
            InitializeComponent();
            LoadAllData();
        }

        private void LoadAllData()
        {
            LoadDailyRevenue();
            LoadRepairParts();
            LoadPopularDishes();
            LoadGuestStats();
        }

        private void LoadDailyRevenue()
        {
            dailyRevenueDataGrid.ItemsSource = Entities.Instance.DailyRevenue.ToList();
        }

        private void LoadRepairParts()
        {
            repairPartsDataGrid.ItemsSource = Entities.Instance.RepairParts.ToList();
        }

        private void LoadPopularDishes()
        {
            popularDishesDataGrid.ItemsSource = Entities.Instance.PopularDish.ToList();
        }

        private void LoadGuestStats()
        {
            guestStatsDataGrid.ItemsSource = Entities.Instance.GuestVisitStat.ToList();
        }

        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            var selectedTab = ((TabItem)MainTab.SelectedItem).Header.ToString();
            var addWindow = new AddGenericRecord(selectedTab) { Owner = Window.GetWindow(this) };

            if (addWindow.ShowDialog() == true)
            {
                try
                {
                    switch (selectedTab)
                    {
                        case "Ежедневная выручка":
                            Entities.Instance.DailyRevenue.Add(new DailyRevenue
                            {
                                Category = addWindow.Field1Value,
                                Revenue = decimal.Parse(addWindow.Field2Value)
                            });
                            break;

                        case "Запчасти на складе":
                            Entities.Instance.RepairParts.Add(new RepairParts
                            {
                                PartsName = addWindow.Field1Value,
                                Balance = int.Parse(addWindow.Field2Value)
                            });
                            break;

                        case "Популярные блюда":
                            Entities.Instance.PopularDish.Add(new PopularDish
                            {
                                DishName = addWindow.Field1Value,
                                OrderCount = int.Parse(addWindow.Field2Value)
                            });
                            break;

                        case "Посещения":
                            Entities.Instance.GuestVisitStat.Add(new GuestVisitStat
                            {
                                Period = addWindow.Field1Value,
                                Visits = int.Parse(addWindow.Field2Value)
                            });
                            break;
                    }

                    Entities.Instance.SaveChanges();
                    LoadAllData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void remBut_Click(object sender, RoutedEventArgs e)
        {
            var selectedTab = ((TabItem)MainTab.SelectedItem).Header.ToString();

            try
            {
                switch (selectedTab)
                {
                    case "Ежедневная выручка":
                        if (dailyRevenueDataGrid.SelectedItem is DailyRevenue revenue)
                        {
                            Entities.Instance.DailyRevenue.Remove(revenue);
                        }
                        break;

                    case "Запчасти на складе":
                        if (repairPartsDataGrid.SelectedItem is RepairParts part)
                        {
                            Entities.Instance.RepairParts.Remove(part);
                        }
                        break;

                    case "Популярные блюда":
                        if (popularDishesDataGrid.SelectedItem is PopularDish dish)
                        {
                            Entities.Instance.PopularDish.Remove(dish);
                        }
                        break;

                    case "Посещения":
                        if (guestStatsDataGrid.SelectedItem is GuestVisitStat stat)
                        {
                            Entities.Instance.GuestVisitStat.Remove(stat);
                        }
                        break;
                }

                Entities.Instance.SaveChanges();
                LoadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }



}

