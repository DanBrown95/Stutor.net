using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class Tutors
    {

        public int ID
        {
            get
            {
                return UserID;
            }
            set
            {
                UserID = value;
            }
        }

        public int UserID { get; set; }

        public int TutorID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

    }
}
