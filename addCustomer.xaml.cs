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
    /// Logique d'interaction pour addCostumer.xaml
    /// </summary>
    public partial class addCostumer : Page
    {
        // instanciation d'un nouvel objet db. 
        private Model2 db = new Model2();
        public addCostumer()
        {
            InitializeComponent();
        }

        private void save_customer(object sender, RoutedEventArgs e)
        {

            // instanciation d'un nouveau client
            customers customer = new customers();

            string regexName = @"^[A-Za-zéèàêâôûùïüç-]+$";
            string regexMail = @"^[0-9a-zA-Z.-]+@[0-9a-zA-Z.-]+.[a-zA-Z]{2,4}";
            string regexPhone = @"^[0][0-9]{9}";
            string regexSubject = @"^[A-Za-zéèëêuùçôàö\-' ]+$";
            string regexBudget = @"^[0-9]+$";
            string budget;

            //Ajout des propriétés du nouveau client
            customer.lastName = lastName.Text;
            customer.firstName = firstName.Text;
            customer.mail = address.Text;
            customer.phoneNumber = phoneNumber.Text;
            budget = budgetUser.Text;
            customer.subject = subject.Text;

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
                db.customers.Add(customer);
                db.SaveChanges();
                MessageBox.Show("Ca marche");
                lastName.Text = " ";
                firstName.Text = " ";
                address.Text = " ";
                phoneNumber.Text = " ";
                budgetUser.Text = " ";
                subject.Text = " ";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("customersList.xaml", UriKind.Relative));
        }
    }
}
