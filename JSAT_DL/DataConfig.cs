using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JSAT_DL
{
    public class DataConfig
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        static SqlConnection connection = null;

        static public SqlConnection GetConnectionString()
        {
            try
            {
                if (connection == null)
                    return connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
