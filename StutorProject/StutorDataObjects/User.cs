using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataObjects
{
    public class User
    {

        public int userID { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string passwordHash { get; set; }

        public bool active { get; set; }

        public string role { get; set; }

    }
}
