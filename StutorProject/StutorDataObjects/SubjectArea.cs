using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class SubjectArea
    {
        public int SubjectAreaID { get; set; }

        [Display(Name = "Subject Area")]
        public string SubjectAreaName { get; set; }

    }
}
