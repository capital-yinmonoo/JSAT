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
    public partial class UserRole : System.Web.UI.Page
    {
        MenuBL menu;
        UserRoleEntity userInfo;
        UserRoleBL user;
        bool Read = false;
        bool Edit = false;
        bool Delete = false;
        CheckBox ckbRead, ckbEdit, ckbDelete;
        int countRead, countEdit, countDelete = 0;
        int menuID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //hide button
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            bool resultRead = user.CanRead(userID, "011");
            if (resultRead)
            {
                btnAddRole.Visible = false;
            }
            bool resultEdit = user.CanSave(userID, "011");
            if (resultEdit)
            {
                btnAddRole.Visible = true;
            }
            else
                btnAddRole.Visible = false;
            if (!IsPostBack)
            {
                user = new UserRoleBL();
                menu = new MenuBL();
                gvUserRole.DataSource = menu.SelectAll();
                gvUserRole.DataBind();
                if (Request.QueryString["ID"] != null)
                {
                    int id = Convert.ToInt16(Request.QueryString["ID"].ToString());
                    lblName.Text = "User Name : " + user.SelectName(id) + " for Permission.";
                    DataTable dt = new DataTable();
                    dt = user.SelectByID(id);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (GridViewRow gvRow in gvUserRole.Rows)
                        {
                            menuID = Convert.ToInt16(((Label)gvRow.FindControl("lblMenuID")).Text);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (menuID == (int)dt.Rows[i]["ID"])
                                {
                                    if ((bool)dt.Rows[i]["CanRead"])
                                    {
                                        ckbRead = (CheckBox)gvRow.FindControl("ckbRead");
                                        ckbRead.Checked = true;
                                        countRead++;
                                    }
                                    if ((bool)dt.Rows[i]["CanEdit"])
                                    {
                                        ckbEdit = (CheckBox)gvRow.FindControl("ckbEdit");
                                        ckbEdit.Checked = true;
                                        countEdit++;
                                    }
                                    if ((bool)dt.Rows[i]["CanDelete"])
                                    {
                                        ckbDelete = (CheckBox)gvRow.FindControl("ckbDelete");
                                        ckbDelete.Checked = true;
                                        countDelete++;
                                    }
                                }
                            }
                            if (countRead == gvUserRole.Rows.Count - 3)
                            {
                                ((CheckBox)gvUserRole.HeaderRow.FindControl("chkAllRead")).Checked = true;
                            }
                            if (countEdit == gvUserRole.Rows.Count - 3)
                            {
                                ((CheckBox)gvUserRole.HeaderRow.FindControl("chkAllEdit")).Checked = true;
                            }
                            if (countDelete == gvUserRole.Rows.Count - 3)
                            {
                                ((CheckBox)gvUserRole.HeaderRow.FindControl("chkAllDelete")).Checked = true;
                            }
                        }
                        btnAddRole.Text = "アップデート役割読む (Update Role)";
                    }
                }
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["ID"].ToString());
            RoleInsert(id);
        }

        protected void RoleInsert(int id)
        {
            user = new UserRoleBL();
            userInfo = new UserRoleEntity();
            for (int i = 0; i < gvUserRole.Rows.Count; i++)
            {
                menuID = Convert.ToInt16(((Label)gvUserRole.Rows[i].Cells[0].FindControl("lblMenuID")).Text);
                if (menuID == 1) // for home page 
                {
                    userInfo.UserRole.Rows.Add(0, id, menuID, true, true, true);
                }
                else
                {
                    CheckBox read = (CheckBox)gvUserRole.Rows[i].Cells[2].FindControl("ckbRead");
                    if (read != null) if (read.Checked) Read = true;
                    CheckBox edit = (CheckBox)gvUserRole.Rows[i].Cells[3].FindControl("ckbEdit");
                    if (edit != null) if (edit.Checked) Edit = true;
                    CheckBox delete = (CheckBox)gvUserRole.Rows[i].Cells[4].FindControl("ckbDelete");
                    if (delete != null) if (delete.Checked) Delete = true;
                    if (Read == true || Edit == true || Delete == true)
                    {
                        userInfo.UserRole.Rows.Add(0, id, menuID, Read, Edit, Delete);
                    }
                }
                Read = false; Edit = false; Delete = false;
            }
            user.Insert(userInfo.UserRole, id);
            GlobalUI.MessageBox("Insert Successful!");
        }

        protected void chkReadSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvUserRole.HeaderRow.FindControl("chkAllRead");
            foreach (GridViewRow row in gvUserRole.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("ckbRead");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void chkEditSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvUserRole.HeaderRow.FindControl("chkAllEdit");
            foreach (GridViewRow row in gvUserRole.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("ckbEdit");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void chkDeleteSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvUserRole.HeaderRow.FindControl("chkAllDelete");
            foreach (GridViewRow row in gvUserRole.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("ckbDelete");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void gvUserRole_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "references")
                {
                    e.Row.Style.Add("background-color", "#007aff");
                    e.Row.Style.Add("text-align", "center");
                    e.Row.Style.Add("color", "white");
                    e.Row.Style.Add("font-size", "15px");
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "employer")
                {
                    e.Row.Style.Add("background-color", "#007aff");
                    e.Row.Style.Add("text-align", "center");
                    e.Row.Style.Add("color", "white");
                    e.Row.Style.Add("font-size", "15px");
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "employee")
                {
                    e.Row.Style.Add("background-color", "#007aff");
                    e.Row.Style.Add("text-align", "center");
                    e.Row.Style.Add("color", "white");
                    e.Row.Style.Add("font-size", "15px");
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "system")
                {
                    e.Row.Style.Add("background-color", "#007aff");
                    e.Row.Style.Add("text-align", "center");
                    e.Row.Style.Add("color", "white");
                    e.Row.Style.Add("font-size", "15px");
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "credit")
                {
                    e.Row.Style.Add("background-color", "#007aff");
                    e.Row.Style.Add("text-align", "center");
                    e.Row.Style.Add("color", "white");
                    e.Row.Style.Add("font-size", "15px");
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "interview")
                {
                    e.Row.Style.Add("background-color", "#007aff");
                    e.Row.Style.Add("text-align", "center");
                    e.Row.Style.Add("color", "white");
                    e.Row.Style.Add("font-size", "15px");
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                }
                if (DataBinder.Eval(e.Row.DataItem, "Description").ToString().ToLower() == "home")
                {
                    e.Row.Visible = false;
                }
            }
        }
    }
}