using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
namespace JSAT_DL
{
    public class InterviewList_DL
    {
        public DataTable SelectbyJobno(int jobno)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetDataByJobno", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@jobno", jobno);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectPersonForInterview(string companyname, int jobno)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetPersonForInterview", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@companyname", companyname);
                da.SelectCommand.Parameters.AddWithValue("@jobno", jobno);
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateComfirm(InterviewList_Entity listentity)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CheckComfirm", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@before", listentity.Before);
                cmd.Parameters.AddWithValue("@theday", listentity.Theday);
                cmd.Parameters.AddWithValue("@career_id", listentity.Career_ID);
                cmd.Parameters.AddWithValue("@jobno", listentity.Jobno);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCareer_Code(string career_code, string companyname, int jobno)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetCareer_Code", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.SelectCommand.Parameters.AddWithValue("@career_code", career_code);
                da.SelectCommand.Parameters.AddWithValue("@companyname", companyname);
                da.SelectCommand.Parameters.AddWithValue("@jobno", jobno);
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


    
       
    

