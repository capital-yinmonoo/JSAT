using JSAT.Reference;
using JSAT_BL;
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
    public partial class Country : System.Web.UI.Page
    {
        CountryBL countrybl;
        CountryEntity countryInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllData();
            }
        }

        protected void SelectAllData()
        {
            countrybl = new CountryBL();
            DataTable dt = new DataTable();
            dt = countrybl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvCountry.DataSource = dt;
                gvCountry.DataBind();
            }
            else
            {
                gvCountry.DataSource = dt;
                gvCountry.PageIndex = 0;
                gvCountry.DataBind();
            }
        }

        protected void gvCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            countryInfo = new CountryEntity();
            countrybl = new CountryBL();
            countryInfo.ID = Convert.ToInt16(((Label)gvCountry.Rows[e.RowIndex].FindControl("lblID")).Text);
            countrybl.Delete(countryInfo.ID);
            if (search == false)
            {
                SelectAllData();
            }
            else
            {
                SearchData();
                GlobalUI.MessageBox("Delete successfully");
            }
        }

        protected void gvCountry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                gvCountry.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                gvCountry.EditIndex = -1;
                SearchData();
            }
        }


        //protected void gvCountry_RowDataBound(object sender, GridViewRowEventArgs e)
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
        //        bool resultRead = user.CanRead(userID, "020");
        //        if (resultRead)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = false;
        //            e.Row.Cells[2].Controls[2].Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "020");
        //        if (resultEdit)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = true;
        //        }

        //        bool resultDelete = user.CanDelete(userID, "020");
        //        if (resultDelete)
        //        {
        //            e.Row.Cells[2].Controls[2].Visible = true;
        //        }
        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        //hide Save Button
        //        bool resultRead = user.CanRead(userID, "020");
        //        Button btn = e.Row.FindControl("btnSave") as Button;
        //        if (resultRead)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "020");
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

        protected void gvCountry_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "v");
                bool resultEdit = user.CanSave(userID, "020");
                bool resultDelete = user.CanDelete(userID, "020");
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
                bool resultRead = user.CanRead(userID, "020");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "020");
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
                
        protected void gvCountry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CountryBL bbl = new CountryBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvCountry.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                gvCountry.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }


        protected void gvCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            countryInfo = new CountryEntity();
            countrybl = new CountryBL();
            countryInfo.ID = Convert.ToInt16(((Label)gvCountry.Rows[e.RowIndex].FindControl("lblID")).Text);
            countryInfo.UpdatedBy = countryInfo.ID;
            countryInfo.Description = ((TextBox)gvCountry.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = countrybl.CheckExistingType(countryInfo.ID, countryInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(countryInfo.Description) || BaseLib.IsInt(countryInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(countryInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    countrybl.Update(countryInfo);
                    GlobalUI.MessageBox("Update Successfully");
                }
            }
            if (search == false)
            {
                gvCountry.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                gvCountry.EditIndex = -1;
                SearchData();
            }
        }

        protected void SearchData()
        {
            countrybl = new CountryBL();
            DataTable dt = new DataTable();
            dt = countrybl.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvCountry.DataSource = dt;
                gvCountry.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvCountry.DataSource = dt;
                gvCountry.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            countryInfo = new CountryEntity();
            countrybl = new CountryBL();
            countryInfo.Description = ((TextBox)gvCountry.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = countrybl.CheckExistingType(0, countryInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed.");
            else
            {
                if (string.IsNullOrWhiteSpace(countryInfo.Description) || countryInfo.Description.Length > 200 || BaseLib.IsInt(countryInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(countryInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else if (countryInfo.Description.Length > 200)
                        GlobalUI.MessageBox("Maximum length is 200 characters.");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    countrybl.Insert(countryInfo);
                    GlobalUI.MessageBox("Save Successfully");
                }
            }
            SelectAllData();
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
            gvCountry.PageIndex = 0;
            SelectAllData();
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                SelectAllData();
                gvCountry.PageIndex = e.NewPageIndex;
                gvCountry.DataBind();
            }
            else
            {
                SearchData();
                gvCountry.PageIndex = e.NewPageIndex;
                gvCountry.DataBind();
            }
        }
    }
}