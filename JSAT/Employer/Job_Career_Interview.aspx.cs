using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT_Ver1.Employer
{
    public partial class Job_Career_Interview : System.Web.UI.Page
    {
        protected string dtpInterviewDateEdit { get; set; }
        protected string dtpInterviewDateFooter { get; set; }
        protected string dtpInterviewResultDateEdit { get; set; }
        public string dtpInterviewResultDateFooter { get; set; }
        public int Client_RecruitmentID
        {
            get
            {
                if (Request.QueryString["Client_RecruitmentID"] != null)
                    return int.Parse(Request.QueryString["Client_RecruitmentID"].ToString());
                return 0;
            }
        }
        public int Client_ID
        {
            get
            {
                if (Request.QueryString["Client_ID"] != null)
                    return int.Parse(Request.QueryString["Client_ID"].ToString());
                return 0;
            }
        }

        Job_Career_InterviewBL jobCareerInterview;
        Job_Career_InterviewEntity jobCareerInterviewInfo;
        Career_ResumeBL CareerResume;
        Career_ResumeEntity CareerResumeInfo;
        Client_ProfileBL ClientProfile;
        GlobalBL globalBL;
        bool resultRead;
        bool resultEdit;

        //Events
        protected void Page_Load(object sender, EventArgs e)
        {
            txtInterviewDate.Text = Request.Form[txtInterviewDate.UniqueID];
            txtInterviewResultDate.Text = Request.Form[txtInterviewResultDate.UniqueID];
            //hide button
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            resultRead = user.CanRead(userID, "019");
            if (resultRead)
            {
                btnSave.Visible = false;
            }
            resultEdit = user.CanSave(userID, "019");
            if (resultEdit)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;

            if (!String.IsNullOrWhiteSpace(txtName.Text))
            {
                String[] str = (txtName.Text.Split('$'));
                if (str.Length == 3)
                {
                    txtCareerCode.Text = str[1];
                    txtCareerName.Text = str[0];
                    txtID.Text = str[2];
                }
            }

            if (!IsPostBack)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                if (Client_RecruitmentID != 0)
                {
                    FillData();
                }
                Listing();
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {

            Listing();

            gvJobCareerInterview1.PageIndex = e.NewPageIndex;

            gvJobCareerInterview1.DataBind();

        }

        protected void EditJobCareer(object sender, GridViewEditEventArgs e)
        {
            jobCareerInterview = new Job_Career_InterviewBL();
            gvJobCareerInterview1.EditIndex = e.NewEditIndex;

            Listing();

            DropDownList ddlInterview = (DropDownList)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("ddlInterviewEdit");
            //HtmlGenericControl dtpInterviewDate = (HtmlGenericControl)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("dtpInterviewDateEdit");
            TextBox dtpInterviewDate = (TextBox)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("dtpInterviewDateEdit");
            DropDownList ddlInterviewResult = (DropDownList)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("ddlInterview_ResultEdit");
            //HtmlGenericControl dtpInterviewResultDate = (HtmlGenericControl)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("dtpInterviewResultDateEdit");
            TextBox dtpInterviewResultDate = (TextBox)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("dtpInterviewResultDateEdit");

            TextBox txtSalary = (TextBox)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("txtSalaryEdit");

            DropDownList ddlSalaryType = (DropDownList)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("ddlSalaryTypeEdit");

            int ID = (int)gvJobCareerInterview1.DataKeys[gvJobCareerInterview1.EditIndex].Value;

            DataTable dt = jobCareerInterview.SelectByID(ID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int JobCareerID = (int)dt.Rows[i]["ID"];
                if (ID == JobCareerID)
                {
                    txtSalary.Text = dt.Rows[i]["Salary"].ToString();

                    bool? Interview;
                    if (dt.Rows[i]["Interview"].ToString() != "")
                    {
                        Interview = Convert.ToBoolean(dt.Rows[i]["Interview"].ToString());
                    }
                    else
                    {
                        Interview = null;
                    }
                    if (Interview != null)
                    {
                        if (Interview == true)
                        {
                            ddlInterview.SelectedValue = "1";
                        }
                        else
                        {
                            ddlInterview.SelectedValue = "2";
                        }
                    }
                    else
                    {
                        ddlInterview.SelectedIndex = -1;
                    }


                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Interview_Date"].ToString()))
                    {
                        DateTime tmpInterviewDate = DateTime.Parse(dt.Rows[i]["Interview_Date"].ToString());
                        string InterviewDate = tmpInterviewDate.ToShortDateString();
                        string ConvertedInterviewDate = Convert.ToDateTime(InterviewDate, CultureInfo.GetCultureInfo("en-US")).ToString("dd/MM/yyyy");
                        this.dtpInterviewDateEdit = ConvertedInterviewDate;
                    }
                    bool? Interview_Result;
                    if (dt.Rows[i]["Interview_Result"].ToString() != "")
                    {
                        Interview_Result = Convert.ToBoolean(dt.Rows[i]["Interview_Result"].ToString());
                    }
                    else
                    {
                        Interview_Result = null;
                    }

                    if (Interview_Result != null)
                    {
                        if (Interview_Result == true)
                        {
                            ddlInterviewResult.SelectedValue = "1";
                        }
                        else
                        {
                            ddlInterviewResult.SelectedValue = "2";
                        }
                    }
                    else
                    {
                        ddlInterview.SelectedIndex = -1;
                    }



                    if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Interview_Result_Date"].ToString()))
                    {
                        DateTime tmpInterviewResultDate = DateTime.Parse(dt.Rows[i]["Interview_Result_Date"].ToString());
                        string InterviewResultDate = tmpInterviewResultDate.ToShortDateString();
                        string ConvertedInterviewResultDate = Convert.ToDateTime(InterviewResultDate, CultureInfo.GetCultureInfo("en-US")).ToString("dd/MM/yyyy");
                        this.dtpInterviewResultDateEdit = ConvertedInterviewResultDate;
                    }

                    if (dt.Rows[i]["Client_RecruitmentID"].ToString() != "")
                    {
                        ddlSalaryType.SelectedValue = dt.Rows[i]["Salary_TypeID"].ToString();
                    }


                }
            }
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvJobCareerInterview1.EditIndex = -1;
            Listing();

        }

        protected void UpdateJobCareer(object sender, GridViewUpdateEventArgs e)
        {
            jobCareerInterviewInfo = new Job_Career_InterviewEntity();
            jobCareerInterview = new Job_Career_InterviewBL();

            int ID = (int)gvJobCareerInterview1.DataKeys[gvJobCareerInterview1.EditIndex].Value;

            DropDownList ddlInterview_Result = (DropDownList)gvJobCareerInterview1.Rows[e.RowIndex].FindControl("ddlInterview_ResultEdit");
            DropDownList ddlInterview = (DropDownList)gvJobCareerInterview1.Rows[e.RowIndex].FindControl("ddlInterviewEdit");
            DropDownList ddlSalary_Type = (DropDownList)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("ddlSalaryTypeEdit");
            TextBox txtSalary = (TextBox)gvJobCareerInterview1.Rows[gvJobCareerInterview1.EditIndex].FindControl("txtSalaryEdit");

            jobCareerInterviewInfo.Salary = Convert.ToDecimal(txtSalary.Text);
            jobCareerInterviewInfo.Salary_Type = Convert.ToInt32(ddlSalary_Type.SelectedValue);

            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            dtfi.ShortDatePattern = "dd-MM-yyyy";
            dtfi.DateSeparator = "-";

            TextBox IDate = (TextBox)gvJobCareerInterview1.Rows[e.RowIndex].FindControl("dtpInterviewDateEdit");
            //string InterviewDate = Request.Form["dtpInterviewDateEdit"].ToString();
            string InterviewDate = IDate.Text;
            if (InterviewDate != "")
            {
                DateTime objInterviewDate = Convert.ToDateTime(InterviewDate, dtfi);
                string ConvertedInterviewDate = Convert.ToDateTime(objInterviewDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                jobCareerInterviewInfo.Interview_Date = DateTime.ParseExact(ConvertedInterviewDate, "MM/dd/yyyy hh:MM:ss", null);
            }
            else
            {
                jobCareerInterviewInfo.Interview_Date = null;
            }

            TextBox IRDate = (TextBox)gvJobCareerInterview1.Rows[e.RowIndex].FindControl("dtpInterviewDateEdit");
            //string InterviewResultDate = Request.Form["dtpInterviewResultDateEdit"].ToString();
            string InterviewResultDate = IRDate.Text;
            if (InterviewResultDate != "")
            {
                DateTime objInterviewResultDate = Convert.ToDateTime(InterviewResultDate, dtfi);
                string ConvertedInterviewResultDate = Convert.ToDateTime(objInterviewResultDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                jobCareerInterviewInfo.Interview_Result_Date = DateTime.ParseExact(ConvertedInterviewResultDate, "MM/dd/yyyy hh:MM:ss", null);
            }
            else
            {
                jobCareerInterviewInfo.Interview_Result_Date = null;
            }

            DataTable dt = jobCareerInterview.SelectByID(int.Parse(gvJobCareerInterview1.DataKeys[gvJobCareerInterview1.EditIndex].Value.ToString()));
            if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Career_ID"].ToString()))
                jobCareerInterviewInfo.Career_ID = BaseLib.Convert_Int(dt.Rows[0]["Career_ID"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int JobCareerID = (int)dt.Rows[i]["ID"];
                if (ID == JobCareerID)
                {

                    jobCareerInterviewInfo.Client_RecruitmentID = int.Parse(dt.Rows[i]["Client_RecruitmentID"].ToString());
                    break;
                }
            }

            jobCareerInterviewInfo.ID = ID;
            if (ddlInterview.SelectedValue.ToString() == "1")
            {
                jobCareerInterviewInfo.Interview = true;
            }
            else if (ddlInterview.SelectedValue.ToString() == "2")
            {
                jobCareerInterviewInfo.Interview = false;
            }
            else
            {
                jobCareerInterviewInfo.Interview = null;
            }

            if (ddlInterview_Result.SelectedValue.ToString() == "1")
            {
                jobCareerInterviewInfo.Interview_Result = true;
            }
            else if (ddlInterview_Result.SelectedValue.ToString() == "2")
            {
                jobCareerInterviewInfo.Interview_Result = false;
            }
            else
            {
                jobCareerInterviewInfo.Interview_Result = null;
            }

            string result = jobCareerInterview.Update(jobCareerInterviewInfo, 1);
            if (result != "")
            {
                GlobalUI.MessageBox(result);
            }
            else
            {
                GlobalUI.MessageBox("Update Failed!");
            }

            gvJobCareerInterview1.EditIndex = -1;

            Listing();
        }

        protected void ddlCareerCodeFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Career_ID = txtID.Text;
        }

        protected void ddlCareerNameFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Career_ID = txtID.Text;
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Edit Template

            DropDownList ddlInterviewEdit = e.Row.FindControl("ddlInterviewEdit") as DropDownList;
            DropDownList ddlSalaryTypeEdit = e.Row.FindControl("ddlSalaryTypeEdit") as DropDownList;


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
            }

            if (ddlSalaryTypeEdit != null)
            {
                SalaryTypeBL salary = new SalaryTypeBL();
                ddlSalaryTypeEdit.DataSource = salary.SelectAll();
                ddlSalaryTypeEdit.DataTextField = "Description";
                ddlSalaryTypeEdit.DataValueField = "ID";
                ddlSalaryTypeEdit.DataBind();
            }


            #endregion

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }

                if (ddlsalarytype != null)
                {
                    SalaryTypeBL stbl = new SalaryTypeBL();
                    ddlsalarytype.DataSource = stbl.SelectAll();
                    ddlsalarytype.DataTextField = "Description";
                    ddlsalarytype.DataValueField = "ID";
                    ddlsalarytype.DataBind();
                }

                //Hide GridView Edit button 
                if (resultRead)
                {
                    e.Row.Cells[8].Controls[0].Visible = false;
                }
                if (resultEdit)
                {
                    e.Row.Cells[8].Controls[0].Visible = true;
                }

            }
        }

        //Functions
        private void FillData()
        {
            jobCareerInterview = new Job_Career_InterviewBL();
            DataTable dtJobCareerInterview = jobCareerInterview.SelectByCareerIDAndClientRecruitment(Client_RecruitmentID, Client_ID);
            DataTable dt = jobCareerInterview.SelectByClientRecruitmentID(Client_RecruitmentID);
            ClientProfile = new Client_ProfileBL();
            DataTable dtClientProfile = ClientProfile.SelectById(Client_ID);
            if (dtClientProfile.Rows.Count > 0)
            {
                lblClientNo.Text = dtClientProfile.Rows[0]["Client_Code"].ToString();
            }
            if (Client_RecruitmentID != 0)
            {
                lblRecruitmentNo.Text = Client_RecruitmentID.ToString();
            }

            if (dtJobCareerInterview.Rows.Count > 0)
            {
                lblUpdaterData.Text = dtJobCareerInterview.Rows[0]["LogIn_ID"].ToString();
                lblUpdateTimeData.Text = dtJobCareerInterview.Rows[0]["UpdatedDate"].ToString();

                if (!String.IsNullOrWhiteSpace(dtJobCareerInterview.Rows[0]["Submission_Date"].ToString()))
                {
                    string date = dtJobCareerInterview.Rows[0]["Submission_Date"].ToString();
                    lblSubmittedDate.Text = GlobalUI.Format_Date(date);
                }
                lblDepartment.Text = dtJobCareerInterview.Rows[0]["Department"].ToString();
                lblPosition.Text = dtJobCareerInterview.Rows[0]["Position"].ToString();
                lblOtherSalary.Text = dtJobCareerInterview.Rows[0]["Other_Salary"].ToString();
                lblPersonInCharge.Text = dtJobCareerInterview.Rows[0]["PersonInCharge"].ToString();
                lblUnit.Text = dtJobCareerInterview.Rows[0]["Unit"].ToString();
                lblEmail.Text = dtJobCareerInterview.Rows[0]["Email"].ToString();
                lblRemarks.Text = dtJobCareerInterview.Rows[0]["Remarks"].ToString();


                lblCompany.Text = dtJobCareerInterview.Rows[0]["Client_Name"].ToString();
                lblProfileTelephone.Text = dtJobCareerInterview.Rows[0]["ClientProfile_Telephone"].ToString();
                lblLocation.Text = dtJobCareerInterview.Rows[0]["Location"].ToString();
                lblIndustry.Text = dtJobCareerInterview.Rows[0]["Industry_Type"].ToString();
                lblTypeOfBusiness.Text = dtJobCareerInterview.Rows[0]["Business_Type"].ToString();


                if (dtJobCareerInterview.Rows[0]["ClientRecruitment_GenderID"].ToString() == "1")
                {
                    lblGender.Text = "男";
                }
                else
                {
                    lblGender.Text = "女";
                }
                string type = string.Empty;
                if (!string.IsNullOrWhiteSpace(dtJobCareerInterview.Rows[0]["Salary_Format"].ToString()))
                {
                    if (dtJobCareerInterview.Rows[0]["Salary_Format"].ToString() == "1")
                        type = "Up to";
                    else if (dtJobCareerInterview.Rows[0]["Salary_Format"].ToString() == "2")
                        type = "Nego";
                    else if (dtJobCareerInterview.Rows[0]["Salary_Format"].ToString() == "3")
                        type = "Max";
                    else if (dtJobCareerInterview.Rows[0]["Salary_Format"].ToString() == "4")
                        type = "Min";
                }
                if (!string.IsNullOrWhiteSpace(type))
                    lblSalary.Text = dtJobCareerInterview.Rows[0]["Salary_From"].ToString() + " ～ " + dtJobCareerInterview.Rows[0]["Salary_To"].ToString() + " " + dtJobCareerInterview.Rows[0]["Salary_Type"].ToString() + " - " + type;
                else
                    lblSalary.Text = dtJobCareerInterview.Rows[0]["Salary_From"].ToString() + " ～ " + dtJobCareerInterview.Rows[0]["Salary_To"].ToString() + " " + dtJobCareerInterview.Rows[0]["Salary_Type"].ToString();
                lblOtherPosition.Text = dtJobCareerInterview.Rows[0]["Other_Position"].ToString();
                lblWorkingPlace.Text = dtJobCareerInterview.Rows[0]["Working_Place"].ToString();
                lblOtherWorkingPlace.Text = dtJobCareerInterview.Rows[0]["Other_WorkingPlace"].ToString();
                lblDayService.Text = dtJobCareerInterview.Rows[0]["Day_Service"].ToString();
                lblStarting.Text = dtJobCareerInterview.Rows[0]["Starting"].ToString();
                lblClosing.Text = dtJobCareerInterview.Rows[0]["Closing"].ToString();
                lblLanguage.Text = dtJobCareerInterview.Rows[0]["Language"].ToString();
                lblLanguageLevel.Text = dtJobCareerInterview.Rows[0]["LanguageFrom"].ToString() + "~" + dtJobCareerInterview.Rows[0]["LanguageTo"].ToString();
                lblAge.Text = dtJobCareerInterview.Rows[0]["Age_From"].ToString() + "	歳~" + dtJobCareerInterview.Rows[0]["Age_To"].ToString() + " 歳";
                lblRecruitmentTelephone.Text = dtJobCareerInterview.Rows[0]["ClientRecruitment_Telephone_No"].ToString();
                if (dtJobCareerInterview.Rows[0]["Wanted"].ToString() != "true")
                {
                    lblWanted.Text = "○";
                }
                else if (dtJobCareerInterview.Rows[0]["Wanted"].ToString() != "false")
                {
                    lblWanted.Text = "×";
                }
            }
            else if (dt.Rows.Count > 0)
            {
                lblCompany.Text = dt.Rows[0]["Client_Name"].ToString();
                lblProfileTelephone.Text = dt.Rows[0]["ClientProfile_Telephone"].ToString();
                lblLocation.Text = dt.Rows[0]["Location"].ToString();
                lblIndustry.Text = dt.Rows[0]["Industry_Type"].ToString();
                lblTypeOfBusiness.Text = dt.Rows[0]["Business_Type"].ToString();


                if (dt.Rows[0]["ClientRecruitment_GenderID"].ToString() == "1")
                {
                    lblGender.Text = "男";
                }
                else
                {
                    lblGender.Text = "女";
                }
                string type = string.Empty;
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Salary_Format"].ToString()))
                {
                    if (dt.Rows[0]["Salary_Format"].ToString() == "1")
                        type = "Up to";
                    else if (dt.Rows[0]["Salary_Format"].ToString() == "2")
                        type = "Nego";
                    else if (dt.Rows[0]["Salary_Format"].ToString() == "3")
                        type = "Max";
                    else if (dt.Rows[0]["Salary_Format"].ToString() == "4")
                        type = "Min";
                }
                if (!string.IsNullOrWhiteSpace(type))
                    lblSalary.Text = dt.Rows[0]["Salary_From"].ToString() + " ～ " + dt.Rows[0]["Salary_To"].ToString() + " " + dt.Rows[0]["Salary_Type"].ToString() + " - " + type;
                else
                    lblSalary.Text = dt.Rows[0]["Salary_From"].ToString() + " ～ " + dt.Rows[0]["Salary_To"].ToString() + " " + dt.Rows[0]["Salary_Type"].ToString();
                lblOtherPosition.Text = dt.Rows[0]["Other_Position"].ToString();
                lblWorkingPlace.Text = dt.Rows[0]["Working_Place"].ToString();
                lblOtherWorkingPlace.Text = dt.Rows[0]["Other_WorkingPlace"].ToString();
                lblDayService.Text = dt.Rows[0]["Day_Service"].ToString();
                lblStarting.Text = dt.Rows[0]["Starting"].ToString();
                lblClosing.Text = dt.Rows[0]["Closing"].ToString();
                lblLanguage.Text = dt.Rows[0]["Language"].ToString();
                lblLanguageLevel.Text = dt.Rows[0]["LanguageLevel_From"].ToString() + "~" + dt.Rows[0]["LanguageLevel_To"].ToString();
                lblAge.Text = dt.Rows[0]["Age_From"].ToString() + "	歳~" + dt.Rows[0]["Age_To"].ToString() + "歳";
                lblRecruitmentTelephone.Text = dt.Rows[0]["ClientRecruitment_Telephone_No"].ToString();

                if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Submission_Date"].ToString()))
                {
                    string date = dt.Rows[0]["Submission_Date"].ToString();
                    lblSubmittedDate.Text = GlobalUI.Format_Date(date);
                }
                lblPosition.Text = dt.Rows[0]["Position"].ToString();
                lblDepartment.Text = dt.Rows[0]["Department"].ToString();
                lblOtherSalary.Text = dt.Rows[0]["Other_Salary"].ToString();
                lblPersonInCharge.Text = dt.Rows[0]["PersonInCharge"].ToString();
                lblUnit.Text = dt.Rows[0]["Unit"].ToString();
                lblEmail.Text = dt.Rows[0]["Email"].ToString();
                lblRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                if (dt.Rows[0]["Wanted"].ToString() != "true")
                {
                    lblWanted.Text = "○";
                }
                else if (dt.Rows[0]["Wanted"].ToString() != "false")
                {
                    lblWanted.Text = "×";
                }
            }
        }

        private void Listing()
        {
            //Load Profile data
            jobCareerInterview = new Job_Career_InterviewBL();
            if (Client_RecruitmentID != 0)
            {
                DataTable dt = jobCareerInterview.SelectByCareerIDAndClientRecruitment(Client_RecruitmentID, Client_ID);
                //To Display Circle for true in Gridview
                DataTable temp = jobCareerInterview.SelectByCareerIDAndClientRecruitment(Client_RecruitmentID, Client_ID);


                dt.Columns.Add("InterviewString", System.Type.GetType("System.String"));
                dt.Columns.Add("InterviewResultString", System.Type.GetType("System.String"));

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    if (temp.Rows[i]["Interview"].ToString() != "")
                    {
                        if (temp.Rows[i]["Interview"].ToString().ToLower() == "true")
                        {
                            dt.Rows[i]["InterviewString"] = "○";
                        }
                        else if (temp.Rows[i]["Interview"].ToString().ToLower() == "false")
                        {
                            dt.Rows[i]["InterviewString"] = "×";
                        }
                        else
                        {
                            dt.Rows[i]["InterviewString"] = "";
                        }
                        if (temp.Rows[i]["Interview_Result"].ToString().ToLower() == "true")
                        {
                            dt.Rows[i]["InterviewResultString"] = "○";
                        }
                        else if (temp.Rows[i]["Interview_Result"].ToString().ToLower() == "false")
                        {
                            dt.Rows[i]["InterviewResultString"] = "×";
                        }
                        else
                        {
                            dt.Rows[i]["InterviewResultString"] = "";
                        }
                    }
                }
                dt.AcceptChanges();
                if (dt.Rows.Count < 1)
                {
                    dt.Rows.Add(0);
                    gvJobCareerInterview1.DataSource = dt;
                    gvJobCareerInterview1.DataBind();
                }
                else
                {
                    gvJobCareerInterview1.DataSource = dt;
                    gvJobCareerInterview1.DataBind();
                }
            }
            else
            {
                DataTable dt = jobCareerInterview.SelectAll();
                if (dt.Rows.Count > 0)
                {
                    gvJobCareerInterview1.DataSource = dt;
                    gvJobCareerInterview1.DataBind();
                }
                else
                {
                    dt.Rows.Add(0);
                    gvJobCareerInterview1.DataSource = dt;
                    gvJobCareerInterview1.DataBind();
                }
            }
        }

        private bool Validation(int ID, int Career_ID)
        {
            int Count = jobCareerInterview.Check_ExistingCode(ID, Client_RecruitmentID, Career_ID);
            if (Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                jobCareerInterview = new Job_Career_InterviewBL();
                jobCareerInterviewInfo = new Job_Career_InterviewEntity();
                CareerResume = new Career_ResumeBL();
                CareerResumeInfo = new Career_ResumeEntity();

                int Career_ID = int.Parse(txtID.Text);
                string salary = txtsalary.Text;
                jobCareerInterviewInfo.Salary = BaseLib.Convert_Int(salary);

                jobCareerInterviewInfo.Salary_Type = Convert.ToInt32(ddlsalarytype.SelectedValue);
                CareerResumeInfo = CareerResume.SelectByCareerCode(txtCareerCode.Text);
                jobCareerInterviewInfo.Career_ID = CareerResumeInfo.Career_ID;
                jobCareerInterviewInfo.Client_RecruitmentID = Client_RecruitmentID;
                if (ddlInterview.SelectedValue.ToString() == "1")
                {
                    jobCareerInterviewInfo.Interview = true;
                }
                else if (ddlInterview.SelectedValue.ToString() == "2")
                {
                    jobCareerInterviewInfo.Interview = false;
                }
                else
                {
                    jobCareerInterviewInfo.Interview = null;
                }

                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd-MM-yyyy";
                dtfi.DateSeparator = "-";

                string strInterviewDateFooter = Request.Form[txtInterviewDate.UniqueID].ToString();
                if (!String.IsNullOrWhiteSpace(strInterviewDateFooter))
                {
                    DateTime objInterviewDateFooter = Convert.ToDateTime(strInterviewDateFooter, dtfi);
                    string InterviewDateFooter = Convert.ToDateTime(objInterviewDateFooter, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    jobCareerInterviewInfo.Interview_Date = DateTime.ParseExact(InterviewDateFooter, "MM/dd/yyyy hh:MM:ss", null);
                }
                else
                {
                    jobCareerInterviewInfo.Interview_Date = null;
                }

                if (ddlIntresult.SelectedValue.ToString() == "1")
                {
                    jobCareerInterviewInfo.Interview_Result = true;
                }
                else if (ddlIntresult.SelectedValue.ToString() == "2")
                {
                    jobCareerInterviewInfo.Interview_Result = false;
                }
                else
                {
                    jobCareerInterviewInfo.Interview_Result = null;
                }

                string strInterviewResultDateFooter = Request.Form[txtInterviewResultDate.UniqueID].ToString();
                if (!String.IsNullOrWhiteSpace(strInterviewResultDateFooter))
                {
                    DateTime objInterviewResultDateFooter = Convert.ToDateTime(strInterviewResultDateFooter, dtfi);
                    string InterviewResultDateFooter = Convert.ToDateTime(objInterviewResultDateFooter, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    jobCareerInterviewInfo.Interview_Result_Date = DateTime.ParseExact(InterviewResultDateFooter, "MM/dd/yyyy hh:MM:ss", null);
                }
                else
                {
                    jobCareerInterviewInfo.Interview_Result_Date = null;
                }

                string result = jobCareerInterview.Insert(jobCareerInterviewInfo, 0);
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
                else if (result == "Save fail!")
                {
                    GlobalUI.MessageBox(result);
                }

                FillData();
                Listing();
                txtsalary.Text = string.Empty;
            }
            catch (Exception ex)
            {
                GlobalUI.MessageBox(ex.Message);
            }
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            txtInterviewDate.Text = String.Empty;
            txtInterviewResultDate.Text = Request.Form[txtInterviewResultDate.UniqueID];
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            txtInterviewResultDate.Text = String.Empty;
            txtInterviewDate.Text = Request.Form[txtInterviewDate.UniqueID];
        }
    }
}