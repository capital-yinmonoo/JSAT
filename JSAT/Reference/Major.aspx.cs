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
    public partial class Major : System.Web.UI.Page
    {
        MajorBL major;
        Major_Entity mentity;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();
            }
        }

        public void SelectAllData()
        {
            major = new MajorBL();
            DataTable dtmajor = new DataTable();
            dtmajor = major.SelectAll();
            if (dtmajor.Rows.Count < 1)
            {
                dtmajor.Rows.Add(0, 0, 0);
                gvMajor.DataSource = dtmajor;
                gvMajor.DataBind();
            }
            else
            {
                gvMajor.DataSource = dtmajor;
                gvMajor.DataBind();
            }
        }

        protected void gvMajor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            mentity = new Major_Entity();
            major = new MajorBL();
            mentity.ID = Convert.ToInt16(((Label)gvMajor.Rows[e.RowIndex].FindControl("lblID")).Text);
            mentity.Description = ((TextBox)gvMajor.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            ViewState["description"] = mentity.Description;
            bool result = major.CheckExistingType(mentity.ID, mentity.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else if (string.IsNullOrWhiteSpace(mentity.Description) || BaseLib.IsInt(mentity.Description))
            {
                if (string.IsNullOrWhiteSpace(mentity.Description))
                    GlobalUI.MessageBox("Not Allow Empty String!");
                else
                    GlobalUI.MessageBox("Not Allow Number!");
            }
            else
            {
                major.Update(mentity);
                GlobalUI.MessageBox("Update Successfully");
                gvMajor.EditIndex = -1;
                SearchData();
                gvMajor.DataBind();
            }
        }

        protected void gvMajor_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "013");
                bool resultEdit = user.CanSave(userID, "013");
                bool resultDelete = user.CanDelete(userID, "013");
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
                bool resultRead = user.CanRead(userID, "013");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "013");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAllData();
            }
            else
            {

                SearchData();
            }
        }

        public void SearchData()
        {
            major = new MajorBL();
            DataTable dtserch = new DataTable();
            dtserch = major.SearchData(txtSearch.Text);
            if (dtserch.Rows.Count < 1)
            {
                dtserch.Rows.Add(0, 0, 0);
                gvMajor.DataSource = dtserch;
                gvMajor.DataBind();
            }
            else
            {
                gvMajor.DataSource = dtserch;
                gvMajor.DataBind();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            gvMajor.PageIndex = 0;
            txtSearch.Text = String.Empty;
            SearchData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            mentity = new Major_Entity();
            major = new MajorBL();
            mentity.Description = ((TextBox)gvMajor.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = major.CheckExistingType(0, mentity.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(mentity.Description) || mentity.Description.Length > 200 || BaseLib.IsInt(mentity.Description))
                {
                    if (string.IsNullOrWhiteSpace(mentity.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (mentity.Description.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 charaters.");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    major.Insert(mentity);
                    GlobalUI.MessageBox("Save successfully");
                    gvMajor.PageIndex = 0;
                    gvMajor.DataBind();
                }
            }
            SearchData();
        }

        //protected void gvMajor_RowEditing(Object sender, GridViewEditEventArgs e)
        //{
        //    if (search == false)
        //    {
        //        SelectAllData();
        //        gvMajor.EditIndex = e.NewEditIndex;
        //    }
        //    else
        //    {
        //        gvMajor.EditIndex = e.NewEditIndex;
        //        SearchData();
        //    }
        //}
        protected void gvMajor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Industry_TypeBL Industry = new Industry_TypeBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvMajor.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                gvMajor.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }

        protected void gvMajor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                SelectAllData();
                gvMajor.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                gvMajor.EditIndex = -1;
                SearchData();
            }
        }

        protected void gvMajor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            mentity = new Major_Entity();
            major = new MajorBL();
            mentity.ID = Convert.ToInt16(((Label)gvMajor.Rows[e.RowIndex].FindControl("lblID")).Text);
            major.Delete(mentity.ID);
            if (search == false)
            {
                SelectAllData();
            }
            else
            {
                GlobalUI.MessageBox("Delete Successfully");
                SearchData();
            }
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                SelectAllData();
                gvMajor.PageIndex = e.NewPageIndex;
                gvMajor.DataBind();
            }
            else
            {
                SearchData();
                gvMajor.PageIndex = e.NewPageIndex;
                gvMajor.DataBind();
            }
        }
    }
}