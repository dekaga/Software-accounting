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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_APP
{
    /// <summary>
    /// Логика взаимодействия для AddDownoloads.xaml
    /// </summary>
    public partial class AddDownoloads : Page
    {
        private Установка _currentDownoloads = new Установка(); // Поле для отслеживания текущей редактируемой установки
        private Установка Установка;
        public AddDownoloads(Установка selectedDownoloads) 
        {
            InitializeComponent();
            //// Если передана установка для редактирования, то скопируем ее в поле для отслеживания текущей редактируемой установки

            if (selectedDownoloads != null)
            {
                _currentDownoloads = selectedDownoloads;
            }
            // Устанавливаем контекст данных для формы
            DataContext = _currentDownoloads;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) //
        {
            // Создаем строку для вывода ошибок
            StringBuilder errors = new StringBuilder();
            // Проверяем обязательные поля
            if (string.IsNullOrWhiteSpace(_currentDownoloads.режим_установки)) errors.AppendLine("Укажите режим установки");
            // Если есть ошибки, то выводим их и возвращаемся
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            // Если текущая установка имеет id=0, то это новая установка
            if (_currentDownoloads.id == 0)
                Krivosheev_zadanieEntities1.GetContext().Установка.Add(_currentDownoloads);
            // Cохраняем изменения в БД
            try
            {
                Krivosheev_zadanieEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            // Если произошла ошибка при сохранении, то выводим сообщение об ошибке
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
