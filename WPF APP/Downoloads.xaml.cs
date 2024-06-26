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
    /// <summary>
    /// Логика взаимодействия для Downoloads.xaml
    /// </summary>
    public partial class Downoloads : Page
    {
        public Downoloads()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = Krivosheev_zadanieEntities1.GetContext().Установка.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddDownoloads((sender as Button).DataContext as Установка));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddDownoloads((sender as Button).DataContext as Установка));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Установка>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие{hotelsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Krivosheev_zadanieEntities1.GetContext().Установка.RemoveRange(hotelsForRemoving);
                    Krivosheev_zadanieEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridHotels.ItemsSource = Krivosheev_zadanieEntities1.GetContext().Установка.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
