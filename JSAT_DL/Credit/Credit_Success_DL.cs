using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;
using JSAT_Common;

namespace JSAT_DL
{
    public class Credit_Success_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Credit_Success_DL()
        { }

        public DataTable SelectTotalPaidAmount(string From_Date, string To_Date, string name, int option)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_TotalPaidAmount", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@From_Date", From_Date);
                da.SelectCommand.Parameters.AddWithValue("@To_Date", To_Date);
                da.SelectCommand.Parameters.AddWithValue("@Company_Name", name);
                da.SelectCommand.Parameters.AddWithValue("@Option", option);
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
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
