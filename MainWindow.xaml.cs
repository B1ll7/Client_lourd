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
        //Methode permettant d'acceder à la page addCustomer
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new addCostumer();
        }
        //Methode permettant d'acceder à la page customerList
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            main.Content = new customersList();
        }
        //Methode permettant d'acceder à la page addBroker
        private void MenuItem_Broker_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new addBroker();
        }
        //Methode permettant d'acceder à la page brokerList
        private void MenuItem_Broker_Click_1(object sender, RoutedEventArgs e)
        {
            main.Content = new brokerList();
        }

        private void page_loaded(object sender, RoutedEventArgs e)
        {
            main.Content = new addBroker();
        }
        //Methode permettant d'acceder à la page addAppointment
        private void MenuItem_Appointment_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new addAppointment();
        }
        //Methode permettant d'acceder à la page AppointmentList
        private void MenuItem_Appointment_Click_1(object sender, RoutedEventArgs e)
        {
            main.Content = new appointmentList();
        }
    }
}
