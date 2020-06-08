using JSAT_BL;
using JSAT_BL.Employee;
using JSAT_Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1.Employee
{
    public partial class Career_Resume_Detail : System.Web.UI.Page
    {
        Career_ResumeBL careerResume;
        Career_ResumeEntity careerResumeInfo;
        CareerEmploymentBL careerEmployment;
        Career_QualificationBL careerQualification;
        Career_AbilityBL careerAbility;
        Career_PCSkillsBL careerPcSkill;
        Career_InterviewQuestion3BL careerInterviewQ3;
        Career_InterView3Entity careerInterviewCommentInfo;
        Career_InterviewQuestion3BL careerInterviewComment;
        Career_InterviewBL careerInterview;
        Career_InterviewEntity careerInterviewInfo;
        Career_InformationBL careerInformation;
        Career_InformationEntity careerInformationInfo;
        Career_Job_InterviewBL careerJobInterview;
        Career_WorkingPlaceBL careerworkingplace;

        string Zip_Data = ConfigurationManager.AppSettings["Zip_Data"].ToString();
        string All_DataPath = ConfigurationManager.AppSettings["All_Data"].ToString();
        string Datasheet_DataPath = ConfigurationManager.AppSettings["Datasheet_DataPath"].ToString();
        string Photo_DataPath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();
        string IDCard_DataPath = ConfigurationManager.AppSettings["IDCard_DataPath"].ToString();
        string Credential_DataPath = ConfigurationManager.AppSettings["Credential_DataPath"].ToString();
        string Japanese_DataPath = ConfigurationManager.AppSettings["Japanese_DataPath"].ToString();
        string Graduation_DataPath = ConfigurationManager.AppSettings["Graduation_DataPath"].ToString();
        string Qualification_DataPath = ConfigurationManager.AppSettings["Qualification_DataPath"].ToString();
        string LabourCard_DataPath = ConfigurationManager.AppSettings["LabourCard_DataPath"].ToString();
        public int Career_ID
        {
            get
            {
                if (Request.QueryString["Career_ID"] != null)
                    return int.Parse(Request.QueryString["Career_ID"].ToString());
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                careerResume = new Career_ResumeBL();
                careerResumeInfo = new Career_ResumeEntity();
                careerEmployment = new CareerEmploymentBL();
                careerQualification = new Career_QualificationBL();
                careerAbility = new Career_AbilityBL();
                careerInterviewQ3 = new Career_InterviewQuestion3BL();
                careerInterviewCommentInfo = new Career_InterView3Entity();
                careerInterviewComment = new Career_InterviewQuestion3BL();
                careerInterview = new Career_InterviewBL();
                careerInterviewInfo = new Career_InterviewEntity();
                careerInformation = new Career_InformationBL();
                careerInformationInfo = new Career_InformationEntity();
                careerJobInterview = new Career_Job_InterviewBL();
                careerPcSkill = new Career_PCSkillsBL();
                careerworkingplace = new Career_WorkingPlaceBL();
                if (Request.QueryString["Career_ID"] != null)
                {
                    int careerID = int.Parse(Request.QueryString["Career_ID"]);
                    careerResumeInfo = careerResume.SelectByID(careerID);
                    DataSet ds = new DataSet();
                    ds = careerQualification.Select_Qualification_Title_Item_ByID(careerID);
                    DataSet dsAbl = new DataSet();
                    dsAbl = careerAbility.Select_Ability_Title_Item_ByID(careerID);
                    DataTable dtPcSkills = new DataTable();
                    dtPcSkills = careerPcSkill.SelectByID(careerID);
                    DataTable dtworkingplace = new DataTable();
                    dtworkingplace = careerworkingplace.SelectByID(careerID);
                    FillCareerResume(careerResumeInfo, ds, dsAbl, dtPcSkills, dtworkingplace);
                    DataTable dtQ3 = new DataTable();
                    dtQ3 = careerInterviewQ3.SelectByID(careerID);
                    careerInterviewCommentInfo = careerInterviewComment.CommentSelectByID(careerID);
                    FillCareerInterviewQuestion3(dtQ3, careerInterviewCommentInfo);
                    careerInterviewInfo = careerInterview.SelectByCarrerID(careerID);
                    careerInformationInfo = careerInformation.SelectByID(careerID, 1);
                    FillCareerInformation(careerInformationInfo);
                    DataTable dtsalary = new DataTable();
                    dtsalary = careerResume.SelectedbySalaryIDDetail(careerID);
                    FillSalary(dtsalary);
                    Working_History_BL workinghistorybl = new Working_History_BL();
                    DataTable dtoldjob = careerResume.SelectedByWorkingHistoryForCareer_Resume(careerID);
                    DataTable dtjobdescripition = new DataTable();
                    dtoldjob.Columns.Add("Job_Description", typeof(string));
                    for (int j = 0; j < dtoldjob.Rows.Count; j++)
                    {
                        string strjobd = string.Empty;
                        strjobd = dtoldjob.Rows[j]["Job_Description_ID"].ToString();
                        dtjobdescripition = workinghistorybl.SelectbyJobDescription(Career_ID, strjobd);
                        string concatjobd = string.Empty;
                        for (int i = 0; i < dtjobdescripition.Rows.Count; i++)
                        {
                            concatjobd += dtjobdescripition.Rows[i]["Description"].ToString();
                            if (i != dtjobdescripition.Rows.Count - 1)
                            {
                                concatjobd += ",";
                            }
                        }
                        dtoldjob.Rows[j]["Job_Description"] = concatjobd.ToString();
                    }
                    FillOldjobhistory(dtoldjob, Career_ID);
                }
            }
        }
        protected void DLQualification_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList= e.Item.FindControl("innerDataList") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Qualification_Relation");                
                innerDataList.DataBind();
            }
        }

        protected void DLAbility_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList1") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Ability_Relation");                
                innerDataList.DataBind();
            }
        }
        protected void FillCareerResume(Career_ResumeEntity cr, DataSet dsQualification, DataSet dsAbility, DataTable dtPcSkills, DataTable dtWorkingPlace)
        {
            try
            {
                lblCreatedDate.Text = cr.CreatedDate.ToString("dd/MMM/yyyy");
                lblUpdatedDate.Text = cr.UpdatedDate.ToString("dd/MMM/yyyy");
                lblCareerCode.Text = cr.Career_Code;
                lbldomestic.Text = cr.Status;
                if (cr.GenderID == 1)
                {
                    lblGender.Text = "男(Male)";
                }
                else if (cr.GenderID == 2)
                {
                    lblGender.Text = "女(Female)";
                }
                else
                {
                    lblGender.Text = string.Empty;
                }
                lblName.Text = cr.Name;
                if (!String.IsNullOrWhiteSpace(cr.DOB.ToString()))
                {
                    string date = cr.DOB.ToString();
                    lblBirth.Text = GlobalUI.Format_Date(date);
                }
                //Calculating Age using DOB
                if (!String.IsNullOrWhiteSpace(cr.DOB.ToString()))
                {
                    DateTime? DOB = cr.DOB;
                    DateTime today = DateTime.Today;
                    int age = today.Year - DOB.Value.Year;
                    if (DOB > today.AddYears(-age)) age--;
                    lblAge.Text = age.ToString();
                }
                else
                {
                    lblAge.Text = cr.Age.ToString();
                }
                if (!String.IsNullOrWhiteSpace(cr.Graduation_Date))
                {
                    lblgdate.Text = cr.Graduation_Date;

                }
                lblReligion.Text = cr.ReligionName;
                lblAddress.Text = cr.ResidentialAreaName;
                lblPh1.Text = cr.Phone_No1;
                lblPh2.Text = cr.Phone_No2;
                lblEmail.Text = cr.Email;
                lblEmgNo.Text = cr.Emergency_ContactNo;
                lblEmgName.Text = cr.Emergency_ContactName;
                lblCareerStatus.Text = cr.Career_Status;
                lblWorkArea.Text = cr.WorkingPlaceName;
                lblDivision1.Text = cr.DepartmentName1;
                lblPosition1.Text = cr.PositionName1;
                lblPositionLevel1.Text = cr.PositionLevelName1;
                lblDivision2.Text = cr.DepartmentName2;
                lblPosition2.Text = cr.PositionName2;
                lblPositionLevel2.Text = cr.PositionLevelName2;
                lblDivision3.Text = cr.DepartmentName3;
                lblPosition3.Text = cr.PositionName3;
                lblPositionLevel3.Text = cr.PositionLevelName3;
                lblCondition.Text = cr.SituationName;
                bindTotalMark.Text = cr.TotalMark1.ToString();
                bindotherqualification.Text = cr.Other_Qualification;
                if (cr.Education_ID != 0)
                {
                    EducationBL e = new EducationBL();
                    DataTable dt = new DataTable();
                    dt = e.SelectByID(cr.Education_ID);
                    lblEducation.Text = dt.Rows[0]["Description"].ToString();
                }
                lbldegree.Text = cr.DegreeName;
                lbldegree2.Text = cr.DegreeName2;
                lblInstitutionName.Text = cr.InstitutionName;
                lblInstitutionName2.Text = cr.InstitutionName2;
                lblInstitutionArea.Text = cr.InstituationAreaName;
                lblInstitutionArea2.Text = cr.InstituationAreaName2;
                lblMajor.Text = cr.MajorName;
                lblMajor2.Text = cr.MajorName2;
                lblMajorOthers.Text = cr.Other_Major;
                lblyear.Text = cr.YearName;
                lblyear2.Text = cr.YearName2;
                string str = string.Empty;
                
                
                dsQualification.Relations.Add(new DataRelation("Qualification_Relation", dsQualification.Tables[0].Columns["ID"], dsQualification.Tables[1].Columns["QualificationTitle_id"], false));
                DLQualification.DataSource = dsQualification.Tables[0];
                DLQualification.DataBind();

                
                dsAbility.Relations.Add(new DataRelation("Ability_Relation", dsAbility.Tables[0].Columns["ID"], dsAbility.Tables[1].Columns["AbilityTitle_id"], false));
                DLAbility.DataSource = dsAbility.Tables[0];
                DLAbility.DataBind();


                str = string.Empty;
                for (int i = 0; i < dtPcSkills.Rows.Count; i++)
                {
                    str += dtPcSkills.Rows[i]["PCSkills"].ToString();
                    if (i != dtPcSkills.Rows.Count - 1)
                    {
                        str += " , ";
                    }
                }
                cr.Other_PCskills = str;
                str = String.Empty;
                for (int i = 0; i < dtWorkingPlace.Rows.Count; i++)
                {
                    str += dtWorkingPlace.Rows[i]["WorkingPlace"].ToString();
                    if (i != dtWorkingPlace.Rows.Count - 1)
                    {
                        str += " , ";
                    }
                }
                lblWorkArea.Text = str;
                lblPCSkillOthers.Text = cr.Other_PCskills;
                lblEnglishRW.Text = cr.LanguageEnglishRWLevel;
                lblEnglishSpeak.Text = cr.LanguageEnglishSKLevel;
                lblJapaneseRW.Text = cr.LanguageJapaneseRWLevel;
                lblJapaneseSpeak.Text = cr.LanguageJapaneseSKLevel;
                lblMyanmarRW.Text = cr.LanguageMyanmarRWLevel;
                lblMyanmarSpeak.Text = cr.LanguageMyanmarSKLevel;
                lblimpression.Text = cr.Impression;
                txtimpressionjp.Text = cr.Impressionjp;
                txtUpdatedInfo.Text = cr.UpdatedInfo;
                if (cr.Notice_Type == "Immediate")
                {
                    lblnoticttype.Text = cr.Notice_Type;
                }
                else if (cr.Notice_Day != " 0" && !String.IsNullOrWhiteSpace(cr.Notice_Type)) //if Notice_Day is o will not show
                {
                    lblnoticttype.Text = cr.Notice_Day + cr.Notice_Type;
                }
                else { }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void FillCareerInterviewQuestion3(DataTable dt, Career_InterView3Entity comment)
        {
            try
            {
                string str = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += dt.Rows[i]["InterviewDescription"].ToString() + "<br/>";
                }
                lblInterviewQuestion3.Text = str;
                lblJapaneseInterviewer.Text = comment.Japense_Interviewer_Comment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetUploadData(String FileName, LinkButton lnk, ImageButton img, String path)
        {
            lnk.Text = FileName;
            if (String.IsNullOrWhiteSpace(FileName))
                img.Visible = false;
            else
                img.ImageUrl = path + FileName;
        }

        protected void FillCareerInformation(Career_InformationEntity cinfo)
        {
            try
            {
                lnkDatasheetData.Text = careerInformationInfo.Datasheet_Data;
                if (lnkDatasheetData.Text == "")
                {
                    imgDataSheet.Visible = false;
                }
                else
                {
                    string strURL = lnkDatasheetData.Text;
                    string FileToCheck = Datasheet_DataPath + strURL;
                    imgDataSheet.ImageUrl = FileToCheck;
                    chkDatasheetData.Visible = true;
                }
                lnkPhoto.Text = careerInformationInfo.Photo_Data;
                if (lnkPhoto.Text == "")
                {
                    imgPhoto.Visible = false;
                }
                else
                {
                    string strURLPhoto = lnkPhoto.Text;
                    string FileToCheckPhoto = Photo_DataPath + strURLPhoto;
                    imgPhoto.ImageUrl = FileToCheckPhoto;
                    chkPhoto.Visible = true;
                }
                lnkCardData.Text = careerInformationInfo.IDCard_Data;
                if (lnkCardData.Text == "")
                {
                    imgCard.Visible = false;
                }
                else
                {
                    string strURLCard = lnkCardData.Text;
                    string FileToCheckCard = IDCard_DataPath + strURLCard;
                    imgCard.ImageUrl = FileToCheckCard;
                    chkCardData.Visible = true;
                }
                lnkCredentialData.Text = careerInformationInfo.Credential_Data;
                if (lnkCredentialData.Text == "")
                {
                    imgCredential.Visible = false;
                }
                else
                {
                    string strURLCredential = lnkCredentialData.Text;
                    string FileToCheckCredential = Credential_DataPath + strURLCredential;
                    imgCredential.ImageUrl = FileToCheckCredential;
                    chkCredentialData.Visible = true;
                }
                lnkGraduationData.Text = careerInformationInfo.Graduation_Data;
                if (lnkGraduationData.Text == "")
                {
                    imgGraduation.Visible = false;
                }
                else
                {
                    string strURLGraduation = lnkGraduationData.Text;
                    string FileToCheckGraduation = Graduation_DataPath + strURLGraduation;
                    imgGraduation.ImageUrl = FileToCheckGraduation;
                    chkGraduationData.Visible = true;
                }
                lnkCard.Text = careerInformationInfo.LabourCard_Data;
                if (lnkCard.Text == "")
                {
                    ImgLabour.Visible = false;
                }
                else
                {
                    string strURLLabourCard = lnkCard.Text;
                    string FileToCheckLabourCard = LabourCard_DataPath + strURLLabourCard;
                    ImgLabour.ImageUrl = FileToCheckLabourCard;
                    chkCard.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool CheckAttatchmentData(ArrayList array)
        {
            foreach (KeyValuePair<string, string> _x in array)
            {
                if (File.Exists(_x.Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        #region Datasheet_Click
        protected void lnkDatasheetData_Click(object sender, EventArgs e)
        {
            DownloadData(Datasheet_DataPath, lnkDatasheetData.Text);
        }
        #endregion

        #region Credential_Click
        protected void lnkCredentialData_Click(object sender, EventArgs e)
        {
            DownloadData(Credential_DataPath, lnkCredentialData.Text);
        }
        #endregion

        #region Photo_Click
        protected void lnkPhoto_Click(object sender, EventArgs e)
        {
            DownloadData(Photo_DataPath, lnkPhoto.Text);
        }
        #endregion

        #region Graduation_Click
        protected void lnkGraduationData_Click(object sender, EventArgs e)
        {
            DownloadData(Graduation_DataPath, lnkGraduationData.Text);
        }
        #endregion

        #region CardData_Click
        protected void lnkCardData_Click(object sender, EventArgs e)
        {
            DownloadData(IDCard_DataPath, lnkCardData.Text);
        }
        #endregion

        #region Labour_Click
        protected void lnkCard_Click(object sender, EventArgs e)
        {
            DownloadData(LabourCard_DataPath, lnkCard.Text);
        }
        #endregion

        protected void DownloadData(String path, String fileName)
        {
            try
            {
                string FileToCheck = path + fileName;
                if (File.Exists(Server.MapPath(FileToCheck)))
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportReportData();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Career_Resume.aspx?Career_ID=" + Career_ID);
        }

        public void ExportReportData()
        {
            try
            {
                careerResume = new Career_ResumeBL();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('../Report/Career_Resume_Report.aspx?Career_ID=" + Career_ID + "&Career_Code=" + lblCareerCode.Text + "','_blank');", true);
                DataTable dtCareerResume = careerResume.SelectByIDReport(Career_ID);
                if (dtCareerResume.Rows.Count > 0)
                {
                    string DataSheetFilePath = Server.MapPath(Datasheet_DataPath) + dtCareerResume.Rows[0]["Datasheet_Data"].ToString();
                    string IDCardFilePath = Server.MapPath(IDCard_DataPath) + dtCareerResume.Rows[0]["IDCard_Data"].ToString();
                    string CredentialFilePath = Server.MapPath(Credential_DataPath) + dtCareerResume.Rows[0]["Credential_Data"].ToString();
                    string GraduationFilePath = Server.MapPath(Graduation_DataPath) + dtCareerResume.Rows[0]["Graduation_Data"].ToString();
                    string LabourCardFilePath = Server.MapPath(LabourCard_DataPath) + dtCareerResume.Rows[0]["LabourCard_Data"].ToString();
                    ArrayList list = new ArrayList();
                    if (chkDatasheetData.Checked)
                    {
                        list.Add(new KeyValuePair<string, string>("DataSheetFilePath", DataSheetFilePath));
                    }
                    if (chkCredentialData.Checked)
                    {
                        list.Add(new KeyValuePair<string, string>("CredentialFilePath", CredentialFilePath));
                    }
                    if (chkGraduationData.Checked)
                    {
                        list.Add(new KeyValuePair<string, string>("GraduationFilePath", GraduationFilePath));
                    }
                    if (chkCardData.Checked)
                    {
                        list.Add(new KeyValuePair<string, string>("IDCardFilePath", IDCardFilePath));
                    }
                    if (chkCard.Checked)
                    {
                        list.Add(new KeyValuePair<string, string>("LabourCardFilePath", LabourCardFilePath));
                    }
                    Session["chkvalue"] = list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillSalary(DataTable dtsalary)
        {
            dlsalary.DataSource = dtsalary;
            dlsalary.DataBind();
        }

        public void FillOldjobhistory(DataTable dtoldjobhistory, int Career_ID)
        {
            datalistsalary.DataSource = dtoldjobhistory;
            datalistsalary.DataBind();
        }

        protected void dlsalary_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl = e.Item.FindControl("lblsalaryformat") as Label;
                if (lbl.Text == "1")
                    lbl.Text = "Up To";
                else if (lbl.Text == "2")
                    lbl.Text = "Nego";
                else if (lbl.Text == "3")
                    lbl.Text = "Max";
                else if (lbl.Text == "4")
                    lbl.Text = "Min";
            }
        }
    }
}