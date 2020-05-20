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
    public partial class Ability : System.Web.UI.Page
    {
        AbilityBL abilitybl;
        AbilityEntity abilityInfo;
        AbilityTitleBL ablTitlebl;
        bool search = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll();
                GetTitle();
            }
        }

        private void SelectAll()
        {
            abilitybl = new AbilityBL();
            DataTable dt = new DataTable();
            dt = abilitybl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvAbility.DataSource = dt;
                gvAbility.DataBind();
            }
            else
            {
                gvAbility.DataSource = dt;
                gvAbility.DataBind();
            }
        }

        private void GetTitle()
        {
            ablTitlebl = new AbilityTitleBL();
            ddlAbilityTitle.DataSource = ablTitlebl.SelectAll(1);
            ddlAbilityTitle.DataTextField = "Description";
            ddlAbilityTitle.DataValueField = "ID";
            ddlAbilityTitle.DataBind();
            ddlAbilityTitle.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlAbilityTitle_SelectedIndexChange(object sender, EventArgs e)
        {
            if (int.Parse(ddlAbilityTitle.SelectedValue) == 0)
            {
                SelectAll();
            }
            else
                SelectByTitle(int.Parse(ddlAbilityTitle.SelectedValue));
        }

        private void SelectByTitle(int title_id)
        {
            abilitybl = new AbilityBL();
            DataTable dt = new DataTable();
            dt = abilitybl.SelectBytitle(title_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvAbility.DataSource = dt;
                gvAbility.DataBind();
            }
            else
            {
                gvAbility.DataSource = dt;
                gvAbility.DataBind();
            }
        }

        protected void gvAbility_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            Button btnedit = e.Row.FindControl("btnedit") as Button;
            Button btndelete = e.Row.FindControl("btndelete") as Button;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                btnedit.Visible = false;
                btndelete.Visible = false;
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                bool resultRead = user.CanRead(userID, "015");
                if (resultRead)
                {
                    btnedit.Visible = false;
                    btndelete.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "015");
                if (resultEdit)
                {
                    btnedit.Visible = true;
                }
                bool resultDelete = user.CanDelete(userID, "015");
                if (resultDelete)
                {
                    btndelete.Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                bool resultRead = user.CanRead(userID, "015");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "015");
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

        protected void gvAbility_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void gvAbility_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvAbility_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            abilityInfo = new AbilityEntity();
            abilitybl = new AbilityBL();
            abilityInfo.ID = Convert.ToInt16(((Label)gvAbility.Rows[e.RowIndex].FindControl("lblID")).Text);
            abilityInfo.Title_ID = int.Parse(ddlAbilityTitle.SelectedValue);
            if (abilityInfo.Title_ID == 0)
            {
                DataTable dt = abilitybl.GetTitleID(abilityInfo.ID);
                int ID = Convert.ToInt32(dt.Rows[0]["Department_ID"]);
                abilityInfo.Title_ID = ID;
            }
            abilityInfo.Description = ((TextBox)gvAbility.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = abilitybl.CheckExistingType(abilityInfo.ID, abilityInfo.Title_ID, abilityInfo.Description);
            if (result)
            {
                GlobalUI.MessageBox("This data has been already existed!");
            }
            else if (abilityInfo.ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(abilityInfo.Description) || BaseLib.IsInt(abilityInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(abilityInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number.");
                }
                else
                {
                    GlobalUI.MessageBox("Update Successfully");
                    abilitybl.Update(abilityInfo);
                }
            }
            else
            {
                abilitybl.Insert(abilityInfo);
            }
            if (search == false)
            {
                gvAbility.EditIndex = -1;
                SelectByTitle(int.Parse(ddlAbilityTitle.SelectedValue));
            }
            else
            {
                gvAbility.EditIndex = -1;
                SearchData();
            }
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (ddlAbilityTitle.SelectedItem.Value == "0")
            {
                if (search == false)
                {
                    SelectByTitle(int.Parse(ddlAbilityTitle.SelectedValue));
                    gvAbility.PageIndex = e.NewPageIndex;
                    gvAbility.DataBind();
                }
                else
                {
                    SearchData();
                    gvAbility.PageIndex = e.NewPageIndex;
                    gvAbility.DataBind();
                }
            }
            else
            {
                if (search == false)
                {
                    SelectByTitle(int.Parse(ddlAbilityTitle.SelectedValue));
                    gvAbility.PageIndex = e.NewPageIndex;
                    gvAbility.DataBind();
                }
                else
                {
                    SearchData();
                    gvAbility.PageIndex = e.NewPageIndex;
                    gvAbility.DataBind();
                }
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    AbilityBL abilitybl = new AbilityBL();
                    Button btn = (Button)e.CommandSource;
                    GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
                    Label id = (Label)grdrow.FindControl("lblid");
                    int bbID = Convert.ToInt32(id.Text);
                    if (bbID != 0)
                    {
                        DataTable dt = abilitybl.GetTitleID(bbID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int ID = Convert.ToInt32(dt.Rows[0]["AbilityTitle_id"]);
                            ddlAbilityTitle.SelectedValue = ID.ToString();
                        }
                    }
                    DataTable resultdt = new DataTable();
                    resultdt = SearchData();
                    gvAbility.DataBind();
                    int gvcount = resultdt.Rows.Count;
                    for (int i = 0; i < gvcount; i++)
                    {
                        if (Convert.ToInt32(resultdt.Rows[i]["ID"]) == bbID)
                        {
                            ((TextBox)gvAbility.FooterRow.FindControl("txtDescriptionSave")).Text = resultdt.Rows[i]["Description"].ToString();
                            ((TextBox)gvAbility.FooterRow.FindControl("txtDescriptionSave")).Focus();
                            Page.MaintainScrollPositionOnPostBack = false;
                            ((Button)gvAbility.FooterRow.FindControl("btnSave")).Text = "Update";
                            hdfID.Value = bbID.ToString();
                        }
                    }
                    ((Button)gvAbility.FooterRow.FindControl("btnCancel")).Visible = true;
                    break;
                case "Delete":
                    Button btnDelete = (Button)e.CommandSource;
                    GridViewRow grdrowfordel = ((GridViewRow)btnDelete.NamingContainer);
                    Label idfordel = (Label)grdrowfordel.FindControl("lblid");
                    abilitybl = new AbilityBL();
                    abilitybl.Delete(Convert.ToInt32(idfordel.Text));
                    GlobalUI.MessageBox("Record Deleted Successfully.");
                    if (search == false)
                    {
                        SelectByTitle(int.Parse(ddlAbilityTitle.SelectedValue));
                    }
                    else
                    {
                        SearchData();
                    }
                    break;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAll();
                ddlAbilityTitle.SelectedValue = "0";
            }
            else
            {
                SearchData();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ddlAbilityTitle.SelectedValue = "0";
            gvAbility.PageIndex = 0;
            SelectAll();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ((TextBox)gvAbility.FooterRow.FindControl("txtDescriptionSave")).Text = String.Empty;
            ((Button)gvAbility.FooterRow.FindControl("btnCancel")).Visible = false;
            ((Button)gvAbility.FooterRow.FindControl("btnSave")).Text = "Save";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            abilityInfo = new AbilityEntity();
            abilitybl = new AbilityBL();
            abilityInfo.Title_ID = int.Parse(ddlAbilityTitle.SelectedValue);
            string SaveorUpdate = ((Button)gvAbility.FooterRow.FindControl("btnSave")).Text;
            if (SaveorUpdate == "Update")
            {
                abilityInfo.ID = Convert.ToInt32(hdfID.Value);
                abilityInfo.Description = ((TextBox)gvAbility.FooterRow.FindControl("txtDescriptionSave")).Text;
                bool result = abilitybl.CheckExistingType(abilityInfo.ID, abilityInfo.Title_ID, abilityInfo.Description);
                if (result == true)
                    GlobalUI.MessageBox("This data has been already existed!");
                else if (abilityInfo.ID >= 1)
                {
                    if (string.IsNullOrWhiteSpace(abilityInfo.Description) || BaseLib.IsInt(abilityInfo.Description))
                    {
                        if (string.IsNullOrWhiteSpace(abilityInfo.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        abilitybl.Update(abilityInfo);
                        GlobalUI.MessageBox("Record Updated Successfully.");
                    }
                }
            }
            else
            {
                if (abilityInfo.Title_ID == 0)
                {
                    GlobalUI.MessageBox(" Please Select Title.");
                }
                else
                    abilityInfo.Description = ((TextBox)gvAbility.FooterRow.FindControl("txtDescriptionSave")).Text;
                bool existOrnot = abilitybl.CheckExistingType(0, abilityInfo.Title_ID, abilityInfo.Description);
                if (existOrnot == true)
                    GlobalUI.MessageBox("This data has been already existed.");
                else
                {
                    if (string.IsNullOrWhiteSpace(abilityInfo.Description) || BaseLib.IsInt(abilityInfo.Description))
                    {
                        if (string.IsNullOrWhiteSpace(abilityInfo.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");

                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        GlobalUI.MessageBox("Save Successfully");
                        abilitybl.Insert(abilityInfo);
                        gvAbility.PageIndex = 0;
                    }
                }
            }
            SelectByTitle(int.Parse(ddlAbilityTitle.SelectedValue));
        }

        protected DataTable SearchData()
        {
            abilitybl = new AbilityBL();
            DataTable dt = new DataTable();
            if (ddlAbilityTitle.SelectedItem.Value == "0")
            {
                dt = abilitybl.Search(int.Parse(ddlAbilityTitle.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvAbility.DataSource = dt;
                    gvAbility.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvAbility.DataSource = dt;
                    gvAbility.DataBind();
                }
            }
            else
            {
                dt = abilitybl.Search(int.Parse(ddlAbilityTitle.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvAbility.DataSource = dt;
                    gvAbility.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvAbility.DataSource = dt;
                    gvAbility.DataBind();
                }
            }
            return dt;
        }
    }
}