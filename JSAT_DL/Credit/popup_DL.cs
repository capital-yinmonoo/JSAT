using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JSAT_DL
{
    public class popup_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public popup_DL() { }

        public DataTable SearchByGroupName()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Distinct GroupID,EmpGroupName From Company_Credit", connection);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable PopupSearchGroupName(String name, int code)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Popup_Search_Group_Name", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@Group_Name", name);
                da.SelectCommand.Parameters.AddWithValue("@Group_ID", code);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchByName()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ID,Career_Code,Name from Career_Resume", connection);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable PopupSearchEmployeeName(String name, String code)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Popup_Search_Employee_Name", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                if (!String.IsNullOrWhiteSpace(name))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Name", name);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Name", DBNull.Value);
                }
                if (!String.IsNullOrWhiteSpace(code))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Code", code);
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Employee_Code", DBNull.Value);
                }
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchByEmploeeName()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Employee_Name", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable SearchByJobNo(string cname)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT cr.ID as Job_No,cp.Client_Name FROM Client_Profile cp left JOIN Client_Recruitment cr on cp.ID=cr.ClientID where cp.IsDeleted=0 and cp.Client_Name=@cname", connection);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@cname", cname);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_Employee_Name(string chkid)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_EName", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@id", chkid);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchByGroup()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Group_Name", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable SearchByInvoiceNo()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Invoice_No", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable PopupSearchName(string code)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Search_Invoice_No", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@code", code);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PopupSearchJobCode(string code)
        {
            //try
            //{
            //    SqlDataAdapter da = new SqlDataAdapter("SP_Search_Job_No", connection);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    DataTable dt = new DataTable();
            //    da.SelectCommand.Connection.Open();
            //    da.SelectCommand.Parameters.AddWithValue("@code",code);            
            //    da.Fill(dt);
            //    da.SelectCommand.Connection.Close();
            //    return dt;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT cr.ID as Job_No,cp.Client_Name FROM Client_Profile cp left JOIN Client_Recruitment cr on cp.ID=cr.ClientID where cp.IsDeleted=0 and cr.ID=@code",connection);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@code",code);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable SearchByInvoiceName()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Invoice_Send_Employee_Name", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable SearchByJobName(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Distinct p.ID,p.Description from Position p inner join Client_Recruitment cr on p.ID=cr.PositionID where p.IsDeleted=0 and p.ID=@jobid", connection);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@jobid", id);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchByJobName1()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Distinct ID,Description from Position where IsDeleted=0", connection);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable PopupSearchJobPosition(String name, int code)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Popup_Search_Job_Position", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@Job_Description", name);
                da.SelectCommand.Parameters.AddWithValue("@Job_Code", code);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }

        public DataTable SearchByCName()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Distinct cp.ID,cp.Client_Name as Company_Name From Client_Profile cp inner join Client_Recruitment cr on cp.ID=cr.ClientID where cp.IsDeleted=0", connection);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable PopupSearchCName(String name)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Select_Popup_Search", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@Company_Name", name);
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
