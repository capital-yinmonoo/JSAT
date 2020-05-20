using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_PCSkills_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Boolean Insert_Update(Career_PCSkillsEntity pse, EnumBase.Save option)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_PCSkills_Delete", connection);
            SqlDataAdapter daPcSkills = new SqlDataAdapter();
            SqlCommand cmdPcSkills = new SqlCommand("SP_Career_PCSkills_Insert", connection);
            try
            {
                int result;
                if (option == EnumBase.Save.Update)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Career_ID", pse.CareerId);
                    cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                cmdPcSkills.CommandType = CommandType.StoredProcedure;
                cmdPcSkills.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdPcSkills.Parameters.Add("@PCSkill_ID", SqlDbType.Int, 10, "PCSkill_ID");
                cmdPcSkills.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                daPcSkills.InsertCommand = cmdPcSkills;
                daPcSkills.Update(pse.PcSkills);
                result = Convert.ToInt32(cmdPcSkills.Parameters["@result"].Value);
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
                cmdPcSkills.Connection.Close();
                cmdPcSkills.Dispose();
            }
        }

        public DataTable SelectByID(int careerId)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmdSelect = new SqlCommand("SP_Career_PcSkills_SelectByID", connection);
            try
            {
                cmdSelect.Parameters.AddWithValue("@Career_ID", careerId);
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

        public Boolean Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_PCSkills_Delete", connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 1)
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
    }
}
