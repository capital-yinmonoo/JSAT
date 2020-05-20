using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_ProfileDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Career_ProfileDL()
        {

        }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Profile_SelectAll", connection);
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

        public Career_ProfileEntity SelectByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Profile_SelectByID", connection);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                Career_ProfileEntity careerProfile = new Career_ProfileEntity();
                if (dt != null)
                {
                    careerProfile.Career_Name = dt.Rows[0]["Carrer_Name"].ToString();
                    careerProfile.Career_Code = dt.Rows[0]["Carrer_Code"].ToString();
                    careerProfile.Age = (int)dt.Rows[0]["Age"];
                    careerProfile.GenderID = (int)dt.Rows[0]["GenderID"];
                    careerProfile.Birth_Place = dt.Rows[0]["Birth_Place"].ToString();
                    careerProfile.Dob = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
                    careerProfile.ReligionID = (int)dt.Rows[0]["ReligionID"];
                    careerProfile.Expected_Salary = (decimal)dt.Rows[0]["Expected_Salary"];
                    careerProfile.Working_PlaceID = (int)dt.Rows[0]["Working_PlaceID"];
                    careerProfile.PositionID = (int)dt.Rows[0]["PositionID"];
                    careerProfile.StartDate = (DateTime)dt.Rows[0]["StartDate"];
                    careerProfile.Study_Field = dt.Rows[0]["Study_Field"].ToString();
                    careerProfile.Strong_Weak_Point = dt.Rows[0]["Strong_Weak_Point"].ToString();
                    careerProfile.English = dt.Rows[0]["English"].ToString();
                    careerProfile.Japanese = dt.Rows[0]["Japanese"].ToString();
                    careerProfile.Score = dt.Rows[0]["Score"].ToString();
                }
                return careerProfile;
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

        public bool Insert(Career_ProfileEntity careerProfileInfo, int Option)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Career_Profile_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Carrer_Name", careerProfileInfo.Career_Name);
                cmd.Parameters.AddWithValue("@Carrer_Code", careerProfileInfo.Career_Code);
                cmd.Parameters.AddWithValue("@Age", careerProfileInfo.Age);
                cmd.Parameters.AddWithValue("@GenderID", careerProfileInfo.GenderID);
                cmd.Parameters.AddWithValue("@Birth_Place", careerProfileInfo.Birth_Place);
                cmd.Parameters.AddWithValue("@DOB", careerProfileInfo.Dob);
                cmd.Parameters.AddWithValue("@ReligionID", careerProfileInfo.ReligionID);
                cmd.Parameters.AddWithValue("@Expected_Salary", careerProfileInfo.Expected_Salary);
                cmd.Parameters.AddWithValue("@Working_PlaceID", careerProfileInfo.Working_PlaceID);
                cmd.Parameters.AddWithValue("@PositionID", careerProfileInfo.PositionID);
                cmd.Parameters.AddWithValue("@StartDate", careerProfileInfo.StartDate);
                cmd.Parameters.AddWithValue("@Study_Field", careerProfileInfo.Study_Field);
                cmd.Parameters.AddWithValue("@Strong_Weak_Point", careerProfileInfo.Strong_Weak_Point);
                cmd.Parameters.AddWithValue("@English", careerProfileInfo.English);
                cmd.Parameters.AddWithValue("@Japanese", careerProfileInfo.Japanese);
                cmd.Parameters.AddWithValue("@Score", careerProfileInfo.Score);
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    careerProfileInfo.ID = id;
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

        public bool Update(Career_ProfileEntity careerProfileInfo, int Option)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Career_Profile_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", careerProfileInfo.ID);
                cmd.Parameters.AddWithValue("@Carrer_Name", careerProfileInfo.Career_Name);
                cmd.Parameters.AddWithValue("@Carrer_Code", careerProfileInfo.Career_Code);
                cmd.Parameters.AddWithValue("@Age", careerProfileInfo.Age);
                cmd.Parameters.AddWithValue("@GenderID", careerProfileInfo.GenderID);
                cmd.Parameters.AddWithValue("@Birth_Place", careerProfileInfo.Birth_Place);
                cmd.Parameters.AddWithValue("@DOB", careerProfileInfo.Dob);
                cmd.Parameters.AddWithValue("@ReligionID", careerProfileInfo.ReligionID);
                cmd.Parameters.AddWithValue("@Expected_Salary", careerProfileInfo.Expected_Salary);
                cmd.Parameters.AddWithValue("@Working_PlaceID", careerProfileInfo.Working_PlaceID);
                cmd.Parameters.AddWithValue("@PositionID", careerProfileInfo.PositionID);
                cmd.Parameters.AddWithValue("@StartDate", careerProfileInfo.StartDate);
                cmd.Parameters.AddWithValue("@Study_Field", careerProfileInfo.Study_Field);
                cmd.Parameters.AddWithValue("@Strong_Weak_Point", careerProfileInfo.Strong_Weak_Point);
                cmd.Parameters.AddWithValue("@English", careerProfileInfo.English);
                cmd.Parameters.AddWithValue("@Japanese", careerProfileInfo.Japanese);
                cmd.Parameters.AddWithValue("@Score", careerProfileInfo.Score);
                cmd.Parameters.AddWithValue("@Option", Option);
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

        public int Check_ExistingCode(string careerCode, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SP_Career_Profile_Check_ExistCode";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Carrer_Code", careerCode);
                cmd.Parameters.AddWithValue("@ID", ID);
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SP_Career_Profile_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1) return true;
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

        public bool DeleteAll()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SP_Career_Profile_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", 1); // For returning @result from database stored procedure.
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1) return true;
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

        public DataTable SelectByCriteria(string SearchValue)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Profile_Search", DataConfig.GetConnectionString());
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Search_Value", SqlDbType.VarChar).Value = SearchValue;
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
