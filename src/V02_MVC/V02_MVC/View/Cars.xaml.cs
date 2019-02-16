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
        public Cars()
        {
            InitializeComponent();
            var c = (CarsController)DataContext;
            c.Model.PropertyChanged += Model_AddCar;
        }

        private void Model_AddCar(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddCar")
            {
                expAddCar.IsExpanded = false;
                MessageBox.Show("Successfully added Car");
            }
        }
    }
}
