using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class IQTest_QuestionDL
    {
        public IQTest_QuestionDL()
        {

        }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_IQTest_Question_SelectAll", DataConfig.connectionString);
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
            finally { da.SelectCommand.Connection.Close(); da.Dispose(); }
        }

        public IQTest_QuestionEntity SelectByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_IQTest_Question_SelectByID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                IQTest_QuestionEntity iqTestQuestionInfo = new IQTest_QuestionEntity();
                if (dt != null)
                {
                    iqTestQuestionInfo.Description = dt.Rows[0]["Description"].ToString();
                    iqTestQuestionInfo.IsDeleted = (bool)dt.Rows[0]["IsDeleted"];
                }
                return iqTestQuestionInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { da.SelectCommand.Connection.Close(); da.Dispose(); }
        }
    }
}
