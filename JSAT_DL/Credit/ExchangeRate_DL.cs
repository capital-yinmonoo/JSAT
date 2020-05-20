using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using System.Configuration;

namespace JSAT_DL
{
    public class ExchangeRate_DL
    {
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public ExchangeRate_DL()
        { }

        public void Insert(string buy, string sell)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Insert_ExchangeRate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                if (!String.IsNullOrWhiteSpace(buy) && !String.IsNullOrWhiteSpace(sell))
                {
                    cmd.Parameters.AddWithValue("@Exchange_Rate_Buy", buy);
                    cmd.Parameters.AddWithValue("@Exchange_Rate_Sell", sell);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Exchange_Rate_Buy", "0");
                    cmd.Parameters.AddWithValue("@Exchange_Rate_Sell", "0");
                }
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
