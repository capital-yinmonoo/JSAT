using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL.Reference
{
    public class Interview_Question1DL
    {
        public Interview_Question1DL()
        { }

        public DataTable SelectAll()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_Interview_Question1_SelectAll", DataConfig.connectionString);
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
            finally { da.SelectCommand.Connection.Close(); da.Dispose(); }
        }
    }
}
