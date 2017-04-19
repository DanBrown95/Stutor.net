using StutorDataObjects;
using StutorLogicLayer;
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
using System.Windows.Shapes;

namespace LoginScreen
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        int _userID;

        public ChangePassword(User user)
        {
            InitializeComponent();
            _userID = user.userID;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // Change password magic here

            var currentPassword = txtCurrentPassword.Password;
            var newPassword = txtNewPassword.Password;
            var confirmPassword = txtConfirmPassword.Password;

            /**
             * Make sure new password isn't the same as the current password
             */
            if (newPassword.Equals(currentPassword))
            {
                MessageBox.Show("New password must be different from the current password","Password must be new",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            /**
             * Make sure new password and confirm password are the same
             */
            else if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Your Password and confirm did not match","oops",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            /**
             * Make sure the fields arent empty
             */
            else if (currentPassword == null || newPassword == null || confirmPassword == null)
            {
                MessageBox.Show("Please fill out the whole form", "Information required", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                /**
                 * Everything is good, change the password
                 */
                try
                {
                    UserManager usrMgr = new UserManager();
                    if (usrMgr.UpdatePasswordHash(_userID, currentPassword, newPassword))
                    {
                        MessageBox.Show("Password Updated!","Success",MessageBoxButton.OK,MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        throw new ApplicationException("Update Failed. Retype password and try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Password not updated \n" + ex.Message,"Oops",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            } //end of else

        }
    }
}
