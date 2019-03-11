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
    /// Logique d'interaction pour addAppointment.xaml
    /// </summary>
    public partial class addAppointment : Page
    {
        private Model2 db = new Model2();
        public addAppointment()
        {
            InitializeComponent();
        }
        //le combobox permet de deroulement de la liste des clients 
        private void Combobox_Loaded(object sender, RoutedEventArgs e)
        {
            comboboxCustomer.ItemsSource = db.customers.ToList();
            comboboxBroker.ItemsSource = db.brokers.ToList();
        }
        // Methode permettant l'ajout du rendez-vous grace au button_click dans la page xaml 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userDate = date.Text;
            string houre = Hour.Text;
            string minut = Min.Text;
            // Condition de fonctionnement.. si les conditions ne sont pas verifiez ça ne fonctionnerà pas. 
            if (comboboxBroker == null || comboboxCustomer == null)
            {
                MessageBox.Show("Une erreur est survenue");
            }
            else if (string.IsNullOrEmpty(houre) && int.Parse(houre) < 10 && int.Parse(houre) > 20)
            {
                MessageBox.Show("Une erreur est survenue");
            }
            else if (!(string.IsNullOrEmpty(minut)) && int.Parse(minut) < 0 && int.Parse(minut) > 59)
            {
                MessageBox.Show("Une erreur est survenue");
            }
            else
            {
                // Déclaration de la var dateTime et affectation des différentes variables composant la dateTime. instanciation de l'objet appointmentToAdd 
                // + affectation des differents attributs la composant.
                var dateTime = userDate + " " + houre + ":" + minut;
                appointments appointmentToAdd = new appointments
                {
                    idBroker = Convert.ToInt32(comboboxBroker.SelectedValue),
                    idCustomer = Convert.ToInt32(comboboxCustomer.SelectedValue),
                    dateHour = Convert.ToDateTime(dateTime)
                };
                //Ajout à la bdd et sauvegarde 
                db.appointments.Add(appointmentToAdd);
                db.SaveChanges();
                MessageBox.Show("Le rendez-vous a bien été ajouté");
            }
        }
        // Methode permettant d'empecher l'insertion de d'autres caractères que des int;
        private void preventString(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}