using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;


namespace JSAT_DL
{
    public class ProfileDL
    {
        public ProfileDL()
        {
        }

        public DataTable SelectAll()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Profile_SelectAll", DataConfig.GetConnectionString());
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

        public ProfileEntity SelectByID(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Profile Where ID=" + id, DataConfig.GetConnectionString());
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                ProfileEntity profile = new ProfileEntity();
                if (dt != null)
                {
                    profile.Name = dt.Rows[0]["Name"].ToString();
                    profile.Gender = (int)dt.Rows[0]["Gender"];
                    profile.Telephone_No = dt.Rows[0]["Telephone_No"].ToString();
                    profile.Website = dt.Rows[0]["Website"].ToString();
                    profile.Location = dt.Rows[0]["Location"].ToString();
                    profile.Working_Place = (int)dt.Rows[0]["Working_Place"];
                    profile.Comment = dt.Rows[0]["Comment"].ToString();
                }
                return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(ProfileEntity profileInfo)
        {
            try
            {
                bool result = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Profile_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Name", profileInfo.Name);
                cmd.Parameters.AddWithValue("@Gender", profileInfo.Gender);
                cmd.Parameters.AddWithValue("@Telephone_No", profileInfo.Telephone_No);
                cmd.Parameters.AddWithValue("@Website", profileInfo.Website);
                cmd.Parameters.AddWithValue("@Location", profileInfo.Location);
                cmd.Parameters.AddWithValue("@Working_Place", profileInfo.Working_Place);
                cmd.Parameters.AddWithValue("@Education", profileInfo.Education);
                cmd.Parameters.AddWithValue("@Comment", profileInfo.Comment);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    profileInfo.ID = id;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ProfileEntity profileInfo)
        {
            try
            {
                bool result = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Profile_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", profileInfo.ID);
                cmd.Parameters.AddWithValue("@Name", profileInfo.Name);
                cmd.Parameters.AddWithValue("@Gender", profileInfo.Gender);
                cmd.Parameters.AddWithValue("@Telephone_No", profileInfo.Telephone_No);
                cmd.Parameters.AddWithValue("@Website", profileInfo.Website);
                cmd.Parameters.AddWithValue("@Location", profileInfo.Location);
                cmd.Parameters.AddWithValue("@Working_Place", profileInfo.Working_Place);
                cmd.Parameters.AddWithValue("@Education", profileInfo.Education);
                cmd.Parameters.AddWithValue("@Comment", profileInfo.Comment);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
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
        }

        public int Check_ExistingName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_Check_ExistName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DataConfig.GetConnectionString();
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Connection.Open();
            int count = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            return count;
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Profile Where ID=" + id, DataConfig.GetConnectionString());
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                if (result >= 1) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
