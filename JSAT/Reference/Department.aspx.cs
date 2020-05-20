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
    public partial class Department : System.Web.UI.Page
    {
        DepartmentBL department;
        DepartmentEntity depInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll(0);
            }
        }

        public void SelectAll(int DorCRV)
        {
            department = new DepartmentBL();
            DataTable dt = new DataTable();
            dt = department.SelectAll(DorCRV);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvDepartment.DataSource = dt;
                gvDepartment.DataBind();
            }
            else
            {
                gvDepartment.DataSource = dt;
                gvDepartment.PageIndex = 0;
                gvDepartment.DataBind();
            }
        }

        protected void Department_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            depInfo = new DepartmentEntity();
            department = new DepartmentBL();
            depInfo.ID = Convert.ToInt16(((Label)gvDepartment.Rows[e.RowIndex].FindControl("lblID")).Text);
            department.Delete(depInfo.ID);
            if (search == false)
            {
                SelectAll(0);
            }
            else
            {
                Search();
                GlobalUI.MessageBox("Delete successfully");
            }
        }

        protected void Department_Insert()
        {
            DepartmentBL department = new DepartmentBL();
            depInfo = new DepartmentEntity();
            int id = Convert.ToInt16(gvDepartment.FindControl("lblID"));
            depInfo.CreatedBy = id;
            string description = ((TextBox)gvDepartment.FooterRow.FindControl("txtDescription")).Text;
            depInfo.Description = description;
            if (string.IsNullOrWhiteSpace(depInfo.Description) || BaseLib.IsInt(depInfo.Description))
            {
                if (string.IsNullOrWhiteSpace(depInfo.Description))
                    GlobalUI.MessageBox("Not Allow Empty String!");
                else
                {
                    GlobalUI.MessageBox("Not Allow Number!");
                }
            }
            else if (department.Check_ExistingRecord(id, depInfo.Description))
            {
                GlobalUI.MessageBox("Record Already Exists");
            }
            else
            {
                depInfo.CreatedBy = Convert.ToInt32(Session["UserID"]);
                department.Insert(depInfo);
                GlobalUI.MessageBox("Record save successfully");
                gvDepartment.PageIndex = 0;
                SelectAll(0);
            }
        }

        //protected void gvDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    if (search == false)
        //    {
        //        gvDepartment.EditIndex = e.NewEditIndex;
        //        SelectAll(0);
        //    }
        //    else
        //    {
        //        gvDepartment.EditIndex = e.NewEditIndex;
        //        Search();
        //    }
        //}

        protected void gvDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DepartmentBL department= new DepartmentBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvDepartment.EditIndex = e.NewEditIndex;
                SelectAll(0);
            }
            else
            {
                gvDepartment.EditIndex = e.NewEditIndex;
                Search();
            }
            hdfupdate.Value = "";
        }

        protected void gvDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DepartmentBL department = new DepartmentBL();
            if (search == false)
            {
                gvDepartment.EditIndex = -1;
                SelectAll(0);
            }
            else
            {
                gvDepartment.EditIndex = -1;
                Search();
            }
        }

        protected void Department_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartment.PageIndex = e.NewPageIndex;
            SelectAll(0);
        }

        protected void gvDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DepartmentBL department = new DepartmentBL();
            DepartmentEntity depInfo = new DepartmentEntity();
            GridViewRow row = (GridViewRow)gvDepartment.Rows[e.RowIndex];
            depInfo.ID = Convert.ToInt32(gvDepartment.DataKeys[e.RowIndex].Value.ToString());
            depInfo.UpdatedBy = Convert.ToInt32(Session["UserID"]);
            depInfo.Description = ((TextBox)gvDepartment.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = department.Check_ExistingRecord(depInfo.ID, depInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(depInfo.Description) || BaseLib.IsInt(depInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(depInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    GlobalUI.MessageBox("Update successfully");
                    department.Update(depInfo);
                    gvDepartment.DataBind();
                }
            }
            if (search == false)
            {
                gvDepartment.EditIndex = -1;
                SelectAll(0);
            }
            else
            {
                gvDepartment.EditIndex = -1;
                Search();
            }
        }

        protected void gvDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Controls[0].Visible = false;//Edit
                e.Row.Cells[2].Controls[2].Visible = false;//Delete
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                //hide Edit button
                bool resultRead = user.CanRead(userID, "023");
                if (resultRead)
                {
                    e.Row.Cells[2].Controls[0].Visible = false;
                    e.Row.Cells[2].Controls[2].Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "023");
                if (resultEdit)
                {
                    e.Row.Cells[2].Controls[0].Visible = true;
                }
                bool resultDelete = user.CanDelete(userID, "023");
                if (resultDelete)
                {
                    e.Row.Cells[2].Controls[2].Visible = true;
                }
            }
            //hide Save Button
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                bool resultRead = user.CanRead(userID, "023");
                Button btn = e.Row.FindControl("btnAdd") as Button;
                if (resultRead)
                {
                    //Button EditButton = (Button)e.Row.FindControl("ShowEditButton");
                    //EditButton.Visible = false;
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "023");
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
                SelectAll(0);
                gvDepartment.PageIndex = e.NewPageIndex;
                gvDepartment.DataBind();
            }
            else
            {
                Search();
                gvDepartment.PageIndex = e.NewPageIndex;
                gvDepartment.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Department_Insert();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                SelectAll(0);
            }
            else
            {
                Search();
            }
        }

        protected void ViewAll_Click(object sender, EventArgs e)
        {
            txtsearch.Text = string.Empty;
            gvDepartment.PageIndex = 0;
            SelectAll(0);
        }

        public void Search()
        {
            DepartmentBL department = new DepartmentBL();
            DataTable dt = new DataTable();
            dt = department.Search(txtsearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvDepartment.DataSource = dt;
                gvDepartment.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvDepartment.DataSource = dt;
                gvDepartment.DataBind();
            }
        }

        protected void CreateDateTime()
        {
            depInfo.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            Response.Write(depInfo.CreatedDate.ToString("dd/MM/yyyy"));
        }

        protected void gvDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            department = new DepartmentBL();
            GridViewRow row = (GridViewRow)gvDepartment.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvDepartment.DataKeys[e.RowIndex].Value.ToString());
            department.Delete(id);
            if (search == false)
                SelectAll(0);
            else
            {
                GlobalUI.MessageBox("Delete successfully");
                Search();
            }
        }
    }
}