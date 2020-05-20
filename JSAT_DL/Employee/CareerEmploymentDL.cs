using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using System.Data.SqlClient;
using System.Data;

namespace JSAT_DL
{
    public class CareerEmploymentDL
    {

        public CareerEmploymentDL() { }

        public DataTable SelectAll()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Career_Employment_SelectAll", DataConfig.GetConnectionString());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CareerEmploymentEntity SelectByID(int id)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Career_Employment_SelectByID", DataConfig.GetConnectionString());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                CareerEmploymentEntity ceInfo = new CareerEmploymentEntity();
                if (dt != null)
                {
                    ceInfo.ID = (int)dt.Rows[0]["ID"];
                    ceInfo.Career_ID = (int)dt.Rows[0]["Career_ID"];
                    ceInfo.Company_Name = dt.Rows[0]["Company_Name"].ToString();
                    ceInfo.Business_Type = dt.Rows[0]["Business_Type"].ToString();
                    if (dt.Rows[0]["LocationID"] != DBNull.Value)
                        ceInfo.LocationID = (int)dt.Rows[0]["LocationID"];
                    ceInfo.Position = dt.Rows[0]["Position"].ToString();
                    ceInfo.Other_Location = dt.Rows[0]["Other_Location"].ToString();
                    ceInfo.Last_Salary = (int)dt.Rows[0]["Last_Salary"];
                    ceInfo.SalaryType = dt.Rows[0]["SalaryType"].ToString();
                    ceInfo.Responsibility = dt.Rows[0]["Responsibility"].ToString();
                    ceInfo.FromDate = dt.Rows[0]["FromDate"].ToString();
                    ceInfo.ToDate = dt.Rows[0]["ToDate"].ToString();
                    ceInfo.Leave_Reason = dt.Rows[0]["Leave_Reason"].ToString();
                    ceInfo.Updater = dt.Rows[0]["LogIn_ID"].ToString();
                    ceInfo.UpdateTime = dt.Rows[0]["UpdatedDate"].ToString();
                    ceInfo.IndustryID = BaseLib.Convert_Int(dt.Rows[0]["Industry_TypeID"].ToString());
                    ceInfo.BusinessID = BaseLib.Convert_Int(dt.Rows[0]["Business_TypeID"].ToString());
                    ceInfo.DepartmentID = BaseLib.Convert_Int(dt.Rows[0]["DepartmentID"].ToString());
                    ceInfo.PositionID = BaseLib.Convert_Int(dt.Rows[0]["PositionID"].ToString());
                }
                return ceInfo;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectByCareerID(int cid)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SP_Career_Employment_SelectByCareerID", DataConfig.GetConnectionString());
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Career_ID", cid);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Insert(CareerEmploymentEntity ceInfo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Career_Employment_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", ceInfo.ID);
                cmd.Parameters.AddWithValue("@Career_ID", ceInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Company_Name", ceInfo.Company_Name);
                cmd.Parameters.AddWithValue("@Industry_TypeID", ceInfo.IndustryID);
                cmd.Parameters.AddWithValue("@Business_TypeID", ceInfo.BusinessID);
                cmd.Parameters.AddWithValue("@DepartmentID", ceInfo.DepartmentID);
                cmd.Parameters.AddWithValue("@PositionID", ceInfo.PositionID);
                cmd.Parameters.AddWithValue("@LocationID", ceInfo.LocationID);
                cmd.Parameters.AddWithValue("@Other", ceInfo.Other_Location);
                cmd.Parameters.AddWithValue("@Last_Salary", ceInfo.Last_Salary);
                cmd.Parameters.AddWithValue("@SalaryType", ceInfo.SalaryType);
                cmd.Parameters.AddWithValue("@Responsibility", ceInfo.Responsibility);
                cmd.Parameters.AddWithValue("@FromDate", ceInfo.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ceInfo.ToDate);
                cmd.Parameters.AddWithValue("@Leave_Reason", ceInfo.Leave_Reason);
                cmd.Parameters.AddWithValue("@CreatedBy", ceInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", ceInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", ceInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", ceInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Update(CareerEmploymentEntity ceInfo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Career_Employment_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", ceInfo.ID);
                cmd.Parameters.AddWithValue("@Career_ID", ceInfo.Career_ID);
                cmd.Parameters.AddWithValue("@Company_Name", ceInfo.Company_Name);
                cmd.Parameters.AddWithValue("@Industry_TypeID", ceInfo.IndustryID);
                cmd.Parameters.AddWithValue("@Business_TypeID", ceInfo.BusinessID);
                cmd.Parameters.AddWithValue("@DepartmentID", ceInfo.DepartmentID);
                cmd.Parameters.AddWithValue("@PositionID", ceInfo.PositionID);
                cmd.Parameters.AddWithValue("@LocationID", ceInfo.LocationID);
                cmd.Parameters.AddWithValue("@Other", ceInfo.Other_Location);
                cmd.Parameters.AddWithValue("@Last_Salary", ceInfo.Last_Salary);
                cmd.Parameters.AddWithValue("@SalaryType", ceInfo.SalaryType);
                cmd.Parameters.AddWithValue("@Responsibility", ceInfo.Responsibility);
                cmd.Parameters.AddWithValue("@FromDate", ceInfo.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ceInfo.ToDate);
                cmd.Parameters.AddWithValue("@Leave_Reason", ceInfo.Leave_Reason);
                cmd.Parameters.AddWithValue("@CreatedBy", ceInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", ceInfo.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", ceInfo.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", ceInfo.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public Boolean DeleteByCareerID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Career_Employment_DeleteByCareerID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@Career_ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Career_Employment_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = DataConfig.GetConnectionString();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SearchData(String Name, String position)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSelect = new SqlCommand("SP_CareerEmployeement_Search", DataConfig.GetConnectionString());
                cmdSelect.Parameters.AddWithValue("@Name", Name);
                if (String.IsNullOrWhiteSpace(position))
                    position = null;
                cmdSelect.Parameters.AddWithValue("@Position", position);
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
