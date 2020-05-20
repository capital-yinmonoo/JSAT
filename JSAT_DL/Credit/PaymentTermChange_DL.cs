using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class PaymentTermChange_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public PaymentTermChange_DL()
        { }

        public DataTable SelectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Update_PaymentTerm", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePaymentTerm(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("Update Employee_Credit SET EmpPayment_Term_ID=2 where Employee_ID=@id", connection);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePaymentTerm1(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("Update Employee_Credit SET EmpPayment_Term_ID=5 where Employee_ID=@id", connection);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.ExecuteNonQuery();
                sda.SelectCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_By_EName(int empid)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Name as Employee_Name From Career_Resume Where ID=@id", connection);
                sda.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@id", empid);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByNameForInvoiceReport(string name, int empid)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Report_EmployeeName", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@name", name);
                sda.SelectCommand.Parameters.AddWithValue("@id", empid);
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
