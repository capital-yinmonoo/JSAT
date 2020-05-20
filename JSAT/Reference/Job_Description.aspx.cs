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
    public partial class Job_Description : System.Web.UI.Page
    {
        JobDescription_BL descriptionbl;
        JobDescription_Entity descriptionentity;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPosition();
                SelectAll();
            }
        }
        private void SelectAll()
        {
            descriptionbl = new JobDescription_BL();
            DataTable dt = new DataTable();
            dt = descriptionbl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvjobdescription.DataSource = dt;
                gvjobdescription.DataBind();
            }
            else
            {
                gvjobdescription.DataSource = dt;
                gvjobdescription.DataBind();
            }
        }

        public void BindPosition()
        {
            PositionBL position = new PositionBL();
            ddlPosition.DataSource = position.SelectAll(1);
            ddlPosition.DataTextField = "Description";
            ddlPosition.DataValueField = "ID";
            ddlPosition.DataBind();
            ddlPosition.Items.Insert(0, new ListItem("--Select--", "0"));
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
            txtSearch.Text = string.Empty;
            ddlPosition.SelectedValue = "0";
            SelectAll();
            gvjobdescription.PageIndex = 0;
            gvjobdescription.DataBind();
        }

        protected void CreatedDateTime()
        {
            descriptionentity.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            Response.Write(descriptionentity.CreatedDate.ToString("dd/MM/yyyy"));
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (ddlPosition.SelectedItem.Value == "0")
            {
                if (search == false)
                {
                    SelectByPosition(int.Parse(ddlPosition.SelectedValue));
                    gvjobdescription.PageIndex = e.NewPageIndex;
                    gvjobdescription.DataBind();
                }
                else
                {
                    SearchData();
                    gvjobdescription.PageIndex = e.NewPageIndex;
                    gvjobdescription.DataBind();
                }
            }
            else
            {
                if (search == false)
                {
                    SelectByPosition(int.Parse(ddlPosition.SelectedValue));
                    gvjobdescription.PageIndex = e.NewPageIndex;
                    gvjobdescription.DataBind();
                }
                else
                {
                    SearchData();
                    gvjobdescription.PageIndex = e.NewPageIndex;
                    gvjobdescription.DataBind();
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ((TextBox)gvjobdescription.FooterRow.FindControl("txtDescriptionSave")).Text = String.Empty;
            ((Button)gvjobdescription.FooterRow.FindControl("btnCancel")).Visible = false;
            ((Button)gvjobdescription.FooterRow.FindControl("btnSave")).Text = "Save";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            descriptionbl = new JobDescription_BL();
            descriptionentity = new JobDescription_Entity();
            descriptionentity.PositionID = int.Parse(ddlPosition.SelectedValue);
            string SaveorUpdate = ((Button)gvjobdescription.FooterRow.FindControl("btnSave")).Text;
            if (SaveorUpdate == "Update")
            {
                descriptionentity.ID = Convert.ToInt32(hdfID.Value);
                if (descriptionentity.PositionID == 0)
                {
                    DataTable dt = descriptionbl.SelectByPosition(descriptionentity.ID);
                    int ID = Convert.ToInt32(dt.Rows[0]["Position_ID"]);
                    descriptionentity.PositionID = ID;
                }
                descriptionentity.CreatedBy = Convert.ToInt32(Session["UserID"]);
                descriptionentity.Description = ((TextBox)gvjobdescription.FooterRow.FindControl("txtDescriptionSave")).Text;
                ViewState["description"] = descriptionentity.Description;
                bool result = descriptionbl.CheckExistingType(descriptionentity.PositionID, descriptionentity.Description, descriptionentity.ID);
                if (result == true)
                    GlobalUI.MessageBox("This data has been already existed!");
                else if (descriptionentity.ID >= 1)
                {
                    if (string.IsNullOrWhiteSpace(descriptionentity.Description) || BaseLib.IsInt(descriptionentity.Description))
                    {
                        if (string.IsNullOrWhiteSpace(descriptionentity.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        if (descriptionbl.Update(descriptionentity))
                            GlobalUI.MessageBox("Record Updated Successfully.");
                        SelectByPosition(int.Parse(ddlPosition.SelectedValue));
                    }
                }
            }
            else
            {
                if (descriptionentity.PositionID == 0)
                {
                    GlobalUI.MessageBox(" Please Select Position.");
                }
                else
                {
                    descriptionentity.Description = ((TextBox)gvjobdescription.FooterRow.FindControl("txtDescriptionSave")).Text;
                    descriptionentity.PositionID = Convert.ToInt16(ddlPosition.SelectedValue);
                    bool result = descriptionbl.CheckExistingType(descriptionentity.PositionID, descriptionentity.Description, 0);
                    if (result == true)
                        GlobalUI.MessageBox("This data has been already existed!");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(descriptionentity.Description) || descriptionentity.Description.Length > 800 || BaseLib.IsInt(descriptionentity.Description))
                        {
                            if (string.IsNullOrWhiteSpace(descriptionentity.Description))
                                GlobalUI.MessageBox("Not Allow Empty String!");
                            else if (descriptionentity.Description.Length > 800)
                                GlobalUI.MessageBox("Maximum length is 200 charaters.");
                            else
                                GlobalUI.MessageBox("Not Allow Number!");
                        }
                        else
                        {
                            int id = Convert.ToInt32(Session["UserID"]);
                            descriptionentity.CreatedBy = id;
                            if (descriptionbl.Insert(descriptionentity))
                                GlobalUI.MessageBox("Saved Successfully.");
                            SelectByPosition(int.Parse(ddlPosition.SelectedValue));
                        }
                    }
                }
            }
        }

        protected void ddlPosition_SelectedIndexChange(object sender, EventArgs e)
        {
            int index = int.Parse(ddlPosition.SelectedValue);
            if (index == 0)
            {
                SelectAll();
            }
            else
                SelectByPosition(index);
        }

        private void SelectByPosition(int position_id)
        {
            descriptionbl = new JobDescription_BL();
            DataTable dt = new DataTable();
            dt = descriptionbl.SelectByPosition(position_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvjobdescription.DataSource = dt;
                gvjobdescription.DataBind();
            }
            else
            {
                gvjobdescription.DataSource = dt;
                gvjobdescription.DataBind();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    descriptionbl = new JobDescription_BL();

                    Button btn = (Button)e.CommandSource;
                    GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
                    Label id = (Label)grdrow.FindControl("lblid");
                    int bbID = Convert.ToInt32(id.Text);
                    if (bbID != 0)
                    {
                        DataTable dt = descriptionbl.GetPositionID(bbID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int ID = Convert.ToInt32(dt.Rows[0]["Position_ID"]);
                            ddlPosition.SelectedValue = ID.ToString();
                        }
                    }
                    DataTable resultdt = new DataTable();
                    resultdt = SearchData();
                    gvjobdescription.DataBind();
                    int gvcount = resultdt.Rows.Count;
                    for (int i = 0; i < gvcount; i++)
                    {
                        if (Convert.ToInt32(resultdt.Rows[i]["ID"]) == bbID)
                        {
                            ((TextBox)gvjobdescription.FooterRow.FindControl("txtDescriptionSave")).Text = resultdt.Rows[i]["Description"].ToString();
                            Page.MaintainScrollPositionOnPostBack = false;
                            ((TextBox)gvjobdescription.FooterRow.FindControl("txtDescriptionSave")).Focus();
                            ((Button)gvjobdescription.FooterRow.FindControl("btnSave")).Text = "Update";
                            hdfID.Value = bbID.ToString();
                        }
                    }
                    txtSearch.Text = "";//For Search-edit-viewall-edit sequence condition
                    ((Button)gvjobdescription.FooterRow.FindControl("btnCancel")).Visible = true;
                    break;
                case "Delete":
                    Button btnDelete = (Button)e.CommandSource;
                    GridViewRow grdrowfordel = ((GridViewRow)btnDelete.NamingContainer);
                    Label idfordel = (Label)grdrowfordel.FindControl("lblid");
                    descriptionbl = new JobDescription_BL();
                    descriptionbl.Delete(Convert.ToInt32(idfordel.Text));
                    GlobalUI.MessageBox("Record Deleted Successfully.");
                    if (search == false)
                    {
                        SelectByPosition(int.Parse(ddlPosition.SelectedValue));
                    }
                    else
                        SearchData();
                    break;
            }
        }

        protected void gvjobdescription_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (ID == 1)
                {
                    e.Row.Visible = false;
                }
                //hide Edit button
                bool resultRead = user.CanRead(userID, "012");
                if (resultRead)
                {
                    btnedit.Visible = false;
                    btndelete.Visible = false;

                }
                bool resultSave = user.CanSave(userID, "012");
                if (resultSave)
                {
                    btnedit.Visible = true;
                }
                bool resultDelete = user.CanDelete(userID, "012");
                if (resultDelete)
                {
                    btndelete.Visible = true;
                }
            }
            //hide Save Button
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                bool resultRead = user.CanRead(userID, "012");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "012");
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

        protected DataTable SearchData()
        {
            descriptionbl = new JobDescription_BL();
            DataTable dt = new DataTable();
            if (ddlPosition.SelectedItem.Value == "0")
            {
                dt = descriptionbl.Search(int.Parse(ddlPosition.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvjobdescription.DataSource = dt;
                    gvjobdescription.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvjobdescription.DataSource = dt;
                    gvjobdescription.DataBind();
                }
            }
            else
            {
                dt = descriptionbl.Search(int.Parse(ddlPosition.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvjobdescription.DataSource = dt;
                    gvjobdescription.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvjobdescription.DataSource = dt;
                    gvjobdescription.DataBind();
                }
            }
            return dt;
        }

        protected void gvjobdescription_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvjobdescription_RowEditing(Object sender, GridViewEditEventArgs e)
        {

        }
    }
}