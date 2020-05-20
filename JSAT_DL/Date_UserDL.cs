using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace JSAT_DL
{
    public class Date_UserDL
    {
        public DataTable Paging(string search, string sort, int startIndex, int pagesize, out int totalrowcount)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_DateUserPaging", DataConfig.GetConnectionString());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Search", search);
            da.SelectCommand.Parameters.AddWithValue("@Sort", sort);
            da.SelectCommand.Parameters.AddWithValue("@StartIndex", startIndex);
            da.SelectCommand.Parameters.AddWithValue("@PageSize", pagesize);
            DataSet ds = new DataSet();
            da.Fill(ds);
            totalrowcount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }
    }
}
