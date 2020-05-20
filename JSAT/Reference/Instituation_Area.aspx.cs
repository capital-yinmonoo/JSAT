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
    public partial class Instituation_Area : System.Web.UI.Page
    {
        Instituation_AreaBL instituation;
        Instituation_AreaEntity instituationInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllData();
            }
        }

        protected void gvInstituationArea_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            instituationInfo = new Instituation_AreaEntity();
            instituation = new Instituation_AreaBL();
            instituationInfo.ID = Convert.ToInt16(((Label)gvInstituationArea.Rows[e.RowIndex].FindControl("lblID")).Text);
            if (instituation.Delete(instituationInfo.ID)) GlobalUI.MessageBox("Delete Successfully!");
            if (search == false)
                SelectAllData();
            else
                SearchData();
        }

        protected void gvInstituationArea_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                gvInstituationArea.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                gvInstituationArea.EditIndex = -1;
                SearchData();
            }
        }

        //protected void gvInstituationArea_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    UserRoleBL user = new UserRoleBL();
        //    int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[2].Controls[0].Visible = false;//edit
        //        e.Row.Cells[2].Controls[2].Visible = false;//delete
        //        int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
        //        if (ID == 0)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        //hide Edit button
        //        bool resultRead = user.CanRead(userID, "004");
        //        if (resultRead)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = false;
        //            e.Row.Cells[2].Controls[2].Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "004");
        //        if (resultEdit)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = true;
        //        }
        //        bool resulteDelete = user.CanDelete(userID, "004");
        //        if (resulteDelete)
        //        {
        //            e.Row.Cells[2].Controls[2].Visible = true;
        //        }
        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        //hide Save Button
        //        bool resultRead = user.CanRead(userID, "004");
        //        Button btn = e.Row.FindControl("btnSave") as Button;
        //        if (resultRead)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "004");
        //        if (resultEdit)
        //        {
        //            e.Row.Visible = true;
        //        }
        //        else
        //        {
        //            e.Row.Visible = false;
        //        }
        //    }
        //}

        protected void gvInstituationArea_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "004");
                bool resultEdit = user.CanSave(userID, "004");
                bool resultDelete = user.CanDelete(userID, "004");
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
                bool resultRead = user.CanRead(userID, "004");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "004");
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

        //protected void gvInstituationArea_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    Instituation_AreaBL instituation = new Instituation_AreaBL();
        //    if (search == false)
        //    {
        //        gvInstituationArea.EditIndex = e.NewEditIndex;
        //        SelectAllData();
        //    }
        //    else
        //    {
        //        gvInstituationArea.EditIndex = e.NewEditIndex;
        //        SearchData();
        //    }
        //}

        protected void gvInstituationArea_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Industry_TypeBL Industry = new Industry_TypeBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvInstituationArea.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                gvInstituationArea.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }

        protected void gvInstituationArea_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            instituationInfo = new Instituation_AreaEntity();
            instituation = new Instituation_AreaBL();
            instituationInfo.ID = Convert.ToInt16(((Label)gvInstituationArea.Rows[e.RowIndex].FindControl("lblID")).Text);
            instituationInfo.Description = ((TextBox)gvInstituationArea.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = instituation.CheckExistingType(instituationInfo.ID, instituationInfo.Description);
            if (result == true)
                GlobalUI.MessageBox(instituationInfo.Description + " has been already existed.");
            else
            {
                if (string.IsNullOrWhiteSpace(instituationInfo.Description) || BaseLib.IsInt(instituationInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(instituationInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                    if (instituation.Update(instituationInfo)) GlobalUI.MessageBox("Update Successfully!");

                if (search == false)
                {
                    gvInstituationArea.EditIndex = -1;
                    SelectAllData();
                }
                else
                {
                    gvInstituationArea.EditIndex = -1;
                    SearchData();
                }
            }
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                SelectAllData();
                gvInstituationArea.PageIndex = e.NewPageIndex;
                gvInstituationArea.DataBind();
            }
            else
            {
                SearchData();
                gvInstituationArea.PageIndex = e.NewPageIndex;
                gvInstituationArea.DataBind();
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

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            SelectAllData();
            txtSearch.Text = string.Empty;
        }

        protected void SelectAllData()
        {
            instituation = new Instituation_AreaBL();
            DataTable dt = new DataTable();
            dt = instituation.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvInstituationArea.DataSource = dt;
                gvInstituationArea.PageIndex = 0;
                gvInstituationArea.DataBind();
            }
            else
            {
                gvInstituationArea.DataSource = dt;
                gvInstituationArea.PageIndex = 0;
                gvInstituationArea.DataBind();
            }
        }

        protected void SearchData()
        {
            instituation = new Instituation_AreaBL();
            DataTable dt = new DataTable();
            dt = instituation.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvInstituationArea.DataSource = dt;
                gvInstituationArea.DataBind();

            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvInstituationArea.DataSource = dt;
                gvInstituationArea.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            instituationInfo = new Instituation_AreaEntity();
            instituation = new Instituation_AreaBL();
            instituationInfo.Description = ((TextBox)gvInstituationArea.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = instituation.CheckExistingType(0, instituationInfo.Description);
            if (result == true)
                GlobalUI.MessageBox(instituationInfo.Description + " has been already existed.");
            else
            {
                if (string.IsNullOrWhiteSpace(instituationInfo.Description) || instituationInfo.Description.Length > 200 || BaseLib.IsInt(instituationInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(instituationInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (instituationInfo.Description.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 charaters.");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                    if (instituation.Insert(instituationInfo)) GlobalUI.MessageBox("Record Saved Successfully!");
            }
            SelectAllData();
        }
    }
}