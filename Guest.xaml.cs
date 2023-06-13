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
using System.Collections;
using System.Collections.ObjectModel;

namespace Uvelir
{
    /// <summary>
    /// Логика взаимодействия для Guest.xaml
    /// </summary>
    public partial class Guest : Page
    {
        public static TradingEntities Connection = new TradingEntities();
        public ObservableCollection<Product> Products { get; set; }
        public Guest()
        {
            InitializeComponent();
            Products =
                new ObservableCollection<Product>(
                        Connection.Product.ToList()
                    );

            DataContext = this;
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Autorization());
        }
    }
}
