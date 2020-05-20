﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Client_ProfileDL
    {
        public Client_ProfileDL()
        {

        }

        public DataTable SelectAll()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Client_Profile_SelectAll", DataConfig.GetConnectionString());
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

        public int AutoGenerated_ClientCode()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MAX(CAST(Client_Code AS Int)) AS Client_Code FROM Client_Profile WHERE ISNUMERIC(Client_Code)=1 AND Client_Code NOT LIKE '%[a-z]%' AND Client_Code NOT LIKE '%.%' AND IsDeleted = 0", DataConfig.GetConnectionString());
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                int Max_ClientCode = 0;
                int AutoGenerated_ClientCode = 0;
                if (dt.Rows[0]["Client_Code"].ToString() != "")
                {
                    Max_ClientCode = int.Parse(dt.Rows[0]["Client_Code"].ToString());
                    AutoGenerated_ClientCode = Max_ClientCode + 1;
                    return AutoGenerated_ClientCode;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectById(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Client_Profile_SelectByID", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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

        public Client_ProfileEntity SelectByID(int id)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Client_Profile_SelectByID", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                DataTable dt = new DataTable();
                da.SelectCommand.Connection.Open();
                da.Fill(dt);
                da.SelectCommand.Connection.Close();
                Client_ProfileEntity clientProfile = new Client_ProfileEntity();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        clientProfile.Client_Name = dt.Rows[0]["Client_Name"].ToString();
                        clientProfile.Client_Code = int.Parse(dt.Rows[0]["Client_Code"].ToString());
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Person_TypeID"].ToString()))
                        {
                            clientProfile.Person_TypeID = (int)dt.Rows[0]["Person_TypeID"];
                        }
                        clientProfile.PersonInCharge_Name = dt.Rows[0]["PersonInCharge_Name"].ToString();
                        clientProfile.Telephone_No = dt.Rows[0]["Telephone_No"].ToString();
                        clientProfile.Fax_No = dt.Rows[0]["Fax_No"].ToString();
                        clientProfile.Website = dt.Rows[0]["Website"].ToString();
                        clientProfile.Location = dt.Rows[0]["Location"].ToString();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Industry_TypeID"].ToString()))
                        {
                            clientProfile.Industry_TypeID = (int)dt.Rows[0]["Industry_TypeID"];
                        }
                        else
                        {
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Business_TypeID"].ToString()))
                        {
                            clientProfile.Business_TypeID = (int)dt.Rows[0]["Business_TypeID"];
                        }
                        else
                        {
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Total_Employees"].ToString()))
                        {
                            clientProfile.Total_Employees = (int)dt.Rows[0]["Total_Employees"];
                        }
                        else
                        {
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["NoofClubs"].ToString()))
                        {
                            clientProfile.NoofClubs = (int)dt.Rows[0]["NoofClubs"];
                        }
                        clientProfile.Establishment_Date = dt.Rows[0]["Establishment_Date"].ToString();
                        clientProfile.Remarks = dt.Rows[0]["Remarks"].ToString();
                        clientProfile.Agreement_Data = dt.Rows[0]["Agreement_Data"].ToString();
                        clientProfile.IsDeleted = (bool)dt.Rows[0]["IsDeleted"];
                        clientProfile.Consent = dt.Rows[0]["Consent"].ToString();
                    }
                }
                return clientProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Client_ProfileEntity clientProfileInfo, int Option)
        {
            try
            {
                bool result = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Client_Profile_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Client_Name", clientProfileInfo.Client_Name);
                cmd.Parameters.AddWithValue("@Client_Code", clientProfileInfo.Client_Code);
                cmd.Parameters.AddWithValue("@Person_TypeID", clientProfileInfo.Person_TypeID);
                cmd.Parameters.AddWithValue("@PersonInCharge_Name", clientProfileInfo.PersonInCharge_Name);
                cmd.Parameters.AddWithValue("@Telephone_No", clientProfileInfo.Telephone_No);
                cmd.Parameters.AddWithValue("@Fax_No", clientProfileInfo.Fax_No);
                cmd.Parameters.AddWithValue("@Website", clientProfileInfo.Website);
                cmd.Parameters.AddWithValue("@Location", clientProfileInfo.Location);
                cmd.Parameters.AddWithValue("@Industry_TypeID", clientProfileInfo.Industry_TypeID);
                cmd.Parameters.AddWithValue("@Business_TypeID", clientProfileInfo.Business_TypeID);
                cmd.Parameters.AddWithValue("@Total_Employees", clientProfileInfo.Total_Employees);
                cmd.Parameters.AddWithValue("@NoofClubs", clientProfileInfo.NoofClubs);
                cmd.Parameters.AddWithValue("@Establishment_Date", clientProfileInfo.Establishment_Date);
                cmd.Parameters.AddWithValue("@Remarks", clientProfileInfo.Remarks);
                cmd.Parameters.AddWithValue("@Consent", clientProfileInfo.Consent);
                cmd.Parameters.AddWithValue("@Agreement_Data", clientProfileInfo.Agreement_Data);
                cmd.Parameters.AddWithValue("@CreatedBy", clientProfileInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", clientProfileInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", clientProfileInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", clientProfileInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", Option);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 1)
                {
                    result = true;
                    clientProfileInfo.ID = id;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Client_ProfileEntity clientProfileInfo, int Option)
        {
            try
            {
                bool result = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Client_Profile_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", clientProfileInfo.ID);
                cmd.Parameters.AddWithValue("@Client_Name", clientProfileInfo.Client_Name);
                cmd.Parameters.AddWithValue("@Client_Code", clientProfileInfo.Client_Code);
                cmd.Parameters.AddWithValue("@Person_TypeID", clientProfileInfo.Person_TypeID);
                cmd.Parameters.AddWithValue("@PersonInCharge_Name", clientProfileInfo.PersonInCharge_Name);
                cmd.Parameters.AddWithValue("@Telephone_No", clientProfileInfo.Telephone_No);
                cmd.Parameters.AddWithValue("@Fax_No", clientProfileInfo.Fax_No);
                cmd.Parameters.AddWithValue("@Website", clientProfileInfo.Website);
                cmd.Parameters.AddWithValue("@Location", clientProfileInfo.Location);
                cmd.Parameters.AddWithValue("@Industry_TypeID", clientProfileInfo.Industry_TypeID);
                cmd.Parameters.AddWithValue("@Business_TypeID", clientProfileInfo.Business_TypeID);
                cmd.Parameters.AddWithValue("@Total_Employees", clientProfileInfo.Total_Employees);
                cmd.Parameters.AddWithValue("@NoofClubs", clientProfileInfo.NoofClubs);
                cmd.Parameters.AddWithValue("@Establishment_Date", clientProfileInfo.Establishment_Date);
                cmd.Parameters.AddWithValue("@Remarks", clientProfileInfo.Remarks);
                cmd.Parameters.AddWithValue("@Consent", clientProfileInfo.Consent);
                cmd.Parameters.AddWithValue("@Agreement_Data", clientProfileInfo.Agreement_Data);
                cmd.Parameters.AddWithValue("@CreatedBy", clientProfileInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", clientProfileInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", clientProfileInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", clientProfileInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", Option);
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

        public int Check_ExistingCode(int clientCode, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_Client_Profile_Check_ExistCode";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DataConfig.GetConnectionString();
            cmd.Parameters.AddWithValue("@Client_Code", clientCode);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Connection.Open();
            int count = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            return count;
        }

        public bool Delete(int id, int sessionID, DateTime date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Client_Profile_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@SessionID", sessionID);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Option", 0);
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

        public bool DeleteAll()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Client_Profile_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", 1); // For returning @result from database stored procedure.
                cmd.Parameters.AddWithValue("@Option", 1);
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

        public DataTable SelectByCriteria(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_Client_Profile_Search", DataConfig.GetConnectionString());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@search", search);
                if (startIndex == 0)
                {
                    startIndex = 1;
                }
                else
                {
                    startIndex = (startIndex / 10) + 1;
                }
                da.SelectCommand.Parameters.AddWithValue("@StartIndex", startIndex);
                da.SelectCommand.Parameters.AddWithValue("@sort", sort);
                da.SelectCommand.Parameters.AddWithValue("@pagesize", pagesize);
                DataSet ds = new DataSet();
                da.SelectCommand.Connection.Open();
                da.Fill(ds);
                totalrowcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                da.SelectCommand.Connection.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByIndustryID(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Client_Profile_SelectByIndustryID", DataConfig.GetConnectionString());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Industry_ID", id);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SearchByName(String Name, int? Code)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_Client_SearchByName", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@Client_Name", Name);
                cmdSelect.Parameters.AddWithValue("@Client_Code", Code);
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
    }
}
