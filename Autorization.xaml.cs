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

namespace Uvelir
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public static TradingEntities connection = new TradingEntities();
        private string code = "";
        private const string chars = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        public Autorization()
        {
            InitializeComponent();
            string chars = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 6; i++)
            {
                int a = random.Next(0, chars.Length - 1);
                code += chars.Substring(a, 1);
            }
            CaptLab.Text = code;
        }

        private void Admin(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Admink());
        }

        private void Klient(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Guest());
        }

        private void Vhod(object sender, RoutedEventArgs e)
        {
            if(code.Length>0&& CaptLab.Text!=code)
            {
                MessageBox.Show("Некорректные данные");
                //BlockActivate();
                return;
            }

            string login = loginBox.Text.Trim();
            string password = PassBox.Password.Trim();
            var user = Autorization.connection.User.Where(u => u.UserMail == login && u.UserPassword == password).FirstOrDefault();

            if(user==null)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }

            else
            {
                if (user.UserRole == "Клиент") Manager.MainFrame.Navigate(new Guest());
                if (user.UserRole == "Администратор") Manager.MainFrame.Navigate(new Admink());
            }
        }
    }
}
