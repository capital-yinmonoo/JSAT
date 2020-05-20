using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using System.Data;
using System.Data.SqlClient;


namespace JSAT_DL
{
    public class Career_InterViewQuestion3DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Career_InterViewQuestion3DL()
        {
        }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("Sp_InterviewQuestion_SelectAll", connection);
            try
            {
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

        public DataTable SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_CareerInterviewQuestion3_SelectByID", connection);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
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

        public void Insert(DataTable dtCareerintview3)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SP_Career_Interview3_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmd.Parameters.Add("@Interview_Question3_ID ", SqlDbType.Int, 10, "Interview_Question3_ID");
                cmd.Connection.Open();
                sda.InsertCommand = cmd;
                sda.Update(dtCareerintview3);
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

        public Boolean DeleteByCareerID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SP_Career_Interview3_DeleteByCareerID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public int CareerInterviewDelete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                int result = 1;
                cmd.CommandText = "SP_CareerInterview3_DeleteByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Career_ID", id);
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

        public bool CommentInsert(Career_InterView3Entity MJInfo)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;

                cmd.CommandText = "SP_Career_Interview3Comment_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Career_ID", MJInfo.Career_ID);
                cmd.Parameters.Add("@Myanmar_Interviewer_Comment", MJInfo.Myanmar_Interviewer_Comment);
                cmd.Parameters.Add("@Myanmar_Comment_Disadvantage", MJInfo.Myanmar_Interviewer_Comment_Disadvantage);
                cmd.Parameters.AddWithValue("@Japanese_Interviewer_Comment", MJInfo.Japense_Interviewer_Comment);
                cmd.Parameters.AddWithValue("@Japanese_Comment_Disadvantage", MJInfo.Japanese_Interviewerr_Comment_Disadvantage);
                cmd.Parameters.AddWithValue("@CreatedBy", MJInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", MJInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", MJInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", MJInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    MJInfo.ID = id;
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

        public bool CommentUpdate(Career_InterView3Entity MJInfo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Career_Interview3Comment_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", MJInfo.ID);
                cmd.Parameters.AddWithValue("@Career_ID", MJInfo.Career_ID);
                cmd.Parameters.Add("@Myanmar_Interviewer_Comment", MJInfo.Myanmar_Interviewer_Comment);
                cmd.Parameters.Add("@Myanmar_Comment_Disadvantage", MJInfo.Myanmar_Interviewer_Comment_Disadvantage);
                cmd.Parameters.AddWithValue("@Japanese_Interviewer_Comment", MJInfo.Japense_Interviewer_Comment);
                cmd.Parameters.AddWithValue("@Japanese_Comment_Disadvantage", MJInfo.Japanese_Interviewerr_Comment_Disadvantage);
                cmd.Parameters.AddWithValue("@CreatedBy", MJInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", MJInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", MJInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", MJInfo.UpdatedDate);
                da.UpdateCommand = cmd;
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
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

        public Career_InterView3Entity CommentSelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_CareerInterview3_SelectByID", connection);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Career_ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                Career_InterView3Entity MJInfo = new Career_InterView3Entity();
                if (dt.Rows.Count > 0)
                {
                    MJInfo.ID = (int)dt.Rows[0]["ID"];
                    MJInfo.Career_ID = (int)dt.Rows[0]["Career_ID"];
                    MJInfo.Updater = dt.Rows[0]["LogIn_ID"].ToString();
                    MJInfo.UpdatedDate = (DateTime)dt.Rows[0]["UpdatedDate"];
                    MJInfo.Myanmar_Interviewer_Comment = dt.Rows[0]["Myanmar_Interviewer_Comment"].ToString();
                    MJInfo.Myanmar_Interviewer_Comment_Disadvantage = dt.Rows[0]["Myanmar_Interviewer_DisComment"].ToString();
                    MJInfo.Japense_Interviewer_Comment = dt.Rows[0]["Japanese_Interviewer_Comment"].ToString();
                    MJInfo.Japanese_Interviewerr_Comment_Disadvantage = dt.Rows[0]["Japanese_Interviewer_DisComment"].ToString();
                }
                return MJInfo;
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

        public int CommentDeleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                int result = 1;
                cmd.CommandText = "SP_Interview3_DeleteByID";
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
