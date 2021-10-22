using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadhemni
{
    class DButilis
    {

        public static SqlConnection GetDBConnection()
        {
            string datasource = @" DESKTOP - FFUR08V";

            string database = "Nadhemni";
            string username = "nadhemni";
            string password = "0000";

            return Connection.GetDBConnection(datasource, database,username,password);
        }
    }
}
