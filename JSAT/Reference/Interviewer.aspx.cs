using JSAT_BL;
using JSAT_Common;
using JSAT_DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Interviewer : System.Web.UI.Page
    {
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectAllData();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SelectAllData();
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            txtSearchInterviewer.Text = string.Empty;
            SelectAllData();
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            SelectAllData();
            gvInterviewer.PageIndex = e.NewPageIndex;
            gvInterviewer.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Name = ((TextBox)gvInterviewer.FooterRow.FindControl("txtNewInterviewer")).Text;
            bool result = CheckExistingName(Name);
            if (result == true)
                GlobalUI.MessageBox(Name + "has been already registered!!.");
            else
            {
                if (string.IsNullOrWhiteSpace(Name) || BaseLib.IsInt(Name))
                {
                    if (string.IsNullOrWhiteSpace(Name))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    Insert(Name, 0, 0);
                    GlobalUI.MessageBox("Save Successfully");
                }
            }
            SelectAllData();
        }

        protected void gvInterviewer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt16(((Label)gvInterviewer.Rows[e.RowIndex].FindControl("lblID")).Text);
            Delete(ID);
            GlobalUI.MessageBox("Delete Successfully");
            SelectAllData();
        }

        //protected void gvInterviewer_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvInterviewer.EditIndex = e.NewEditIndex;
        //    SelectAllData();
        //}
        protected void gvInterviewer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Industry_TypeBL Industry = new Industry_TypeBL();
            hdfupdate.Value = "update";
            if (search == false)
            {
                gvInterviewer.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            else
            {
                gvInterviewer.EditIndex = e.NewEditIndex;
                SelectAllData();
            }
            hdfupdate.Value = "";
        }


        protected void gvInterviewer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ID = Convert.ToInt16(((Label)gvInterviewer.Rows[e.RowIndex].FindControl("lblID")).Text);
            string Name = ((TextBox)gvInterviewer.Rows[e.RowIndex].FindControl("txtInterviewerName")).Text;
            bool result = CheckExistingName(Name);
            if (result == true)
                GlobalUI.MessageBox(Name + " type has been already.");
            else if (ID >= 1)
            {
                if (string.IsNullOrWhiteSpace(Name) || BaseLib.IsInt(Name))
                {
                    if (string.IsNullOrWhiteSpace(Name))
                        GlobalUI.MessageBox("Not Allow Empty String!");
                    else
                        GlobalUI.MessageBox("Not Allow Number!");
                }
                else
                {
                    Insert(Name, ID, 1);
                }
            }
            else
            {
                Name = ((TextBox)gvInterviewer.FooterRow.FindControl("txtInterviewerName")).Text;
                Insert(Name, 0, 0);
            }
            if (search == false)
            {
                gvInterviewer.EditIndex = -1;
            }
            else
            {
                gvInterviewer.EditIndex = -1;
                GlobalUI.MessageBox("Update Successfully");
                SelectAllData();
            }
        }

        protected void gvInterviewer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInterviewer.EditIndex = -1;
            SelectAllData();
        }

        //protected void gvInterviewer_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    UserRoleBL user = new UserRoleBL();
        //    int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[2].Controls[0].Visible = false;
        //        e.Row.Cells[2].Controls[2].Visible = false;
        //        int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "ID").ToString());
        //        if (ID == 0)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        bool resultRead = user.CanRead(userID, "033");
        //        if (resultRead)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = false;
        //            e.Row.Cells[2].Controls[2].Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "033");
        //        if (resultEdit)
        //        {
        //            e.Row.Cells[2].Controls[0].Visible = true;
        //        }
        //        bool resultdelete = user.CanDelete(userID, "033");
        //        if (resultdelete)
        //        {
        //            e.Row.Cells[2].Controls[2].Visible = true;
        //        }
        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        bool resultRead = user.CanRead(userID, "033");
        //        Button btn = e.Row.FindControl("btnSave") as Button;
        //        if (resultRead)
        //        {
        //            e.Row.Visible = false;
        //        }
        //        bool resultEdit = user.CanSave(userID, "033");
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

        protected void gvInterviewer_RowDataBound(object sender, GridViewRowEventArgs e)
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
                bool resultRead = user.CanRead(userID, "033");
                bool resultEdit = user.CanSave(userID, "033");
                bool resultDelete = user.CanDelete(userID, "033");
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
                bool resultRead = user.CanRead(userID, "033");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "033");
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
            DataTable dt = new DataTable();
            dt = SelectAll(txtSearchInterviewer.Text);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                gvInterviewer.DataSource = dt;
                gvInterviewer.DataBind();
            }
            else
            {
                gvInterviewer.DataSource = dt;
                gvInterviewer.DataBind();
            }
        }

        public DataTable SelectAll(string name)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SP_SelectAll_Interviewer", DataConfig.connectionString);
            try
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.SelectCommand.Connection.Open();
                sda.SelectCommand.Parameters.AddWithValue("@Name", name);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sda.SelectCommand.Connection.Close();
                sda.Dispose();
            }
        }

        public bool CheckExistingName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Check_Interviewer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection connection = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = "SP_Delete_Interviewer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }

        public void Insert(string name, int id, int option)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnection sqlcon = new SqlConnection(DataConfig.connectionString);
                cmd.CommandText = ("SP_InsertUpdate_Interviewer");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Option", option);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
    }
}