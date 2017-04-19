using System;
using StutorLogicLayer;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace LoginScreen
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnCancelApplication_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateApplication_Click(object sender, RoutedEventArgs e)
        {
            var firstname = txtFirstname.Text;
            var lastname = txtLastname.Text;
            var email = txtEmail.Text;
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;
            
            //Ensure the fields are not empty or provide a reminder to fill them out
            if(firstname.Length < 1 || Regex.IsMatch(firstname, @"\d") || firstname.Length > 50 || lastname.Length < 1 || lastname.Length > 100 || Regex.IsMatch(lastname, @"\d") || email.Length < 7 || email.Length > 100 || !email.Contains("@") || password.Length < 5 || password.Length > 100 || !password.Equals(confirmPassword))
            {
                if (firstname.Length < 1 || firstname.Length > 50 || Regex.IsMatch(firstname, @"\d"))
                {
                    lblFirstnameMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    lblFirstnameMessage.Visibility = Visibility.Hidden;
                }
                if (lastname.Length < 1 || lastname.Length > 100 || Regex.IsMatch(lastname, @"\d"))
                {
                    lblLastnameMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    lblLastnameMessage.Visibility = Visibility.Hidden;
                }
                
                if (txtEmail.Text.Length < 7 || txtEmail.Text.Length > 100 || !email.Contains("@"))
                {
                    lblEmailMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    lblEmailMessage.Visibility = Visibility.Hidden;
                }
                if (txtPassword.Text.Length < 5 || txtPassword.Text.Length > 100)
                {
                    lblPasswordMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    lblPasswordMessage.Visibility = Visibility.Hidden;
                }
                if (!password.Equals(confirmPassword))
                {
                    lblConfirmPasswordMessage.Visibility = Visibility.Visible;
                }
            }else
            {
                // This is where we save the record to the database
                try
                {
                    if(1 == UserManager.ValidateStudentApplication(firstname, lastname, email, password))
                    {
                        MessageBox.Show("Account Created","Success",MessageBoxButton.OK,MessageBoxImage.Asterisk);
                    }else
                    {
                        MessageBox.Show("Account creation unsuccsesful","Unsuccessful creation",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            
        }


    }
}
