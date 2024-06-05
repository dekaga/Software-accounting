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
    /// Логика взаимодействия для AddProgramms.xaml
    /// </summary>
    public partial class AddProgramms : Page
    {
        private Программа _currentProgramm = new Программа();
        private Программа Программа;
        public AddProgramms(Программа selectedProgramm)
        {
            InitializeComponent();
            if (selectedProgramm != null)
            {
                _currentProgramm = selectedProgramm;
            }
            DataContext = _currentProgramm;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentProgramm.название))
            {
                errors.AppendLine("Укажите номер компьютера");
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProgramm.id == 0)
            {
                Krivosheev_zadanieEntities1.GetContext().Программа.Add(_currentProgramm);
            }

            try
            {
                await Krivosheev_zadanieEntities1.GetContext().SaveChangesAsync();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
