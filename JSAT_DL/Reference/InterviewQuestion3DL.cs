using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;


namespace JSAT_DL.Reference
{
    public class InterviewQuestion3DL
    {
        public InterviewQuestion3DL()
        {

        }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("Sp_InterviewQuestion_SelectAll", DataConfig.connectionString);
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
            { da.SelectCommand.Connection.Close(); da.Dispose(); }
        }
    }
}
