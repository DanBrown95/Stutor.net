using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class StudentAppointments
    {
        public int ID
        {
            get
            {
                return TutoringRequestID;
            }
            set
            {
                TutoringRequestID = value;
            }
        }
        public DateTime Day { get; set; }
        public string Time { get; set; }
        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
        [Display(Name = "Studet First Name")]
        public string StudentFirstname { get; set; }
        [Display(Name = "Student Last Name")]
        public string StudentLastname { get; set; }
        public string Status { get; set; }
        public int TutoringRequestID { get; set; }

    }
}
