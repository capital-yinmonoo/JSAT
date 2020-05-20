using JSAT_BL;
using JSAT_BL.Reference;
using JSAT_Common.Reference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_Common;

namespace JSAT_Ver1
{
    public partial class Company_Type : System.Web.UI.Page
    {
        Company_TypeBL companybl;
        Company_TypeEntity companyInfo;
        bool s = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll();
            }
        }

        protected void SelectAll()
        {
            companybl = new Company_TypeBL();
            DataTable dt = new DataTable();
            dt = companybl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvCompany_Type.DataSource = dt;
                gvCompany_Type.DataBind();
            }
            else
            {
                gvCompany_Type.DataSource = dt;
                gvCompany_Type.DataBind();
            }
        }

        protected void gvCompany_Type_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            companyInfo = new Company_TypeEntity();
            companybl = new Company_TypeBL();
            companyInfo.ID = Convert.ToInt16(((Label)gvCompany_Type.Rows[e.RowIndex].FindControl("lblID")).Text);
            companybl.Delete(companyInfo.ID);
            if (s == false)
            {
                SelectAllData();
            }
            else
            {
                GlobalUI.MessageBox("Delete Successfully");
                SearchData();
            }
        }

        protected void gvCompany_Type_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Company_TypeBL bbl = new Company_TypeBL();
            hdfupdate.Value = "update";

            gvCompany_Type.EditIndex = e.NewEditIndex;
            SearchData();
            hdfupdate.Value = "";
        }

        protected void gvCompany_Type_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            companyInfo = new Company_TypeEntity();
            companybl = new Company_TypeBL();
            companyInfo.ID = Convert.ToInt16(((Label)gvCompany_Type.Rows[e.RowIndex].FindControl("lblID")).Text);
            companyInfo.Company_Type = ((TextBox)gvCompany_Type.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result1 = companybl.CheckExistingType(companyInfo.ID, companyInfo.Company_Type);
            if (result1 == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else if (companyInfo.ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(companyInfo.Company_Type) || JSAT_Common.BaseLib.IsInt(companyInfo.Company_Type))
                {
                    if (string.IsNullOrWhiteSpace(companyInfo.Company_Type))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    companybl.Update(companyInfo);
                    GlobalUI.MessageBox("Update Successfully");
                }
            }
            else
            {
                companyInfo.Company_Type = ((TextBox)gvCompany_Type.FooterRow.FindControl("txtDescriptionSave")).Text;
                companybl.Insert(companyInfo);
            }
            gvCompany_Type.EditIndex = -1;
            SearchData();
        }

        protected void gvCompany_Type_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (s == false)
            {
                SelectAllData();
                gvCompany_Type.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                gvCompany_Type.EditIndex = -1;
                SearchData();
            }
        }


        protected void gvCompany_Type_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            JSAT_BL.UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkedit = (LinkButton)e.Row.FindControl("lnkedit");
                LinkButton lnkdelete = ((LinkButton)e.Row.FindControl("lnkDelete"));
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                //hide Edit button
                bool resultRead = user.CanRead(userID, "014");
                bool resultEdit = user.CanSave(userID, "014");
                bool resultDelete = user.CanDelete(userID, "014");
                if (resultRead)
                {
                    if (resultEdit)
                    {
                        if (hdfupdate.Value != "update")
                        {
                            lnkedit.Visible = true;//edit
                        }
                    }
                    else
                    {
                        lnkedit.Visible = false;
                    }
                    if (resultDelete)
                    {
                        if (hdfupdate.Value != "update")
                        {
                            lnkdelete.Visible = true;//delete
                        }
                    }
                    else
                    {
                        if (hdfupdate.Value != "update")
                        {
                            lnkdelete.Visible = false;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //hide Save Button
                bool resultRead = user.CanRead(userID, "014");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "014");
                if (resultEdit)
                {
                    e.Row.Visible = true;
                }
                else
                {
                    e.Row.Visible = false;
                }
            }
        }
        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (s == false)
            {
                SelectAllData();
                gvCompany_Type.PageIndex = e.NewPageIndex;
                gvCompany_Type.DataBind();
            }
            else
            {
                SearchData();
                gvCompany_Type.PageIndex = e.NewPageIndex;
                gvCompany_Type.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAll();
            }
            else
            {
                SearchData();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;
            SelectAll();
        }

        protected void SelectAllData()
        {
            companybl = new Company_TypeBL();
            DataTable dt = new DataTable();
            dt = companybl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvCompany_Type.DataSource = dt;
                gvCompany_Type.DataBind();
            }
            else
            {
                gvCompany_Type.DataSource = dt;
                gvCompany_Type.DataBind();
            }
        }

        protected void SearchData()
        {
            companybl = new Company_TypeBL();
            DataTable dt = new DataTable();
            dt = companybl.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                SelectAllData();
                gvCompany_Type.DataSource = dt;
                gvCompany_Type.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvCompany_Type.DataSource = dt;
                gvCompany_Type.DataBind();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            companyInfo = new Company_TypeEntity();
            companybl = new Company_TypeBL();
            companyInfo.Company_Type = ((TextBox)gvCompany_Type.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = companybl.CheckExistingType(0, companyInfo.Company_Type);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(companyInfo.Company_Type) || companyInfo.Company_Type.Length > 200 || JSAT_Common.BaseLib.IsInt(companyInfo.Company_Type))
                {
                    if (string.IsNullOrWhiteSpace(companyInfo.Company_Type))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (companyInfo.Company_Type.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 charaters.");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    bool check = companybl.Insert(companyInfo);
                    if (check)
                    {
                        GlobalUI.MessageBox("Instituation Name Save Successfully!!");
                    }
                    SelectAll();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            companyInfo = new Company_TypeEntity();
            companybl = new Company_TypeBL();
            companyInfo.ID = Convert.ToInt32(((DropDownList)gvCompany_Type.FooterRow.FindControl("ddlCompanyType")).SelectedValue);
            companyInfo.Country_ID = Convert.ToInt32(((DropDownList)gvCompany_Type.FooterRow.FindControl("ddlCountry")).SelectedValue);
            if (companyInfo.ID == 0 || companyInfo.ID == 0)
            {
                GlobalUI.MessageBox("Please Select Company Type or Company Type Country!!");
            }
            else
            {
                bool result = companybl.CheckExistingCompany_Type(companyInfo.ID, companyInfo.Country_ID);
                if (result == true)
                    GlobalUI.MessageBox("This Company Type and Country has been already Register!!!");
                else
                {
                    bool check = companybl.InsertCompanyType(companyInfo);
                    if (check)
                    {
                        GlobalUI.MessageBox("Company Type with Country Register Successfully!!");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Company_Type_Details.aspx','_newtab');", true);
                    }
                }
            }
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            if (row == null) { return; }

            else
            {
                if (gvCompany_Type.Rows.Count > 0)
                {
                    DropDownList ddl = gvCompany_Type.FooterRow.FindControl("ddlCountry") as DropDownList;
                    ddl.DataSource = GetData("SELECT * FROM Company_Type_Country where IsDeleted=0 order by Description asc");
                    ddl.DataTextField = "Description";
                    ddl.DataValueField = "ID";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
                    DropDownList ddlCompanyType = gvCompany_Type.FooterRow.FindControl("ddlCompanyType") as DropDownList;
                    ddlCompanyType.DataSource = GetData("SELECT * FROM Company_Type where IsDeleted=0 order by Description asc");
                    ddlCompanyType.DataTextField = "Description";
                    ddlCompanyType.DataValueField = "ID";
                    ddlCompanyType.DataBind();
                    ddlCompanyType.Items.Insert(0, new ListItem("--Select--", "0"));
                }
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

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Company_Type_Details.aspx','_newtab');", true);
        }
    }
}