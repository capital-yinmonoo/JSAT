using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Job_Career_InterviewDL
    {
        public Job_Career_InterviewDL()
        {

        }

        public DataTable SelectAll()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Job_Career_Interview_SelectAll", DataConfig.GetConnectionString());
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

        public DataTable SelectByCareerIDAndClientRecruitment(int Client_RecruitmentID, int Client_ID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Job_Career_Interview_SelectByClientIDAndClientRecruitment", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Client_RecruitmentID", SqlDbType.Int).Value = Client_RecruitmentID;
                da.SelectCommand.Parameters.Add("@Client_ID", SqlDbType.Int).Value = Client_ID;
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

        public DataTable SelectByID(int ID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Job_Career_Interview_SelectByID", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
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

        public DataTable SelectByClientRecruitmentID(int ClientRecruitmentID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Job_Interview_SelectByClientRecruitmentID", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Client_Recruitment_ID", SqlDbType.Int).Value = ClientRecruitmentID;
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

        public bool Insert(Job_Career_InterviewEntity jobCareerInterviewInfo, int Option)
        {
            try
            {
                bool result = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Job_Career_Interview_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Client_RecruitmentID", jobCareerInterviewInfo.Client_RecruitmentID);
                cmd.Parameters.AddWithValue("@Career_ID", jobCareerInterviewInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Interview", jobCareerInterviewInfo.Interview);
                cmd.Parameters.AddWithValue("@Interview_Date", jobCareerInterviewInfo.Interview_Date);
                cmd.Parameters.AddWithValue("@Interview_Result", jobCareerInterviewInfo.Interview_Result);
                cmd.Parameters.AddWithValue("@Interview_Result_Date", jobCareerInterviewInfo.Interview_Result_Date);
                cmd.Parameters.AddWithValue("@Salary", jobCareerInterviewInfo.Salary);
                cmd.Parameters.AddWithValue("@Salary_TypeID", jobCareerInterviewInfo.Salary_Type);
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    jobCareerInterviewInfo.ID = id;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Job_Career_InterviewEntity jobCareerInterviewInfo, int Option)
        {
            try
            {
                bool result = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Job_Career_Interview_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", jobCareerInterviewInfo.ID);
                cmd.Parameters.AddWithValue("@Client_RecruitmentID", jobCareerInterviewInfo.Client_RecruitmentID);
                cmd.Parameters.AddWithValue("@Career_ID", jobCareerInterviewInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Interview", jobCareerInterviewInfo.Interview);
                cmd.Parameters.AddWithValue("@Interview_Date", jobCareerInterviewInfo.Interview_Date);
                cmd.Parameters.AddWithValue("@Interview_Result", jobCareerInterviewInfo.Interview_Result);
                cmd.Parameters.AddWithValue("@Interview_Result_Date", jobCareerInterviewInfo.Interview_Result_Date);
                cmd.Parameters.AddWithValue("@Salary", jobCareerInterviewInfo.Salary);
                cmd.Parameters.AddWithValue("@Salary_TypeID", jobCareerInterviewInfo.Salary_Type);
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
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
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Job_Career_Interview_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 1) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DeleteByCareerID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Job_Career_Interview_SelectByCareerID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool DeleteAll()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Job_Career_Interview_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", 1); // For returning @result from database stored procedure.
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                if (result >= 1) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByCriteria(string ClientName, string ClientCode, int? MajorIndstryID, int? SmallIndustryID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Client_Profile_Search", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Client_Name", SqlDbType.VarChar).Value = ClientName;
                da.SelectCommand.Parameters.Add("@Client_Code", SqlDbType.VarChar).Value = ClientCode;
                da.SelectCommand.Parameters.Add("@MajorIndustry", SqlDbType.Int).Value = MajorIndstryID;
                da.SelectCommand.Parameters.Add("@SmallIndustry", SqlDbType.Int).Value = SmallIndustryID;
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

        public int Check_ExistingCode(int ID, int Client_RecruitmentID, int Career_ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_Job_Career_Interview_Check_ExistCode";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DataConfig.GetConnectionString();
            cmd.Parameters.AddWithValue("@Client_RecruitmentID", Client_RecruitmentID);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Career_ID", Career_ID);
            cmd.Connection.Open();
            int count = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            return count;
        }
    }
}
