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
    public partial class DegreeType : System.Web.UI.Page
    {
        InstituationBL university;
        DegreeType_BL dbl;
        DegreeType_Entity dte;
        bool search = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_University();
                SelectAll();
            }
        }

        protected void Get_University()
        {
            university = new InstituationBL();
            ddlDegree.DataSource = university.SelectAll(1);
            ddlDegree.DataTextField = "Description";
            ddlDegree.DataValueField = "ID";
            ddlDegree.DataBind();
            ddlDegree.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtsearchDegree.Text == "")
            {
                ddlDegree.SelectedValue = "0";
                SelectAll();
            }
            else
            {
                SearchData();
            }
        }

        protected DataTable SearchData()
        {
            dbl = new DegreeType_BL();
            DataTable dt = new DataTable();
            if (ddlDegree.SelectedItem.Value == "0")
            {
                dt = dbl.Search(int.Parse(ddlDegree.SelectedValue), TxtsearchDegree.Text);
                if (dt.Rows.Count > 0)
                {
                    GVdegree.DataSource = dt;
                    GVdegree.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    GVdegree.DataSource = dt;
                    GVdegree.DataBind();
                }
            }
            else
            {
                dt = dbl.Search(int.Parse(ddlDegree.SelectedValue), TxtsearchDegree.Text);
                if (dt.Rows.Count > 0)
                {
                    GVdegree.DataSource = dt;
                    GVdegree.DataBind();
                }
                else
                {
                    dt.Rows.Add(0, 0, 0, 0);
                    GVdegree.DataSource = dt;
                    GVdegree.DataBind();
                }
            }
            return dt;
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            SelectAll();
            ddlDegree.SelectedValue = "0";
            TxtsearchDegree.Text = string.Empty;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ((TextBox)GVdegree.FooterRow.FindControl("txtDegreeSave")).Text = String.Empty;
            ((Button)GVdegree.FooterRow.FindControl("btnCancel")).Visible = false;
            ((Button)GVdegree.FooterRow.FindControl("btnSave")).Text = "Save";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            dte = new DegreeType_Entity();
            dbl = new DegreeType_BL();
            dte.University_ID = int.Parse(ddlDegree.SelectedValue);
            string SaveorUpdate = ((Button)GVdegree.FooterRow.FindControl("btnSave")).Text;
            if (SaveorUpdate == "Update")
            {
                dte.ID = Convert.ToInt32(hdfID.Value);
                if (dte.University_ID == 0)
                {
                    DataTable dt = dbl.GetByInstitutionID(dte.ID);
                    int ID = Convert.ToInt32(dt.Rows[0]["University_ID"]);
                    dte.University_ID = ID;
                }
                dte.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                dte.Degree_Description = ((TextBox)GVdegree.FooterRow.FindControl("txtDegreeSave")).Text;
                ViewState["description"] = dte.Degree_Description;
                bool result = dbl.CheckExistingType(dte.University_ID, dte.Degree_Description, dte.ID);
                if (result == true)
                    GlobalUI.MessageBox("This data has been already existed!");
                else if (dte.ID >= 1)
                {
                    if (string.IsNullOrWhiteSpace(dte.Degree_Description) || BaseLib.IsInt(dte.Degree_Description))
                    {
                        if (string.IsNullOrWhiteSpace(dte.Degree_Description))
                            GlobalUI.MessageBox("Not Allow Empty String!");
                        else
                            GlobalUI.MessageBox("Not Allow Number!");
                    }
                    else
                    {
                        CreatedDateTime();
                        dbl.Update(dte);
                        GlobalUI.MessageBox("Record Updated Successfully.");
                    }
                }
            }
            else
            {
                if (dte.University_ID == 0)
                {
                    GlobalUI.MessageBox(" Please, Select Institution.");
                    SelectAll();
                }
                else
                {
                    dte.Degree_Description = ((TextBox)GVdegree.FooterRow.FindControl("txtDegreeSave")).Text;
                    bool result = dbl.CheckExistingType(dte.University_ID, dte.Degree_Description, 0);
                    if (result == true)
                        GlobalUI.MessageBox("This data has been already existed!");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(dte.Degree_Description) || BaseLib.IsInt(dte.Degree_Description))
                        {
                            if (string.IsNullOrWhiteSpace(dte.Degree_Description))
                                GlobalUI.MessageBox("Not Allow Empty String!");
                            else
                                GlobalUI.MessageBox("Not Allow Number!");
                        }
                        else
                        {
                            CreatedDateTime();
                            int id = Convert.ToInt32(Session["UserID"]);
                            dte.CreatedBy = id;
                            dbl.Insert(dte);
                            GlobalUI.MessageBox("Saved Successfully.");
                            GVdegree.PageIndex = 0;
                        }
                    }
                }
            }
            SelectByInstitution(int.Parse(ddlDegree.SelectedValue));
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Edit":
                    dbl = new DegreeType_BL();
                    Button btn = (Button)e.CommandSource;
                    GridViewRow grdrow = ((GridViewRow)btn.NamingContainer);
                    Label id = (Label)grdrow.FindControl("lblid");
                    int bbID = Convert.ToInt32(id.Text);
                    if (bbID != 0)
                    {
                        DataTable dt = dbl.GetByInstitutionID(bbID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int ID = Convert.ToInt32(dt.Rows[0]["University_ID"]);
                            ddlDegree.SelectedValue = ID.ToString();
                        }
                    }
                    DataTable resultdt = new DataTable();
                    resultdt = SearchData();
                    GVdegree.DataBind();
                    int gvcount = resultdt.Rows.Count;
                    for (int i = 0; i < gvcount; i++)
                    {
                        if (Convert.ToInt32(resultdt.Rows[i]["Degree_ID"]) == bbID)
                        {
                            ((TextBox)GVdegree.FooterRow.FindControl("txtDegreeSave")).Text = resultdt.Rows[i]["Description"].ToString();
                            ((Button)GVdegree.FooterRow.FindControl("btnSave")).Text = "Update";
                            hdfID.Value = bbID.ToString();
                            Page.MaintainScrollPositionOnPostBack = false;
                            ((TextBox)GVdegree.FooterRow.FindControl("txtDegreeSave")).Focus();
                        }
                    }
                    TxtsearchDegree.Text = "";//For Search-edit-viewall-edit sequence condition
                    ((Button)GVdegree.FooterRow.FindControl("btnCancel")).Visible = true;
                    break;
                case "Delete":
                    Button btnDelete = (Button)e.CommandSource;
                    GridViewRow grdrowfordel = ((GridViewRow)btnDelete.NamingContainer);
                    Label idfordel = (Label)grdrowfordel.FindControl("lblid");
                    dbl = new DegreeType_BL();
                    dbl.Delete(Convert.ToInt32(idfordel.Text));
                    GlobalUI.MessageBox("Record Deleted Successfully.");
                    if (search == false)
                    {
                        SelectByInstitution(int.Parse(ddlDegree.SelectedValue));
                    }
                    else
                        SearchData();
                    break;
            }
        }

        protected void GVdegree_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void GVdegree_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GVdegree_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
            Button btnedit = e.Row.FindControl("btnedit") as Button;
            Button btndelete = e.Row.FindControl("btndelete") as Button;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                btnedit.Visible = false;
                btndelete.Visible = false;
                int ID = int.Parse(DataBinder.Eval(e.Row.DataItem, "Degree_ID").ToString());
                if (ID == 0)
                {
                    e.Row.Visible = false;
                }
                //hide Edit button
                bool resultRead = user.CanRead(userID, "050");
                if (resultRead)
                {
                    btnedit.Visible = false;
                    btndelete.Visible = false;
                }
                bool resultDelete = user.CanDelete(userID, "050");
                if (resultDelete)
                {
                    btndelete.Visible = true;
                }
                bool resultEdit = user.CanSave(userID, "050");
                if (resultEdit)
                {
                    btnedit.Visible = true;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //hide Save Button
                bool resultRead = user.CanRead(userID, "050");
                Button btn = e.Row.FindControl("btnSave") as Button;
                if (resultRead)
                {
                    e.Row.Visible = false;
                }
                bool resultEdit = user.CanSave(userID, "050");
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

        protected void SelectByInstitution(int institution_id)
        {
            dbl = new DegreeType_BL();
            DataTable dt = new DataTable();
            dt = dbl.SelectByInstitutionID(institution_id);
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0, 0);
                GVdegree.DataSource = dt;
                GVdegree.DataBind();
            }
            else
            {
                GVdegree.DataSource = dt;
                GVdegree.DataBind();
            }
        }

        protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlDegree.SelectedValue) == 0)
            {
                SelectAll();
                ddlDegree.SelectedValue = "0";
                TxtsearchDegree.Text = string.Empty;
            }
            else
                SelectByInstitution(int.Parse(ddlDegree.SelectedValue));
        }

        protected void SelectAll()
        {
            dbl = new DegreeType_BL();
            DataTable dt = new DataTable();
            dt = dbl.SelectAll();
            if (dt.Rows.Count < 1)
            {
                dt.Rows.Add(0, 0, 0);
                GVdegree.DataSource = dt;
                GVdegree.DataBind();
            }
            else
            {
                GVdegree.DataSource = dt;
                GVdegree.DataBind();
            }
        }

        protected void CreatedDateTime()
        {
            dte.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            Response.Write(dte.CreatedDate.ToString("dd/MM/yyyy"));
        }

        protected void onPaging(object sender, GridViewPageEventArgs e)
        {
            if (ddlDegree.SelectedItem.Value == "0")
            {
                if (search == false)
                {
                    SelectByInstitution(int.Parse(ddlDegree.SelectedValue));
                    GVdegree.PageIndex = e.NewPageIndex;
                    GVdegree.DataBind();
                }
                else
                {

                    SearchData();
                    GVdegree.PageIndex = e.NewPageIndex;
                    GVdegree.DataBind();
                }
            }
            else
            {
                if (search == false)
                {

                    SelectByInstitution(int.Parse(ddlDegree.SelectedValue));
                    GVdegree.PageIndex = e.NewPageIndex;
                    GVdegree.DataBind();
                }
                else
                {
                    SearchData();
                    GVdegree.PageIndex = e.NewPageIndex;
                    GVdegree.DataBind();
                }
            }
        }
    }
}