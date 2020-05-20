using JSAT.Reference;
using JSAT_BL;
using JSAT_BL.Reference;
using JSAT_Common;
using JSAT_Common.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Ability_Title : System.Web.UI.Page
    {
        AbilityTitleBL abltitlebl;
        AbilityTitleEntity ablTitleInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllData(0);
            }
        }

        protected void SelectAllData(int IDorDescription)
        {
            abltitlebl = new AbilityTitleBL();
            DataTable dt = new DataTable();
            dt = abltitlebl.SelectAll(IDorDescription);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvAblTitle.DataSource = dt;
                gvAblTitle.DataBind();
            }
            else
            {
                gvAblTitle.DataSource = dt;
                gvAblTitle.DataBind();
            }
        }

        protected void gvAblTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ablTitleInfo = new AbilityTitleEntity();
            abltitlebl = new AbilityTitleBL();
            ablTitleInfo.ID = Convert.ToInt16(((Label)gvAblTitle.Rows[e.RowIndex].FindControl("lblID")).Text);
            abltitlebl.Delete(ablTitleInfo.ID);
            if (search == false)
            {
                SelectAllData(0);
            }
            else
            {
                GlobalUI.MessageBox("Delete successfully");
                SearchData();
            }
        }

        protected void gvAblTitle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                gvAblTitle.EditIndex = -1;
                SelectAllData(0);
            }
            else
            {
                gvAblTitle.EditIndex = -1;
                SearchData();
            }
        }

        protected void gvAblTitle_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "072");
                bool resultEdit = user.CanSave(userID, "072");
                bool resultDelete = user.CanDelete(userID, "072");
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
                bool resultRead = user.CanRead(userID, "072");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "072");
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

        protected void gvAblTitle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CountryBL bbl = new CountryBL();
            hdfupdate.Value="update";
            if (search == false)
            {
                gvAblTitle.EditIndex = e.NewEditIndex;
                SelectAllData(0);
            }
            else
            {
                gvAblTitle.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }

        protected void gvAblTitle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ablTitleInfo = new AbilityTitleEntity();
            abltitlebl = new AbilityTitleBL();
            ablTitleInfo.ID = Convert.ToInt16(((Label)gvAblTitle.Rows[e.RowIndex].FindControl("lblID")).Text);
            ablTitleInfo.UpdatedBy = ablTitleInfo.ID;
            ablTitleInfo.Description = ((TextBox)gvAblTitle.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = abltitlebl.CheckExistingType(ablTitleInfo.ID, ablTitleInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(ablTitleInfo.Description) || JSAT_Common.BaseLib.IsInt(ablTitleInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(ablTitleInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                    abltitlebl.Update(ablTitleInfo);

                if (search == false)
                {
                    gvAblTitle.EditIndex = -1;
                    SelectAllData(0);
                }
                else
                {
                    gvAblTitle.EditIndex = -1;
                    GlobalUI.MessageBox("Update Successfully");
                    SearchData();
                }
            }
        }

        protected void SearchData()
        {
            abltitlebl = new AbilityTitleBL();
            DataTable dt = new DataTable();
            dt = abltitlebl.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvAblTitle.DataSource = dt;
                gvAblTitle.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvAblTitle.DataSource = dt;
                gvAblTitle.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ablTitleInfo = new AbilityTitleEntity();
            abltitlebl = new AbilityTitleBL();
            ablTitleInfo.Description = ((TextBox)gvAblTitle.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = abltitlebl.CheckExistingType(0, ablTitleInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(ablTitleInfo.Description) || ablTitleInfo.Description.Length > 200 || JSAT_Common.BaseLib.IsInt(ablTitleInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(ablTitleInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (ablTitleInfo.Description.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 characters.");
                }
                else
                {
                    GlobalUI.MessageBox("Save Successfully");
                    abltitlebl.Insert(ablTitleInfo);
                    gvAblTitle.PageIndex = 0;
                }
                SelectAllData(0);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAllData(0);
            }
            else
            {
                SearchData();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            SelectAllData(0);
            txtSearch.Text = string.Empty;
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                SelectAllData(0);
                gvAblTitle.PageIndex = e.NewPageIndex;
                gvAblTitle.DataBind();
            }
            else
            {
                SearchData();
                gvAblTitle.PageIndex = e.NewPageIndex;
                gvAblTitle.DataBind();
            }
        }
    }
}