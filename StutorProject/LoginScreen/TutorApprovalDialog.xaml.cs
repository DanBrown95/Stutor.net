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
    /// Interaction logic for TutorApprovalDialog.xaml
    /// </summary>
    public partial class TutorApprovalDialog : Window
    {
        /**
         * The applicants details
         */
        TutorApplicant _applicant;

        TutorManager tutorMgr = new TutorManager();

        /**
         * The requested subjectID to tutor
         */
        int _subjectID;



        public TutorApprovalDialog(TutorApplicant applicant)
        {
            InitializeComponent();
            _applicant = applicant;
            lblApplicant.Content = _applicant.Firstname + " " + _applicant.Lastname;
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                /**
                 * Initialize an interface manager
                 */
                InterfaceManager intMgr = new InterfaceManager();

                /**
                 * Retrieve the subjectID from the subjectName
                 */
                try
                {
                   _subjectID = intMgr.GetSubjectIdWithSubjectName(_applicant.SubjectName);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Something went wrong.. \n" + ex.Message, "Please try again later", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                
                try
                {
                    
                    /**
                    * Add the user to the class Tutors table
                    */
                    tutorMgr.AddTutorToClassTutors(_applicant.UserID, _subjectID);

                    /**
                     * Add the user to the tutor table
                     */
                    tutorMgr.AddTutorToTutorTable(_applicant.UserID);


                    /**
                     * Now that the user has successfully been made a class tutor.
                     * Update the users role to tutor
                     */
                    tutorMgr.AddTutorRole(_applicant.UserID);

                    /**
                     * Now remove the user from the tutor application table
                     */
                    tutorMgr.DeleteTutorApplication(_applicant.UserID, _applicant.SubjectName);

                    /**
                    * If everything worked show a success message
                    */
                    MessageBox.Show("Application Approved!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                

            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /**
                 * Remove the user from the tutor Application table
                 */
                TutorManager tutorMgr = new TutorManager();
                tutorMgr.DeleteTutorApplication(_applicant.UserID, _applicant.SubjectName);

                /**
                 * Show a completion message then close the dialog box
                 */
                MessageBox.Show("Application Denied.");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
