using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class UserDL
    {
        public UserDL() { }

        public DataTable SelectAll()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_SelectAll", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    dt.Rows.Add(0, 0, 0, 0, 0);
                }
                return dt;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public DataTable SelectLoggedInUsers()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_SelectLoggedIn", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    dt.Rows.Add(0, 0, 0, 0, 0);
                }
                return dt;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Insert(UserEntity userInfo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_User_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", userInfo.ID);
                cmd.Parameters.AddWithValue("@User_Name", userInfo.User_Name);
                cmd.Parameters.AddWithValue("@LogIn_ID", userInfo.LogIn_ID);
                cmd.Parameters.AddWithValue("@Img_FileName", userInfo.Image_FileName);
                cmd.Parameters.AddWithValue("@Password", userInfo.Password);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public bool Update(UserEntity userInfo)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_User_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", userInfo.ID);
                cmd.Parameters.AddWithValue("@User_Name", userInfo.User_Name);
                cmd.Parameters.AddWithValue("@LogIn_ID", userInfo.LogIn_ID);
                cmd.Parameters.AddWithValue("@Img_FileName", userInfo.Image_FileName);
                cmd.Parameters.AddWithValue("@Password", userInfo.Password);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                }
                return result;
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

        public void UpdateIsLogin(int UserID, int IsLogin)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_User_IsLogin_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", UserID);
                cmd.Parameters.AddWithValue("@IsLogin", IsLogin);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_User_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num >= 0)
                {
                    result = true;
                }
                return result;
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

        public DataTable Search(string str)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_User_Search", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Parameters.AddWithValue("@User_Name", str);
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                return dt;
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

        public UserEntity SelectedByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [User] Where ID=" + id, DataConfig.connectionString);
            try
            {
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                UserEntity userInfo = new UserEntity();
                if (dt != null)
                {
                    userInfo.User_Name = dt.Rows[0]["User_Name"].ToString();
                    userInfo.LogIn_ID = dt.Rows[0]["LogIn_ID"].ToString();
                    userInfo.Password = dt.Rows[0]["Password"].ToString();
                    userInfo.Image_FileName = dt.Rows[0]["Image_FileName"].ToString();
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

        public int Check_LogInID(int id, string logInID)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Check_LogInID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@LogIn_ID", logInID);
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
    }
}
