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
    public partial class JobDialogBox : System.Web.UI.Page
    {
        popup_BL popup;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                popup = new popup_BL();
                int id = Convert.ToInt32(Session["JobID"]);
                    DataTable dt = popup.SearchByJobName(id);
                    gvJobPosition.DataSource = dt;
                    gvJobPosition.DataBind();
             
                    //DataTable dt = popup.SearchByJobName1();
                    //gvJobPosition.DataSource = dt;
                    //gvJobPosition.DataBind();
                }
            //}
        }

        protected void rdoSearch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            rdo.Checked = true;
            GridViewRow gr = (GridViewRow)rdo.Parent.Parent;
            Session["JobID"] = gr.Cells[1].Text;
            txtJobCode.Text = gr.Cells[1].Text;
            txtJobDesc.Text = gr.Cells[2].Text;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            popup = new popup_BL();
            int code = 0;
            if (txtSearchJobCode.Text != String.Empty)
            {
                code = Convert.ToInt32(txtSearchJobCode.Text.Trim());
            }
            DataTable dt=popup.PopupSearchJobPosition(txtSearchJobName.Text.Trim(), code);
            gvJobPosition.DataSource = dt;
            gvJobPosition.DataBind();
        }

        protected void gvJobPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            popup = new popup_BL();
            gvJobPosition.PageIndex = e.NewPageIndex;
            int id = Convert.ToInt32(Session["JobID"]);
            DataTable dt = popup.SearchByJobName(id);
            gvJobPosition.DataSource = dt;
            gvJobPosition.DataBind();
        }
    }
}