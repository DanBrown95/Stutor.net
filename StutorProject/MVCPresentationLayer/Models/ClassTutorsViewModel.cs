using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPresentationLayer.Models
{
    public class ClassTutorsViewModel
    {

        [Key]
        public int userID { get; set; }

        public int subjectID { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

    }
}