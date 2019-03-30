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

            controller.Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "LogedIn" && controller.Model.LogedIn)
                this.NavigationService.Navigate(new Home(controller.Model.LogedInWorker));
        }

    }
}
