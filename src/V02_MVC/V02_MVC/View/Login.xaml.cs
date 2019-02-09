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
using V02_MVC.Controller;

namespace V02_MVC.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        LoginController controller;
        public Login()
        {
            InitializeComponent();
            controller = (LoginController)DataContext;
            
            // event when change
            //controller.Model.LogedIn -> navigate to home.xaml
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Home(controller.Model.IsAdmin));
        }
    }
}
