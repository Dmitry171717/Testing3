using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Admink.xaml
    /// </summary>
    public partial class Admink : Page
    {
        public static TradingEntities Connection = new TradingEntities();
        public ObservableCollection<Product> Products { get; set; }
        public Admink()
        {
            InitializeComponent();
            Products =
               new ObservableCollection<Product>(
                       Connection.Product.ToList()
                   );

            DataContext = this;
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Autorization());
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
