using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using JSAT_Common.Reference;

namespace JSAT_DL.Reference
{
    public class CountryDL
    {
        public CountryDL()
        { }

        public System.Data.DataTable SelectAll()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Country_SelectAll", DataConfig.connectionString);
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

        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Country_Search_Paging", DataConfig.GetConnectionString());
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

        public CountryEntity SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Country_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                CountryEntity countryInfo = new CountryEntity();
                if (dt.Rows.Count > 0)
                {
                    countryInfo.ID = (int)dt.Rows[0]["ID"];
                    countryInfo.Description = dt.Rows[0]["Description"].ToString();
                }
                return countryInfo;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Insert(CountryEntity countryInfo)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Country_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", countryInfo.ID);               
                cmd.Parameters.AddWithValue("@Description", countryInfo.Description);                
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

        public bool Update(CountryEntity countryInfo)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Country_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", countryInfo.ID);               
                cmd.Parameters.AddWithValue("@Description", countryInfo.Description);
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
                cmd.CommandText = "SP_Country_Delete";
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

        public DataTable Search( string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Country_Search", DataConfig.connectionString);
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

        public int CheckExistingType(string str, int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Country_Check";
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

        public DataTable GetByCompanyID(int Company_id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Company_Type_ID from Company_Type_Country where ID=@Company_Type_ID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@Company_Type_ID", Company_id);
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

        public DataTable GetCompanyType(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Company_Type_ID  From Company_Type_Country where ID=" + id, DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
