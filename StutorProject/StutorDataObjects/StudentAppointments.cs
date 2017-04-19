using System;
using System.Collections.Generic;
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
        public string SubjectName { get; set; }
        public string StudentFirstname { get; set; }
        public string StudentLastname { get; set; }
        public string Status { get; set; }
        public int TutoringRequestID { get; set; }

    }
}
