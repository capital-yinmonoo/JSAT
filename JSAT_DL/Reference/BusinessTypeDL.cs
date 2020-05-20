using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class BusinessTypeDL
    { 
        public BusinessTypeDL()
        { }

        public DataTable SelectAll()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Business_Type_SelectAll", DataConfig.connectionString);
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

        public BusinessTypeEntity SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Business_Type_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                BusinessTypeEntity business = new BusinessTypeEntity();
                if (dt.Rows.Count > 0)
                {
                    business.ID = (int)dt.Rows[0]["ID"];
                    business.Industry_ID = (int)dt.Rows[0]["IndustryType_ID"];
                    business.Description = dt.Rows[0]["Description"].ToString();
                }
                return business;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Insert(BusinessTypeEntity business)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Business_Type_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", business.ID);
                cmd.Parameters.AddWithValue("@IndustryType_ID", business.Industry_ID);
                cmd.Parameters.AddWithValue("@Description", business.Description);
                cmd.Parameters.AddWithValue("@CreatedBy", business.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", business.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", business.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", business.UpdatedDate);
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

        public bool Update(BusinessTypeEntity business)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Business_Type_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", business.ID);
                cmd.Parameters.AddWithValue("@IndustryType_ID", business.Industry_ID);
                cmd.Parameters.AddWithValue("@Description", business.Description);
                cmd.Parameters.AddWithValue("@CreatedBy", business.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", business.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", business.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", business.UpdatedDate);
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

        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_BusinessType_Search_Paging", DataConfig.GetConnectionString());
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString); 
                cmd.CommandText = "SP_Business_Type_Delete";
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

        public DataTable Search(int id,string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Business_Type_Search", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@IndustryType_ID", id);
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

        public int CheckExistingType(int Industryid,string str,int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Business_Type_Check";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@IndustryType_ID", Industryid);
                cmd.Parameters.AddWithValue("@Description", str);
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

        public DataTable SlectByIndustryID(int Industry_id) 
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_SelectByIndustry_ID ", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@IndustryType_ID", Industry_id);
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

        public DataTable GetByIndustryID(int Industry_id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select IndustryType_ID from Business_Type where ID=@IndustryType_ID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@IndustryType_ID", Industry_id);
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

        public DataTable SelectedbyTypeofBusiness(int index)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_SelectedbyTypeofBusiness", DataConfig.connectionString);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@industrytype", index);
                DataTable dtb = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dtb);
                da.SelectCommand.Connection.Close();
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetIndustryType(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select IndustryType_ID From Business_Type where ID=" + id, DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Selectedbycompanytype(int type)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GetCountry_SelectByID", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID",type);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
