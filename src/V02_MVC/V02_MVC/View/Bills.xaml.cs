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
    /// Interaction logic for Bills.xaml
    /// </summary>
    public partial class Bills : Page
    {
        BillsController c;
        public Bills()
        {
            InitializeComponent();
            c = (BillsController) DataContext;
            c.Model.PropertyChanged += Model_AddBill;
            c.Model.PropertyChanged += Model_DeleteBill;

        }

        private void Model_DeleteBill(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DeleteBill")
            {
                MessageBox.Show("Successfully canceled bill");
            }
        }

        private void Model_AddBill(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddBill")
            {
                expAddBill.IsExpanded = false;
                MessageBox.Show("Successfully added bill");
            }
        }
    }
}
