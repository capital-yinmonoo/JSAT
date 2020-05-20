using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT.Employee
{
    public partial class Career_Information : System.Web.UI.Page
    {
        //public static string previouspage;
        Career_InformationBL careerInformation;
        GenderBL gender;
        Career_InformationEntity careerInformationInfo;

        string IDCard_DataPath = ConfigurationManager.AppSettings["IDCard_DataPath"].ToString();
        string Credential_DataPath = ConfigurationManager.AppSettings["Credential_DataPath"].ToString();
        string Japanese_DataPath = ConfigurationManager.AppSettings["Japanese_DataPath"].ToString();
        string Graduation_DataPath = ConfigurationManager.AppSettings["Graduation_DataPath"].ToString();
        string Photo_DataPath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();
        string Datasheet_DataPath = ConfigurationManager.AppSettings["Datasheet_DataPath"].ToString();
        string Qualification_DataPath = ConfigurationManager.AppSettings["Qualification_DataPath"].ToString();
        string LabourCard_DataPath = ConfigurationManager.AppSettings["LabourCard_DataPath"].ToString();

        int id = 0;
        public int ID
        {
            get
            {
                if (Request.QueryString["ID"] != null)
                    return int.Parse(Request.QueryString["ID"].ToString());
                return 0;
            }
        }

        public int Career_ID
        {
            get
            {
                if (Request.QueryString["Career_ID"] != null)
                    return int.Parse(Request.QueryString["Career_ID"].ToString());
                return 0;
            }
        }

        DataTable dtCareerInformation = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            // User Authorized 
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());

            bool resultRead = user.CanRead(userID, "025");
            if (resultRead)
            {
                btnSubmit.Visible = false;
                //btnDelete.Visible = false;
            }

            bool resultEdit = user.CanSave(userID, "025");
            if (resultEdit)
                btnSubmit.Visible = true;
            else
                btnSubmit.Visible = false;

            Career_InterviewControl1.CareerID = Request.QueryString["Career_ID"];
            Career_InterviewControl1.CarEmploymentlink = true;
            Career_InterviewControl1.CarInterview1link = true;
            Career_InterviewControl1.CarInterview2link = true;
            Career_InterviewControl1.CarInterview3link = true;
            Career_InterviewControl1.CarInformationlink = true;

            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                    //previouspage = Request.UrlReferrer.ToString();
                }
                else ViewState["UrlReferrer"] = null;

                if (Career_ID != 0)
                {
                    btnSubmit.Text = "更新する";
                    FillData();
                    MakeDeleteButtonsVisible(true);
                }
                GetSex();
            }
            
        }
        private void MakeDeleteButtonsVisible(bool status)
        {
            if (!string.IsNullOrWhiteSpace(lnkDatasheetData.Text))
            {
                btnDatasheetDataDelete.Visible = status;
                imgDatasheetData.Visible = status;
                uplDatasheetData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkDatasheetData2.Text))
            {
                btnDatasheetData2Delete.Visible = status;
                imgDatasheetData2.Visible = status;
                uplDatasheetData2.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkDatasheetData3.Text))
            {
                btnDatasheetData3Delete.Visible = status;
                imgDatasheetData3.Visible = status;
                uplDatasheetData3.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkDatasheetData4.Text))
            {
                btnDatasheetData4Delete.Visible = status;
                imgDatasheetData4.Visible = status;
                uplDatasheetData4.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkDatasheetData5.Text))
            {
                btnDatasheetData5Delete.Visible = status;
                imgDatasheetData5.Visible = status;
                uplDatasheetData5.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkPhoto.Text))
            {
                btnPhoto.Visible = status;
                imgPhoto.Visible = status;
                uplPhotoData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkPhoto2.Text))
            {
                btnPhoto2.Visible = status;
                imgPhoto2.Visible = status;
                uplPhotoData2.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkPhoto3.Text))
            {
                btnPhoto3.Visible = status;
                imgPhoto3.Visible = status;
                uplPhotoData3.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCardData.Text))
            {
                btnCardData.Visible = status;
                imgCardData.Visible = status;
                uplCardData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData.Text))
            {
                btnCredentialData.Visible = status;
                imgCredentialData.Visible = status;
                uplCredentialData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData2.Text))
            {
                btnCredentialData2.Visible = status;
                imgCredentialData2.Visible = status;
                uplCredentialData2.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData3.Text))
            {
                btnCredentialData3.Visible = status;
                imgCredentialData3.Visible = status;
                uplCredentialData3.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData4.Text))
            {
                btnCredentialData4.Visible = status;
                imgCredentialData4.Visible = status;
                uplCredentialData4.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData5.Text))
            {
                btnCredentialData5.Visible = status;
                imgCredentialData5.Visible = status;
                uplCredentialData5.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData6.Text))
            {
                btnCredentialData6.Visible = status;
                imgCredentialData6.Visible = status;
                uplCredentialData6.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkCredentialData7.Text))
            {
                btnCredentialData7.Visible = status;
                imgCredentialData7.Visible = status;
                uplCredentialData7.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkJapaneseData.Text))
            {
                btnJapaneseData.Visible = status;
                imgJapaneseData.Visible = status;
                uplJapaeseData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkJapaneseData2.Text))
            {
                btnJapaneseData2.Visible = status;
                imgJapaneseData2.Visible = status;
                uplJapaeseData2.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkJapaneseData3.Text))
            {
                btnJapaneseData3.Visible = status;
                imgJapaneseData3.Visible = status;
                uplJapaeseData3.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkGraduationData.Text))
            {
                btnGraduationData.Visible = status;
                imgGraduationData.Visible = status;
                uplGraduationData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkGraduationData2.Text))
            {
                btnGraduationData2.Visible = status;
                imgGraduationData2.Visible = status;
                uplGraduationData2.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkGraduationData3.Text))
            {
                btnGraduationData3.Visible = status;
                imgGraduationData3.Visible = status;
                uplGraduationData3.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkQualificationData.Text))
            {
                btnQualificationDataDelete.Visible = status;
                imgQualificationData.Visible = status;
                uplQualificationData.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkQualificationData2.Text))
            {
                btnQualificationData2.Visible = status;
                imgQualificationData2.Visible = status;
                uplQualificationData2.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkQualificationData3.Text))
            {
                btnQualificationData3.Visible = status;
                imgQualificationData3.Visible = status;
                uplQualificationData3.ForeColor = Color.White;
            }
            if (!string.IsNullOrWhiteSpace(lnkLabourCard.Text))
            {
                btnLabourCard.Visible = status;
                imgLabourCard.Visible = status;
                uplLabourCard.ForeColor = Color.White;
            }
        }

        private void GetSex()
        {
            try
            {
                gender = new GenderBL();
                ddlSex.DataSource = gender.SelectAll();
                ddlSex.DataTextField = "Description";
                ddlSex.DataValueField = "ID";
                ddlSex.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void FillData()
        {
            try
            {
                careerInformation = new Career_InformationBL();
                careerInformationInfo = new Career_InformationEntity();

                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count != 0)
                {
                    hfCareerCode.Value = dtCareerInformation.Rows[0]["Career_Code"].ToString();
                    careerInformationInfo.Updater = dtCareerInformation.Rows[0]["LogIn_ID"].ToString();
                    careerInformationInfo.UpdateTime = dtCareerInformation.Rows[0]["UpdatedDate"].ToString();
                    careerInformationInfo.Career_ID = (int)dtCareerInformation.Rows[0]["Career_ID"];
                    careerInformationInfo.Name = dtCareerInformation.Rows[0]["Name"].ToString();
                    careerInformationInfo.GenderID = (int)dtCareerInformation.Rows[0]["GenderID"];
                    careerInformationInfo.Address = dtCareerInformation.Rows[0]["Address"].ToString();
                    careerInformationInfo.Remark = dtCareerInformation.Rows[0]["Remark"].ToString();
                    careerInformationInfo.Photo_Data = dtCareerInformation.Rows[0]["Photo"].ToString();
                    careerInformationInfo.Photo_Data2 = dtCareerInformation.Rows[0]["Photo2"].ToString();
                    careerInformationInfo.Photo_Data3 = dtCareerInformation.Rows[0]["Photo3"].ToString();
                    careerInformationInfo.Datasheet_Data = dtCareerInformation.Rows[0]["Datasheet_Data"].ToString();
                    careerInformationInfo.Datasheet_Data2 = dtCareerInformation.Rows[0]["Datasheet_Data2"].ToString();
                    careerInformationInfo.Datasheet_Data3 = dtCareerInformation.Rows[0]["Datasheet_Data3"].ToString();
                    careerInformationInfo.Datasheet_Data4 = dtCareerInformation.Rows[0]["Datasheet_Data4"].ToString();
                    careerInformationInfo.Datasheet_Data5 = dtCareerInformation.Rows[0]["Datasheet_Data5"].ToString();
                    careerInformationInfo.IDCard_Data = dtCareerInformation.Rows[0]["IDCard_Data"].ToString();
                    careerInformationInfo.IDCard_Data2 = dtCareerInformation.Rows[0]["IDCard_Data2"].ToString();
                    careerInformationInfo.IDCard_Data3 = dtCareerInformation.Rows[0]["IDCard_Data3"].ToString();
                    careerInformationInfo.Credential_Data = dtCareerInformation.Rows[0]["Credential_Data"].ToString();
                    careerInformationInfo.Credential_Data2 = dtCareerInformation.Rows[0]["Credential_Data2"].ToString();
                    careerInformationInfo.Credential_Data3 = dtCareerInformation.Rows[0]["Credential_Data3"].ToString();
                    careerInformationInfo.Credential_Data4 = dtCareerInformation.Rows[0]["Credential_Data4"].ToString();
                    careerInformationInfo.Credential_Data5 = dtCareerInformation.Rows[0]["Credential_Data5"].ToString();
                    careerInformationInfo.Credential_Data6 = dtCareerInformation.Rows[0]["Credential_Data6"].ToString();
                    careerInformationInfo.Credential_Data7 = dtCareerInformation.Rows[0]["Credential_Data7"].ToString();
                    careerInformationInfo.Japanese_Data = dtCareerInformation.Rows[0]["Japanese_Data"].ToString();
                    careerInformationInfo.Japanese_Data2 = dtCareerInformation.Rows[0]["Japanese_Data2"].ToString();
                    careerInformationInfo.Japanese_Data3 = dtCareerInformation.Rows[0]["Japanese_Data3"].ToString();
                    careerInformationInfo.Graduation_Data = dtCareerInformation.Rows[0]["Graduation_Data"].ToString();
                    careerInformationInfo.Graduation_Data2 = dtCareerInformation.Rows[0]["Graduation_Data2"].ToString();
                    careerInformationInfo.Graduation_Data3 = dtCareerInformation.Rows[0]["Graduation_Data3"].ToString();
                    careerInformationInfo.Qualification_Data = dtCareerInformation.Rows[0]["Qualification_Data"].ToString();
                    careerInformationInfo.Qualification_Data2 = dtCareerInformation.Rows[0]["Qualification_Data2"].ToString();
                    careerInformationInfo.Qualification_Data3 = dtCareerInformation.Rows[0]["Qualification_Data3"].ToString();
                    careerInformationInfo.LabourCard_Data = dtCareerInformation.Rows[0]["LabourCard_Data"].ToString();
                    careerInformationInfo.LabourCard_Data2 = dtCareerInformation.Rows[0]["LabourCard_Data2"].ToString();
                    careerInformationInfo.LabourCard_Data3 = dtCareerInformation.Rows[0]["LabourCard_Data3"].ToString();
                    careerInformationInfo.IsDeleted = (bool)dtCareerInformation.Rows[0]["IsDeleted"];

                    lblUpdatedBy.Text = careerInformationInfo.Updater;
                    lblUpdatedDate.Text = careerInformationInfo.UpdateTime;
                    //hdfClient_ProfileID.Value = careerInformationInfo.ID.ToString();
                    txtName.Text = careerInformationInfo.Name;
                    ddlSex.SelectedValue = careerInformationInfo.GenderID.ToString();
                    txtAddress.Text = careerInformationInfo.Address;
                    txtRemarks.Text = careerInformationInfo.Remark;

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Photo_Data))
                    {
                        uplPhotoData.ForeColor = Color.White;
                        lnkPhoto.Text = careerInformationInfo.Photo_Data;
                        imgPhoto.ImageUrl = Photo_DataPath + lnkPhoto.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Photo_Data2))
                    {
                        uplPhotoData2.ForeColor = Color.White;
                        lnkPhoto2.Text = careerInformationInfo.Photo_Data2;
                        imgPhoto2.ImageUrl = Photo_DataPath + lnkPhoto2.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Photo_Data3))
                    {
                        uplPhotoData3.ForeColor = Color.White;
                        lnkPhoto3.Text = careerInformationInfo.Photo_Data3;
                        imgPhoto3.ImageUrl = Photo_DataPath + lnkPhoto3.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Datasheet_Data))
                    {
                        lnkDatasheetData.Text = careerInformationInfo.Datasheet_Data;
                        imgDatasheetData.ImageUrl = Datasheet_DataPath + lnkDatasheetData.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Datasheet_Data2))
                    {
                        lnkDatasheetData2.Text = careerInformationInfo.Datasheet_Data2;
                        imgDatasheetData2.ImageUrl = Datasheet_DataPath + lnkDatasheetData2.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Datasheet_Data3))
                    {
                        lnkDatasheetData3.Text = careerInformationInfo.Datasheet_Data3;
                        imgDatasheetData3.ImageUrl = Datasheet_DataPath + lnkDatasheetData3.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Datasheet_Data4))
                    {
                        lnkDatasheetData4.Text = careerInformationInfo.Datasheet_Data4;
                        imgDatasheetData4.ImageUrl = Datasheet_DataPath + lnkDatasheetData4.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Datasheet_Data5))
                    {
                        lnkDatasheetData5.Text = careerInformationInfo.Datasheet_Data5;
                        imgDatasheetData5.ImageUrl = Datasheet_DataPath + lnkDatasheetData5.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.IDCard_Data))
                    {
                        lnkCardData.Text = careerInformationInfo.IDCard_Data;
                        imgCardData.ImageUrl = IDCard_DataPath + lnkCardData.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data))
                    {
                        lnkCredentialData.Text = careerInformationInfo.Credential_Data;
                        imgCredentialData.ImageUrl = Credential_DataPath + lnkCredentialData.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data2))
                    {
                        lnkCredentialData2.Text = careerInformationInfo.Credential_Data2;
                        imgCredentialData2.ImageUrl = Credential_DataPath + lnkCredentialData2.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data3))
                    {
                        lnkCredentialData3.Text = careerInformationInfo.Credential_Data3;
                        imgCredentialData3.ImageUrl = Credential_DataPath + lnkCredentialData3.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data4))
                    {
                        lnkCredentialData4.Text = careerInformationInfo.Credential_Data4;
                        imgCredentialData4.ImageUrl = Credential_DataPath + lnkCredentialData4.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data5))
                    {
                        lnkCredentialData5.Text = careerInformationInfo.Credential_Data5;
                        imgCredentialData5.ImageUrl = Credential_DataPath + lnkCredentialData5.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data6))
                    {
                        lnkCredentialData6.Text = careerInformationInfo.Credential_Data6;
                        imgCredentialData6.ImageUrl = Credential_DataPath + lnkCredentialData6.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Credential_Data7))
                    {
                        lnkCredentialData7.Text = careerInformationInfo.Credential_Data7;
                        imgCredentialData7.ImageUrl = Credential_DataPath + lnkCredentialData7.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Japanese_Data))
                    {
                        lnkJapaneseData.Text = careerInformationInfo.Japanese_Data;
                        imgJapaneseData.ImageUrl = Japanese_DataPath + lnkJapaneseData.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Japanese_Data2))
                    {
                        lnkJapaneseData2.Text = careerInformationInfo.Japanese_Data2;
                        imgJapaneseData2.ImageUrl = Japanese_DataPath + lnkJapaneseData2.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Japanese_Data3))
                    {
                        lnkJapaneseData3.Text = careerInformationInfo.Japanese_Data3;
                        imgJapaneseData3.ImageUrl = Japanese_DataPath + lnkJapaneseData3.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Graduation_Data))
                    {
                        lnkGraduationData.Text = careerInformationInfo.Graduation_Data;
                        imgGraduationData.ImageUrl = Graduation_DataPath + lnkGraduationData.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Graduation_Data2))
                    {
                        lnkGraduationData2.Text = careerInformationInfo.Graduation_Data2;
                        imgGraduationData2.ImageUrl = Graduation_DataPath + lnkGraduationData2.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Graduation_Data3))
                    {
                        lnkGraduationData3.Text = careerInformationInfo.Graduation_Data3;
                        imgGraduationData3.ImageUrl = Graduation_DataPath + lnkGraduationData3.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Qualification_Data))
                    {
                        lnkQualificationData.Text = careerInformationInfo.Qualification_Data;
                        imgQualificationData.ImageUrl = Qualification_DataPath + lnkQualificationData.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Qualification_Data2))
                    {
                        lnkQualificationData2.Text = careerInformationInfo.Qualification_Data2;
                        imgQualificationData2.ImageUrl = Qualification_DataPath + lnkQualificationData2.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Qualification_Data3))
                    {
                        lnkQualificationData3.Text = careerInformationInfo.Qualification_Data3;
                        imgQualificationData3.ImageUrl = Qualification_DataPath + lnkQualificationData3.Text;
                    }

                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.LabourCard_Data))
                    {
                        lnkLabourCard.Text = careerInformationInfo.LabourCard_Data;
                        imgLabourCard.ImageUrl = LabourCard_DataPath + lnkLabourCard.Text;
                    }
                }
                else
                {
                    Career_ResumeBL careerResume = new Career_ResumeBL();
                    Career_ResumeEntity careerResumeInfo = new Career_ResumeEntity();
                    careerInformationInfo.Career_ID = Career_ID;
                    careerResumeInfo = careerResume.SelectByID(Career_ID);
                    lblUpdatedBy.Text = careerInformationInfo.Updater;
                    lblUpdatedDate.Text = careerInformationInfo.UpdateTime;
                    hfCareerCode.Value = careerResumeInfo.Career_Code;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetCareerInformation(Career_InformationEntity careerInformationInfo)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                DataTable dt = careerInformation.SelectByCareerID(Career_ID, 1);
                if (ID != 0)
                {
                    careerInformationInfo.ID = ID;
                }
                if (Career_ID != 0)
                {
                    careerInformationInfo.Career_ID = Career_ID;
                    if (dt.Rows.Count != 0)
                    {
                        careerInformationInfo.ID = (int)dt.Rows[0]["ID"];
                    }
                }
                careerInformationInfo.Name = txtName.Text;
                careerInformationInfo.GenderID = int.Parse(ddlSex.SelectedValue.ToString());
                careerInformationInfo.Address = txtAddress.Text;
                careerInformationInfo.Remark = txtRemarks.Text;
                careerInformationInfo.Photo_Data = lnkPhoto.Text;
                careerInformationInfo.Photo_Data2 = lnkPhoto2.Text;
                careerInformationInfo.Photo_Data3 = lnkPhoto3.Text;
                careerInformationInfo.Datasheet_Data = lnkDatasheetData.Text;
                careerInformationInfo.Datasheet_Data2 = lnkDatasheetData2.Text;
                careerInformationInfo.Datasheet_Data3 = lnkDatasheetData3.Text;
                careerInformationInfo.Datasheet_Data4 = lnkDatasheetData4.Text;
                careerInformationInfo.Datasheet_Data5 = lnkDatasheetData5.Text;
                careerInformationInfo.IDCard_Data = lnkCardData.Text;
                careerInformationInfo.Credential_Data = lnkCredentialData.Text;
                careerInformationInfo.Credential_Data2 = lnkCredentialData2.Text;
                careerInformationInfo.Credential_Data3 = lnkCredentialData3.Text;
                careerInformationInfo.Credential_Data4 = lnkCredentialData4.Text;
                careerInformationInfo.Credential_Data5 = lnkCredentialData5.Text;
                careerInformationInfo.Credential_Data6 = lnkCredentialData6.Text;
                careerInformationInfo.Credential_Data7 = lnkCredentialData7.Text;
                careerInformationInfo.Japanese_Data = lnkJapaneseData.Text;
                careerInformationInfo.Japanese_Data2 = lnkJapaneseData2.Text;
                careerInformationInfo.Japanese_Data3 = lnkJapaneseData3.Text;
                careerInformationInfo.Graduation_Data = lnkGraduationData.Text;
                careerInformationInfo.Graduation_Data2 = lnkGraduationData2.Text;
                careerInformationInfo.Graduation_Data3 = lnkGraduationData3.Text;
                careerInformationInfo.Qualification_Data = lnkQualificationData.Text;
                careerInformationInfo.Qualification_Data2 = lnkQualificationData2.Text;
                careerInformationInfo.Qualification_Data3 = lnkQualificationData3.Text;
                careerInformationInfo.LabourCard_Data = lnkLabourCard.Text;

                // Upload Data Naming Standard
                // "Career_Code" + "UploadControl's Number" + "Upload File Name"
                // e.g. "AC"

                if (uplPhotoData.HasFile)
                {
                    string File = uplPhotoData.FileName;
                    careerInformationInfo.Photo_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplPhotoData.SaveAs(Server.MapPath(Photo_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkPhoto.Text = hfCareerCode.Value + "_01" + "_" + File;
                }

                if (uplPhotoData2.HasFile)
                {
                    string File = uplPhotoData2.FileName;
                    careerInformationInfo.Photo_Data2 = hfCareerCode.Value + "_02" + "_" + File;
                    uplPhotoData2.SaveAs(Server.MapPath(Photo_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkPhoto2.Text = hfCareerCode.Value + "_02" + "_" + File;
                }

                if (uplPhotoData3.HasFile)
                {
                    string File = uplPhotoData3.FileName;
                    careerInformationInfo.Photo_Data3 = hfCareerCode.Value + "_03" + "_" + File;
                    uplPhotoData3.SaveAs(Server.MapPath(Photo_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkPhoto3.Text = hfCareerCode.Value + "_03" + "_" + File;
                }

                if (uplDatasheetData.HasFile)
                {
                    string File = uplDatasheetData.FileName;
                    careerInformationInfo.Datasheet_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplDatasheetData.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkDatasheetData.Text = hfCareerCode.Value + "_01" + "_" + File;
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }

                if (uplDatasheetData2.HasFile)
                {
                    string File = uplDatasheetData2.FileName;
                    careerInformationInfo.Datasheet_Data2 = hfCareerCode.Value + "_02" + "_" + File;
                    uplDatasheetData2.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkDatasheetData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }

                if (uplDatasheetData3.HasFile)
                {
                    string File = uplDatasheetData3.FileName;
                    careerInformationInfo.Datasheet_Data3 = hfCareerCode.Value + "_03" + "_" + File;
                    uplDatasheetData3.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkDatasheetData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }

                if (uplDatasheetData4.HasFile)
                {
                    string File = uplDatasheetData4.FileName;
                    careerInformationInfo.Datasheet_Data4 = hfCareerCode.Value + "_04" + "_" + File;
                    uplDatasheetData4.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    lnkDatasheetData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }

                if (uplDatasheetData5.HasFile)
                {
                    string File = uplDatasheetData5.FileName;
                    careerInformationInfo.Datasheet_Data5 = hfCareerCode.Value + "_05" + "_" + File;
                    uplDatasheetData5.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    lnkDatasheetData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }
                if (uplCardData.HasFile)
                {
                    string File = uplCardData.FileName;
                    careerInformationInfo.IDCard_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplCardData.SaveAs(Server.MapPath(IDCard_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    //lblCardData.Text = hfCareerCode.Value + "_" + File;
                    lnkCardData.Text = hfCareerCode.Value + "_01" + "_" + File;
                }

                if (uplCredentialData.HasFile)
                {
                    string File = uplCredentialData.FileName;
                    careerInformationInfo.Credential_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplCredentialData.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData.Text = hfCareerCode.Value + "_01" + "_" + File;
                }

                if (uplCredentialData2.HasFile)
                {
                    string File = uplCredentialData2.FileName;
                    careerInformationInfo.Credential_Data2 = hfCareerCode.Value + "_02" + "_" + File;
                    uplCredentialData2.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                }

                if (uplCredentialData3.HasFile)
                {
                    string File = uplCredentialData3.FileName;
                    careerInformationInfo.Credential_Data3 = hfCareerCode.Value + "_03" + "_" + File;
                    uplCredentialData3.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                }
                if (uplCredentialData4.HasFile)
                {
                    string File = uplCredentialData4.FileName;
                    careerInformationInfo.Credential_Data4 = hfCareerCode.Value + "_04" + "_" + File;
                    uplCredentialData4.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                }
                if (uplCredentialData5.HasFile)
                {
                    string File = uplCredentialData5.FileName;
                    careerInformationInfo.Credential_Data5 = hfCareerCode.Value + "_05" + "_" + File;
                    uplCredentialData5.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                }
                if (uplCredentialData6.HasFile)
                {
                    string File = uplCredentialData6.FileName;
                    careerInformationInfo.Credential_Data6 = hfCareerCode.Value + "_06" + "_" + File;
                    uplCredentialData6.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_06" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData6.Text = hfCareerCode.Value + "_06" + "_" + File;
                }
                if (uplCredentialData7.HasFile)
                {
                    string File = uplCredentialData7.FileName;
                    careerInformationInfo.Credential_Data7 = hfCareerCode.Value + "_07" + "_" + File;
                    uplCredentialData7.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_07" + "_" + File);
                    //lblCredentialData.Text = hfCareerCode.Value + "_" + File;
                    lnkCredentialData7.Text = hfCareerCode.Value + "_07" + "_" + File;
                }
                if (uplJapaeseData.HasFile)
                {
                    string File = uplJapaeseData.FileName;
                    careerInformationInfo.Japanese_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplJapaeseData.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    //lblJapaneseData.Text = hfCareerCode.Value + "_" + File;
                    lnkJapaneseData.Text = hfCareerCode.Value + "_01" + "_" + File;
                }

                if (uplJapaeseData2.HasFile)
                {
                    string File = uplJapaeseData2.FileName;
                    careerInformationInfo.Japanese_Data2 = hfCareerCode.Value + "_02" + "_" + File;
                    uplJapaeseData2.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    //lblJapaneseData.Text = hfCareerCode.Value + "_" + File;
                    lnkJapaneseData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                }

                if (uplJapaeseData3.HasFile)
                {
                    string File = uplJapaeseData3.FileName;
                    careerInformationInfo.Japanese_Data3 = hfCareerCode.Value + "_03" + "_" + File;
                    uplJapaeseData3.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    //lblJapaneseData.Text = hfCareerCode.Value + "_" + File;
                    lnkJapaneseData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                }

                if (uplGraduationData.HasFile)
                {
                    string File = uplGraduationData.FileName;
                    careerInformationInfo.Graduation_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplGraduationData.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData.Text = hfCareerCode.Value + "_01" + "_" + File;
                }

                if (uplGraduationData2.HasFile)
                {
                    string File = uplGraduationData2.FileName;
                    careerInformationInfo.Graduation_Data2 = hfCareerCode.Value + "_02" + "_" + File;
                    uplGraduationData2.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                }

                if (uplGraduationData3.HasFile)
                {
                    string File = uplGraduationData3.FileName;
                    careerInformationInfo.Graduation_Data3 = hfCareerCode.Value + "_03" + "_" + File;
                    uplGraduationData3.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                }

                if (uplQualificationData.HasFile)
                {
                    string File = uplQualificationData.FileName;
                    careerInformationInfo.Qualification_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplQualificationData.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkQualificationData.Text = hfCareerCode.Value + "_01" + "_" + File;
                }

                if (uplQualificationData2.HasFile)
                {
                    string File = uplQualificationData2.FileName;
                    careerInformationInfo.Qualification_Data2 = hfCareerCode.Value + "_02" + "_" + File;
                    uplQualificationData2.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkQualificationData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                }

                if (uplQualificationData3.HasFile)
                {
                    string File = uplQualificationData3.FileName;
                    careerInformationInfo.Qualification_Data3 = hfCareerCode.Value + "_03" + "_" + File;
                    uplQualificationData3.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkQualificationData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                }

                if (uplLabourCard.HasFile)
                {
                    string File = uplLabourCard.FileName;
                    careerInformationInfo.LabourCard_Data = hfCareerCode.Value + "_01" + "_" + File;
                    uplLabourCard.SaveAs(Server.MapPath(LabourCard_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkLabourCard.Text = hfCareerCode.Value + "_01" + "_" + File;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            try
            {
                careerInformation = new Career_InformationBL();
                careerInformationInfo = new Career_InformationEntity();

                SetCareerInformation(careerInformationInfo);
                if (careerInformationInfo != null)
                {
                    CreatedDateTime();
                    UpdatedDateTime();
                    string result = careerInformation.Insert(careerInformationInfo, (int)EnumBase.Save.Insert);
                    if (result == "Save success!")
                    {
                        Response.Write("<script>alert('Save success!')</script>");
                        Response.Write("<script>window.location.href='Career_Information.aspx?Career_ID='+Career_ID</script>");
                        
                    }
                    else
                    {
                        GlobalUI.MessageBox(result);
                    }
                    //GlobalUI.MessageBox(result);
                    MakeDeleteButtonsVisible(true);
                }

            }
            catch (Exception ex)
            {
                GlobalUI.MessageBox(ex.Message);
                throw;
            }

        }

        private void Update()
        {
            try
            {
                careerInformation = new Career_InformationBL();
                careerInformationInfo = new Career_InformationEntity();

                SetCareerInformation(careerInformationInfo);
                if (careerInformationInfo != null)
                {
                  
                    UpdatedDateTime();
                    string result = careerInformation.Update(careerInformationInfo, (int)EnumBase.Save.Update);
                    if (result == "Update success!")
                    {
                        Response.Write("<script>alert('Update success!')</script>");
                        Response.Write("<script>window.location.href='Career_Information.aspx?Career_ID='+Career_ID</script>");
                        
                    }
                    else
                    {
                        GlobalUI.MessageBox(result);
                    }
                  
                    FillData();
                    MakeDeleteButtonsVisible(true);
                }
                id = careerInformationInfo.ID;
            }
            catch (Exception ex)
            {
                GlobalUI.MessageBox(ex.Message);
                throw;
            }

        }

        protected void CreatedDateTime()
        {
            try
            {
                careerInformationInfo.CreatedBy = Convert.ToInt32(Session["UserID"]);
                careerInformationInfo.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void UpdatedDateTime()
        {
            try
            {
                careerInformationInfo.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                careerInformationInfo.UpdatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected DateTime DeletedDateTime()
        {
            try
            {
                careerInformationInfo.DeletedBy = Convert.ToInt32(Session["UserID"]);
                return Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                DataTable dtCareerInfo = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInfo.Rows.Count == 0)
                {
                    Save();
                }
                else
                {
                    Update();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Photo_DataPath + lnkPhoto.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkPhoto2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Photo_DataPath + lnkPhoto2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkPhoto3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Photo_DataPath + lnkPhoto3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkDatasheetData_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkDatasheetData2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkDatasheetData3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkDatasheetData4_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData4.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkDatasheetData5_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData5.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCardData_Click(object sender, EventArgs e)
        {
            try
            {
                Download(IDCard_DataPath + lnkCardData.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData4_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData4.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData5_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData5.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData6_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData6.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkCredentialData7_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData7.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkJapaneseData_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Japanese_DataPath + lnkJapaneseData.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkJapaneseData2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Japanese_DataPath + lnkJapaneseData2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkJapaneseData3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Japanese_DataPath + lnkJapaneseData3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkGraduationData_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Graduation_DataPath + lnkGraduationData.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkGraduationData2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Graduation_DataPath + lnkGraduationData2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkGraduationData3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Graduation_DataPath + lnkGraduationData3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkQualificationData_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkQualificationData2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkQualificationData3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkLabourCard_Click(object sender, EventArgs e)
        {
            try
            {
                Download(LabourCard_DataPath + lnkLabourCard.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Download(string FileToCheck)
        {
            try
            {
                if (File.Exists(Server.MapPath(FileToCheck)))
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileToCheck + "\"");
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
                throw ex;
            }
        }

        protected void btnDatasheetDataDelete_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string DatasheetFilePath = Server.MapPath(Datasheet_DataPath) + dtCareerInformation.Rows[0]["Datasheet_Data"].ToString();
                    if (File.Exists(DatasheetFilePath))
                    {
                        System.IO.File.Delete(DatasheetFilePath);
                        lnkDatasheetData.Text = string.Empty;
                        btnDatasheetDataDelete.Visible = false;
                        imgDatasheetData.Visible = false;
                        uplDatasheetData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDatasheetData2Delete_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string DatasheetFilePath2 = Server.MapPath(Datasheet_DataPath) + dtCareerInformation.Rows[0]["Datasheet_Data2"].ToString();
                    if (File.Exists(DatasheetFilePath2))
                    {
                        System.IO.File.Delete(DatasheetFilePath2);
                        lnkDatasheetData2.Text = string.Empty;
                        btnDatasheetData2Delete.Visible = false;
                        imgDatasheetData2.Visible = false;
                        uplDatasheetData2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDatasheetData3Delete_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string DatasheetFilePath3 = Server.MapPath(Datasheet_DataPath) + dtCareerInformation.Rows[0]["Datasheet_Data3"].ToString();
                    if (File.Exists(DatasheetFilePath3))
                    {
                        System.IO.File.Delete(DatasheetFilePath3);
                        lnkDatasheetData3.Text = string.Empty;
                        btnDatasheetData3Delete.Visible = false;
                        imgDatasheetData3.Visible = false;
                        uplDatasheetData3.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDatasheetData4Delete_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string DatasheetFilePath4 = Server.MapPath(Datasheet_DataPath) + dtCareerInformation.Rows[0]["Datasheet_Data4"].ToString();
                    if (File.Exists(DatasheetFilePath4))
                    {
                        System.IO.File.Delete(DatasheetFilePath4);
                        lnkDatasheetData4.Text = string.Empty;
                        btnDatasheetData4Delete.Visible = false;
                        imgDatasheetData4.Visible = false;
                        uplDatasheetData4.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDatasheetData5Delete_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string DatasheetFilePath5 = Server.MapPath(Datasheet_DataPath) + dtCareerInformation.Rows[0]["Datasheet_Data5"].ToString();
                    if (File.Exists(DatasheetFilePath5))
                    {
                        System.IO.File.Delete(DatasheetFilePath5);
                        lnkDatasheetData5.Text = string.Empty;
                        btnDatasheetData5Delete.Visible = false;
                        imgDatasheetData5.Visible = false;
                        uplDatasheetData5.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string PhotoFilePath = Server.MapPath(Photo_DataPath) + dtCareerInformation.Rows[0]["Photo"].ToString();
                    if (File.Exists(PhotoFilePath))
                    {
                        System.IO.File.Delete(PhotoFilePath);
                        lnkPhoto.Text = string.Empty;
                        btnPhoto.Visible = false;
                        imgPhoto.Visible = false;
                        uplPhotoData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnPhoto2_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string Photo2FilePath = Server.MapPath(Photo_DataPath) + dtCareerInformation.Rows[0]["Photo2"].ToString();
                    if (File.Exists(Photo2FilePath))
                    {
                        System.IO.File.Delete(Photo2FilePath);
                        lnkPhoto2.Text = string.Empty;
                        btnPhoto2.Visible = false;
                        imgPhoto2.Visible = false;
                        uplPhotoData2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPhoto3_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string Photo3FilePath = Server.MapPath(Photo_DataPath) + dtCareerInformation.Rows[0]["Photo3"].ToString();
                    if (File.Exists(Photo3FilePath))
                    {
                        System.IO.File.Delete(Photo3FilePath);
                        lnkPhoto3.Text = string.Empty;
                        btnPhoto3.Visible = false;
                        imgPhoto3.Visible = false;
                        uplPhotoData3.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCardData_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CardDataFilePath = Server.MapPath(IDCard_DataPath) + dtCareerInformation.Rows[0]["IDCard_Data"].ToString();
                    if (File.Exists(CardDataFilePath))
                    {
                        System.IO.File.Delete(CardDataFilePath);
                        lnkCardData.Text = string.Empty;
                        btnCardData.Visible = false;
                        imgCardData.Visible = false;
                        uplCardData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCredentialData_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialDataFilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data"].ToString();
                    if (File.Exists(CredentialDataFilePath))
                    {
                        System.IO.File.Delete(CredentialDataFilePath);
                        lnkCredentialData.Text = string.Empty;
                        btnCredentialData.Visible = false;
                        imgCredentialData.Visible = false;
                        uplCredentialData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnCredentialData2_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialData2FilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data2"].ToString();
                    if (File.Exists(CredentialData2FilePath))
                    {
                        System.IO.File.Delete(CredentialData2FilePath);
                        lnkCredentialData2.Text = string.Empty;
                        btnCredentialData2.Visible = false;
                        imgCredentialData2.Visible = false;
                        uplCredentialData2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnCredentialData3_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialData3FilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data3"].ToString();
                    if (File.Exists(CredentialData3FilePath))
                    {
                        System.IO.File.Delete(CredentialData3FilePath);
                        lnkCredentialData3.Text = string.Empty;
                        btnCredentialData3.Visible = false;
                        imgCredentialData3.Visible = false;
                        uplCredentialData3.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCredentialData4_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialData4FilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data4"].ToString();
                    if (File.Exists(CredentialData4FilePath))
                    {
                        System.IO.File.Delete(CredentialData4FilePath);
                        lnkCredentialData4.Text = string.Empty;
                        btnCredentialData4.Visible = false;
                        imgCredentialData4.Visible = false;
                        uplCredentialData4.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnCredentialData5_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialData5FilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data5"].ToString();
                    if (File.Exists(CredentialData5FilePath))
                    {
                        System.IO.File.Delete(CredentialData5FilePath);
                        lnkCredentialData5.Text = string.Empty;
                        btnCredentialData5.Visible = false;
                        imgCredentialData5.Visible = false;
                        uplCredentialData5.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnCredentialData6_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialData6FilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data6"].ToString();
                    if (File.Exists(CredentialData6FilePath))
                    {
                        System.IO.File.Delete(CredentialData6FilePath);
                        lnkCredentialData6.Text = string.Empty;
                        btnCredentialData6.Visible = false;
                        imgCredentialData6.Visible = false;
                        uplCredentialData6.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCredentialData7_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string CredentialData7FilePath = Server.MapPath(Credential_DataPath) + dtCareerInformation.Rows[0]["Credential_Data7"].ToString();
                    if (File.Exists(CredentialData7FilePath))
                    {
                        System.IO.File.Delete(CredentialData7FilePath);
                        lnkCredentialData7.Text = string.Empty;
                        btnCredentialData7.Visible = false;
                        imgCredentialData7.Visible = false;
                        uplCredentialData7.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void btnJapaneseData_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string JapaneseDataFilePath = Server.MapPath(Japanese_DataPath) + dtCareerInformation.Rows[0]["Japanese_Data"].ToString();
                    if (File.Exists(JapaneseDataFilePath))
                    {
                        System.IO.File.Delete(JapaneseDataFilePath);
                        lnkJapaneseData.Text = string.Empty;
                        btnJapaneseData.Visible = false;
                        imgJapaneseData.Visible = false;
                        uplJapaeseData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnJapaneseData2_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string JapaneseData2FilePath = Server.MapPath(Japanese_DataPath) + dtCareerInformation.Rows[0]["Japanese_Data2"].ToString();
                    if (File.Exists(JapaneseData2FilePath))
                    {
                        System.IO.File.Delete(JapaneseData2FilePath);
                        lnkJapaneseData2.Text = string.Empty;
                        btnJapaneseData2.Visible = false;
                        imgJapaneseData2.Visible = false;
                        uplJapaeseData2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnJapaneseData3_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string JapaneseData3FilePath = Server.MapPath(Japanese_DataPath) + dtCareerInformation.Rows[0]["Japanese_Data3"].ToString();
                    if (File.Exists(JapaneseData3FilePath))
                    {
                        System.IO.File.Delete(JapaneseData3FilePath);
                        lnkJapaneseData3.Text = string.Empty;
                        btnJapaneseData3.Visible = false;
                        imgJapaneseData3.Visible = false;
                        uplJapaeseData3.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnGraduationData_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string GraduationDataFilePath = Server.MapPath(Graduation_DataPath) + dtCareerInformation.Rows[0]["Graduation_Data"].ToString();
                    if (File.Exists(GraduationDataFilePath))
                    {
                        System.IO.File.Delete(GraduationDataFilePath);
                        lnkGraduationData.Text = string.Empty;
                        btnGraduationData.Visible = false;
                        imgGraduationData.Visible = false;
                        uplGraduationData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnGraduationData2_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string GraduationData2FilePath = Server.MapPath(Graduation_DataPath) + dtCareerInformation.Rows[0]["Graduation_Data2"].ToString();
                    if (File.Exists(GraduationData2FilePath))
                    {
                        System.IO.File.Delete(GraduationData2FilePath);
                        lnkGraduationData2.Text = string.Empty;
                        btnGraduationData2.Visible = false;
                        imgGraduationData2.Visible = false;
                        uplGraduationData2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnGraduationData3_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string GraduationData3FilePath = Server.MapPath(Graduation_DataPath) + dtCareerInformation.Rows[0]["Graduation_Data3"].ToString();
                    if (File.Exists(GraduationData3FilePath))
                    {
                        System.IO.File.Delete(GraduationData3FilePath);
                        lnkGraduationData3.Text = string.Empty;
                        btnGraduationData3.Visible = false;
                        imgGraduationData3.Visible = false;
                        uplGraduationData3.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnQualificationDataDelete_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string QualificationDataFilePath = Server.MapPath(Qualification_DataPath) + dtCareerInformation.Rows[0]["Qualification_Data"].ToString();
                    if (File.Exists(QualificationDataFilePath))
                    {
                        System.IO.File.Delete(QualificationDataFilePath);
                        lnkQualificationData.Text = string.Empty;
                        btnQualificationDataDelete.Visible = false;
                        imgQualificationData.Visible = false;
                        uplQualificationData.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnQualificationData2_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string QualificationDataFilePath = Server.MapPath(Qualification_DataPath) + dtCareerInformation.Rows[0]["Qualification_Data2"].ToString();
                    if (File.Exists(QualificationDataFilePath))
                    {
                        System.IO.File.Delete(QualificationDataFilePath);
                        lnkQualificationData2.Text = string.Empty;
                        btnQualificationData2.Visible = false;
                        imgQualificationData2.Visible = false;
                        uplQualificationData2.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnQualificationData3_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string QualificationDataFilePath = Server.MapPath(Qualification_DataPath) + dtCareerInformation.Rows[0]["Qualification_Data3"].ToString();
                    if (File.Exists(QualificationDataFilePath))
                    {
                        System.IO.File.Delete(QualificationDataFilePath);
                        lnkQualificationData3.Text = string.Empty;
                        btnQualificationData3.Visible = false;
                        imgQualificationData3.Visible = false;
                        uplQualificationData3.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnLabourCard_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    string LabourCardDataFilePath = Server.MapPath(LabourCard_DataPath) + dtCareerInformation.Rows[0]["LabourCard_Data"].ToString();
                    if (File.Exists(LabourCardDataFilePath))
                    {
                        System.IO.File.Delete(LabourCardDataFilePath);
                        lnkLabourCard.Text = string.Empty;
                        btnLabourCard.Visible = false;
                        imgLabourCard.Visible = false;
                        uplLabourCard.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnEmploymentRecord_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/CareerEmployment.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCheckComment_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Interview3.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnForJSAT_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Interview.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCareerResume_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Resume.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}