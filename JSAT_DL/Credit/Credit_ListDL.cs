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
    public class Credit_ListDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Credit_ListDL()
        {

        }

        public int SelectStartWorkingCount()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Count_For_StartWorking", connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                int count = (int)sda.SelectCommand.ExecuteScalar();
                sda.SelectCommand.Connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SelectOneMonthCount()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Count_For_OneMonth", connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                int count = (int)sda.SelectCommand.ExecuteScalar();
                sda.SelectCommand.Connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SelectTwoMonthCount()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Count_For_TwoMonth", connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                int count = (int)sda.SelectCommand.ExecuteScalar();
                sda.SelectCommand.Connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SelectThreeMonthCount()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Count_For_ThreeMonth", connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                int count = (int)sda.SelectCommand.ExecuteScalar();
                sda.SelectCommand.Connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SelectFPaymentPerson()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Count_For_First_Payment", connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                int count = (int)sda.SelectCommand.ExecuteScalar();
                sda.SelectCommand.Connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SelectSPaymentPerson()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Count_For_Second_Payment", connection);
                DataTable dt = new DataTable();
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                int count = (int)sda.SelectCommand.ExecuteScalar();
                sda.SelectCommand.Connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectAll()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Company_List", connection);
                DataTable dt = new DataTable();
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

        public DataTable PopupSearchName(Credit_List_Entity creditentity)
        {
            try
            {
                int Company_code = 0; int Job_code = 0;
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.ID)))
                {
                    Company_code = Convert.ToInt32(creditentity.ID);
                }
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Jcode)))
                {
                    Job_code = Convert.ToInt32(creditentity.Jcode);
                }
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_CreditList_Search1", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                if (!String.IsNullOrWhiteSpace(creditentity.Name))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Company_Name", creditentity.Name);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Company_Name", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Company_code)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Company_Code", Company_code);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Company_Code", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.EName)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Name", creditentity.EName);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Name", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.EID)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Code", creditentity.EID);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Code", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Jdesc)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Job_Description", creditentity.Jdesc);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Job_Description", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(Job_code)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Job_Code", Job_code);
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Job_Code", DBNull.Value);
                if (!String.IsNullOrWhiteSpace(Convert.ToString(creditentity.Payment)))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Payment_Term", Convert.ToInt32(creditentity.Payment));
                }
                else
                    da.SelectCommand.Parameters.AddWithValue("@Payment_Term", DBNull.Value);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePaymentTerm()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("Update Employee_Credit Set EmpPayment_Term_ID=4 where EmpPayment_Term_ID=3;", connection);
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Connection.Open();
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
