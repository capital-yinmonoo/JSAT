using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class Payment_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Payment_DL()
        { }

        public DataTable SelectDataForTextbox2(string cname, string invoice)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Data", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@cname", cname);
                sda.SelectCommand.Parameters.AddWithValue("@invoice", invoice);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable Select_Company_Credit_ID(string invoice,int comid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Data_By_Invoice", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@invoice", invoice);
                sda.SelectCommand.Parameters.AddWithValue("@cid", comid);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertdata(int companyid, int cid,int eid, string invoice, int status, string invoicedate, int amount)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Payment_Insert", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@invoicedate", invoicedate);
                da.SelectCommand.Parameters.AddWithValue("@status", status);
                da.SelectCommand.Parameters.AddWithValue("@invoice", invoice);
                da.SelectCommand.Parameters.AddWithValue("@cid", cid);
                da.SelectCommand.Parameters.AddWithValue("@eid", eid);
                da.SelectCommand.Parameters.AddWithValue("@companyid", companyid);
                da.SelectCommand.Parameters.AddWithValue("@amount", amount);
                da.SelectCommand.Connection.Open();
                da.SelectCommand.ExecuteNonQuery();
                da.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
