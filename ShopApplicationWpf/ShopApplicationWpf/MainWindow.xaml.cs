using ShopApplicationWpf.Controller;
using ShopApplicationWpf.Model;
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

namespace ShopApplicationWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        myController _controller = new myController();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = _controller;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _controller.setName(txtText.Text);
        }
    }
}
