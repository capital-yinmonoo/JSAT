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

namespace JSAT.popup
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        popup_BL popup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popup = new popup_BL();
                DataTable dt = popup.SearchByCName();
                gvCompany.DataSource = dt;
                gvCompany.DataBind();
            }
        }

        protected void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            rdo.Checked = true;
            GridViewRow gr = (GridViewRow)rdo.Parent.Parent;
            txtName.Text = gr.Cells[2].Text;
            txtID.Text = gr.Cells[1].Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            popup = new popup_BL();
            //int code = 0;
            //if (txtSearchCode.Text != String.Empty)
            //{
            //    code = Convert.ToInt32(txtSearchCode.Text);
            //}
            //DataTable dt = popup.PopupSearchCName(txtSearchName.Text, code);
            DataTable dt = popup.PopupSearchCName(txtSearchName.Text.Trim());
            gvCompany.DataSource = dt;
            gvCompany.DataBind();
        }

        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            popup = new popup_BL();
            gvCompany.PageIndex = e.NewPageIndex;
            DataTable dt = popup.SearchByCName();
            gvCompany.DataSource = dt;
            gvCompany.DataBind();
        }
    }
}