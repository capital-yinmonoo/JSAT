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
    public class UserRoleDL
    {
        public UserRoleDL() { }

        public DataTable UserRoleSelect()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_Role_Select", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
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

        public DataTable UserRoleSelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_Role_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
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

        public void UserRoleInsert(DataTable dtUserRole)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.CommandText = "SP_User_Role_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.Add("@UserID", SqlDbType.Int, 10, "UserID");
                cmd.Parameters.Add("@MenuID", SqlDbType.Int, 10, "MenuID");
                cmd.Parameters.Add("@CanRead", SqlDbType.Bit, 2, "CanRead");
                cmd.Parameters.Add("@CanEdit", SqlDbType.Bit, 2, "CanEdit");
                cmd.Parameters.Add("@CanDelete", SqlDbType.Bit, 2, "CanDelete");
                cmd.Connection.Open();
                sda.InsertCommand = cmd;
                sda.Update(dtUserRole);
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

        public int UserRoleDelete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                int result = 1;
                cmd.CommandText = "SP_User_Role_DeleteByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                result = (int)cmd.Parameters["@result"].Value;
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

        public string SelectName(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                string Name = string.Empty;
                cmd.Connection = Connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_User_SelectName";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Connection.Open();
                Name = (string)cmd.ExecuteScalar();
                return Name;
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

        public bool CanRead(int userID, string pageCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_Role_SelectCanRead", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@UserID", userID);
                sda.SelectCommand.Parameters.AddWithValue("@Page_Code", pageCode);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                    return false;
                else
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

        public bool CanSave(int userID, string pageCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_Role_SelectCanEdit", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@UserID", userID);
                sda.SelectCommand.Parameters.AddWithValue("@Page_Code", pageCode);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                    return false;
                else
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

        public bool CanDelete(int userID, string pageCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_User_Role_SelectCanDelete", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@UserID", userID);
                sda.SelectCommand.Parameters.AddWithValue("@Page_Code", pageCode);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.SelectCommand.Dispose();
            }
        }
    }
}
