using System;
using StutorLogicLayer;
using StutorDataObjects;
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

namespace LoginScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtEmail.Focus();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            string password = txtPassword.Password;

            
            UserManager usrMgr = new UserManager();
            
            try
            {
                if(usrMgr.AuthenticateUser(email, password))
                {

                    User student;
                    LoggedIn loggedIn = new LoggedIn(student = usrMgr.GetIndividualStudent(email));

                    // Close current login window
                    this.Close();
                    
                    //Open new window
                    loggedIn.ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("Not a valid user." + Environment.NewLine, "We've Encountered a problem.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("We've encountered a problem" + Environment.NewLine + ex.Message, "Oops",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            

        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.ShowDialog();
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
