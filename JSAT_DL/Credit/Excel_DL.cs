using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;
using System.Data.OleDb;

namespace JSAT_DL
{
    public class Excel_DL
    {
        DataTable dt = new DataTable();
        DataTable dtinfo = new DataTable();
        DataTable dtdata = new DataTable();
        SqlConnection connection = new SqlConnection(DataConfig.connectionString);
        public Excel_DL()
        { }

        public DataTable Read(string path, string extension)
        {
            try
            {
                dtdata.Columns.Add("Date", typeof(System.String));
                dtdata.Columns.Add("No", typeof(System.String));
                dtdata.Columns.Add("Name", typeof(System.String));
                dtdata.Columns.Add("TELNo", typeof(System.String));
                dtdata.Columns.Add("CompanyName", typeof(System.String));
                dtdata.Columns.Add("JobNo", typeof(System.String));
                dtdata.Columns.Add("Position", typeof(System.String));
                dtdata.Columns.Add("Salary", typeof(System.String));
                dtdata.Columns.Add("USD", typeof(System.String));
                dtdata.Columns.Add("Start_Working", typeof(System.String));
                dtdata.Columns.Add("1Week", typeof(System.String));
                dtdata.Columns.Add("Issue_Date", typeof(System.String));
                dtdata.Columns.Add("1Month", typeof(System.String));
                dtdata.Columns.Add("2Month", typeof(System.String));
                dtdata.Columns.Add("3Month", typeof(System.String));
                dtdata.Columns.Add("Issue_Date2", typeof(System.String));
                dtdata.Rows.Add();
                string check = string.Empty; int x = 0; string checkdate = string.Empty; string[] date = new string[2]; int drow = 0; int drow2 = 0;
                string connStr;
                connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0";//for excel 2012
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
                        string str = dt1.Columns[6].ColumnName.ToString();
                        string[] dat = str.Split(' ');
                        string year = dat[dat.Length - 1].ToString();
                        dt1.Columns[6].ColumnName = "Success on";
                        dt1.AcceptChanges();
                        for (int y = 3; y < dt1.Rows.Count; y++)
                        {
                            dtdata.Rows[i]["Date"] = dt1.Rows[y]["F2"].ToString();
                            dtdata.Rows[i]["No"] = dt1.Rows[y]["F3"].ToString();
                            dtdata.Rows[i]["Name"] = dt1.Rows[y]["F4"].ToString() + dt1.Rows[y]["F5"].ToString();
                            dtdata.Rows[i]["TELNo"] = dt1.Rows[y]["F6"].ToString();
                            dtdata.Rows[i]["CompanyName"] = dt1.Rows[y]["Success on"].ToString();
                            dtdata.Rows[i]["JobNo"] = dt1.Rows[y]["F8"].ToString();
                            dtdata.Rows[i]["Position"] = dt1.Rows[y]["F9"].ToString();
                            dtdata.Rows[i]["Salary"] = dt1.Rows[y]["F10"].ToString();
                            dtdata.Rows[i]["USD"] = dt1.Rows[y]["F11"].ToString();
                            dtdata.Rows[i]["Start_Working"] = dt1.Rows[y]["F12"].ToString();
                            dtdata.Rows[i]["1Week"] = dt1.Rows[y]["F14"].ToString();
                            dtdata.Rows[i]["Issue_Date"] = dt1.Rows[y]["F15"].ToString();
                            dtdata.Rows[i]["1Month"] = dt1.Rows[y]["F17"].ToString();
                            dtdata.Rows[i]["2Month"] = dt1.Rows[y]["F18"].ToString();
                            dtdata.Rows[i]["3Month"] = dt1.Rows[y]["F19"].ToString();
                            dtdata.Rows[i]["Issue_Date2"] = dt1.Rows[y]["F20"].ToString();
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
                    SqlCommand cmd = new SqlCommand("SP_Exceldata_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@Company_Name", dt.Rows[i]["CompanyName"].ToString());
                    cmd.Parameters.AddWithValue("@Employee_Code", dt.Rows[i]["No"].ToString());
                    cmd.Parameters.AddWithValue("@Employee_Name", dt.Rows[i]["Name"].ToString());
                    if (dt.Rows[i]["Name"].ToString().Contains("Ms"))
                    {
                        cmd.Parameters.AddWithValue("@Gender", 2);
                    }
                    else
                        cmd.Parameters.AddWithValue("@Gender", 1);
                    cmd.Parameters.AddWithValue("@Start_Working_Date", Convert.ToDateTime(dt.Rows[i]["Start_Working"].ToString()));
                    cmd.Parameters.AddWithValue("@Job_Position_ID", Convert.ToInt32(dt.Rows[i]["JobNo"].ToString()));
                    cmd.Parameters.AddWithValue("@Job_Description", dt.Rows[i]["Position"]);
                    string salary = dt.Rows[i]["Salary"].ToString();
                    salary = salary.Replace(",", "");
                    if (dt.Rows[i]["Salary"].ToString().Contains('$'))
                    {
                        String[] data = dt.Rows[i]["Salary"].ToString().Split('$');
                        cmd.Parameters.AddWithValue("@currency", "$");
                        cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(data[1].ToString()));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@currency", "Ks");
                        cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(salary));
                    }
                    cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Client_Code", SqlDbType.Int).Direction = ParameterDirection.Output;

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
