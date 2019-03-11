using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Logique d'interaction pour brokerList.xaml
    /// </summary>
    public partial class brokerList : Page
    {
        private Model2 db = new Model2();
        brokers broker;
        int? idtodel;
        public brokerList()
        {
            InitializeComponent();
            broker = new brokers();
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.brokers.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string regexName = @"^[A-Za-zéèàêâôûùïüç-]+$";
            string regexMail = @"^[0-9a-zA-Z.-]+@[0-9a-zA-Z.-]+.[a-zA-Z]{2,4}";
            string regexPhone = @"^[0][0-9]{9}";

            //Ajout des propriétés du nouveau client
            broker.lastName = editLastName.Text;
            broker.firstName = editFirstName.Text;
            broker.mail = editMail.Text;
            broker.phoneNumber = editPhoneNumber.Text;

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
                db.Entry(broker).State = EntityState.Modified;
                db.SaveChanges();
                dataGrid.Items.Refresh();
                MessageBox.Show("Ca marche");
            }
        }

        private void brokerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            broker = dataGrid.SelectedItem as brokers;
            idtodel = broker.idBroker;
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            editLastName.Text = broker.lastName;
            editFirstName.Text = broker.firstName;
            editMail.Text = broker.mail;
            editPhoneNumber.Text = broker.phoneNumber;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.brokers.Remove(broker);
            broker = db.brokers.Find(idtodel);
            db.brokers.Remove(broker);
            db.SaveChanges();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = db.brokers.ToList();
            MessageBox.Show("Ca marche");
            editLastName.Text = " ";
            editFirstName.Text = " ";
            editMail.Text = " ";
            editPhoneNumber.Text = " ";
        }
    }
}
