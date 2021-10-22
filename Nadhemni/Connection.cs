using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Nadhemni
{
    class Connection
    {

        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password)
        {
            
            string connString = @"Data Source=DESKTOP-FFUR08V;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(connString);
             return conn;


           

        }


    }
}