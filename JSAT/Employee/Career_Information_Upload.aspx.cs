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
using JSAT.Properties;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT.Employee
{
    public partial class Career_Information_Upload : System.Web.UI.Page
    {
        Career_Information_UploadBL careerInformation;
        String UploadType = String.Empty;
        //  GenderBL gender;
        // Career_InformationEntity careerInformationInfo1;
        Career_Information_Upload_Entity careerInformationInfo;

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
                // GetSex();
            }

        }
        private void MakeDeleteButtonsVisible(bool status)
        {
            #region Datasheet Data
            SetValueControl(lnkDatasheetData, btnDatasheetDataDelete, imgDatasheetData, uplDatasheetData, status);
            SetValueControl(lnkDatasheetData2, btnDatasheetData2Delete, imgDatasheetData2, uplDatasheetData2, status);
            SetValueControl(lnkDatasheetData3, btnDatasheetData3Delete, imgDatasheetData3, uplDatasheetData3, status);
            SetValueControl(lnkDatasheetData4, btnDatasheetData4Delete, imgDatasheetData4, uplDatasheetData4, status);
            SetValueControl(lnkDatasheetData5, btnDatasheetData5Delete, imgDatasheetData5, uplDatasheetData5, status);
            SetValueControl(lnkDatasheetData6, btnDatasheetData6Delete, imgDatasheetData6, uplDatasheetData6, status);
            SetValueControl(lnkDatasheetData7, btnDatasheetData7Delete, imgDatasheetData7, uplDatasheetData7, status);
            SetValueControl(lnkDatasheetData8, btnDatasheetData8Delete, imgDatasheetData8, uplDatasheetData8, status);
            #endregion

            #region Japanese Data
            SetValueControl(lnkJapaneseData, btnJapaneseData, imgJapaneseData, uplJapaeseData, status);
            SetValueControl(lnkJapaneseData2, btnJapaneseData2, imgJapaneseData2, uplJapaeseData2, status);
            SetValueControl(lnkJapaneseData3, btnJapaneseData3, imgJapaneseData3, uplJapaeseData3, status);
            SetValueControl(lnkJapaneseData4, btnJapaneseData4, imgJapaneseData4, uplJapaeseData4, status);
            SetValueControl(lnkJapaneseData5, btnJapaneseData5, imgJapaneseData5, uplJapaeseData5, status);
            #endregion

            #region CV Data
            SetValueControl(lnkCredentialData, btnCredentialData, imgCredentialData, uplCredentialData, status);
            SetValueControl(lnkCredentialData2, btnCredentialData2, imgCredentialData2, uplCredentialData2, status);
            SetValueControl(lnkCredentialData3, btnCredentialData3, imgCredentialData3, uplCredentialData3, status);
            SetValueControl(lnkCredentialData4, btnCredentialData4, imgCredentialData4, uplCredentialData4, status);
            SetValueControl(lnkCredentialData5, btnCredentialData5, imgCredentialData5, uplCredentialData5, status);
            SetValueControl(lnkCredentialData6, btnCredentialData6, imgCredentialData6, uplCredentialData6, status);
            SetValueControl(lnkCredentialData7, btnCredentialData7, imgCredentialData7, uplCredentialData7, status);
            SetValueControl(lnkCredentialData8, btnCredentialData8, imgCredentialData8, uplCredentialData8, status);
            SetValueControl(lnkCredentialData9, btnCredentialData9, imgCredentialData9, uplCredentialData9, status);
            SetValueControl(lnkCredentialData10, btnCredentialData10, imgCredentialData10, uplCredentialData10, status);
            SetValueControl(lnkCredentialData11, btnCredentialData11, imgCredentialData11, uplCredentialData11, status);
            SetValueControl(lnkCredentialData12, btnCredentialData12, imgCredentialData12, uplCredentialData12, status);
            SetValueControl(lnkCredentialData13, btnCredentialData13, imgCredentialData13, uplCredentialData13, status);
            SetValueControl(lnkCredentialData14, btnCredentialData14, imgCredentialData14, uplCredentialData14, status);
            SetValueControl(lnkCredentialData15, btnCredentialData15, imgCredentialData15, uplCredentialData15, status);
            #endregion

            #region Photo Data
            SetValueControl(lnkPhoto, btnPhoto, imgPhoto, uplPhotoData, status);
            SetValueControl(lnkPhoto2, btnPhoto2, imgPhoto2, uplPhotoData2, status);
            SetValueControl(lnkPhoto3, btnPhoto3, imgPhoto3, uplPhotoData3, status);
            #endregion

            #region Graduation Data
            SetValueControl(lnkGraduationData, btnGraduationData, imgGraduationData, uplGraduationData, status);
            SetValueControl(lnkGraduationData2, btnGraduationData2, imgGraduationData2, uplGraduationData2, status);
            SetValueControl(lnkGraduationData3, btnGraduationData3, imgGraduationData3, uplGraduationData3, status);
            SetValueControl(lnkGraduationData4, btnGraduationData4, imgGraduationData4, uplGraduationData4, status);
            SetValueControl(lnkGraduationData5, btnGraduationData5, imgGraduationData5, uplGraduationData5, status);
            #endregion

            #region Qualificatoin Data
            SetValueControl(lnkQualificationData, btnQualificationDataDelete, imgQualificationData, uplQualificationData, status);
            SetValueControl(lnkQualificationData, btnQualificationData2, imgQualificationData2, uplQualificationData2, status);
            SetValueControl(lnkQualificationData, btnQualificationData3, imgQualificationData3, uplQualificationData3, status);
            SetValueControl(lnkQualificationData, btnQualificationData4, imgQualificationData4, uplQualificationData4, status);
            SetValueControl(lnkQualificationData, btnQualificationData5, imgQualificationData5, uplQualificationData5, status);
            SetValueControl(lnkQualificationData, btnQualificationData6, imgQualificationData6, uplQualificationData6, status);
            SetValueControl(lnkQualificationData, btnQualificationData7, imgQualificationData7, uplQualificationData7, status);
            SetValueControl(lnkQualificationData, btnQualificationData8, imgQualificationData8, uplQualificationData8, status);
            SetValueControl(lnkQualificationData, btnQualificationData9, imgQualificationData9, uplQualificationData9, status);
            SetValueControl(lnkQualificationData, btnQualificationData10, imgQualificationData10, uplQualificationData10, status);
            #endregion

            #region IDCard Data
            SetValueControl(lnkCardData, btnCardData, imgCardData, uplCardData, status);
            SetValueControl(lnkCardData2, btnCardData2, imgCardData2, uplCardData2, status);
            SetValueControl(lnkCardData3, btnCardData3, imgCardData3, uplCardData3, status);
            #endregion

            #region Labour Card Data
            SetValueControl(lnkLabourCard, btnLabourCard, imgLabourCard, uplLabourCard, status);
            SetValueControl(lnkLabourCard2, btnLabourCard2, imgLabourCard2, uplLabourCard2, status);
            SetValueControl(lnkLabourCard3, btnLabourCard3, imgLabourCard3, uplLabourCard3, status);
            #endregion
        }

        protected void SetValueControl(LinkButton lnk, Button btn, ImageButton imgbtn, FileUpload upl, Boolean status)
        {
            if (!String.IsNullOrWhiteSpace(lnk.Text))
            {
                btn.Visible = status;
                imgbtn.Visible = status;
                upl.ForeColor = Color.White;
            }
        }

        protected void FillData()
        {
            try
            {
                careerInformation = new Career_Information_UploadBL();
                careerInformationInfo = new Career_Information_Upload_Entity();

                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count != 0)
                {

                    for (int i = 0; i < dtCareerInformation.Rows.Count; i++)
                    {
                        hfCareerCode.Value = dtCareerInformation.Rows[i]["Career_Code"].ToString();
                        //careerInformationInfo.Updater = dtCareerInformation.Rows[i]["LogIn_ID"].ToString();
                        //careerInformationInfo1.UpdateTime = dtCareerInformation.Rows[i]["UpdatedDate"].ToString();
                        careerInformationInfo.Career_ID = (int)dtCareerInformation.Rows[i]["Career_ID"];
                        //careerInformationInfo1.Name = dtCareerInformation.Rows[i]["Name"].ToString();
                        //careerInformationInfo1.GenderID = (int)dtCareerInformation.Rows[i]["GenderID"];
                        //careerInformationInfo1.Address = dtCareerInformation.Rows[i]["Address"].ToString();
                        //careerInformationInfo1.Remark = dtCareerInformation.Rows[i]["Remark"].ToString();
                        UploadType = dtCareerInformation.Rows[i]["Upload_TypeID"].ToString();
                        //   if (dtCareerInformation.Rows[i]["Upload_TypeID"].ToString() == "Photo_1")
                        if (UploadType.Equals(Settings.Default.Photo_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                uplPhotoData.ForeColor = Color.White;
                                lnkPhoto.Text = careerInformationInfo.Filename;
                                imgPhoto.ImageUrl = Photo_DataPath + lnkPhoto.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Photo_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                uplPhotoData2.ForeColor = Color.White;
                                lnkPhoto2.Text = careerInformationInfo.Filename;
                                imgPhoto2.ImageUrl = Photo_DataPath + lnkPhoto2.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Photo_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                uplPhotoData3.ForeColor = Color.White;
                                lnkPhoto3.Text = careerInformationInfo.Filename;
                                imgPhoto3.ImageUrl = Photo_DataPath + lnkPhoto3.Text;
                            }

                        }
                        else if (UploadType.Equals(Settings.Default.IDCard_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();

                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCardData.Text = careerInformationInfo.Filename;
                                imgCardData.ImageUrl = IDCard_DataPath + lnkCardData.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.IDCard_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCardData2.Text = careerInformationInfo.Filename;
                                imgCardData2.ImageUrl = IDCard_DataPath + lnkCardData2.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.IDCard_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCardData3.Text = careerInformationInfo.Filename;
                                imgCardData3.ImageUrl = IDCard_DataPath + lnkCardData3.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.LabourCard_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkLabourCard.Text = careerInformationInfo.Filename;
                                imgLabourCard.ImageUrl = LabourCard_DataPath + lnkLabourCard.Text;
                            }
                        }


                        else if (UploadType.Equals(Settings.Default.LabourCard_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkLabourCard2.Text = careerInformationInfo.Filename;
                                imgLabourCard2.ImageUrl = LabourCard_DataPath + lnkLabourCard2.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.LabourCard_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkLabourCard3.Text = careerInformationInfo.Filename;
                                imgLabourCard3.ImageUrl = LabourCard_DataPath + lnkLabourCard3.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Japanese_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkJapaneseData.Text = careerInformationInfo.Filename;
                                imgJapaneseData.ImageUrl = Japanese_DataPath + lnkJapaneseData.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Japanese_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkJapaneseData2.Text = careerInformationInfo.Filename;
                                imgJapaneseData2.ImageUrl = Japanese_DataPath + lnkJapaneseData2.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Japanese_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkJapaneseData3.Text = careerInformationInfo.Filename;
                                imgJapaneseData3.ImageUrl = Japanese_DataPath + lnkJapaneseData3.Text;
                            }

                        }
                        else if (UploadType.Equals(Settings.Default.Japanese_Data_4))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkJapaneseData4.Text = careerInformationInfo.Filename;
                                imgJapaneseData4.ImageUrl = Japanese_DataPath + lnkJapaneseData4.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Japanese_Data_5))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkJapaneseData5.Text = careerInformationInfo.Filename;
                                imgJapaneseData5.ImageUrl = Japanese_DataPath + lnkJapaneseData5.Text;
                            }

                        }
                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData.Text = careerInformationInfo.Filename;
                                imgDatasheetData.ImageUrl = Datasheet_DataPath + lnkDatasheetData.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData2.Text = careerInformationInfo.Filename;
                                imgDatasheetData2.ImageUrl = Datasheet_DataPath + lnkDatasheetData2.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();

                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData3.Text = careerInformationInfo.Filename;
                                imgDatasheetData3.ImageUrl = Datasheet_DataPath + lnkDatasheetData3.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_4))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData4.Text = careerInformationInfo.Filename;
                                imgDatasheetData4.ImageUrl = Datasheet_DataPath + lnkDatasheetData4.Text;
                            }

                        }
                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_5))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData5.Text = careerInformationInfo.Filename;
                                imgDatasheetData5.ImageUrl = Datasheet_DataPath + lnkDatasheetData5.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_6))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData6.Text = careerInformationInfo.Filename;
                                imgDatasheetData6.ImageUrl = Datasheet_DataPath + lnkDatasheetData6.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_7))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData7.Text = careerInformationInfo.Filename;
                                imgDatasheetData7.ImageUrl = Datasheet_DataPath + lnkDatasheetData7.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Datasheet_Data_8))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkDatasheetData8.Text = careerInformationInfo.Filename;
                                imgDatasheetData8.ImageUrl = Datasheet_DataPath + lnkDatasheetData8.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Graduation_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();

                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkGraduationData.Text = careerInformationInfo.Filename;
                                imgGraduationData.ImageUrl = Graduation_DataPath + lnkGraduationData.Text;
                            }

                        }
                        else if (UploadType.Equals(Settings.Default.Graduation_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();

                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkGraduationData2.Text = careerInformationInfo.Filename;
                                imgGraduationData2.ImageUrl = Graduation_DataPath + lnkGraduationData2.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Graduation_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkGraduationData3.Text = careerInformationInfo.Filename;
                                imgGraduationData3.ImageUrl = Graduation_DataPath + lnkGraduationData3.Text;
                            }

                        }

                        else if (UploadType.Equals(Settings.Default.Graduation_Data_4))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkGraduationData4.Text = careerInformationInfo.Filename;
                                imgGraduationData4.ImageUrl = Graduation_DataPath + lnkGraduationData4.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Graduation_Data_5))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkGraduationData5.Text = careerInformationInfo.Filename;
                                imgGraduationData5.ImageUrl = Graduation_DataPath + lnkGraduationData5.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Qualification_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();

                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData.Text = careerInformationInfo.Filename;
                                imgQualificationData.ImageUrl = Qualification_DataPath + lnkQualificationData.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.Qualification_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData2.Text = careerInformationInfo.Filename;
                                imgQualificationData2.ImageUrl = Qualification_DataPath + lnkQualificationData2.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();

                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData3.Text = careerInformationInfo.Filename;
                                imgQualificationData3.ImageUrl = Qualification_DataPath + lnkQualificationData3.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_4))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData4.Text = careerInformationInfo.Filename;
                                imgQualificationData4.ImageUrl = Qualification_DataPath + lnkQualificationData4.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_5))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData5.Text = careerInformationInfo.Filename;
                                imgQualificationData5.ImageUrl = Qualification_DataPath + lnkQualificationData5.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_6))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData6.Text = careerInformationInfo.Filename;
                                imgQualificationData6.ImageUrl = Qualification_DataPath + lnkQualificationData6.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_7))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData7.Text = careerInformationInfo.Filename;
                                imgQualificationData7.ImageUrl = Qualification_DataPath + lnkQualificationData7.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_8))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData8.Text = careerInformationInfo.Filename;
                                imgQualificationData8.ImageUrl = Qualification_DataPath + lnkQualificationData8.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_9))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData9.Text = careerInformationInfo.Filename;
                                imgQualificationData9.ImageUrl = Qualification_DataPath + lnkQualificationData9.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.Qualification_Data_10))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkQualificationData10.Text = careerInformationInfo.Filename;
                                imgQualificationData10.ImageUrl = Qualification_DataPath + lnkQualificationData10.Text;
                            }
                        }


                        else if (UploadType.Equals(Settings.Default.CV_Data_1))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData.Text = careerInformationInfo.Filename;
                                imgCredentialData.ImageUrl = Credential_DataPath + lnkCredentialData.Text;
                            }
                        }


                        else if (UploadType.Equals(Settings.Default.CV_Data_2))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData2.Text = careerInformationInfo.Filename;
                                imgCredentialData2.ImageUrl = Credential_DataPath + lnkCredentialData2.Text;
                            }
                        }


                        else if (UploadType.Equals(Settings.Default.CV_Data_3))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData3.Text = careerInformationInfo.Filename;
                                imgCredentialData3.ImageUrl = Credential_DataPath + lnkCredentialData3.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.CV_Data_4))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData4.Text = careerInformationInfo.Filename;
                                imgCredentialData4.ImageUrl = Credential_DataPath + lnkCredentialData4.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.CV_Data_5))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData5.Text = careerInformationInfo.Filename;
                                imgCredentialData5.ImageUrl = Credential_DataPath + lnkCredentialData5.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.CV_Data_6))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData6.Text = careerInformationInfo.Filename;
                                imgCredentialData6.ImageUrl = Credential_DataPath + lnkCredentialData6.Text;
                            }
                        }

                        else if (UploadType.Equals(Settings.Default.CV_Data_7))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData7.Text = careerInformationInfo.Filename;
                                imgCredentialData7.ImageUrl = Credential_DataPath + lnkCredentialData7.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_8))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData8.Text = careerInformationInfo.Filename;
                                imgCredentialData8.ImageUrl = Credential_DataPath + lnkCredentialData8.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_9))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData9.Text = careerInformationInfo.Filename;
                                imgCredentialData9.ImageUrl = Credential_DataPath + lnkCredentialData9.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_10))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData10.Text = careerInformationInfo.Filename;
                                imgCredentialData10.ImageUrl = Credential_DataPath + lnkCredentialData10.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_11))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData11.Text = careerInformationInfo.Filename;
                                imgCredentialData11.ImageUrl = Credential_DataPath + lnkCredentialData11.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_12))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData12.Text = careerInformationInfo.Filename;
                                imgCredentialData12.ImageUrl = Credential_DataPath + lnkCredentialData12.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_13))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData13.Text = careerInformationInfo.Filename;
                                imgCredentialData13.ImageUrl = Credential_DataPath + lnkCredentialData13.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_14))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData14.Text = careerInformationInfo.Filename;
                                imgCredentialData14.ImageUrl = Credential_DataPath + lnkCredentialData14.Text;
                            }
                        }
                        else if (UploadType.Equals(Settings.Default.CV_Data_15))
                        {
                            careerInformationInfo.Filename = dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (!String.IsNullOrWhiteSpace(careerInformationInfo.Filename))
                            {
                                lnkCredentialData15.Text = careerInformationInfo.Filename;
                                imgCredentialData15.ImageUrl = Credential_DataPath + lnkCredentialData15.Text;
                            }
                        }

                    }

                }
                else
                {
                    Career_ResumeBL careerResume = new Career_ResumeBL();
                    Career_ResumeEntity careerResumeInfo = new Career_ResumeEntity();
                    careerInformationInfo.Career_ID = Career_ID;
                    careerResumeInfo = careerResume.SelectByID(Career_ID);
                    hfCareerCode.Value = careerResumeInfo.Career_Code;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private DataTable SetCareerInformation()
        {
            try
            {
                Career_Information_Upload_Entity careerInformationInfo = new Career_Information_Upload_Entity();
                DataTable dts = new DataTable();
                //     dts.Columns.Add("ID", System.Type.GetType("System.String"));
                dts.Columns.Add("Career_ID", System.Type.GetType("System.String"));
                dts.Columns.Add("Upload_FileName", System.Type.GetType("System.String"));
                dts.Columns.Add("Upload_TypeID", System.Type.GetType("System.String"));

                careerInformation = new Career_Information_UploadBL();
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


                if (!String.IsNullOrWhiteSpace(lnkPhoto.Text))
                {

                    careerInformationInfo.Filename = lnkPhoto.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Photo_1);

                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkPhoto2.Text))
                {
                    careerInformationInfo.Filename = lnkPhoto2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Photo_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkPhoto3.Text))
                {
                    careerInformationInfo.Filename = lnkPhoto3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Photo_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkDatasheetData.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);


                }

                if (!String.IsNullOrWhiteSpace(lnkDatasheetData2.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkDatasheetData3.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkDatasheetData4.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData4.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_4);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkDatasheetData5.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData5.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_5);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkDatasheetData6.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData6.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_6);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkDatasheetData7.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData7.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_7);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkDatasheetData8.Text))
                {
                    careerInformationInfo.Filename = lnkDatasheetData8.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Datasheet_Data_8);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }



                if (!String.IsNullOrWhiteSpace(lnkCardData.Text))
                {
                    careerInformationInfo.Filename = lnkCardData.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.IDCard_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkCardData2.Text))
                {
                    careerInformationInfo.Filename = lnkCardData2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.IDCard_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkCardData3.Text))
                {
                    careerInformationInfo.Filename = lnkCardData3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.IDCard_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }




                if (!String.IsNullOrWhiteSpace(lnkCredentialData.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData2.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkCredentialData3.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkCredentialData4.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData4.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_4);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData5.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData5.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_5);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData6.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData6.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_6);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData7.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData7.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_7);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData8.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData8.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_8);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkCredentialData9.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData9.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_9);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData10.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData10.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_10);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData11.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData11.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_11);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData12.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData12.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_12);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData13.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData13.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_13);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData14.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData14.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_14);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkCredentialData15.Text))
                {
                    careerInformationInfo.Filename = lnkCredentialData15.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.CV_Data_15);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }



                if (!String.IsNullOrWhiteSpace(lnkJapaneseData.Text))
                {
                    careerInformationInfo.Filename = lnkJapaneseData.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Japanese_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkJapaneseData2.Text))
                {
                    careerInformationInfo.Filename = lnkJapaneseData2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Japanese_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkJapaneseData3.Text))
                {
                    careerInformationInfo.Filename = lnkJapaneseData3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Japanese_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkJapaneseData4.Text))
                {
                    careerInformationInfo.Filename = lnkJapaneseData4.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Japanese_Data_4);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkJapaneseData5.Text))
                {
                    careerInformationInfo.Filename = lnkJapaneseData5.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Japanese_Data_5);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }



                if (!String.IsNullOrWhiteSpace(lnkGraduationData.Text))
                {
                    careerInformationInfo.Filename = lnkGraduationData.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Graduation_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkGraduationData2.Text))
                {
                    careerInformationInfo.Filename = lnkGraduationData2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Graduation_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkGraduationData3.Text))
                {
                    careerInformationInfo.Filename = lnkGraduationData3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Graduation_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkGraduationData4.Text))
                {
                    careerInformationInfo.Filename = lnkGraduationData4.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Graduation_Data_4);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkGraduationData5.Text))
                {
                    careerInformationInfo.Filename = lnkGraduationData5.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Graduation_Data_5);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }


                if (!String.IsNullOrWhiteSpace(lnkQualificationData.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData2.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData3.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData4.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData4.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_4);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData5.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData5.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_5);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData6.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData6.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_6);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData7.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData7.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_7);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData8.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData8.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_8);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData9.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData9.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_9);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkQualificationData10.Text))
                {
                    careerInformationInfo.Filename = lnkQualificationData10.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.Qualification_Data_10);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (!String.IsNullOrWhiteSpace(lnkLabourCard.Text))
                {
                    careerInformationInfo.Filename = lnkLabourCard.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.LabourCard_Data_1);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkLabourCard2.Text))
                {
                    careerInformationInfo.Filename = lnkLabourCard2.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.LabourCard_Data_2);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (!String.IsNullOrWhiteSpace(lnkLabourCard3.Text))
                {
                    careerInformationInfo.Filename = lnkLabourCard3.Text;
                    careerInformationInfo.UploadtypeID = Convert.ToInt16(Settings.Default.LabourCard_Data_3);
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }


                if (uplPhotoData.HasFile)
                {
                    string File = uplPhotoData.FileName;
                    //  careerInformationInfo.UploadID = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;


                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Photo_1);
                    uplPhotoData.SaveAs(Server.MapPath(Photo_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkPhoto.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplPhotoData2.HasFile)
                {
                    string File = uplPhotoData2.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Photo_2);
                    uplPhotoData2.SaveAs(Server.MapPath(Photo_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkPhoto2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplPhotoData3.HasFile)
                {
                    string File = uplPhotoData3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Photo_3);
                    uplPhotoData3.SaveAs(Server.MapPath(Photo_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkPhoto3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplDatasheetData.HasFile)
                {
                    string File = uplDatasheetData.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_1);

                    uplDatasheetData.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkDatasheetData.Text = hfCareerCode.Value + "_01" + "_" + File;

                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);

                }

                if (uplDatasheetData2.HasFile)
                {
                    string File = uplDatasheetData2.FileName;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_2);

                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    uplDatasheetData2.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkDatasheetData2.Text = hfCareerCode.Value + "_02" + "_" + File;

                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);

                }

                if (uplDatasheetData3.HasFile)
                {
                    string File = uplDatasheetData3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_3);

                    uplDatasheetData3.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkDatasheetData3.Text = hfCareerCode.Value + "_03" + "_" + File;

                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);

                }

                if (uplDatasheetData4.HasFile)
                {
                    string File = uplDatasheetData4.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_04" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_4);
                    uplDatasheetData4.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    lnkDatasheetData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }

                if (uplDatasheetData5.HasFile)
                {
                    string File = uplDatasheetData5.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_05" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_5);
                    uplDatasheetData5.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    lnkDatasheetData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }
                if (uplDatasheetData6.HasFile)
                {
                    string File = uplDatasheetData6.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_06" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_6);
                    uplDatasheetData6.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_06" + "_" + File);
                    lnkDatasheetData6.Text = hfCareerCode.Value + "_06" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }
                if (uplDatasheetData7.HasFile)
                {
                    string File = uplDatasheetData7.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_07" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_7);
                    uplDatasheetData7.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_07" + "_" + File);
                    lnkDatasheetData7.Text = hfCareerCode.Value + "_07" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }
                if (uplDatasheetData8.HasFile)
                {
                    string File = uplDatasheetData8.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_08" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Datasheet_Data_8);
                    uplDatasheetData8.SaveAs(Server.MapPath(Datasheet_DataPath) + hfCareerCode.Value + "_08" + "_" + File);
                    lnkDatasheetData8.Text = hfCareerCode.Value + "_08" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                    // lblDatasheetData.Text = hfCareerCode.Value + "_" + File;
                }



                if (uplCardData.HasFile)
                {
                    string File = uplCardData.FileName;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.IDCard_Data_1);
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    uplCardData.SaveAs(Server.MapPath(IDCard_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    //lblCardData.Text = hfCareerCode.Value + "_" + File;
                    lnkCardData.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCardData2.HasFile)
                {
                    string File = uplCardData2.FileName;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.IDCard_Data_2);
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    uplCardData2.SaveAs(Server.MapPath(IDCard_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    //lblCardData.Text = hfCareerCode.Value + "_" + File;
                    lnkCardData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCardData3.HasFile)
                {
                    string File = uplCardData3.FileName;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.IDCard_Data_3);
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    uplCardData3.SaveAs(Server.MapPath(IDCard_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkCardData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }



                if (uplCredentialData.HasFile)
                {
                    string File = uplCredentialData.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_1);
                    uplCredentialData.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkCredentialData.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData2.HasFile)
                {
                    string File = uplCredentialData2.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_2);
                    uplCredentialData2.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkCredentialData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData3.HasFile)
                {
                    string File = uplCredentialData3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_3);
                    uplCredentialData3.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkCredentialData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCredentialData4.HasFile)
                {
                    string File = uplCredentialData4.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_04" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_4);
                    uplCredentialData4.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    lnkCredentialData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCredentialData5.HasFile)
                {
                    string File = uplCredentialData5.FileName;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_5);
                    careerInformationInfo.Filename = hfCareerCode.Value + "_05" + "_" + File;
                    uplCredentialData5.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    lnkCredentialData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCredentialData6.HasFile)
                {
                    string File = uplCredentialData6.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_06" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_6);
                    uplCredentialData6.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_06" + "_" + File);
                    lnkCredentialData6.Text = hfCareerCode.Value + "_06" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCredentialData7.HasFile)
                {
                    string File = uplCredentialData7.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_07" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_7);
                    uplCredentialData7.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_07" + "_" + File);
                    lnkCredentialData7.Text = hfCareerCode.Value + "_07" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplCredentialData8.HasFile)
                {
                    string File = uplCredentialData8.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_08" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_8);
                    uplCredentialData8.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_08" + "_" + File);
                    lnkCredentialData8.Text = hfCareerCode.Value + "_0." + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData9.HasFile)
                {
                    string File = uplCredentialData9.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_09" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_9);
                    uplCredentialData9.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_09" + "_" + File);
                    lnkCredentialData9.Text = hfCareerCode.Value + "_09" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData10.HasFile)
                {
                    string File = uplCredentialData10.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_10" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_10);
                    uplCredentialData10.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_10" + "_" + File);
                    lnkCredentialData10.Text = hfCareerCode.Value + "_10" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData11.HasFile)
                {
                    string File = uplCredentialData11.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_11" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_11);
                    uplCredentialData11.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_11" + "_" + File);
                    lnkCredentialData11.Text = hfCareerCode.Value + "_11" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData12.HasFile)
                {
                    string File = uplCredentialData12.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_12" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_12);
                    uplCredentialData12.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_12" + "_" + File);
                    lnkCredentialData12.Text = hfCareerCode.Value + "_12" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData13.HasFile)
                {
                    string File = uplCredentialData13.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_13" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_13);
                    uplCredentialData13.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_13" + "_" + File);
                    lnkCredentialData13.Text = hfCareerCode.Value + "_13" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData14.HasFile)
                {
                    string File = uplCredentialData14.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_14" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_14);
                    uplCredentialData14.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_14" + "_" + File);
                    lnkCredentialData14.Text = hfCareerCode.Value + "_14" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplCredentialData15.HasFile)
                {
                    string File = uplCredentialData15.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_15" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.CV_Data_15);
                    uplCredentialData15.SaveAs(Server.MapPath(Credential_DataPath) + hfCareerCode.Value + "_15" + "_" + File);
                    lnkCredentialData15.Text = hfCareerCode.Value + "_15" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }





                if (uplJapaeseData.HasFile)
                {
                    string File = uplJapaeseData.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Japanese_Data_1);
                    uplJapaeseData.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkJapaneseData.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplJapaeseData2.HasFile)
                {
                    string File = uplJapaeseData2.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Japanese_Data_2);
                    uplJapaeseData2.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkJapaneseData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplJapaeseData3.HasFile)
                {
                    string File = uplJapaeseData3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Japanese_Data_3);
                    uplJapaeseData3.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkJapaneseData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplJapaeseData4.HasFile)
                {
                    string File = uplJapaeseData4.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_04" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Japanese_Data_4);
                    uplJapaeseData4.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    lnkJapaneseData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplJapaeseData5.HasFile)
                {
                    string File = uplJapaeseData5.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_05" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Japanese_Data_5);
                    uplJapaeseData5.SaveAs(Server.MapPath(Japanese_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    lnkJapaneseData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplGraduationData.HasFile)
                {
                    string File = uplGraduationData.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Graduation_Data_1);
                    uplGraduationData.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplGraduationData2.HasFile)
                {
                    string File = uplGraduationData2.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Graduation_Data_2);
                    uplGraduationData2.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplGraduationData3.HasFile)
                {
                    string File = uplGraduationData3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Graduation_Data_3);
                    uplGraduationData3.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplGraduationData4.HasFile)
                {
                    string File = uplGraduationData4.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_04" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Graduation_Data_4);
                    uplGraduationData4.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplGraduationData5.HasFile)
                {
                    string File = uplGraduationData5.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_05" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Graduation_Data_5);
                    uplGraduationData5.SaveAs(Server.MapPath(Graduation_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    //lblGraduationData.Text = hfCareerCode.Value + "_" + File;
                    lnkGraduationData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }


                if (uplQualificationData.HasFile)
                {
                    string File = uplQualificationData.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_1);
                    uplQualificationData.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkQualificationData.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplQualificationData2.HasFile)
                {
                    string File = uplQualificationData2.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_2);
                    uplQualificationData2.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkQualificationData2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplQualificationData3.HasFile)
                {
                    string File = uplQualificationData3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_3);
                    uplQualificationData3.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkQualificationData3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplQualificationData4.HasFile)
                {
                    string File = uplQualificationData4.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_04" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_4);
                    uplQualificationData4.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_04" + "_" + File);
                    lnkQualificationData4.Text = hfCareerCode.Value + "_04" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplQualificationData5.HasFile)
                {
                    string File = uplQualificationData5.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_05" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_5);
                    uplQualificationData5.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_05" + "_" + File);
                    lnkQualificationData5.Text = hfCareerCode.Value + "_05" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplQualificationData6.HasFile)
                {
                    string File = uplQualificationData6.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_06" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_6);
                    uplQualificationData6.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_06" + "_" + File);
                    lnkQualificationData6.Text = hfCareerCode.Value + "_06" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);

                }
                if (uplQualificationData7.HasFile)
                {
                    string File = uplQualificationData7.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_07" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_7);
                    uplQualificationData7.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_07" + "_" + File);
                    lnkQualificationData7.Text = hfCareerCode.Value + "_07" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplQualificationData8.HasFile)
                {
                    string File = uplQualificationData8.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_08" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_8);
                    uplQualificationData8.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_08" + "_" + File);
                    lnkQualificationData8.Text = hfCareerCode.Value + "_08" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplQualificationData9.HasFile)
                {
                    string File = uplQualificationData9.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_09" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_9);
                    uplQualificationData9.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_09" + "_" + File);
                    lnkQualificationData9.Text = hfCareerCode.Value + "_09" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplQualificationData10.HasFile)
                {
                    string File = uplQualificationData10.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_10" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.Qualification_Data_10);
                    uplQualificationData10.SaveAs(Server.MapPath(Qualification_DataPath) + hfCareerCode.Value + "_10" + "_" + File);
                    lnkQualificationData10.Text = hfCareerCode.Value + "_10" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                if (uplLabourCard.HasFile)
                {
                    string File = uplLabourCard.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_01" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.LabourCard_Data_1);
                    uplLabourCard.SaveAs(Server.MapPath(LabourCard_DataPath) + hfCareerCode.Value + "_01" + "_" + File);
                    lnkLabourCard.Text = hfCareerCode.Value + "_01" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplLabourCard2.HasFile)
                {
                    string File = uplLabourCard2.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_02" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.LabourCard_Data_2);
                    uplLabourCard2.SaveAs(Server.MapPath(LabourCard_DataPath) + hfCareerCode.Value + "_02" + "_" + File);
                    lnkLabourCard2.Text = hfCareerCode.Value + "_02" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }
                if (uplLabourCard3.HasFile)
                {
                    string File = uplLabourCard3.FileName;
                    careerInformationInfo.Filename = hfCareerCode.Value + "_03" + "_" + File;
                    careerInformationInfo.UploadID = Convert.ToInt16(Settings.Default.LabourCard_Data_3);
                    uplLabourCard3.SaveAs(Server.MapPath(LabourCard_DataPath) + hfCareerCode.Value + "_03" + "_" + File);
                    lnkLabourCard3.Text = hfCareerCode.Value + "_03" + "_" + File;
                    dts.Rows.Add(careerInformationInfo.Career_ID, careerInformationInfo.Filename, careerInformationInfo.UploadtypeID);
                }

                return dts;
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
                careerInformation = new Career_Information_UploadBL();
                careerInformationInfo = new Career_Information_Upload_Entity();

                DataTable dt = SetCareerInformation();
                if (careerInformationInfo != null)
                {
                    string result = careerInformation.Insert(dt, (int)EnumBase.Save.Insert);
                    if (result == "Save success!")
                    {
                        object referrer = ViewState["UrlReferrer"];
                        string url = (string)referrer;
                        string script = "window.onload = function(){ alert('";
                        script += result;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
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
                careerInformation = new Career_Information_UploadBL();
                careerInformationInfo = new Career_Information_Upload_Entity();

                //SetCareerInformation(careerInformationInfo);
                DataTable dt = SetCareerInformation();
                if (careerInformationInfo != null)
                {
                    int ID = int.Parse(Request.QueryString["Career_ID"].ToString());
                    careerInformation.Delete(ID);
                    string result = careerInformation.Insert(dt, (int)EnumBase.Save.Insert);
                    if (result == "Save success!")
                    {
                        object referrer = ViewState["UrlReferrer"];
                        string url = (string)referrer;
                        string script = "window.onload = function(){ alert('";
                        script += "Update success!";
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                    else
                    {
                        GlobalUI.MessageBox(result);
                    }
                    //GlobalUI.MessageBox(result);
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

    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                careerInformation = new Career_Information_UploadBL();
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

        #region Photo Download
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
        #endregion

        #region Datasheet Download
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
        protected void lnkDatasheetData6_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData6.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkDatasheetData7_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData7.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkDatasheetData8_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Datasheet_DataPath + lnkDatasheetData8.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region IDCard Download
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
        protected void lnkCardData2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(IDCard_DataPath + lnkCardData2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCardData3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(IDCard_DataPath + lnkCardData3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CV Download
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
        protected void lnkCredentialData8_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData8.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData9_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData9.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData10_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData10.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData11_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData11.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData12_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData12.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData13_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData13.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData14_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData14.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkCredentialData15_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Credential_DataPath + lnkCredentialData15.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Japanese Download
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
        protected void lnkJapaneseData4_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Japanese_DataPath + lnkJapaneseData4.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkJapaneseData5_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Japanese_DataPath + lnkJapaneseData5.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GraduationData Download
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
        protected void lnkGraduationData4_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Graduation_DataPath + lnkGraduationData4.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkGraduationData5_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Graduation_DataPath + lnkGraduationData5.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Qualification Download
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
        protected void lnkQualificationData4_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData4.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkQualificationData5_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData5.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkQualificationData6_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData6.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkQualificationData7_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData7.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkQualificationData8_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData8.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkQualificationData9_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData9.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkQualificationData10_Click(object sender, EventArgs e)
        {
            try
            {
                Download(Qualification_DataPath + lnkQualificationData10.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Labour Card Download
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
        protected void lnkLabourCard2_Click(object sender, EventArgs e)
        {
            try
            {
                Download(LabourCard_DataPath + lnkLabourCard2.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void lnkLabourCard3_Click(object sender, EventArgs e)
        {
            try
            {
                Download(LabourCard_DataPath + lnkLabourCard3.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //Download Event When link buttons click
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

        //Delete Event for all delete buttons
        protected void DeleteEvent(String DefaultUploadType, String Path, LinkButton lnk, Button btn, ImageButton imgbtn, FileUpload upl)
        {
            try
            {
                careerInformation = new Career_Information_UploadBL();
                dtCareerInformation = careerInformation.SelectByCareerID(Career_ID, 1);
                if (dtCareerInformation.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCareerInformation.Rows.Count; i++)
                    {
                        UploadType = dtCareerInformation.Rows[i]["Upload_TypeID"].ToString();
                        if (UploadType.Equals(DefaultUploadType))
                        {
                            String FilePath = Server.MapPath(Path) + dtCareerInformation.Rows[i]["Upload_FileName"].ToString();
                            if (File.Exists(FilePath))
                            {
                                System.IO.File.Delete(FilePath);
                                lnk.Text = string.Empty;
                                btn.Visible = false;
                                imgbtn.Visible = false;
                                upl.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDatasheetDataDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_1, Datasheet_DataPath, lnkDatasheetData, btnDatasheetDataDelete, imgDatasheetData, uplDatasheetData);
        }

        protected void btnDatasheetData2Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_2, Datasheet_DataPath, lnkDatasheetData2, btnDatasheetData2Delete, imgDatasheetData2, uplDatasheetData2);
        }

        protected void btnDatasheetData3Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_3, Datasheet_DataPath, lnkDatasheetData3, btnDatasheetData3Delete, imgDatasheetData3, uplDatasheetData3);
        }

        protected void btnDatasheetData4Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_4, Datasheet_DataPath, lnkDatasheetData4, btnDatasheetData4Delete, imgDatasheetData4, uplDatasheetData4);
        }

        protected void btnDatasheetData5Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_5, Datasheet_DataPath, lnkDatasheetData5, btnDatasheetData5Delete, imgDatasheetData5, uplDatasheetData5);
        }
        protected void btnDatasheetData6Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_6, Datasheet_DataPath, lnkDatasheetData6, btnDatasheetData6Delete, imgDatasheetData6, uplDatasheetData6);
        }
        protected void btnDatasheetData7Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_7, Datasheet_DataPath, lnkDatasheetData7, btnDatasheetData7Delete, imgDatasheetData7, uplDatasheetData7);
        }
        protected void btnDatasheetData8Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Datasheet_Data_8, Datasheet_DataPath, lnkDatasheetData8, btnDatasheetData8Delete, imgDatasheetData8, uplDatasheetData8);
        }

        protected void btnPhoto_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Photo_1, Photo_DataPath, lnkPhoto, btnPhoto, imgPhoto, uplPhotoData);
        }

        protected void btnPhoto2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Photo_2, Photo_DataPath, lnkPhoto2, btnPhoto2, imgPhoto2, uplPhotoData2);
        }

        protected void btnPhoto3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Photo_3, Photo_DataPath, lnkPhoto3, btnPhoto3, imgPhoto3, uplPhotoData3);
        }

        protected void btnCardData_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.IDCard_Data_1, IDCard_DataPath, lnkCardData, btnCardData, imgCardData, uplCardData);
        }
        protected void btnCardData2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.IDCard_Data_2, IDCard_DataPath, lnkCardData2, btnCardData2, imgCardData2, uplCardData2);
        }
        protected void btnCardData3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.IDCard_Data_3, IDCard_DataPath, lnkCardData3, btnCardData3, imgCardData3, uplCardData3);
        }

        protected void btnCredentialData_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_1, Credential_DataPath, lnkCredentialData, btnCredentialData, imgCredentialData, uplCredentialData);
        }

        protected void btnCredentialData2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_2, Credential_DataPath, lnkCredentialData2, btnCredentialData2, imgCredentialData2, uplCredentialData2);
        }

        protected void btnCredentialData3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_3, Credential_DataPath, lnkCredentialData3, btnCredentialData3, imgCredentialData3, uplCredentialData3);
        }

        protected void btnCredentialData4_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_4, Credential_DataPath, lnkCredentialData4, btnCredentialData4, imgCredentialData4, uplCredentialData4);
        }
        protected void btnCredentialData5_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_5, Credential_DataPath, lnkCredentialData5, btnCredentialData5, imgCredentialData5, uplCredentialData5);
        }
        protected void btnCredentialData6_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_6, Credential_DataPath, lnkCredentialData6, btnCredentialData6, imgCredentialData6, uplCredentialData6);
        }

        protected void btnCredentialData7_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_7, Credential_DataPath, lnkCredentialData7, btnCredentialData7, imgCredentialData7, uplCredentialData7);
        }
        protected void btnCredentialData8_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_8, Credential_DataPath, lnkCredentialData8, btnCredentialData8, imgCredentialData8, uplCredentialData8);
        }

        protected void btnCredentialData9_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_9, Credential_DataPath, lnkCredentialData9, btnCredentialData9, imgCredentialData9, uplCredentialData9);
        }

        protected void btnCredentialData10_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_10, Credential_DataPath, lnkCredentialData10, btnCredentialData10, imgCredentialData10, uplCredentialData10);
        }

        protected void btnCredentialData11_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_11, Credential_DataPath, lnkCredentialData11, btnCredentialData11, imgCredentialData11, uplCredentialData11);
        }

        protected void btnCredentialData12_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_12, Credential_DataPath, lnkCredentialData12, btnCredentialData12, imgCredentialData12, uplCredentialData12);
        }

        protected void btnCredentialData13_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_13, Credential_DataPath, lnkCredentialData13, btnCredentialData13, imgCredentialData13, uplCredentialData13);
        }

        protected void btnCredentialData14_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_14, Credential_DataPath, lnkCredentialData14, btnCredentialData14, imgCredentialData14, uplCredentialData14);
        }

        protected void btnCredentialData15_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.CV_Data_15, Credential_DataPath, lnkCredentialData15, btnCredentialData15, imgCredentialData15, uplCredentialData15);
        }
        protected void btnJapaneseData_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Japanese_Data_1, Japanese_DataPath, lnkJapaneseData, btnJapaneseData, imgJapaneseData, uplJapaeseData);
        }

        protected void btnJapaneseData2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Japanese_Data_2, Japanese_DataPath, lnkJapaneseData2, btnJapaneseData2, imgJapaneseData2, uplJapaeseData2);
        }

        protected void btnJapaneseData3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Japanese_Data_3, Japanese_DataPath, lnkJapaneseData3, btnJapaneseData3, imgJapaneseData3, uplJapaeseData3);
        }
        protected void btnJapaneseData4_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Japanese_Data_4, Japanese_DataPath, lnkJapaneseData4, btnJapaneseData4, imgJapaneseData4, uplJapaeseData4);
        }
        protected void btnJapaneseData5_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Japanese_Data_5, Japanese_DataPath, lnkJapaneseData5, btnJapaneseData5, imgJapaneseData5, uplJapaeseData5);
        }

        protected void btnGraduationData_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Graduation_Data_1, Graduation_DataPath, lnkGraduationData, btnGraduationData, imgGraduationData, uplGraduationData);
        }

        protected void btnGraduationData2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Graduation_Data_2, Graduation_DataPath, lnkGraduationData2, btnGraduationData2, imgGraduationData2, uplGraduationData2);
        }

        protected void btnGraduationData3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Graduation_Data_3, Graduation_DataPath, lnkGraduationData3, btnGraduationData3, imgGraduationData3, uplGraduationData3);
        }

        protected void btnGraduationData4_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Graduation_Data_4, Graduation_DataPath, lnkGraduationData4, btnGraduationData4, imgGraduationData4, uplGraduationData4);
        }
        protected void btnGraduationData5_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Graduation_Data_5, Graduation_DataPath, lnkGraduationData5, btnGraduationData5, imgGraduationData5, uplGraduationData5);
        }

        protected void btnQualificationDataDelete_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_1, Qualification_DataPath, lnkQualificationData, btnQualificationDataDelete, imgQualificationData, uplQualificationData);
        }

        protected void btnQualificationData2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_2, Qualification_DataPath, lnkQualificationData2, btnQualificationData2, imgQualificationData2, uplQualificationData2);
        }

        protected void btnQualificationData3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_3, Qualification_DataPath, lnkQualificationData3, btnQualificationData3, imgQualificationData3, uplQualificationData3);
        }
        protected void btnQualificationData4_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_4, Qualification_DataPath, lnkQualificationData4, btnQualificationData4, imgQualificationData4, uplQualificationData4);
        }
        protected void btnQualificationData5_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_5, Qualification_DataPath, lnkQualificationData5, btnQualificationData5, imgQualificationData5, uplQualificationData5);
        }
        protected void btnQualificationData6_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_6, Qualification_DataPath, lnkQualificationData6, btnQualificationData6, imgQualificationData6, uplQualificationData6);
        }
        protected void btnQualificationData7_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_7, Qualification_DataPath, lnkQualificationData7, btnQualificationData7, imgQualificationData7, uplQualificationData7);
        }

        protected void btnQualificationData8_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_8, Qualification_DataPath, lnkQualificationData8, btnQualificationData8, imgQualificationData8, uplQualificationData8);
        }
        protected void btnQualificationData9_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_9, Qualification_DataPath, lnkQualificationData9, btnQualificationData9, imgQualificationData9, uplQualificationData9);
        }
        protected void btnQualificationData10_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.Qualification_Data_10, Qualification_DataPath, lnkQualificationData10, btnQualificationData10, imgQualificationData10, uplQualificationData10);
        }

        protected void btnLabourCard_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.LabourCard_Data_1, LabourCard_DataPath, lnkLabourCard, btnLabourCard, imgLabourCard, uplLabourCard);
        }

        protected void btnLabourCard2_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.LabourCard_Data_2, LabourCard_DataPath, lnkLabourCard2, btnLabourCard2, imgLabourCard2, uplLabourCard2);
        }
        protected void btnLabourCard3_Click(object sender, EventArgs e)
        {
            DeleteEvent(Settings.Default.LabourCard_Data_3, LabourCard_DataPath, lnkLabourCard3, btnLabourCard3, imgLabourCard3, uplLabourCard3);
        }


    }
}