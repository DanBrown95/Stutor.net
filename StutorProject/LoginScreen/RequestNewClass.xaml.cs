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
using StutorLogicLayer;
using StutorDataObjects;

namespace LoginScreen
{
    /// <summary>
    /// Interaction logic for RequestNewClass.xaml
    /// </summary>
    public partial class RequestNewClass : Window
    {
        public RequestNewClass()
        {
            InitializeComponent();
            PopulateSubjectAreaComboBox();
        }

        public void PopulateSubjectAreaComboBox()
        {

            try
            {
                /**
                 * Retrieve a list of subject areas from the database
                 */
                InterfaceManager intMgr = new InterfaceManager();
                List<SubjectArea> subjectsAreas = intMgr.getListSubjectArea();

                /**
                 * Populate the combo box
                 */
                foreach (var subjectArea in subjectsAreas)
                {
                    cmbSubjectArea.Items.Add(subjectArea.SubjectAreaName);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error retrieving the list of subject areas.", "Please try again later",MessageBoxButton.OK,MessageBoxImage.Error);
            }


        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            /**
            * Retrieve the requested subject information
            */
            string subjectName = txtSubjectRequest.Text;
            string subjectAreaName = null;

            try
            {
                subjectAreaName = cmbSubjectArea.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {

            }
            

            /**
             * Validate to make sure the entries and selections are valid
             */
             if(subjectAreaName == null || subjectName.Length < 1 || subjectName.Length > 100)
            {
                /**
                 * Bad entry. Send an error message
                 */
                MessageBox.Show("Make sure to select a subject area." + "Subject length must be greater than 0 and less than 100 characters","Please make some corrections",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }else
            {
                /**
                 * Good entry. Add to database
                 */
                try
                {
                    InterfaceManager intMgr = new InterfaceManager();
                    if (1 == intMgr.AddSubjectRequest(subjectAreaName, subjectName))
                    {
                        /**
                         * Request added to database successfully
                         */
                        MessageBox.Show("Subject request has been sent!","Success",MessageBoxButton.OK,MessageBoxImage.Information);
                        /**
                         * Close the dialog box
                         */
                        this.Close();
                    }else
                    {
                        /**
                         * Logic error
                         */
                        MessageBox.Show("Entry was not added","Oops",MessageBoxButton.OK,MessageBoxImage.Error);
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("There was an error while trying to add your subject to the database. Please try again later. \n" + ex.Message,"Oops something went wrong",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }


        }
    }
}
