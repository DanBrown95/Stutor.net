using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class User
    {

        public int userID { get; set; }

        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        public string email { get; set; }

        public string passwordHash { get; set; }

        public bool active { get; set; }

        public string role { get; set; }

    }
}
