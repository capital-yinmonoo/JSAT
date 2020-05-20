using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class ClientRecruitmentDL
    {
        public ClientRecruitmentDL()
        {

        }

        public DataTable SearchData(Client_RecruitmentEntity.SearchRecruitment sr)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Client_Recruitment_Search", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@Name", sr.Name);
                cmdSelect.Parameters.AddWithValue("@ClientID", sr.ClientNo);
                cmdSelect.Parameters.AddWithValue("@RecuritmentID", sr.RecruitmentNo);
                cmdSelect.Parameters.AddWithValue("@PersonInCharge", sr.PersonInCharge);
                cmdSelect.Parameters.AddWithValue("@Telephone_No", sr.ContactPhoneNo);
                cmdSelect.Parameters.AddWithValue("@Position", sr.PositionID);
                cmdSelect.Parameters.AddWithValue("@JpRW", sr.JpRW);
                cmdSelect.Parameters.AddWithValue("@JpRWcheck", sr.JpRWcheck);
                cmdSelect.Parameters.AddWithValue("@JpSpeaking", sr.JpSpeaking);
                cmdSelect.Parameters.AddWithValue("@JpSpeakingcheck", sr.JpSpeakingcheck);
                cmdSelect.Parameters.AddWithValue("@EngRW", sr.EngRW);
                cmdSelect.Parameters.AddWithValue("@EngRWcheck", sr.EngRWcheck);
                cmdSelect.Parameters.AddWithValue("@EngSpeaking", sr.EngSpeaking);
                cmdSelect.Parameters.AddWithValue("@EngSpeakingcheck", sr.EngSpeakingcheck);
                cmdSelect.Parameters.AddWithValue("@MnRW", sr.MnRW);
                cmdSelect.Parameters.AddWithValue("@MnRWcheck", sr.MnRWcheck);
                cmdSelect.Parameters.AddWithValue("@MnSpeaking", sr.MnSpeaking);
                cmdSelect.Parameters.AddWithValue("@MnSpeakingcheck", sr.MnSpeakingcheck);
                cmdSelect.Parameters.AddWithValue("@Wanted", sr.Wanted);
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

        public DataTable SelectAll()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Client_Recruitment_SelectAll", DataConfig.GetConnectionString());
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

        public DataTable SelectByID(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Client_Recruitment_SelectByID", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@ID", id);
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

        public DataTable SelectByProfileID(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Client_Recruitment_SelectByClient_ProfileID", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@ID", id);
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

        public Boolean Insert_Update(Client_RecruitmentEntity crEntity, EnumBase.Save option)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdInsert = new SqlCommand("SP_Client_Recruitment_Update", DataConfig.GetConnectionString());
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", crEntity.Id);
                cmdInsert.Parameters.AddWithValue("@jobno", crEntity.Jobno);
                cmdInsert.Parameters.AddWithValue("@ClientID", crEntity.ClientId);
                cmdInsert.Parameters.AddWithValue("@Submission_Date", crEntity.SubDate);
                cmdInsert.Parameters.AddWithValue("@DepartmentID", crEntity.MajorIndustryId);
                cmdInsert.Parameters.AddWithValue("@PositionID", crEntity.SmallIndustryId);
                cmdInsert.Parameters.AddWithValue("@Other_Position", crEntity.OtherIndustry);
                cmdInsert.Parameters.AddWithValue("@PostID", crEntity.PostId);
                cmdInsert.Parameters.AddWithValue("@Other_Post", crEntity.OtherPost);
                cmdInsert.Parameters.AddWithValue("@GenderID", crEntity.GenderId);
                cmdInsert.Parameters.AddWithValue("@Salary_TypeID", crEntity.SalaryTypeId);
                cmdInsert.Parameters.AddWithValue("@Salary_From", crEntity.SalaryFrom);
                cmdInsert.Parameters.AddWithValue("@Salary_To", crEntity.SalaryTo);
                cmdInsert.Parameters.AddWithValue("@Salary_Format", crEntity.Salary_Format);
                cmdInsert.Parameters.AddWithValue("@Other_Salary", crEntity.OtherSalary);
                cmdInsert.Parameters.AddWithValue("@Working_PlaceID", crEntity.WorkingPlaceId);
                cmdInsert.Parameters.AddWithValue("@Other_WorkingPlace", crEntity.OtherWorkingPlace);
                cmdInsert.Parameters.AddWithValue("@Day_ServiceID", crEntity.DayServiceId);
                cmdInsert.Parameters.AddWithValue("@Starting", crEntity.Starting);
                cmdInsert.Parameters.AddWithValue("@Closing", crEntity.Closing);
                cmdInsert.Parameters.AddWithValue("@LanguageID", crEntity.LanguageId);
                cmdInsert.Parameters.AddWithValue("@English_RW_LevelID", crEntity.EnglishRWId);
                cmdInsert.Parameters.AddWithValue("@English_Speaking_LevelID", crEntity.EnglishSpeakID);
                cmdInsert.Parameters.AddWithValue("@Japanese_RW_LevelID", crEntity.JapanRWId);
                cmdInsert.Parameters.AddWithValue("@Japanese_Speaking_LevelID", crEntity.JapanSpeakID);
                cmdInsert.Parameters.AddWithValue("@Myanmar_RW_LevelID", crEntity.MyanmarRWId);
                cmdInsert.Parameters.AddWithValue("@Myanmar_Speaking_LevelID", crEntity.MyanmarSpeakID);
                cmdInsert.Parameters.AddWithValue("@To_English_RW_LevelID", crEntity.ToEnglishRWID);
                cmdInsert.Parameters.AddWithValue("@To_English_Speaking_LevelID", crEntity.ToEnglishspeakID);
                cmdInsert.Parameters.AddWithValue("@To_Japanese_RW_LevelID", crEntity.ToJapanRWID);
                cmdInsert.Parameters.AddWithValue("@To_Japanese_Speaking_LevelID", crEntity.ToJapanspeakID);
                cmdInsert.Parameters.AddWithValue("@To_Myanmar_RW_LevelID", crEntity.ToMyanmarRWID);
                cmdInsert.Parameters.AddWithValue("@To_Myanmar_Speaking_LevelID", crEntity.ToMyanmarspeakID);
                cmdInsert.Parameters.AddWithValue("@Age_From", crEntity.AgeFrom);
                cmdInsert.Parameters.AddWithValue("@Age_To", crEntity.AgeTo);
                cmdInsert.Parameters.AddWithValue("@Person_Type", crEntity.PersonInChargeId);
                cmdInsert.Parameters.AddWithValue("@PersonInCharge", crEntity.PersonInCharge);
                cmdInsert.Parameters.AddWithValue("@Person_Type1", crEntity.PersonInChargeId1);
                cmdInsert.Parameters.AddWithValue("@PersonInCharge1", crEntity.PersonInCharge1);
                cmdInsert.Parameters.AddWithValue("@Person_Type2", crEntity.PersonInChargeId2);
                cmdInsert.Parameters.AddWithValue("@PersonInCharge2", crEntity.PersonInCharge2);
                cmdInsert.Parameters.AddWithValue("@Department", crEntity.Department);
                cmdInsert.Parameters.AddWithValue("@Telephone_No", crEntity.TelePhoneNo);
                cmdInsert.Parameters.AddWithValue("@Telephone_No1", crEntity.TelePhoneNo1);
                cmdInsert.Parameters.AddWithValue("@Telephone_No2", crEntity.TelePhoneNo2);
                cmdInsert.Parameters.AddWithValue("@Email", crEntity.Email);
                cmdInsert.Parameters.AddWithValue("@Email1", crEntity.Email1);
                cmdInsert.Parameters.AddWithValue("@Email2", crEntity.Email2);
                cmdInsert.Parameters.AddWithValue("@Email_Confirm", crEntity.EmailConfirm);
                cmdInsert.Parameters.AddWithValue("@Email_Confirm1", crEntity.EmailConfirm1);
                cmdInsert.Parameters.AddWithValue("@Email_Confirm2", crEntity.EmailConfirm2);
                cmdInsert.Parameters.AddWithValue("@Remarks", crEntity.Remark);
                cmdInsert.Parameters.AddWithValue("@CreatedBy", crEntity.CreatedBy);
                cmdInsert.Parameters.AddWithValue("@CreatedDate", crEntity.CreatedDate);
                cmdInsert.Parameters.AddWithValue("@UpdatedBy", crEntity.UpdatedBy);
                cmdInsert.Parameters.AddWithValue("@UpdatedDate", crEntity.UpdatedDate);
                cmdInsert.Parameters.AddWithValue("@Wanted", crEntity.Wanted);
                cmdInsert.Parameters.AddWithValue("@EnterDay", crEntity.EnterDate);
                cmdInsert.Parameters.AddWithValue("@ASAP1", crEntity.ASAP1);
                cmdInsert.Parameters.AddWithValue("@InterviewDate", crEntity.InterviewDate);
                cmdInsert.Parameters.AddWithValue("@ASAP2", crEntity.ASAP2);
                cmdInsert.Parameters.AddWithValue("@Option", option);
                cmdInsert.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                cmdInsert.ExecuteNonQuery();
                int result = Convert.ToInt32(cmdInsert.Parameters["@result"].Value);
                cmdInsert.Connection.Close();
                if (result == 1)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Checkupdate(int jobno)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SP_CheckUpdateID", DataConfig.GetConnectionString());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", jobno);
                da.SelectCommand = cmd;
                DataTable dtb = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dtb);
                da.SelectCommand.Connection.Close();
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(int id, int sessionID, DateTime date)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdInsert = new SqlCommand("SP_Client_Recruitment_Delete", DataConfig.GetConnectionString());
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("@ID", id);
                cmdInsert.Parameters.AddWithValue("@SessionID", sessionID);
                cmdInsert.Parameters.AddWithValue("@Date", date);
                da.InsertCommand = cmdInsert;
                cmdInsert.Connection.Open();
                int result = cmdInsert.ExecuteNonQuery();
                cmdInsert.Connection.Close();
                if (result == -1)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DeleteByClientID(int ClientID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Client_Recruitment_DeleteByClientID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ClientID", ClientID);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
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
