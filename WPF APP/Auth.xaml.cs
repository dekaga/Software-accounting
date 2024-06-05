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
            if (txtUsername.Text == "user1" && Pas.Password == "user1")
            {
                Manager.MainFrame.Navigate(new Admin());
                return;
            }
            int Try = 3;
            if (Try != 0)
            {
                try
                {
                    var search_user = Krivosheev_zadanieEntities1.GetContext().Users.Where(p => p.Name == txtUsername.Text && p.Password == Pas.Password).Single();

                    if (txtUsername.Text == "admin" && Pas.Password == "admin") 
                    {
                        this.NavigationService.Navigate(new HotelsPage());
                    }

                    else
                        Console.WriteLine("Пароль");

                    Console.WriteLine($"{search_user.Name}");
                }
                catch
                {
                    MessageBox.Show("Ошибка, что-то неправильно");
                }
            }
        }
    }
}
