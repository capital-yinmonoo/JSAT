﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JSAT_DL
{
    public class LanguageLevelDL
    {
        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Language_Level_SelectAll", DataConfig.connectionString);
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
    }
}
