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
    /// Interaction logic for TutorRequest.xaml
    /// </summary>
    public partial class TutorRequest : Window
    {
        /**
         * The current user
         */
        User _user;

        /**
         * The tutor information
         */
        ClassTutor _classTutor;

        /**
         * The subject requested
         */
        string _subjectName;

        TutorManager tutorMgr = new TutorManager();

        public TutorRequest(ClassTutor classTutor, User user)
        {
            InitializeComponent();
            _classTutor = classTutor;
            _user = user;

            /**
             * Populate the tutor name label
             */
            lblTutorHeader.Content = _classTutor.firstname + " " + _classTutor.lastname;
            

            /**
             * Populate the subjectName label
             */
            InterfaceManager intMgr = new InterfaceManager();
            _subjectName = intMgr.GetSubjectNameWithSubjectId(_classTutor.subjectID);
            lblSubjectName.Content = _subjectName;

            /**
             * Do not allow dates from the past
             */
            datePicker.DisplayDateStart = DateTime.Today;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(datePicker.Text != null && timePicker.Text != null && datePicker.Text != "") // Ensure all fields are filled out
            {
                /**
                 * Required information for tutoring request table
                 */
                int userID = _user.userID;
                int tutorID = _classTutor.userID;
                int subjectID = _classTutor.subjectID;
                string day = datePicker.Text;
                string time = timePicker.Text;

                // Make sure there are no preexisting appointments for this subject at this time and date
                InterfaceManager intMgr = new InterfaceManager();
                int preexistingAppointments = 0;
                preexistingAppointments = intMgr.SearchPreexistingAppointments(userID, subjectID, day, time);

                if(preexistingAppointments > 0) // An appointment already exists
                {
                    MessageBox.Show("You already have an apointment for this class at this time.", "Oops, duplicate appointment", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else // No duplicate appointments exist, submit the request
                {

                    /**
                    * Add record to tutoring request table
                    */
                    try
                    {
                        tutorMgr.CreateTutoringRequest(userID, tutorID, subjectID, day, time);
                            
                        /**
                        * Added successfully, show message
                        */
                        MessageBox.Show("Tutor request has been made!","Success",MessageBoxButton.OK,MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unable to request tutoring \n" + ex.Message,"Unable to request tutor", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }

            }
            else // Some fields are empty, show a message
            {
                MessageBox.Show("Please select a date and time");
            }
        }
    }
}
