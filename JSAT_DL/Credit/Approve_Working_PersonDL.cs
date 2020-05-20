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
    public class Approve_Working_PersonDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        Approve_Working_Person_Entity appentity;
        public Approve_Working_PersonDL()
        { }

        public DataTable Select_Start_Working_Person()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Start_Working_Person", connection);
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

        public void Update_Status_And_PaymentTerm(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Update_Status_And_Payment", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_Status_And_PaymentTerm1(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Update_Status_And_Payment1", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PopupSearchName(string name, string startdate, string enddate, string status)
        {
            appentity = new Approve_Working_Person_Entity();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_StartWorking_Search", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Name", name);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Name", null);
                if (!string.IsNullOrWhiteSpace(status))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Status", status);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Status", null);
                if (!string.IsNullOrWhiteSpace(startdate))
                {
                    da.SelectCommand.Parameters.AddWithValue("@StartDate", startdate);
                }
                else { da.SelectCommand.Parameters.AddWithValue("@StartDate", null); }
                if (!string.IsNullOrWhiteSpace(enddate))
                {
                    da.SelectCommand.Parameters.AddWithValue("@EndDate", enddate);
                }
                else { da.SelectCommand.Parameters.AddWithValue("@EndDate", null); }
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
