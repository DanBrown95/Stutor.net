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
    /// Interaction logic for ActiveStudentRequest.xaml
    /// </summary>
    public partial class ActiveStudentRequest : Window
    {
        StudentAppointments _studentAppointment;
        TutorManager tutorMgr = new TutorManager();
        public ActiveStudentRequest(StudentAppointments studentAppointment)
        {
            InitializeComponent();
            _studentAppointment = studentAppointment;

            lblStudent.Content = _studentAppointment.StudentFirstname + " " + _studentAppointment.StudentLastname;
            lblSubjectName.Content = _studentAppointment.SubjectName;
            lblDateTime.Content = _studentAppointment.Day + " " + _studentAppointment.Time;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(true == tutorMgr.DeleteStudentApplication(_studentAppointment.TutoringRequestID))
                {
                    MessageBox.Show("Appointment deleted successfully", "Appointment Deleted", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to delete the appointment", "Unable to delete appointment", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong. \n" + ex.Message, "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
