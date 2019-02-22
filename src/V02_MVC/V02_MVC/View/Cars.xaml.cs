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
using V02_MVC.Model;

namespace V02_MVC.View
{
    /// <summary>
    /// Interaction logic for Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        CarsController c; 
        public Cars()
        {
            InitializeComponent();
            c = (CarsController)DataContext;
            c.Model.PropertyChanged += Model_AddCar;
            c.Model.PropertyChanged += Model_DeleteCar;
            c.Model.PropertyChanged += Model_EditCar;
            c.Model.PropertyChanged += Model_DeleteCarUn;
        }

        private void Model_DeleteCarUn(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DeleteCarUn")
            {
                MessageBox.Show("Car coudln't be deleted");
            }
        }

        private void Model_AddCar(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddCar")
            {
                expAddCar.IsExpanded = false;
                MessageBox.Show("Successfully added Car");
            }
        }

        private void Model_DeleteCar(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DeleteCar")
            {
                MessageBox.Show("Successfully deleted Car");
            }
        }
        private void Model_EditCar(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "EditCar")
            {
                expEditCar.IsExpanded = false;
                MessageBox.Show("Successfully edited Car");
            }
        }

        private void btnExpEditCar_Click(object sender, RoutedEventArgs e)
        {
            expEditCar.IsExpanded = true;
        }
    }
}
