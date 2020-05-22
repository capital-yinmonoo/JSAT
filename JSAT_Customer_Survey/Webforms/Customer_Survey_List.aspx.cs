using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using System.Web.Services;
using JSAT_Common;
using System.Web.Script.Services;
//using static JSAT_Common.Customer_Survey_Entity;


namespace JSAT_Customer_Survey.Webforms
{
    public partial class Customer_Survey_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_Survey();
            }
        }

        public void Bind_Survey()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("PhoneNo");
            dt.Rows.Add();

            gvSurvey.DataSource = dt;
            gvSurvey.DataBind();

            gvSurvey.UseAccessibleHeader = true;
            gvSurvey.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

       [WebMethod]
        public static List<Customer> GetSurvey()
        {
            List<Customer> customers = new List<Customer>();
            Customer_Survery_BL csbl = new Customer_Survery_BL();
            DataTable dt = new DataTable();

            dt = csbl.Select_Survey();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Customer customer = new Customer();
                customer.ID = dt.Rows[i]["ID"].ToString();
                customer.Name = dt.Rows[i]["Name"].ToString();
                customer.PhoneNo = dt.Rows[i]["PhoneNo"].ToString();
                customers.Add(customer);
            }
            return customers;
        }

        public class Customer
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string PhoneNo { get; set; }
        }


    }
}