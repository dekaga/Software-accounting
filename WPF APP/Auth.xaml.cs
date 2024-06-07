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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }
        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void Loginer_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, совпадают ли введенные данные с данными администратора
            if (txtUsername.Text == "user1" && Pas.Password == "user1")
            {
                // Если совпадают, переходим на страницу администратора
                Manager.MainFrame.Navigate(new Admin());
                return;
            }
            // Устанавливаем количество попыток входа
            int Try = 3;
            // Пока количество попыток не равно 0
            if (Try != 0)
            {
                try
                {
                    // Ищем пользователя с введенными данными в БД
                    var search_user = Krivosheev_zadanieEntities1.GetContext().Users.Where(p => p.Name == txtUsername.Text && p.Password == Pas.Password).Single();
                    // Если введены данные администратора
                    if (txtUsername.Text == "admin" && Pas.Password == "admin") 
                    {
                        // Переходим на страницу компьютеров
                        this.NavigationService.Navigate(new HotelsPage());
                    }

                    else
                        Console.WriteLine("Пароль");
                    // Выводим имя найденного пользователя
                    Console.WriteLine($"{search_user.Name}");
                }
                // Если пользователь не найден, выводим сообщение об ошибке
                catch
                {
                    MessageBox.Show("Ошибка, что-то неправильно");
                }
            }
        }
    }
}
