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
    public partial class Employee_Name : System.Web.UI.Page
    {
        popup_BL popup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popup = new popup_BL();
                DataTable dt = popup.SearchByEmploeeName();
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
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

        protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            popup = new popup_BL();
            gvEmployee.PageIndex = e.NewPageIndex;
            DataTable dt = popup.SearchByEmploeeName();
            gvEmployee.DataSource = dt;
            gvEmployee.DataBind();
        }

        protected void chkSearch_CheckedChanged(object sender, EventArgs e)
        {
            string chkid = null;
            foreach (GridViewRow row in gvEmployee.Rows)
            {
                Label Id = row.FindControl("lblID") as Label;
                CheckBox chkBox = row.FindControl("chkSearch") as CheckBox;
                if (chkBox != null)
                {
                    if (chkBox.Checked)
                    {
                        chkid += Convert.ToInt16(Id.Text) + ",";
                    }

                }
            }
            if (!String.IsNullOrWhiteSpace(chkid))
            {
                popup = new popup_BL();
                DataTable dt = popup.Select_Employee_Name(chkid);
                txtEmployeeName.Text = Convert.ToString(dt.Rows[0]["Employee_Name"]);
                txtEID.Text = chkid;
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            popup = new popup_BL();
            DataTable dt = popup.PopupSearchEmployeeName(txtSearchEName.Text, txtSearchECode.Text);
            gvEmployee.DataSource = dt;
            gvEmployee.DataBind();
        }
    }
}