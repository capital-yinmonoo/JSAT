using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class Client_Recruitment_DetailDL
    {
        public DataTable SelectByRecruitmentID(int rec_ID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Job_Career_Interview_SelectBy_Recruitment_ID", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@Client_RecruitmentID", rec_ID);
                da.SelectCommand = cmdSelect;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(int rec_ID, int career_ID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdInsert = new SqlCommand("SP_Career_Job_Interview_Deleteby2IDs", DataConfig.GetConnectionString());
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@Client_RecruitmentID", rec_ID);
                cmdInsert.Parameters.AddWithValue("@Career_ID", career_ID);
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                int result = cmdInsert.ExecuteNonQuery();
                cmdInsert.Connection.Close();
                if (result == -1)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
