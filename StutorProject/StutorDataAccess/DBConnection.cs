using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StutorDataAccess
{
    public static class DBConnection
    {

        public static SqlConnection GetDBConnection()
        {
            var connString = @"Data Source =localhost; Initial Catalog =stutorDB; Integrated Security =True";
            return new SqlConnection(connString);
        }

    }
}
