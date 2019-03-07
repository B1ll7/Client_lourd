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
    /// Logique d'interaction pour customersList.xaml
    /// </summary>
    public partial class customersList : Page
    {
        private Model2 db = new Model2();
        customers customer;
        int? idtodel;

        public customersList()
        {
            InitializeComponent();
            customer = new customers();
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.customers.ToList();
        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem == null) return;
            customer = dataGrid.SelectedItem as customers;
            idtodel = customer.idCustomer;
            // On attribue a chaque champ prévu la valeur de l'element selectionner
            editLastName.Text = customer.lastName;
            editFirstName.Text = customer.firstName;
            editMail.Text = customer.mail;
            editPhoneNumber.Text = customer.phoneNumber;
            editBudget.Text = customer.budget.ToString();
            editSubject.Text = customer.subject;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string regexName = @"^[A-Za-zéèàêâôûùïüç-]+$";
            string regexMail = @"^[0-9a-zA-Z.-]+@[0-9a-zA-Z.-]+.[a-zA-Z]{2,4}";
            string regexPhone = @"^[0][0-9]{9}";
            string regexSubject = @"^[A-Za-zéèëêuùçôàö\-' ]+$";
            string regexBudget = @"^[0-9]+$";
            string budget;

            //Ajout des propriétés du nouveau client
            customer.lastName = editLastName.Text;
            customer.firstName = editFirstName.Text;
            customer.mail = editMail.Text;
            customer.phoneNumber = editPhoneNumber.Text;
            budget = editBudget.Text;
            customer.subject = editSubject.Text;

            if (!(string.IsNullOrEmpty(customer.lastName)) && !Regex.IsMatch(customer.lastName, regexName))
            {
                MessageBox.Show("Ecrire un nom valide /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(customer.firstName)) && !Regex.IsMatch(customer.firstName, regexName))
            {
                MessageBox.Show("Ecrire un Prénom valide  /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(customer.mail)) && !Regex.IsMatch(customer.mail, regexMail))
            {
                MessageBox.Show("Ecrire un mail valide  /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(customer.phoneNumber)) && !Regex.IsMatch(customer.phoneNumber, regexPhone))
            {
                MessageBox.Show("Ecrire un numero valide  /!\\Attention aux Espaces en trop/!\\");
            }
            else if (!(string.IsNullOrEmpty(customer.subject)) && !Regex.IsMatch(customer.subject, regexSubject))
            {
                MessageBox.Show("Ecrire un sujet valide  /!\\Attention aux Espaces/!\\");
            }
            else if (!(string.IsNullOrEmpty(budget)) && !Regex.IsMatch(budget, regexBudget))
            {
                MessageBox.Show("Ecrire un sujet valide  /!\\Attention aux Espaces/!\\");
            }
            else if (string.IsNullOrEmpty(customer.lastName) || string.IsNullOrEmpty(customer.firstName) ||
                string.IsNullOrEmpty(customer.mail) || string.IsNullOrEmpty(customer.phoneNumber) || string.IsNullOrEmpty(customer.subject))
            {
                MessageBox.Show("Remplir les champs vides s'il vous plait ! ");
            }
            else
            {
                // convertissement de la variable budget
                customer.budget = int.Parse(budget);
                //Ajout à la bdd et sauvegarde 
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                dataGrid.Items.Refresh();
                MessageBox.Show("Ca marche");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.customers.Remove(customer);
            customer = db.customers.Find(idtodel);
            db.customers.Remove(customer);
            db.SaveChanges();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = db.customers.ToList();
            MessageBox.Show("Ca marche");
            editLastName.Text = " ";
            editFirstName.Text = " ";
            editMail.Text = " ";
            editPhoneNumber.Text = " ";
            editBudget.Text = " ";
            editSubject.Text = " ";
        }
    }
}
