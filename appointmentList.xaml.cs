using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Logique d'interaction pour appointmentList.xaml
    /// </summary>
    public partial class appointmentList : Page
    {
        private Model2 db = new Model2();
        appointments appointmentToAdd;
        int? idtodel;

        public appointmentList()
        {
            InitializeComponent();
            appointmentToAdd = new appointments();
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            appointDataGrid.ItemsSource = db.appointments.ToList();
            editComboboxCustomer.ItemsSource = db.customers.ToList();
            editComboboxBroker.ItemsSource = db.brokers.ToList();
        }

        private void AppointmentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appointDataGrid.SelectedItem == null) return;
            appointmentToAdd = appointDataGrid.SelectedItem as appointments;
            idtodel = appointmentToAdd.idAppointment;
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            editComboboxBroker.Text = appointmentToAdd.brokers.lastName.ToString();
            editComboboxCustomer.Text = appointmentToAdd.customers.lastName.ToString();
            editDateHour.Text = appointmentToAdd.dateHour.ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.appointments.Remove(appointmentToAdd);
            appointmentToAdd = db.appointments.Find(idtodel);
            db.appointments.Remove(appointmentToAdd);
            db.SaveChanges();
            appointDataGrid.ItemsSource = null;
            appointDataGrid.ItemsSource = db.appointments.ToList();
            MessageBox.Show("Ca marche");
            editComboboxBroker.Text = " ";
            editComboboxCustomer.Text = " ";
            editDateHour.Text = " ";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userDate = editDateHour.Text;
            // Condition de fonctionnement.. si les conditions ne sont pas verifiez ça ne fonctionnerà pas. 
            //if (editComboboxBroker == null || editComboboxCustomer == null)
            //{
            //    MessageBox.Show("Une erreur est survenue");
            //}
            //else if (string.IsNullOrEmpty(userDate))
            //{
            //    MessageBox.Show("Une erreur est survenue");
            //}
            //else
            //{
                // Déclaration de la var dateTime et affectation des différentes variables composant la dateTime. instanciation de l'objet appointmentToAdd 
                // + affectation des differents attributs la composant.
                var dateTime = userDate;
                appointments appointmentToAdd = new appointments
                {
                    idBroker = Convert.ToInt32(editComboboxBroker.SelectedValue),
                    idCustomer = Convert.ToInt32(editComboboxCustomer.SelectedValue),
                    dateHour = Convert.ToDateTime(dateTime)
                };
            //Ajout à la bdd et sauvegarde 
                db.Entry(appointmentToAdd).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Le rendez-vous a bien été ajouté");
            //}
        }
    }
}
