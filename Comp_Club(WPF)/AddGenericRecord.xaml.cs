using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Comp_Club
{
    public partial class AddGenericRecord : Window
    {
        public string Field1Value { get; private set; }
        public string Field2Value { get; private set; }

        private readonly string _mode;

        // Инициализирует окно и задаёт режим работы
        public AddGenericRecord(string mode)
        {
            InitializeComponent(); // инициализация компонентов
            _mode = mode;
            SetupForm(); // настройка формы по режиму
        }

        // Настраивает заголовок и метки в зависимости от режима
        private void SetupForm()
        {
            switch (_mode)
            {
                case "Запчасти на складе":
                    Title = "Добавить запчасть";
                    Label1.Text = "Название:";
                    Label2.Text = "Количество:";
                    break;

                case "Ежедневная выручка":
                    Title = "Добавить выручку";
                    Label1.Text = "Категория:";
                    Label2.Text = "Выручка:";
                    break;

                case "Популярные блюда":
                    Title = "Добавить блюдо";
                    Label1.Text = "Блюдо:";
                    Label2.Text = "Заказов:";
                    break;

                case "Посещения":
                    Title = "Добавить посещение";
                    Label1.Text = "Дата (yyyy-mm-dd):";
                    Label2.Text = "Посещений:";
                    break;
            }
        }

        // Обработчик кнопки "Добавить": проверяет ввод и возвращает значения
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Field1TextBox.Text) || string.IsNullOrWhiteSpace(Field2TextBox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Field1Value = Field1TextBox.Text;
            Field2Value = Field2TextBox.Text;
            DialogResult = true; 
            Close(); 
        }

        // Обработчик кнопки "Отмена": закрывает окно без сохранения
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close(); 
        }
    }
}
