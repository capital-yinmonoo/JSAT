using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;

namespace JSAT
{
    public partial class IntroductionListForCareer_GoDetail : System.Web.UI.Page  
    { 
        IntroductionListForCareer_BL introbl;
        IntroductionListForCareer_Entity introentity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                gvsuccessworkerdetail.DataBind();
            }
        }  

        public void gvpageindexchage(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvsuccessworkerdetail.PageIndex = 0;

                gvsuccessworkerdetail.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public void gvrowcommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataEdit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    //Response.Redirect("~/AccessCheck.aspx");
                    Response.Redirect("~/Employee/IntroductionListFor_Career.aspx?ID=" + ID);
                    //string queryString = "AccessCheck.aspx";
                    //string newWin = "window.open('" + queryString + "');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "Pop", newWin, true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                }
                else { }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grid1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            gvsuccessworkerdetail.DataBind();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Delete Successfult')", true);

        }

        protected void btnaddnewIntorduction_Click(object sender, EventArgs e)
        {
            Response.Redirect("IntroductionListFor_Career.aspx");
        }

        
        protected void odsUM_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string search = "";           
            string code1 = ddlcode.SelectedItem.ToString();
            string code2 = txtcode.Text;
            string name = txtName.Text;           
            if (!String.IsNullOrWhiteSpace(code1))
            {
                search += " AND  Carrer_Code LIKE '%" + code1.Trim() + "%'";

            }
            if (!String.IsNullOrWhiteSpace(code2))
            {
                search += " AND  Carrer_Code LIKE '%" + code2.Trim() + "%'";

            }
            if (!string.IsNullOrEmpty(name))
            {
                search += " AND Name LIKE '%" + name.Trim() + "%'";
            }

            e.InputParameters["search"] = search;
            
        }


    }
}