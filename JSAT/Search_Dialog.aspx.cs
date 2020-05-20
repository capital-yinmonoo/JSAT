using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT
{
    public partial class Search_Dialog : System.Web.UI.Page
    {
        public static String sortBy = "Original";
        public static String columnName = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (String.Equals(Request.QueryString["Type"], "2"))
                {
                    lblSearch.Text = "Name:";
                    lblCode.Text = "No:";
                    ddlCode.Visible = true;
                    lblCode1.Visible = true;
                }
                dgvClientProfile.DataSource = FillDataGrid(Request.QueryString["Type"]);
                dgvClientProfile.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dgvClientProfile.DataSource = FillDataGrid(Request.QueryString["Type"]);
            dgvClientProfile.DataBind();
        }

        protected void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            rdo.Checked = true;
            GridViewRow gr = (GridViewRow)rdo.Parent.Parent;
            txtID.Text = gr.Cells[1].Text;
            txtName.Text = gr.Cells[2].Text;
            txtData.Text = gr.Cells[3].Text;
        }

        protected void dgvClientProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientProfile.PageIndex = e.NewPageIndex;
            if (!String.IsNullOrWhiteSpace(columnName))
            {
                if (sortBy == "Desc")
                {
                    sortBy = "Asc";
                }
                else if (sortBy == "Asc")
                {
                    sortBy = "Original";
                }
                else if (sortBy == "Original")
                {
                    sortBy = "Desc";
                }

                SortedWith(columnName);
            }
            else
            {
                dgvClientProfile.DataSource = FillDataGrid(Request.QueryString["Type"]);
                dgvClientProfile.DataBind();
            }
        }

        protected void SortedWith(String column_Name)
        {
            if (sortBy == "Original")
            {
                DataTable dt = new DataTable();
                dt = FillDataGrid(Request.QueryString["Type"]);
                DataView dv = new DataView(dt);
                dv.Sort = column_Name + " ASC";
                dt = dv.ToTable();
                dgvClientProfile.DataSource = dt;
                dgvClientProfile.DataBind();
                sortBy = "Asc";
            }
            else if (sortBy == "Asc")
            {
                DataTable dt = new DataTable();
                dt = FillDataGrid(Request.QueryString["Type"]);
                DataView dv = new DataView(dt);
                dv.Sort = column_Name + " DESC";
                dt = dv.ToTable();
                dgvClientProfile.DataSource = dt;
                dgvClientProfile.DataBind();
                sortBy = "Desc";
            }
            else if (sortBy == "Desc")
            {
                dgvClientProfile.DataSource = FillDataGrid(Request.QueryString["Type"]);
                dgvClientProfile.DataBind();
                sortBy = "Original";
            }
        }

        protected void dgvClientProfile_Sorting(object sender, GridViewSortEventArgs e)
        {
            columnName = e.SortExpression;
            SortedWith(e.SortExpression);
        }

        protected DataTable FillDataGrid(String type)
        {
            if (String.Equals(type, "1"))
            {
                int? i = null;
                if (!String.IsNullOrWhiteSpace(txtCode.Text))
                {
                    if (CheckInt(txtCode.Text))
                    {
                        i = BaseLib.Convert_Int(txtCode.Text);
                    }
                    else
                    {
                        GlobalUI.MessageBox("Client Code Access Number Only.");
                    }
                }
                Client_ProfileBL cpbl = new Client_ProfileBL();
                return cpbl.SearchByName(txtSearch.Text, i);
            }
            else
            {
                Career_ResumeBL crbl = new Career_ResumeBL();
                return crbl.SearchByName(txtSearch.Text, ddlCode.SelectedItem.Text, txtCode.Text);
            }
        }

        protected Boolean CheckInt(String str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}