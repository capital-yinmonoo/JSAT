using JSAT_BL;
using JSAT_BL.Employee;
using JSAT_Common;
using JSAT_Common.Employee;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1.Employee
{
    public partial class Career_Resume : System.Web.UI.Page
    {
        protected string InputValue { get; set; }
        protected string InputValue2 { get; set; }
        Career_ResumeEntity cre;
        Career_InterviewQuestion3BL CareerInvQuestion3;
        InterViewQuestion3BL IntQuestion3;
        Career_Interview_Question3Entity CareerInfo;
        Career_InterView3Entity MJInfo;
        Career_InformationBL careerInformation;
        GenderBL gender;
        Career_InformationEntity careerInformationInfo;
        string All_DataPath = ConfigurationManager.AppSettings["All_Data"].ToString();
        string IDCard_DataPath = ConfigurationManager.AppSettings["IDCard_DataPath"].ToString();
        string Credential_DataPath = ConfigurationManager.AppSettings["Credential_DataPath"].ToString();
        string Japanese_DataPath = ConfigurationManager.AppSettings["Japanese_DataPath"].ToString();
        string Graduation_DataPath = ConfigurationManager.AppSettings["Graduation_DataPath"].ToString();
        string Photo_DataPath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();
        string Datasheet_DataPath = ConfigurationManager.AppSettings["Datasheet_DataPath"].ToString();
        string Qualification_DataPath = ConfigurationManager.AppSettings["Qualification_DataPath"].ToString();
        string LabourCard_DataPath = ConfigurationManager.AppSettings["LabourCard_DataPath"].ToString();
        string customerId;

        public int Career_ID
        {
            get
            {
                if (Request.QueryString["Career_ID"] != null)
                    return int.Parse(Request.QueryString["Career_ID"].ToString());
                return 0;
            }
        }
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

        DataTable dtCareerInformation = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDateofBirth.Text = Request.Form[txtDateofBirth.UniqueID];
            txtGraduationDate.Text = Request.Form[txtGraduationDate.UniqueID];
            Page.MaintainScrollPositionOnPostBack = false;
            //User Authorized on saving , uncommen later.
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            bool resultRead = user.CanRead(userID, "022");
            if (resultRead)
            {
                btnSave.Visible = false;
                btnDelete.Visible = false;
            }
            bool resultDelete = user.CanDelete(userID, "022");
            if (resultDelete)
                btnDelete.Visible = true;
            else
                btnDelete.Visible = false;

            bool resultEdit = user.CanSave(userID, "022");
            if (resultEdit)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;

            if (String.IsNullOrWhiteSpace(Request.QueryString["Career_ID"]))
            {
                //Career_InterviewControl2.CareerID = hfCareerID.Value;
            }
            else
            {
                //Career_InterviewControl2.CareerID = Request.QueryString["Career_ID"];
                //Career_InterviewControl2.CarEmploymentlink = true;
                //Career_InterviewControl2.CarInterview1link = true;
                //Career_InterviewControl2.CarInterview2link = true;
                //Career_InterviewControl2.CarInterview3link = true;
                //Career_InterviewControl2.CarInformationlink = true;
            }
            if (!IsPostBack)
            {
                gvCustomers.DataSource = GetData("Select Interview_Question_Title_ID,Interview_Question_Title From Interview_Question_Title where IsDeleted=0");
                gvCustomers.DataBind();
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                }
                else ViewState["UrlReferrer"] = null;
                if (Career_ID != 0)
                {
                    FillData1();
                    MakeDeleteButtonsVisible(true);
                }
                IntQuestion3 = new InterViewQuestion3BL();
                SetInitialRow();
                if (Request.QueryString["Career_ID"] != null)
                {
                    lbldate.Visible = true;
                    lblID.Visible = true;
                    lblUpdatedBy.Visible = true;
                    lblUpdatedDate.Visible = true;
                    int id = Convert.ToInt32(Request.QueryString["Career_ID"].ToString());
                    IntvQ3SelectedByID(id);
                    GetComment(id);
                }
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                }
                else ViewState["UrlReferrer"] = null;
                txtCode.Focus();
                FillData();
                if (Request.QueryString["Career_ID"] != null)
                {
                    hfCareerID.Value = Request.QueryString["Career_ID"];
                    Career_Interview1BL cibl = new Career_Interview1BL();
                    Career_ResumeBL rbl = new Career_ResumeBL();
                    DataTable dt = cibl.SelectByCareerID(BaseLib.Convert_Int(hfCareerID.Value));
                    DataTable dtsalary = rbl.SelectBySalary_CareerID(BaseLib.Convert_Int(hfCareerID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        hfMode.Value = "Update";
                        btnDelete.Enabled = true;
                        lbldate.Visible = true;
                        lblID.Visible = true;
                        lblUpdatedBy.Visible = true;
                        lblUpdatedDate.Visible = true;
                        lblUpdatedBy.Text = dt.Rows[0]["LogIn_ID"].ToString();
                        lblUpdatedDate.Text = dt.Rows[0]["UpdatedDate"].ToString();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Career Code"].ToString()))
                        {
                            String[] str = dt.Rows[0]["Career Code"].ToString().Split('-');
                            if (str.Length == 2)
                            {
                                if (ddlCode.Items.FindByText(str[0]) != null)
                                {
                                    ddlCode.ClearSelection();
                                    ddlCode.Items.FindByText(str[0]).Selected = true;
                                }
                                txtCode.Text = str[1];
                            }
                            else
                            {
                                txtCode.Text = str[0];
                            }
                        }
                        bindimpression.Text = dt.Rows[0]["Impression"].ToString();
                        txtimpressionjp.Text = dt.Rows[0]["Impression_Japan"].ToString();
                        bindotherqualification.Text = dt.Rows[0]["Other_Qualification"].ToString();
                        if (dt.Rows[0]["NoticeType"].ToString() == "Immediate")
                        {
                            lblnoticttype.Text = "Immediate";
                        }
                        else
                        {
                            if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Notice_Day"].ToString()) && !String.IsNullOrWhiteSpace(dt.Rows[0]["NoticeType"].ToString()))
                            {
                                lblnoticttype.Text = dt.Rows[0]["Notice_Day"].ToString() + dt.Rows[0]["NoticeType"].ToString();
                            }
                        }
                        bindTotalMark.Text = dt.Rows[0]["TotalMark"].ToString();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["GenderID"].ToString()))
                        {
                            ddlGender.ClearSelection();
                            ddlGender.SelectedValue = dt.Rows[0]["GenderID"].ToString();
                        }
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtAge.Text = dt.Rows[0]["Age"].ToString();
                        txtYear.Text = dt.Rows[0]["Year"].ToString();
                        txtYear2.Text = dt.Rows[0]["Year2"].ToString();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["DOB"].ToString()))
                        {
                            DateTime date = (DateTime)dt.Rows[0]["DOB"];
                            txtDateofBirth.Text = Convert.ToDateTime(date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
                        }

                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Graduate Date"].ToString()))
                        {
                            txtGraduationDate.Text = dt.Rows[0]["Graduate Date"].ToString();
                        }

                        if (ddlReligion.Items.FindByText(dt.Rows[0]["Religion"].ToString()) != null)
                        {
                            ddlReligion.ClearSelection();
                            ddlReligion.Items.FindByText(dt.Rows[0]["Religion"].ToString()).Selected = true;
                        }
                        if (ddlAddress.Items.FindByText(dt.Rows[0]["Address"].ToString()) != null)
                        {
                            ddlAddress.ClearSelection();
                            ddlAddress.Items.FindByText(dt.Rows[0]["Address"].ToString()).Selected = true;
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Phone1"].ToString()))
                        {
                            txtph1.Text = dt.Rows[0]["Phone1"].ToString();
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Phone2"].ToString()))
                        {
                            txtph2.Text = dt.Rows[0]["Phone2"].ToString();
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Email"].ToString()))
                        {
                            txtemail.Text = dt.Rows[0]["Email"].ToString();
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Contact No"].ToString()))
                        {
                            txtemph.Text = dt.Rows[0]["Contact No"].ToString();
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Contact Name"].ToString()))
                        {
                            txtemperson.Text = dt.Rows[0]["Contact Name"].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[0]["Domestic"])!=0)
                        {
                            chkdomestic.Checked = true;
                        }
                        else
                        { chkdomestic.Checked = false; }
                        if (Convert.ToInt32(dt.Rows[0]["Oversea"]) != 0)
                        {
                            chkoversea.Checked = true;
                        }
                        else
                        { chkoversea.Checked = false; }
                        if (chkWorkableArea.Items.FindByText(dt.Rows[0]["Workable Area"].ToString()) != null)
                        {
                            chkWorkableArea.ClearSelection();
                            chkWorkableArea.Items.FindByText(dt.Rows[0]["Workable Area"].ToString()).Selected = true;
                        }
                        if (ddlDivision1.Items.FindByText(dt.Rows[0]["Division1"].ToString()) != null)
                        {
                            ddlDivision1.ClearSelection();
                            ddlDivision1.Items.FindByText(dt.Rows[0]["Division1"].ToString()).Selected = true;
                            PositionBL pb = new PositionBL();
                            ddlPosition1.DataSource = pb.SelectByDepartmentID(BaseLib.Convert_Int(ddlDivision1.SelectedValue));
                            ddlPosition1.DataTextField = "Description";
                            ddlPosition1.DataValueField = "ID";
                            ddlPosition1.DataBind();
                            ddlPosition1.ClearSelection();
                            ddlPosition1.Items.Insert(0, "");
                            ddlPosition1.Text = "";
                        }
                        if (ddlCareerStatus.Items.FindByText(dt.Rows[0]["CareerStatus"].ToString()) != null)
                        {
                            ddlCareerStatus.ClearSelection();
                            ddlCareerStatus.Items.FindByText(dt.Rows[0]["CareerStatus"].ToString()).Selected = true;
                        }
                        if (ddlPosition1.Items.FindByText(dt.Rows[0]["Position1"].ToString()) != null)
                        {
                            ddlPosition1.ClearSelection();
                            ddlPosition1.Items.FindByText(dt.Rows[0]["Position1"].ToString()).Selected = true;
                        }
                        if (ddlPositionLevel1.Items.FindByText(dt.Rows[0]["PositionLevel1"].ToString()) != null)
                        {
                            ddlPositionLevel1.ClearSelection();
                            ddlPositionLevel1.Items.FindByText(dt.Rows[0]["PositionLevel1"].ToString()).Selected = true;
                        }
                        if (ddlDivision2.Items.FindByText(dt.Rows[0]["Division2"].ToString()) != null)
                        {
                            ddlDivision2.ClearSelection();
                            ddlDivision2.Items.FindByText(dt.Rows[0]["Division2"].ToString()).Selected = true;
                            PositionBL pb = new PositionBL();
                            ddlPosition2.DataSource = pb.SelectByDepartmentID(BaseLib.Convert_Int(ddlDivision2.SelectedValue));
                            ddlPosition2.DataTextField = "Description";
                            ddlPosition2.DataValueField = "ID";
                            ddlPosition2.DataBind();
                            ddlPosition2.ClearSelection();
                            ddlPosition2.Items.Insert(0, "");
                            ddlPosition2.Text = "";
                        }
                        if (ddlPosition2.Items.FindByText(dt.Rows[0]["Position2"].ToString()) != null)
                        {
                            ddlPosition2.ClearSelection();
                            ddlPosition2.Items.FindByText(dt.Rows[0]["Position2"].ToString()).Selected = true;
                        }
                        if (ddlPositionLevel2.Items.FindByText(dt.Rows[0]["PositionLevel2"].ToString()) != null)
                        {
                            ddlPositionLevel2.ClearSelection();
                            ddlPositionLevel2.Items.FindByText(dt.Rows[0]["PositionLevel2"].ToString()).Selected = true;
                        }
                        if (ddlDivision3.Items.FindByText(dt.Rows[0]["Division3"].ToString()) != null)
                        {
                            ddlDivision3.ClearSelection();
                            ddlDivision3.Items.FindByText(dt.Rows[0]["Division3"].ToString()).Selected = true;
                            PositionBL pb = new PositionBL();
                            ddlPosition3.DataSource = pb.SelectByDepartmentID(BaseLib.Convert_Int(ddlDivision3.SelectedValue));
                            ddlPosition3.DataTextField = "Description";
                            ddlPosition3.DataValueField = "ID";
                            ddlPosition3.DataBind();
                            ddlPosition3.ClearSelection();
                            ddlPosition3.Items.Insert(0, "");
                            ddlPosition3.Text = "";
                        }
                        if (ddlPosition3.Items.FindByText(dt.Rows[0]["Position3"].ToString()) != null)
                        {
                            ddlPosition3.ClearSelection();
                            ddlPosition3.Items.FindByText(dt.Rows[0]["Position3"].ToString()).Selected = true;
                        }
                        if (ddlPositionLevel3.Items.FindByText(dt.Rows[0]["PositionLevel3"].ToString()) != null)
                        {
                            ddlPositionLevel3.ClearSelection();
                            ddlPositionLevel3.Items.FindByText(dt.Rows[0]["PositionLevel3"].ToString()).Selected = true;
                        }
                        if (ddlCurrentCareerCondition.Items.FindByText(dt.Rows[0]["Current Career Condition"].ToString()) != null)
                        {
                            ddlCurrentCareerCondition.ClearSelection();
                            ddlCurrentCareerCondition.Items.FindByText(dt.Rows[0]["Current Career Condition"].ToString()).Selected = true;
                        }
                        if (ddlEduBackground.Items.FindByText(dt.Rows[0]["Educational Background"].ToString()) != null)
                        {
                            ddlEduBackground.ClearSelection();
                            ddlEduBackground.Items.FindByText(dt.Rows[0]["Educational Background"].ToString()).Selected = true;
                        }

                        if (ddlUniversityName.Items.FindByText(dt.Rows[0]["Instituation Name"].ToString()) != null)
                        {
                            ddlUniversityName.ClearSelection();
                            ddlUniversityName.Items.FindByText(dt.Rows[0]["Instituation Name"].ToString()).Selected = true;
                        }
                        else
                        {
                            ddlUniversityName.ClearSelection();
                            ddlUniversityName.Items.Insert(0, "");
                            ddlUniversityName.Text = "";
                        }
                        if (ddlUniversityName2.Items.FindByText(dt.Rows[0]["Instituation Name2"].ToString()) != null)
                        {
                            ddlUniversityName2.ClearSelection();
                            ddlUniversityName2.Items.FindByText(dt.Rows[0]["Instituation Name2"].ToString()).Selected = true;
                        }
                        else
                        {
                            ddlUniversityName2.ClearSelection();
                            ddlUniversityName2.Items.Insert(0, "");
                            ddlUniversityName2.Text = "";
                        }
                        FillInstitutionArea();
                        if (ddlUniversityArea.Items.FindByText(dt.Rows[0]["Instituation Area"].ToString()) != null)
                        {
                            ddlUniversityArea.ClearSelection();
                            ddlUniversityArea.Items.FindByText(dt.Rows[0]["Instituation Area"].ToString()).Selected = true;
                        }
                        else
                        {
                            ddlUniversityArea.ClearSelection();
                            ddlUniversityArea.Items.Insert(0, "");
                            ddlUniversityArea.Text = "";
                        }
                        if (ddlUniversityArea2.Items.FindByText(dt.Rows[0]["Instituation Area2"].ToString()) != null)
                        {
                            ddlUniversityArea2.ClearSelection();
                            ddlUniversityArea2.Items.FindByText(dt.Rows[0]["Instituation Area2"].ToString()).Selected = true;
                        }
                        else
                        {
                            ddlUniversityArea2.ClearSelection();
                            ddlUniversityArea2.Items.Insert(0, "");
                            ddlUniversityArea2.Text = "";
                        }
                        if (ddlMajor.Items.FindByText(dt.Rows[0]["Major"].ToString()) != null)
                        {
                            ddlMajor.ClearSelection();
                            ddlMajor.Items.FindByText(dt.Rows[0]["Major"].ToString()).Selected = true;
                        }
                        if (ddlMajor2.Items.FindByText(dt.Rows[0]["Major2"].ToString()) != null)
                        {
                            ddlMajor2.ClearSelection();
                            ddlMajor2.Items.FindByText(dt.Rows[0]["Major2"].ToString()).Selected = true;
                        }
                        if (ddldegree.Items.FindByText(dt.Rows[0]["Degree"].ToString()) != null)
                        {
                            ddldegree.ClearSelection();
                            ddldegree.Items.FindByText(dt.Rows[0]["Degree"].ToString()).Selected = true;
                        }
                        if (ddldegree2.Items.FindByText(dt.Rows[0]["Degree2"].ToString()) != null)
                        {
                            ddldegree2.ClearSelection();
                            ddldegree2.Items.FindByText(dt.Rows[0]["Degree2"].ToString()).Selected = true;
                        }
                        txtOtherMajor.Text = dt.Rows[0]["Other Major"].ToString();
                        if (ddlEngListening.Items.FindByText(dt.Rows[0]["English Listening"].ToString()) != null)
                        {
                            ddlEngListening.ClearSelection();
                            ddlEngListening.Items.FindByText(dt.Rows[0]["English Listening"].ToString()).Selected = true;
                        }
                        if (ddlEngSpeaking.Items.FindByText(dt.Rows[0]["English Speaking"].ToString()) != null)
                        {
                            ddlEngSpeaking.ClearSelection();
                            ddlEngSpeaking.Items.FindByText(dt.Rows[0]["English Speaking"].ToString()).Selected = true;
                        }
                        if (ddlJapListening.Items.FindByText(dt.Rows[0]["Japanese Listening"].ToString()) != null)
                        {
                            ddlJapListening.ClearSelection();
                            ddlJapListening.Items.FindByText(dt.Rows[0]["Japanese Listening"].ToString()).Selected = true;
                        }
                        if (ddlJapSpeaking.Items.FindByText(dt.Rows[0]["Japanese Speaking"].ToString()) != null)
                        {
                            ddlJapSpeaking.ClearSelection();
                            ddlJapSpeaking.Items.FindByText(dt.Rows[0]["Japanese Speaking"].ToString()).Selected = true;
                        }
                        if (ddlMnListening.Items.FindByText(dt.Rows[0]["Burmese Listening"].ToString()) != null)
                        {
                            ddlMnListening.ClearSelection();
                            ddlMnListening.Items.FindByText(dt.Rows[0]["Burmese Listening"].ToString()).Selected = true;
                        }
                        if (ddlMnSpeaking.Items.FindByText(dt.Rows[0]["Burmese Speaking"].ToString()) != null)
                        {
                            ddlMnSpeaking.ClearSelection();
                            ddlMnSpeaking.Items.FindByText(dt.Rows[0]["Burmese Speaking"].ToString()).Selected = true;
                        }
                        Career_WorkingPlaceBL cwpbl = new Career_WorkingPlaceBL();
                        dt.Clear();
                        dt = cwpbl.SelectByID(BaseLib.Convert_Int(hfCareerID.Value));

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (chkWorkableArea.Items.FindByText(dt.Rows[i]["WorkingPlace"].ToString()) != null)
                            {
                                chkWorkableArea.Items.FindByText(dt.Rows[i]["WorkingPlace"].ToString()).Selected = true;
                            }
                        }
                        Qualification_SelectedByID(BaseLib.Convert_Int(hfCareerID.Value));
                        Ability_SelectedByID(BaseLib.Convert_Int(hfCareerID.Value));
                        Career_PCSkillsBL cpbl = new Career_PCSkillsBL();
                        dt.Clear();
                        dt = cpbl.SelectByID(BaseLib.Convert_Int(hfCareerID.Value));

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (chkPcSkill.Items.FindByText(dt.Rows[i]["PCSkills"].ToString()) != null)
                            {
                                chkPcSkill.Items.FindByText(dt.Rows[i]["PCSkills"].ToString()).Selected = true;
                            }
                        }
                        #region bindWorkingHistory
                        Working_History_BL workinghistorybl = new Working_History_BL();
                        DataTable dtoldjob = rbl.SelectedByWorkingHistoryForCareer_Resume(BaseLib.Convert_Int(hfCareerID.Value));
                        DataTable dtjobdescripition = new DataTable();
                        dtoldjob.Columns.Add("Job_Description", typeof(string));
                        if (dtoldjob.Rows.Count > 0)
                        {
                            lblWorkingHistory.Text = "Working History <hr/>"; // FOr Title 
                        }
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
                        #endregion
                        if (dtsalary.Rows.Count > 0 && dtsalary != null)
                        {
                            int rowindex = 0;
                            if (dtsalary.Rows.Count > 0)
                            {
                                gvsalary.DataSource = dtsalary;
                                gvsalary.DataBind();
                                foreach (GridViewRow row in gvsalary.Rows)
                                {
                                    TextBox box1 = (TextBox)row.Cells[0].FindControl("txtExpSalary1");
                                    DropDownList ddlsalarytype1 = (DropDownList)row.Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                                    DropDownList ddlsalaryformat = (DropDownList)row.Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                                    CheckBox chksalary = (CheckBox)row.Cells[0].FindControl("chkselectsalary") as CheckBox;
                                    Label lbl4 = (Label)row.Cells[0].FindControl("lblsalary1");
                                    box1.Text = dtsalary.Rows[rowindex]["Salary"].ToString();
                                    if (!String.IsNullOrWhiteSpace(dtsalary.Rows[rowindex]["Salary_TypeTex"].ToString()))
                                    {
                                        ddlsalarytype1.ClearSelection();
                                        ddlsalarytype1.Items.FindByText(dtsalary.Rows[rowindex]["Salary_TypeTex"].ToString()).Selected = true;
                                    }
                                    if (dtsalary.Rows[rowindex]["Salary_Status"].ToString() == "True")
                                    {
                                        chksalary.Checked = true;
                                    }
                                    else
                                    {
                                        chksalary.Checked = false;
                                    }
                                    if (!string.IsNullOrWhiteSpace(dtsalary.Rows[rowindex]["Salary_Format"].ToString()))
                                        ddlsalaryformat.Items.FindByValue(dtsalary.Rows[rowindex]["Salary_Format"].ToString()).Selected = true;
                                    else
                                        ddlsalaryformat.Items.FindByValue("0").Selected = true;
                                    rowindex++;
                                }
                                if (dtsalary.Rows.Count > 1)
                                {
                                    LinkButton LinkButton1 = gvsalary.HeaderRow.FindControl("LinkButton1") as LinkButton;
                                    LinkButton1.Visible = true;
                                }
                                ViewState["PreviousTable"] = dtsalary;
                            }
                        }
                    }
                }
                else
                {
                    btnSave.Text = "Save";
                    hfMode.Value = "Save";
                    btnDelete.Enabled = false;
                }
            }
        }

        protected void Qualification_SelectedByID(int careerid)
        {
            Career_QualificationBL cqbl = new Career_QualificationBL();
            DataTable dtbindqual = cqbl.SelectByID(careerid);
            int itemCount1 = 0;
            for (int i = 0; i < dtbindqual.Rows.Count; i++)
            {
                for (itemCount1 = 0; itemCount1 < outerDataList.Items.Count; itemCount1++)
                {
                    DataList childdl = outerDataList.Items[itemCount1].FindControl("innerDataList") as System.Web.UI.WebControls.DataList;
                    foreach (DataListItem dl in childdl.Items)
                    {
                        CheckBox chkQ = (CheckBox)dl.FindControl("chkQ");
                        if ((chkQ.Text).ToString() == dtbindqual.Rows[i]["Qualification"].ToString())
                        {
                            chkQ.Checked = true;
                        }
                    }
                }
            }
        }

        protected void Ability_SelectedByID(int careerid)
        {
            Career_AbilityBL cabl = new Career_AbilityBL();
            DataTable dtbindqual = cabl.SelectByID(careerid);
            int itemCount1 = 0;
            for (int i = 0; i < dtbindqual.Rows.Count; i++)
            {
                for (itemCount1 = 0; itemCount1 < outerDataList1.Items.Count; itemCount1++)
                {
                    DataList childdl1 = outerDataList1.Items[itemCount1].FindControl("innerDataList1") as System.Web.UI.WebControls.DataList;
                    foreach (DataListItem dl in childdl1.Items)
                    {
                        CheckBox chkAbl = (CheckBox)dl.FindControl("chkAbl");
                        if ((chkAbl.Text).ToString() == dtbindqual.Rows[i]["Ability"].ToString())
                        {
                            chkAbl.Checked = true;
                        }
                    }
                }
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
            if (!string.IsNullOrWhiteSpace(lnkPhoto.Text))
            {
                btnPhoto.Visible = status;
                imgPhoto.Visible = status;
                uplPhotoData.ForeColor = Color.White;
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
            if (!string.IsNullOrWhiteSpace(lnkLabourCard.Text))
            {
                btnLabourCard.Visible = status;
                imgLabourCard.Visible = status;
                uplLabourCard.ForeColor = Color.White;
            }
        }

        protected void FillData1()
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
                    careerInformationInfo.Photo_Data = dtCareerInformation.Rows[0]["Photo"].ToString();
                    careerInformationInfo.Datasheet_Data = dtCareerInformation.Rows[0]["Datasheet_Data"].ToString();
                    careerInformationInfo.IDCard_Data = dtCareerInformation.Rows[0]["IDCard_Data"].ToString();
                    careerInformationInfo.Credential_Data = dtCareerInformation.Rows[0]["Credential_Data"].ToString();
                    careerInformationInfo.Japanese_Data = dtCareerInformation.Rows[0]["Japanese_Data"].ToString();
                    careerInformationInfo.Graduation_Data = dtCareerInformation.Rows[0]["Graduation_Data"].ToString();
                    careerInformationInfo.Qualification_Data = dtCareerInformation.Rows[0]["Qualification_Data"].ToString();
                    careerInformationInfo.LabourCard_Data = dtCareerInformation.Rows[0]["LabourCard_Data"].ToString();
                    careerInformationInfo.IsDeleted = (bool)dtCareerInformation.Rows[0]["IsDeleted"];
                    lblUpdatedBy.Text = careerInformationInfo.Updater;
                    lblUpdatedDate.Text = careerInformationInfo.UpdateTime;
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Photo_Data))
                    {
                        uplPhotoData.ForeColor = Color.White;
                        lnkPhoto.Text = careerInformationInfo.Photo_Data;
                        imgPhoto.ImageUrl = Photo_DataPath + lnkPhoto.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Datasheet_Data))
                    {
                        lnkDatasheetData.Text = careerInformationInfo.Datasheet_Data;
                        imgDatasheetData.ImageUrl = Datasheet_DataPath + lnkDatasheetData.Text;
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
                    if (!String.IsNullOrWhiteSpace(careerInformationInfo.Graduation_Data))
                    {
                        lnkGraduationData.Text = careerInformationInfo.Graduation_Data;
                        imgGraduationData.ImageUrl = Graduation_DataPath + lnkGraduationData.Text;
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

        public void FillInstitutionArea()
        {
            int index = BaseLib.Convert_Int(ddlUniversityName.SelectedValue);
            DataTable dt = new DataTable();
            Working_History_BL webbl = new Working_History_BL();
            dt = webbl.SelectedbyUniversityID(index);
            ddlUniversityArea.DataSource = dt;
            ddlUniversityArea.DataTextField = "AreaDescription";
            ddlUniversityArea.DataValueField = "AreaID";
            ddlUniversityArea.DataBind();
            ddlUniversityArea.Focus();

            int index2 = BaseLib.Convert_Int(ddlUniversityName2.SelectedValue);
            DataTable dt2 = new DataTable();
            dt2 = webbl.SelectedbyUniversityID(index2);
            ddlUniversityArea2.DataSource = dt2;
            ddlUniversityArea2.DataTextField = "AreaDescription";
            ddlUniversityArea2.DataValueField = "AreaID";
            ddlUniversityArea2.DataBind();
            ddlUniversityArea2.Focus();
        }

        protected void IntvQ3SelectedByID(int id)
        {
            try
            {
                CareerInvQuestion3 = new Career_InterviewQuestion3BL();
                CareerInfo = new Career_Interview_Question3Entity();
                DataTable dt = CareerInvQuestion3.SelectByID(id);
                foreach (GridViewRow row in gvCustomers.Rows)
                {
                    customerId = gvCustomers.DataKeys[row.RowIndex].Value.ToString();
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        GridView ChldGrid = (GridView)row.FindControl("gvOrders");
                        BindOrders(customerId, ChldGrid);
                        foreach (GridViewRow row2 in ChldGrid.Rows)
                        {
                            Label Id = row2.FindControl("lblInterviewQ3ID") as Label;
                            CheckBox chkBox = row2.FindControl("chk") as CheckBox;
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Id.Text == dr["Interview_Question3_ID"].ToString())
                                {
                                    chkBox.Checked = true;
                                }
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

        private void BindOrders(string customerId, GridView gvOrders)
        {
            gvOrders.ToolTip = customerId;
            gvOrders.DataSource = GetData(string.Format("SELECT ID,Description,InterviewQuestionTitleID From Interview_Question3  where InterviewQuestionTitleID ='{0}'", customerId));
            gvOrders.DataBind();
        }

        protected void GetComment(int id)
        {
            try
            {
                CareerInvQuestion3 = new Career_InterviewQuestion3BL();
                MJInfo = new Career_InterView3Entity();
                MJInfo = CareerInvQuestion3.CommentSelectByID(id);
                lblUpdatedBy.Text = MJInfo.Updater;
                lblUpdatedDate.Text = MJInfo.UpdatedDate.ToString();
                txtMCommentdisadvantage.Text = MJInfo.Myanmar_Interviewer_Comment_Disadvantage;
                txtJCommentAdvantages.Text = MJInfo.Japense_Interviewer_Comment;
                txtJCommentDisadvantage.Text = MJInfo.Japanese_Interviewerr_Comment_Disadvantage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Qualification()
        {
            Working_History_BL webbl = new Working_History_BL();
            DataSet dsdata = new DataSet();
            dsdata = webbl.BindDataForQualification();
            dsdata.Relations.Add(new DataRelation("Qualification_Relation", dsdata.Tables[0].Columns["ID"], dsdata.Tables[1].Columns["QualificationTitle_id"], false));
            outerDataList.DataSource = dsdata.Tables[0];
            outerDataList.DataBind();
        }

        public void Ability()
        {
            Working_History_BL webbl = new Working_History_BL();
            DataSet dsdata = new DataSet();
            dsdata = webbl.BindDataForAbility();
            dsdata.Relations.Add(new DataRelation("Ability_Relation", dsdata.Tables[0].Columns["ID"], dsdata.Tables[1].Columns["AbilityTitle_id"], false));
            outerDataList1.DataSource = dsdata.Tables[0];
            outerDataList1.DataBind();
        }

        public void FillData()
        {
            try
            {
                GlobalBL gb = new GlobalBL();
                ddlPositionLevel1.DataSource = gb.Get_Data("Position_Level");
                ddlPositionLevel1.DataTextField = "Description";
                ddlPositionLevel1.DataValueField = "ID";
                ddlPositionLevel1.DataBind();
                ddlPositionLevel1.ClearSelection();
                ddlPositionLevel1.Items.Insert(0, "");
                ddlPositionLevel1.Text = "";

                ddlPositionLevel2.DataSource = gb.Get_Data("Position_Level");
                ddlPositionLevel2.DataTextField = "Description";
                ddlPositionLevel2.DataValueField = "ID";
                ddlPositionLevel2.DataBind();
                ddlPositionLevel2.ClearSelection();
                ddlPositionLevel2.Items.Insert(0, "");
                ddlPositionLevel2.Text = "";

                ddlPositionLevel3.DataSource = gb.Get_Data("Position_Level");
                ddlPositionLevel3.DataTextField = "Description";
                ddlPositionLevel3.DataValueField = "ID";
                ddlPositionLevel3.DataBind();
                ddlPositionLevel3.ClearSelection();
                ddlPositionLevel3.Items.Insert(0, "");
                ddlPositionLevel3.Text = "";

                ddlReligion.DataSource = gb.Get_Data("Religion");
                ddlReligion.DataTextField = "Description";
                ddlReligion.DataValueField = "ID";
                ddlReligion.DataBind();
                ddlReligion.ClearSelection();
                ddlReligion.Items.Insert(0, "");
                ddlReligion.Text = "";

                ddlAddress.DataSource = gb.Get_Data("Residential_Area");
                ddlAddress.DataTextField = "Description";
                ddlAddress.DataValueField = "ID";
                ddlAddress.DataBind();
                ddlAddress.ClearSelection();
                ddlAddress.Items.Insert(0, "");
                ddlAddress.Text = "";

                Working_PlaceBL wpbl = new Working_PlaceBL();
                chkWorkableArea.DataSource = wpbl.SelectAll(3);
                chkWorkableArea.DataTextField = "Description";
                chkWorkableArea.DataValueField = "ID";
                chkWorkableArea.DataBind();
                chkWorkableArea.ClearSelection();

                ddlDivision1.DataSource = gb.Get_Data("Department");
                ddlDivision1.DataTextField = "Description";
                ddlDivision1.DataValueField = "ID";
                ddlDivision1.DataBind();
                ddlDivision1.ClearSelection();
                ddlDivision1.Items.Insert(0, "");
                ddlDivision1.Text = "";

                ddlDivision2.DataSource = gb.Get_Data("Department");
                ddlDivision2.DataTextField = "Description";
                ddlDivision2.DataValueField = "ID";
                ddlDivision2.DataBind();
                ddlDivision2.ClearSelection();
                ddlDivision2.Items.Insert(0, "");
                ddlDivision2.Text = "";

                ddlDivision3.DataSource = gb.Get_Data("Department");
                ddlDivision3.DataTextField = "Description";
                ddlDivision3.DataValueField = "ID";
                ddlDivision3.DataBind();
                ddlDivision3.ClearSelection();
                ddlDivision3.Items.Insert(0, "");
                ddlDivision3.Text = "";

                ddlCurrentCareerCondition.DataSource = gb.Get_Data("Situation");
                ddlCurrentCareerCondition.DataTextField = "Description";
                ddlCurrentCareerCondition.DataValueField = "ID";
                ddlCurrentCareerCondition.DataBind();
                ddlCurrentCareerCondition.ClearSelection();
                ddlCurrentCareerCondition.Items.Insert(0, "");
                ddlCurrentCareerCondition.Text = "";

                ddlEduBackground.DataSource = gb.Get_Data("Education");
                ddlEduBackground.DataTextField = "Description";
                ddlEduBackground.DataValueField = "ID";
                ddlEduBackground.DataBind();
                ddlEduBackground.ClearSelection();
                ddlEduBackground.Items.Insert(0, "");
                ddlEduBackground.Text = "";

                ddlCareerStatus.DataSource = gb.Get_Data("Career_Status");
                ddlCareerStatus.DataTextField = "Career_Status";
                ddlCareerStatus.DataValueField = "Career_Status_ID";
                ddlCareerStatus.DataBind();
                ddlCareerStatus.ClearSelection();
                ddlCareerStatus.Items.Insert(0, "");
                ddlCareerStatus.Text = "";

                ddldegree.DataSource = gb.Get_Data("Degree_Type");
                ddldegree.DataTextField = "Description";
                ddldegree.DataValueField = "Degree_ID";
                ddldegree.DataBind();
                ddldegree.ClearSelection();
                ddldegree.Items.Insert(0, "");
                ddldegree.Text = "";

                ddldegree2.DataSource = gb.Get_Data("Degree_Type");
                ddldegree2.DataTextField = "Description";
                ddldegree2.DataValueField = "Degree_ID";
                ddldegree2.DataBind();
                ddldegree2.ClearSelection();
                ddldegree2.Items.Insert(0, "");
                ddldegree2.Text = "";

                ddlUniversityName.DataSource = gb.Get_Data("Institution");
                ddlUniversityName.DataTextField = "Description";
                ddlUniversityName.DataValueField = "ID";
                ddlUniversityName.DataBind();
                ddlUniversityName.ClearSelection();
                ddlUniversityName.Items.Insert(0, "");
                ddlUniversityName.Text = "";

                ddlUniversityName2.DataSource = gb.Get_Data("Institution");
                ddlUniversityName2.DataTextField = "Description";
                ddlUniversityName2.DataValueField = "ID";
                ddlUniversityName2.DataBind();
                ddlUniversityName2.ClearSelection();
                ddlUniversityName2.Items.Insert(0, "");
                ddlUniversityName2.Text = "";

                ddlMajor.DataSource = gb.Get_Data("Major");
                ddlMajor.DataTextField = "Description";
                ddlMajor.DataValueField = "ID";
                ddlMajor.DataBind();
                ddlMajor.ClearSelection();
                ddlMajor.Items.Insert(0, "");
                ddlMajor.Text = "";

                ddlMajor2.DataSource = gb.Get_Data("Major");
                ddlMajor2.DataTextField = "Description";
                ddlMajor2.DataValueField = "ID";
                ddlMajor2.DataBind();
                ddlMajor2.ClearSelection();
                ddlMajor2.Items.Insert(0, "");
                ddlMajor2.Text = "";
                Qualification();
                Ability();

                chkPcSkill.DataSource = gb.Get_Data("PC_Skill");
                chkPcSkill.DataTextField = "Description";
                chkPcSkill.DataValueField = "ID";
                chkPcSkill.DataBind();
                chkPcSkill.ClearSelection();

                ddlEngListening.DataSource = gb.Get_Data("Language_Level");
                ddlEngListening.DataTextField = "Description";
                ddlEngListening.DataValueField = "ID";
                ddlEngListening.DataBind();
                ddlEngListening.ClearSelection();
                ddlEngListening.Items.Insert(0, "");
                ddlEngListening.Text = "";

                ddlEngSpeaking.DataSource = gb.Get_Data("Language_Level");
                ddlEngSpeaking.DataTextField = "Description";
                ddlEngSpeaking.DataValueField = "ID";
                ddlEngSpeaking.DataBind();
                ddlEngSpeaking.ClearSelection();
                ddlEngSpeaking.Items.Insert(0, "");
                ddlEngSpeaking.Text = "";

                ddlJapListening.DataSource = gb.Get_Data("Language_Level");
                ddlJapListening.DataTextField = "Description";
                ddlJapListening.DataValueField = "ID";
                ddlJapListening.DataBind();
                ddlJapListening.ClearSelection();
                ddlJapListening.Items.Insert(0, "");
                ddlJapListening.Text = "";

                ddlJapSpeaking.DataSource = gb.Get_Data("Language_Level");
                ddlJapSpeaking.DataTextField = "Description";
                ddlJapSpeaking.DataValueField = "ID";
                ddlJapSpeaking.DataBind();
                ddlJapSpeaking.ClearSelection();
                ddlJapSpeaking.Items.Insert(0, "");
                ddlJapSpeaking.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void clearData()
        {
            ddlCode.SelectedIndex = 1;
            txtCode.Text = String.Empty;
            ddlGender.SelectedIndex = 0;
            txtName.Text = String.Empty;
            txtAge.Text = string.Empty;
            ddlReligion.SelectedIndex = 0;
            ddlAddress.SelectedIndex = 0;
            chkWorkableArea.ClearSelection();
            ddlDivision1.SelectedIndex = 0;
            ddlDivision2.SelectedIndex = 0;
            ddlDivision3.SelectedIndex = 0;
            ddlPosition1.Items.Clear();
            ddlPosition2.Items.Clear();
            ddlPosition3.Items.Clear();
            ddlPositionLevel1.Items.Clear();
            ddlPositionLevel2.Items.Clear();
            ddlPositionLevel3.Items.Clear();
            ddlCurrentCareerCondition.SelectedIndex = 0;
            ddlEduBackground.SelectedIndex = 0;
            ddldegree.SelectedIndex = 0;
            ddldegree2.SelectedIndex = 0;
            ddlUniversityName2.SelectedIndex = 0;
            ddlUniversityName.SelectedIndex = 0;
            ddlUniversityArea.SelectedIndex = 0;
            ddlUniversityArea2.SelectedIndex = 0;
            txtYear.Text = String.Empty;
            txtYear2.Text = String.Empty;
            ddlMajor.SelectedIndex = 0;
            ddlMajor2.SelectedIndex = 0;
            txtOtherMajor.Text = String.Empty;
            chkPcSkill.ClearSelection();
            ddlEngListening.SelectedIndex = 0;
            ddlEngSpeaking.SelectedIndex = 0;
            ddlJapListening.SelectedIndex = 0;
            ddlJapSpeaking.SelectedIndex = 0;
            ddlMnListening.SelectedIndex = 0;
            ddlMnSpeaking.SelectedIndex = 0;
            btnSave.Text = "Save";
            hfMode.Value = "Save";
        }

        protected void outerRep_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Qualification_Relation");
                innerDataList.DataBind();
            }
        }

        protected void outerRep_ItemDataBound1(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList1") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Ability_Relation");
                innerDataList.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    cre = new Career_ResumeEntity();
                    MJInfo = new Career_InterView3Entity();
                    cre.ID = BaseLib.Convert_Int(hfCareerID.Value);
                    cre.Career_ID = cre.ID;
                    cre.Career_Code = ddlCode.Text + "-" + txtCode.Text;
                    if (!String.IsNullOrWhiteSpace(ddlGender.Text))
                        cre.GenderID = BaseLib.Convert_Int(ddlGender.Text);
                    cre.Name = txtName.Text;
                    cre.Age = BaseLib.Convert_Int(txtAge.Text);
                    cre.Impressionjp = txtimpressionjp.Text;
                    if (!string.IsNullOrWhiteSpace(Request.Form[txtDateofBirth.UniqueID]))
                    {
                        string strDate = Request.Form[txtDateofBirth.UniqueID];
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "MM-yyyy";
                        dtfi.DateSeparator = "-";
                        DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                        string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("dd-MM-yyyy");
                        cre.DOB = DateTime.ParseExact(date, "dd-MM-yyyy", null);
                    }
                    DateTime now = DateTime.Today;
                    DateTime dob = Convert.ToDateTime(cre.DOB);
                    cre.Age = now.Year - dob.Year;
                    if (!string.IsNullOrWhiteSpace(Request.Form[txtGraduationDate.UniqueID]))
                    {
                        string strGraduationDate = Request.Form[txtGraduationDate.UniqueID];
                        DateTimeFormatInfo dtgd = new DateTimeFormatInfo();
                        dtgd.YearMonthPattern = "Month-Year";
                        dtgd.DateSeparator = "-";
                        DateTime objDate = Convert.ToDateTime(strGraduationDate, dtgd);
                        cre.Graduation_Date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MMM-yyyy");
                    }
                    else cre.Graduation_Date = "";
                    if (!String.IsNullOrWhiteSpace(ddlReligion.Text))
                        cre.Religion_ID = BaseLib.Convert_Int(ddlReligion.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlAddress.Text))
                        cre.Residential_AreaID = BaseLib.Convert_Int(ddlAddress.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(txtph1.Text))
                        cre.Phone_No1 = txtph1.Text;
                    if (!String.IsNullOrWhiteSpace(txtph2.Text))
                        cre.Phone_No2 = txtph2.Text;
                    if (!String.IsNullOrWhiteSpace(txtemail.Text))
                        cre.Email = txtemail.Text;
                    if (!String.IsNullOrWhiteSpace(txtemph.Text))
                        cre.Emergency_ContactNo = txtemph.Text;
                    if (!String.IsNullOrWhiteSpace(txtemperson.Text))
                        cre.Emergency_ContactName = txtemperson.Text;
                    if (!String.IsNullOrWhiteSpace(ddlCareerStatus.Text))
                        cre.Requested_CareerStatus_ID = BaseLib.Convert_Int(ddlCareerStatus.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlDivision1.Text))
                        cre.Requested_Division1_ID = BaseLib.Convert_Int(ddlDivision1.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlPosition1.Text))
                        cre.Requested_Position1_ID = BaseLib.Convert_Int(ddlPosition1.SelectedValue);
                    //ssw
                    if (!String.IsNullOrWhiteSpace(ddlPositionLevel1.Text))
                        cre.Requested_PositionLevel1_ID = BaseLib.Convert_Int(ddlPositionLevel1.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlDivision2.Text))
                        cre.Requested_Division2_ID = BaseLib.Convert_Int(ddlDivision2.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlPosition2.Text))
                        cre.Requested_Position2_ID = BaseLib.Convert_Int(ddlPosition2.SelectedValue);
                    //ssw
                    if (!String.IsNullOrWhiteSpace(ddlPositionLevel2.Text))
                        cre.Requested_PositionLevel2_ID = BaseLib.Convert_Int(ddlPositionLevel2.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlDivision3.Text))
                        cre.Requested_Division3_ID = BaseLib.Convert_Int(ddlDivision3.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlPosition3.Text))
                        cre.Requested_Position3_ID = BaseLib.Convert_Int(ddlPosition3.SelectedValue);
                    //ssw
                    if (!String.IsNullOrWhiteSpace(ddlPositionLevel3.Text))
                        cre.Requested_PositionLevel3_ID = BaseLib.Convert_Int(ddlPositionLevel3.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlCurrentCareerCondition.Text))
                        cre.SituationID = BaseLib.Convert_Int(ddlCurrentCareerCondition.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlEduBackground.Text))
                        cre.Education_ID = BaseLib.Convert_Int(ddlEduBackground.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlUniversityName.Text))
                        cre.InstitutionName_ID = BaseLib.Convert_Int(ddlUniversityName.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlUniversityName2.Text))
                        cre.InstitutionName_ID2 = BaseLib.Convert_Int(ddlUniversityName2.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlUniversityArea.Text))
                        cre.InstitutionArea_ID = BaseLib.Convert_Int(ddlUniversityArea.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlUniversityArea2.Text))
                        cre.InstitutionArea_ID2 = BaseLib.Convert_Int(ddlUniversityArea2.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(txtYear.Text))
                        cre.Year = txtYear.Text;
                    if (!String.IsNullOrWhiteSpace(txtYear2.Text))
                        cre.Year2 = txtYear2.Text;
                    if (!String.IsNullOrWhiteSpace(ddlUniversityName2.Text))
                        cre.InstitutionName_ID2 = BaseLib.Convert_Int(ddlUniversityName2.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddldegree.Text))
                        cre.Degree = BaseLib.Convert_Int(ddldegree.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddldegree2.Text))
                        cre.Degree2 = BaseLib.Convert_Int(ddldegree2.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlMajor.Text))
                        cre.Major_ID = BaseLib.Convert_Int(ddlMajor.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlMajor2.Text))
                        cre.Major_ID2 = BaseLib.Convert_Int(ddlMajor2.SelectedValue);
                    cre.Other_Major = txtOtherMajor.Text;
                    Career_WorkingPlaceEntity cwpe = new Career_WorkingPlaceEntity();
                    int row = 0;
                    foreach (ListItem item in chkWorkableArea.Items)
                    {
                        if (item.Selected)
                        {
                            cwpe.WorkingPlace.Rows.Add();
                            cwpe.WorkingPlace.Rows[row]["Career_ID"] = BaseLib.Convert_Int(hfCareerID.Value);
                            cwpe.WorkingPlace.Rows[row]["WorkingPlace_ID"] = item.Value;
                            row++;
                        }
                    }
                    Career_QualificationEntity cq = new Career_QualificationEntity();
                    int itemCount1 = 0;
                    row = 0;
                    for (itemCount1 = 0; itemCount1 < outerDataList.Items.Count; itemCount1++)
                    {
                        DataList childdl = outerDataList.Items[itemCount1].FindControl("innerDataList") as System.Web.UI.WebControls.DataList;
                        foreach (DataListItem dl in childdl.Items)
                        {
                            CheckBox chkQ = (CheckBox)dl.FindControl("chkQ");
                            Label lblQ_id = (Label)dl.FindControl("lblQ_id");

                            if (chkQ.Checked)
                            {
                                cq.Qualification.Rows.Add();
                                cq.Qualification.Rows[row]["Qualification_ID"] = Int32.Parse(lblQ_id.Text);
                                row++;
                            }
                        }
                    }
                    //Career_Ability
                    Career_AbilityEntity cae = new Career_AbilityEntity();
                    int itemCount = 0;
                    row = 0;
                    for (itemCount = 0; itemCount < outerDataList1.Items.Count; itemCount++)
                    {
                        DataList childdl = outerDataList1.Items[itemCount].FindControl("innerDataList1") as System.Web.UI.WebControls.DataList;
                        foreach (DataListItem dl in childdl.Items)
                        {
                            CheckBox chkAbl = (CheckBox)dl.FindControl("chkAbl");
                            Label lblAbl_id = (Label)dl.FindControl("lblAbl_id");

                            if (chkAbl.Checked)
                            {
                                cae.Ability.Rows.Add();
                                cae.Ability.Rows[row]["Ability_ID"] = Int32.Parse(lblAbl_id.Text);
                                row++;
                            }
                        }
                    }
                    Career_PCSkillsEntity cpe = new Career_PCSkillsEntity();
                    row = 0;
                    foreach (ListItem item in chkPcSkill.Items)
                    {
                        if (item.Selected)
                        {
                            cpe.PcSkills.Rows.Add();
                            cpe.PcSkills.Rows[row]["Career_ID"] = BaseLib.Convert_Int(hfCareerID.Value);
                            cpe.PcSkills.Rows[row]["PCSkill_ID"] = item.Value;
                            row++;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(ddlEngListening.Text))
                        cre.English_RW_LevelID = BaseLib.Convert_Int(ddlEngListening.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlEngSpeaking.Text))
                        cre.English_Speaking_LevelID = BaseLib.Convert_Int(ddlEngSpeaking.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlJapListening.Text))
                        cre.Japanese_RW_LevelID = BaseLib.Convert_Int(ddlJapListening.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlJapSpeaking.Text))
                        cre.Japanese_Speaking_LevelID = BaseLib.Convert_Int(ddlJapSpeaking.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlMnListening.Text))
                        cre.Myanmar_RW_LevelID = BaseLib.Convert_Int(ddlMnListening.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ddlMnSpeaking.Text))
                        cre.Myanmar_Speaking_LevelID = BaseLib.Convert_Int(ddlMnSpeaking.SelectedValue);
                    if (chkdomestic.Checked)
                    {
                        cre.Domestic = 1;
                    }
                    if (chkoversea.Checked)
                    {
                        cre.Oversea = 1;
                    }
                    #region WorkingHIstoyr //Insert data into DataTable For Working History
                    CreateForWorkingHistory();
                    DataTable dttext = (DataTable)ViewState["WorkingHistory"];
                    DataRow drtext = null;
                    foreach (DataListItem items in datalistsalary.Items)
                    {
                        Label lblcompany = items.FindControl("lblcompnayname") as Label;
                        Label lblindustrytype = items.FindControl("lblindustrytypeID") as Label;
                        Label lblcompanyaddress = items.FindControl("lblcompanyaddress") as Label;
                        Label lbldepartment = items.FindControl("lbldepartmentID") as Label;
                        Label lbltypeofbusiness = items.FindControl("lblbusinesstypeID") as Label;
                        Label lbldurationfrom = items.FindControl("lbldurationfrom") as Label;
                        Label lbldurationto = items.FindControl("lbldurationto") as Label;
                        Label lblposition = items.FindControl("lblpositionID") as Label;
                        Label lblpositionlevel = items.FindControl("lblpositionlevelID") as Label;
                        Label lbljobdescxription = items.FindControl("lbljobdescripitionID") as Label;
                        Label lblothereng = items.FindControl("lblother") as Label;
                        Label lblreasongleavingeng = items.FindControl("lblreason") as Label;
                        TextBox text1 = items.FindControl("txtotherjp") as TextBox;
                        TextBox text2 = items.FindControl("txtreasongfroleavingjp") as TextBox;
                        drtext = dttext.NewRow();
                        drtext["companyname"] = lblcompany.Text;
                        drtext["companyaddress"] = lblcompanyaddress.Text;
                        drtext["fromdate"] = lbldurationfrom.Text;
                        drtext["todate"] = lbldurationto.Text;
                        drtext["jobdescripition"] = lbljobdescxription.Text;
                        drtext["reasonjp"] = text2.Text;
                        drtext["industry"] = lblindustrytype.Text;
                        drtext["business"] = lbltypeofbusiness.Text;
                        drtext["deparment"] = lbldepartment.Text;
                        drtext["position"] = lblposition.Text;
                        drtext["otherjp"] = text1.Text;
                        drtext["positionlevel"] = lblpositionlevel.Text;
                        drtext["othereng"] = lblothereng.Text;
                        drtext["reasoneng"] = lblreasongleavingeng.Text;
                        dttext.Rows.Add(drtext);
                    }
                    #endregion
                    #region Salarly
                    CreatenewDataTable();
                    DataTable dtnew = (DataTable)ViewState["DataTablenew"];
                    DataRow dr = null;
                    foreach (GridViewRow gvrow in gvsalary.Rows)
                    {
                        TextBox box1 = gvrow.FindControl("txtExpSalary1") as TextBox;
                        DropDownList ddlsalarytype1 = gvrow.FindControl("ddlsalarytype1") as DropDownList;
                        DropDownList ddlsalaryformat = gvrow.FindControl("ddlsalaryformat") as DropDownList;
                        CheckBox chksalary = gvrow.FindControl("chkselectsalary") as CheckBox;
                        Label lbl4 = gvrow.FindControl("lblsalary1") as Label;
                        dr = dtnew.NewRow();
                        dr["Salary"] = box1.Text;
                        dr["SalaryType1"] = ddlsalarytype1.SelectedValue;
                        dr["SalaryFormat"] = ddlsalaryformat.SelectedValue;
                        dr["SelectSalary"] = chksalary.Checked;
                        if (!String.IsNullOrWhiteSpace(box1.Text)) // not insert  database into salary o 
                        {
                            dtnew.Rows.Add(dr);
                        }
                    }
                    for (int i = 0; i < dtnew.Rows.Count; i++)
                    {
                        if (String.IsNullOrWhiteSpace(dtnew.Rows[i]["Salary"].ToString()) && String.IsNullOrWhiteSpace(dtnew.Rows[i]["SalaryType1"].ToString()))
                        {
                            dtnew.Rows[i].Delete();
                        }
                        dtnew.AcceptChanges();
                    }
                    #endregion
                    Career_ResumeBL rbl = new Career_ResumeBL();
                    if (hfMode.Value == "Save")
                    {
                        CreatedDateTime();
                        UpdatedDateTime();
                        cre.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        cre.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                        hfCareerID.Value = rbl.Insert_Update(cre, cq, cae, cpe, cwpe, EnumBase.Save.Insert, dtnew, dttext).ToString();
                        int careerid = Convert.ToInt32(hfCareerID.Value);
                        rbl.Insert_Career_Status(careerid, cre.Requested_CareerStatus_ID);
                        if (BaseLib.Convert_Int(hfCareerID.Value) > 0)
                        {
                            //Career_InterviewControl2.CarEmploymentlink = true;
                            //Career_InterviewControl2.CarInterview1link = true;
                            //Career_InterviewControl2.CarInterview2link = true;
                            //Career_InterviewControl2.CarInterview3link = true;
                            //Career_InterviewControl2.CarInformationlink = true;
                        }
                        else if (BaseLib.Convert_Int(hfCareerID.Value) == 0)
                        {
                            GlobalUI.MessageBox("Career Code Already Exists");
                        }
                        else
                        {
                            GlobalUI.MessageBox("Save failed!");
                        }
                    }

                    if (hfMode.Value == "Update")
                    {
                        UpdatedDateTime();
                        cre.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                        hfCareerID.Value = rbl.Insert_Update(cre, cq, cae, cpe, cwpe, EnumBase.Save.Update, dtnew, dttext).ToString();
                        int careerid = Convert.ToInt32(hfCareerID.Value);
                        rbl.Insert_Career_Status(careerid, cre.Requested_CareerStatus_ID);
                        if (BaseLib.Convert_Int(hfCareerID.Value) > 0)
                        {

                        }
                        else if (BaseLib.Convert_Int(hfCareerID.Value) == 0)
                        {
                            GlobalUI.MessageBox("Career Code Already Exists");
                        }
                        else
                        {
                            GlobalUI.MessageBox("Updated failed!");
                        }
                    }
                    if (txtJCommentAdvantages.Text.Length <= 400 && txtJCommentDisadvantage.Text.Length <= 400)
                    {
                        MJInfo = new Career_InterView3Entity();
                        int id = Convert.ToInt32(hfCareerID.Value);
                        IntvQuestion3Insert(id);
                        if (id != 0)
                        {
                            CreatedDateTime();
                            UpdatedDateTime();
                            SetComment(MJInfo, id);
                        }
                        else
                        {
                            CareerInvQuestion3.CommentUpdate(MJInfo);
                        }
                    }

                    careerInformation = new Career_InformationBL();
                    if (Request.QueryString["Career_ID"] != null)
                    {
                        DataTable dtCareerInfo = careerInformation.SelectByCareerID(Career_ID, 1);
                        if (dtCareerInfo != null && dtCareerInfo.Rows.Count > 0)
                        {
                            Update();
                        }
                        else
                        {
                            Save();
                        }
                    }
                    else
                    {
                        DataTable dtCareerInfo = careerInformation.SelectByCareerID(Convert.ToInt32(hfCareerID.Value), 1);
                        Save();
                    }
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
                        int Careerid = Convert.ToInt32(hfCareerID.Value);
                        object referrer = ViewState["UrlReferrer"];
                        string url = "Career_Resume_Detail.aspx?Career_ID=" + Careerid;
                        string script = "window.onload = function(){ alert('";
                        script += "Save Successfully";
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
                        object referrer = ViewState["UrlReferrer"];
                        string url = "Career_Resume_Detail.aspx?Career_ID=" + Career_ID;
                        string script = "window.onload = function(){ alert('";
                        script += "Update Successfully";
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
                    FillData1();
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

        private void SetCareerInformation(Career_InformationEntity careerInformationInfo)
        {
            try
            {
                careerInformation = new Career_InformationBL();
                string code = hfCareerCode.Value;
                DataTable dt = careerInformation.SelectByCareerID(Convert.ToInt32(hfCareerID.Value), 1);
                if (ID != 0)
                {
                    careerInformationInfo.ID = ID;
                }
                if (Career_ID != 0)
                {
                    careerInformationInfo.Career_ID = Convert.ToInt32(hfCareerID.Value);
                    if (dt.Rows.Count != 0)
                    {
                        careerInformationInfo.ID = (int)dt.Rows[0]["ID"];
                    }
                }
                careerInformationInfo.Career_ID = Convert.ToInt32(hfCareerID.Value);
                careerInformationInfo.Name = txtName.Text;
                careerInformationInfo.Age = int.Parse(txtAge.Text);
                careerInformationInfo.GenderID = int.Parse(ddlGender.SelectedValue.ToString());
                careerInformationInfo.Address = ddlAddress.SelectedItem.Text;
                careerInformationInfo.Photo_Data = lnkPhoto.Text;
                careerInformationInfo.Datasheet_Data = lnkDatasheetData.Text;
                careerInformationInfo.IDCard_Data = lnkCardData.Text;
                careerInformationInfo.Credential_Data = lnkCredentialData.Text;
                careerInformationInfo.Graduation_Data = lnkGraduationData.Text;
                careerInformationInfo.LabourCard_Data = lnkLabourCard.Text;
                if (uplPhotoData.HasFile && Request.QueryString["Career_ID"] == null)
                {
                    string File = uplPhotoData.FileName;
                    careerInformationInfo.Photo_Data = cre.Career_Code + "_" + File;
                    uplPhotoData.SaveAs(Server.MapPath(Photo_DataPath) + cre.Career_Code + "_" + File);
                    uplPhotoData.SaveAs(Server.MapPath(All_DataPath) + cre.Career_Code + "_" + File);
                    lnkPhoto.Text = cre.Career_Code + "_" + File;
                }
                if (uplPhotoData.HasFile && Request.QueryString["Career_ID"] != null)
                {
                    string File = uplPhotoData.FileName;
                    careerInformationInfo.Photo_Data = code + "_" + File;
                    uplPhotoData.SaveAs(Server.MapPath(Photo_DataPath) + code + "_" + File);
                    uplPhotoData.SaveAs(Server.MapPath(All_DataPath) + code + "_" + File);
                    lnkPhoto.Text = code + "_" + File;
                }
                if (uplDatasheetData.HasFile && Request.QueryString["Career_ID"] == null)
                {
                    string File = uplDatasheetData.FileName;
                    careerInformationInfo.Datasheet_Data = cre.Career_Code + "_" + File;
                    uplDatasheetData.SaveAs(Server.MapPath(Datasheet_DataPath) + cre.Career_Code + "_" + File);
                    uplDatasheetData.SaveAs(Server.MapPath(All_DataPath) + cre.Career_Code + "_" + File);
                    lnkDatasheetData.Text = cre.Career_Code + "_" + File;
                }
                if (uplDatasheetData.HasFile && Request.QueryString["Career_ID"] != null)
                {
                    string File = uplDatasheetData.FileName;
                    careerInformationInfo.Datasheet_Data = hfCareerCode.Value + "_" + File;
                    uplDatasheetData.SaveAs(Server.MapPath(Datasheet_DataPath) + code + "_" + File);
                    uplDatasheetData.SaveAs(Server.MapPath(All_DataPath) + code + "_" + File);
                    lnkDatasheetData.Text = code + "_" + File;
                }
                if (uplCardData.HasFile && Request.QueryString["Career_ID"] == null)
                {
                    string File = uplCardData.FileName;
                    careerInformationInfo.IDCard_Data = cre.Career_Code + "_" + File;
                    uplCardData.SaveAs(Server.MapPath(IDCard_DataPath) + cre.Career_Code + "_" + File);
                    uplCardData.SaveAs(Server.MapPath(All_DataPath) + cre.Career_Code + "_" + File);
                    lnkCardData.Text = cre.Career_Code + "_" + File;
                }
                if (uplCardData.HasFile && Request.QueryString["Career_ID"] != null)
                {
                    string File = uplCardData.FileName;
                    careerInformationInfo.IDCard_Data = code + "_" + File;
                    uplCardData.SaveAs(Server.MapPath(IDCard_DataPath) + code + "_" + File);
                    uplCardData.SaveAs(Server.MapPath(All_DataPath) + code + "_" + File);
                    lnkCardData.Text = code + "_" + File;
                }
                if (uplCredentialData.HasFile && Request.QueryString["Career_ID"] == null)
                {
                    string File = uplCredentialData.FileName;
                    careerInformationInfo.Credential_Data = cre.Career_Code + "_" + File;
                    uplCredentialData.SaveAs(Server.MapPath(Credential_DataPath) + cre.Career_Code + "_" + File);
                    uplCredentialData.SaveAs(Server.MapPath(All_DataPath) + cre.Career_Code + "_" + File);
                    lnkCredentialData.Text = cre.Career_Code + "_" + File;
                }
                if (uplCredentialData.HasFile && Request.QueryString["Career_ID"] != null)
                {
                    string File = uplCredentialData.FileName;
                    careerInformationInfo.Credential_Data = code + "_" + File;
                    uplCredentialData.SaveAs(Server.MapPath(Credential_DataPath) + code + "_" + File);
                    uplCredentialData.SaveAs(Server.MapPath(All_DataPath) + code + "_" + File);
                    lnkCredentialData.Text = code + "_" + File;
                }
                if (uplGraduationData.HasFile && Request.QueryString["Career_ID"] == null)
                {
                    string File = uplGraduationData.FileName;
                    careerInformationInfo.Graduation_Data = cre.Career_Code + "_" + File;
                    uplGraduationData.SaveAs(Server.MapPath(Graduation_DataPath) + cre.Career_Code + "_" + File);
                    uplGraduationData.SaveAs(Server.MapPath(All_DataPath) + cre.Career_Code + "_" + File);
                    lnkGraduationData.Text = cre.Career_Code + "_" + File;
                }
                if (uplGraduationData.HasFile && Request.QueryString["Career_ID"] != null)
                {
                    string File = uplGraduationData.FileName;
                    careerInformationInfo.Graduation_Data = code + "_" + File;
                    uplGraduationData.SaveAs(Server.MapPath(Graduation_DataPath) + code + "_" + File);
                    uplGraduationData.SaveAs(Server.MapPath(All_DataPath) + code + "_" + File);
                    lnkGraduationData.Text = code + "_" + File;
                }
                if (uplLabourCard.HasFile && Request.QueryString["Career_ID"] == null)
                {
                    string File = uplLabourCard.FileName;
                    careerInformationInfo.LabourCard_Data = cre.Career_Code + "_" + File;
                    uplLabourCard.SaveAs(Server.MapPath(LabourCard_DataPath) + cre.Career_Code + "_" + File);
                    uplLabourCard.SaveAs(Server.MapPath(All_DataPath) + cre.Career_Code + "_" + File);
                    lnkLabourCard.Text = cre.Career_Code + "_" + File;
                }
                if (uplLabourCard.HasFile && Request.QueryString["Career_ID"] != null)
                {
                    string File = uplLabourCard.FileName;
                    careerInformationInfo.LabourCard_Data = code + "_" + File;
                    uplLabourCard.SaveAs(Server.MapPath(LabourCard_DataPath) + code + "_" + File);
                    uplLabourCard.SaveAs(Server.MapPath(All_DataPath) + code + "_" + File);
                    lnkLabourCard.Text = code + "_" + File;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
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

        protected void ddlDivision1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddlDivision1.SelectedValue);

                DataTable dt = new DataTable();
                PositionBL pbl = new PositionBL();
                dt = pbl.SelectByDepartmentID(index);
                ddlPosition1.DataSource = dt;
                ddlPosition1.DataTextField = "Description";
                ddlPosition1.DataValueField = "ID";
                ddlPosition1.DataBind();
                ddlPosition1.Focus();
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

        protected void ddlDivision2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddlDivision2.SelectedValue);
                DataTable dt = new DataTable();
                PositionBL pbl = new PositionBL();
                dt = pbl.SelectByDepartmentID(index);
                ddlPosition2.DataSource = dt;
                ddlPosition2.DataTextField = "Description";
                ddlPosition2.DataValueField = "ID";
                ddlPosition2.DataBind();
                ddlPosition2.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDivision3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddlDivision3.SelectedValue);
                DataTable dt = new DataTable();
                PositionBL pbl = new PositionBL();
                dt = pbl.SelectByDepartmentID(index);
                ddlPosition3.DataSource = dt;
                ddlPosition3.DataTextField = "Description";
                ddlPosition3.DataValueField = "ID";
                ddlPosition3.DataBind();
                ddlPosition3.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                clearData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Career_ResumeBL crbl = new Career_ResumeBL();
                if (crbl.DeleteFromAllCareerTable(BaseLib.Convert_Int(Request.QueryString["Career_ID"].ToString()), Convert.ToInt32(Session["UserID"]), DeletedDateTime()))
                {
                    Response.Write("<script>alert('Delete Successfully')</script>");
                    Response.Write("<script>window.location.href='Career_Resume.aspx?Career_ID='+Career_ID</script>");
                }
                else
                {
                    GlobalUI.MessageBox("Delete Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CreatedDateTime()
        {
            try
            {
                cre.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                MJInfo.CreatedBy = Convert.ToInt32(Session["UserID"]);
                MJInfo.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SetComment(Career_InterView3Entity MJInfo, int id)
        {
            try
            {
                MJInfo.Career_ID = Convert.ToInt32(hfCareerID.Value);
                MJInfo.Myanmar_Interviewer_Comment_Disadvantage = txtMCommentdisadvantage.Text;
                MJInfo.Japense_Interviewer_Comment = txtJCommentAdvantages.Text;
                MJInfo.Japanese_Interviewerr_Comment_Disadvantage = txtJCommentDisadvantage.Text;
                CareerInvQuestion3.CommentInsert(MJInfo, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void IntvQuestion3Insert(int id)
        {
            try
            {
                CareerInvQuestion3 = new Career_InterviewQuestion3BL();
                CareerInfo = new Career_Interview_Question3Entity();
                foreach (GridViewRow row in gvCustomers.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        GridView gvChild = (GridView)row.FindControl("gvOrders");
                        foreach (GridViewRow row1 in gvChild.Rows)
                        {
                            Label Id = row1.FindControl("lblInterviewQ3ID") as Label;
                            CheckBox chkBox = row1.FindControl("chk") as CheckBox;
                            if (chkBox != null)
                            {
                                if (chkBox.Checked)
                                {
                                    CareerInfo.Career_Interview3.Rows.Add(0, id, Convert.ToInt32(Id.Text));
                                }
                            }
                        }
                    }
                }
                CareerInvQuestion3.Insert(CareerInfo.Career_Interview3, id);
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
                cre.UpdatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
                MJInfo.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                MJInfo.UpdatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
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
                return Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                if (e.Value.Length < 400)
                    e.IsValid = true;
                else
                {
                    e.IsValid = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Show_Hide_OrdersGrid(object sender, EventArgs e)
        {
            ImageButton imgShowHide = (sender as ImageButton);
            GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);
            if (imgShowHide.CommandArgument == "Show")
            {
                row.FindControl("pnlOrders").Visible = true;
                imgShowHide.CommandArgument = "Hide";
                imgShowHide.ImageUrl = "~/img/minus.png";
                GridView gvOrders = row.FindControl("gvOrders") as GridView;
                if (gvOrders.Rows.Count <= 0)
                {
                    customerId = gvCustomers.DataKeys[row.RowIndex].Value.ToString();
                    BindOrders(customerId, gvOrders);
                }
            }
            else
            {
                row.FindControl("pnlOrders").Visible = false;
                imgShowHide.CommandArgument = "Show";
                imgShowHide.ImageUrl = "~/img/2plus.png";
            }
        }

        protected Boolean check()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtCode.Text))
                    return false;
                else if (String.IsNullOrWhiteSpace(txtName.Text))
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            txtDateofBirth.Text = String.Empty;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            txtGraduationDate.Text = String.Empty;
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

        protected void btnDataPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Information.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Show_Hide_textbox2(object sender, ImageClickEventArgs e)
        {
            ImageButton img = (sender as ImageButton);
            if (img.CommandArgument == "Show")
            {
                txtJCommentAdvantages.Visible = true;
                img.CommandArgument = "Hide";
                img.ImageUrl = "~/img/minus.png";
            }
            else
            {
                txtJCommentAdvantages.Visible = false;
                img.CommandArgument = "Show";
                img.ImageUrl = "~/img/2plus.png";
            }
        }

        protected void Show_HideTextbox4(object sender, ImageClickEventArgs e)
        {
            ImageButton img = (sender as ImageButton);
            foreach (DataListItem item in datalistsalary.Items)
            {
                TextBox txtother = item.FindControl("txtother") as TextBox;
                if (img.CommandArgument == "Show")
                {
                    txtother.Visible = true;
                    img.CommandArgument = "Hide";
                    img.ImageUrl = "~/img/minus.png";
                }
                else
                {
                    txtother.Visible = false;
                    img.CommandArgument = "Show";
                    img.ImageUrl = "~/img/2plus.png";
                }
            }
        }

        protected void Show_HideTextbox5(object sender, ImageClickEventArgs e)
        {
            ImageButton img = (sender as ImageButton);
            foreach (DataListItem item in datalistsalary.Items)
            {
                TextBox txtreasongfroleaving = item.FindControl("txtreasongfroleaving") as TextBox;
                if (img.CommandArgument == "Show")
                {
                    txtreasongfroleaving.Visible = true;
                    img.CommandArgument = "Hide";
                    img.ImageUrl = "~/img/minus.png";
                }
                else
                {
                    txtreasongfroleaving.Visible = false;
                    img.CommandArgument = "Show";
                    img.ImageUrl = "~/img/2plus.png";
                }
            }
        }

        protected void Show_Hide_textbox3(object sender, ImageClickEventArgs e)
        {
            ImageButton img = (sender as ImageButton);
            if (img.CommandArgument == "Show")
            {
                txtJCommentDisadvantage.Visible = true;
                img.CommandArgument = "Hide";
                img.ImageUrl = "~/img/minus.png";
            }
            else
            {
                txtJCommentDisadvantage.Visible = false;
                img.CommandArgument = "Show";
                img.ImageUrl = "~/img/2plus.png";
            }
        }

        protected void Show_Hide_textboxim(object sender, ImageClickEventArgs e)
        {
            ImageButton img = (sender as ImageButton);
            if (img.CommandArgument == "Show")
            {
                txtimpressionjp.Visible = true;
                img.CommandArgument = "Hide";
                img.ImageUrl = "~/img/minus.png";
            }
            else
            {
                txtimpressionjp.Visible = false;
                img.CommandArgument = "Show";
                img.ImageUrl = "~/img/2plus.png";
            }
        }

        protected void addnew_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        public void AddNewRowToGrid()
        {
            int rowindex = 0;
            if (ViewState["PreviousTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["PreviousTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count > 0 && dtCurrentTable.Rows.Count < 3)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)gvsalary.Rows[rowindex].Cells[0].FindControl("txtExpSalary1");
                            DropDownList ddlIndustry = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                            DropDownList ddlsalaryformat = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                            CheckBox chksalary = (CheckBox)gvsalary.Rows[rowindex].Cells[0].FindControl("chkselectsalary") as CheckBox;
                            Label lbl4 = (Label)gvsalary.Rows[rowindex].Cells[0].FindControl("lblsalary1");
                            drCurrentRow = dtCurrentTable.NewRow();
                            dtCurrentTable.Rows[i - 1]["Salary"] = box1.Text;
                            dtCurrentTable.Rows[i - 1]["Salary_Type"] = ddlIndustry.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["Salary_Format"] = ddlsalaryformat.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["Salary_Status"] = chksalary.Checked;
                            rowindex++;
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["PreviousTable"] = dtCurrentTable;
                        gvsalary.DataSource = dtCurrentTable;
                        gvsalary.DataBind();
                        SetPreviousDB();
                    }
                    else
                    {
                        GlobalUI.MessageBox("Maximum Salary is 3 row");
                    }
                }
            }
            else if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0 && dtCurrentTable.Rows.Count < 3)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)gvsalary.Rows[rowindex].Cells[0].FindControl("txtExpSalary1");
                        DropDownList ddlIndustry = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                        DropDownList ddlsalaryformat = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                        CheckBox chksalary = (CheckBox)gvsalary.Rows[rowindex].Cells[0].FindControl("chkselectsalary") as CheckBox;
                        RadioButton rdosalary = (RadioButton)gvsalary.Rows[rowindex].Cells[0].FindControl("rdoselectsalary") as RadioButton;
                        Label lbl4 = (Label)gvsalary.Rows[rowindex].Cells[0].FindControl("lblsalary1");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Salary"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Salarytype1"] = ddlIndustry.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["SalaryFormat"] = ddlsalaryformat.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["SelectSalary"] = chksalary.Checked;
                        dtCurrentTable.Rows[i - 1]["Lable"] = "希望給与(EXPECTED SALARY):";
                        rowindex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvsalary.DataSource = dtCurrentTable;
                    gvsalary.DataBind();
                    SetPreviousData();
                }
                else
                {
                    GlobalUI.MessageBox("Maximum Salary is 3 row");
                }
            }
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Salary", typeof(string)));
            dt.Columns.Add(new DataColumn("Salarytype1", typeof(string)));
            dt.Columns.Add(new DataColumn("SalaryFormat", typeof(string)));
            dt.Columns.Add(new DataColumn("SelectSalary", typeof(string)));
            dt.Columns.Add(new DataColumn("Lable", typeof(string)));
            dr = dt.NewRow();
            dr["Salary"] = string.Empty;
            dr["Salarytype1"] = string.Empty;
            dr["SalaryFormat"] = string.Empty;
            dr["SelectSalary"] = string.Empty;
            dr["Lable"] = "希望給与(EXPECTED SALARY):";
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            gvsalary.DataSource = dt;
            gvsalary.DataBind();
        }

        protected void gvsalary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlsalarytype = (e.Row.FindControl("ddlsalarytype1") as DropDownList);
                DropDownList ddlsalaryformat = (e.Row.FindControl("ddlsalaryformat") as DropDownList);
                ddlsalarytype.DataSource = BindSalaryType();
                ddlsalarytype.DataTextField = "Description";
                ddlsalarytype.DataValueField = "ID";
                ddlsalarytype.DataBind();
            }
        }

        public DataTable BindSalaryType()
        {
            GlobalBL bl = new GlobalBL();
            DataTable dtb = bl.Get_Datanew("Salary_Type");
            return dtb;
        }

        private void SetPreviousData()
        {
            try
            {
                int rowindex = 0;
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TextBox box1 = (TextBox)gvsalary.Rows[rowindex].Cells[0].FindControl("txtExpSalary1");
                            DropDownList ddlsalarytype1 = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                            DropDownList ddlsalaryformat = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                            CheckBox chksalary = (CheckBox)gvsalary.Rows[rowindex].Cells[0].FindControl("chkselectsalary") as CheckBox;
                            Label lbl4 = (Label)gvsalary.Rows[rowindex].Cells[0].FindControl("lblsalary1");
                            box1.Text = dt.Rows[i]["Salary"].ToString();
                            lbl4.Text = "希望給与(EXPECTED SALARY):";
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["SelectSalary"].ToString()))
                            {
                                if (Convert.ToBoolean(dt.Rows[i]["SelectSalary"]) == true)
                                {
                                    chksalary.Checked = true;
                                }
                                else
                                {
                                    chksalary.Checked = false;
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Salarytype1"].ToString()))
                            {
                                ddlsalarytype1.ClearSelection();
                                ddlsalarytype1.Items.FindByValue(dt.Rows[i]["Salarytype1"].ToString()).Selected = true;
                            }
                            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["SalaryFormat"].ToString()))
                                ddlsalaryformat.Items.FindByValue(dt.Rows[0]["SalaryFormat"].ToString()).Selected = true;
                            else
                                ddlsalaryformat.Items.FindByValue("0").Selected = true;
                            rowindex++;
                        }
                    }
                    DataTable dt1 = (DataTable)ViewState["CurrentTable"];
                    if (dt1.Rows.Count > 1)
                    {
                        LinkButton LinkButton1 = gvsalary.HeaderRow.FindControl("LinkButton1") as LinkButton;
                        LinkButton1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPreviousDB()
        {
            int rowindex = 0;
            if (ViewState["PreviousTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["PreviousTable"];
                if (dt.Rows.Count > 0)
                {
                    Response.Write(gvsalary.Rows.Count);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)gvsalary.Rows[rowindex].Cells[0].FindControl("txtExpSalary1");
                        DropDownList ddlsalarytype1 = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                        DropDownList ddlsalaryformat = (DropDownList)gvsalary.Rows[rowindex].Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                        CheckBox chksalary = (CheckBox)gvsalary.Rows[rowindex].Cells[0].FindControl("chkselectsalary") as CheckBox;
                        Label lbl4 = (Label)gvsalary.Rows[rowindex].Cells[0].FindControl("lblsalary1");
                        box1.Text = dt.Rows[i]["Salary"].ToString();
                        lbl4.Text = "希望給与(EXPECTED SALARY):";
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Salary_Status"].ToString()))
                        {
                            if (Convert.ToBoolean(dt.Rows[i]["Salary_Status"]) == true)
                            {
                                chksalary.Checked = true;
                            }
                            else
                            {
                                chksalary.Checked = false;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Salary_Type"].ToString()))
                        {
                            ddlsalarytype1.ClearSelection();
                            ddlsalarytype1.Items.FindByValue(dt.Rows[i]["Salary_Type"].ToString()).Selected = true;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Salary_Format"].ToString()))
                            ddlsalaryformat.Items.FindByValue(dt.Rows[0]["Salary_Format"].ToString()).Selected = true;
                        else
                            ddlsalaryformat.Items.FindByValue("0").Selected = true;
                        rowindex++;
                    }
                }
            }
            DataTable dt1 = (DataTable)ViewState["PreviousTable"];
            if (dt1.Rows.Count > 1)
            {
                LinkButton LinkButton1 = gvsalary.HeaderRow.FindControl("LinkButton1") as LinkButton;
                LinkButton1.Visible = true;
            }
        }

        public void CreatenewDataTable()
        {
            DataTable dtnew = new DataTable();
            DataRow dr = null;
            dtnew.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dtnew.Columns.Add(new DataColumn("Salary", typeof(string)));
            dtnew.Columns.Add(new DataColumn("Salarytype1", typeof(string)));
            dtnew.Columns.Add(new DataColumn("SelectSalary", typeof(string)));
            dtnew.Columns.Add(new DataColumn("SalaryFormat", typeof(string)));
            ViewState["DataTablenew"] = dtnew;
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["PreviousTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["PreviousTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
                    }
                }
                ViewState["PreviousTable"] = dt;
                gvsalary.DataSource = dt;
                gvsalary.DataBind();
                int rowIndex = 0;
                foreach (GridViewRow row in gvsalary.Rows)
                {
                    TextBox box1 = (TextBox)row.Cells[0].FindControl("txtExpSalary1");
                    DropDownList ddlsalarytype1 = (DropDownList)row.Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                    DropDownList ddlsalaryformat = (DropDownList)row.Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                    CheckBox chksalary = (CheckBox)row.Cells[0].FindControl("chkselectsalary") as CheckBox;
                    Label lbl4 = (Label)row.Cells[0].FindControl("lblsalary1");
                    box1.Text = dt.Rows[rowIndex]["Salary"].ToString();
                    lbl4.Text = "希望給与(EXPECTED SALARY):";
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Salary_Status"].ToString()))
                    {
                        if (Convert.ToBoolean(dt.Rows[rowIndex]["Salary_Status"]) == true)
                        {
                            chksalary.Checked = true;
                        }
                        else
                        {
                            chksalary.Checked = false;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Salary_Type"].ToString()))
                    {
                        ddlsalarytype1.ClearSelection();
                        ddlsalarytype1.Items.FindByValue(dt.Rows[rowIndex]["Salary_Type"].ToString()).Selected = true;
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["SalaryFormat"].ToString()))
                        ddlsalaryformat.Items.FindByValue(dt.Rows[0]["SalaryFormat"].ToString()).Selected = true;
                    else
                        ddlsalaryformat.Items.FindByValue("0").Selected = true;
                    rowIndex++;
                }
                if (dt.Rows.Count > 1)
                {
                    LinkButton LinkButton1 = gvsalary.HeaderRow.FindControl("LinkButton1") as LinkButton;
                    LinkButton1.Visible = true;
                }
            }
            else if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
                    }
                }
                ViewState["CurrentTable"] = dt;
                gvsalary.DataSource = dt;
                gvsalary.DataBind();
                int rowIndex = 0;
                foreach (GridViewRow row in gvsalary.Rows)
                {
                    TextBox box1 = (TextBox)row.Cells[0].FindControl("txtExpSalary1");
                    DropDownList ddlsalarytype1 = (DropDownList)row.Cells[0].FindControl("ddlsalarytype1") as DropDownList;
                    DropDownList ddlsalaryformat = (DropDownList)row.Cells[0].FindControl("ddlsalaryformat") as DropDownList;
                    CheckBox chksalary = (CheckBox)row.Cells[0].FindControl("chkselectsalary") as CheckBox;
                    Label lbl4 = (Label)row.Cells[0].FindControl("lblsalary1");
                    box1.Text = dt.Rows[rowIndex]["Salary"].ToString();
                    lbl4.Text = "希望給与(EXPECTED SALARY):";
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["SelectSalary"].ToString()))
                    {
                        if (Convert.ToBoolean(dt.Rows[rowIndex]["SelectSalary"]) == true)
                        {
                            chksalary.Checked = true;
                        }
                        else
                        {
                            chksalary.Checked = false;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Salarytype1"].ToString()))
                    {
                        ddlsalarytype1.ClearSelection();
                        ddlsalarytype1.Items.FindByValue(dt.Rows[rowIndex]["Salarytype1"].ToString()).Selected = true;
                    }
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["SalaryFormat"].ToString()))
                        ddlsalaryformat.Items.FindByValue(dt.Rows[0]["SalaryFormat"].ToString()).Selected = true;
                    else
                        ddlsalaryformat.Items.FindByValue("0").Selected = true;
                    rowIndex++;
                }
                if (dt.Rows.Count > 1)
                {
                    LinkButton LinkButton1 = gvsalary.HeaderRow.FindControl("LinkButton1") as LinkButton;
                    LinkButton1.Visible = true;
                }
            }
        }

        public void FillOldjobhistory(DataTable dtoldjobhistory, int Career_ID)
        {
            datalistsalary.DataSource = dtoldjobhistory;
            datalistsalary.DataBind();
        }

        public void CreateForWorkingHistory()
        {
            DataTable dtworking = new DataTable();
            DataRow dr = null;
            dtworking.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dtworking.Columns.Add(new DataColumn("companyname", typeof(string)));
            dtworking.Columns.Add(new DataColumn("companyaddress", typeof(string)));
            dtworking.Columns.Add(new DataColumn("fromdate", typeof(string)));
            dtworking.Columns.Add(new DataColumn("todate", typeof(string)));
            dtworking.Columns.Add(new DataColumn("jobdescripition", typeof(string)));
            dtworking.Columns.Add(new DataColumn("reasonjp", typeof(string)));
            dtworking.Columns.Add(new DataColumn("industry", typeof(string)));
            dtworking.Columns.Add(new DataColumn("business", typeof(string)));
            dtworking.Columns.Add(new DataColumn("deparment", typeof(string)));
            dtworking.Columns.Add(new DataColumn("position", typeof(string)));
            dtworking.Columns.Add(new DataColumn("otherjp", typeof(string)));
            dtworking.Columns.Add(new DataColumn("positionlevel", typeof(string)));
            dtworking.Columns.Add(new DataColumn("othereng", typeof(string)));
            dtworking.Columns.Add(new DataColumn("reasoneng", typeof(string)));
            dtworking.Columns.Add(new DataColumn("industryID", typeof(string)));
            dtworking.Columns.Add(new DataColumn("businessID", typeof(string)));
            dtworking.Columns.Add(new DataColumn("deparmentID", typeof(string)));
            dtworking.Columns.Add(new DataColumn("positionID", typeof(string)));
            ViewState["WorkingHistory"] = dtworking;
        }

        protected void Selected_Township(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddlUniversityName.SelectedValue);
                DataTable dt = new DataTable();
                Working_History_BL webbl = new Working_History_BL();
                dt = webbl.SelectedbyUniversityID(index);
                ddlUniversityArea.DataSource = dt;
                ddlUniversityArea.DataTextField = "AreaDescription";
                ddlUniversityArea.DataValueField = "AreaID";
                ddlUniversityArea.DataBind();
                ddlUniversityArea.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Selected_Township2(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddlUniversityName2.SelectedValue);
                DataTable dt = new DataTable();
                Working_History_BL webbl = new Working_History_BL();
                dt = webbl.SelectedbyUniversityID(index);
                ddlUniversityArea2.DataSource = dt;
                ddlUniversityArea2.DataTextField = "AreaDescription";
                ddlUniversityArea2.DataValueField = "AreaID";
                ddlUniversityArea2.DataBind();
                ddlUniversityArea2.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}