using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Instituation : System.Web.UI.Page
    {
        Instituation_AreaBL instarea;
        InstituationBL instituation;
        InstituationEntity InstituationInfo;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAll(0);
            }
        }

        protected void gvInstituation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInstituation.EditIndex = -1;
            SearchData();
        }

        //protected void gvInstituation_RowDataBound(object sender, GridViewRowEventArgs e)
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
        //        bool resultRead = user.CanRead(userID, "008");
        //        if (resultRead)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = false;
        //            e.Row.Cells[2].Controls[2].Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "008");
        //        if (resultEdit)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = true;
        //        }
        //        bool resultDelete = user.CanDelete(userID, "008");
        //        if (resultDelete)
        //        {
        //            e.Row.Cells[2].Controls[2].Visible = true;
        //        }
        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        //hide Save Button
        //        bool resultRead = user.CanRead(userID, "008");
        //        Button btn = e.Row.FindControl("btnSave") as Button;
        //        if (resultRead)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "008");
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

        protected void gvInstituation_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultEdit = user.CanSave(userID, "008");
                bool resultDelete = user.CanDelete(userID, "008");
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
                bool resultRead = user.CanRead(userID, "008");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "008");
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InstituationInfo = new InstituationEntity();
            instituation = new InstituationBL();
            InstituationInfo.ID = Convert.ToInt32(((DropDownList)gvInstituation.FooterRow.FindControl("ddlInstitute")).SelectedValue);
            InstituationInfo.Instituation_ID = Convert.ToInt32(((DropDownList)gvInstituation.FooterRow.FindControl("ddlArea")).SelectedValue);
            if (InstituationInfo.ID == 0 || InstituationInfo.Instituation_ID == 0)
            {
                GlobalUI.MessageBox("Please Select Instituation or Instituation Area!!");
            }
            else
            {
                bool result = instituation.CheckExistingInstituation(InstituationInfo.ID, InstituationInfo.Instituation_ID);
                if (result == true)
                    GlobalUI.MessageBox("This Instituation has been already Register!!!");
                else
                {
                    bool check = instituation.InsertInstituation(InstituationInfo);
                    if (check)
                    {
                        GlobalUI.MessageBox("Instituation with Township Register Successfully!!");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Instituation_Details.aspx','_newtab');", true);
                    }
                }
            }
        }

        private static DataTable GetData(string query)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            DropDownList ddl = gvInstituation.FooterRow.FindControl("ddlArea") as DropDownList;
            ddl.DataSource = GetData("SELECT * FROM Instituation_Area where IsDeleted=0 order by Description asc");
            ddl.DataTextField = "Description";
            ddl.DataValueField = "ID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList ddlInstitute = gvInstituation.FooterRow.FindControl("ddlInstitute") as DropDownList;
            ddlInstitute.DataSource = GetData("SELECT * FROM Institution where IsDeleted=0 order by Description asc");
            ddlInstitute.DataTextField = "Description";
            ddlInstitute.DataValueField = "ID";
            ddlInstitute.DataBind();
            ddlInstitute.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        

        protected void gvInstituation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            InstituationInfo = new InstituationEntity();
            instituation = new InstituationBL();
            InstituationInfo.ID = Convert.ToInt16(((Label)gvInstituation.Rows[e.RowIndex].FindControl("lblID")).Text);
            if (instituation.Delete(InstituationInfo.ID)) GlobalUI.MessageBox("Delete Successfully!");
            SearchData();
        }

        protected void gvInstituation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvInstituation.EditIndex = e.NewEditIndex;
            SearchData();
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Instituation_Details.aspx','_newtab');", true);
        }

        protected void gvInstituation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            InstituationInfo = new InstituationEntity();
            instituation = new InstituationBL();
            InstituationInfo.ID = Convert.ToInt16(((Label)gvInstituation.Rows[e.RowIndex].FindControl("lblID")).Text);
            InstituationInfo.Description = ((TextBox)gvInstituation.Rows[e.RowIndex].FindControl("txtDescriptionEdit")).Text;
            bool result = instituation.CheckExistingType(InstituationInfo.ID, InstituationInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed.");
            else if (InstituationInfo.ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(InstituationInfo.Description) || BaseLib.IsInt(InstituationInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(InstituationInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                    if (instituation.Update(InstituationInfo)) GlobalUI.MessageBox("Update successfully!");
            }
            else
            {
                InstituationInfo.Description = ((TextBox)gvInstituation.FooterRow.FindControl("txtDescriptionSave")).Text;
                if (instituation.Insert(InstituationInfo)) GlobalUI.MessageBox("Insert successfully!");
            }
            gvInstituation.EditIndex = -1;
            SearchData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InstituationInfo = new InstituationEntity();
            instituation = new InstituationBL();
            InstituationInfo.Description = ((TextBox)gvInstituation.FooterRow.FindControl("txtDescriptionSave")).Text;
            bool result = instituation.CheckExistingType(0, InstituationInfo.Description);
            if (result == true)
                GlobalUI.MessageBox("This data has been already existed!");
            else
            {
                if (string.IsNullOrWhiteSpace(InstituationInfo.Description) || BaseLib.IsInt(InstituationInfo.Description))
                {
                    if (string.IsNullOrWhiteSpace(InstituationInfo.Description))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    bool check = instituation.Insert(InstituationInfo);
                    if (check)
                    {
                        GlobalUI.MessageBox("Instituation Name Save Successfully!!");
                        gvInstituation.PageIndex = 0;
                    }
                    SelectAll(0);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                SelectAll(0);
            }
            else
            {
                SearchData();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;
            gvInstituation.PageIndex = 0;
            SelectAll(0);
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            SearchData();
            gvInstituation.PageIndex = e.NewPageIndex;
            gvInstituation.DataBind();

        }

        protected void SearchData()
        {
            instituation = new InstituationBL();
            DataTable dt = new DataTable();
            dt = instituation.Search(txtSearch.Text);
            if (dt.Rows.Count > 0)
            {
                gvInstituation.DataSource = dt;
                gvInstituation.DataBind();
            }
            else
            {
                dt.Rows.Add(0, 0, 0);
                gvInstituation.DataSource = dt;
                gvInstituation.DataBind();
            }
        }

        protected void SelectAll(int IorCRV)
        {
            instituation = new InstituationBL();
            DataTable dt = new DataTable();
            dt = instituation.SelectAll(IorCRV);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvInstituation.DataSource = dt;
                gvInstituation.DataBind();
            }
            else
            {
                gvInstituation.DataSource = dt;
                gvInstituation.DataBind();
            }
        }
    }
}