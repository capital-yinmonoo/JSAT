using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class Career_InterviewDL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Career_InterviewDL() { }

        public bool Insert(Career_InterviewEntity ciInfo)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_Interview_Update", connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ciInfo.ID);
                cmd.Parameters.AddWithValue("@Career_ID", ciInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Job_Introduction", ciInfo.Job_Introduction);
                cmd.Parameters.AddWithValue("@Address", ciInfo.Address);
                cmd.Parameters.AddWithValue("@Residential_Area", ciInfo.Residential_Area);
                cmd.Parameters.AddWithValue("@Phone_No1", ciInfo.Phone_No1);
                cmd.Parameters.AddWithValue("@Phone_No2", ciInfo.Phone_No2);
                cmd.Parameters.AddWithValue("@Email", ciInfo.Email);
                cmd.Parameters.AddWithValue("@Emergency_ContactNo", ciInfo.Emergency_ContactNo);
                cmd.Parameters.AddWithValue("@Emergency_ContactName", ciInfo.Emergency_ContactName);
                cmd.Parameters.AddWithValue("@Family_Persons", ciInfo.Family_Persons);
                cmd.Parameters.AddWithValue("@Family_Occupation", ciInfo.Family_Occupation);
                cmd.Parameters.AddWithValue("@Family_Income", ciInfo.Family_Income);
                cmd.Parameters.AddWithValue("@Apprentice_Accuracy", ciInfo.Apprentice_Accuracy);
                cmd.Parameters.AddWithValue("@Working_Abroad", ciInfo.Working_Abroad);
                cmd.Parameters.AddWithValue("@Location_ID", ciInfo.Location_ID);
                cmd.Parameters.AddWithValue("@Other_Place", ciInfo.Other_Place);
                cmd.Parameters.AddWithValue("@Period", ciInfo.Period);
                cmd.Parameters.AddWithValue("@Other_Period", ciInfo.Other_Period);
                cmd.Parameters.AddWithValue("@Remarks", ciInfo.Remarks);
                cmd.Parameters.AddWithValue("@CreatedBy", ciInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", ciInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", ciInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", ciInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.AddWithValue("@LocationID2", ciInfo.LocationID2);
                cmd.Parameters.AddWithValue("@LocationID3", ciInfo.LocationID3);
                cmd.Parameters.AddWithValue("@LocationID4", ciInfo.LocationID3);
                cmd.Parameters.AddWithValue("@Relationship", ciInfo.Relationship);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public bool Update(Career_InterviewEntity ciInfo)
        {
            SqlCommand cmd = new SqlCommand("SP_Career_Interview_Update", connection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ciInfo.ID);
                cmd.Parameters.AddWithValue("@Career_ID", ciInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Job_Introduction", ciInfo.Job_Introduction);
                cmd.Parameters.AddWithValue("@Address", ciInfo.Address);
                cmd.Parameters.AddWithValue("@Residential_Area", ciInfo.Residential_Area);
                cmd.Parameters.AddWithValue("@Phone_No1", ciInfo.Phone_No1);
                cmd.Parameters.AddWithValue("@Phone_No2", ciInfo.Phone_No2);
                cmd.Parameters.AddWithValue("@Email", ciInfo.Email);
                cmd.Parameters.AddWithValue("@Emergency_ContactNo", ciInfo.Emergency_ContactNo);
                cmd.Parameters.AddWithValue("@Emergency_ContactName", ciInfo.Emergency_ContactName);
                cmd.Parameters.AddWithValue("@Family_Persons", ciInfo.Family_Persons);
                cmd.Parameters.AddWithValue("@Family_Occupation", ciInfo.Family_Occupation);
                cmd.Parameters.AddWithValue("@Family_Income", ciInfo.Family_Income);
                cmd.Parameters.AddWithValue("@Apprentice_Accuracy", ciInfo.Apprentice_Accuracy);
                cmd.Parameters.AddWithValue("@Working_Abroad", ciInfo.Working_Abroad);
                cmd.Parameters.AddWithValue("@Location_ID", ciInfo.Location_ID);
                cmd.Parameters.AddWithValue("@Other_Place", ciInfo.Other_Place);
                cmd.Parameters.AddWithValue("@Period", ciInfo.Period);
                cmd.Parameters.AddWithValue("@Other_Period", ciInfo.Other_Period);
                cmd.Parameters.AddWithValue("@Remarks", ciInfo.Remarks);
                cmd.Parameters.AddWithValue("@CreatedBy", ciInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", ciInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", ciInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", ciInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@LocationID2", ciInfo.LocationID2);
                cmd.Parameters.AddWithValue("@LocationID3", ciInfo.LocationID3);
                cmd.Parameters.AddWithValue("@LocationID4", ciInfo.LocationID4);
                cmd.Parameters.AddWithValue("@Relationship", ciInfo.Relationship);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public Career_InterviewEntity SelectByCareerID(int cid)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Career_Interview_SelectByCareerID", connection);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Career_ID", cid);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                Career_InterviewEntity ciInfo = new Career_InterviewEntity();
                if (dt.Rows.Count > 0)
                {
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["ID"])))
                    {
                        ciInfo.ID = (int)dt.Rows[0]["ID"];
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Career_ID"])))
                    {
                        ciInfo.Career_ID = (int)dt.Rows[0]["Career_ID"];
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Job_Introduction"])))
                    {
                        ciInfo.Job_Introduction = (bool)dt.Rows[0]["Job_Introduction"];
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Address"])))
                    {
                        ciInfo.Address = dt.Rows[0]["Address"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Address1"])))
                    {
                        ciInfo.Residential_Area = dt.Rows[0]["Address1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Phone_No1"])))
                    {
                        ciInfo.Phone_No1 = dt.Rows[0]["Phone_No1"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Phone_No2"])))
                    {
                        ciInfo.Phone_No2 = dt.Rows[0]["Phone_No2"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Email"])))
                    {
                        ciInfo.Email = dt.Rows[0]["Email"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Emergency_ContactNo"])))
                    {
                        ciInfo.Emergency_ContactNo = dt.Rows[0]["Emergency_ContactNo"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Emergency_ContactName"])))
                    {
                        ciInfo.Emergency_ContactName = dt.Rows[0]["Emergency_ContactName"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Family_Persons"])))
                    {
                        ciInfo.Family_Persons = (int)dt.Rows[0]["Family_Persons"];
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Family_Occupation"])))
                    {
                        ciInfo.Family_Occupation = dt.Rows[0]["Family_Occupation"].ToString();
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Family_Income"])))
                    {
                        ciInfo.Family_Income = (int)dt.Rows[0]["Family_Income"];
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Apprentice_Accuracy"])))
                    {
                        ciInfo.Apprentice_Accuracy = (bool)dt.Rows[0]["Apprentice_Accuracy"];
                    }
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Working_Abroad"])))
                    {
                        ciInfo.Working_Abroad = (bool)dt.Rows[0]["Working_Abroad"];
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Location_ID"].ToString()))
                        ciInfo.Location_ID = (int)dt.Rows[0]["Location_ID"];
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Location_ID2"].ToString()))
                        ciInfo.LocationID2 = (int)dt.Rows[0]["Location_ID2"];
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Location_ID3"].ToString()))
                        ciInfo.LocationID3 = (int)dt.Rows[0]["Location_ID3"];
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Location_ID4"].ToString()))
                        ciInfo.LocationID4 = (int)dt.Rows[0]["Location_ID4"];
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Other_Place"].ToString()))
                        ciInfo.Other_Place = dt.Rows[0]["Other_Place"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Period"].ToString()))
                        ciInfo.Period = (int)dt.Rows[0]["Period"];
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Other_Period"].ToString()))
                        ciInfo.Other_Period = dt.Rows[0]["Other_Period"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Remarks"].ToString()))
                        ciInfo.Remarks = dt.Rows[0]["Remarks"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Location_ID"].ToString()))
                        ciInfo.WorkingPlace = dt.Rows[0]["WorkingPlace"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["WorkingPlace2"].ToString()))
                        ciInfo.WorkingPlace2 = dt.Rows[0]["WorkingPlace2"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["WorkingPlace3"].ToString()))
                        ciInfo.WorkingPlace3 = dt.Rows[0]["WorkingPlace3"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["WorkingPlace4"].ToString()))
                        ciInfo.WorkingPlace4 = dt.Rows[0]["WorkingPlace4"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["LogIn_ID"].ToString()))
                        ciInfo.Updater = dt.Rows[0]["LogIn_ID"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["UpdatedDate"].ToString()))
                        ciInfo.UpdateTime = dt.Rows[0]["UpdatedDate"].ToString();
                }
                return ciInfo;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }
    }
}
