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
    public partial class Township_Type : System.Web.UI.Page
    {
        Instituation_AreaBL area;
        Township_Type_BL tbl;
        Township_Type_Entity tety;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllData();
            }
        }

        protected void SelectByInstituteArea(int institutionarea_id)
        {
            tbl = new Township_Type_BL();
            DataTable dt = new DataTable();
            dt = tbl.SelectByInstitutionID(institutionarea_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                GVTownship.DataSource = dt;
                GVTownship.DataBind();
            }
            else
            {
                GVTownship.DataSource = dt;
                GVTownship.DataBind();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtsearchTS.Text == "")
            {
                SelectAllData();
            }
            else
            {
                SearchData();
            }
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            SelectAllData();
            TxtsearchTS.Text = string.Empty;
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                GVTownship.PageIndex = e.NewPageIndex;
                GVTownship.DataBind();
            }
            else
            {
                SearchData();
                GVTownship.PageIndex = e.NewPageIndex;
                GVTownship.DataBind();
            }
        }

        protected void SearchData()
        {
            tbl = new Township_Type_BL();
            DataTable dt = new DataTable();
            dt = tbl.Search(TxtsearchTS.Text);
            if (dt.Rows.Count > 0)
            {
                GVTownship.DataSource = dt;
                GVTownship.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                GVTownship.DataSource = dt;
                GVTownship.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tety = new Township_Type_Entity();
            tbl = new Township_Type_BL();
            tety.Township_Description = ((TextBox)GVTownship.FooterRow.FindControl("txtNewTownship")).Text;
            bool result = tbl.CheckExistingType(tety.Township_Description, 0);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(tety.Township_Description) || BaseLib.IsInt(tety.Township_Description))
                {
                    if (string.IsNullOrWhiteSpace(tety.Township_Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    CreatedDateTime();
                    int id = Convert.ToInt32(Session["UserID"]);
                    tety.CreatedBy = id;
                    tbl.Insert(tety);
                    GlobalUI.MessageBox("Save successfully");
                }
            }
            SelectAllData();
        }

        protected void GVTownship_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            tety = new Township_Type_Entity();
            tbl = new Township_Type_BL();
            tety.ID = Convert.ToInt16(((Label)GVTownship.Rows[e.RowIndex].FindControl("lblID")).Text);
            tbl.Delete(tety.ID);
            if (search == false)
            {
                SelectAllData();
            }
            else
            {
                SearchData();
                GlobalUI.MessageBox("Delete Successfully");
            }
        }

        
        protected void GVTownship_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Township_Type_BL bbl = new Township_Type_BL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                GVTownship.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                GVTownship.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }


        protected void GVTownship_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            tety = new Township_Type_Entity();
            tbl = new Township_Type_BL();
            tety.ID = Convert.ToInt16(((Label)GVTownship.Rows[e.RowIndex].FindControl("lblID")).Text);
            tety.UpdatedBy = tety.ID;
            tety.Township_Description = ((TextBox)GVTownship.Rows[e.RowIndex].FindControl("TxtTownship")).Text;
            bool result = tbl.CheckExistingType(tety.Township_Description, tety.ID);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else if (tety.ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(tety.Township_Description) || BaseLib.IsInt(tety.Township_Description))
                {
                    if (string.IsNullOrWhiteSpace(tety.Township_Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    CreatedDateTime();
                    tbl.Update(tety);
                    GlobalUI.MessageBox("Update Successfully");
                }
            }
            else
            {
                tety.Township_Description = ((TextBox)GVTownship.FooterRow.FindControl("txtNewTownship")).Text;
                tety.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                CreatedDateTime();
                tbl.Insert(tety);
            }
            if (search == false)
            {
                GVTownship.EditIndex = -1;
            }
            else
            {
                GVTownship.EditIndex = -1;
                SearchData();
            }
        }

        protected void GVTownship_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                GVTownship.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                GVTownship.EditIndex = -1;
                SearchData();
            }
        }


        protected void GVTownship_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            JSAT_BL.UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkedit = (LinkButton)e.Row.FindControl("lnkedit");
                LinkButton lnkdelete = ((LinkButton)e.Row.FindControl("lnkDelete"));
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "Township_ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                //hide Edit button
                bool resultRead = user.CanRead(userID, "049");
                bool resultEdit = user.CanSave(userID, "049");
                bool resultDelete = user.CanDelete(userID, "049");
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
                bool resultRead = user.CanRead(userID, "049");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "049");
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

        protected void SelectAllData()
        {
            tbl = new Township_Type_BL();
            DataTable dt = new DataTable();
            dt = tbl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                GVTownship.DataSource = dt;
                GVTownship.DataBind();
            }
            else
            {
                GVTownship.DataSource = dt;
                GVTownship.DataBind();
            }
        }

        protected void CreatedDateTime()
        {
            tety.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            Response.Write(tety.CreatedDate.ToString("dd/MM/yyyy"));
        }
    }
}