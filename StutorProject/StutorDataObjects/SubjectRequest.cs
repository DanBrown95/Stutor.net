using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class SubjectRequest
    {
        [Key]
        public int SubjectRequestID { get; set; }

        [Display(Name = "Subject Area")]
        public string subjectAreaName { get; set; }
        [Display(Name = "Subject")]
        public string subjectName { get; set; }

    }
}
