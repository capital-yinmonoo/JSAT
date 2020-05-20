using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;


namespace JSAT_DL
{
    public class Career_Interview2DL
    {
        public Career_Interview2DL()
        {
        }

        public bool Insert(Career_Interview2Entity CareerInt2Info)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_CareerInterview2_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Career_ID", CareerInt2Info.Career_ID);
                cmd.Parameters.AddWithValue("@Company_Name", CareerInt2Info.Company_Name);
                cmd.Parameters.AddWithValue("@Company_Industry", CareerInt2Info.Company_Industry);
                cmd.Parameters.AddWithValue("@Service_Years", Convert.ToInt32(CareerInt2Info.Service_Years));
                cmd.Parameters.AddWithValue("@Job_Description", CareerInt2Info.Job_Description);
                cmd.Parameters.AddWithValue("@Termination_Reason", CareerInt2Info.Termination_Reason);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    CareerInt2Info.ID = id;
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

        public bool Update(Career_Interview2Entity CareerInt2Info)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_CareerInterview2_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", CareerInt2Info.ID);
                cmd.Parameters.AddWithValue("@Career_ID", CareerInt2Info.Career_ID);
                cmd.Parameters.AddWithValue("@Company_Name", CareerInt2Info.Company_Name);
                cmd.Parameters.AddWithValue("@Company_Industry", CareerInt2Info.Company_Industry);
                cmd.Parameters.AddWithValue("@Service_Years", Convert.ToInt32(CareerInt2Info.Service_Years));
                cmd.Parameters.AddWithValue("@Job_Description", CareerInt2Info.Job_Description);
                cmd.Parameters.AddWithValue("@Termination_Reason", CareerInt2Info.Termination_Reason);
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

        public bool DeleteByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Interview2_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == -1)
                    return true;
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

        public Career_Interview2Entity SelectedByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Interview2_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Career_ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                Career_Interview2Entity CareerIntInfo2 = new Career_Interview2Entity();
                if (dt.Rows.Count > 0)
                {
                    CareerIntInfo2.ID = (int)dt.Rows[0]["ID"];
                    CareerIntInfo2.Career_ID = (int)dt.Rows[0]["Career_ID"];
                    CareerIntInfo2.Company_Name = dt.Rows[0]["Company_Name"].ToString();
                    CareerIntInfo2.Company_Industry = dt.Rows[0]["Company_Industry"].ToString();
                    CareerIntInfo2.Service_Years = (int)dt.Rows[0]["Service_Years"];
                    CareerIntInfo2.Job_Description = dt.Rows[0]["Job_Description"].ToString();
                    CareerIntInfo2.Termination_Reason = dt.Rows[0]["Termination_Reason"].ToString();
                }
                return CareerIntInfo2;
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

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Interview2_SelectAll", DataConfig.connectionString);
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
    }
}
