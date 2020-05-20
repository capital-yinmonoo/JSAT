using JSAT_BL;
using JSAT_BL.Reference;
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
    public partial class Qualification : System.Web.UI.Page
    {
        QualificationBL qualification;
        Qualification_Entity qentity;
        QualificationTitleBL qtitle;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll(0);
                GetTitle();
            }
        }

        private void SelectAll(int QorCRV)
        {
            qualification = new QualificationBL();
            DataTable dt = new DataTable();
            dt = qualification.SelectAll(QorCRV);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvQualification.DataSource = dt;
                gvQualification.DataBind();
            }
            else
            {
                gvQualification.DataSource = dt;
                gvQualification.DataBind();
            }
        }

        private void GetTitle()
        {
            qtitle = new QualificationTitleBL();
            ddlQtitle.DataSource = qtitle.SelectAll(1);
            ddlQtitle.DataTextField = "Description";
            ddlQtitle.DataValueField = "ID";
            ddlQtitle.DataBind();
            ddlQtitle.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlQtitle_SelectedIndexChange(object sender, EventArgs e)
        {
            if (ddlQtitle.SelectedValue == "0")
                SelectAll(0);
            else
                SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
        }

        private void SelectByTitle(int title_id)
        {
            qualification = new QualificationBL();
            DataTable dt = new DataTable();
            dt = qualification.SelectBytitle(title_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvQualification.DataSource = dt;
                gvQualification.DataBind();
            }
            else
            {
                gvQualification.DataSource = dt;
                gvQualification.DataBind();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    QualificationBL qualification = new QualificationBL();
                    Button btn = (Button)e.CommandSource;
                    GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
                    Label id = (Label)grdrow.FindControl("lblid");
                    int bbID = Convert.ToInt32(id.Text);
                    if (bbID != 0)
                    {
                        DataTable dt = qualification.GetTitleID(bbID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int ID = Convert.ToInt32(dt.Rows[0]["QualificationTitle_id"]);
                            ddlQtitle.SelectedValue = ID.ToString();
                        }
                    }
                    DataTable resultdt = new DataTable();
                    resultdt = SearchData();
                    gvQualification.DataBind();
                    int gvcount = resultdt.Rows.Count;
                    for (int i = 0; i < gvcount; i++)
                    {
                        if (Convert.ToInt32(resultdt.Rows[i]["ID"]) == bbID)
                        {
                            ((TextBox)gvQualification.FooterRow.FindControl("txtDescriptionSave")).Text = resultdt.Rows[i]["Description"].ToString();
                            ((TextBox)gvQualification.FooterRow.FindControl("txtDescriptionSave")).Focus();
                            Page.MaintainScrollPositionOnPostBack = false;
                            ((Button)gvQualification.FooterRow.FindControl("btnSave")).Text = "Update";
                            hdfID.Value = bbID.ToString();
                        }
                    }
                    txtSearch.Text = "";//For Search-edit-viewall-edit sequence condition
                    ((Button)gvQualification.FooterRow.FindControl("btnCancel")).Visible = true;
                    break;
                case "Delete":
                    Button btnDelete = (Button)e.CommandSource;
                    GridViewRow grdrowfordel = ((GridViewRow)btnDelete.NamingContainer);
                    Label idfordel = (Label)grdrowfordel.FindControl("lblid");
                    qualification = new QualificationBL();
                    qualification.Delete(Convert.ToInt32(idfordel.Text));
                    GlobalUI.MessageBox("Record Deleted Successfully.");
                    if (search == false)
                    {
                        SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
                    }
                    else
                        SearchData();
                    break;
            }
        }

        protected void gvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //hide Edit button
                bool resultRead = user.CanRead(userID, "005");
                if (resultRead)
                {
                    btnedit.Visible = false;
                    btndelete.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "005");
                if (resultEdit)
                {
                    btnedit.Visible = true;
                }
                bool resultDelete = user.CanDelete(userID, "005");
                if (resultDelete)
                {
                    btndelete.Visible = true;
                }
            }
            //hide Save Button
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                bool resultRead = user.CanRead(userID, "005");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "005");
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

        protected void gvQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvQualification_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPosition_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            qentity = new Qualification_Entity();
            qualification = new QualificationBL();
            qentity.ID = Convert.ToInt16(((Label)gvQualification.Rows[e.RowIndex].FindControl("lblID")).Text);
            qentity.Title_ID = int.Parse(ddlQtitle.SelectedValue);
            if (qentity.Title_ID == 0)
            {
                DataTable dt = qualification.GetTitleID(qentity.ID);
                int ID = Convert.ToInt32(dt.Rows[0]["Department_ID"]);
                qentity.Title_ID = ID;
            }
            qentity.Description = ((TextBox)gvQualification.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = qualification.CheckExistingType(qentity.ID, qentity.Title_ID, qentity.Description);
            if (result)
            {
                GlobalUI.MessageBox(qentity.Description + " has been already existed.");
            }
            else if (qentity.ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(qentity.Description) || BaseLib.IsInt(qentity.Description))
                {
                    if (string.IsNullOrWhiteSpace(qentity.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number.");
                }
                else
                {
                    GlobalUI.MessageBox("Update Successfully");
                    qualification.Update(qentity);
                }
            }
            else
            {
                GlobalUI.MessageBox("Save successfully");
                qualification.Insert(qentity);
            }
            if (search == false)
            {
                gvQualification.EditIndex = -1;
                SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
            }
            else
            {
                gvQualification.EditIndex = -1;
                SearchData();
            }
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (ddlQtitle.SelectedItem.Value == "0")
            {
                if (search == false)
                {
                    SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
                    gvQualification.PageIndex = e.NewPageIndex;
                    gvQualification.DataBind();
                }
                else
                {
                    SelectAll(0);
                    gvQualification.PageIndex = e.NewPageIndex;
                    gvQualification.DataBind();
                }
            }
            else
            {
                if (search == false)
                {
                    SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
                    gvQualification.PageIndex = e.NewPageIndex;
                    gvQualification.DataBind();
                }
                else
                {
                    SearchData();
                    gvQualification.PageIndex = e.NewPageIndex;
                    gvQualification.DataBind();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ddlQtitle.SelectedValue = "0";
            gvQualification.PageIndex = 0;
            SelectAll(0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            qentity = new Qualification_Entity();
            qualification = new QualificationBL();
            qentity.Title_ID = int.Parse(ddlQtitle.SelectedValue);
            string SaveorUpdate = ((Button)gvQualification.FooterRow.FindControl("btnSave")).Text;
            if (SaveorUpdate == "Update")
            {
                qentity.ID = Convert.ToInt32(hdfID.Value);
                if (qentity.Title_ID == 0)
                {
                    DataTable dt = qualification.SelectBytitle(qentity.ID);
                    int ID = Convert.ToInt32(dt.Rows[0]["Title_ID"]);
                    qentity.Title_ID = ID;
                }
                qentity.Description = ((TextBox)gvQualification.FooterRow.FindControl("txtDescriptionSave")).Text;
                ViewState["description"] = qentity.Description;
                bool result = qualification.CheckExistingType(qentity.ID, qentity.Title_ID, qentity.Description);
                if (result == true)
                    GlobalUI.MessageBox(qentity.Description + " has been already existed.");
                else if (qentity.ID >= 1)
                {
                    if (string.IsNullOrWhiteSpace(qentity.Description) || BaseLib.IsInt(qentity.Description))
                    {
                        if (string.IsNullOrWhiteSpace(qentity.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        qualification.Update(qentity);
                        GlobalUI.MessageBox("Record Updated Successfully.");
                        SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
                    }
                }
            }
            else
            {
                if (qentity.Title_ID == 0)
                {
                    GlobalUI.MessageBox(" Please Select Qualification Title.");
                }
                else
                    qentity.Description = ((TextBox)gvQualification.FooterRow.FindControl("txtDescriptionSave")).Text;
                bool existOrnot = qualification.CheckExistingType(0, qentity.Title_ID, qentity.Description);
                if (existOrnot == true)
                    GlobalUI.MessageBox("This data has been already existed!");
                else
                {
                    if (string.IsNullOrWhiteSpace(qentity.Description) || BaseLib.IsInt(qentity.Description))
                    {
                        if (string.IsNullOrWhiteSpace(qentity.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        qualification.Insert(qentity);
                        GlobalUI.MessageBox("Save Successfully.");
                        gvQualification.PageIndex = 0;
                        SelectByTitle(int.Parse(ddlQtitle.SelectedValue));
                    }
                }
            }
        }

        protected DataTable SearchData()
        {
            qualification = new QualificationBL();
            DataTable dt = new DataTable();
            if (ddlQtitle.SelectedItem.Value == "0")
            {
                dt = qualification.Search(int.Parse(ddlQtitle.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvQualification.DataSource = dt;
                    gvQualification.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvQualification.DataSource = dt;
                    gvQualification.DataBind();
                }
            }
            else
            {
                dt = qualification.Search(int.Parse(ddlQtitle.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvQualification.DataSource = dt;
                    gvQualification.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvQualification.DataSource = dt;
                    gvQualification.DataBind();
                }
            }
            return dt;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ((TextBox)gvQualification.FooterRow.FindControl("txtDescriptionSave")).Text = String.Empty;
            ((Button)gvQualification.FooterRow.FindControl("btnCancel")).Visible = false;
            ((Button)gvQualification.FooterRow.FindControl("btnSave")).Text = "Save";
        }
    }
}