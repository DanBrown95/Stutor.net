using System;
namespace StutorLogicLayer
{
    interface ITutorManager
    {
        bool AcceptStudentAppointment(int tutoringRequestID);
        void AddTutorRole(int userID);
        int AddTutorToClassTutors(int userID, int subjectID);
        void AddTutorToTutorTable(int userID);
        bool CreateTutoringRequest(int userID, int tutorID, int subjectID, string day, string time);
        bool DeleteStudentApplication(int tutoringRequestID);
        void DeleteTutorApplication(int userID, string subjectName);
        System.Collections.Generic.List<StutorDataObjects.StudentAppointments> GetListStudentAppointments(int tutorID);
        System.Collections.Generic.List<StutorDataObjects.TutorAppointments> GetListTutorAppointments(int userID);
        System.Collections.Generic.List<StutorDataObjects.TutorApplicant> GetTutorApplicationList();
        int GetTutorIDFromUserID(int userID);
        void manageTutorApplication(int userID, string subjectName);
    }
}
