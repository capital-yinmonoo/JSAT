using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class Credit_Invoice_Group_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Credit_Invoice_Group_DL()
        { }

        public string AutoGenerate(string prefix, string suffix, bool includeDate)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("sp_AutoGenerate", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("Prefix", prefix);
                sda.SelectCommand.Parameters.AddWithValue("Suffix", suffix);
                sda.SelectCommand.Parameters.AddWithValue("IncludeDate", includeDate);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                if (dt.Rows.Count > 0)
                    return dt.Rows[0][0].ToString();
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertByInvoiceNo1(string gname, string invoiceNo)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Employee_Credit_UpdateInvoiceByID1", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@strString", gname);
                sda.SelectCommand.Parameters.AddWithValue("@Invoice_No", invoiceNo);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByGroupNameForInvoiceReport(string gname)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Report_GroupName", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@gname", gname);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectCompany(int PID,string etype)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Report_Employee", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@ID", PID);
                sda.SelectCommand.Parameters.AddWithValue("@EType", etype);
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

        public DataTable SelectByCompany(int PID)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Report_Employee1", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@ID", PID);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        public void InsertByInvoiceNo(string eid, string invoiceNo)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Employee_Credit_UpdateInvoiceByID", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@strString", eid);
                sda.SelectCommand.Parameters.AddWithValue("@Invoice_No", invoiceNo);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_By_ENameBySingleGroup(string eid)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_By_EName", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@strString", eid);
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

        public DataTable Select_By_Invoice_No(string invoice,int cid)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Data_By_Invoice", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@invoice", invoice);
                sda.SelectCommand.Parameters.AddWithValue("@cid", cid);
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
