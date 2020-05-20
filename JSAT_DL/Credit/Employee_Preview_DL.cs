using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_DL
{
    public class Employee_Preview_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Employee_Preview_DL()
        { }

        public DataTable Get_Info_ByEmpID(int eid)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SP_Select_Info_ByEmpIDPreview", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Employee_ID", eid);
                sda.Fill(dt);
                sda.SelectCommand.Connection.Close();
                return dt;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
