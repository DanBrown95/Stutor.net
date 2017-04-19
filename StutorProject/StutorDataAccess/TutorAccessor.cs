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
    public class TutorAccessor
    {
        public static int SubmitTutorApplication(int userID, string subjectName)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_submit_tutor_application";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100);

            cmd.Parameters["@UserID"].Value = userID;
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

        public static List<TutorApplicant> RetrieveTutorApplicants()
        {
            // list to hold a list of tutor applicants
            var tutorApplications = new List<TutorApplicant>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_tutor_applications";

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
                        tutorApplications.Add(new TutorApplicant()
                        {
                            SubjectName = reader.GetString(0),
                            UserID = reader.GetInt32(1),
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


            return tutorApplications;
        }

        public static int ChangeRoleToTutor(int userID)
        {
            var rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_tutor";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;

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

        public static int DeleteTutorApplication(int userID, string subjectName)
        {
            var rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_delete_tutor_application";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID",SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100);
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


            return rowsAffected;
        }

        public static int AddTutorToClassTutor(int userID, int subjectID)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_tutor_to_class_tutors";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID",SqlDbType.Int);
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@SubjectID"].Value = subjectID;

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

        public static int AddTutorToTutorTable(int userID)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_tutor_to_tutor_table";
            var cmd = new SqlCommand(cmdText,conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;

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

        public static int AddTutoringRequest(int userID, int tutorID, int subjectID, string day, string time)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_tutoring_request";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@TutorID", SqlDbType.Int);
            cmd.Parameters.Add("@SubjectID", SqlDbType.Int);
            cmd.Parameters.Add("@Day", SqlDbType.Date);
            cmd.Parameters.Add("@Time", SqlDbType.NVarChar);
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@TutorID"].Value = tutorID;
            cmd.Parameters["@SubjectID"].Value = subjectID;
            cmd.Parameters["@Day"].Value = day;
            cmd.Parameters["@Time"].Value = time;

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

        public static int GetTutorIDFromUserID(int userID)
        {
            int tutorID = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_tutorID_from_userID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;

            try
            {
                conn.Open();
                tutorID = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return tutorID;
        }

        public static List<StudentAppointments> GetStudentAppointments(int tutorID)
        {
            List<StudentAppointments> studentAppointments = new List<StudentAppointments>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_student_appointments";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TutorID", SqlDbType.Int);
            cmd.Parameters["@TutorID"].Value = tutorID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        studentAppointments.Add(new StudentAppointments
                        {
                            Day = DateTime.Parse(reader.GetDateTime(0).ToString("MM-dd-yyyy")),
                            Time = reader.GetString(1),
                            SubjectName = InterfaceAccessor.RetrieveSubjectNameWithSubjectId(reader.GetInt32(2)),
                            StudentFirstname = reader.GetString(3),
                            StudentLastname = reader.GetString(4),
                            Status = reader.GetString(5),
                            TutoringRequestID = reader.GetInt32(6)
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


            return studentAppointments;
        }

        public static int ApproveAppointmentRequest(int TutoringRequestID)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_accept_student_appointment";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TutoringRequestID", SqlDbType.Int);
            cmd.Parameters["@TutoringRequestID"].Value = TutoringRequestID;

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

        public static int DeleteAppointmentRequest(int TutoringRequestID)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_delete_student_appointment_request";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TutoringRequestID", SqlDbType.Int);
            cmd.Parameters["@TutoringRequestID"].Value = TutoringRequestID;

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

        public static List<TutorAppointments> GetTutorAppointments(int userID)
        {
            List<TutorAppointments> tutorAppointments = new List<TutorAppointments>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_tutors_appointments";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string tutorFirstname = null;
                        string tutorLastname = null;
                        string tutorEmail = null;

                        var conn2 = DBConnection.GetDBConnection();
                        var cmdText2 = @"sp_tutor_details_for_appointment";
                        var cmd2 = new SqlCommand(cmdText2, conn2);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.Add("@TutorID", SqlDbType.Int);
                        cmd2.Parameters["@TutorID"].Value = reader.GetInt32(5);

                        try
                        {
                            conn2.Open();
                            var reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    tutorFirstname = reader2.GetString(0);
                                    tutorLastname = reader2.GetString(1);
                                    tutorEmail = reader2.GetString(2);
                                }
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            conn2.Close();
                        }


                        tutorAppointments.Add(new TutorAppointments
                        {
                            Day = DateTime.Parse(reader.GetDateTime(0).ToString("MM-dd-yyyy")).Date,
                            Time = reader.GetString(1),
                            SubjectName = InterfaceAccessor.RetrieveSubjectNameWithSubjectId(reader.GetInt32(2)),
                            Status = reader.GetString(3),
                            TutoringRequestID = reader.GetInt32(4),
                            TutorID = reader.GetInt32(5),
                            TutorFirstname = tutorFirstname,
                            TutorLastname = tutorLastname,
                            Email = tutorEmail
                            
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


            return tutorAppointments;
        }

        public static int EditTutorAppointment(TutorAppointments oldAppointment, TutorAppointments newAppointment)
        {
            int result = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = "sp_edit_tutoring_request";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@OldTutoringRequestID", SqlDbType.Int);
            cmd.Parameters.Add("@OldDay", SqlDbType.Date);
            cmd.Parameters.Add("@OldTime", SqlDbType.NVarChar);
            cmd.Parameters.Add("@NewDay", SqlDbType.Date);
            cmd.Parameters.Add("@NewTime", SqlDbType.NVarChar);
            cmd.Parameters["@OldTutoringRequestID"].Value = oldAppointment.TutoringRequestID;
            cmd.Parameters["@OldDay"].Value = oldAppointment.Day;
            cmd.Parameters["@OldTime"].Value = oldAppointment.Time;
            cmd.Parameters["@NewDay"].Value = newAppointment.Day;
            cmd.Parameters["@NewTime"].Value = newAppointment.Time;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                throw;
            }


            return result;
        }

        public static List<Class> RetrieveAllClassesTutoredByUserID(int userID)
        {
            List<Class> classes = new List<Class>();

            var conn = DBConnection.GetDBConnection();
            var cmdText = "sp_retrieve_classes_tutored_by_userID";
            
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Class Class = new Class();
                        Class.Name = reader.GetString(0);
                        classes.Add(Class);
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


            return classes;
        }



    }
}
