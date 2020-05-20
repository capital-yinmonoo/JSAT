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
    public class One_Month_PersonDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public One_Month_PersonDL()
        { }

        public DataTable Select_OneMonth_Working_Person()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_One_Month_Working_Person", connection);
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

        public DataTable Select_TwoMonth_Working_Person()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Two_Month_Working_Person", connection);
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

        public DataTable Select_ThreeMonth_Working_Person()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Three_Month_Working_Person", connection);
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

        public void Update(int id, int option)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_EmployeeApprove", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.SelectCommand.Parameters.AddWithValue("@option", option);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
