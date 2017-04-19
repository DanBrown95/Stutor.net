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
    /// Interaction logic for SubjectRequestApproval.xaml
    /// </summary>
    public partial class SubjectRequestApproval : Window
    {
        SubjectRequest _subjectRequest;
        public SubjectRequestApproval(SubjectRequest selectedSubjectRequest)
        {
            InitializeComponent();
            _subjectRequest = selectedSubjectRequest;
        }

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            
            /**
             * Add subject to database
             */

            try
            {
                // Get subjectAreaID from subjectAreaName
                
                int selectedSubjectAreaID;
                InterfaceManager intMgr = new InterfaceManager();

                /**
                 * Retrive subjectAreaID with SubjectAreaName
                 */
                selectedSubjectAreaID = intMgr.GetSubjectAreaIdWithSubjectAreaName(_subjectRequest.subjectAreaName);

                /**
                 * Add new subject
                 */
                if(true == intMgr.AddNewSubject(selectedSubjectAreaID, _subjectRequest.subjectName))
                {
                    
                    /**
                     * Now that the subject is added to the database. Delete the request from subjectRequest table
                     */
                    if(true == intMgr.DeleteSubjectRequest(_subjectRequest.SubjectRequestID))
                    {
                        MessageBox.Show("New subject successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        this.Close();
                    } 

                }
                else
                {
                    MessageBox.Show("Subject Not added. Something went wrong","Oops",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to process request.\n" + ex.Message, "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void btnDiscard_Click(object sender, RoutedEventArgs e)
        {
            /**
             * Delete the subject request from the database
             */
            InterfaceManager intMgr = new InterfaceManager();

            try
            {
                if(true == intMgr.DeleteSubjectRequest(_subjectRequest.SubjectRequestID))
                {
                    MessageBox.Show("Request deleted.", "Success",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    this.Close();
                }
                MessageBox.Show("No request was deleted.", "Oops..", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete the subject request. \n" + ex.Message, "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
