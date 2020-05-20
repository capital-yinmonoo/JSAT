using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Business_Type : System.Web.UI.Page
    {
        Industry_TypeBL Industry;
        BusinessTypeBL business;
        BusinessTypeEntity businessInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllData();
                Get_IndustryData();
            }
        }

        protected void Get_IndustryData()
        {
            Industry = new Industry_TypeBL();
            ddlIndustry.DataSource = Industry.SelectAll();
            ddlIndustry.DataTextField = "Description";
            ddlIndustry.DataValueField = "ID";
            ddlIndustry.DataBind();
            ddlIndustry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void gvBusinessType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvBusinessType_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvBusinessType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                gvBusinessType.EditIndex = -1;
                SelectByIndustry(int.Parse(ddlIndustry.SelectedValue));
            }
            else
            {
                gvBusinessType.EditIndex = -1;
                SearchData();
            }
        }

        protected void gvBusinessType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            UserRoleBL user = new UserRoleBL();
            Button btnedit = e.Row.FindControl("btnedit") as Button;
            Button btndelete = e.Row.FindControl("btndelete") as Button;
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                btnedit.Visible = false;
                btndelete.Visible = false;
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                //hide Edit button
                bool resultRead = user.CanRead(userID, "016");
                if (resultRead)
                {
                    btnedit.Visible = false;
                    btndelete.Visible = false;
                }
                bool resultDelete = user.CanDelete(userID, "016");
                if (resultDelete)
                {

                    btndelete.Visible = true;
                }
                bool resultEdit = user.CanSave(userID, "016");
                if (resultEdit)
                {
                    btnedit.Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // hide Save Button
                bool resultRead = user.CanRead(userID, "016");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "016");
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

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    BusinessTypeBL bbl = new BusinessTypeBL();
                    Button btn = (Button)e.CommandSource;
                    GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
                    Label id = (Label)grdrow.FindControl("lblid");

                    int bbID = Convert.ToInt32(id.Text);
                    if (bbID != 0)
                    {
                        DataTable dt = bbl.GetIndustryType(bbID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int ID = Convert.ToInt32(dt.Rows[0]["IndustryType_ID"]);
                            ddlIndustry.SelectedValue = ID.ToString();
                        }
                    }
                    DataTable resultdt = new DataTable();
                    resultdt = SearchData();
                    gvBusinessType.DataBind();
                    int gvcount = resultdt.Rows.Count;
                    for (int i = 0; i < gvcount; i++)
                    {
                        if (Convert.ToInt32(resultdt.Rows[i]["ID"]) == bbID)
                        {
                            ((TextBox)gvBusinessType.FooterRow.FindControl("txtDescriptionSave")).Text = resultdt.Rows[i]["Description"].ToString();
                            ((TextBox)gvBusinessType.FooterRow.FindControl("txtDescriptionSave")).Focus();
                            Page.MaintainScrollPositionOnPostBack = false;
                            ((Button)gvBusinessType.FooterRow.FindControl("btnSave")).Text = "Update";
                            hdfID.Value = bbID.ToString();
                        }
                    }
                    txtSearch.Text = "";//For Search-edit-viewall-edit sequence condition
                    ((Button)gvBusinessType.FooterRow.FindControl("btnCancel")).Visible = true;
                    break;
                case "Delete":
                    Button btnDelete = (Button)e.CommandSource;
                    GridViewRow grdrowfordel = ((GridViewRow)btnDelete.NamingContainer);
                    Label idfordel = (Label)grdrowfordel.FindControl("lblid");
                    business = new BusinessTypeBL();
                    business.Delete(Convert.ToInt32(idfordel.Text));
                    GlobalUI.MessageBox("Record Deleted Successfully.");
                    if (search == false)
                    {
                        SelectByIndustry(int.Parse(ddlIndustry.SelectedValue));
                    }
                    else
                        SearchData();
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            businessInfo = new BusinessTypeEntity();
            business = new BusinessTypeBL();
            businessInfo.Industry_ID = int.Parse(ddlIndustry.SelectedValue);
            string SaveorUpdate = ((Button)gvBusinessType.FooterRow.FindControl("btnSave")).Text;
            if (SaveorUpdate == "Update")
            {
                businessInfo.ID = Convert.ToInt32(hdfID.Value);
                if (businessInfo.Industry_ID == 0)
                {
                    DataTable dt = business.GetByIndustryID(businessInfo.ID);
                    int ID = Convert.ToInt32(dt.Rows[0]["IndustryType_ID"]);
                    businessInfo.Industry_ID = ID;
                }
                businessInfo.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                businessInfo.Description = ((TextBox)gvBusinessType.FooterRow.FindControl("txtDescriptionSave")).Text;
                ViewState["description"] = businessInfo.Description;
                bool result = business.CheckExistingType(businessInfo.Industry_ID, businessInfo.Description, businessInfo.ID);
                if (result == true)
                    GlobalUI.MessageBox(businessInfo.Description + " type has been already existed.");
                else if (businessInfo.ID >= 1)
                {
                    if (string.IsNullOrWhiteSpace(businessInfo.Description) || BaseLib.IsInt(businessInfo.Description))
                    {
                        if (string.IsNullOrWhiteSpace(businessInfo.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        CreatedDateTime();
                        business.Update(businessInfo);
                        GlobalUI.MessageBox("Record Updated Successfully.");
                    }
                }
            }
            else
            {
                if (businessInfo.Industry_ID == 0)
                {
                    GlobalUI.MessageBox("Please Select Industry!!");
                    SelectAllData();
                }
                else
                {
                    businessInfo.Description = ((TextBox)gvBusinessType.FooterRow.FindControl("txtDescriptionSave")).Text;

                    bool result = business.CheckExistingType(businessInfo.Industry_ID, businessInfo.Description, 0);
                    if (result == true)
                        GlobalUI.MessageBox("This business has been already existed.");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(businessInfo.Description) || BaseLib.IsInt(businessInfo.Description))
                        {
                            if (string.IsNullOrWhiteSpace(businessInfo.Description))
                                GlobalUI.MessageBox("Not Allow Empty String!");
                            else
                                GlobalUI.MessageBox("Not Allow Number!");
                        }
                        else
                        {
                            CreatedDateTime();
                            int id = Convert.ToInt32(Session["UserID"]);
                            businessInfo.CreatedBy = id;
                            business.Insert(businessInfo);
                            GlobalUI.MessageBox("Saved Successfully.");
                            gvBusinessType.PageIndex = 0;
                        }
                    }
                }
            }
            SelectByIndustry(int.Parse(ddlIndustry.SelectedValue));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAllData();
                ddlIndustry.SelectedValue = "0";
            }
            else
            {
                SearchData();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            SelectAllData();
            ddlIndustry.SelectedValue = "0";
            txtSearch.Text = string.Empty;
            gvBusinessType.PageIndex = 0;
            gvBusinessType.DataBind();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ((TextBox)gvBusinessType.FooterRow.FindControl("txtDescriptionSave")).Text = String.Empty;
            ((Button)gvBusinessType.FooterRow.FindControl("btnCancel")).Visible = false;
            ((Button)gvBusinessType.FooterRow.FindControl("btnSave")).Text = "Save";
        }

        protected void SelectAllData()
        {
            business = new BusinessTypeBL();
            DataTable dt = new DataTable();
            dt = business.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvBusinessType.DataSource = dt;
                gvBusinessType.DataBind();
            }
            else
            {
                gvBusinessType.DataSource = dt;
                gvBusinessType.DataBind();
            }
        }

        protected DataTable SearchData()
        {
            business = new BusinessTypeBL();
            DataTable dt = new DataTable();
            dt = business.Search(int.Parse(ddlIndustry.SelectedValue), txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvBusinessType.DataSource = dt;
                gvBusinessType.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvBusinessType.DataSource = dt;
                gvBusinessType.DataBind();
            }
            return dt;
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (ddlIndustry.SelectedItem.Value == "0")
            {
                if (search == false)
                {
                    SelectByIndustry(int.Parse(ddlIndustry.SelectedValue));
                    gvBusinessType.PageIndex = e.NewPageIndex;
                    gvBusinessType.DataBind();
                }
                else
                {
                    SearchData();
                    gvBusinessType.PageIndex = e.NewPageIndex;
                    gvBusinessType.DataBind();
                }
            }
            else
            {
                if (search == false)
                {
                    SelectByIndustry(int.Parse(ddlIndustry.SelectedValue));
                    gvBusinessType.PageIndex = e.NewPageIndex;
                    gvBusinessType.DataBind();
                }
                else
                {
                    SearchData();
                    gvBusinessType.PageIndex = e.NewPageIndex;
                    gvBusinessType.DataBind();
                }
            }
        }

        protected void CreatedDateTime()
        {
            businessInfo.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            Response.Write(businessInfo.CreatedDate.ToString("dd/MM/yyyy"));
        }

        protected void ddlIndustry_SelectedIndexChange(object sender, EventArgs e)
        {
            if (int.Parse(ddlIndustry.SelectedValue) == 0)
            {
                SelectAllData();
            }
            else
                SelectByIndustry(int.Parse(ddlIndustry.SelectedValue));
        }

        protected void SelectByIndustry(int Industry_id)
        {
            business = new BusinessTypeBL();
            DataTable dt = new DataTable();
            dt = business.SelectByIndustryID(Industry_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvBusinessType.DataSource = dt;
                gvBusinessType.DataBind();
            }
            else
            {
                gvBusinessType.DataSource = dt;
                gvBusinessType.DataBind();
            }
        }
    }
}