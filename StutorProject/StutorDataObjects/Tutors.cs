using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        public string Email { get; set; }

    }
}
