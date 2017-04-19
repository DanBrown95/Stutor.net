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
    /// Interaction logic for ActiveTutor.xaml
    /// </summary>
    public partial class ActiveTutor : Window
    {
        TutorAppointments _tutorAppointment;
        TutorManager tutorMgr = new TutorManager();
        public ActiveTutor(TutorAppointments tutorAppointment)
        {
            InitializeComponent();

            _tutorAppointment = tutorAppointment;

            lblTutor.Content = _tutorAppointment.TutorFirstname + " " + _tutorAppointment.TutorLastname;
            lblSubjectName.Content = _tutorAppointment.SubjectName;
            lblDateTime.Content = _tutorAppointment.Day + " " + _tutorAppointment.Time;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (true == tutorMgr.DeleteStudentApplication(_tutorAppointment.TutoringRequestID))
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
