using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace JSAT_Ver1
{
    public partial class User : System.Web.UI.Page
    {
        string Profile_Photo_DataPath = ConfigurationManager.AppSettings["Profile_Photo_DataPath"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide button
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            bool resultRead = user.CanRead(userID, "010");
            if (resultRead)
            {
                btnSave.Visible = false;
            }
            bool resultEdit = user.CanSave(userID, "010");
            if (resultEdit)
            {
                FileUpload1.ForeColor = Color.Black;
                btnSave.Visible = true;
            }
            else
                btnSave.Visible = false;
            if (!IsPostBack)
            {
                Clear();
                if (Request.QueryString["ID"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    Get_UserInfo(id);
                    txtPassword.Attributes.Add("value", txtPassword.Text);
                    btnSave.Text = "Update";
                }
            }
            else
            {
                if (FileUpload1.HasFile)
                {

                    SaveImageFile();
                    Image2.ImageUrl = "~/img/" + Path.GetFileNameWithoutExtension(FileUpload1.FileName) + ".ico";
                    Session["PreImg"] = Path.GetFileNameWithoutExtension(FileUpload1.FileName) + ".ico";


                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserBL user = new UserBL();
            int id = 0;
            UserEntity userInfo = new UserEntity();
            Set_UserInfo(userInfo);
            if (user.Check_LogInID(userInfo.ID, userInfo.LogIn_ID))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('LogIn_ID Already Exists .Please write another LogIn_ID!');window.location ='User.aspx';", true);
                Clear();
            }
            else
            {
                if (Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["ID"]);
                }
                if (id == 0)
                {
                    user.Insert(userInfo);
                    Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Saved Successfully!');window.location ='User_View.aspx';", true);
                }
                else
                {
                    if (userInfo.ID == Convert.ToInt32(Session["UserID"])) //Changing current logined account
                        Session["Img_name"] = Session["PreImg"];  //setting for SiteMaster profile img
                    Update(userInfo);
                    Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Updated Successfully!');window.location ='User_View.aspx';", true);
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
            Response.Redirect("~/System/User.aspx");
        }

        private void Clear()
        {
            txtUserName.Text = "";
            txtLogInID.Text = "";
            txtPassword.Text = "";
            Session["PreImg"] = "";
            btnSave.Text = "Submit";
        }

        private void Get_UserInfo(int id)
        {
            UserBL user = new UserBL();
            UserEntity userInfo = user.SelectedByID(id);
            txtUserName.Text = userInfo.User_Name;
            txtLogInID.Text = userInfo.LogIn_ID;
            //Image1.ImageUrl = "img/" + Session["Img_name"].ToString();

            if (userInfo.Image_FileName != null && userInfo.Image_FileName != "")
            {
                Image2.ImageUrl = "~/img/" + userInfo.Image_FileName;

            }
            txtPassword.Text = GlobalUI.DecryptPassword(userInfo.Password);
        }

        private void Set_UserInfo(UserEntity userInfo)
        {
            GlobalUI encript = new GlobalUI();
            if (Request.QueryString["ID"] != null)
            {
                userInfo.ID = Convert.ToInt32(Request.QueryString["ID"]);
            }

            userInfo.User_Name = txtUserName.Text;
            userInfo.LogIn_ID = txtLogInID.Text;
            userInfo.Password = GlobalUI.EncryptPassword(txtPassword.Text);
            if (Session["PreImg"] != null)
            {
                userInfo.Image_FileName = Session["PreImg"].ToString();//every img is shown as preview before it is saved.                
                SaveImageFile();
            }

        }
        protected void SaveImageFile() //Save image in custom img folder. not database.
        {
            // Check the extension of image  
            string extension = Path.GetExtension(FileUpload1.FileName);
            if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
            {
                Stream strm = FileUpload1.PostedFile.InputStream;

                using (var image = System.Drawing.Image.FromStream(strm))
                {
                    int newWidth = 30; // New Width of Image in Pixel  
                    int newHeight = 30; // New Height of Image in Pixel  
                    var thumbImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imgRectangle);
                    // Save the file  
                    string targetPath = Server.MapPath(Profile_Photo_DataPath) + Path.GetFileNameWithoutExtension(FileUpload1.FileName) + ".ico";
                    //Server.MapPath(Photo_DataPath)
                    thumbImg.Save(targetPath, ImageFormat.Icon);

                }
            }
        }

        public void Update(UserEntity userInfo)
        {
            UserBL user = new UserBL();
            Set_UserInfo(userInfo);
            user.Update(userInfo);
        }
    }
}