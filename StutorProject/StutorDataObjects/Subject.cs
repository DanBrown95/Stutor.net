using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class Subject
    {
        public int SubjectID { get; set; }

        public int SubjectAreaID { get; set; }

        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
    }
}
