using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using System.Data.SqlClient;
using System.Data;

namespace JSAT_DL
{
    public class Career_WorkingPlaceDL
    {
        public Boolean Insert_Update(Career_WorkingPlaceEntity cwpe, EnumBase.Save option)
        {
            int result;
            if (option == EnumBase.Save.Update)
            {
                SqlCommand cmd = new SqlCommand("SP_Career_WorkingPlace_Delete", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Career_ID", cwpe.CareerId);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            SqlDataAdapter daWorkingPlace = new SqlDataAdapter();
            SqlCommand cmdWorkingPlace = new SqlCommand("SP_Career_WorkingPlace_Insert", DataConfig.GetConnectionString());
            cmdWorkingPlace.CommandType = CommandType.StoredProcedure;
            cmdWorkingPlace.Parameters.Add("@Career_ID", SqlDbType.Int, 10, "Career_ID");
            cmdWorkingPlace.Parameters.Add("@WorkingPlace_ID", SqlDbType.Int, 10, "WorkingPlace_ID");
            cmdWorkingPlace.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
            daWorkingPlace.InsertCommand = cmdWorkingPlace;
            daWorkingPlace.Update(cwpe.WorkingPlace);
            result = Convert.ToInt32(cmdWorkingPlace.Parameters["@result"].Value);
            if (result == 1 || result == 0)
                return true;
            else return false;
        }

        public DataTable SelectByID(int careerId)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Career_WorkingPlace_SelectByID", DataConfig.GetConnectionString());
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

        public Boolean Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_WorkingPlace_Delete", DataConfig.GetConnectionString());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Career_ID",id);
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
