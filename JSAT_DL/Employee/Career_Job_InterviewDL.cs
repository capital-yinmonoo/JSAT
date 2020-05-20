using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using System.Data.SqlClient;
using System.Data;

namespace JSAT_DL
{
    public class Career_Job_InterviewDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Boolean Insert_Update(Career_Job_InterviewEntity cje, EnumBase.Save option)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdInsert = new SqlCommand("SP_Career_Job_Interview_Update", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", cje.Id);
                cmdInsert.Parameters.AddWithValue("@Client_RecruitmentID", cje.Client_RecruitmentID);
                cmdInsert.Parameters.AddWithValue("@Career_ID", cje.Career_ID);
                cmdInsert.Parameters.AddWithValue("@Interview", cje.Interview);
                cmdInsert.Parameters.AddWithValue("@Interview_Date", cje.Interview_Date);
                cmdInsert.Parameters.AddWithValue("@Interview_Result", cje.Interview_Result);
                cmdInsert.Parameters.AddWithValue("@Interview_Result_Date", cje.Interview_Result_Date);
                cmdInsert.Parameters.AddWithValue("@Salary", cje.Salary);
                cmdInsert.Parameters.AddWithValue("@Salary_TypeID", cje.Salary_Type);
                cmdInsert.Parameters.AddWithValue("@Comment", cje.Comment);
                cmdInsert.Parameters.AddWithValue("@CreatedBy ", cje.CreatedBy);
                cmdInsert.Parameters.AddWithValue("@CreatedDate", cje.CreatedDate);
                cmdInsert.Parameters.AddWithValue("@UpdatedBy", cje.UpdatedBy);
                cmdInsert.Parameters.AddWithValue("@UpdatedDate", cje.UpdatedDate);
                cmdInsert.Parameters.AddWithValue("@Option", option);
                cmdInsert.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
                int result = Convert.ToInt32(cmdInsert.Parameters["@result"].Value);
                if (result == 1)
                {
                    return true;
                }
                else return false;
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

        public int GetCount(int Rec_ID, int Career_ID)
        {
            SqlCommand myCommand = new SqlCommand("SP_Career_Job_Interview_GetCount", connection);
            try
            {
                myCommand.Parameters.AddWithValue("@Client_RecruitmentID", Rec_ID);
                myCommand.Parameters.AddWithValue("@Career_ID", Career_ID);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Connection.Open();
                int count = BaseLib.Convert_Int(myCommand.ExecuteScalar().ToString());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCommand.Connection.Close();
                myCommand.Dispose();
            }
        }

        public DataTable SelectByID(int Rec_ID, int Career_ID)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdSelect = new SqlCommand("SP_Career_Job_Interview_SelectBy2IDs", connection);
            try
            {
                cmdSelect.Parameters.AddWithValue("@Client_RecruitmentID", Rec_ID);
                cmdSelect.Parameters.AddWithValue("@Career_ID", Career_ID);
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

        public DataTable SelectByCareerID(int cid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SP_Career_Job_Interview_SelectByCareerID", connection);
            try
            {
                cmd.Parameters.AddWithValue("@Career_ID", cid);
                da.SelectCommand = cmd;
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
