using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class LogInDL
    {
        public LogInDL()
        {

        }

        public int LogIn(string LogIn_ID, string password)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Profile_LogIn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@LogIn_ID", LogIn_ID);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public UserEntity SelectPassword(string LogIn_ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LogIN_SelectAll", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Parameters.AddWithValue("@LogIn_ID", LogIn_ID);
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                UserEntity userInfo = new UserEntity();
                if (dt.Rows.Count > 0)
                {
                    userInfo.Password = dt.Rows[0]["Password"].ToString();
                    userInfo.User_Name = dt.Rows[0]["User_Name"].ToString();
                    userInfo.Image_FileName = dt.Rows[0]["Image_FileName"].ToString();
                }
                else
                {
                    userInfo.LogIn_ID = string.Empty;
                    userInfo.Password = string.Empty;
                }
                return userInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da.SelectCommand.Connection.Close();
                da.Dispose();
            }
        }

        public bool Check_PageAccess(int id, string url, string pagecode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_PageAccess_Check", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@userID", id);
                sda.SelectCommand.Parameters.AddWithValue("@url", url);
                sda.SelectCommand.Parameters.AddWithValue("@Page_Code", pagecode);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }
    }
}
