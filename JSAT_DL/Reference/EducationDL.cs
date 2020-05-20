using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace JSAT_DL
{
    public class EducationDL
    {
        public EducationDL()
        {

        }

        public DataTable SelectByID(int ID)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Education Where ID=" + ID, DataConfig.connectionString);
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
            SqlCommand cmdInsert = new SqlCommand("SP_Education_Update");
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                cmdInsert.Connection = connection;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.Add("@ProfileID", SqlDbType.Int, 10, "ProfileID");
                cmdInsert.Parameters.Add("@EducationID", SqlDbType.Int, 10, "EducationID");
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
            SqlCommand cmdUpdate = new SqlCommand("SP_Education_Update");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.Connection = connection;
                cmdUpdate.Parameters.Add("@ID", SqlDbType.Int, 10, "ID");
                cmdUpdate.Parameters.Add("@ProfileID", SqlDbType.Int, 10, "ProfileID");
                cmdUpdate.Parameters.Add("@EducationID", SqlDbType.Int, 10, "EducationID");
                da.UpdateCommand = cmdUpdate;
                cmdUpdate.Connection.Open();
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

        public bool DeleteByProfileID(int profileID)
        {
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmd = new SqlCommand("Delete from Profile_Education Where ProfileID=" + profileID, connection);
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
