using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_Common.Employee;


namespace JSAT_DL.Employee
{
    public class Career_AbilityDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Boolean Insert_Update(Career_AbilityEntity cae, EnumBase.Save option)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_Ability_Delete", connection);
            SqlDataAdapter daAbility = new SqlDataAdapter();
            SqlCommand cmdAbility = new SqlCommand("SP_CareerAbility_Insert", connection);
            try
            {
                int result;
                if (option == EnumBase.Save.Update)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Career_ID", cae.CareerId);
                    cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                cmdAbility.CommandType = CommandType.StoredProcedure;
                cmdAbility.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
                cmdAbility.Parameters.Add("@Ability_ID", SqlDbType.Int, 10, "Ability_ID");
                cmdAbility.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmdAbility.Connection.Open();
                daAbility.InsertCommand = cmdAbility;
                daAbility.Update(cae.Ability);
                result = Convert.ToInt32(cmdAbility.Parameters["@result"].Value);
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
                cmdAbility.Connection.Close();
                cmdAbility.Dispose();
            }
        }

        public DataTable SelectByID(int careerId)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Career_Ability_SelectByID", DataConfig.GetConnectionString());
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

        public DataSet Select_Ability_Title_Item_ByID(int careerId)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Career_Ability_2Table_SelectByID", DataConfig.GetConnectionString());
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
            SqlCommand cmd = new SqlCommand("SP_Career_Ability_Delete", DataConfig.GetConnectionString());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Career_ID", id);
            cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            int result = (int)cmd.Parameters["@result"].Value;
            if (result >= 1)
                return true;
            else return false;
        }
    }
}
