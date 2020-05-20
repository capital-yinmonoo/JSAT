using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class DegreeType_DL
    {
        public DegreeType_DL()
        {

        }

        public bool Insert(DegreeType_Entity degree)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection sqlcon = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = ("SP_Degree_Type_Updated");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@ID", degree.ID);
                cmd.Parameters.AddWithValue("@University_ID", degree.University_ID);
                cmd.Parameters.AddWithValue("@degreedescription", degree.Degree_Description);
                cmd.Parameters.AddWithValue("@CreatedBy", degree.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", degree.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", degree.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", degree.UpdatedDate);
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

        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_DegreeType_Search_Paging", DataConfig.GetConnectionString());
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

        public bool Update(DegreeType_Entity degree)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Degree_Type_Updated";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", degree.ID);
                cmd.Parameters.AddWithValue("@University_ID", degree.University_ID);
                cmd.Parameters.AddWithValue("@degreedescription", degree.Degree_Description);
                cmd.Parameters.AddWithValue("@CreatedBy", degree.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", degree.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", degree.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", degree.UpdatedDate);
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
                cmd.CommandText = "SP_Degree_Type_Delete";
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

        public DataTable Search(int id, string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Degree_Type_Search", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@University_ID", id);
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

        public int CheckExistingType(int institutionid, string str, int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Degree_Type_Check";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@University_ID", institutionid);
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

        public DataTable SelectByInstitutionID(int institution_id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_SelectByUniversity_ID ", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@University_ID", institution_id);
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

        public DegreeType_Entity SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Degree_Type_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                DegreeType_Entity degree = new DegreeType_Entity();
                if (dt.Rows.Count > 0)
                {
                    degree.ID = (int)dt.Rows[0]["Degree_ID"];
                    degree.University_ID = (int)dt.Rows[0]["University_ID"];
                    degree.Degree_Description = dt.Rows[0]["Degree_Description"].ToString();
                }
                return degree;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public DataTable SelectAll()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Degree_Type_SelectAll", DataConfig.connectionString);
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

        public DataTable GetByInstitutionID(int institution_id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select University_ID from Degree_Type where Degree_ID=@University_ID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.Text;
                sda.SelectCommand.Parameters.AddWithValue("@University_ID", institution_id);
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

        public DataTable GetInstituation(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select University_ID,Institution.IsDeleted From Degree_Type left outer join Institution on Institution.ID=Degree_Type.University_ID where Degree_Type.Degree_ID=" + id, DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
