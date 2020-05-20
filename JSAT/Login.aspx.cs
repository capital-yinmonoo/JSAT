using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;

namespace JSAT_Ver1
{
    public partial class Login : System.Web.UI.Page
    {
        LogInBL LogIn;
        UserBL User;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn = new LogInBL();
            UserEntity userInfo = new UserEntity();
            string LogIn_ID = txtLoginID.Text;
            string password = txtPassword.Text;
            userInfo = LogIn.SelectPassword(LogIn_ID);
            string passwords = GlobalUI.DecryptPassword(userInfo.Password);
            if (passwords == password)
            {
                int ID = LogIn.LogInCheck(LogIn_ID, userInfo.Password);
                if (ID > 0)
                {
                    Session["UserID"] = ID;
                    Session["LoginID"] = userInfo.User_Name;
                    if (userInfo.Image_FileName != null)
                    {
                        Session["Img_name"] = userInfo.Image_FileName;
                    }
                    User = new UserBL();
                    User.UpdateIsLogin(ID, 1);
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                GlobalUI.MessageBox("Please enter correct UserID and Password");
                txtLoginID.Focus();
            }
        }
    }
}