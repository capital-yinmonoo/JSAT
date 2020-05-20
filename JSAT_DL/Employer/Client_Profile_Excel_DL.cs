using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JSAT_DL;
using System.Data.OleDb;

namespace JSAT_DL
{
    public class Client_Profile_Excel_DL
    {
        DataTable dt = new DataTable();
        DataTable dtinfo = new DataTable();
        DataTable dtdata = new DataTable();
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);

        public Client_Profile_Excel_DL()
        {
           
        }

        public DataTable Read(string path, string extension)
        {
            try
            {
                dtdata.Columns.Add("Client_Name", typeof(System.String));
                dtdata.Columns.Add("PersonInCharge_Name", typeof(System.String));
                dtdata.Columns.Add("Telephone_No", typeof(System.String));
                dtdata.Columns.Add("Fax_No", typeof(System.String));
                dtdata.Columns.Add("Location", typeof(System.String));
                dtdata.Columns.Add("Total_Employee", typeof(System.String));
                dtdata.Columns.Add("Remarks", typeof(System.String));
                dtdata.Rows.Add();
                string connStr;
                connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";
                DataTable sheets = GetSchemaTable(connStr);
                string sql = string.Empty;
                DataSet ds = new DataSet();
                foreach (DataRow dr in sheets.Rows)
                {
                    //Print_Area
                    string WorkSheetName = dr["TABLE_NAME"].ToString().Trim();
                    if (!WorkSheetName.Contains("Print_Area"))
                    {
                        sql = "SELECT * FROM [" + WorkSheetName + "]";
                        ds.Clear();
                        OleDbDataAdapter data = new OleDbDataAdapter(sql, connStr);
                        data.Fill(ds);
                        DataTable dt1 = ds.Tables[0];
                        int i = 0;
                        for (int y = 2; y < dt1.Rows.Count; y++)
                        {
                            dtdata.Rows[i]["Client_Name"] = dt1.Rows[y]["F1"].ToString();
                            dtdata.Rows[i]["PersonInCharge_Name"] = dt1.Rows[y]["F2"].ToString();
                            dtdata.Rows[i]["Telephone_No"] = dt1.Rows[y]["Client_Profile"].ToString();
                            dtdata.Rows[i]["Fax_No"] = dt1.Rows[y]["F4"].ToString();
                            dtdata.Rows[i]["Location"] = dt1.Rows[y]["F5"].ToString();
                            dtdata.Rows[i]["Total_Employee"] = dt1.Rows[y]["F6"].ToString();
                            dtdata.Rows[i]["Remarks"] = dt1.Rows[y]["F7"].ToString();
                            i++;
                            dtdata.Rows.Add();
                        }
                        dt1.Columns.Clear();
                        for (int j = dtdata.Rows.Count; j > 0; j--)
                        {
                            dtdata.Rows.RemoveAt(j - 1);
                            break;
                        }
                        dt.Merge(dtdata);
                    }//if 
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static DataTable GetSchemaTable(string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }

        public void Insert(DataTable dt)
        {
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SP_ClientProfileExceldata_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Client_Name"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Client_Name", dt.Rows[i]["Client_Name"].ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Client_Name", DBNull.Value);
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["PersonInCharge_Name"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@PersonInCharge_Name", dt.Rows[i]["PersonInCharge_Name"].ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PersonInCharge_Name", DBNull.Value);
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Telephone_No"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Telephone_No", dt.Rows[i]["Telephone_No"].ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Telephone_No", DBNull.Value);
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Fax_No"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Fax_No", Convert.ToInt32(dt.Rows[i]["Fax_No"].ToString()));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Fax_No", DBNull.Value);
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Location"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Location", dt.Rows[i]["Location"]);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Location", DBNull.Value);
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Total_Employee"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Total_Employee", Convert.ToInt32(dt.Rows[i]["Total_Employee"].ToString()));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Total_Employee", DBNull.Value);
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Remarks"].ToString()))
                    {
                        cmd.Parameters.AddWithValue("@Remarks", dt.Rows[i]["Remarks"].ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Remarks", DBNull.Value);
                    }
                    cmd.Parameters.Add("@Client_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
