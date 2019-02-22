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
using V02_MVC.Model;

namespace V02_MVC.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        bool IsAdmin;
        Worker LogedInWorker;
        public Home(Worker b)
        {
            InitializeComponent();
            btnLogEntries.IsEnabled = b.Admin;
            btnWorkers.IsEnabled = b.Admin;

        }

        private void btnWorkers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Workers());
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Customers());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Cars());
        }

        private void btnCities_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Cities());
        }

        private void btnBills_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Bills());
        }
    }
}
