using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT_Ver1.Employer
{
    public partial class Job_Interview : System.Web.UI.Page
    {
        Job_InterviewBL ji;
        Job_InterviewEntity jiInfo;

        protected string InputValue1 { get; set; }
        protected string InputValue2 { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Client_Recruitment_ID"] != null)
                {
                    int id = Convert.ToInt16(Request.QueryString["Client_Recruitment_ID"].ToString());
                    GetData(id);
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ji = new Job_InterviewBL();
                if (Request.QueryString["Client_Recruitment_ID"] != null)
                {
                    if (btnSave.Text == "Save")
                    {
                        int id = Convert.ToInt16(Request.QueryString["Client_Recruitment_ID"].ToString());
                        if (SetData(id))
                        {
                            string str = ji.Insert(jiInfo);
                            GlobalUI.MessageBox(str);
                        }
                    }
                    else if (btnSave.Text == "Update")
                    {
                        jiInfo = new Job_InterviewEntity();
                        int id = Convert.ToInt16(Request.QueryString["Client_Recruitment_ID"].ToString());

                        if (SetData(id))
                        {
                            jiInfo.ID = int.Parse(hfID.Value);
                            jiInfo.Client_Recruitment_ID = id;
                            string str = ji.Update(jiInfo);
                            GlobalUI.MessageBox(str);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool SetData(int ClientRecruitmentID)
        {
            try
            {
                jiInfo = new Job_InterviewEntity();
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd-MM-yyyy";
                dtfi.DateSeparator = "-";

                if (Request.Form["InterviewDate"].ToString() == "" || Request.Form["InterviewResultDate"].ToString() == "")
                {
                    if (Request.Form["InterviewDate"].ToString() == "") lblInterviewDate.Text = "*";
                    if (Request.Form["InterviewResultDate"].ToString() == "") lblInterviewResultDate.Text = "*";
                    return false;
                }
                else
                {
                    jiInfo.Client_Recruitment_ID = ClientRecruitmentID;

                    jiInfo.Interview = Convert.ToBoolean(ddlInterview.SelectedValue);

                    string InterviewDate = Request.Form["InterviewDate"].ToString();

                    DateTime objInterviewDate = Convert.ToDateTime(InterviewDate, dtfi);
                    string interviewdate = Convert.ToDateTime(objInterviewDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    jiInfo.Interview_Date = DateTime.ParseExact(interviewdate, "MM/dd/yyyy hh:MM:ss", null);
                    lblInterviewDate.Text = "";

                    jiInfo.Interview_Result = Convert.ToBoolean(ddlInterviewResult.SelectedValue);

                    string InterviewResultDate = Request.Form["InterviewResultDate"].ToString();
                    DateTime objInterviewResultDate = Convert.ToDateTime(InterviewResultDate, dtfi);
                    string todate = Convert.ToDateTime(objInterviewResultDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    jiInfo.Interview_Result_Date = DateTime.ParseExact(todate, "MM/dd/yyyy hh:MM:ss", null);
                    lblInterviewResultDate.Text = "";
                    jiInfo.Comment = txtComment.Text;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GetData(int ClientRecruitmentID)
        {
            try
            {
                ji = new Job_InterviewBL();
                jiInfo = new Job_InterviewEntity();

                jiInfo = ji.SelectByClientRecruitmentID(ClientRecruitmentID);
                if (jiInfo != null)
                {
                    hfID.Value = jiInfo.ID.ToString();
                    ddlInterview.SelectedValue = jiInfo.Interview.ToString();
                    ddlInterviewResult.SelectedValue = jiInfo.Interview_Result.ToString();
                    txtComment.Text = jiInfo.Comment.ToString();
                    this.InputValue1 = Convert.ToDateTime(jiInfo.Interview_Date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MM/yyyy");
                    this.InputValue2 = Convert.ToDateTime(jiInfo.Interview_Result_Date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MM/yyyy");
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}