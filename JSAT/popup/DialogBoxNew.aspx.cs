using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_Common;
using JSAT_BL;
using System.Configuration;
using System.Globalization;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace JSAT
{
    public partial class DialogBoxNew : System.Web.UI.Page
    {
        popup_BL popup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popup = new popup_BL();
                DataTable dt = popup.SearchByName();
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
        }

        protected void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            rdo.Checked = true;
            GridViewRow gr = (GridViewRow)rdo.Parent.Parent;
            txtEID.Text = gr.Cells[1].Text;
            txtEmployeeCode.Text = gr.Cells[2].Text;
            txtEmployeeName.Text = gr.Cells[3].Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            popup = new popup_BL();
            DataTable dt=popup.PopupSearchEmployeeName(txtSearchEName.Text.Trim(), txtSearchECode.Text.Trim());
            gvEmployee.DataSource = dt;
            gvEmployee.DataBind();
        }

        protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            popup = new popup_BL();
            gvEmployee.PageIndex = e.NewPageIndex;
            DataTable dt = popup.SearchByName();
            gvEmployee.DataSource = dt;
            gvEmployee.DataBind();
        }

        protected void gvEmployee_rowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Session["checkedValueName"] != null && Session["checkedValueCode"] != null)
                {
                    ArrayList arrlstname = Session["checkedValueName"] as ArrayList;
                    ArrayList arrlstcode = Session["checkedValueCode"] as ArrayList;
                    foreach (string code in arrlstcode)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "Employee_Code").ToString() == code)
                        {
                            CheckBox bf = (e.Row.Cells[0].FindControl("chkSearch") as CheckBox);
                            bf.Checked = true;
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}