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
    /// Логика взаимодействия для Programms.xaml
    /// </summary>
    public partial class Programms : Page
    {
        public Programms()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = Krivosheev_zadanieEntities1.GetContext().Программа.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProgramms(null));
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Downoloads());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProgramms((sender as Button).DataContext as Программа));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Программа>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие{hotelsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Krivosheev_zadanieEntities1.GetContext().Программа.RemoveRange(hotelsForRemoving);
                    Krivosheev_zadanieEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridHotels.ItemsSource = Krivosheev_zadanieEntities1.GetContext().Программа.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
