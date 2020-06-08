using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1.Employee
{
    public partial class Career_Resume_View : System.Web.UI.Page
    {
        String ExportCSVPath = ConfigurationManager.AppSettings["ExportCSVPath"].ToString();
        Career_ResumeEntity cre;
        Career_ResumeBL career_Resume;
        GenderBL gender;
        QualificationBL Qualification;
        InstituationBL Institution;
        MajorBL Major;
        PositionBL Position;
        DepartmentBL Department;
        GlobalBL gb; string index;
        Career_ResumeEntity.Criterias Criteria;
        string cid; int changeid;
        string[] sortname = new string[100000];
        string[] sortcode = new string[100000];
        string[] sort = new string[100000];
        string sorted; string search; string exp;
        private int psize = 10; int check; string page = null;

        public int PageIndex
        {
            get
            {
                if (Session["PageIndex"] != null)
                {
                    int pgindex = (int)Session["PageIndex"];
                    return pgindex;
                }
                else
                {
                    return 0;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvCareerProfileView.DataBind();
                if (Request.QueryString["ClientRecuriment"] != null)
                {
                    DataTable dt = Session["dtClientRecruitment"] as DataTable;
                    int age1 = Convert.ToInt32(dt.Rows[0]["Age_From"]);
                    ddlcFromAge.SelectedValue = age1.ToString();
                    int age2 = Convert.ToInt32(dt.Rows[0]["Age_To"]);
                    ddlcToAge.SelectedValue = age2.ToString();
                    int salary1 = Convert.ToInt32(dt.Rows[0]["Salary_From"]);
                    txtExpectedSalary.Text = salary1.ToString();
                    int salary2 = Convert.ToInt32(dt.Rows[0]["Salary_To"]);
                    txtExpectedSalary2.Text = salary2.ToString();
                    cre = new Career_ResumeEntity();
                    string gender = dt.Rows[0]["Gender"].ToString();
                    string interviewername = dt.Rows[0]["Interviewer_Name"].ToString();
                    cre.PositionName1 = dt.Rows[0]["Position1"].ToString();
                    cre.LanguageJapaneseRWLevel = dt.Rows[0]["Japanese_RW_LevelID1"].ToString();
                    cre.LanguageJapaneseSKLevel = dt.Rows[0]["Japanese_Speaking_LevelID1"].ToString();
                    cre.LanguageEnglishRWLevel = dt.Rows[0]["English_RW_LevelID1"].ToString();
                    cre.LanguageEnglishSKLevel = dt.Rows[0]["English_Speaking_LevelID1"].ToString();
                    cre.LanguageMyanmarRWLevel = dt.Rows[0]["Myanmar_RW_LevelID1"].ToString();
                    cre.LanguageMyanmarSKLevel = dt.Rows[0]["Myanmar_Speaking_LevelID1"].ToString();
                    career_Resume = new Career_ResumeBL();
                    //DataTable dt1 = career_Resume.SelectByClientRecruitment(cre, age1, age2, salary1, salary2);
                    //gvCareerProfileView.DataSource = dt1;
                    //gvCareerProfileView.DataBind();
                    GetJapaneseRW();
                    GetJapaneseSpeaking();
                    GetEnglishRW();
                    GetEnglishSpeaking();
                    GetBurmeseRW();
                    GetBurmeseSpeaking();
                    ClearViewStates();
                    GetGender();
                    GetQualification();
                    GetInstitution();
                    Ability();
                    GetMajor();
                    GetPosition();
                    GetDepartment();
                    GetTownship();
                    GetIndustry();
                    GetDepartmentnew();
                    GetPositionnew();
                    GetPositionLevel();
                    GetInterviewer();
                    lnkdownload.Text = String.Empty;
                }
                else
                {
                    gvCareerProfileView.PageIndex = Convert.ToInt32(Session["Page"]);
                    GetJapaneseRW();
                    GetJapaneseSpeaking();
                    GetEnglishRW();
                    GetEnglishSpeaking();
                    GetBurmeseRW();
                    GetBurmeseSpeaking();
                    ClearViewStates();
                    GetGender();
                    GetQualification();
                    GetInstitution();
                    GetMajor();
                    Ability();
                    GetPosition();
                    GetDepartment();
                    GetTownship();
                    GetBusinessType();
                    GetIndustry();
                    GetDepartmentnew();
                    GetPositionnew();
                    GetPositionLevel();
                    GetInterviewer();
                    lnkdownload.Text = String.Empty;
                    Session.Remove("PageIndex");
                }
            }
        }

        protected void ScriptManager1_Navigate(object sender, System.Web.UI.HistoryEventArgs e)
        {
            string pageIndex = e.State["PageIndex"];
            if (Session["index"] != null)
            {
                page = Session["index"].ToString();
            }
            if (string.IsNullOrEmpty(pageIndex))
            {
                gvCareerProfileView.PageIndex = 0;
            }
            else if (page != null)
            {
                gvCareerProfileView.PageIndex = 0;
                page = null;
                Session["index"] = null;
            }
            else
            {
                gvCareerProfileView.PageIndex = Convert.ToInt32(pageIndex);
            }
        }

        public void GetTownship()
        {
            try
            {
                LbTownship.DataTextField = "Description";
                LbTownship.DataValueField = "ID";
                LbTownship.DataSource = career_Resume.SelectByTownship();
                LbTownship.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public void GetQualification()
        {
            try
            {
                Qualification = new QualificationBL();
                Lbqualification.DataSource = Qualification.SelectAll(1);
                Lbqualification.DataTextField = "Description";
                Lbqualification.DataValueField = "ID";
                Lbqualification.DataBind();
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
                Response.Redirect("Career_Resume.aspx");
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
                career_Resume = new Career_ResumeBL();
                SaveCheckedValues();
                ArrayList selectedID = GetSelectedRecord();
                if (selectedID == null)
                {
                    GlobalUI.MessageBox("Please select at least one record!");
                    return;
                }
                if (ViewState["HeaderCheckBox"] != null && (bool)ViewState["HeaderCheckBox"])
                {
                    GlobalUI.MessageBox(career_Resume.DeleteAll());
                }
                else
                {
                    foreach (DataRow Row in career_Resume.SelectAll().Rows)
                    {
                        int ID = int.Parse(Row["ID"].ToString());
                        ArrayList userdetails = (ArrayList)ViewState["CHECKED_ITEMS"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCareer_Profile_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvCareerProfileView.Rows.Count != 0)
                {
                    SaveCheckedValues();
                    PopulateCheckedValues();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewState["CHECKED_ITEMS"] = null;
                CheckBox chkAll = (CheckBox)gvCareerProfileView.HeaderRow.FindControl("chkAll");
                if (chkAll.Checked)
                {
                    foreach (GridViewRow gvRow in gvCareerProfileView.Rows)
                    {
                        if (gvCareerProfileView.DataKeys[gvRow.RowIndex].Value.ToString() != "")
                        {
                            CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                            chkStatus.Checked = true;
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in gvCareerProfileView.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                        chkStatus.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCareerProfileView.PageIndex = e.NewPageIndex;
            if (ScriptManager1.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            {
                ScriptManager1.AddHistoryPoint("PageIndex", gvCareerProfileView.PageIndex.ToString());
            }
            if (ViewState["search"] != null)
            {
                search = ViewState["search"].ToString();
                ViewState["index"] = "index";
            }
        }

        protected void gvCareerProfileView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "ID").ToString() == "")
                    {
                        CheckBox chk = (CheckBox)e.Row.FindControl("chkStatus");
                        chk.Visible = false;
                        chk.Enabled = false;
                    }
                    else
                    {
                        int CareerID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                        career_Resume = new Career_ResumeBL();
                        DataTable dt = career_Resume.SelectQualificationByCareerID(CareerID);
                        if (dt.Rows.Count > 0)
                        {
                            GridView gvQualification = (GridView)e.Row.FindControl("gvQualification");
                            gvQualification.DataSource = dt;
                            gvQualification.DataBind();
                        }
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "JobIntroduction").ToString().ToLower() == "false")
                    {
                        e.Row.Cells[17].Text = String.Empty;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "JobIntroduction").ToString().ToLower() == "true")
                    {
                        e.Row.Cells[17].Text = "○";

                    }
                }
                //if (e.Row.RowType == DataControlRowType.Pager)
                //{
                //    int CurPage = gvCareerProfileView.PageIndex + 1;
                //    TableCell sortCell = new TableCell();
                //    sortCell.Text = string.Format("Current Page Number : {0} of Total Records : {1}&nbsp;&nbsp;", CurPage, HiddenField1.Value.ToString());
                //    Table tbl = (Table)e.Row.Cells[0].Controls[0];
                //    tbl.Rows[0].Cells.AddAt(0, sortCell);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            hdfsearch.Value = "";
            gvCareerProfileView.DataBind();
            ViewState["search"] = search;
        }

        protected void gvCareer_Profile_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataTable dataTable = ViewState["data"] as DataTable;
                SaveCheckedValues();
                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    dataView.Sort = "ctdate" + " " + GetSortDirection("ctdate");
                    dataTable = dataView.ToTable();
                    DataTable SortedData = dataTable;
                    ViewState["SortedData"] = SortedData;
                    gvCareerProfileView.DataSource = SortedData;
                    gvCareerProfileView.DataBind();
                }
                PopulateCheckedValues();
                ToggleCheckBoxes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCareerEmployment_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList selectedID = GetSelectedRecord();
                if (selectedID != null)
                {
                    if (selectedID.Count > 1 || selectedID.Count <= 0)
                    {
                        string result;
                        if (selectedID.Count > 1)
                            result = "Not allowed to select multiple records in Edit!";
                        else
                            result = "You select one row to edit";
                        GlobalUI.MessageBox(result);
                    }
                    else
                    {
                        int Career_ID = Convert.ToInt16(selectedID[0].ToString());
                        Response.Redirect("CareerEmployment.aspx?Career_ID=" + Career_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCareerInterview1_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList selectedID = GetSelectedRecord();
                if (selectedID != null)
                {
                    if (selectedID.Count > 1 || selectedID.Count <= 0)
                    {
                        string result;
                        if (selectedID.Count > 1)
                            result = "Not allowed to select multiple records in Edit!";
                        else
                            result = "You select one row to edit";
                        GlobalUI.MessageBox(result);
                    }
                    else
                    {
                        int Career_ID = Convert.ToInt16(selectedID[0].ToString());
                        Response.Redirect("Career_Interview.aspx?Career_ID=" + Career_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCareerInterview3_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList selectedID = GetSelectedRecord();
                if (selectedID != null)
                {
                    if (selectedID.Count > 1 || selectedID.Count <= 0)
                    {
                        string result;
                        if (selectedID.Count > 1)
                            result = "Not allowed to select multiple records in Edit!";
                        else
                            result = "You select one row to edit";
                        GlobalUI.MessageBox(result);
                    }
                    else
                    {
                        int Career_ID = Convert.ToInt16(selectedID[0].ToString());
                        Response.Redirect("Career_Interview3.aspx?Career_ID=" + Career_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCareerInterview2_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList selectedID = GetSelectedRecord();
                if (selectedID != null)
                {
                    if (selectedID.Count > 1 || selectedID.Count <= 0)
                    {
                        string result;
                        if (selectedID.Count > 1)
                            result = "Not allowed to select multiple records in Edit!";
                        else
                            result = "You select one row to edit";
                        GlobalUI.MessageBox(result);
                    }
                    else
                    {
                        int Career_ID = Convert.ToInt16(selectedID[0].ToString());
                        Response.Redirect("Career_Interview2.aspx?Career_ID=" + Career_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList selectedID = GetSelectedRecord();
                if (selectedID != null)
                {
                    if (selectedID.Count > 1 || selectedID.Count <= 0)
                    {
                        string result;
                        if (selectedID.Count > 1)
                            result = "Not allowed to select multiple records in Edit!";
                        else
                            result = "You select one row to edit";
                        GlobalUI.MessageBox(result);
                    }
                    else
                    {
                        int Career_ID = Convert.ToInt16(selectedID[0].ToString());
                        Response.Redirect("Career_Information.aspx?Career_ID=" + Career_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCareerProfileView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataUpdate")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/Employee/Career_Resume.aspx?Career_ID=" + ID);
                }
                else if (e.CommandName == "DataEdit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/Employee/Career_Resume.aspx?Career_ID=" + ID);
                }
                else if (e.CommandName == "DataDetail")
                {
                    Session["Page"] = gvCareerProfileView.PageIndex;
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/Employee/Career_Resume_Detail.aspx?Career_ID=" + ID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DataTable GetCareerResume()
        {
            DataTable dtCareerResume = SearchByCriteria();
            if (dtCareerResume != null)
            {
                if (dtCareerResume.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCareerResume.Rows.Count; i++)
                    {
                        if (dtCareerResume.Rows[i]["English_RW_Level"].ToString() == "")
                        {
                            dtCareerResume.Rows[i]["English_RW_Level"] = "-";
                        }
                        if (dtCareerResume.Rows[i]["English_Speaking_Level"].ToString() == "")
                        {
                            dtCareerResume.Rows[i]["English_Speaking_Level"] = "-";
                        }
                        if (dtCareerResume.Rows[i]["Japanese_RW_Level"].ToString() == "")
                        {
                            dtCareerResume.Rows[i]["Japanese_RW_Level"] = "- ";
                        }
                        if (dtCareerResume.Rows[i]["Japanese_Speaking_Level"].ToString() == "")
                        {
                            dtCareerResume.Rows[i]["Japanese_Speaking_Level"] = " -";
                        }
                        if (dtCareerResume.Rows[i]["Myanmar_RW_Level"].ToString() == "")
                        {
                            dtCareerResume.Rows[i]["Myanmar_RW_Level"] = "- ";
                        }
                        if (dtCareerResume.Rows[i]["Myanmar_Speaking_Level"].ToString() == "")
                        {
                            dtCareerResume.Rows[i]["Myanmar_Speaking_Level"] = " -";
                        }
                    }
                    dtCareerResume.AcceptChanges();
                    return dtCareerResume;
                }
                else
                {
                    return dtCareerResume;
                }
            }
            else
            {
                return dtCareerResume;
            }
        }

        private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
        {
            foreach (DataRow sourcerow in source.Rows)
            {
                DataRow destRow = dest.NewRow();
                for (int i = 0; i < columns.Length; i++)
                {
                    string colname = columns[i];
                    if (!String.IsNullOrWhiteSpace(colname))
                    {
                        destRow[colname] = sourcerow[colname];
                    }
                }
                dest.Rows.Add(destRow);
            }
        }

        private string GetSortDirection1(string column)
        {
            string sortDirection = "DESC";
            if (column == "CareerNamesort")
            {
                sortDirection = "ASC";
            }
            return sortDirection;
        }

        private void SaveCheckedValues()
        {
            #region Header CheckBox
            CheckBox chkAll = (CheckBox)gvCareerProfileView.HeaderRow.FindControl("chkAll");
            if (chkAll.Checked)
            {
                ViewState["HeaderCheckBox"] = true;
            }
            else
            {
                if (ViewState["CHECKED_ITEMS"] != null)
                    ViewState["HeaderCheckBox"] = null;
                else
                    ViewState["HeaderCheckBox"] = false;
            }
            #endregion
            ArrayList userdetails = new ArrayList();
            int ID = -1;
            foreach (GridViewRow gvrow in gvCareerProfileView.Rows)
            {
                if (gvCareerProfileView.DataKeys[gvrow.RowIndex].Value.ToString() != "")
                {
                    ID = int.Parse(gvCareerProfileView.DataKeys[gvrow.RowIndex].Value.ToString());
                    bool result = ((CheckBox)gvrow.FindControl("chkStatus")).Checked;
                    // Check in the ViewState
                    if (ViewState["CHECKED_ITEMS"] != null)
                        userdetails = (ArrayList)ViewState["CHECKED_ITEMS"];
                    if (result)
                    {
                        if (!userdetails.Contains(ID))
                            userdetails.Add(ID);
                    }
                    else
                        userdetails.Remove(ID);
                }
            }
            if (userdetails != null && userdetails.Count > 0)
                ViewState["CHECKED_ITEMS"] = userdetails;
        }

        private void PopulateCheckedValues()
        {
            #region Header CheckBox
            CheckBox chkAll = (CheckBox)gvCareerProfileView.HeaderRow.FindControl("chkAll");
            if (ViewState["HeaderCheckBox"] != null)
            {
                if ((bool)ViewState["HeaderCheckBox"])
                {
                    chkAll.Checked = true;
                }
            }
            #endregion
            ArrayList userdetails = (ArrayList)ViewState["CHECKED_ITEMS"];
            if (userdetails != null && userdetails.Count > 0)
            {
                foreach (GridViewRow gvrow in gvCareerProfileView.Rows)
                {
                    if (gvCareerProfileView.DataKeys[gvrow.RowIndex].Value.ToString() != "")
                    {
                        int index = (int)gvCareerProfileView.DataKeys[gvrow.RowIndex].Value;
                        if (userdetails.Contains(index))
                        {
                            CheckBox myCheckBox = (CheckBox)gvrow.FindControl("chkStatus");
                            myCheckBox.Checked = true;
                        }
                    }
                }
            }
        }

        protected void ToggleCheckBoxes()
        {
            CheckBox chkAll = (CheckBox)gvCareerProfileView.HeaderRow.FindControl("chkAll");
            if (ViewState["HeaderCheckBox"] != null)
            {
                if ((bool)ViewState["HeaderCheckBox"])
                {
                    foreach (GridViewRow gvRow in gvCareerProfileView.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                        chkStatus.Checked = true;
                    }
                }
                else if (!(bool)ViewState["HeaderCheckBox"])
                {
                    foreach (GridViewRow gvRow in gvCareerProfileView.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                        chkStatus.Checked = false;
                    }
                }
            }
        }

        private ArrayList GetSelectedRecord()
        {
            ArrayList selectedID = new ArrayList();
            for (int i = 0; i < gvCareerProfileView.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvCareerProfileView.Rows[i].Cells[0].FindControl("chkStatus");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        selectedID.Add(Convert.ToInt16(gvCareerProfileView.DataKeys[i].Value));
                    }
                }
            }
            return selectedID;
        }

        private DataTable SearchByCriteria()
        {
            try
            {
                career_Resume = new Career_ResumeBL();
                Criteria.Career_Code = ddlcCode.SelectedItem.ToString() + "-" + txtCode.Text;
                Criteria.Name = txtName.Text;
                Criteria.JobIntro = chkJobIntro.Checked;
                Criteria.GenderID = null;
                if (ddlcSex.SelectedValue.ToString() != "")
                {
                    Criteria.GenderID = int.Parse(ddlcSex.SelectedValue.ToString());
                }
                
                Criteria.English_RW_LevelID = null;
                Criteria.English_Speaking_LevelID = null;
                Criteria.Japanese_RW_LevelID = null;
                Criteria.Japanese_Speaking_LevelID = null;
                Criteria.Myanmar_RW_LevelID = null;
                Criteria.Myanmar_Speaking_LevelID = null;
                Criteria.JPRWcheck = null;
                Criteria.JPSpeakingcheck = null;
                Criteria.EngRWcheck = null;
                Criteria.EngSpeakingcheck = null;
                Criteria.MnSpeakingcheck = null;
                Criteria.MnRWcheck = null;
                Criteria.Keyword = txtKey.Text.Trim();
                Criteria.department = null;
                if (!String.IsNullOrWhiteSpace(ddldepartmentnew.SelectedValue.ToString()))
                {
                    Criteria.department = int.Parse(ddldepartmentnew.SelectedValue.ToString());
                }
                Criteria.position = null;
                //if (!String.IsNullOrWhiteSpace(ddlpositionnew.SelectedValue.ToString()))
                //{
                //    Criteria.position = int.Parse(ddlpositionnew.SelectedValue.ToString());
                //}
                if (!String.IsNullOrWhiteSpace(ddlcpositionnew.SelectedValue.ToString()))
                {
                    Criteria.position = int.Parse(ddlcpositionnew.SelectedValue.ToString());
                }
                Criteria.industry = null;
                if (ddlindustrynew.SelectedValue.ToString() != "")
                {
                    Criteria.industry = int.Parse(ddlindustrynew.SelectedValue.ToString());
                }
                Criteria.typeofbusiness = null;
                //if (ddltypeofbusinessnew.SelectedValue.ToString() != "")
                //{
                //    Criteria.typeofbusiness = int.Parse(ddltypeofbusinessnew.SelectedValue.ToString());
                //}
                if (ddlctypeofbusinessnew.SelectedValue.ToString() != "")
                {
                    Criteria.typeofbusiness = int.Parse(ddlctypeofbusinessnew.SelectedValue.ToString());
                }
                if (!String.IsNullOrWhiteSpace(txttotalmark.Text.Trim()))
                {
                    if (chktotalmark.Checked)
                    {
                        Criteria.totalmark = Convert.ToInt32(txttotalmark.Text.Trim());
                    }
                    else
                    {
                        Criteria.totalmark = Convert.ToInt32(txttotalmark.Text.Trim());
                    }
                }
                #region Language
                //if (!String.IsNullOrWhiteSpace(ddlJapaneseRW.SelectedValue.ToString()))
                //{
                //    if (chkJPRW.Checked)
                //    {
                //        Criteria.JPRWcheck = BaseLib.Convert_Int(ddlJapaneseRW.SelectedValue.ToString());
                //    }
                //    else
                //    {
                //        Criteria.Japanese_RW_LevelID = BaseLib.Convert_Int(ddlJapaneseRW.SelectedValue.ToString());
                //    }
                //}
                //if (!String.IsNullOrWhiteSpace(ddlJapaneseSpeaking.SelectedValue.ToString()))
                //{
                //    if (chkJPSpeaking.Checked)
                //    {
                //        Criteria.JPSpeakingcheck = BaseLib.Convert_Int(ddlJapaneseSpeaking.SelectedValue.ToString());
                //    }
                //    else
                //    {
                //        Criteria.Japanese_Speaking_LevelID = BaseLib.Convert_Int(ddlJapaneseSpeaking.SelectedValue.ToString());
                //    }
                //}
                //if (!String.IsNullOrWhiteSpace(ddlEnglishRW.SelectedValue.ToString()))
                //{
                //    if (chkEngRW.Checked)
                //    {
                //        Criteria.EngRWcheck = BaseLib.Convert_Int(ddlEnglishRW.SelectedValue.ToString());
                //    }
                //    else
                //    {
                //        Criteria.English_RW_LevelID = BaseLib.Convert_Int(ddlEnglishRW.SelectedValue.ToString());
                //    }
                //}
                //if (!String.IsNullOrWhiteSpace(ddlEnglishSpeaking.SelectedValue.ToString()))
                //{
                //    if (chkEngSpeaking.Checked)
                //    {
                //        Criteria.EngSpeakingcheck = BaseLib.Convert_Int(ddlEnglishSpeaking.SelectedValue.ToString());
                //    }
                //    else
                //    {
                //        Criteria.English_Speaking_LevelID = BaseLib.Convert_Int(ddlEnglishSpeaking.SelectedValue.ToString());
                //    }
                //}
                #endregion
                if (!String.IsNullOrWhiteSpace(ddlcJapaneseRW.SelectedValue.ToString()))
                {
                    if (chkJPRW.Checked)
                    {
                        Criteria.JPRWcheck = BaseLib.Convert_Int(ddlcJapaneseRW.SelectedValue.ToString());
                    }
                    else
                    {
                        Criteria.Japanese_RW_LevelID = BaseLib.Convert_Int(ddlcJapaneseRW.SelectedValue.ToString());
                    }
                }
                if (!String.IsNullOrWhiteSpace(ddlcJapaneseSpeaking.SelectedValue.ToString()))
                {
                    if (chkJPSpeaking.Checked)
                    {
                        Criteria.JPSpeakingcheck = BaseLib.Convert_Int(ddlcJapaneseSpeaking.SelectedValue.ToString());
                    }
                    else
                    {
                        Criteria.Japanese_Speaking_LevelID = BaseLib.Convert_Int(ddlcJapaneseSpeaking.SelectedValue.ToString());
                    }
                }
                if (!String.IsNullOrWhiteSpace(ddlcEnglishRW.SelectedValue.ToString()))
                {
                    if (chkEngRW.Checked)
                    {
                        Criteria.EngRWcheck = BaseLib.Convert_Int(ddlcEnglishRW.SelectedValue.ToString());
                    }
                    else
                    {
                        Criteria.English_RW_LevelID = BaseLib.Convert_Int(ddlcEnglishRW.SelectedValue.ToString());
                    }
                }
                if (!String.IsNullOrWhiteSpace(ddlcEnglishSpeaking.SelectedValue.ToString()))
                {
                    if (chkEngSpeaking.Checked)
                    {
                        Criteria.EngSpeakingcheck = BaseLib.Convert_Int(ddlcEnglishSpeaking.SelectedValue.ToString());
                    }
                    else
                    {
                        Criteria.English_Speaking_LevelID = BaseLib.Convert_Int(ddlcEnglishSpeaking.SelectedValue.ToString());
                    }
                }
                if (!String.IsNullOrWhiteSpace(ddlBurmeseRW.SelectedValue.ToString()))
                {
                    if (chkMnRW.Checked)
                    {
                        Criteria.MnRWcheck = BaseLib.Convert_Int(ddlBurmeseRW.SelectedValue.ToString());
                    }
                    else
                    {
                        Criteria.Myanmar_RW_LevelID = BaseLib.Convert_Int(ddlBurmeseRW.SelectedValue.ToString());
                    }
                }
                if (!String.IsNullOrWhiteSpace(ddlBurmeseSpeaking.SelectedValue.ToString()))
                {
                    if (chkMnSpeaking.Checked)
                    {
                        Criteria.MnSpeakingcheck = BaseLib.Convert_Int(ddlBurmeseSpeaking.SelectedValue.ToString());
                    }
                    else
                    {
                        Criteria.Myanmar_Speaking_LevelID = BaseLib.Convert_Int(ddlBurmeseSpeaking.SelectedValue.ToString());
                    }
                }
                Criteria.InstitutionName_ID = null;
                if (ddlcInstitution.SelectedValue.ToString() != "")
                {
                    Criteria.InstitutionName_ID = int.Parse(ddlcInstitution.SelectedValue.ToString());
                }
                //added by nyisoe  20/05/2020
                Criteria.ID = null;                
                    if(ddlfirsint.SelectedValue.ToString() != "")
                {
                    Criteria.ID = int.Parse(ddlfirsint.SelectedValue.ToString());
                }

                Criteria.MajorID = null;
                if (ddlcMajor.SelectedValue.ToString() != "")
                {
                    Criteria.MajorID = int.Parse(ddlcMajor.SelectedValue.ToString());
                }
                Criteria.PositionID = null;
                if (ddlPosition.SelectedValue.ToString() != "")
                {
                    Criteria.PositionID = int.Parse(ddlPosition.SelectedValue.ToString());
                }
                Criteria.DepartmentID = null;
                if (ddlDepartment.SelectedValue.ToString() != "")
                {
                    Criteria.DepartmentID = int.Parse(ddlDepartment.SelectedValue.ToString());
                }
                Criteria.QualificationID = null;
                if (Lbqualification.SelectedValue.ToString() != "")
                {
                    string qualification = null;
                    if (Lbqualification.SelectedValue.ToString() != "")
                    {
                        for (int i = 0; i < Lbqualification.Items.Count; i++)
                        {
                            qualification += Lbqualification.Items[i].Value.ToString() + ",";
                        }
                    }
                    Criteria.QualificationID = qualification;
                }
                Criteria.Township = null;
                if (LbTownship.SelectedValue.ToString() != "")
                {
                    string townships = null;
                    for (int i = 0; i < LbTownship.Items.Count; i++)
                    {
                        if (LbTownship.Items[i].Selected)
                        {
                            townships += LbTownship.Items[i].Value.ToString() + ",";
                        }
                    }
                    Criteria.Township1 = townships;
                }
                if (ddlcFromAge.SelectedValue.ToString() != "")
                {
                    Criteria.Age = int.Parse(ddlcFromAge.SelectedValue.ToString());
                }
                else
                    Criteria.Age = null;
                if (ddlcToAge.SelectedValue.ToString() != "")
                {
                    Criteria.ToAge = int.Parse(ddlcToAge.SelectedValue.ToString());
                }
                else Criteria.ToAge = null;
                if (!String.IsNullOrWhiteSpace(txtExpectedSalary.Text))
                    Criteria.Salary = int.Parse(txtExpectedSalary.Text.Trim());
                else
                    Criteria.Salary = null;
                if (!String.IsNullOrWhiteSpace(txtExpectedSalary2.Text))
                    Criteria.Salaryto = int.Parse(txtExpectedSalary2.Text.Trim());
                else
                    Criteria.Salaryto = null;
                return career_Resume.SelectByCriteria(ref Criteria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearViewStates()
        {
            ViewState["CHECKED_ITEMS"] = null;
            ViewState["HeaderCheckBox"] = null;
            ViewState["SortedData"] = null;
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        #region Binding Drop Down List
        private void GetGender()
        {
            try
            {
                gender = new GenderBL(); 
                ddlcSex.DataTextField = "Description";
                ddlcSex.DataValueField = "ID";
                ddlcSex.DataSource = gender.SelectAll();
                ddlcSex.DataBind();
                //ddlSex.DataSource = gender.SelectAll();
                //ddlSex.DataTextField = "Description";
                //ddlSex.DataValueField = "ID";
                //ddlSex.DataBind();
                //ddlSex.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetInstitution()
        {
            try
            {
                Institution = new InstituationBL();
                ddlcInstitution.DataTextField = "Description";
                ddlcInstitution.DataValueField = "ID";
                ddlcInstitution.DataSource = Institution.SelectAll(1);
                ddlcInstitution.DataBind();
                //ddlInstitution.DataSource = Institution.SelectAll(1);
                //ddlInstitution.DataTextField = "Description";
                //ddlInstitution.DataValueField = "ID";
                //ddlInstitution.DataBind();
                //ddlInstitution.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetMajor()
        {
            try
            {
                Major = new MajorBL();
                ddlcMajor.DataTextField = "Description";
                ddlcMajor.DataValueField = "ID";
                ddlcMajor.DataSource = Major.SelectAll();
                ddlcMajor.DataBind();
                //ddlMajor.DataSource = Major.SelectAll();
                //ddlMajor.DataTextField = "Description";
                //ddlMajor.DataValueField = "ID";
                //ddlMajor.DataBind();
                //ddlMajor.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetPosition()
        {
            try
            {
                Position = new PositionBL();
                ddlPosition.DataSource = Position.SelectAll(1);
                ddlPosition.DataTextField = "Description";
                ddlPosition.DataValueField = "ID";
                ddlPosition.DataBind();
                ddlPosition.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetDepartment()
        {
            try
            {
                career_Resume = new Career_ResumeBL();
                Department = new DepartmentBL();
                ddlDepartment.DataSource = Department.SelectAll(1);
                ddlDepartment.DataTextField = "Description";
                ddlDepartment.DataValueField = "ID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetBusinessType()
        {
            try
            {
                career_Resume = new Career_ResumeBL();
                DataTable dtb = career_Resume.SelectbyBusinessType();
                ddlctypeofbusinessnew.DataTextField = "Description";
                ddlctypeofbusinessnew.DataValueField = "ID";
                ddlctypeofbusinessnew.DataSource = dtb;
                ddlctypeofbusinessnew.DataBind();

                //ddltypeofbusinessnew.DataSource = dtb;
                //ddltypeofbusinessnew.DataTextField = "Description";
                //ddltypeofbusinessnew.DataValueField = "ID";
                //ddltypeofbusinessnew.DataBind();
                //ddltypeofbusinessnew.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetIndustry()
        {
            try
            {
                ddlindustrynew.DataSource = career_Resume.SelectedbyIndustry();
                ddlindustrynew.DataTextField = "Description";
                ddlindustrynew.DataValueField = "ID";
                ddlindustrynew.DataBind();
                ddlindustrynew.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetPositionnew()
        {
            try
            {
                Position = new PositionBL();
                ddldepartmentnew.DataSource = Department.SelectAll(1);
                ddldepartmentnew.DataTextField = "Description";
                ddldepartmentnew.DataValueField = "ID";
                ddldepartmentnew.DataBind();
                ddldepartmentnew.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetPositionLevel()
        {
            gb = new GlobalBL();
            ddlcpositionnewlevel.DataTextField = "Description";
            ddlcpositionnewlevel.DataValueField = "ID";
            ddlcpositionnewlevel.DataSource = gb.Get_Datanew("Position_Level");
            ddlcpositionnewlevel.DataBind();
            //ddlpositionnewlevel.DataSource = gb.Get_Datanew("Position_Level");
            //ddlpositionnewlevel.DataTextField = "Description";
            //ddlpositionnewlevel.DataValueField = "ID";
            //ddlpositionnewlevel.DataBind();
            //ddlpositionnewlevel.ClearSelection();
            //ddlpositionnewlevel.Items.Insert(0, "");
            //ddlpositionnewlevel.Text = "";

            ddlcpositionrequestedlevel.DataTextField = "Description";
            ddlcpositionrequestedlevel.DataValueField = "ID";
            ddlcpositionrequestedlevel.DataSource = gb.Get_Datanew("Position_Level");
            ddlcpositionrequestedlevel.DataBind();
            //ddlpositionrequestedlevel.DataSource = gb.Get_Datanew("Position_Level");
            //ddlpositionrequestedlevel.DataTextField = "Description";
            //ddlpositionrequestedlevel.DataValueField = "ID";
            //ddlpositionrequestedlevel.DataBind();
            //ddlpositionrequestedlevel.ClearSelection();
            //ddlpositionrequestedlevel.Items.Insert(0, "");
            //ddlpositionrequestedlevel.Text = "";
        }

        private void GetDepartmentnew()
        {
            Department = new DepartmentBL();
            try
            {
                ddlcpositionnew.DataTextField = "Description";
                ddlcpositionnew.DataValueField = "ID";
                ddlcpositionnew.DataSource = Position.SelectAll(1);
                ddlcpositionnew.DataBind();
                //ddlpositionnew.DataSource = Position.SelectAll(1);
                //ddlpositionnew.DataTextField = "Description";
                //ddlpositionnew.DataValueField = "ID";
                //ddlpositionnew.DataBind();
                //ddlpositionnew.Items.Insert(0, new ListItem(string.Empty, string.Empty));

                lstpositionrequested.DataSource = Position.SelectAll(1);
                lstpositionrequested.DataTextField = "Description";
                lstpositionrequested.DataValueField = "ID";
                lstpositionrequested.DataBind();
                //ddlpositionrequested.DataSource = Position.SelectAll(1);
                //ddlpositionrequested.DataTextField = "Description";
                //ddlpositionrequested.DataValueField = "ID";
                //ddlpositionrequested.DataBind();
                //ddlpositionrequested.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected void btnNew_Click1(object sender, EventArgs e)
        {
            try
            {
                Session["PageIndex1"] = gvCareerProfileView.PageCount;
                Response.Redirect("Career_Resume.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GetJapaneseRW()
        {
            gb = new GlobalBL();
            ddlcJapaneseRW.DataTextField = "Description";
            ddlcJapaneseRW.DataValueField = "ID";
            ddlcJapaneseRW.DataSource = gb.Get_DataOrderbyID("Language_Level");
            ddlcJapaneseRW.DataBind();
            //ddlJapaneseRW.Items.Clear();
            //ddlJapaneseRW.DataSource = gb.Get_DataOrderbyID("Language_Level");
            //ddlJapaneseRW.DataTextField = "Description";
            //ddlJapaneseRW.DataValueField = "ID";
            //ddlJapaneseRW.DataBind();
            //ddlJapaneseRW.Items.Insert(0, "");
        }

        protected void GetJapaneseSpeaking()
        {
            gb = new GlobalBL();
            ddlcJapaneseSpeaking.DataTextField = "Description";
            ddlcJapaneseSpeaking.DataValueField = "ID";
            ddlcJapaneseSpeaking.DataSource = gb.Get_DataOrderbyID("Language_Level");
            ddlcJapaneseSpeaking.DataBind();
            //ddlJapaneseSpeaking.DataSource = gb.Get_DataOrderbyID("Language_Level");
            //ddlJapaneseSpeaking.DataTextField = "Description";
            //ddlJapaneseSpeaking.DataValueField = "ID";
            //ddlJapaneseSpeaking.DataBind();
            //ddlJapaneseSpeaking.Items.Insert(0, "");
        }

        protected void GetEnglishRW()
        {
            gb = new GlobalBL();
            ddlcEnglishRW.DataTextField = "Description";
            ddlcEnglishRW.DataValueField = "ID";
            ddlcEnglishRW.DataSource = gb.Get_DataOrderbyID("Language_Level");
            ddlcEnglishRW.DataBind();
            //ddlEnglishRW.DataSource = gb.Get_DataOrderbyID("Language_Level");
            //ddlEnglishRW.DataTextField = "Description";
            //ddlEnglishRW.DataValueField = "ID";
            //ddlEnglishRW.DataBind();
            //ddlEnglishRW.Items.Insert(0, "");
        }

        protected void GetEnglishSpeaking()
        {
            gb = new GlobalBL();
            ddlcEnglishSpeaking.DataTextField = "Description";
            ddlcEnglishSpeaking.DataValueField = "ID";
            ddlcEnglishSpeaking.DataSource = gb.Get_DataOrderbyID("Language_Level");
            ddlcEnglishSpeaking.DataBind();
            //ddlEnglishSpeaking.DataSource = gb.Get_DataOrderbyID("Language_Level");
            //ddlEnglishSpeaking.DataTextField = "Description";
            //ddlEnglishSpeaking.DataValueField = "ID";
            //ddlEnglishSpeaking.DataBind();
            //ddlEnglishSpeaking.Items.Insert(0, "");
        }

        protected void GetBurmeseRW()
        {
            gb = new GlobalBL();
            ddlBurmeseRW.DataSource = gb.Get_DataOrderbyID("Language_Level");
            ddlBurmeseRW.DataTextField = "Description";
            ddlBurmeseRW.DataValueField = "ID";
            ddlBurmeseRW.DataBind();
            ddlBurmeseRW.Items.Insert(0, "");
        }

        protected void GetBurmeseSpeaking()
        {
            gb = new GlobalBL();
            ddlBurmeseSpeaking.DataSource = gb.Get_DataOrderbyID("Language_Level");
            ddlBurmeseSpeaking.DataTextField = "Description";
            ddlBurmeseSpeaking.DataValueField = "ID";
            ddlBurmeseSpeaking.DataBind();
            ddlBurmeseSpeaking.Items.Insert(0, "");
        }

        protected void GetInterviewer()
        {
            GlobalBL global = new GlobalBL();
            ddlfirsint.DataSource = global.Get_Datanew("Interviewer_Name");
            ddlfirsint.DataTextField = "Interviewer_Name";
            ddlfirsint.DataValueField = "ID";
            ddlfirsint.DataBind();
            ddlfirsint.ClearSelection();
            ddlfirsint.Items.Insert(0, "");
            ddlfirsint.Text = "";
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Career_WorkingPlaceBL careerworkingplace = new Career_WorkingPlaceBL();
            DataTable dt = new DataTable();
            dt = GetCareerResume();
            if ((dt != null && dt.Rows.Count > 0))
            {
                // Change encoding to Shift-JIS
                using (StreamWriter writer = new StreamWriter(Server.MapPath(ExportCSVPath + "Career_Resume_View.csv"), false, Encoding.GetEncoding(932)))
                {
                    dt.Columns.Remove("Career_ID");
                    dt.Columns.Remove("DOB");
                    dt.Columns.Remove("Religion_ID");
                    dt.Columns.Remove("Other_Religion");
                    dt.Columns.Remove("Requested_Position1_ID");
                    dt.Columns.Remove("Requested_Division2_ID");
                    dt.Columns.Remove("Requested_Division1_ID");
                    dt.Columns.Remove("Requested_Position2_ID");
                    dt.Columns.Remove("Requested_Division3_ID");
                    dt.Columns.Remove("Requested_Position3_ID");
                    dt.Columns.Remove("Availability_ID");
                    dt.Columns.Remove("Other_Availability");
                    dt.Columns.Remove("Driver_License");
                    dt.Columns.Remove("Other_Address");
                    dt.Columns.Remove("Occupation");
                    dt.Columns.Remove("Education");
                    dt.Columns.Remove("Education_ID");
                    dt.Columns.Remove("Other_Education");
                    dt.Columns.Remove("Qualification");
                    dt.Columns.Remove("Myanmar_Author_Comments");
                    dt.Columns.Remove("PC_SkillsID");
                    dt.Columns.Remove("Other_PCskills");
                    dt.Columns.Remove("InstitutionArea_ID");
                    dt.Columns.Remove("InstitutionName_ID");
                    dt.Columns.Remove("Other_Institution");
                    dt.Columns.Remove("Major_ID");
                    dt.Columns.Remove("Other_Major");
                    dt.Columns.Remove("Major_Reason");
                    dt.Columns.Remove("Job_ObjectiveID");
                    dt.Columns.Remove("Preferred_LocationID");
                    dt.Columns.Remove("Japanese_Author_Comments");
                    dt.Columns.Remove("English_RW_LevelID");
                    dt.Columns.Remove("English_Speaking_LevelID");
                    dt.Columns.Remove("Japanese_RW_LevelID");
                    dt.Columns.Remove("Japanese_Speaking_LevelID");
                    dt.Columns.Remove("Myanmar_Speaking_LevelID");
                    dt.Columns.Remove("Apprentice_AccuracyID");
                    dt.Columns.Remove("Working_PlaceID");
                    dt.Columns.Remove("Other_WorkingPlace");
                    dt.Columns.Remove("Period");
                    dt.Columns.Remove("StartDate");
                    dt.Columns.Remove("graduation_date");
                    dt.Columns.Remove("SituationID");
                    dt.Columns.Remove("IsDeleted");
                    dt.Columns.Remove("Department");
                    dt.Columns.Remove("Position");
                    dt.Columns.Remove("Situation");
                    dt.Columns.Remove("Myanmar_RW_LevelID");
                    dt.Columns.Remove("Myanmar_RW_Level");
                    dt.Columns.Remove("Myanmar_Speaking_Level");
                    dt.Columns.Remove("Township");
                    dt.Columns.Remove("Other_Qualification");
                    dt.Columns.Remove("PhoneNo1");
                    dt.Columns.Remove("JobIntroduction");
                    dt.AcceptChanges();
                    DataTable dtexport = dt.Copy();
                    for (int y = 0; y < dtexport.Rows.Count; y++)
                    {
                        if (dtexport.Columns.Contains("Availability_ID1"))
                        {
                            if (!String.IsNullOrWhiteSpace(dtexport.Rows[y]["Availability_ID1"].ToString()))
                            {
                                string change = dtexport.Rows[y]["Availability_ID1"].ToString();
                                switch (change)
                                {
                                    case "1":
                                        dtexport.Rows[y]["Starttime"] = "即日(Immediately)"; break;
                                    case "2":
                                        dtexport.Rows[y]["Starttime"] = "要１ヶ月(One month notice)"; break;
                                    case "3":
                                        dtexport.Rows[y]["Starttime"] = "その他(Others)"; break;
                                    case "4":
                                        dtexport.Rows[y]["Starttime"] = "1week notice"; break;
                                    case "5":
                                        dtexport.Rows[y]["Starttime"] = "2week notice"; break;
                                }
                            }
                        }
                    }
                    dtexport.Columns.Remove("Availability_ID1");
                    dtexport = ChangeHeader2(dtexport);
                    dtexport.AcceptChanges();
                    String csvdate = DateTime.Now.ToString("ddMMyyyy_HHmmss");
                    string ex = ".csv";
                    String filename = "Career_Resume_View" + "_" + csvdate + ex;
                    lnkdownload.Text = filename;
                    using (StreamWriter writers = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(ExportCSVPath + filename), false, Encoding.GetEncoding(932)))
                    {
                        WriteDataTable(dtexport, writers, true);
                    }
                }
            }
        }

        public DataTable ChangeHeader2(DataTable dt)
        {
            dt.Columns["Career_Code"].ColumnName = "登録番号";
            dt.Columns["Name"].ColumnName = "名前";
            dt.Columns["Gender"].ColumnName = "性別";
            dt.Columns["Area"].ColumnName = "現住所";
            dt.Columns["ph1"].ColumnName = "電話番号1";
            dt.Columns["email"].ColumnName = "メールアドレス";
            dt.Columns["religious"].ColumnName = "宗教";
            dt.Columns["major"].ColumnName = "専攻";
            dt.Columns["Salary"].ColumnName = "希望給与";
            dt.Columns["Working"].ColumnName = "希望勤務地";
            dt.Columns["Age"].ColumnName = "年齢";
            dt.Columns["sitution"].ColumnName = "現在の状況";
            dt.Columns["Starttime"].ColumnName = "希望勤務開始時期";
            dt.Columns["English_RW_Level"].ColumnName = "英語読み書き";
            dt.Columns["English_Speaking_Level"].ColumnName = "英語会話";
            dt.Columns["Japanese_RW_Level"].ColumnName = "日本語読み書き ";
            dt.Columns["Japanese_Speaking_Level"].ColumnName = "日本語会話";
            dt.Columns["ctdate"].ColumnName = "登録日";
            return dt;
        }

        public DataTable ChangeHeader(DataTable dt)
        {
            dt.Columns["Career_Code"].ColumnName = "登録番号";
            dt.Columns["Name"].ColumnName = "名前";
            dt.Columns["Gender"].ColumnName = "性別";
            dt.Columns["Area"].ColumnName = "現住所";
            dt.Columns["Salary"].ColumnName = "希望給与";
            dt.Columns["Age"].ColumnName = "年齢";
            dt.Columns["English_RW_Level"].ColumnName = "英語読み書き";
            dt.Columns["English_Speaking_Level"].ColumnName = "英語会話";
            dt.Columns["Japanese_RW_Level"].ColumnName = "日本語読み書き ";
            dt.Columns["Japanese_Speaking_Level"].ColumnName = "日本語会話";
            return dt;
        }

        public static void WriteDataTable(DataTable sourceTable, TextWriter writer, bool includeHeaders)
        {
            if (includeHeaders)
            {
                List<string> headerValues = new List<string>();
                foreach (DataColumn column in sourceTable.Columns)
                {
                    headerValues.Add(QuoteValue(column.ColumnName.ToLower()));
                }
                StringBuilder builder = new StringBuilder();
                writer.WriteLine(String.Join(",", headerValues.ToArray()));
            }
            string[] items = null;
            foreach (DataRow row in sourceTable.Rows)
            {
                items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();
                writer.WriteLine(String.Join(",", items));
            }
            writer.Flush();
        }

        private static string QuoteValue(string value)
        {
            return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
        }

        protected void lnkdownload_Click(object sender, EventArgs e)
        {
            try
            {
                Download(ExportCSVPath + lnkdownload.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Download(string filecheck)
        {
            try
            {
                if (File.Exists(Server.MapPath(filecheck)))
                {
                    string filename = lnkdownload.Text;
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    response.ContentType = "application/octet-stream";
                    byte[] data = req.DownloadData(Server.MapPath(filecheck));
                    response.BinaryWrite(data);
                    response.End();
                }
                else
                {
                    GlobalUI.MessageBox("File doesn't exist!");
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void Ability()
        {
            career_Resume = new Career_ResumeBL();
            DataSet ds = new DataSet();
            ds = career_Resume.SelectAbility();
            ds.Relations.Add(new DataRelation("Ability_Relation", ds.Tables[0].Columns["ID"], ds.Tables[1].Columns["AbilityTitle_id"], false));
            DLAbility.DataSource = ds.Tables[0];
            DLAbility.DataBind();
        }

        protected void DLAbility_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                ListBox LBAbililty = e.Item.FindControl("LBAbility") as ListBox;
                LBAbililty.SelectionMode = System.Web.UI.WebControls.ListSelectionMode.Multiple;
                LBAbililty.DataSource = drv.CreateChildView("Ability_Relation");
                LBAbililty.DataTextField = "AbilityDescription";
                LBAbililty.DataValueField = "Ability_ID";
                LBAbililty.DataBind();
            }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (ViewState["index"] == "index")
            {
                search = ViewState["search"].ToString();
                hdfsearch.Value = "page3";
            }
            else
            {
                search = "";
                string name = txtName.Text;
                string careercode = ddlcCode.SelectedValue.ToString();
                string careercode1 = txtCode.Text;
                string JapaneseRW = ddlcJapaneseRW.SelectedValue.ToString();
                string gender = ddlcSex.SelectedValue.ToString();
                Criteria.Career_Code = ddlcCode.SelectedValue.ToString() + '-' + txtCode.Text;
                Criteria.Career_Code1 = ddlcCode.SelectedValue.ToString();
                Criteria.Career_Code2 = txtCode.Text;
                if (!string.IsNullOrEmpty(name))
                {
                    search += (search == "" ? "" : " AND ") + " Name Like '%" + name.Trim() + "%' ";
                }

                if (!string.IsNullOrEmpty(careercode) && !string.IsNullOrEmpty(careercode1))
                {
                    search += (search == "" ? "" : " AND ") + "Career_Code = " + "'" + ddlcCode.SelectedValue + '-' + careercode1 + "'";
                }
                else
                {
                    if (!string.IsNullOrEmpty(careercode))
                    {
                        search += (search == "" ? "" : " AND ") + " Career_Code Like'%" + careercode + "%' ";
                    }
                    if (!string.IsNullOrEmpty(careercode1))
                    {
                        search += (search == "" ? "" : " AND ") + " Career_Code Like'%" + careercode1 + "%' ";
                    }
                }
                #region Language
                //if (ddlJapaneseRW.SelectedIndex > 0)
                //{
                //    if (chkJPRW.Checked)
                //    {
                //        search += (search == "" ? "" : " AND ") + "Japanese_RW_LevelID <=" + ddlJapaneseRW.SelectedValue + " AND " + "Japanese_RW_LevelID !=" + 0;
                //    }
                //    else
                //    {
                //        search += (search == "" ? "" : " AND ") + "Japanese_RW_LevelID =" + ddlJapaneseRW.SelectedValue;
                //    }
                //}
                //if (ddlJapaneseSpeaking.SelectedIndex > 0)
                //{
                //    if (chkJPSpeaking.Checked)
                //    {
                //        search += (search == "" ? "" : " AND ") + "Japanese_Speaking_LevelID <" + ddlJapaneseSpeaking.SelectedValue + " AND " + "Japanese_Speaking_LevelID!=" + 0;
                //    }
                //    else
                //    {
                //        search += (search == "" ? "" : " AND ") + "Japanese_Speaking_LevelID =" + ddlJapaneseSpeaking.SelectedValue;
                //    }
                //}
                //if (ddlEnglishRW.SelectedIndex > 0)
                //{
                //    if (chkEngRW.Checked)
                //    {
                //        search += (search == "" ? "" : " AND ") + "English_RW_LevelID <=" + ddlEnglishRW.SelectedValue + " AND " + "English_RW_LevelID !=" + 0;
                //    }
                //    else
                //    {
                //        search += (search == "" ? "" : " AND ") + "English_RW_LevelID =" + ddlEnglishRW.SelectedValue;
                //    }
                //}
                //if (ddlEnglishSpeaking.SelectedIndex > 0)
                //{
                //    if (chkEngSpeaking.Checked)
                //    {
                //        search += (search == "" ? "" : " AND ") + "English_Speaking_LevelID <=" + ddlEnglishSpeaking.SelectedValue + " AND " + "English_Speaking_LevelID!=" + 0;
                //    }
                //    else
                //    {
                //        search += (search == "" ? "" : " AND ") + "English_Speaking_LevelID =" + ddlEnglishSpeaking.SelectedValue;
                //    }
                //}
                #endregion
                if (ddlcJapaneseRW.SelectedIndex > 0)
                {
                    if (chkJPRW.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "Japanese_RW_LevelID <=" + ddlcJapaneseRW.SelectedValue + " AND " + "Japanese_RW_LevelID !=" + 0;
                    }
                    else
                    {
                        search += (search == "" ? "" : " AND ") + "Japanese_RW_LevelID =" + ddlcJapaneseRW.SelectedValue;
                    }
                }
                if (ddlcJapaneseSpeaking.SelectedIndex > 0)
                {
                    if (chkJPSpeaking.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "Japanese_Speaking_LevelID <" + ddlcJapaneseSpeaking.SelectedValue + " AND " + "Japanese_Speaking_LevelID!=" + 0;
                    }
                    else
                    {
                        search += (search == "" ? "" : " AND ") + "Japanese_Speaking_LevelID =" + ddlcJapaneseSpeaking.SelectedValue;
                    }
                }

                if (ddlcEnglishRW.SelectedIndex > 0)
                {

                    if (chkEngRW.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "English_RW_LevelID <=" + ddlcEnglishRW.SelectedValue + " AND " + "English_RW_LevelID !=" + 0;
                    }
                    else
                    {
                        search += (search == "" ? "" : " AND ") + "English_RW_LevelID =" + ddlcEnglishRW.SelectedValue;
                    }
                }
                if (ddlcEnglishSpeaking.SelectedIndex > 0)
                {
                    if (chkEngSpeaking.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "English_Speaking_LevelID <=" + ddlcEnglishSpeaking.SelectedValue + " AND " + "English_Speaking_LevelID!=" + 0;
                    }
                    else
                    {
                        search += (search == "" ? "" : " AND ") + "English_Speaking_LevelID =" + ddlcEnglishSpeaking.SelectedValue;
                    }
                }
                if (ddlcInstitution.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "InstitutionName_ID =" + ddlcInstitution.SelectedValue;
                }

                //added by nyisoe 20/05/2020
                if (ddlfirsint.SelectedIndex > 0)
                {

                    search += (search == "" ? "" : " AND ") + "ve.ID =" + ddlfirsint.SelectedValue;
                }

                if (ddlcMajor.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Major_ID =" + ddlcMajor.SelectedValue;
                }
                //if (ddltypeofbusinessnew.SelectedIndex > 0)
                //{
                //    search += (search == "" ? "" : " AND ") + "Bussiness_Type_ID =" + ddltypeofbusinessnew.SelectedValue;
                //}
                if (ddlctypeofbusinessnew.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Bussiness_Type_ID =" + ddlctypeofbusinessnew.SelectedValue;
                }
                //if (ddlpositionnew.SelectedIndex > 0)
                //{
                //    search += (search == "" ? "" : " AND ") + "(o.Position_ID =" + ddlpositionnew.SelectedValue + ")";
                //}
                if (ddlcpositionnew.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "(o.Position_ID =" + ddlcpositionnew.SelectedValue + ")";
                }
                //if (ddlpositionnewlevel.SelectedIndex > 0)
                //{
                //    search += (search == "" ? "" : " AND ") + "(o.Position_Level =" + ddlpositionnewlevel.SelectedValue + ")";
                //}
                if (ddlcpositionnewlevel.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "(o.Position_Level =" + ddlcpositionnewlevel.SelectedValue + ")";
                }
                //if (ddlpositionrequested.SelectedIndex > 0 && ddlpositionrequestedlevel.SelectedIndex > 0)
                //{
                //    search += (search == "" ? "" : " AND ") + "(e.Position_ID =" + ddlpositionrequested.SelectedValue + " AND " + "e.Position_Level1= " + ddlpositionrequestedlevel.SelectedValue + " OR " + "e.Position_ID1= " + ddlpositionrequested.SelectedValue + " AND " + "e.Position_Level2 = " + ddlpositionrequestedlevel.SelectedValue + " OR " + "e.Position_ID2= " + ddlpositionrequested.SelectedValue + " AND " + "e.Position_Level3= " + ddlpositionrequestedlevel.SelectedValue + ")";
                //}
                //else
                //{
                //    if (ddlpositionrequested.SelectedIndex > 0)
                //    {
                //        search += (search == "" ? "" : " AND ") + "(e.Position_ID  =" + ddlpositionrequested.SelectedValue + " OR " + "e.Position_ID1 =" + ddlpositionrequested.SelectedValue + " OR " + "e.Position_ID2 =" + ddlpositionrequested.SelectedValue + ")";
                //    }
                //    if (ddlpositionrequestedlevel.SelectedIndex > 0)
                //    {
                //        search += (search == "" ? "" : " AND ") + "(e.Position_Level1 =" + ddlpositionrequestedlevel.SelectedValue + "OR" + "e.Position_Level2= " + ddlpositionrequestedlevel.SelectedValue + "OR " + "e.Position_Level3= " + ddlpositionrequestedlevel.SelectedValue + ")";
                //    }
                //}
                String positionrequested = string.Empty;
                foreach (ListItem item in lstpositionrequested.Items)
                {
                    if (item.Selected)
                        positionrequested += item.Value + ",";
                }
                positionrequested = positionrequested.TrimEnd(',', ' ');
                if (lstpositionrequested.SelectedIndex >= 0 && ddlcpositionrequestedlevel.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "(e.Position_ID IN (SELECT * FROM dbo.StringSplit('" + positionrequested + "')) AND " + "e.Position_Level1= " + ddlcpositionrequestedlevel.SelectedValue + " OR " + "e.Position_ID1 IN (SELECT * FROM dbo.StringSplit('" + positionrequested + "')) AND " + "e.Position_Level2 = " + ddlcpositionrequestedlevel.SelectedValue + " OR " + "e.Position_ID2 IN (SELECT * FROM dbo.StringSplit('" + positionrequested + "')) AND " + "e.Position_Level3= " + ddlcpositionrequestedlevel.SelectedValue + ")";
                }
                else
                {
                    if (lstpositionrequested.SelectedIndex >= 0)
                    {
                        search += (search == "" ? "" : " AND ") + "(e.Position_ID IN (SELECT * FROM dbo.StringSplit('" + positionrequested + "')) OR " + "e.Position_ID1 IN (SELECT * FROM dbo.StringSplit('" + positionrequested + "')) OR " + "e.Position_ID2 IN (SELECT * FROM dbo.StringSplit('" + positionrequested + "')))";
                    }
                    if (ddlcpositionrequestedlevel.SelectedIndex > 0)
                    {
                        search += (search == "" ? "" : " AND ") + "(e.Position_Level1 = " + ddlcpositionrequestedlevel.SelectedValue + " OR " + "e.Position_Level2 = " + ddlcpositionrequestedlevel.SelectedValue + " OR " + "e.Position_Level3 = " + ddlcpositionrequestedlevel.SelectedValue + ")";
                    }
                }

                if (ddlcSex.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "GenderID =" + ddlcSex.SelectedValue;
                }
                if (LbTownship.SelectedValue != "")
                {
                    string township = null;
                    string townships = null;
                    string a = null;
                    for (int i = 0; i < LbTownship.Items.Count; i++)
                    {
                        if (LbTownship.Items[i].Selected)
                        {
                            townships += LbTownship.Items[i].Value.ToString() + ",";
                        }
                    }
                    township = townships;
                    string[] values = township.Split(',');
                    for (int i = 0; i < values.Length - 1; i++)
                    {
                        values[i] = values[i].Trim();
                        a += "Residential_AreaID= " + values[i] + " OR ";
                    }
                    var idx = a.LastIndexOf("OR");
                    a = a.Remove(idx);
                    search += (search == "" ? "" : " AND ") + "(" + a + ")";
                }
                if (Lbqualification.SelectedValue != "")
                {
                    string qualification = null;
                    string qualifications = null;
                    string a = null;
                    for (int i = 0; i < Lbqualification.Items.Count; i++)
                    {
                        if (Lbqualification.Items[i].Selected)
                        {
                            qualifications += Lbqualification.Items[i].Value.ToString() + ",";
                        }
                    }
                    qualification = qualifications;
                    string[] values = qualification.Split(',');
                    for (int i = 0; i < values.Length - 1; i++)
                    {
                        values[i] = values[i].Trim();
                        a += "Qualification_ID = " + values[i] + " OR ";
                    }
                    var idx = a.LastIndexOf("OR");
                    a = a.Remove(idx);
                    search += (search == "" ? "" : " AND ") + "(" + a + ")";
                }
                if (DLAbility.Items.Count > 0)
                {
                    string ability = null;
                    string a = null;
                    foreach (DataListItem dl in DLAbility.Items)
                    {
                        ListBox dlability = (ListBox)dl.FindControl("LBAbility");
                        if (dlability.SelectedValue != "")
                        {
                            for (int i = 0; i < dlability.Items.Count; i++)
                            {
                                if (dlability.Items[i].Selected)
                                {
                                    ability += dlability.Items[i].Value.ToString() + ",";
                                }
                            }
                            a = null;
                            string[] values = ability.Split(',');
                            for (int i = 0; i < values.Length - 1; i++)
                            {
                                values[i] = values[i].Trim();
                                a += "Ability_ID=" + values[i] + " OR ";
                            }
                        }
                    }
                    if (a != null)
                    {
                        var idx = a.LastIndexOf("OR");
                        if (idx != -1)
                        {
                            a = a.Remove(idx);
                            search += (search == "" ? "" : " AND ") + "(" + a + ")";
                        }
                    }
                }
                if (ddlcFromAge.SelectedIndex > 0 && ddlcToAge.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Age >=" + ddlcFromAge.SelectedValue + " AND " + "Age<=" + ddlcToAge.SelectedValue;
                }
                else if (ddlcFromAge.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Age >=" + ddlcFromAge.SelectedValue;
                }
                else if (ddlcToAge.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Age<=" + ddlcToAge.SelectedValue;
                }
                if (!string.IsNullOrEmpty(txtExpectedSalary.Text) && !string.IsNullOrEmpty(txtExpectedSalary2.Text))
                {
                    search += (search == "" ? "" : " AND ") + "Career_Salary.Salary>=" + txtExpectedSalary.Text + " AND " + " Career_Salary.Salary<" + txtExpectedSalary2.Text;
                }
                else if (!string.IsNullOrEmpty(txtExpectedSalary.Text))
                {
                    search += (search == "" ? "" : " AND ") + "Career_Salary.Salary>=" + txtExpectedSalary.Text;
                }
                else if (!string.IsNullOrEmpty(txtExpectedSalary2.Text))
                {
                    search += (search == "" ? "" : " AND ") + "Career_Salary.Salary<" + txtExpectedSalary2.Text;
                }
                if (ddlcsalarytype.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Career_Salary.Salary_Type=" + ddlcsalarytype.SelectedValue;
                }
                if (ddlcsalaryformat.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Career_Salary.Salary_Format=" + ddlcsalaryformat.SelectedValue;
                }
                    if (!string.IsNullOrEmpty(txtexperience.Text) && !string.IsNullOrEmpty(txtexperienceto.Text))
                    {
                        search += (search == "" ? "" : " AND ") + "tmp.Experience>=" + txtexperience.Text + " AND " + "tmp.Experience <" + txtexperienceto.Text;
                    }
                    else if (!string.IsNullOrEmpty(txtexperience.Text))
                    {
                        search += (search == "" ? "" : " AND ") + "tmp.Experience>=" + txtexperience.Text;
                    }
                    else if (!string.IsNullOrEmpty(txtexperienceto.Text))
                    {
                        search += (search == "" ? "" : " AND ") + "tmp.Experience<=" + txtexperienceto.Text;
                    }
                    //if (ddlexptype.SelectedIndex >= 0)
                    //{
                    //    if (Convert.ToInt32(ddlexptype.SelectedValue) == 1)
                    //    {
                    //        exp = ddlexptype.SelectedValue;
                    //    }
                    //    else
                    //    {
                    //        exp = ddlexptype.SelectedValue;
                    //    }
                    //}
                    if (ddlcexptype.SelectedIndex >= 0)
                    {
                        if (Convert.ToInt32(ddlcexptype.SelectedValue) == 1)
                        {
                            exp = ddlcexptype.SelectedValue;
                        }
                        else
                        {
                            exp = ddlcexptype.SelectedValue;
                        }
                    }
                    if (chkJobIntro.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "ci.Job_Introduction=1";
                    }
                    if (!String.IsNullOrEmpty(txttotalmark1.Text))
                    {
                        if (chktotalmark.Checked)
                        {
                            search += (search == "" ? "" : " AND ") + "TotalMark >=" + txttotalmark1.Text;
                        }
                        else
                        {
                            search += (search == "" ? "" : " AND ") + "TotalMark = " + txttotalmark1.Text;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(txtOther.Text))
                    {
                        search += (search == "" ? "" : " AND ") + "o.Other LIKE '%" + txtOther.Text.Trim() + "%'";
                    }

                    if (!string.IsNullOrWhiteSpace(txtImpression.Text))
                    {
                        search += (search == "" ? "" : " AND ") + "e.Impression LIKE '%" + txtImpression.Text.Trim() + "%'";
                    }

                    if (chkdomestic.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "Domestic=" + 1;
                    }
                    if (chkoversea.Checked)
                    {
                        search += (search == "" ? "" : " AND ") + "Career_Resume.Oversea=" + 1;
                    }
                    else
                    {
                        search += "";
                    }
                }
                e.InputParameters["exptype"] = exp;
                e.InputParameters["search"] = search;
            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            page = "1";
            Session["index"] = page;
            gvCareerProfileView.PageIndex = 0;
            gvCareerProfileView.DataBind();
            ViewState["search"] = search;
        }

        [WebMethod]
        public static List<string> GetOtherData(string other)
        {
            List<string> result = new List<string>();
            Career_ResumeBL career = new Career_ResumeBL();
            DataTable dt = career.GetOtherData(other);
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    string oth = row["Other"].ToString();
                    int oth_index = oth.IndexOf(other);
                    if (oth_index != -1)
                    {
                        int index = 0;
                        string oth_data;
                        if (oth.IndexOf(' ', oth_index) != -1)
                        {
                            index = oth.IndexOf(' ', oth_index);
                            oth_data = oth.Substring(oth_index, index - oth_index);
                        }
                        else
                        {
                            if (oth.IndexOf('.', oth_index) != -1)
                            {
                                index = oth.IndexOf('.', oth_index);
                                oth_data = oth.Substring(oth_index, index - oth_index);
                            }
                            else
                                oth_data = oth.Substring(oth_index, oth.Length - oth_index);
                        }
                        oth_data = Regex.Replace(oth_data, @"[^0-9a-zA-Z]+", "");
                        if (!result.Contains(string.Format("{0}*{1}", oth_data, oth_data)))
                            result.Add(string.Format("{0}*{1}", oth_data, oth_data));
                        result.Sort();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        [WebMethod]
        public static List<string> GetImpressionData(string impression)
        {
            List<string> result = new List<string>();
            Career_ResumeBL career = new Career_ResumeBL();
            DataTable dt = career.GetImpressionData(impression);
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    string imp = row["Impression"].ToString();
                    int imp_index = imp.IndexOf(impression);
                    if (imp_index != -1)
                    {
                        int index = 0;
                        string imp_data;
                        if (imp.IndexOf(' ', imp_index) != -1)
                        {
                            index = imp.IndexOf(' ', imp_index);
                            imp_data = imp.Substring(imp_index, index - imp_index);
                        }
                        else
                        {
                            if (imp.IndexOf('.', imp_index) != -1)
                            {
                                index = imp.IndexOf('.', imp_index);
                                imp_data = imp.Substring(imp_index, index - imp_index);
                            }
                            else
                                imp_data = imp.Substring(imp_index, imp.Length - imp_index);
                        }
                        imp_data = Regex.Replace(imp_data, @"[^0-9a-zA-Z]+", "");
                        if (!result.Contains(string.Format("{0}*{1}", imp_data, imp_data)))
                            result.Add(string.Format("{0}*{1}", imp_data, imp_data));
                        result.Sort();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}