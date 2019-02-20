﻿using System;
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
        }

        private void Model_AddCustomer(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "AddCustomer")
            {
                MessageBox.Show("Successfully added customer");
                expAddCustomer.IsExpanded = false;
            }
        }
    }
}
