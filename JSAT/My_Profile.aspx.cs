using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT_Ver1
{
    public partial class My_Profile : System.Web.UI.Page
    {
        string Profile_Photo_DataPath = ConfigurationManager.AppSettings["Profile_Photo_DataPath"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide button
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            if (!IsPostBack)
            {
                Clear();
                Get_UserInfo(userID);
                txtPassword.Attributes.Add("value", txtPassword.Text);
                btnSave.Text = "Update";
            }
            else
            {
                if (FileUpload1.HasFile)
                {

                    SaveImageFile();
                    Image1.ImageUrl = "~/img/" + Path.GetFileNameWithoutExtension(FileUpload1.FileName) + ".ico";
                    Session["PreImg"] = Path.GetFileNameWithoutExtension(FileUpload1.FileName) + ".ico";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserBL user = new UserBL();
            UserEntity userInfo = new UserEntity();
            Set_UserInfo(userInfo);
            Update(userInfo);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Updated Successfully!');window.location ='My_Profile.aspx';", true);
            if (userInfo.ID == Convert.ToInt32(Session["UserID"])) //Changing current logined account
                Session["Img_name"] = Session["PreImg"];  //setting for SiteMaster profile img
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/My_Profile.aspx");
        }

        private void Clear()
        {
            txtUserName.Text = "";
            txtLogInID.Text = "";
            txtPassword.Text = "";
            btnSave.Text = "Submit";
        }

        private void Get_UserInfo(int id)
        {
            UserBL user = new UserBL();
            UserEntity userInfo = user.SelectedByID(id);
            txtUserName.Text = userInfo.User_Name;
            txtLogInID.Text = userInfo.LogIn_ID;
            if (userInfo.Image_FileName != null && userInfo.Image_FileName != "")
            {
                Image1.ImageUrl = "~/img/" + userInfo.Image_FileName;
            }
            txtPassword.Text = GlobalUI.DecryptPassword(userInfo.Password);
        }

        private void Set_UserInfo(UserEntity userInfo)
        {
            GlobalUI encript = new GlobalUI();
            userInfo.ID = BaseLib.Convert_Int(Session["UserID"].ToString());
            userInfo.User_Name = txtUserName.Text;
            userInfo.LogIn_ID = txtLogInID.Text;
            userInfo.Password = GlobalUI.EncryptPassword(txtPassword.Text);
            if (FileUpload1.PostedFile != null)
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
            //Set_UserInfo(userInfo);
            user.Update(userInfo);
        }
    }
}