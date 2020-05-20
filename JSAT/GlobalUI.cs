using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;

namespace JSAT_Ver1
{
    public class GlobalUI
    {
        public static void MessageBox(string message)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = message.Replace("'", "\\'");
            string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";

            // Gets the executing web page
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(GlobalUI), "alert", script);
            }
        }

        public static string Format_Date(string strDate)
        {
            string ConvertedDate = Convert.ToDateTime(strDate, CultureInfo.GetCultureInfo("en-US")).ToString("dd / MMM / yyyy");
            return ConvertedDate;
        }

        public static string Format_Salary(int intsalary)
        {
            return string.Format("{0:#,###0}", intsalary);
        }

        public static void File_Download(string URL)
        {
            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + URL + "\"");
            response.ContentType = "application/octet-stream";
            byte[] data = req.DownloadData(URL);
            response.BinaryWrite(data);
            response.End();
        }

        public static void ExporttoExcel(DataTable dt)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");
            HttpContext.Current.Response.Charset = "";
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in dt.Rows)
            {
                //write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }
                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static DataTable ImporttoExcel(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["ExcelConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["ExcelConString"].ConnectionString;
                    break;
            }

            conStr = String.Format(conStr, FilePath);
            OleDbConnection connExcel = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\MyData\\Projects\\JSAT_Source\\JSAT.root\\JSAT\\JSAT\\Upload Folder\\test2.xls;Extended Properties='Excel 4.0;HDR=No;IMEX=1';");
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;
            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();
            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            return dt;

        }

        public static void ExportToCsv(DataTable dt)
        {
            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=test.csv");
            HttpContext.Current.Response.Write(ExportToCSVFile(dt));
            HttpContext.Current.Response.End();
        }

        private static string ExportToCSVFile(DataTable dtTable)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + ',');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        string RemoveLineBreaks = row[column].ToString().Replace("\r\n", " ");
                        sbldr.Append(RemoveLineBreaks + ',');
                    }
                    sbldr.Append("\r\n");
                }
            }
            return sbldr.ToString();
        }

        public static DataTable ImportFromCsvFile(string Path)
        {
            StreamReader sr = new StreamReader(Path);
            string line = sr.ReadLine();
            string[] value = line.Split(',');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value)
            {
                dt.Columns.Add(new DataColumn(dc));
            }
            while (!sr.EndOfStream)
            {
                value = sr.ReadLine().Split(',');
                if (value.Length == dt.Columns.Count)
                {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        public static string EncryptPassword(string txtPassword)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
            string encryptPassword = Convert.ToBase64String(passBytes);
            return encryptPassword;
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }

        public static bool CanSave(int userID, string pageCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select CanEdit From User_Role inner JOIN Menu on MenuID=menu.ID Where UserID=" + userID + " and Page_Code='" + pageCode + "' and CanEdit=1", ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sda.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            sda.SelectCommand.Connection.Open();
            sda.Fill(dt);
            sda.SelectCommand.Connection.Close();
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public static string FormatDatenew(string strDate)
        {
            string ConvertedDate = string.Empty;
            if (!String.IsNullOrWhiteSpace(strDate))
            {
                ConvertedDate = Convert.ToDateTime(strDate, CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd");
            }
            else
            {
                ConvertedDate = strDate;
            }
            return ConvertedDate;
        }
    }
}