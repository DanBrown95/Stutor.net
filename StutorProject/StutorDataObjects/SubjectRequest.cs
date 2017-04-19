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

        public string subjectAreaName { get; set; }
      
        public string subjectName { get; set; }

    }
}
