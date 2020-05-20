using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace JSAT_Ver1
{
    public partial class User_View : System.Web.UI.Page
    {
        UserBL user;
        public string selected = string.Empty;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string[] filePaths = Directory.GetFiles(Server.MapPath("~/img/"));
            //List<ListItem> files = new List<ListItem>();
            //foreach (string filePath in filePaths)
            //{
            //    string fileName = Path.GetFileName(filePath);
            //    files.Add(new ListItem(fileName, "~/img/" + fileName));
            //}
            //gvUser.DataSource = files;
            //SelectAll();

            if (!IsPostBack)
            {

                SelectAll();
            }
        }

        protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                else
                {

                    Image image = (Image)e.Row.FindControl("imgPicture");
                    if (image != null && image.ImageUrl == "~/img/" || image.ImageUrl =="")
                    {
                        image.ImageUrl = "~/img/Default_Profile.ico";
                    }

                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                UserRoleBL user = new UserRoleBL();
                int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                bool resultRead = user.CanRead(userID, "009");
                if (resultRead)
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "009");
                if (resultEdit)
                {
                    btnEdit.Visible = true;
                }
                else
                    btnEdit.Visible = false;
                bool resultDelete = user.CanDelete(userID, "009");
                if (resultDelete)
                {
                    btnDelete.Visible = true;
                }
                else
                    btnDelete.Visible = false;
            }
        }

        protected void SelectAll()
        {
            user = new UserBL();
            gvUser.DataSource = user.SelectAll();
            //string[] filePaths = Directory.GetFiles(Server.MapPath("~/img/"));
            //List<ListItem> files = new List<ListItem>();
            //foreach (string filePath in filePaths)
            //{
            //    string fileName = Path.GetFileName(filePath);
            //    files.Add(new ListItem(fileName, "~/img/" + fileName));
            //}
            //gvUser.DataSource = files;
            gvUser.DataBind();
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                SelectAll();
                gvUser.PageIndex = e.NewPageIndex;
                gvUser.DataBind();
            }
            else
            {
                Search();
                gvUser.PageIndex = e.NewPageIndex;
                gvUser.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ArrayList selectedID = GetSelectedRecord();
            if (selectedID != null)
            {
                if (selectedID.Count > 1)
                {
                    GlobalUI.MessageBox("Not allowed to select multiple records in Edit!");
                }
                else if (selectedID.Count <= 0)
                {
                    GlobalUI.MessageBox("Please select one records for Edit!");
                }
                else
                {
                    int id = Convert.ToInt16(selectedID[0].ToString());
                    Response.Redirect("~/System/User.aspx?ID=" + id);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ArrayList selectedID = GetSelectedRecord();
            if (selectedID != null)
            {
                for (int i = 0; i <= selectedID.Count - 1; i++)
                {
                    int id = Convert.ToInt16(selectedID[i].ToString());
                    user.Delete(id);
                }
            }
            SelectAll();
            GlobalUI.MessageBox("Deleted Successfully!");
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            ArrayList selectedID = GetSelectedRecord();
            if (selectedID != null)
            {
                if (selectedID.Count > 1)
                {
                    GlobalUI.MessageBox("Not allowed to select multiple records in Add Role.!");
                }
                else if (selectedID.Count <= 0)
                {
                    GlobalUI.MessageBox("Please select one records for Add Role!");
                }
                else
                {
                    int id = Convert.ToInt16(selectedID[0].ToString());
                    Response.Redirect("~/System/UserRole.aspx?ID=" + id);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAll();
            }
            else
            {
                Search();
            }
        }

        private ArrayList GetSelectedRecord()
        {
            // GridViewRow row;
            user = new UserBL();
            ArrayList selectedID = new ArrayList();
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvUser.Rows[i].Cells[0].FindControl("chkStatus");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        selectedID.Add(Convert.ToInt16(gvUser.DataKeys[i].Value));
                    }
                }
            }
            return selectedID;
        }

        public void Search()
        {
            UserBL user = new UserBL();
            DataTable dt = new DataTable();
            dt = user.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvUser.DataSource = dt;
                gvUser.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0, 0, 0);
                gvUser.DataSource = dt;
                gvUser.DataBind();
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/System/User.aspx");
        }
    }
}