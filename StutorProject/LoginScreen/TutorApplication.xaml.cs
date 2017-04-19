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
    /// Interaction logic for TutorApplication.xaml
    /// </summary>
    public partial class TutorApplication : Window
    {
        User _user = null; 
        public TutorApplication(User user)
        {
            InitializeComponent();

            _user = user;

            //Populate the subject area combo box

            var subjectAreas = new List<SubjectArea>();
            InterfaceManager intMgr = new InterfaceManager();

            try
            {
                subjectAreas = intMgr.getListSubjectArea();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem connecting to the database \n" + ex.Message, "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            foreach (var subjectArea in subjectAreas)
            {
                cmbSubjectArea.Items.Add(subjectArea.SubjectAreaName);
            }
            




        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbSubjectArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSubjectComboBox();
        }

        private void PopulateSubjectComboBox()
        {

            //Clear the subject combo box every time someone selects a different subject Area
            cmbSubject.Items.Clear();

            //Create a list for subjects
            InterfaceManager intMgr = new InterfaceManager();
            List<Subject> subjects = new List<Subject>();
            string subjectAreaName = cmbSubjectArea.SelectedItem.ToString();

            //Populate the list of subjects using the SubjectAreaName
            try
            {
                subjects = intMgr.getListSubject(subjectAreaName);
            }
            catch (Exception)
            {
                MessageBox.Show("Error retrieving your subjects", "Oops", MessageBoxButton.OK);
            }

            //Populate the subject combo box
            foreach (var subject in subjects)
            {
                cmbSubject.Items.Add(subject.SubjectName);
            }

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Verify that both a subjectArea and subject are selected
            if(cmbSubject.SelectedValue == null)
            {
                MessageBox.Show("You did not select a valid subject","Oops",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }else
            {
                // Send application data to database
                try
                {
                    TutorManager tutorMgr = new TutorManager();
                    tutorMgr.manageTutorApplication(_user.userID, cmbSubject.SelectedValue.ToString());

                    // If added successfully
                    MessageBox.Show("Your application has been submitted!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    _user = null;
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem submitting your application " + Environment.NewLine + ex, "Please try again", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
    }
}
