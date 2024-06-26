﻿using System;
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

    public partial class AddEditPage : Page
    {
        private Компьютер _currentHotel = new Компьютер(); // Поле для отслеживания текущего редактируемого компьюьтера
        private Компьютер компьютер;

        public AddEditPage(Компьютер selectedHotel)
        {
            InitializeComponent();
            //// Если передан копмпьютер для редактирования, то скопируем его в поле для отслеживания текущего редактируемого компьютера
            if (selectedHotel != null)
            {
                _currentHotel = selectedHotel;
            }
            // Устанавливаем контекст данных для формы
            DataContext = _currentHotel;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Создаем строку для вывода ошибок
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.номер_компьютера))errors.AppendLine("Укажите номер компьютера");
            // Если есть ошибки, то выводим их и возвращаемся
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            // Если текущий компьютер имеет id=0, то это новый компьютер
            if (_currentHotel.id == 0)
                Krivosheev_zadanieEntities1.GetContext().Компьютер.Add(_currentHotel);
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
