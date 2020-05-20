using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Database_Backup : System.Web.UI.Page
    {
        public static string Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public static string BackUpLoc = ConfigurationManager.AppSettings["BackUp_Loc"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            bool resultRead = user.CanRead(userID, "031");
            if (resultRead)
            {
                btnBackup.Visible = false;
            }
            else
                btnBackup.Visible = true;

            bool resultEdit = user.CanSave(userID, "031");
            if (resultEdit)
            {
                btnBackup.Visible = true;
            }
            else
                btnBackup.Visible = false;
        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            BakUp("JSAT");
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = lnkDownload.Text;
                string FileToCheck = BackUpLoc + FileName;
                if (File.Exists(Server.MapPath(FileToCheck)))
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileName + "\"");
                    response.ContentType = "application/octet-stream";
                    byte[] data = req.DownloadData(Server.MapPath(FileToCheck));
                    response.BinaryWrite(data);
                    response.End();
                }
                else
                {
                    GlobalUI.MessageBox("File doesn't exist!");
                }

            }
            catch (Exception ex)
            {
                GlobalUI.MessageBox(ex.Message);
            }
        }

        public void BakUp(string DBName)
        {
            try
            {
                DateTime start = DateTime.Now;
                SqlConnection conn = new SqlConnection(Connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand = new SqlCommand(" BACKUP DATABASE @DBName TO DISK = @PATH ", conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@DBName", DBName);
                string FormattedDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Path = Server.MapPath(BackUpLoc) + DBName + "(" + FormattedDate + ").bak";
                sqlCommand.Parameters.AddWithValue("@PATH", Path);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                lnkDownload.Text = DBName + "(" + FormattedDate + ").bak";
                Console.WriteLine("DB Backup Location : " + Path);
                Console.WriteLine("Press ENTER To Exit!!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}