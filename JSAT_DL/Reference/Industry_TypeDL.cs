using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Industry_TypeDL
    {
        public Industry_TypeDL()
        {

        }

        public DataTable SelectAll()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Industry_SelectAll", DataConfig.connectionString);
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

        public Industry_TypeEntity SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Industry_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                Industry_TypeEntity IndustryInfo = new Industry_TypeEntity();
                if (dt.Rows.Count > 0)
                {
                    IndustryInfo.Description = dt.Rows[0]["Description"].ToString();
                }
                return IndustryInfo;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Insert(Industry_TypeEntity IndustryInfo)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                bool result = false;
                cmd.CommandText = "SP_Industry_Type_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", IndustryInfo.ID);
                cmd.Parameters.AddWithValue("@Description", IndustryInfo.Description);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 0)
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

        public bool Update(Industry_TypeEntity IndustryInfo)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                bool result = false;
                cmd.CommandText = "SP_Industry_Type_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", IndustryInfo.ID);
                cmd.Parameters.AddWithValue("@Description", IndustryInfo.Description);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 0)
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_IndustryType_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
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
            SqlDataAdapter sda = new SqlDataAdapter("SP_Industry_Type_Search", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Description", str);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public int CheckExistingType(int id, string str)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Industry_Type_Check";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Type", str);
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

        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Industry_Type_Search_Paging", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Search", search);
            da.SelectCommand.Parameters.AddWithValue("@Sort", sort);
            da.SelectCommand.Parameters.AddWithValue("@StartIndex", startIndex);
            da.SelectCommand.Parameters.AddWithValue("@PageSize", pagesize);
            DataSet ds = new DataSet();
            da.Fill(ds);
            totalrowcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }
    }
}
