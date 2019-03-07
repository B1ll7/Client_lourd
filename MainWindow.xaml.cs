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

namespace ClientLourdWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            ////Window addCustomer = new Window();
            ////addCustomer.Show();
            //addCostumer addCostumer = new addCostumer();
            //this.Visibility = Visibility.Hidden;
            //addCostumer.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new addCostumer();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            main.Content = new customersList();
        }

        private void MenuItem_Broker_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new addBroker();
        }

        private void MenuItem_Broker_Click_1(object sender, RoutedEventArgs e)
        {
            main.Content = new addBroker();
        }
    }
}
