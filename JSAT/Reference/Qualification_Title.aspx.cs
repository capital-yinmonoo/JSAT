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
    public partial class Qualification_Title : System.Web.UI.Page
    {
        QualificationTitleBL qtitlebl;
        QualificationTitleEntity qtitleInfo;
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
            qtitlebl = new QualificationTitleBL();
            DataTable dt = new DataTable();
            dt = qtitlebl.SelectAll(IDorDescription);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvQtitle.DataSource = dt;
                gvQtitle.DataBind();
            }
            else
            {
                gvQtitle.DataSource = dt;
                gvQtitle.DataBind();
            }
        }

        protected void gvQtitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            qtitleInfo = new QualificationTitleEntity();
            qtitlebl = new QualificationTitleBL();
            qtitleInfo.ID = Convert.ToInt16(((Label)gvQtitle.Rows[e.RowIndex].FindControl("lblID")).Text);
            qtitlebl.Delete(qtitleInfo.ID);
            if (search == false)
            {
                SelectAllData(0);
            }
            else
            {
                GlobalUI.MessageBox("Delete Successfully");
                SearchData();
            }
        }

        protected void gvQtitle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                gvQtitle.EditIndex = -1;
                SelectAllData(0);
            }
            else
            {
                gvQtitle.EditIndex = -1;
                SearchData();
            }
        }

        

        protected void gvQtitle_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "021");
                bool resultEdit = user.CanSave(userID, "021");
                bool resultDelete = user.CanDelete(userID, "021");
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
                bool resultRead = user.CanRead(userID, "021");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "021");
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

        //protected void gvQtitle_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    CountryBL bbl = new CountryBL();
        //    if (search == false)
        //    {
        //        gvQtitle.EditIndex = e.NewEditIndex;
        //        SelectAllData(0);
        //    }
        //    else
        //    {
        //        gvQtitle.EditIndex = e.NewEditIndex;
        //        SearchData();
        //    }
        //}
        protected void gvQtitle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CountryBL bbl = new CountryBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvQtitle.EditIndex = e.NewEditIndex;
                SelectAllData(0);
            }
            else
            {
                gvQtitle.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }

        protected void gvQtitle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            qtitleInfo = new QualificationTitleEntity();
            qtitlebl = new QualificationTitleBL();
            qtitleInfo.ID = Convert.ToInt16(((Label)gvQtitle.Rows[e.RowIndex].FindControl("lblID")).Text);
            qtitleInfo.UpdatedBy = qtitleInfo.ID;
            qtitleInfo.Description = ((TextBox)gvQtitle.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = qtitlebl.CheckExistingType(qtitleInfo.ID, qtitleInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(qtitleInfo.Description) || JSAT_Common.BaseLib.IsInt(qtitleInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(qtitleInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                    qtitlebl.Update(qtitleInfo);

                if (search == false)
                {
                    gvQtitle.EditIndex = -1;

                    SelectAllData(0);
                }
                else
                {
                    gvQtitle.EditIndex = -1;
                    GlobalUI.MessageBox("Update successfully");
                    SearchData();
                }
            }
        }

        protected void SearchData()
        {
            qtitlebl = new QualificationTitleBL();
            DataTable dt = new DataTable();
            dt = qtitlebl.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvQtitle.DataSource = dt;
                gvQtitle.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvQtitle.DataSource = dt;
                gvQtitle.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            qtitleInfo = new QualificationTitleEntity();
            qtitlebl = new QualificationTitleBL();
            qtitleInfo.Description = ((TextBox)gvQtitle.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = qtitlebl.CheckExistingType(0, qtitleInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(qtitleInfo.Description) || qtitleInfo.Description.Length > 200 || JSAT_Common.BaseLib.IsInt(qtitleInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(qtitleInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (qtitleInfo.Description.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 characters.");
                }
                else
                {
                    GlobalUI.MessageBox("Save Successfully");
                    qtitlebl.Insert(qtitleInfo);
                }
            }
            SelectAllData(0);
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
                gvQtitle.PageIndex = e.NewPageIndex;
                gvQtitle.DataBind();
            }
            else
            {
                SearchData();
                gvQtitle.PageIndex = e.NewPageIndex;
                gvQtitle.DataBind();
            }
        }
    }
}