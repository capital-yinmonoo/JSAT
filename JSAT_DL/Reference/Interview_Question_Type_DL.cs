using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Interview_Question_Type_DL
    {
        public Interview_Question_Type_DL()
        {
        }

        public DataTable SelectAll()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_QuestionType_SelectAll", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
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

        public Interview_Question_Type_Entity SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_QuestionType_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                Interview_Question_Type_Entity question = new Interview_Question_Type_Entity();
                if (dt.Rows.Count > 0)
                {
                    question.Description = dt.Rows[0]["Interview_Question_Title"].ToString();
                }
                return question;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Insert(Interview_Question_Type_Entity question)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                bool result = false;
                cmd.CommandText = "SP_QuestionTitle_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", question.ID);
                cmd.Parameters.AddWithValue("@Question", question.Description);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 0)
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

        public bool Update(Interview_Question_Type_Entity question)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                bool result = false;
                cmd.CommandText = "SP_QuestionTitle_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", question.ID);
                cmd.Parameters.AddWithValue("@Question", question.Description);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 0)
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Question_Title_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num >= 0)
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

        public DataTable Search(string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Quesiton_Search", DataConfig.connectionString);
            try
            {

                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Question", str);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public int CheckExistingType(string str, int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Question_Check";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Type", str);
                cmd.Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
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
