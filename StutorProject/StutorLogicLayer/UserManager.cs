using System;
using StutorDataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StutorDataObjects;

namespace StutorLogicLayer
{
    public class UserManager
    {

        internal static string HashSHA256(string source)
        {
            var result = "";

            //this logic is always the same for our purposes
            //create a byte array (8 bit unsigned int)
            byte[] data;


            // cerate a .NET hash provider object
            //these are computationally expensive,
            //so we get rid of them as soon as we can
            //Hash providers are all created with factory methods

            using (SHA256 SHA256Hash = SHA256.Create())
            {
                //Hash the input
                data = SHA256Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // use a stringbuilder to conserve memory 
            var s = new StringBuilder();

            //loop through the bytes creating characters
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            
            result = s.ToString();
            return result;
        }

        public bool AuthenticateUser(string email, string password)
        {
            var result = false;
            
            if (email.Length < 7 || email.Length > 100)
            {
                throw new ApplicationException("Invalid Email Address");
            }
            if (password.Length < 1)
            {
                throw new ApplicationException("Invalid Password");
            }


            try
            {
                result = (1 == UserAccessor.VerifyUser(email, HashSHA256(password)));
                password = null;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }


        public User GetIndividualStudent(string email)
        {
            try
            {
                return UserAccessor.RetrieveUser(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ValidateStudentApplication(string firstname, string lastname, string email, string password)
        {
            int result = 0;

            try
            {
                if(1 == UserAccessor.AddStudent(firstname, lastname, email, HashSHA256(password)))
                {
                    result = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return result;
        }

        public bool UpdatePasswordHash(int userID, string currentPassword, string newPassword)
        {
            var result = false;

            try
            {
                if (1 == UserAccessor.UpdatePasswordHash(userID, HashSHA256(currentPassword), HashSHA256(newPassword)))
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


    }
}
