using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using System.Configuration;

namespace JSAT_DL
{
	public class Payment_ListDL
	{
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Payment_ListDL()
        { }

        public DataTable Select_First_Payment_Person()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_First_Payment_Person", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_Second_Payment_Person()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Second_Payment_Person", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}
