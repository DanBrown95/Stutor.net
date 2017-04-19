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

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

    }
}
