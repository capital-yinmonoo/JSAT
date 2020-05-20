using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;

namespace JSAT.Employee
{
    public partial class InterviewList : System.Web.UI.Page
    {
        InterviwList_BL list;
        CheckBox chkbefore;
        CheckBox chktheday;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["Job_No"] != null)
                {
                    int Jobno = int.Parse(Request.QueryString["Job_No"]);
                    list = new InterviwList_BL();
                    DataTable dtblist = new DataTable();
                    dtblist = list.SelectbyJobno(Jobno);
                    lblinterviewdate.Text = dtblist.Rows[0]["Interview_Date"].ToString();
                    lbljobno.Text = Jobno.ToString();
                    lblhpaddress.Text = dtblist.Rows[0]["Location"].ToString();
                    lblcompanyname.Text = dtblist.Rows[0]["Client_Name"].ToString();
                    lblposition.Text = dtblist.Rows[0]["Position"].ToString();
                    //lblinterviewplace.Text = dtblist.Rows[0]["Interview_Place"].ToString();
                    lblcontactperson.Text = dtblist.Rows[0]["Gender"].ToString() + "." + dtblist.Rows[0]["PersonInCharge"].ToString();
                    lblcontactno.Text = dtblist.Rows[0]["Telephone_No"].ToString();

                    BindData(lblcompanyname.Text, lbljobno.Text, lblposition.Text);
                }
            }

        }
        public void BindData(string companyname, string jobno, string lblposition)
        {
            list = new InterviwList_BL();
            DataTable dtb = new DataTable();
            dtb = list.SelectPersonForInterview(companyname, Convert.ToInt32(jobno));
            gvinterview.DataSource = dtb;
            gvinterview.DataBind();

            foreach (GridViewRow gvrow in gvinterview.Rows)
            {

                Label careerid = gvrow.FindControl("lblid") as Label;
                lblcareerid.Text = careerid.Text;
                DataTable dtselect = new DataTable();
                dtselect = list.GetCareer_Code(lblcareerid.Text, companyname, Convert.ToInt32(jobno));
                //for (int i = 0; i < dtselect.Rows.Count; i++)
                //{
                if (dtselect.Rows.Count > 0)
                {
                    if (!String.IsNullOrWhiteSpace(dtselect.Rows[0]["Before"].ToString()))
                    {
                        if ((bool)dtselect.Rows[0]["Before"])
                        {
                            chkbefore = (CheckBox)gvrow.FindControl("chkbefore");
                            chkbefore.Checked = true;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(dtselect.Rows[0]["The_Day"].ToString()))
                    {
                        if ((bool)dtselect.Rows[0]["The_Day"])
                        {
                            chktheday = (CheckBox)gvrow.FindControl("chktheday");
                            chktheday.Checked = true;
                        }
                    }
                }
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            InterviewList_Entity listentity = new InterviewList_Entity();
            list = new InterviwList_BL();
            foreach (GridViewRow row in gvinterview.Rows)
            {
                CheckBox chkbefore = (row.Cells[4].FindControl("chkbefore") as CheckBox);
                CheckBox chktheday = (row.Cells[5].FindControl("chktheday") as CheckBox);
                Label careerid = row.FindControl("lblid") as Label;
                lblcareerid.Text = careerid.Text;
                listentity.Before = chkbefore.Checked;
                listentity.Theday = chktheday.Checked;
                listentity.Career_ID = Convert.ToInt32(lblcareerid.Text);
                listentity.Jobno = Convert.ToInt32(lbljobno.Text);
                list.UpdateComfirm(listentity);
            }
            string script = "window.onload = function(){ alert('";
            script += "Save Successfully";
            script += "');";
            script += "window.location = '";
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

        }
        //GridViewRow selectedRow = gvinterview.Rows[index];
        //CheckBox chkbefore = (CheckBox)sender;
        //CheckBox chktheday = (CheckBox)sender;
        //listentity.Before = chkbefore.Checked;
        //listentity.Theday = chktheday.Checked;


        public void gvinterviewpageindexchanging(object sender, GridViewPageEventArgs e)
        {
            gvinterview.PageIndex = e.NewPageIndex;
            BindData(lblcompanyname.Text, lbljobno.Text, lblposition.Text);

        }
    }
}