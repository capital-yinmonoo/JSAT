using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_InterviewQuestion1DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Boolean Insert_Update(Career_InterviewQuestion1Entity iq1e, EnumBase.Save option)
        {
            SqlCommand cmdDelete = new SqlCommand("SP_Career_InterviewQuestion1_Delete", connection);
            try
            {
                if (option == EnumBase.Save.Update)
                {
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    int i = BaseLib.Convert_Int(iq1e.Question1.Rows[0]["Carrer_ID"].ToString());
                    cmdDelete.Parameters.AddWithValue("@Carrer_ID", BaseLib.Convert_Int(iq1e.Question1.Rows[0]["Carrer_ID"].ToString()));
                    cmdDelete.Connection.Open();
                    cmdDelete.ExecuteNonQuery();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SP_CareerInterviewQuestion1_Insert", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Carrer_ID", SqlDbType.Int, 10, "Carrer_ID");
                cmd.Parameters.Add("@Interview_Question1_ID", SqlDbType.Int, 10, "Interview_Question1_ID");
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmd;
                da.Update(iq1e.Question1);
                int result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (result == 1)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdDelete.Connection.Close();
                cmdDelete.Dispose();
            }
        }

        public DataTable SelectByID(int careerId)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdSelect = new SqlCommand("SP_CareerInterviewQuestion1_SelectByID", connection);
            try
            {
                cmdSelect.Parameters.AddWithValue("@Carrer_ID", careerId);
                da.SelectCommand = cmdSelect;
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
    }
}
