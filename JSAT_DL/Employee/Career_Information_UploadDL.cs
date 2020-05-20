using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_Information_UploadDL
    {
        public Career_Information_UploadDL() { }

        public bool Insert(DataTable dt, int Option)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                bool result = true;
                cmd.CommandText = "SP_Career_Information_Upload_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar, 50, "Upload_FileName");
                cmd.Parameters.Add("@UploadtypeID", SqlDbType.Int, 10, "Upload_TypeID");
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                sda.InsertCommand = cmd;
                sda.Update(dt);
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

        public bool Update(DataTable dt, int Option)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                bool result = true;
                cmd.CommandText = "SP_Career_Information_Upload_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar, 50, "Upload_FileName");
                cmd.Parameters.Add("@UploadtypeID", SqlDbType.Int, 10, "Upload_TypeID");
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                da.InsertCommand = cmd;
                da.Update(dt);
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

        public DataTable SelectByCareerID(int id, int option)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Upload_SelectbyID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                da.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = option;
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

        public int CareerUploadDelete(int id)
        {
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {

                int result = 1;
                cmd.CommandText = "SP_Career_Inoformation_DeletebyID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.Add("@Career_ID", id);
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
    }
}
