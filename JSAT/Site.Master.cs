using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT
{
    public partial class Site : System.Web.UI.MasterPage
    {
         //string Photo_DataPath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();
        protected void Page_Init(object sender, EventArgs e)
        {
            //to maintain Scroll position for long page on postback
            Page.MaintainScrollPositionOnPostBack = true;
            if (Context.Session != null)
            {
                if (Session.IsNewSession)
                {
                    HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];
                    if (newSessionIdCookie != null)
                    {
                        string newSessionIdCookieValue = newSessionIdCookie.Value;
                        if (newSessionIdCookieValue != string.Empty)
                        {
                            // This means Session was timed Out and New Session was started
                            Response.Redirect("~/Login.aspx");
                        }
                    }
                }
            }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    lnkUserID.Text = Session["LoginID"].ToString();
                    hdfUserID.Value = Session["UserID"].ToString();                
                    Image1.ImageUrl ="img/"+ Session["Img_name"].ToString();
                    if (Image1.ImageUrl == "img/") Image1.ImageUrl += "Default_Profile.ico";
                }
                //Menu_Set();
                if (Request.Url.AbsolutePath != "/My_Profile.aspx")
                {
                    string[] path = Request.Url.AbsolutePath.Split("/".ToCharArray());
                    if (path[path.Length - 1].ToString() != "AccessCheck.aspx")
                    {
                        if (!Check_PageAccess(path[path.Length - 1].ToString()))
                            Response.Redirect("~/AccessCheck.aspx");
                    }
                }
            }
        }

        private bool Check_PageAccess(string url)
        {
            bool result = false;
            int userID = BaseLib.Convert_Int(hdfUserID.Value);
            string pagecod = "001";//testing fixed code / modified later
            LogInBL login = new LogInBL();
            result = login.Check_PageAccess(userID, url, pagecod);
            if (result == false)
            {
                GlobalUI.MessageBox("No authorized!");
                return false;
            }
            else
                return true;
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            UserBL User = new UserBL();
            if (Session["UserID"] != null)
            {
                User.UpdateIsLogin(int.Parse(Session["UserID"].ToString()), 0);
            }
            Session["UserID"] = null;
            Session["LoginID"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void lnkMyProfile_Click(object sender, EventArgs e)
        {
            UserBL User = new UserBL();
            if (Session["UserID"] != null)
            {
                User.UpdateIsLogin(int.Parse(Session["UserID"].ToString()), 0);
            }
            Response.Redirect("~/My_Profile.aspx");
        }
    }
}