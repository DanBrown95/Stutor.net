using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StutorDataObjects
{
    public class ClassTutor
    {
        [Key]
        public int userID { get; set; }

        public int subjectID { get; set; }
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}
