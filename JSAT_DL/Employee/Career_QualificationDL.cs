using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_QualificationDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Boolean Insert_Update(Career_QualificationEntity qe,EnumBase.Save option)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_Qualification_Delete", connection);
            SqlDataAdapter daQualification = new SqlDataAdapter();
            SqlCommand cmdQualification = new SqlCommand("SP_CareerQualification_Insert", connection);
            try
            {
                int result;
                if (option == EnumBase.Save.Update)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Career_ID", qe.CareerId);
                    cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                cmdQualification.CommandType = CommandType.StoredProcedure;
                cmdQualification.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdQualification.Parameters.Add("@Qualification_ID", SqlDbType.Int, 10, "Qualification_ID");
                cmdQualification.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                daQualification.InsertCommand = cmdQualification;
                daQualification.Update(qe.Qualification);
                result = Convert.ToInt32(cmdQualification.Parameters["@result"].Value);
                if (result == 1 || result == 0)
                    return true;
                else return false;
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

        public DataTable SelectByID(int careerId)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Career_Qualification_SelectByID", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@Career_ID", careerId);
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
        public DataSet Select_Qualification_Title_Item_ByID(int careerId)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Career_Qualification_2Table_SelectByID", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@Career_ID", careerId);
                da.SelectCommand = cmdSelect;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.SelectCommand.Connection.Open();
                da.Fill(ds);
                da.SelectCommand.Connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_Qualification_Delete", DataConfig.GetConnectionString());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Career_ID", id);
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            int result = (int)cmd.Parameters["@result"].Value;
            if (result >=1)
                return true;
            else return false;
        }
    }
}
