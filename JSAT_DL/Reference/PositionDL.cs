using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_DL
{
    public class PositionDL
    {
        public PositionDL()
        { }

        public DataTable SelectAll(int PorCRV)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Position_SelectAll", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@PorCRV", PorCRV);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public DataTable SelectByDepartmentID(int dept_id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Position_SelectByDepartmentID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@Department_ID", dept_id);
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public PositionEntity SelectByID(int id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Position_SelectByID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@ID", id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                PositionEntity position = new PositionEntity();
                if (dt != null)
                {
                    position.Department_ID = (int)dt.Rows[0]["Department_ID"];
                    position.Description = dt.Rows[0]["Description"].ToString();
                }
                return position;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool Insert(PositionEntity position)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Position_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", position.ID);
                cmd.Parameters.AddWithValue("@Department_ID", position.Department_ID);
                cmd.Parameters.AddWithValue("@Description", position.Description);
                cmd.Parameters.AddWithValue("@CreatedBy", position.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", position.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", position.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", position.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", 0);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 0)
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

        public bool Update(PositionEntity position)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Position_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", position.ID);
                cmd.Parameters.AddWithValue("@Department_ID", position.Department_ID);
                cmd.Parameters.AddWithValue("@Description", position.Description);
                cmd.Parameters.AddWithValue("@CreatedBy", position.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", position.CreatedDate);
                cmd.Parameters.AddWithValue("@UpdatedBy", position.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", position.UpdatedDate);
                cmd.Parameters.AddWithValue("@Option", 1);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int id = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (id >= 0)
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

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                bool result = false;
                cmd.CommandText = "SP_Position_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                int num = Convert.ToInt32(cmd.Parameters["@result"].Value);
                if (num >= 0)
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

        public DataTable Search(int id, string str)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_Position_Search", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Department_ID", id);
                sda.SelectCommand.Parameters.AddWithValue("@Description", str);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public int CheckExistingType(int id, int departmentid, string str)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection Connection = new SqlConnection(DataConfig.connectionString);
            try
            {
                cmd.CommandText = "SP_Position_Check";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Department_ID", departmentid);
                cmd.Parameters.AddWithValue("@Description", str);
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

        public DataTable GetDepartmentID(int department_id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Department_ID from Position where ID=@Department_ID", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                sda.SelectCommand.Parameters.AddWithValue("@Department_ID", department_id);
                sda.SelectCommand.Connection.Open();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public DataTable GetDepartment(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Department_ID From Position where ID=" + id, DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
