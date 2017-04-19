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
    /// Interaction logic for NewStudentRequest.xaml
    /// </summary>
    public partial class NewStudentRequest : Window
    {
        StudentAppointments _studentAppointment;
        TutorManager tutorMgr;

        public NewStudentRequest(StudentAppointments studentAppointment)
        {
            InitializeComponent();
            _studentAppointment = studentAppointment;
            
            lblStudent.Content = _studentAppointment.StudentFirstname + " " + _studentAppointment.StudentLastname;
            lblSubjectName.Content = _studentAppointment.SubjectName;
            lblDateTime.Content = _studentAppointment.Day + " " + _studentAppointment.Time;
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            // Delete request from database

            try
            {
                if(true == tutorMgr.DeleteStudentApplication(_studentAppointment.TutoringRequestID))
                {
                    MessageBox.Show("Appointment request deleted successfully", "Appointment Deleted",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to delete the student request", "Unable to delete the request", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong. \n" + ex.Message,"Oops!",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            // Change pending status to Accepted
            try
            {
                tutorMgr = new TutorManager();
                if(true == tutorMgr.AcceptStudentAppointment(_studentAppointment.TutoringRequestID))
                {
                    MessageBox.Show("Appointment Accepted","Success",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to accept student tutor request", "Unable to accept the request", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not accept student request \n" + ex.Message,"Unable to process request",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


    }
}
