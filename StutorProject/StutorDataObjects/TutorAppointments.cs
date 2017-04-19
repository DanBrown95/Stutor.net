using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class TutorAppointments
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
        [Required(ErrorMessage="You must specify a date 'mm/dd/yyyy'")]
        public DateTime Day { get; set; }
        [Required(ErrorMessage="You must specify a time. '1:35PM'")]
        public string Time { get; set; }
        public string SubjectName { get; set; }
        public string TutorFirstname { get; set; }
        public string TutorLastname { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int TutoringRequestID { get; set; }
        public int TutorID { get; set; }

    }
}
