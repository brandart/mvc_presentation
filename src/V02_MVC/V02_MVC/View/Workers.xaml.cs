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
    /// Interaction logic for Workers.xaml
    /// </summary>
    public partial class Workers : Page
    {
        WorkersController c;
        public Workers()
        {
            InitializeComponent();
            c = (WorkersController)DataContext;
            c.Model.PropertyChanged += Model_AddWorker;
            c.Model.PropertyChanged += Model_DeleteWorker;
            c.Model.PropertyChanged += Model_EditWorker;
        }

        private void Model_EditWorker(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "EditWorker")
            {
                expEditWorker.IsExpanded = false;
                MessageBox.Show("Successfully edited worker");
            }
        }

        private void Model_DeleteWorker(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DeleteWorker")
            {
                MessageBox.Show("Successfully deleted Worker");
            }
        }

        private void Model_AddWorker(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddWorker")
            {
                expAddWorker.IsExpanded = false;
                MessageBox.Show("Successfully added worker");
            }
        }

        private void btnOpenEditExp_Click(object sender, RoutedEventArgs e)
        {
            expEditWorker.IsExpanded = true;
        }
    }
}
