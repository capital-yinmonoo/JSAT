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
    public partial class Job_Dialog : System.Web.UI.Page
    {
        popup_BL popup;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popup = new popup_BL();
                string cname = Convert.ToString(Session["ID"]);
                DataTable dt = popup.SearchByJobNo(cname);
                gvCompany.DataSource = dt;
                gvCompany.DataBind();
            }
        }

        protected void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            rdo.Checked = true;
            GridViewRow gr = (GridViewRow)rdo.Parent.Parent;
            txtNo.Text = gr.Cells[1].Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
                popup = new popup_BL();
                string code = txtJobNo.Text.Trim();
                string cname = txtName.Text.Trim();
                DataTable dt = popup.PopupSearchJobCode(code);
                gvCompany.DataSource = dt;
                gvCompany.DataBind();
        }

        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            popup = new popup_BL();
            gvCompany.PageIndex = e.NewPageIndex;
            string cname = Convert.ToString(Session["ID"]);
            DataTable dt = popup.SearchByJobNo(cname);
            gvCompany.DataSource = dt;
            gvCompany.DataBind();
        }

     
    }
}