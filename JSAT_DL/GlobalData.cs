using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class GlobalData
    {
        public DataTable Get_Data(string tableName)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From "+ tableName+" WHERE IsDeleted = 0 order by Description asc", DataConfig.connectionString);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable Get_DataOrderbyID(string tableName) 
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From " + tableName + " WHERE IsDeleted = 0 order by ID", DataConfig.connectionString);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable Getpersonalskill()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Personal_Skill", DataConfig.connectionString);
                da.SelectCommand.CommandType = CommandType.Text;
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

        public DataTable Get_Datanew(string tableName)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From " + tableName + " WHERE IsDeleted = 0 order by Description asc", DataConfig.connectionString);
                da.SelectCommand.CommandType = CommandType.Text;
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
