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
    /// Interaction logic for Cities.xaml
    /// </summary>
    public partial class Cities : Page
    {
        CitiesController c;
        public Cities()
        {
            InitializeComponent();
            c = (CitiesController)DataContext;
            c.Model.PropertyChanged += Model_AddCity;
            c.Model.PropertyChanged += Model_DeleteCity;
            c.Model.PropertyChanged += Model_DeleteCityUnsuccessful;
        }

        private void Model_DeleteCityUnsuccessful(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DeleteCarUnsuccessful")
            {
                MessageBox.Show("City couldn't be deleted");
            }
        }

        private void Model_DeleteCity(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DeleteCar")
            {
                MessageBox.Show("Successfully deleted city");
            }
        }

        private void Model_AddCity(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddCity")
            {
                expAddCity.IsExpanded = false;
                MessageBox.Show("Successfully added city");
            }
        }
    }
}
