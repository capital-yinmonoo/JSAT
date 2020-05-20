using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common.Reference;
using JSAT_Common;

namespace JSAT_DL
{
    public class CareerInterview1DL
    {
        public CareerInterview1DL()
        { }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Interview1_SelectAll", DataConfig.connectionString);
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

        public DataTable SelectByID(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                SqlCommand cmdSelect = new SqlCommand("SP_Career_Interview1_SelectByID", connection);
                cmdSelect.Parameters.AddWithValue("@ID", id);
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

        public DataTable SelectByCareerID(int careerId)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                SqlCommand cmdSelect = new SqlCommand("SP_Career_Resume_SelectByCareerID", connection);
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

        public int Insert_Update(CareerInterview1Entity cie, EnumBase.Save option)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmdInsert = new SqlCommand("SP_Career_Resume_Update", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", cie.Id);
                cmdInsert.Parameters.AddWithValue("@Career_ID", cie.CareerId);
                cmdInsert.Parameters.AddWithValue("@Career_Code", cie.CareerCode);
                cmdInsert.Parameters.AddWithValue("@Name", cie.Name);
                cmdInsert.Parameters.AddWithValue("@DOB", cie.Dob);
                cmdInsert.Parameters.AddWithValue("@GenderID", cie.GenderId);
                cmdInsert.Parameters.AddWithValue("@Religion_ID", cie.ReligionId);
                cmdInsert.Parameters.AddWithValue("@Other_Religion", cie.OtherReligion);
                cmdInsert.Parameters.AddWithValue("@Residential_AreaID", cie.AddressId);
                cmdInsert.Parameters.AddWithValue("@Other_Address", cie.OtherAddress);
                cmdInsert.Parameters.AddWithValue("@Salary", cie.Salary);
                cmdInsert.Parameters.AddWithValue("@Working_PlaceID", cie.WorkableAreaId);
                cmdInsert.Parameters.AddWithValue("@Other_WorkingPlace", cie.OtherWorkableArea);
                cmdInsert.Parameters.AddWithValue("@Requested_Division1_ID", cie.Division1);
                cmdInsert.Parameters.AddWithValue("@Requested_Position1_ID", cie.Position1);
                cmdInsert.Parameters.AddWithValue("@Requested_Division2_ID", cie.Division2);
                cmdInsert.Parameters.AddWithValue("@Requested_Position2_ID", cie.Position2);
                cmdInsert.Parameters.AddWithValue("@Requested_Division3_ID", cie.Division3);
                cmdInsert.Parameters.AddWithValue("@Requested_Position3_ID", cie.Position3);
                cmdInsert.Parameters.AddWithValue("@SituationID", cie.SituationId);
                cmdInsert.Parameters.AddWithValue("@Availability_ID", cie.AvailabilityId);
                cmdInsert.Parameters.AddWithValue("@Other_Availability", cie.OtherAvailibality);
                cmdInsert.Parameters.AddWithValue("@Education_ID", cie.EducationId);
                cmdInsert.Parameters.AddWithValue("@Other_Education", cie.OtherEducation);
                cmdInsert.Parameters.AddWithValue("@InstitutionArea_ID", cie.InstituteAreaId);
                cmdInsert.Parameters.AddWithValue("@InstitutionName_ID", cie.InstituteNameId);
                cmdInsert.Parameters.AddWithValue("@Other_Institution", cie.OtherInstitution);
                cmdInsert.Parameters.AddWithValue("@Major_ID", cie.MajorId);
                cmdInsert.Parameters.AddWithValue("@Other_Major", cie.OtherMajor);
                cmdInsert.Parameters.AddWithValue("@Graduation_Date", cie.GraduateDate);
                cmdInsert.Parameters.AddWithValue("@Other_Qualification", cie.OtherQualification);
                cmdInsert.Parameters.AddWithValue("@Other_PCskills", cie.OtherPcSkill);
                cmdInsert.Parameters.AddWithValue("@English_RW_LevelID", cie.EngListeningId);
                cmdInsert.Parameters.AddWithValue("@English_Speaking_LevelID", cie.EngSpeakingId);
                cmdInsert.Parameters.AddWithValue("@Japanese_RW_LevelID", cie.JapListeningId);
                cmdInsert.Parameters.AddWithValue("@Japanese_Speaking_LevelID", cie.JapSpeakingId);
                cmdInsert.Parameters.AddWithValue("@Myanmar_RW_LevelID", cie.MyanListeningId);
                cmdInsert.Parameters.AddWithValue("@Myanmar_Speaking_LevelID", cie.MyanSpeakingId);
                cmdInsert.Parameters.AddWithValue("@Option", option);
                cmdInsert.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
                int result = Convert.ToInt32(cmdInsert.Parameters["@result"].Value);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdInsert.Connection.Close();
                cmdInsert.Dispose();
            }
        }

        public Boolean Delete(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            SqlCommand cmdInsert = new SqlCommand("SP_Career_Interview1_Delete", connection);
            try
            {
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", id);
                cmdInsert.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
                int result = (int)cmdInsert.Parameters["@result"].Value;
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
                cmdInsert.Connection.Close();
                cmdInsert.Dispose();
            }
        }

        public Boolean DeleteByCareerID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Interview_DeleteByCareerID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
    }
}
