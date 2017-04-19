using System;
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
using System.Windows.Shapes;
using StutorLogicLayer;

namespace LoginScreen
{
    /// <summary>
    /// Interaction logic for LoggedIn.xaml
    /// </summary>
    public partial class LoggedIn : Window
    {

        User _user;
        string _role = null;
        InterfaceManager intMgr = new InterfaceManager();
        TutorManager tutorMgr = new TutorManager();

        List<SubjectRequest> _subjectRequests;
        List<TutorApplicant> _tutorApplications;
        List<StudentAppointments> _studentAppointments;
        List<TutorAppointments> _tutorAppointments;
        List<Tutors> _tutors;

        public LoggedIn(User user) 
        {
            InitializeComponent();
            _user = user;
            _role = user.role;

            //Collapse all tabs for startup
            disableAllTabsForStartup();

            // Determine what tabs to enable due to the users role
            switch (_role)
            {
                case "Employee":
                    tabStutors.Visibility = Visibility.Visible;
                    tabStutorRequests.Visibility = Visibility.Visible;
                    tabSubjectRequests.Visibility = Visibility.Visible;

                    //Populate the stutor requests tab as it is the default tab to open on startup for employees
                    _tutorApplications = tutorMgr.GetTutorApplicationList();
                    tabStutorRequests.Focus();

                    break;
                case "Tutor":
                    tabRequestATutor.Visibility = Visibility.Visible;
                    tabMyTutors.Visibility = Visibility.Visible;
                    tabMyStudents.Visibility = Visibility.Visible;

                    //Populate the request a tutor tab as it is the default tab to open on startup
                    PopulateRequestATutorTab();
                    break;
                case "Student":
                    tabRequestATutor.Visibility = Visibility.Visible;
                    tabMyTutors.Visibility = Visibility.Visible;

                    //Populate the request a tutor tab as it is the default tab to open on startup
                    PopulateRequestATutorTab();
                    break;
            }
                


            // Generate the greeting
            lblGreeting.Content = "Welcome " + _user.firstname;

            
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            _user = null;
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
            
            
        }

        private void cmbSubjectArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSubjectComboBox();
        }

        private void PopulateRequestATutorTab()
        {
            // Populate the subjectArea combo box
            var subjectAreas = new List<SubjectArea>();
            InterfaceManager intMgr = new InterfaceManager();

            try
            {
                subjectAreas = intMgr.getListSubjectArea();
            }
            catch (Exception)
            {

                throw;
            }
            
            foreach (var subjectArea in subjectAreas)
            {
                cmbSubjectArea.Items.Add(subjectArea.SubjectAreaName);
            }
            
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

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            List<ClassTutor> classTutors;
            string subjectName = null;

            //Get the selected Subject Item
            try
            {
                subjectName = cmbSubject.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                
            }
            

            if(subjectName == null)
            {
                //No subject Selected
                MessageBox.Show("Please select a subject","No subjects selected", MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }else
            {
                //Retrive list of tutors that tutor that subject
                try
                {
                    // Ensure list view is clear everytime a new subject is selected
                    lstClassTutors.Items.Clear();

                    //Populate the view
                    InterfaceManager intMgr = new InterfaceManager();
                    classTutors = intMgr.getClassTutors(subjectName,_user.userID);
                    
                    foreach (var classTutor in classTutors)
                    {
                        this.lstClassTutors.Items.Add(classTutor);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please try again later" + ex.Message, "Unable to connect to the database server", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void disableAllTabsForStartup()
        {
            tabMyStudents.Visibility = Visibility.Collapsed;
            tabMyTutors.Visibility = Visibility.Collapsed;
            tabRequestATutor.Visibility = Visibility.Collapsed;
            tabStutorRequests.Visibility = Visibility.Collapsed;
            tabSubjectRequests.Visibility = Visibility.Collapsed;
            tabStutors.Visibility = Visibility.Collapsed;
        }

        private void mnuTutorApplication_Click(object sender, RoutedEventArgs e)
        {
            TutorApplication tutorApplication = new TutorApplication(_user);
            tutorApplication.ShowDialog();
        }
  
        private void lstClassTutors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstClassTutors.SelectedItem == null)
            {
                //If no tutor is selected do nothing
            }
            else
            {
                //If tutor is selected show request tutor dialog

                /**
                 * Save requested tutor info
                 */
                var requestedTutor = (ClassTutor)lstClassTutors.SelectedItem;

                // If the user selects themselves
                if(requestedTutor.userID == _user.userID)
                {
                    /**
                    * Show error if user tries to request themselves
                    */
                    MessageBox.Show("You cannot request yourself as a tutor :( ", "Hmm.. I dont think this would be beneficial", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else // If the user did not select themselves as a tutor
                {
                    /**
                    * Open the request a tutor dialog
                    */
                    TutorRequest tutorRequest = new TutorRequest(requestedTutor, _user);
                    tutorRequest.ShowDialog();

                }

                // Refresh the list of tutorAppointments
                _tutorAppointments = tutorMgr.GetListTutorAppointments(_user.userID);
                lvMyTutors.Focus();

            }

        }
        
        private void lvTutorRequests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (lvTutorRequests.SelectedItem == null)
            {
                //If no tutor application is selected do nothing
            }
            else
            {
                //If application is selected show TutorApprovalDialog window
                
                /**
                 * Grab the selected subjectname
                 */
                var tutorApplication = (TutorApplicant)lvTutorRequests.SelectedItem;

                /**
                 * Pass the applicant into the tutorApprovalDialog window to process the applicant
                 */
                TutorApprovalDialog tutorApprovalDialog = new TutorApprovalDialog(tutorApplication);
                tutorApprovalDialog.ShowDialog();

                /**
                * Update the list of tutorApplicants and refresh the view 
                */
                _tutorApplications = tutorMgr.GetTutorApplicationList();
                lvTutorRequests.Items.Refresh();
                lvTutorRequests.Focus();
                /**
                 * Update the list of all tutors
                 */
                _tutors = intMgr.getAllTutors();
                lvAllTutors.Items.Refresh();
                lvAllTutors.Focus();
                
            }
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutwindow = new About();
            aboutwindow.ShowDialog();
        }

        private void btnRequestSubject_Click(object sender, RoutedEventArgs e)
        {
            RequestNewClass requestNewClass = new RequestNewClass();
            requestNewClass.ShowDialog();
            _subjectRequests = intMgr.GetAllSubjectRequests();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _tutorApplications = tutorMgr.GetTutorApplicationList();
            _subjectRequests = intMgr.GetAllSubjectRequests();
            _tutorAppointments = tutorMgr.GetListTutorAppointments(_user.userID);
            _tutors = intMgr.getAllTutors();

            if (_role.Equals("Tutor"))
            {
                _studentAppointments = tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(_user.userID));
            }
            
        }

        private void tabStutorRequests_GotFocus(object sender, RoutedEventArgs e)
        {
            lvTutorRequests.ItemsSource = _tutorApplications;
        }

        private void tabSubjectRequests_GotFocus(object sender, RoutedEventArgs e)
        {
            lvSubjectRequests.ItemsSource = _subjectRequests;
        }

        private void lvSubjectRequests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //If no item is selected do nothing
            if (lvSubjectRequests.SelectedItem == null)
            {
                // Nothing
            }
            else // If subject request is selected
            {
                /**
                 * Grab selected subjectRequest
                 */
                var selectedSubjectRequest = (SubjectRequest)lvSubjectRequests.SelectedItem;


                /**
                 * Instantiate new subject request dialog box
                 */
                SubjectRequestApproval subjectApproval = new SubjectRequestApproval(selectedSubjectRequest);
                subjectApproval.ShowDialog();

                /**
                 * Refresh the subjectRequest list view
                 */
                _subjectRequests = intMgr.GetAllSubjectRequests();
                lvSubjectRequests.Focus();

            }


        }

        private void tabMyStudents_GotFocus(object sender, RoutedEventArgs e)
        {

            lvMyStudents.ItemsSource = _studentAppointments;
            
        }

        private void lvMyStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lvMyStudents.SelectedItem == null)
            {
                // Do nothing
            }
            else
            {
                
                var selectedStudent = (StudentAppointments)lvMyStudents.SelectedItem;
                if (selectedStudent.Status.Equals("Pending"))
                {
                    // Request is a new pending request
                    NewStudentRequest newRequest = new NewStudentRequest(selectedStudent);
                    newRequest.ShowDialog();

                    /**
                     * Refresh the list view
                     */
                    _studentAppointments = tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(_user.userID));
                    lvMyStudents.Focus();
                }else
                {
                    // Request has already been accepted

                    /**
                     * Show the active student dialog window
                     */
                    ActiveStudentRequest activeRequest = new ActiveStudentRequest(selectedStudent);
                    activeRequest.ShowDialog();

                    /**
                     * Refresh the list
                     */
                    _studentAppointments = tutorMgr.GetListStudentAppointments(tutorMgr.GetTutorIDFromUserID(_user.userID));
                    lvMyStudents.Focus();
                }
            }



        }

        private void tabMyTutors_GotFocus(object sender, RoutedEventArgs e)
        {
            lvMyTutors.ItemsSource = _tutorAppointments;
        }

        private void lvMyTutors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //check to see if something is selected
            if(lvMyTutors.SelectedItem == null)
            {
                // Do nothing
            }
            else // there is a valid selection
            {
                /**
                 * get the selected tutor appointment selected
                 */
                var selectedTutor = (TutorAppointments)lvMyTutors.SelectedItem;

                /**
                 * show the active tutor dialog
                 */
                ActiveTutor activeTutorDialog = new ActiveTutor(selectedTutor);
                activeTutorDialog.ShowDialog();

                /**
                 * Refresh the list view
                 */
                _tutorAppointments = tutorMgr.GetListTutorAppointments(_user.userID);
                lvMyTutors.Focus();


            }
        }

        private void mnuChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePasswordDialog = new ChangePassword(_user);
            changePasswordDialog.ShowDialog();
        }

        private void tabStutors_GotFocus(object sender, RoutedEventArgs e)
        {
            lvAllTutors.ItemsSource = _tutors;
        }
    }
    
}
