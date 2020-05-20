using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Job_InterviewDL
    {
        public Job_InterviewDL() { }

        public bool Insert(Job_InterviewEntity jiInfo)
        {
            try 
            {
                SqlCommand cmd = new SqlCommand("SP_Job_Interview_Update",DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", jiInfo.ID);
                cmd.Parameters.AddWithValue("@Client_Recruitment_ID", jiInfo.Client_Recruitment_ID);
                cmd.Parameters.AddWithValue("@Interview", jiInfo.Interview);
                cmd.Parameters.AddWithValue("@Interview_Date", jiInfo.Interview_Date);
                cmd.Parameters.AddWithValue("@Interview_Result", jiInfo.Interview_Result);
                cmd.Parameters.AddWithValue("@Interview_Result_Date", jiInfo.Interview_Result_Date);
                cmd.Parameters.AddWithValue("@Comment", jiInfo.Comment);
                cmd.Parameters.AddWithValue("@Option",0);
                cmd.Parameters.Add("@result",SqlDbType.Int).Direction= ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Update(Job_InterviewEntity jiInfo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Job_Interview_Update", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", jiInfo.ID);
                cmd.Parameters.AddWithValue("@Client_Recruitment_ID", jiInfo.Client_Recruitment_ID);
                cmd.Parameters.AddWithValue("@Interview", jiInfo.Interview);
                cmd.Parameters.AddWithValue("@Interview_Date", jiInfo.Interview_Date);
                cmd.Parameters.AddWithValue("@Interview_Result", jiInfo.Interview_Result);
                cmd.Parameters.AddWithValue("@Interview_Result_Date", jiInfo.Interview_Result_Date);
                cmd.Parameters.AddWithValue("@Comment", jiInfo.Comment);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public Job_InterviewEntity SelectByClientRecruitmentID(int crid)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Job_Interview_SelectByClientRecruitmentID", DataConfig.GetConnectionString());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.SelectCommand.Parameters.AddWithValue("@Client_Recruitment_ID" , crid);
            sda.SelectCommand.Connection.Open();
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            Job_InterviewEntity jiInfo = new Job_InterviewEntity();
            if (dt.Rows.Count > 0)
            {
                jiInfo.ID = (int)dt.Rows[0]["ID"];
                jiInfo.Client_Recruitment_ID = (int)dt.Rows[0]["Client_Recruitment_ID"];
                jiInfo.Interview = (bool)dt.Rows[0]["Interview"];
                jiInfo.Interview_Date = (DateTime)dt.Rows[0]["Interview_Date"];
                jiInfo.Interview_Result = (bool)dt.Rows[0]["Interview_Result"];
                jiInfo.Interview_Result_Date = (DateTime)dt.Rows[0]["Interview_Result_Date"];
                jiInfo.Comment = dt.Rows[0]["Comment"].ToString();
            }
            return jiInfo;
        }
    }
}
