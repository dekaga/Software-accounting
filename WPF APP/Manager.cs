using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_APP
{
    internal class Manager
    {
        public static Frame MainFrame { get; set; }
        public static int user_now_admin = 0;
        public static TextBlock page_now_text { get; set; }


        public static void Add_test()
        {
            var need = new Компьютер
            {
                номер_компьютера = "Test",
                Ip_адрес = "Test",
                кабинет = "Test",
                характеристики = "Test",
            };

            Krivosheev_zadanieEntities1.GetContext().Компьютер.Add(need);
            Krivosheev_zadanieEntities1.GetContext().SaveChanges();


        }
    }
}
