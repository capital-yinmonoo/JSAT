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
using static JSAT_Common.Customer_Survey_Entity;


namespace JSAT_Customer_Survey.Webforms
{
    public partial class Customer_Survey_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
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
                customer.Q1 = dt.Rows[i]["Q1"].ToString();
                customer.Q2 = dt.Rows[i]["Q2"].ToString();
                customer.Q3 = dt.Rows[i]["Q3"].ToString();
                customer.Q4 = dt.Rows[i]["Q4"].ToString();
                customer.Q5 = dt.Rows[i]["Q5"].ToString();
                customer.Q6 = dt.Rows[i]["Q6"].ToString();
                customer.Q7 = dt.Rows[i]["Q7"].ToString();
                customer.Q8 = dt.Rows[i]["Q8"].ToString();
                customer.Q9 = dt.Rows[i]["Q9"].ToString();
                customer.Description = dt.Rows[i]["Description"].ToString();
                customer.InsertedDate = dt.Rows[i]["InsertedDate"].ToString();
                customers.Add(customer);
            }
            return customers;
        }
    }
}