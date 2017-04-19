using System;
using StutorDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StutorDataObjects;

namespace StutorLogicLayer
{
    public class InterfaceManager
    {
        public List<SubjectArea> getListSubjectArea()
        {
            
            var subjectArea = InterfaceAccessor.RetrieveListSubjectArea();

            return subjectArea;

        }
        
        public List<Subject> getListSubject(string subjectAreaName)
        {
            List<Subject> subjects;

            try
            {
                subjects = InterfaceAccessor.RetrieveListSubject(subjectAreaName);
            }
            catch (Exception)
            {

                throw;
            }


            return subjects;
        }

        public List<ClassTutor> getClassTutors(string subjectName, int userID)
        {
            List<ClassTutor> classTutors = new List<ClassTutor>();
            try
            {
                classTutors = InterfaceAccessor.RetrieveClassTutors(subjectName,userID);
            }
            catch (Exception)
            {

                throw;
            }
            
            return classTutors;
        }

        public int AddSubjectRequest(string subjectAreaName, string subjectName)
        {
            var rowsAffected = 0;

            try
            {
                rowsAffected = InterfaceAccessor.RequestNewSubject(subjectAreaName, subjectName);
            }
            catch (Exception)
            {

                throw;
            }


            return rowsAffected;
        }

        public List<SubjectRequest> GetAllSubjectRequests()
        {
            try
            {
                return InterfaceAccessor.RetrieveAllSubjectRequests();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetSubjectIdWithSubjectName(string subjectName)
        {
            int subjectID = 0;

            try
            {
                subjectID = InterfaceAccessor.RetrieveSubjectIdWithSubjectName(subjectName);

                if (subjectID == 0)
                {
                    throw new ApplicationException("Cannot retrieve Id for that subject");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return subjectID;
        }

        public int GetSubjectAreaIdWithSubjectAreaName(string subjectAreaName)
        {
            int subjectAreaID = 0;

            try
            {
                subjectAreaID = InterfaceAccessor.RetrieveSubjectAreaIdWithSubjectAreaName(subjectAreaName);

                if (subjectAreaID == 0)
                {
                    throw new ApplicationException("Cannot retrieve Id for that subject");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return subjectAreaID;
        }

        public string GetSubjectNameWithSubjectId(int subjectID)
        {
            string subjectName = null;

            try
            {
                subjectName = InterfaceAccessor.RetrieveSubjectNameWithSubjectId(subjectID);
                if(null == subjectName)
                {
                    throw new ApplicationException("There was an error retrieving your data");
                }
            }
            catch (Exception)
            {

                throw;
            }


            return subjectName;
        }

        public bool AddNewSubject(int subjectAreaID, string subjectName)
        {
            var result = false;

            try
            {
                if(1 == InterfaceAccessor.AddNewSubject(subjectAreaID, subjectName))
                {
                    result = true;
                }else
                {
                    throw new ApplicationException("There was an error while trying to add new subject to the database");
                }
            }
            catch (Exception)
            {

                throw;
            }



            return result;
        }

        public bool DeleteSubjectRequest(int subjectRequestID)
        {
            var result = false;

            try
            {
                result = (1 == InterfaceAccessor.DeleteSubjectRequest(subjectRequestID));
                if(result == false)
                {
                    throw new ApplicationException("Subject Request was not deleted");
                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public List<Tutors> getAllTutors()
        {
            try
            {
                return InterfaceAccessor.GetAllTutors();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SearchPreexistingAppointments(int userID, int subjectID, string day, string time)
        {
            int matchingAppointments = 0;

            try
            {
                matchingAppointments = InterfaceAccessor.SearchPreexistingAppointments(userID, subjectID, day, time);
            }
            catch (Exception)
            {

                throw;
            }


            return matchingAppointments;
        }

    }
}
