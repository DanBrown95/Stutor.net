using StutorDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataAccess
{
    public class InterfaceAccessor
    {

        public static List<SubjectArea> RetrieveListSubjectArea()
        {
            List<SubjectArea> subjectAreas = new List<SubjectArea>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_subjectArea";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        subjectAreas.Add(new SubjectArea()
                        {
                            SubjectAreaID = reader.GetInt32(0),
                            SubjectAreaName = reader.GetString(1)
                        });

                    }
                }
                reader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }



            return subjectAreas;
        }
        
        public static List<Subject> RetrieveListSubject(string subjectAreaName)
        {
            List<Subject> subjects = new List<Subject>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_list_subject_with_subjectAreaName";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectAreaName", SqlDbType.NVarChar, 100);
            cmd.Parameters["@SubjectAreaName"].Value = subjectAreaName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject()
                        {
                            SubjectID = reader.GetInt32(0),
                            SubjectAreaID = reader.GetInt32(1),
                            SubjectName = reader.GetString(2)
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            
            return subjects;
        }

        public static List<ClassTutor> RetrieveClassTutors(string subjectName, int userID)
        {
            List<ClassTutor> classTutors = new List<ClassTutor>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_tutors_for_subject_with_subjectName";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100);
            cmd.Parameters["@SubjectName"].Value = subjectName;
            cmd.Parameters.Add("@CurrentUser", SqlDbType.Int);
            cmd.Parameters["@CurrentUser"].Value = userID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        classTutors.Add(new ClassTutor()
                        {
                            userID = reader.GetInt32(0),
                            subjectID = reader.GetInt32(1),
                            firstname = reader.GetString(2),
                            lastname = reader.GetString(3),
                            email = reader.GetString(4)
                        });
                    }
                }
                reader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return classTutors;


        }

        public static int RequestNewSubject(string subjectAreaName, string subjectName)
        {
            var rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_subject_request";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectAreaName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SubjectName",SqlDbType.NVarChar,100);

            cmd.Parameters["@SubjectAreaName"].Value = subjectAreaName;
            cmd.Parameters["@SubjectName"].Value = subjectName;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }finally
            {
                conn.Close();
            }



            return rowsAffected;
        }

        public static List<SubjectRequest> RetrieveAllSubjectRequests()
        {
            List<SubjectRequest> subjectRequests = new List<SubjectRequest>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_all_subject_requests";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        subjectRequests.Add(new SubjectRequest()
                        {
                            subjectAreaName = reader.GetString(0),
                            subjectName = reader.GetString(1),
                            SubjectRequestID = reader.GetInt32(2)
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return subjectRequests;
        }

        public static int RetrieveSubjectIdWithSubjectName(string subjectName)
        {
            int subjectID = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_subjectID_with_subjectName";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100);
            cmd.Parameters["@SubjectName"].Value = subjectName;

            try
            {
                conn.Open();
                subjectID = (int)cmd.ExecuteScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return subjectID;
        }

        public static int RetrieveSubjectAreaIdWithSubjectAreaName(string subjectAreaName)
        {
            int subjectAreaID = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_subjectAreaID_with_subjectAreaName";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectAreaName", SqlDbType.NVarChar, 100);
            cmd.Parameters["@SubjectAreaName"].Value = subjectAreaName;

            try
            {
                conn.Open();
                subjectAreaID = (int)cmd.ExecuteScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return subjectAreaID;
        }

        public static string RetrieveSubjectNameWithSubjectId(int subjectID)
        {
            string subjectName = null;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_subjectName_with_subjectID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectID", SqlDbType.Int);
            cmd.Parameters["@SubjectID"].Value = subjectID;

            try
            {
                conn.Open();

                subjectName = (string)cmd.ExecuteScalar();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return subjectName;
        }

        public static int AddNewSubject(int subjectAreaID, string subjectName)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_new_subject";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectAreaID", SqlDbType.Int);
            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100);

            cmd.Parameters["@SubjectAreaID"].Value = subjectAreaID;
            cmd.Parameters["@SubjectName"].Value = subjectName;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return rowsAffected;
        }

        public static int DeleteSubjectRequest(int subjectRequestID)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_delete_subject_request";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SubjectRequestID", SqlDbType.Int);
            cmd.Parameters["@SubjectRequestID"].Value = subjectRequestID;

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            
            return rowsAffected;
        }

        public static List<Tutors> GetAllTutors()
        {
            List<Tutors> tutors = new List<Tutors>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_all_tutors";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tutors.Add(new Tutors
                        {
                            UserID = reader.GetInt32(0),
                            TutorID = reader.GetInt32(1),
                            Firstname = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Email = reader.GetString(4)
                        });
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return tutors;
        }

        public static int SearchPreexistingAppointments(int userID, int subjectID, string day, string time)
        {
            int matchingAppointments = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = "sp_search_preexisting_appointments";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int);
            cmd.Parameters.Add("@Day", SqlDbType.Date);
            cmd.Parameters.Add("@Time", SqlDbType.NVarChar);
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@SubjectID"].Value = subjectID;
            cmd.Parameters["@Day"].Value = day;
            cmd.Parameters["@Time"].Value = time;

            try
            {
                conn.Open();
                matchingAppointments = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return matchingAppointments;
        } 

    }
}
