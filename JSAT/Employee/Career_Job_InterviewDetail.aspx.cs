using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT.Employee
{
    public partial class Career_Job_InterviewDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int rec_id = 0;
            int career_id = 0;
            if (Request.QueryString["Client_RecruitmentID"] != null)
                rec_id = BaseLib.Convert_Int(Request.QueryString["Client_RecruitmentID"].ToString());
            if (Request.QueryString["Career_ID"] != null)
            {
                career_id = BaseLib.Convert_Int(Request.QueryString["Career_ID"].ToString());
            }

            Client_RecruitmentBL crbl = new Client_RecruitmentBL();
            DataTable dt = new DataTable();
            dt = crbl.SelectByID(rec_id);
            lblName.Text = dt.Rows[0]["Name"].ToString();
            lblDepartment.Text = dt.Rows[0]["DivitionOrDepartment"].ToString();

            Career_Job_InterviewBL cjibl = new Career_Job_InterviewBL();
            dt = new DataTable();
            dt = cjibl.SelectByID(rec_id, career_id);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Interview"].ToString().ToLower() == "true")
                    lblInterview.Text = "○";
                else if (dt.Rows[0]["Interview"].ToString().ToLower() == "false")
                    lblInterview.Text = "×";

                if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Interview_Date"].ToString()))
                {
                    DateTime date = (DateTime)dt.Rows[0]["Interview_Date"];
                    // lblInterviewDate.Text = Convert.ToDateTime(d.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd MMM yyyy");
                    lblInterviewDate.Text = GlobalUI.Format_Date(date.ToString());
                }

                if (dt.Rows[0]["Interview_Result"].ToString().ToLower() == "true")
                    lblInterviewResult.Text = "○";
                else if (dt.Rows[0]["Interview_Result"].ToString().ToLower() == "false")
                    lblInterviewResult.Text = "×";

                if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Interview_Result_Date"].ToString()))
                {
                    DateTime date = (DateTime)dt.Rows[0]["Interview_Result_Date"];
                    //lblInterviewResultDate.Text = Convert.ToDateTime(d.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd MMM yyyy");
                    lblInterviewResultDate.Text = GlobalUI.Format_Date(date.ToString());
                }

                lblSalary.Text = GlobalUI.Format_Salary(int.Parse(dt.Rows[0]["Salary"].ToString())) + " " + dt.Rows[0]["Salary_Type"].ToString();
                lblComment.Text = dt.Rows[0]["Comment"].ToString();
            }
        }
        protected void btnCV_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Career_Job_Interview.aspx?Client_RecruitmentID=" + Request.QueryString["Client_RecruitmentID"] + "&Career_ID=" + Request.QueryString["Career_ID"]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}