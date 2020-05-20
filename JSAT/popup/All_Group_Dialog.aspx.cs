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

namespace JSAT
{
    public partial class All_Group_Dialog : System.Web.UI.Page
    {
        popup_BL popup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popup = new popup_BL();
                DataTable dt=popup.SearchByGroupName();
                gvGroup.DataSource = dt;
                gvGroup.DataBind();
            }
        }

        protected void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            rdo.Checked = true;
            GridViewRow gr = (GridViewRow)rdo.Parent.Parent;
            Session["GroupID"] = gr.Cells[1].Text;
            txtGroupID.Text = gr.Cells[1].Text;
            txtGroupName.Text = gr.Cells[2].Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            popup = new popup_BL();
            int code = 0;
            if (txtSearchGroupID.Text != String.Empty)
            {
                code = Convert.ToInt32(txtSearchGroupID.Text);
            }
            DataTable dt=popup.PopupSearchGroupName(txtSearchGroupName.Text, code);
            gvGroup.DataSource = dt;
            gvGroup.DataBind();
        }

        protected void gvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            popup = new popup_BL();
            gvGroup.PageIndex = e.NewPageIndex;
            DataTable dt=popup.SearchByGroupName();
            gvGroup.DataSource = dt;
            gvGroup.DataBind();
        }
    }
}