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
    public partial class Position : System.Web.UI.Page
    {
        DepartmentBL department;
        PositionBL position;
        PositionEntity positionInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll(0);
                Get_Department();
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedValue == "0")
                SelectAll(0);
            else
                SelectByDepartment(int.Parse(ddlDepartment.SelectedValue));
        }

        protected void gvPosition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void gvPosition_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvPosition_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "006");
                if (resultRead)
                {
                    btnedit.Visible = false;
                    btndelete.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "006");
                if (resultEdit)
                {
                    btnedit.Visible = true;
                }
                bool resultDelete = user.CanDelete(userID, "006");
                if (resultDelete)
                {
                    btndelete.Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //hide Save button
                bool resultRead = user.CanRead(userID, "006");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "006");
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
            if (ddlDepartment.SelectedItem.Value == "0")
            {
                if (search == false)
                {
                    SelectByDepartment(int.Parse(ddlDepartment.SelectedValue));
                    gvPosition.PageIndex = e.NewPageIndex;
                    gvPosition.DataBind();
                }
                else
                {
                    SelectAll(0);
                    gvPosition.PageIndex = e.NewPageIndex;
                    gvPosition.DataBind();
                }
            }
            else
            {
                if (search == false)
                {
                    SelectByDepartment(int.Parse(ddlDepartment.SelectedValue));
                    gvPosition.PageIndex = e.NewPageIndex;
                    gvPosition.DataBind();
                }
                else
                {
                    SearchData();
                    gvPosition.PageIndex = e.NewPageIndex;
                    gvPosition.DataBind();
                }
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    PositionBL position = new PositionBL();
                    Button btn = (Button)e.CommandSource;
                    GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
                    Label id = (Label)grdrow.FindControl("lblid");
                    int bbID = Convert.ToInt32(id.Text);
                    if (bbID != 0)
                    {
                        DataTable dt = position.GetDepartmentID(bbID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int ID = Convert.ToInt32(dt.Rows[0]["Department_ID"]);
                            ddlDepartment.SelectedValue = ID.ToString();
                        }
                    }
                    DataTable resultdt = new DataTable();
                    resultdt = SearchData();
                    gvPosition.DataBind();
                    int gvcount = resultdt.Rows.Count;
                    for (int i = 0; i < gvcount; i++)
                    {
                        if (Convert.ToInt32(resultdt.Rows[i]["ID"]) == bbID)
                        {
                            ((TextBox)gvPosition.FooterRow.FindControl("txtDescriptionSave")).Text = resultdt.Rows[i]["Description"].ToString();
                            ((TextBox)gvPosition.FooterRow.FindControl("txtDescriptionSave")).Focus();
                            Page.MaintainScrollPositionOnPostBack = false;
                            ((Button)gvPosition.FooterRow.FindControl("btnSave")).Text = "Update";
                            hdfID.Value = bbID.ToString();
                        }
                    }
                    txtSearch.Text = "";//For Search-edit-viewall-edit sequence condition
                    ((Button)gvPosition.FooterRow.FindControl("btnCancel")).Visible = true;
                    break;
                case "Delete":
                    Button btnDelete = (Button)e.CommandSource;
                    GridViewRow grdrowfordel = ((GridViewRow)btnDelete.NamingContainer);
                    Label idfordel = (Label)grdrowfordel.FindControl("lblid");
                    position = new PositionBL();
                    position.Delete(Convert.ToInt32(idfordel.Text));
                    GlobalUI.MessageBox("Record Deleted Successfully.");
                    if (search == false)
                    {
                        SelectByDepartment(int.Parse(ddlDepartment.SelectedValue));
                    }
                    else
                    {
                        GlobalUI.MessageBox("Delete Successfully");
                        SearchData();
                    }
                    break;
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ((TextBox)gvPosition.FooterRow.FindControl("txtDescriptionSave")).Text = String.Empty;
            ((Button)gvPosition.FooterRow.FindControl("btnCancel")).Visible = false;
            ((Button)gvPosition.FooterRow.FindControl("btnSave")).Text = "Save";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            positionInfo = new PositionEntity();
            position = new PositionBL();
            positionInfo.Department_ID = int.Parse(ddlDepartment.SelectedValue);
            string SaveorUpdate = ((Button)gvPosition.FooterRow.FindControl("btnSave")).Text;
            if (SaveorUpdate == "Update")
            {
                positionInfo.ID = Convert.ToInt32(hdfID.Value);
                if (positionInfo.Department_ID == 0)
                {
                    DataTable dt = position.GetDepartmentID(positionInfo.ID);
                    int ID = Convert.ToInt32(dt.Rows[0]["Departement_ID"]);
                    positionInfo.Department_ID = ID;
                }
                positionInfo.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                positionInfo.Description = ((TextBox)gvPosition.FooterRow.FindControl("txtDescriptionSave")).Text;
                ViewState["description"] = positionInfo.Description;
                bool result = position.CheckExistingType(positionInfo.ID, positionInfo.Department_ID, positionInfo.Description);
                if (result == true)
                    GlobalUI.MessageBox("This data has been already existed!");
                else if (positionInfo.ID >= 1)
                {
                    if (string.IsNullOrWhiteSpace(positionInfo.Description) || BaseLib.IsInt(positionInfo.Description))
                    {
                        if (string.IsNullOrWhiteSpace(positionInfo.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        CreateDateTime();
                        position.Update(positionInfo);
                        GlobalUI.MessageBox("Record Updated Successfully.");
                    }
                }
            }
            else
            {
                if (positionInfo.Department_ID == 0)
                {
                    GlobalUI.MessageBox(" Please Select Department.");
                }
                else
                    positionInfo.Description = ((TextBox)gvPosition.FooterRow.FindControl("txtDescriptionSave")).Text;
                bool existOrnot = position.CheckExistingType(0, positionInfo.Department_ID, positionInfo.Description);
                if (existOrnot == true)
                    GlobalUI.MessageBox("This data has been already existed!");
                else
                {
                    if (string.IsNullOrWhiteSpace(positionInfo.Description) || BaseLib.IsInt(positionInfo.Description))
                    {
                        if (string.IsNullOrWhiteSpace(positionInfo.Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");

                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        CreateDateTime();
                        int id = Convert.ToInt32(Session["UserID"]);
                        positionInfo.CreatedBy = id;
                        GlobalUI.MessageBox("Save succesfully");
                        position.Insert(positionInfo);
                        SelectByDepartment(int.Parse(ddlDepartment.SelectedValue));
                    }
                    position.SelectAll(0);
                    gvPosition.PageIndex = 0;
                }
            }
            SelectByDepartment(int.Parse(ddlDepartment.SelectedValue));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAll(0);
                ddlDepartment.SelectedValue = "0";
            }
            else
            {
                SearchData();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ddlDepartment.SelectedValue = "0";
            gvPosition.PageIndex = 0;
            SelectAll(0);
        }

        protected void SelectByDepartment(int dept_id)
        {
            position = new PositionBL();
            DataTable dt = new DataTable();
            dt = position.SelectByDepartmentID(dept_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvPosition.DataSource = dt;
                gvPosition.DataBind();
            }
            else
            {
                gvPosition.DataSource = dt;
                gvPosition.DataBind();
            }
        }

        protected void SelectAll(int PorCRV)
        {
            position = new PositionBL();
            DataTable dt = new DataTable();
            dt = position.SelectAll(PorCRV);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                gvPosition.DataSource = dt;
                gvPosition.DataBind();
            }
            else
            {
                gvPosition.DataSource = dt;
                gvPosition.DataBind();
            }
        }

        protected DataTable SearchData()
        {
            position = new PositionBL();
            DataTable dt = new DataTable();
            if (ddlDepartment.SelectedItem.Value == "0")
            {
                dt = position.Search(int.Parse(ddlDepartment.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {
                    gvPosition.DataSource = dt;
                    gvPosition.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvPosition.DataSource = dt;
                    gvPosition.DataBind();
                }
            }
            else
            {
                dt = position.Search(int.Parse(ddlDepartment.SelectedValue), txtSearch.Text);
                if (dt.Rows.Count > 0)
                {

                    gvPosition.DataSource = dt;
                    gvPosition.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    gvPosition.DataSource = dt;
                    gvPosition.DataBind();
                }
            }
            return dt;
        }

        protected void Get_Department()
        {
            department = new DepartmentBL();
            ddlDepartment.DataSource = department.SelectAll(1);
            ddlDepartment.DataTextField = "Description";
            ddlDepartment.DataValueField = "ID";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void CreateDateTime()
        {
            positionInfo.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            Response.Write(positionInfo.CreatedDate.ToString("dd/MM/yyyy"));
        }
    }
}