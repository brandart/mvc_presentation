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

namespace V02_MVC.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        bool IsAdmin;
        public Home(bool b)
        {
            InitializeComponent();
            btnLogEntries.IsEnabled = b;
            btnWorkers.IsEnabled = b;

        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Customers());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Cars());
        }
    }
}
