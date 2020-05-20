using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Ver1;

namespace JSAT_Ver1.Employer
{
    public partial class ClientProfileExcel : System.Web.UI.Page
    {
        Client_Profile_Excel_BL excel_BL;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (up1.HasFile)
                {
                    String[] validFileTypes = { "xlsx", "xls" };
                    if (Checkfile(validFileTypes))
                    {
                        excel_BL = new Client_Profile_Excel_BL();
                        string ext = System.IO.Path.GetExtension(up1.PostedFile.FileName);
                        up1.SaveAs(Server.MapPath("~/Excel_Data/") + Path.GetFileName(up1.FileName));
                        String path = Server.MapPath("~/Excel_Data/") + Path.GetFileName(up1.FileName);
                        DataTable dt = excel_BL.Read(path, ext);
                        excel_BL.Insert(dt);
                        gvdata.DataSource = dt;
                        gvdata.DataBind();
                        GlobalUI.MessageBox("Import Successfully!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool Checkfile(String[] validFileTypes)
        {
            string ext = System.IO.Path.GetExtension(up1.PostedFile.FileName);
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}