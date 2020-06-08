using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_InformationDL
    {
        public Career_InformationDL()
        {

        }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Information_SelectAll", DataConfig.connectionString);
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

        public DataTable SelectByCareerID(int id, int option)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Information_SelectByID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                da.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = option;
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

        public bool Insert(Career_InformationEntity careerInformationInfo, int Option)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Career_Information_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@Career_ID", careerInformationInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Name", careerInformationInfo.Name);
                cmd.Parameters.AddWithValue("@GenderID", careerInformationInfo.GenderID);
                cmd.Parameters.AddWithValue("@Address", careerInformationInfo.Address);
                cmd.Parameters.AddWithValue("@Age",careerInformationInfo.Age);
                cmd.Parameters.AddWithValue("@Remark", careerInformationInfo.Remark);
                cmd.Parameters.AddWithValue("@Datasheet_Data", careerInformationInfo.Datasheet_Data);
                cmd.Parameters.AddWithValue("@Datasheet_Data2", careerInformationInfo.Datasheet_Data2);
                cmd.Parameters.AddWithValue("@Datasheet_Data3", careerInformationInfo.Datasheet_Data3);
                cmd.Parameters.AddWithValue("@Datasheet_Data4", careerInformationInfo.Datasheet_Data4);
                cmd.Parameters.AddWithValue("@Datasheet_Data5", careerInformationInfo.Datasheet_Data5);
                cmd.Parameters.AddWithValue("@Photo", careerInformationInfo.Photo_Data);
                cmd.Parameters.AddWithValue("@Photo2", careerInformationInfo.Photo_Data2);
                cmd.Parameters.AddWithValue("@Photo3", careerInformationInfo.Photo_Data3);
                cmd.Parameters.AddWithValue("@IDCard_Data", careerInformationInfo.IDCard_Data);
                cmd.Parameters.AddWithValue("@IDCard_Data2", careerInformationInfo.IDCard_Data2);
                cmd.Parameters.AddWithValue("@IDCard_Data3", careerInformationInfo.IDCard_Data3);
                cmd.Parameters.AddWithValue("@Credential_Data", careerInformationInfo.Credential_Data);
                cmd.Parameters.AddWithValue("@Credential_Data2", careerInformationInfo.Credential_Data2);
                cmd.Parameters.AddWithValue("@Credential_Data3", careerInformationInfo.Credential_Data3);
                cmd.Parameters.AddWithValue("@Credential_Data4", careerInformationInfo.Credential_Data4);
                cmd.Parameters.AddWithValue("@Credential_Data5", careerInformationInfo.Credential_Data5);
                cmd.Parameters.AddWithValue("@Credential_Data6", careerInformationInfo.Credential_Data6);
                cmd.Parameters.AddWithValue("@Credential_Data7", careerInformationInfo.Credential_Data7);
                cmd.Parameters.AddWithValue("@Japanese_Data", careerInformationInfo.Japanese_Data);
                cmd.Parameters.AddWithValue("@Japanese_Data2", careerInformationInfo.Japanese_Data2);
                cmd.Parameters.AddWithValue("@Japanese_Data3", careerInformationInfo.Japanese_Data3);
                cmd.Parameters.AddWithValue("@Graduation_Data", careerInformationInfo.Graduation_Data);
                cmd.Parameters.AddWithValue("@Graduation_Data2", careerInformationInfo.Graduation_Data2);
                cmd.Parameters.AddWithValue("@Graduation_Data3", careerInformationInfo.Graduation_Data3);
                cmd.Parameters.AddWithValue("@Qualification_Data", careerInformationInfo.Qualification_Data);
                cmd.Parameters.AddWithValue("@Qualification_Data2", careerInformationInfo.Qualification_Data2);
                cmd.Parameters.AddWithValue("@Qualification_Data3", careerInformationInfo.Qualification_Data3);
                cmd.Parameters.AddWithValue("@LabourCard_Data", careerInformationInfo.LabourCard_Data);
                cmd.Parameters.AddWithValue("@LabourCard_Data2", careerInformationInfo.LabourCard_Data2);
                cmd.Parameters.AddWithValue("@LabourCard_Data3", careerInformationInfo.LabourCard_Data3);
                cmd.Parameters.AddWithValue("@CreatedBy", careerInformationInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", careerInformationInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", careerInformationInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", careerInformationInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@IsDeleted", careerInformationInfo.IsDeleted);
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    careerInformationInfo.ID = id;
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

        public bool Update(Career_InformationEntity careerInformationInfo, int Option)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Career_Information_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", careerInformationInfo.ID);
                cmd.Parameters.AddWithValue("@Career_ID", careerInformationInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Name", careerInformationInfo.Name);
                cmd.Parameters.AddWithValue("@GenderID", careerInformationInfo.GenderID);
                cmd.Parameters.AddWithValue("@Address", careerInformationInfo.Address);
                cmd.Parameters.AddWithValue("@Age", careerInformationInfo.Age);
                cmd.Parameters.AddWithValue("@Remark", careerInformationInfo.Remark);
                cmd.Parameters.AddWithValue("@Datasheet_Data", careerInformationInfo.Datasheet_Data);
                cmd.Parameters.AddWithValue("@Datasheet_Data2", careerInformationInfo.Datasheet_Data2);
                cmd.Parameters.AddWithValue("@Datasheet_Data3", careerInformationInfo.Datasheet_Data3);
                cmd.Parameters.AddWithValue("@Datasheet_Data4", careerInformationInfo.Datasheet_Data4);
                cmd.Parameters.AddWithValue("@Datasheet_Data5", careerInformationInfo.Datasheet_Data5);
                cmd.Parameters.AddWithValue("@Photo", careerInformationInfo.Photo_Data);
                cmd.Parameters.AddWithValue("@Photo2", careerInformationInfo.Photo_Data2);
                cmd.Parameters.AddWithValue("@Photo3", careerInformationInfo.Photo_Data3);
                cmd.Parameters.AddWithValue("@IDCard_Data", careerInformationInfo.IDCard_Data);
                cmd.Parameters.AddWithValue("@IDCard_Data2", careerInformationInfo.IDCard_Data2);
                cmd.Parameters.AddWithValue("@IDCard_Data3", careerInformationInfo.IDCard_Data3);
                cmd.Parameters.AddWithValue("@Credential_Data", careerInformationInfo.Credential_Data);
                cmd.Parameters.AddWithValue("@Credential_Data2", careerInformationInfo.Credential_Data2);
                cmd.Parameters.AddWithValue("@Credential_Data3", careerInformationInfo.Credential_Data3);
                cmd.Parameters.AddWithValue("@Credential_Data4", careerInformationInfo.Credential_Data4);
                cmd.Parameters.AddWithValue("@Credential_Data5", careerInformationInfo.Credential_Data5);
                cmd.Parameters.AddWithValue("@Credential_Data6", careerInformationInfo.Credential_Data6);
                cmd.Parameters.AddWithValue("@Credential_Data7", careerInformationInfo.Credential_Data7);
                cmd.Parameters.AddWithValue("@Japanese_Data", careerInformationInfo.Japanese_Data);
                cmd.Parameters.AddWithValue("@Japanese_Data2", careerInformationInfo.Japanese_Data2);
                cmd.Parameters.AddWithValue("@Japanese_Data3", careerInformationInfo.Japanese_Data3);
                cmd.Parameters.AddWithValue("@Graduation_Data", careerInformationInfo.Graduation_Data);
                cmd.Parameters.AddWithValue("@Graduation_Data2", careerInformationInfo.Graduation_Data2);
                cmd.Parameters.AddWithValue("@Graduation_Data3", careerInformationInfo.Graduation_Data3);
                cmd.Parameters.AddWithValue("@Qualification_Data", careerInformationInfo.Qualification_Data);
                cmd.Parameters.AddWithValue("@Qualification_Data2", careerInformationInfo.Qualification_Data2);
                cmd.Parameters.AddWithValue("@Qualification_Data3", careerInformationInfo.Qualification_Data3);
                cmd.Parameters.AddWithValue("@LabourCard_Data", careerInformationInfo.LabourCard_Data);
                cmd.Parameters.AddWithValue("@LabourCard_Data2", careerInformationInfo.LabourCard_Data2);
                cmd.Parameters.AddWithValue("@LabourCard_Data3", careerInformationInfo.LabourCard_Data3);
                cmd.Parameters.AddWithValue("@CreatedBy", careerInformationInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", careerInformationInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", careerInformationInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", careerInformationInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@IsDeleted", careerInformationInfo.IsDeleted);
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

        public Boolean DeleteByCareerId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Information_DeleteByCareerID";
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Information_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int result = (int)cmd.Parameters["@result"].Value;
                if (result >= 0) return true;
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
            SqlConnection connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Career_Information_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
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

        public Career_InformationEntity SelectByID(int id, int option)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Career_Information_SelectByID", DataConfig.connectionString);
            try
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                da.SelectCommand.Parameters.Add("@Option", SqlDbType.Int).Value = option;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                Career_InformationEntity careerInformation = new Career_InformationEntity();
                if (dt.Rows.Count > 0)
                {
                    careerInformation.Career_ID = (int)dt.Rows[0]["Career_ID"];
                    careerInformation.Name = dt.Rows[0]["Name"].ToString();
                    careerInformation.GenderID = (int)dt.Rows[0]["GenderID"];
                    careerInformation.Address = dt.Rows[0]["Address"].ToString();
                    careerInformation.Remark = dt.Rows[0]["Remark"].ToString();
                    careerInformation.Datasheet_Data = dt.Rows[0]["Datasheet_Data"].ToString();
                    careerInformation.Datasheet_Data2 = dt.Rows[0]["Datasheet_Data2"].ToString();
                    careerInformation.Datasheet_Data3 = dt.Rows[0]["Datasheet_Data3"].ToString();
                    careerInformation.Datasheet_Data4 = dt.Rows[0]["Datasheet_Data4"].ToString();
                    careerInformation.Datasheet_Data5 = dt.Rows[0]["Datasheet_Data5"].ToString();
                    careerInformation.Photo_Data = dt.Rows[0]["Photo"].ToString();
                    careerInformation.Photo_Data2 = dt.Rows[0]["Photo2"].ToString();
                    careerInformation.Photo_Data3 = dt.Rows[0]["Photo3"].ToString();
                    careerInformation.IDCard_Data = dt.Rows[0]["IDCard_Data"].ToString();
                    careerInformation.IDCard_Data2 = dt.Rows[0]["IDCard_Data2"].ToString();
                    careerInformation.IDCard_Data3 = dt.Rows[0]["IDCard_Data3"].ToString();
                    careerInformation.Credential_Data = dt.Rows[0]["Credential_Data"].ToString();
                    careerInformation.Credential_Data2 = dt.Rows[0]["Credential_Data2"].ToString();
                    careerInformation.Credential_Data3 = dt.Rows[0]["Credential_Data3"].ToString();
                    careerInformation.Credential_Data4 = dt.Rows[0]["Credential_Data4"].ToString();
                    careerInformation.Credential_Data5 = dt.Rows[0]["Credential_Data5"].ToString();
                    careerInformation.Credential_Data6 = dt.Rows[0]["Credential_Data6"].ToString();
                    careerInformation.Credential_Data7 = dt.Rows[0]["Credential_Data7"].ToString();
                    careerInformation.Japanese_Data = dt.Rows[0]["Japanese_Data"].ToString();
                    careerInformation.Japanese_Data2 = dt.Rows[0]["Japanese_Data2"].ToString();
                    careerInformation.Japanese_Data3 = dt.Rows[0]["Japanese_Data3"].ToString();
                    careerInformation.Graduation_Data = dt.Rows[0]["Graduation_Data"].ToString();
                    careerInformation.Graduation_Data2 = dt.Rows[0]["Graduation_Data2"].ToString();
                    careerInformation.Graduation_Data3 = dt.Rows[0]["Graduation_Data3"].ToString();
                    careerInformation.Qualification_Data = dt.Rows[0]["Qualification_Data"].ToString();
                    careerInformation.Qualification_Data2 = dt.Rows[0]["Qualification_Data2"].ToString();
                    careerInformation.Qualification_Data3 = dt.Rows[0]["Qualification_Data3"].ToString();
                    careerInformation.LabourCard_Data = dt.Rows[0]["LabourCard_Data"].ToString();
                    careerInformation.LabourCard_Data2 = dt.Rows[0]["LabourCard_Data2"].ToString();
                    careerInformation.LabourCard_Data3 = dt.Rows[0]["LabourCard_Data3"].ToString();
                    careerInformation.IsDeleted = (bool)dt.Rows[0]["IsDeleted"];
                }
                return careerInformation;
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
