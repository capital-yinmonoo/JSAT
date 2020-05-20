using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class Career_IQTestDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Career_IQTestDL()
        {

        }

        public DataTable SelectByCareerProfileID(int Career_ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Career_IQTest Where Career_ID=" + Career_ID, connection);
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
                da.Dispose();
            }
        }

        public void Insert(DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdInsert = new SqlCommand("SP_Career_IQTest_Update", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdInsert.Parameters.Add("@IQTestQuestion_ID", SqlDbType.Int, 10, "IQTestQuestion_ID");
                cmdInsert.Parameters.Add("@IQTest_Answer", SqlDbType.VarChar, 50, "IQTest_Answer");
                cmdInsert.Parameters.Add("@IsCorrect", SqlDbType.Bit, 2, "IsCorrect");
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                da.Update(dt);
            }
            catch (Exception ex)
            {
                throw ex;
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
            SqlCommand cmdUpdate = new SqlCommand("SP_Career_IQTest_Update", connection);
            try
            {
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.Parameters.Add("@ID", SqlDbType.Int, 10, "ID");
                cmdUpdate.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdUpdate.Parameters.Add("@IQTestQuestion_ID", SqlDbType.Int, 10, "IQTestQuestion_ID");
                cmdUpdate.Parameters.Add("@IQTest_Answer", SqlDbType.VarChar, 50, "IQTest_Answer");
                cmdUpdate.Parameters.Add("@IsCorrect", SqlDbType.Bit, 2, "IsCorrect");
                da.UpdateCommand = cmdUpdate;
                cmdUpdate.Connection.Open();
                da.Update(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cmdUpdate.Connection.Close();
                cmdUpdate.Dispose();
            }
        }

        public bool DeleteByProfileID(int Career_ID)
        {
            SqlCommand cmd = new SqlCommand("Delete from Career_IQTest Where Career_ID=" + Career_ID, connection);
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
