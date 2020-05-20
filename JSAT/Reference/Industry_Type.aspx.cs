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
    public partial class Industry_Type : System.Web.UI.Page
    {
        Industry_TypeBL Industry;
        Industry_TypeEntity IndustryInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();
            }
        }

        protected void gvIndustryType_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            IndustryInfo = new Industry_TypeEntity();
            Industry = new Industry_TypeBL();
            IndustryInfo.ID = Convert.ToInt16(((Label)gvIndustry_Type.Rows[e.RowIndex].FindControl("lblID")).Text);
            Industry.Delete(IndustryInfo.ID);
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

        //protected void gvIndustryType_RowEditing(Object sender, GridViewEditEventArgs e)
        //{
        //    if (search == false)
        //    {
        //        SelectAllData();
        //        gvIndustry_Type.EditIndex = e.NewEditIndex;
        //    }
        //    else
        //    {
        //        gvIndustry_Type.EditIndex = e.NewEditIndex;
        //        SearchData();
        //    }
        //}

        protected void gvIndustryType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Industry_TypeBL Industry = new Industry_TypeBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvIndustry_Type.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                gvIndustry_Type.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }

        protected void gvIndustryType_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            IndustryInfo = new Industry_TypeEntity();
            Industry = new Industry_TypeBL();
            IndustryInfo.ID = Convert.ToInt16(((Label)gvIndustry_Type.Rows[e.RowIndex].FindControl("lblID")).Text);
            IndustryInfo.Description = ((TextBox)gvIndustry_Type.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            ViewState["description"] = IndustryInfo.Description;
            bool result = Industry.CheckExistingType(IndustryInfo.ID, IndustryInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else if (string.IsNullOrWhiteSpace(IndustryInfo.Description) || BaseLib.IsInt(IndustryInfo.Description))
            {
                if (string.IsNullOrWhiteSpace(IndustryInfo.Description))
                    GlobalUI.MessageBox("Not Allow Empty String!");
                else
                    GlobalUI.MessageBox("Not Allow Number!");
            }
            else
            {
                Industry.Update(IndustryInfo);
                GlobalUI.MessageBox("Update successfully");
            }
            gvIndustry_Type.EditIndex = -1;
            SearchData();
        }


        protected void gvIndustryType_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                SelectAllData();
                gvIndustry_Type.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                gvIndustry_Type.EditIndex = -1;
                SearchData();
            }
        }

        //protected void gvIndustryType_RowDataBound(object sender, GridViewRowEventArgs e)
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
        //        bool resultRead = user.CanRead(userID, "003");
        //        if (resultRead)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = false;
        //            e.Row.Cells[2].Controls[2].Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "003");
        //        if (resultEdit)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = true;
        //        }
        //        bool resultDelete = user.CanDelete(userID, "003");
        //        if (resultDelete)
        //        {
        //            e.Row.Cells[2].Controls[2].Visible = true;
        //        }
        //    }
        //    //hide Save Button
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        bool resultRead = user.CanRead(userID, "003");
        //        Button btn = e.Row.FindControl("btnSave") as Button;
        //        if (resultRead)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "003");
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


        protected void gvIndustryType_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "003");
                bool resultEdit = user.CanSave(userID, "003");
                bool resultDelete = user.CanDelete(userID, "003");
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
                bool resultRead = user.CanRead(userID, "003");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "003");
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
            if (search == false)
            {
                SelectAllData();
                gvIndustry_Type.PageIndex = e.NewPageIndex;
                gvIndustry_Type.DataBind();
            }
            else
            {
                SearchData();
                gvIndustry_Type.PageIndex = e.NewPageIndex;
                gvIndustry_Type.DataBind();
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
            txtSearch.Text = string.Empty;
            gvIndustry_Type.PageIndex = 0;
            SearchData();
        }

        protected void SelectAllData()
        {
            Industry = new Industry_TypeBL();
            DataTable dt = new DataTable();
            dt = Industry.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvIndustry_Type.DataSource = dt;
                gvIndustry_Type.DataBind();
            }
            else
            {
                gvIndustry_Type.DataSource = dt;
                gvIndustry_Type.DataBind();
            }
        }

        protected void SearchData()
        {
            Industry = new Industry_TypeBL();
            DataTable dt = new DataTable();
            dt = Industry.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                SelectAllData();
                gvIndustry_Type.DataSource = dt;
                gvIndustry_Type.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvIndustry_Type.DataSource = dt;
                gvIndustry_Type.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IndustryInfo = new Industry_TypeEntity();
            Industry = new Industry_TypeBL();
            IndustryInfo.Description = ((TextBox)gvIndustry_Type.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = Industry.CheckExistingType(0, IndustryInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed");
            else
            {
                if (string.IsNullOrWhiteSpace(IndustryInfo.Description) || IndustryInfo.Description.Length > 200 || BaseLib.IsInt(IndustryInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(IndustryInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (IndustryInfo.Description.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 charaters.");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    Industry.Insert(IndustryInfo);
                    GlobalUI.MessageBox("Save Successfully");
                    gvIndustry_Type.DataBind();
                }
            }
            SearchData();
        }
    }
}