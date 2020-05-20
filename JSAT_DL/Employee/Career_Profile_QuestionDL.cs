using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class Career_Profile_QuestionDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Career_Profile_QuestionDL()
        {

        }

        public DataTable SelectByCareerProfileID(int careerProfileID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Career_Profile_Question Where Career_ID=" + careerProfileID, DataConfig.connectionString);
            try
            {
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
            }
        }

        public void Insert(DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdInsert = new SqlCommand("SP_Career_Profile_Question_Update", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdInsert.Parameters.Add("@ProfileQuestion_ID", SqlDbType.Int, 10, "ProfileQuestion_ID");
                cmdInsert.Connection.Open();
                da.InsertCommand = cmdInsert;
                da.Update(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cmdInsert.Connection.Close();
                cmdInsert.Dispose();
            }
        }

        public void Update(DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdUpdate = new SqlCommand("SP_Career_Profile_Question_Update", connection);
            try
            {
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.Parameters.Add("@ID", SqlDbType.Int, 10, "ID");
                cmdUpdate.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdUpdate.Parameters.Add("@ProfileQuestion_ID", SqlDbType.Int, 10, "ProfileQuestion_ID");
                cmdUpdate.Connection.Open();
                da.UpdateCommand = cmdUpdate;
                da.Update(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdUpdate.Connection.Close();
                cmdUpdate.Dispose();
            }
        }

        public bool DeleteByProfileID(int Career_ID)
        {
            SqlCommand cmd = new SqlCommand("Delete from Career_Profile_Question Where Career_ID=" + Career_ID, DataConfig.GetConnectionString());
            try
            {
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1) return true;
                else
                    return false;
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
