using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT_Ver1.Employer
{
    public partial class Client_Recruitment_View : System.Web.UI.Page
    {
        public static String sortBy = "Original";
        public static String columnName = String.Empty;
        Client_RecruitmentBL crbl = new Client_RecruitmentBL();
        public int count = 0;
        private int Client_RecruitmentID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(hfValue.Value))
            {
                String[] str = (hfValue.Value.Split('$'));
                if (str.Length == 3)
                {
                    txtName.Text = str[0];
                    txtClientNo.Text = str[1];
                }
            }

            if (!IsPostBack)
            {
                GlobalBL gb = new GlobalBL();
                ddlJPRW.DataSource = gb.Get_Data("Language_Level");
                ddlJPRW.DataTextField = "Description";
                ddlJPRW.DataValueField = "ID";
                ddlJPRW.DataBind();
                ddlJPRW.ClearSelection();
                ddlJPRW.Items.Insert(0, "");
                ddlJPRW.Text = "";

                ddlJPSpeaking.DataSource = gb.Get_Data("Language_Level");
                ddlJPSpeaking.DataTextField = "Description";
                ddlJPSpeaking.DataValueField = "ID";
                ddlJPSpeaking.DataBind();
                ddlJPSpeaking.ClearSelection();
                ddlJPSpeaking.Items.Insert(0, "");
                ddlJPSpeaking.Text = "";

                ddlEngRW.DataSource = gb.Get_Data("Language_Level");
                ddlEngRW.DataTextField = "Description";
                ddlEngRW.DataValueField = "ID";
                ddlEngRW.DataBind();

                ddlEngRW.ClearSelection();
                ddlEngRW.Items.Insert(0, "");
                ddlEngRW.Text = "";

                ddlEngSpeaking.DataSource = gb.Get_Data("Language_Level");
                ddlEngSpeaking.DataTextField = "Description";
                ddlEngSpeaking.DataValueField = "ID";
                ddlEngSpeaking.DataBind();

                ddlEngSpeaking.ClearSelection();
                ddlEngSpeaking.Items.Insert(0, "");
                ddlEngSpeaking.Text = "";

                ddlMnRW.DataSource = gb.Get_Data("Language_Level");
                ddlMnRW.DataTextField = "Description";
                ddlMnRW.DataValueField = "ID";
                ddlMnRW.DataBind();
                ddlMnRW.ClearSelection();
                ddlMnRW.Items.Insert(0, "");
                ddlMnRW.Text = "";

                ddlMnSpeaking.DataSource = gb.Get_Data("Language_Level");
                ddlMnSpeaking.DataTextField = "Description";
                ddlMnSpeaking.DataValueField = "ID";
                ddlMnSpeaking.DataBind();
                ddlMnSpeaking.ClearSelection();
                ddlMnSpeaking.Items.Insert(0, "");
                ddlMnSpeaking.Text = "";

                PositionBL pbl = new PositionBL();
                ddlPosition.DataSource = pbl.SelectAll(2);//not defined for 2 in stored procedure
                ddlPosition.DataTextField = "Description";
                ddlPosition.DataValueField = "ID";
                ddlPosition.DataBind();
                ddlPosition.Items.Insert(0, "");
                ddlPosition.Text = "";

                DataTable dt = crbl.SelectAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        HiddenField1.Value = dt.Rows.Count.ToString();
                        dgvClientRecruitment.DataSource = dt;
                        dgvClientRecruitment.DataBind();
                    }
                    else
                    {
                        dgvClientRecruitment.DataSource = dt;
                        dgvClientRecruitment.DataBind();
                    }
                }
            }

        }
        protected void lnkCareerInterview_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client_RecruitmentID != 0)
                {
                    DataTable dtClientRecruitment = crbl.SelectByID(Client_RecruitmentID);
                    int ClientID = int.Parse(dtClientRecruitment.Rows[0]["Client_ID"].ToString());
                    Response.Redirect("~/Employer/Job_Career_Interview.aspx?Client_RecruitmentID=" + Client_RecruitmentID + "&ClientID=" + ClientID);
                }
                else
                {
                    GlobalUI.MessageBox("Choose at least one row To Update");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvClientRecruitment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvClientRecruitment.PageIndex = e.NewPageIndex;
                if (!String.IsNullOrWhiteSpace(columnName))
                {
                    if (sortBy == "Desc")
                    {
                        sortBy = "Asc";
                    }
                    else if (sortBy == "Asc")
                    {
                        sortBy = "Original";
                    }
                    else if (sortBy == "Original")
                    {
                        sortBy = "Desc";
                    }

                    SortedWith(columnName);
                }

                else
                {
                    Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                    Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                    sr = FillForSearch();
                    dgvClientRecruitment.DataSource = crbl.SearchData(sr);
                    dgvClientRecruitment.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void dgvClientRecruitment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    DataRow row = ((DataRowView)e.Row.DataItem).Row;
                    Label lblData = (Label)e.Row.FindControl("lblJapaneseRWData");
                    if (String.IsNullOrWhiteSpace(DataBinder.Eval(e.Row.DataItem, "JpRW").ToString()))
                        lblData.Text = "-";

                    lblData = (Label)e.Row.FindControl("lblEnglishRWData");
                    if (String.IsNullOrWhiteSpace(DataBinder.Eval(e.Row.DataItem, "EngRW").ToString()))
                        lblData.Text = "-";

                    lblData = (Label)e.Row.FindControl("lblBurmeseRWData");
                    if (String.IsNullOrWhiteSpace(DataBinder.Eval(e.Row.DataItem, "MnRW").ToString()))
                        lblData.Text = "-";

                    lblData = (Label)e.Row.FindControl("lblJapaneseSpeakingData");
                    if (String.IsNullOrWhiteSpace(DataBinder.Eval(e.Row.DataItem, "JpSpeaking").ToString()))
                        lblData.Text = "-";

                    lblData = (Label)e.Row.FindControl("lblEnglishSpeakingData");
                    if (String.IsNullOrWhiteSpace(DataBinder.Eval(e.Row.DataItem, "EngSpeaking").ToString()))
                        lblData.Text = "-";

                    lblData = (Label)e.Row.FindControl("lblBurmeseSpeakingData");
                    if (String.IsNullOrWhiteSpace(DataBinder.Eval(e.Row.DataItem, "MnSpeaking").ToString()))
                        lblData.Text = "-";

                }
                if (e.Row.RowType == DataControlRowType.Pager)
                {
                    int CurPage = dgvClientRecruitment.PageIndex + 1;
                    TableCell sortCell = new TableCell();
                    sortCell.Text = string.Format("Current Page Number : {0} of Total Records : {1}&nbsp;&nbsp;", CurPage, HiddenField1.Value.ToString());
                    Table tbl = (Table)e.Row.Cells[0].Controls[0];
                    tbl.Rows[0].Cells.AddAt(0, sortCell);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDepartment_SelectedIndexChange(object sender, EventArgs e)
        {


        }

        protected void dgvClientRecruitment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataEdit")
                {

                    int ID = Convert.ToInt32(e.CommandArgument.ToString());
                    DataTable dt = new DataTable();
                    dt = crbl.SelectByID(ID);
                    if (dt.Rows.Count > 0)
                    {
                        int Client_ID = int.Parse(dt.Rows[0]["Client_ID"].ToString());
                        Response.Redirect("~/Employer/Client_Recruitment.aspx?Client_ID=" + Client_ID + "&Client_Recruitment_ID=" + ID);
                    }

                    // HiddenFieldID.Value = Convert.ToString(e.CommandArgument);
                }
                else if (e.CommandName == "DataDetail")
                {
                    int ID = Convert.ToInt32(e.CommandArgument.ToString());
                    DataTable dt = new DataTable();
                    dt = crbl.SelectByID(ID);
                    if (dt.Rows.Count > 0)
                    {
                        int Client_ID = int.Parse(dt.Rows[0]["Client_ID"].ToString());
                        Response.Redirect("~/Employer/Client_Recruitment_Detail.aspx?Client_ID=" + Client_ID + "&Client_Recruitment_ID=" + ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SortedWith(String column_Name)
        {
            if (sortBy == "Original")
            {
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                DataTable dt = new DataTable();
                Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                sr = FillForSearch();
                dt = crbl.SearchData(sr);
                DataView dv = new DataView(dt);
                dv.Sort = column_Name + " ASC";
                dt = dv.ToTable();
                dgvClientRecruitment.DataSource = dt;
                dgvClientRecruitment.DataBind();
                sortBy = "Asc";
            }
            else if (sortBy == "Asc")
            {
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                DataTable dt = new DataTable();
                Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                sr = FillForSearch();
                dt = crbl.SearchData(sr);
                DataView dv = new DataView(dt);
                dv.Sort = column_Name + " DESC";
                dt = dv.ToTable();
                dgvClientRecruitment.DataSource = dt;
                dgvClientRecruitment.DataBind();
                sortBy = "Desc";
            }
            else if (sortBy == "Desc")
            {
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                sr = FillForSearch();
                dgvClientRecruitment.DataSource = crbl.SearchData(sr);
                dgvClientRecruitment.DataBind();
                sortBy = "Original";
            }
        }

        protected void dgvClientRecruitment_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                columnName = e.SortExpression;
                SortedWith(e.SortExpression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearchData_Click(object sender, EventArgs e)
        {
            try
            {
                hfValue.Value = String.Empty;
                Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                sr = FillForSearch();
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                DataTable dt = crbl.SearchData(sr);
                dgvClientRecruitment.DataSource = dt;
                dgvClientRecruitment.DataBind();
                if (dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected Client_RecruitmentEntity.SearchRecruitment FillForSearch()
        {
            Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
            sr.Name = String.Empty;
            sr.ClientNo = null;
            sr.RecruitmentNo = null;
            sr.PersonInCharge = String.Empty;
            sr.ContactPhoneNo = String.Empty;
            sr.PositionID = null;
            sr.EngRW = null;
            sr.EngRWcheck = null;
            sr.EngSpeaking = null;
            sr.EngSpeakingcheck = null;
            sr.JpRW = null;
            sr.JpRWcheck = null;
            sr.JpSpeaking = null;
            sr.JpSpeakingcheck = null;
            sr.MnRW = null;
            sr.MnRWcheck = null;
            sr.MnSpeaking = null;
            sr.MnSpeakingcheck = null;
            sr.Wanted = false;

            if (!String.IsNullOrWhiteSpace(txtName.Text))
                sr.Name = txtName.Text;

            if (!String.IsNullOrWhiteSpace(txtClientNo.Text))
                sr.ClientNo = txtClientNo.Text;

            if (!String.IsNullOrWhiteSpace(txtRecruitmentNo.Text))
                sr.RecruitmentNo = txtRecruitmentNo.Text;

            if (!String.IsNullOrWhiteSpace(txtPersonInCharge.Text))
                sr.PersonInCharge = txtPersonInCharge.Text;

            if (!String.IsNullOrWhiteSpace(txtContactPhoneNo.Text))
                sr.ContactPhoneNo = txtContactPhoneNo.Text;

            if (!String.IsNullOrWhiteSpace(ddlPosition.SelectedValue))
                sr.PositionID = ddlPosition.SelectedValue;

            if (!String.IsNullOrWhiteSpace(ddlJPRW.SelectedValue))
            {
                if (chkJPRW.Checked)
                    sr.JpRWcheck = BaseLib.Convert_Int(ddlJPRW.SelectedValue);
                else sr.JpRW = BaseLib.Convert_Int(ddlJPRW.SelectedValue);
            }

            if (!String.IsNullOrWhiteSpace(ddlJPSpeaking.SelectedValue))
            {
                if (chkJPSpeaking.Checked)
                    sr.JpSpeakingcheck = BaseLib.Convert_Int(ddlJPSpeaking.SelectedValue);
                else sr.JpSpeaking = BaseLib.Convert_Int(ddlJPSpeaking.SelectedValue);
            }

            if (!String.IsNullOrWhiteSpace(ddlEngRW.SelectedValue))
            {
                if (chkEngRW.Checked)
                    sr.EngRWcheck = BaseLib.Convert_Int(ddlEngRW.SelectedValue);
                else sr.EngRW = BaseLib.Convert_Int(ddlEngRW.SelectedValue);
            }

            if (!String.IsNullOrWhiteSpace(ddlEngSpeaking.SelectedValue))
            {
                if (chkEngSpeaking.Checked)
                    sr.EngSpeakingcheck = BaseLib.Convert_Int(ddlEngSpeaking.SelectedValue);
                else sr.EngSpeaking = BaseLib.Convert_Int(ddlEngSpeaking.SelectedValue);
            }

            if (!String.IsNullOrWhiteSpace(ddlMnRW.SelectedValue))
            {
                if (chkMnRW.Checked)
                    sr.MnRWcheck = BaseLib.Convert_Int(ddlMnRW.SelectedValue);
                else sr.MnRW = BaseLib.Convert_Int(ddlMnRW.SelectedValue);
            }

            if (!String.IsNullOrWhiteSpace(ddlMnSpeaking.SelectedValue))
            {
                if (chkMnSpeaking.Checked)
                    sr.MnSpeakingcheck = BaseLib.Convert_Int(ddlMnSpeaking.SelectedValue);
                else sr.MnSpeaking = BaseLib.Convert_Int(ddlMnSpeaking.SelectedValue);
            }
            if (chkWanted.Checked)
                sr.Wanted = true;
            return sr;
        }

    }
}