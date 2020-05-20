using System;
using System.Collections;
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
    public partial class Client_Profile_View : System.Web.UI.Page
    {

        Client_ProfileBL clientProfile;
        GlobalBL globalBL;
        BusinessTypeBL businessType;
        string search;

        //Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsAsync)
            {
                clientProfile = new Client_ProfileBL();
                gvClient_Profile.DataBind();
                ClearViewStates();
                GetIndustryMajor();
                GetIndustrySmall();
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Session["PageIndex"] = gvClient_Profile.PageCount;
                Response.Redirect("~/Employer/Client_Profile.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvClient_Profile_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvClient_Profile.Rows.Count != 0)
                {
                    PopulateCheckedValues();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetTableWithBlankRows(DataTable Dt)
        {
            clientProfile = new Client_ProfileBL();
            DataTable dt = Dt;
            int RowCount = dt.Rows.Count;
            int Mod = RowCount % gvClient_Profile.PageSize;
            int NeededManualRows = gvClient_Profile.PageSize - Mod;
            return Dt;
        }

        protected void btnClientRecruitment_Click(object sender, EventArgs e)
        {
            try
            {
                int NoOfCheckedRows = 0;
                gvClient_Profile.AllowPaging = false;
                foreach (GridViewRow gvRow in gvClient_Profile.Rows)
                {
                    CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");

                    if (chkStatus.Checked)
                    {
                        NoOfCheckedRows++;
                    }
                }

                if (NoOfCheckedRows > 1 || NoOfCheckedRows < 1)
                {
                    GlobalUI.MessageBox("Please check one row.");
                    gvClient_Profile.AllowPaging = true;
                    return;
                }

                foreach (GridViewRow gvRow in gvClient_Profile.Rows)
                {
                    CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");

                    if (chkStatus.Checked)
                    {
                        int Client_ID = (int)gvClient_Profile.DataKeys[gvRow.RowIndex].Value;
                        Response.Redirect("Client_Recruitment.aspx?Client_ID=" + Client_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvClient_Profile.PageIndex = 0;
                gvClient_Profile.DataBind();
                ViewState["data"] = search;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvClient_Profile_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "Consent").ToString().ToLower() == "no")
                    {
                        e.Row.Cells[5].Text = String.Empty;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "Consent").ToString().ToLower() == "yes")
                    {
                        e.Row.Cells[5].Text = "○";
                    }
                }

                if (e.Row.RowType == DataControlRowType.Pager)
                {
                    int CurPage = gvClient_Profile.PageIndex + 1;
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

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["CHECKED_ITEMS"] = null;
            CheckBox chkAll = (CheckBox)gvClient_Profile.HeaderRow.FindControl("chkAll");

            if (chkAll.Checked)
            {
                foreach (GridViewRow gvRow in gvClient_Profile.Rows)
                {
                    if (gvClient_Profile.DataKeys[gvRow.RowIndex].Value.ToString() != "")
                    {
                        CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                        chkStatus.Checked = true;
                    }
                }
            }
            else
            {
                foreach (GridViewRow gvRow in gvClient_Profile.Rows)
                {
                    CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                    chkStatus.Checked = false;
                }
            }
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClient_Profile.PageIndex = e.NewPageIndex;
            search = ViewState["data"].ToString();
            ViewState["index"] = "index";
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            clientProfile = new Client_ProfileBL();
            DataTable dt = clientProfile.SelectAll();
            GlobalUI.ExportToCsv(dt);
        }

        protected void gvClient_Profile_OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataTable dataTable = ViewState["data"] as DataTable;
                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    dataView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                    dataTable = dataView.ToTable();

                    DataTable SortedData = dataTable;
                    ViewState["SortedData"] = SortedData;
                    gvClient_Profile.DataSource = SortedData;
                    gvClient_Profile.DataBind();

                }
                PopulateCheckedValues();
                ToggleCheckBoxes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "DESC";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void btnClientCV_Click(object sender, EventArgs e)
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
                    foreach (GridViewRow gvRow in gvClient_Profile.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");

                        if (chkStatus.Checked)
                        {
                            int Client_ID = (int)gvClient_Profile.DataKeys[gvRow.RowIndex].Value;
                            Response.Redirect("~/Employer/ClientCVHistory.aspx?Client_ID=" + Client_ID);
                        }
                    }
                }
            }

        }

        protected void gvClient_Profile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataEdit")
                {
                    Response.Redirect("~/Employer/Client_Profile.aspx?Client_ID=" + Convert.ToInt32(e.CommandArgument.ToString()));
                    // HiddenFieldID.Value = Convert.ToString(e.CommandArgument);
                }
                else if (e.CommandName == "DataDetail")
                {
                    Response.Redirect("~/Employer/Client_Information_Details.aspx?ClientID=" + Convert.ToInt32(e.CommandArgument.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlIndustryMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Client_ProfileBL cpbl = new Client_ProfileBL();
                ddlIndustrySmall.DataSource = cpbl.SelectByIndustryID(BaseLib.Convert_Int(ddlIndustryMajor.SelectedValue));
                ddlIndustrySmall.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Functions
        protected void BindGrid()
        {

        }

        private void PopulateCheckedValues()
        {
            #region Header CheckBox
            CheckBox chkAll = (CheckBox)gvClient_Profile.HeaderRow.FindControl("chkAll");
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
                foreach (GridViewRow gvrow in gvClient_Profile.Rows)
                {
                    if (gvClient_Profile.DataKeys[gvrow.RowIndex].Value.ToString() != "")
                    {
                        int index = (int)gvClient_Profile.DataKeys[gvrow.RowIndex].Value;
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
            CheckBox chkAll = (CheckBox)gvClient_Profile.HeaderRow.FindControl("chkAll");

            if (ViewState["HeaderCheckBox"] != null)
            {
                if ((bool)ViewState["HeaderCheckBox"])
                {
                    foreach (GridViewRow gvRow in gvClient_Profile.Rows)
                    {
                        CheckBox chkStatus = (CheckBox)gvRow.FindControl("chkStatus");
                        chkStatus.Checked = true;
                    }
                }
                else if (!(bool)ViewState["HeaderCheckBox"])
                {
                    foreach (GridViewRow gvRow in gvClient_Profile.Rows)
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

            for (int i = 0; i < gvClient_Profile.Rows.Count; i++)
            {
                if (gvClient_Profile.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)gvClient_Profile.Rows[i].Cells[0].FindControl("chkStatus");

                    if (chk != null)
                    {
                        if (chk.Checked)
                        {
                            selectedID.Add(Convert.ToInt16(gvClient_Profile.DataKeys[i].Value));
                        }
                    }
                }
            }
            return selectedID;
        }

        private void ClearViewStates()
        {
            ViewState["CHECKED_ITEMS"] = null;
            ViewState["HeaderCheckBox"] = null;
            ViewState["SortedData"] = null;
        }

        private void GetIndustryMajor()
        {
            try
            {
                globalBL = new GlobalBL();
                DataTable dtIndustryType = globalBL.Get_Data("Industry_Type");
                if (dtIndustryType != null)
                {
                    if (dtIndustryType.Rows.Count > 0)
                    {
                        ddlIndustryMajor.DataSource = globalBL.Get_Data("Industry_Type");
                        ddlIndustryMajor.DataTextField = "Description";
                        ddlIndustryMajor.DataValueField = "ID";
                        ddlIndustryMajor.DataBind();
                    }
                }
                ddlIndustryMajor.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetIndustrySmall()
        {
            try
            {
                businessType = new BusinessTypeBL();
                DataTable dtBusinessType = businessType.SelectAll();
                if (dtBusinessType != null)
                {
                    if (dtBusinessType.Rows.Count > 0)
                    {
                        ddlIndustrySmall.DataSource = dtBusinessType;
                        ddlIndustrySmall.DataTextField = "Description";
                        ddlIndustrySmall.DataValueField = "ID";
                        ddlIndustrySmall.DataBind();
                    }
                }
                ddlIndustrySmall.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (ViewState["index"] == "index")
            {
                search = ViewState["data"].ToString();
            }
            else
            {
                search = "";
                if (!String.IsNullOrEmpty(txtClientNo.Text))
                {
                    search += (search == "" ? "" : " AND ") + " Client_Code like '%" + txtClientNo.Text.Trim() + "%'";
                }
                if (!String.IsNullOrEmpty(txtName.Text))
                {
                    search += (search == "" ? "" : " AND ") + "Client_Name like '%" + txtName.Text.Trim() + "%'";
                }
                if (ddlIndustryMajor.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Industry_TypeID =" + ddlIndustryMajor.SelectedIndex;
                }
                if (ddlIndustrySmall.SelectedIndex > 0)
                {
                    search += (search == "" ? "" : " AND ") + "Business_TypeID = " + ddlIndustrySmall.SelectedIndex;
                }
                if (!String.IsNullOrEmpty(txtKey.Text))
                {
                    search += (search == "" ? "" : " AND ") + "Telephone_No like '%" + txtKey.Text.Trim() + "%'" + " OR " + "Location like '%" + txtKey.Text.Trim() + "%'" + " OR " + "Remarks like '%" + txtKey.Text.Trim() + "%'";
                }
            }
            e.InputParameters["search"] = search;
        }
    }
}

