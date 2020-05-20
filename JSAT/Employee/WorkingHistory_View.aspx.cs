using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;

namespace JSAT.Employee
{
    public partial class WorkingHistory_View : System.Web.UI.Page
    {
        WorkingHistoryEntity.Criterias Criterial;
        Working_History_BL workbl;
        private int psize = 10; string page = null; string search = null;
        public int PageIndex
        {
            get
            {
                if (Session["PageIndex"] != null)
                {
                    int pgindex = (int)Session["PageIndex"];
                    return pgindex;
                }
                else
                {
                    return 0;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvworkinghistoryview.DataBind();
                gvworkinghistoryview.PageIndex = Convert.ToInt32(Session["Page"]);
                Session.Remove("PageIndex");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {                
                gvworkinghistoryview.PageIndex = 0;

                gvworkinghistoryview.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

      
        public void gvOnPageIndexChainging(object sender, GridViewPageEventArgs e)
        {
            gvworkinghistoryview.PageIndex = e.NewPageIndex;
            if (ScriptManager1.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            {
                ScriptManager1.AddHistoryPoint("PageIndex", gvworkinghistoryview.PageIndex.ToString());
            }
            if (ViewState["search"] != null) 
            {
                search = ViewState["search"].ToString();
                ViewState["index"] = "index";
            }
        }

        public void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataDetail")
                {
                    Session["Page"] = gvworkinghistoryview.PageIndex;
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/Employee/WorkingHistory_Detail.aspx?Career_ID=" + ID);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnaddWorkingHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkingHistory.aspx");
        }


        protected void odsUM_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            search = "";          
            string code1 = ddlcode.SelectedItem.ToString();
            string code2 = txtcode.Text;

            string name = txtName.Text;           

            if (!String.IsNullOrWhiteSpace(code1))
            {
                search += " AND Career_Code LIKE '%" + code1.Trim() + "%'";

            }
            if (!String.IsNullOrWhiteSpace(code2))
            {
                search += " AND Career_Code LIKE '%" + code2.Trim() + "%'";

            }

            if (!string.IsNullOrEmpty(name))
            {
                search += " AND Name LIKE '%" + name.Trim() + "%'";
            }

            e.InputParameters["search"] = search;
        }

        protected void ScriptManager1_Navigate(object sender, HistoryEventArgs e)
        {
            string pageIndex = e.State["PageIndex"];
            if (Session["index"] != null)
            {
                page = Session["index"].ToString();
            }
            if (string.IsNullOrEmpty(pageIndex))
            {
                gvworkinghistoryview.PageIndex = 0;
            }
            else if (page != null)
            {
                gvworkinghistoryview.PageIndex = 0;
                page = null;
                Session["index"] = null;
            }
            else
            {
                gvworkinghistoryview.PageIndex = Convert.ToInt32(pageIndex);
            }
        }

    }
}