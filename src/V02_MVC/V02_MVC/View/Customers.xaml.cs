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
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        CustomersController c;
        public Customers()
        {
            InitializeComponent();
            c = (CustomersController) DataContext;
            c.Model.PropertyChanged += Model_AddCustomer;
            c.Model.PropertyChanged += Model_DeleteCustomer;
            c.Model.PropertyChanged += Model_DeleteCustomerUn;
            c.Model.PropertyChanged += Model_EditCustomer;
        }

        private void Model_EditCustomer(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "EditCustomer")
            {
                expEditCustomer.IsExpanded = false;
                MessageBox.Show("Successfully edited Customer");
            }
        }

        private void Model_DeleteCustomerUn(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DeleteCustomerUn")
            {
                MessageBox.Show("Couldn't delete Customer");
            }
        }

        private void Model_DeleteCustomer(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DeleteCustomer")
            {
                MessageBox.Show("Successfully deleted Customer");
            }
        }

        private void Model_AddCustomer(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddCustomer")
            {
                MessageBox.Show("Successfully added customer");
                expAddCustomer.IsExpanded = false;
            }
        }

        private void btnOpenEditExp_Click(object sender, RoutedEventArgs e)
        {
            expEditCustomer.IsExpanded = true;
        }
    }
}
