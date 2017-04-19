using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StutorDataAccess;
using StutorDataObjects;

namespace StutorLogicLayer
{
    public class TutorManager : StutorLogicLayer.ITutorManager
    {

        public void manageTutorApplication(int userID, string subjectName)
        {
            try
            {
                if(1 == TutorAccessor.SubmitTutorApplication(userID, subjectName))
                {

                }
                else
                {
                    throw new ApplicationException("Application not added to database");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TutorApplicant> GetTutorApplicationList()
        {
            List<TutorApplicant> tutorApplications;

            try
            {
                tutorApplications = TutorAccessor.RetrieveTutorApplicants();
            }
            catch (Exception)
            {
                throw;
            }

            return tutorApplications;
        }

        public void AddTutorRole(int userID)
        {
            int rowsAffected = 0;
            try
            {
                rowsAffected = TutorAccessor.ChangeRoleToTutor(userID);
                if(0 == rowsAffected)
                {
                    throw new ApplicationException("Unable to make user a tutor");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteTutorApplication(int userID, string subjectName)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = TutorAccessor.DeleteTutorApplication(userID, subjectName);
                if(0 == rowsAffected)
                {
                    throw new ApplicationException("Tutor application was not deleted");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddTutorToClassTutors(int userID, int subjectID)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = TutorAccessor.AddTutorToClassTutor(userID, subjectID);
                if(0 == rowsAffected)
                {
                    throw new ApplicationException("User was not added to class Tutors");
                }
            }
            catch (Exception)
            {

                throw;
            }


            return rowsAffected;
        }

        public void AddTutorToTutorTable(int userID)
        {
            
            try
            {
                if(0 == TutorAccessor.AddTutorToTutorTable(userID))
                {
                    throw new ApplicationException("Tutor was not added to database.");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool CreateTutoringRequest(int userID, int tutorID, int subjectID, string day, string time)
        {
            var result = false;

            try
            {
                if(1 == TutorAccessor.AddTutoringRequest(userID, tutorID, subjectID, day, time))
                {
                    result = true;
                }
                else
                {
                    throw new ApplicationException("Unable to process tutor request");
                }
            }
            catch (Exception)
            {

                throw;
            }


            return result;
        }

        public int GetTutorIDFromUserID(int userID)
        {
            int tutorID = 0;

            try
            {
                tutorID = TutorAccessor.GetTutorIDFromUserID(userID);
                if(tutorID == 0)
                {
                    throw new ApplicationException("Could not find tutorID");
                }
            }
            catch (Exception)
            {

                throw;
            }


            return tutorID;
        }

        public List<StudentAppointments> GetListStudentAppointments(int tutorID)
        {
            List<StudentAppointments> studentAppointments = null;

            try
            {
                studentAppointments = TutorAccessor.GetStudentAppointments(tutorID);
            }
            catch (Exception)
            {

                throw;
            }

            return studentAppointments;
        }

        public bool AcceptStudentAppointment(int tutoringRequestID)
        {
            bool result = false;

            try
            {
                result = (1 == TutorAccessor.ApproveAppointmentRequest(tutoringRequestID));
                if(result == false)
                {
                    throw new ApplicationException("Unable to accept student request");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool DeleteStudentApplication(int tutoringRequestID)
        {
            bool result = false;

            try
            {
                result = (1 == TutorAccessor.DeleteAppointmentRequest(tutoringRequestID));
                if(result == false)
                {
                    throw new ApplicationException("Appointment request was not deleted");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public List<TutorAppointments> GetListTutorAppointments(int userID)
        {
            List<TutorAppointments> tutorAppointments = null;

            try
            {
                tutorAppointments = TutorAccessor.GetTutorAppointments(userID);
            }
            catch (Exception)
            {

                throw;
            }

            return tutorAppointments;
        }

        public bool EditTutorAppointment(TutorAppointments oldAppointment, TutorAppointments newAppointment)
        {
            bool result = false;

            try
            {
                if (1 == TutorAccessor.EditTutorAppointment(oldAppointment, newAppointment))
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return result;
        }

        public List<Class> GetAllSubjectsTutoredByUserID(int userID)
        {
            List<Class> classes = null;

            try
            {
                classes = TutorAccessor.RetrieveAllClassesTutoredByUserID(userID);
            }
            catch (Exception)
            {
                
                throw;
            }

            
            return classes;
        }
    }
}
