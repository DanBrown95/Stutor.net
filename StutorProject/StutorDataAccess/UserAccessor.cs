using System;
using StutorDataObjects;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataAccess
{
    public class UserAccessor
    {

        public static int VerifyUser(string email, string passwordHash)
        {
            var resultCount = 0;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_authenticate_user";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();
                resultCount = (int)cmd.ExecuteScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return resultCount;


        }

        public static User RetrieveUser(string email)
        {
            User user = null;

            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_retrieve_user_with_email";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters["@Email"].Value = email;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            userID = reader.GetInt32(0),
                            firstname = reader.GetString(1),
                            lastname = reader.GetString(2),
                            email = reader.GetString(3),
                            active = reader.GetBoolean(4),
                            role = reader.GetString(5)
                        };

                    }
                    reader.Close();
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

            return user;
        }

        public static int AddStudent(string firstname, string lastname, string email, string passwordHash, bool active = true)
        {
            int rowsAffected = 0;
            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_add_student";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Firstname", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Firstname"].Value = firstname;
            cmd.Parameters.Add("@Lastname", SqlDbType.NVarChar, 100);
            cmd.Parameters["@Lastname"].Value = lastname;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters["@PasswordHash"].Value = passwordHash;
            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

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

        public static int UpdatePasswordHash(int userID, string currentPasswordhash, string newPasswordHash)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var cmdText = @"sp_update_passwordHash";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@CurrentPasswordHash", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.VarChar, 100);

            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters["@CurrentPasswordHash"].Value = currentPasswordhash;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;


            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return count;


        }



    }
}
