using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour addBroker.xaml
    /// </summary>
    public partial class addBroker : Page
    {
        private Model2 db = new Model2();
        public addBroker()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // instanciation d'un nouveau client
            brokers broker = new brokers();

            string regexName = @"^[A-Za-zéèàêâôûùïüç-]+$";
            string regexMail = @"^[0-9a-zA-Z.-]+@[0-9a-zA-Z.-]+.[a-zA-Z]{2,4}";
            string regexPhone = @"^[0][0-9]{9}";

            //Ajout des propriétés du nouveau client
            broker.lastName = lastName.Text;
            broker.firstName = firstName.Text;
            broker.mail = address.Text;
            broker.phoneNumber = phoneNumber.Text;

            if (!(string.IsNullOrEmpty(broker.lastName)) && !Regex.IsMatch(broker.lastName, regexName))
            {
                MessageBox.Show("Ecrire un nom valide /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(broker.firstName)) && !Regex.IsMatch(broker.firstName, regexName))
            {
                MessageBox.Show("Ecrire un Prénom valide  /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(broker.mail)) && !Regex.IsMatch(broker.mail, regexMail))
            {
                MessageBox.Show("Ecrire un mail valide  /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(broker.phoneNumber)) && !Regex.IsMatch(broker.phoneNumber, regexPhone))
            {
                MessageBox.Show("Ecrire un numero valide  /!\\Attention aux Espaces en trop/!\\");
            }
            else if (string.IsNullOrEmpty(broker.lastName) || string.IsNullOrEmpty(broker.firstName) ||
                string.IsNullOrEmpty(broker.mail) || string.IsNullOrEmpty(broker.phoneNumber))
            {
                MessageBox.Show("Remplir les champs vides s'il vous plait ! ");
            }
            else
            {
                //Ajout à la bdd et sauvegarde 
                db.brokers.Add(broker);
                db.SaveChanges();
                MessageBox.Show("Ca marche");
                lastName.Text = " ";
                firstName.Text = " ";
                address.Text = " ";
                phoneNumber.Text = " ";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("brokerList.xaml", UriKind.Relative));
        }
    }
}
