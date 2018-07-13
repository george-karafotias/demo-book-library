using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookLibrary.DataAccess
{
    public class Connection
    {
        public static SqlConnection GetDbConnection()
        {
            SqlConnection connection = null;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {

            }
            
            return connection;
        }
    }
}