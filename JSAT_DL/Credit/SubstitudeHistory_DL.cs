using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;
namespace JSAT_DL
{
    public class SubstitudeHistory_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public SubstitudeHistory_DL()
        { }

        public DataTable Get_Payment_ID(int pid)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_EmpInfo", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@Company_Credit_ID", pid);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
