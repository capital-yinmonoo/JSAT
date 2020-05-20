using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using System.Data.SqlClient;
namespace JSAT_DL
{
   public  class JobDescription_DL
    {
       JobDescription_Entity description;
       public JobDescription_DL()
       {
       }

       public DataTable SelectAll()
       {
           SqlDataAdapter da = new SqlDataAdapter("SP_JobDescriptionSelectedALL", DataConfig.connectionString);
           try
           {
               da.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
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

       public DataTable SelectByPosition(int position_id)
       {
           SqlDataAdapter sda = new SqlDataAdapter("SP_SelectByPosition_ID", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.StoredProcedure;
               sda.SelectCommand.Parameters.AddWithValue("@position_id", position_id);
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

       public bool Delete(int id)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               bool result = false;
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               cmd.CommandText = "SP_JobDescription_Delete";
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

       public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
       {
           SqlDataAdapter da = new SqlDataAdapter("SP_JobDescription_Search_Paging", DataConfig.GetConnectionString());
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

       public DataTable Search(int id, string str)
       {
           SqlDataAdapter sda = new SqlDataAdapter("SP_JobDescription_Search", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
               sda.SelectCommand.Parameters.AddWithValue("@position", id);
               sda.SelectCommand.Parameters.AddWithValue("@Description", str);
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

       public int CheckExistingType(int posid, string str,int id)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               cmd.CommandText = "SP_Position_Type_Check";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = connection;
               cmd.Parameters.AddWithValue("@ID", id);
               cmd.Parameters.AddWithValue("@Type", str);
               cmd.Parameters.AddWithValue("@PID", posid);
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

       public bool Update(JobDescription_Entity descriptionentity)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               bool result = false;
               cmd.CommandText = "SP_Description_Update";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = connection;
               cmd.Parameters.AddWithValue("@ID", descriptionentity.ID);
               cmd.Parameters.AddWithValue("@Description", descriptionentity.Description);
               cmd.Parameters.AddWithValue("@PositionID", descriptionentity.PositionID);
               cmd.Parameters.AddWithValue("@CreatedBY", descriptionentity.CreatedBy);
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

       public bool Insert(JobDescription_Entity description)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               bool result = false;
               cmd.CommandText = "SP_Description_Update";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = connection;
               cmd.Parameters.AddWithValue("@ID", description.ID);
               cmd.Parameters.AddWithValue("@Description", description.Description);
               cmd.Parameters.AddWithValue("@PositionID",description.PositionID);
               cmd.Parameters.AddWithValue("@CreatedBY",description.CreatedBy);
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

       public DataTable GetPositionID(int id)
       {
           SqlDataAdapter da = new SqlDataAdapter("Select Position_ID From Job_Description where ID="+id, DataConfig.GetConnectionString());
           da.SelectCommand.CommandType = CommandType.Text;
           DataTable dt=new DataTable();
           da.Fill(dt);
           return dt;
       }
    }
}
