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
        private Программа _currentProgramm = new Программа(); // Поле для отслеживания текущей редактируемой программы
        private Программа Программа;
        public AddProgramms(Программа selectedProgramm)
        {
            InitializeComponent();
            //// Если передана программа для редактирования, то скопируем ее в поле для отслеживания текущей редактируемой программы
            if (selectedProgramm != null)
            {
                _currentProgramm = selectedProgramm;
            }
            // Устанавливаем контекст данных для формы
            DataContext = _currentProgramm;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Создаем строку для вывода ошибок
            StringBuilder errors = new StringBuilder();
            // Проверяем обязательные поля
            if (string.IsNullOrWhiteSpace(_currentProgramm.название))
            {
                errors.AppendLine("Укажите номер компьютера");
                MessageBox.Show(errors.ToString());
                return;
            }
            // Если текущая программа имеет id=0, то это новая программа
            if (_currentProgramm.id == 0)
            {
                Krivosheev_zadanieEntities1.GetContext().Программа.Add(_currentProgramm);
            }
            // Cохраняем изменения в БД
            try
            {
                await Krivosheev_zadanieEntities1.GetContext().SaveChangesAsync();
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
