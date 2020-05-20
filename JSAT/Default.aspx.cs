using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1
{
    public partial class Default : System.Web.UI.Page
    {
        string search = null;
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
               // gvDateUser.DataBind();
                gvDateUser.PageIndex = Convert.ToInt32(Session["Page"]);
                Session.Remove("PageIndex");
            }

        }

        public void gvOnPageIndexChainging(object sender, GridViewPageEventArgs e)
        {
            gvDateUser.PageIndex = e.NewPageIndex;
            //if (ScriptManager1.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            //{
            //    ScriptManager1.AddHistoryPoint("PageIndex", gvDateUser.PageIndex.ToString());
            //}
            if (ViewState["search"] != null)
            {
                search = ViewState["search"].ToString();
                ViewState["index"] = "index";
            }
        }

        protected void odsUM_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            search = "";            

            e.InputParameters["search"] = search;
        }

    }
}