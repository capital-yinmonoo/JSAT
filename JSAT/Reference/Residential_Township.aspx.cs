using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_BL.Reference;
using JSAT_Common;
using JSAT_Common.Reference;
using JSAT_Ver1;

namespace JSAT.Reference
{
    public partial class Residential_Township : System.Web.UI.Page
    {
        ResidentialAreaBL area;
        ResidentialArea_Entity area_entity;
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
            area = new ResidentialAreaBL();
            DataTable dt = new DataTable();
            dt = area.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                GVResidentialTownship.DataSource = dt;
                GVResidentialTownship.DataBind();
            }
            else
            {
                GVResidentialTownship.DataSource = dt;
                GVResidentialTownship.DataBind();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtsearchRTS.Text == "")
            {
                SelectAllData();
            }
            else
            {
                SearchData();
            }
        }
        protected void SearchData()
        {
            area = new ResidentialAreaBL();
            DataTable dt = new DataTable();
            dt = area.Search(TxtsearchRTS.Text);
            if (dt.Rows.Count > 0)
            {
                GVResidentialTownship.DataSource = dt;
                GVResidentialTownship.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                GVResidentialTownship.DataSource = dt;
                GVResidentialTownship.DataBind();
            }
        }
        protected void BtnView_Click(object sender, EventArgs e)
        {
            SelectAllData();
            TxtsearchRTS.Text = string.Empty;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            area_entity = new ResidentialArea_Entity();
            area = new ResidentialAreaBL();
            area_entity.Township_Description = ((TextBox)GVResidentialTownship.FooterRow.FindControl("txtNewTownship")).Text;
            bool result = area.CheckExistingType(area_entity.Township_Description, 0);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(area_entity.Township_Description) || BaseLib.IsInt(area_entity.Township_Description))
                {
                    if (string.IsNullOrWhiteSpace(area_entity.Township_Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {

                    int id = Convert.ToInt32(Session["UserID"]);
                    area.Insert(area_entity);
                    GlobalUI.MessageBox("Save successfully");
                    GVResidentialTownship.PageIndex = 0;
                    GVResidentialTownship.DataBind();
                }
            }
            SelectAllData();
        }

        protected void GVTownship_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            area_entity = new ResidentialArea_Entity();
            area = new ResidentialAreaBL();
            area_entity.ID = Convert.ToInt16(((Label)GVResidentialTownship.Rows[e.RowIndex].FindControl("lblID")).Text);
            area.Delete(area_entity.ID);
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
            ResidentialAreaBL bbl = new ResidentialAreaBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                GVResidentialTownship.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                GVResidentialTownship.EditIndex = e.NewEditIndex;
                SearchData();
            }
            hdfupdate.Value = "";
        }


        protected void GVTownship_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            area_entity = new ResidentialArea_Entity();
            area = new ResidentialAreaBL();
            area_entity.ID = Convert.ToInt16(((Label)GVResidentialTownship.Rows[e.RowIndex].FindControl("lblID")).Text);
            //area.UpdatedBy = area_entity.ID;
            area_entity.Township_Description = ((TextBox)GVResidentialTownship.Rows[e.RowIndex].FindControl("TxtTownship")).Text;
            bool result = area.CheckExistingType(area_entity.Township_Description, area_entity.ID);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else if (area_entity.ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(area_entity.Township_Description) || BaseLib.IsInt(area_entity.Township_Description))
                {
                    if (string.IsNullOrWhiteSpace(area_entity.Township_Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    area.Update(area_entity);
                    GlobalUI.MessageBox("Update Successfully");
                }
            }
            else
            {
                area_entity.Township_Description = ((TextBox)GVResidentialTownship.FooterRow.FindControl("txtNewTownship")).Text;
                area.Insert(area_entity);
            }
            if (search == false)
            {
                GVResidentialTownship.EditIndex = -1;
            }
            else
            {
                GVResidentialTownship.EditIndex = -1;
                SearchData();
            }
        }

        protected void GVTownship_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (search == false)
            {
                GVResidentialTownship.EditIndex = -1;
                SelectAllData();
            }
            else
            {
                GVResidentialTownship.EditIndex = -1;
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
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
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

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                GVResidentialTownship.PageIndex = e.NewPageIndex;
                GVResidentialTownship.DataBind();
            }
            else
            {
                SearchData();
                GVResidentialTownship.PageIndex = e.NewPageIndex;
                GVResidentialTownship.DataBind();
            }
        }



    }
}