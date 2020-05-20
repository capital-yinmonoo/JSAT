using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Profile_QuestionDL
    {
        public Profile_QuestionDL()
        {

        }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Profile_Question_SelectAll", DataConfig.connectionString);
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

        public Profile_QuestionEntity SelectByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Profile_Question_SelectByID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                Profile_QuestionEntity ProfileQuestionInfo = new Profile_QuestionEntity();
                if (dt != null)
                {
                    ProfileQuestionInfo.Description = dt.Rows[0]["Description"].ToString();
                    ProfileQuestionInfo.IsDeleted = (bool)dt.Rows[0]["IsDeleted"];
                }
                return ProfileQuestionInfo;
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
