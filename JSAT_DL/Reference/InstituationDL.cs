using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
   public  class InstituationDL
    {
       public InstituationDL() 
       {
       
       }

       public DataTable SelectAll(int IorCRV)
       {
           SqlDataAdapter sda = new SqlDataAdapter("SP_Institution_SelectAll", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.StoredProcedure;
               sda.SelectCommand.Parameters.AddWithValue("@IorCRV", IorCRV);
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

       public InstituationEntity SelectByID(int id)
       {
           SqlDataAdapter sda = new SqlDataAdapter("SP_Instituation_SelectByID", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
               sda.SelectCommand.Parameters.AddWithValue("@ID", id);
               sda.SelectCommand.Connection.Open();
               sda.Fill(dt);
               InstituationEntity InstituationInfo = new InstituationEntity();
               if (dt.Rows.Count > 0)
               {
                   InstituationInfo.ID = (int)dt.Rows[0]["ID"];
                   InstituationInfo.Instituation_ID = (int)dt.Rows[0]["Instituation_ID"];
                   InstituationInfo.Description = dt.Rows[0]["Description"].ToString();

               }
               return InstituationInfo;
           }
           catch (Exception ex) { throw ex; }
           finally { sda.SelectCommand.Connection.Close(); sda.Dispose(); }
       }

       public bool Insert(InstituationEntity InstituationInfo)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               bool result = false;
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               cmd.CommandText = "SP_Instituation_Update";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = connection;
               cmd.Parameters.AddWithValue("@ID", InstituationInfo.Instituation_ID);
               cmd.Parameters.AddWithValue("@Description", InstituationInfo.Description);
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

       public bool InsertInstituation(InstituationEntity InstituationInfo)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               bool result = false;
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               cmd.CommandText = "SP_Instituation_Relation_Insert";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = connection;
               cmd.Parameters.AddWithValue("@ID", InstituationInfo.ID);
               cmd.Parameters.AddWithValue("@Instituation_ID", InstituationInfo.Instituation_ID);
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

       public bool Update(InstituationEntity InstituationInfo)
       {
           SqlCommand cmd = new SqlCommand();
           try
           {
               SqlConnection connection = new SqlConnection(DataConfig.connectionString);
               bool result = false;
               cmd.CommandText = "SP_Instituation_Update";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = connection;
               cmd.Parameters.AddWithValue("@ID", InstituationInfo.ID);
               cmd.Parameters.AddWithValue("@Description", InstituationInfo.Description);
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
               cmd.CommandText = "SP_Instituation_Delete";
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
           SqlDataAdapter sda = new SqlDataAdapter("SP_Instituation_Search", DataConfig.connectionString);
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
           finally { sda.SelectCommand.Connection.Close(); sda.Dispose(); }
       }

       public int CheckExistingType(string str , int id )
       {
           SqlCommand cmd = new SqlCommand();
           SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
           try
           {
               cmd.CommandText = "SP_Instituation_Check";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = Connection;
               cmd.Parameters.AddWithValue("@ID", id);
               cmd.Parameters.AddWithValue("@Description", str);
               cmd.Connection.Open();
               int count = (int)cmd.ExecuteScalar();
               return count;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally { cmd.Connection.Close(); cmd.Dispose(); }
       }

       public int CheckExistingInstituation(int id,int instid)
       {
           SqlCommand cmd = new SqlCommand();
           SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
           try
           {
               cmd.CommandText = "SP_Instituation_Type_Check";
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Connection = Connection;
               cmd.Parameters.AddWithValue("@ID", id);
               cmd.Parameters.AddWithValue("@Instituation_ID", instid);
               cmd.Connection.Open();
               int count = (int)cmd.ExecuteScalar();
               return count;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally { cmd.Connection.Close(); cmd.Dispose(); }
       }

       public DataTable SlectByInstituationID(int Instituation_id)
       {
           SqlDataAdapter sda = new SqlDataAdapter("SP_SelectBy_InstituationID ", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.StoredProcedure;
               sda.SelectCommand.Parameters.AddWithValue("@Instituation_ID", Instituation_id);
               DataTable dt = new DataTable();
               sda.SelectCommand.Connection.Open();
               sda.Fill(dt);
               return dt;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally { sda.SelectCommand.Connection.Close(); sda.Dispose(); }
       }

       public DataTable GetIndustyID(int instituation_id)
       {
           SqlDataAdapter sda = new SqlDataAdapter("Select Instituation_ID from Institution where ID=@Instituation_ID", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.Text;
               sda.SelectCommand.Parameters.AddWithValue("@Instituation_ID", instituation_id);
               DataTable dt = new DataTable();
               sda.SelectCommand.Connection.Open();
               sda.Fill(dt);
               return dt;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally { sda.SelectCommand.Connection.Close(); sda.Dispose();
           }
       }

       public DataTable GetInstitutionAreaSelectByID(int instituation_id)
       {
           SqlDataAdapter sda = new SqlDataAdapter("Select Instituation_Area.ID from Instituation_Area inner JOIN Institution on Instituation_Area.ID=Instituation_ID where Institution.ID=@Instituation_ID and Instituation_Area.IsDeleted=0 and Institution.IsDeleted=0 ", DataConfig.connectionString);
           try
           {
               sda.SelectCommand.CommandType = CommandType.Text;
               sda.SelectCommand.Parameters.AddWithValue("@Instituation_ID", instituation_id);
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
               sda.SelectCommand.Connection.Close(); sda.Dispose();
           }
       }
    }
}

