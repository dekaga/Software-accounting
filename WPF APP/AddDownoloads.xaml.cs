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
        private Установка _currentDownoloads = new Установка();
        private Установка Установка;
        public AddDownoloads(Установка selectedDownoloads)
        {
            InitializeComponent();
            if (selectedDownoloads != null)
            {
                _currentDownoloads = selectedDownoloads;
            }
            DataContext = _currentDownoloads;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentDownoloads.режим_установки)) errors.AppendLine("Укажите режим установки");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentDownoloads.id == 0)
                Krivosheev_zadanieEntities1.GetContext().Установка.Add(_currentDownoloads);
            try
            {
                Krivosheev_zadanieEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
