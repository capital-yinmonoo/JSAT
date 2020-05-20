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

namespace JSAT_Ver1.Employer
{
    public partial class Client_Recruitment_Detail : System.Web.UI.Page
    {
        public static int client_ID = 0;
        public static int rec_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Client_ID"] != null)
                    client_ID = BaseLib.Convert_Int(Request.QueryString["Client_ID"]);

                if (Request.QueryString["Client_Recruitment_ID"] != null)
                    rec_ID = BaseLib.Convert_Int(Request.QueryString["Client_Recruitment_ID"]);

                Client_ProfileBL cpbl = new Client_ProfileBL();
                Client_ProfileEntity cpe = new Client_ProfileEntity();
                cpe = cpbl.SelectByID(client_ID);

                lblClientNo.Text = cpe.Client_Code.ToString();
                lblName.Text = cpe.Client_Name;
                lblPhoneNo.Text = cpe.Telephone_No; //+ ", " + cpe.Telephone_No1 + ", " + cpe.Telephone_No2;
                lblLocation.Text = cpe.Location;
                lblDutyPost.Text = cpe.NoofClubs.ToString();

                Industry_TypeBL itbl = new Industry_TypeBL();
                Industry_TypeEntity ite = new Industry_TypeEntity();
                ite = itbl.SelectByID(cpe.Industry_TypeID);

                lblMajorIndustry.Text = ite.Description;

                BusinessTypeBL btbl = new BusinessTypeBL();
                BusinessTypeEntity bte = new BusinessTypeEntity();
                bte = btbl.SelectByID(cpe.Business_TypeID);

                lblSmallIndustry.Text = bte.Description;
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                DataTable dt = new DataTable();
                dt = crbl.SelectByID(rec_ID);

                if (dt.Rows.Count > 0)
                {
                    //lblSalaryFormat.Text = dt.Rows[0]["Salary_Format"].ToString();
                    lbljobno.Text = dt.Rows[0]["ID"].ToString();
                    lblPersonInCharge.Text = dt.Rows[0]["ContactPerson"].ToString() + ", " + dt.Rows[0]["ContactPerson1"].ToString() + ", " + dt.Rows[0]["ContactPerson2"].ToString();
                    lblUpdater.Text = dt.Rows[0]["UpdateBy"].ToString();
                    lblUpdateTime.Text = dt.Rows[0]["UpdateDate"].ToString();
                    lblRecruitmentNo.Text = dt.Rows[0]["ID"].ToString();
                    lblPersonInChargePhoneNo.Text = dt.Rows[0]["Phone_No"].ToString();
                    lblPersonInChargeEmail.Text = dt.Rows[0]["Email"].ToString() + ", " + dt.Rows[0]["Email1"].ToString() + ", " + dt.Rows[0]["Email2"].ToString();
                    lblMajorOccupation.Text = dt.Rows[0]["DivitionOrDepartment"].ToString();
                    lblSmallOcupation.Text = dt.Rows[0]["Position"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["SubDate"].ToString()))
                    {

                        lblSubmissionDate.Text = GlobalUI.Format_Date(dt.Rows[0]["SubDate"].ToString());
                    }
                    lblPost.Text = dt.Rows[0]["Post"].ToString();
                    lblOtherPost.Text = dt.Rows[0]["Other_Post"].ToString();
                    lblGender.Text = dt.Rows[0]["Gender"].ToString();
                    String str = String.Empty;
                    String str1 = String.Empty;
                    String str2 = String.Empty;
                    string type = string.Empty;
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Salary_Format"].ToString()))
                    {
                        if (dt.Rows[0]["Salary_Format"].ToString() == "1")
                            type = "Up to";
                        else if (dt.Rows[0]["Salary_Format"].ToString() == "2")
                            type = "Nego";
                        else if (dt.Rows[0]["Salary_Format"].ToString() == "3")
                            type = "Max";
                        else if (dt.Rows[0]["Salary_Format"].ToString() == "4")
                            type = "Min";
                    }
                    if(!string.IsNullOrWhiteSpace(type))
                        lblSalary.Text = GlobalUI.Format_Salary(int.Parse(dt.Rows[0]["Salary_From"].ToString())) + " ～ " + GlobalUI.Format_Salary(int.Parse(dt.Rows[0]["Salary_To"].ToString())) + dt.Rows[0]["Salary"].ToString() + " - " + type;
                    else
                        lblSalary.Text = GlobalUI.Format_Salary(int.Parse(dt.Rows[0]["Salary_From"].ToString())) + " ～ " + GlobalUI.Format_Salary(int.Parse(dt.Rows[0]["Salary_To"].ToString())) + dt.Rows[0]["Salary"].ToString();
                    lblOtherSalary.Text = GlobalUI.Format_Salary(int.Parse(dt.Rows[0]["Other_Salary"].ToString()));
                    lblWorkableArea.Text = dt.Rows[0]["Working_Place"].ToString();
                    lblOtherWorkableArea.Text = dt.Rows[0]["Other_WorkingPlace"].ToString();
                    lblDayService.Text = dt.Rows[0]["Day_Service"].ToString();
                    lblStartTime.Text = dt.Rows[0]["Start_time"].ToString();
                    lblCloseTime.Text = dt.Rows[0]["Closing_time"].ToString();
                    lblLanguage.Text = dt.Rows[0]["Languages"].ToString();

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Japanese_RW_LevelID"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["Japanese_Speaking_LevelID"].ToString()))
                    {
                        str = dt.Rows[0]["Japanese_RW_LevelID"].ToString();
                        lbljapanlanguagelisten.Text = str;
                        str = dt.Rows[0]["Japanese_Speaking_LevelID"].ToString();
                        lbljapanlanguagespeak.Text = str;
                    }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["English_RW_LevelID"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["English_Speaking_LevelID"].ToString()))
                    {
                        str = dt.Rows[0]["English_RW_LevelID"].ToString();
                        lblEnglishlanguagelisten.Text = str;
                        str = dt.Rows[0]["English_Speaking_LevelID"].ToString();
                        lblEnglishlanguagespeak.Text = str;
                    }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Myanmar_RW_LevelID"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["Myanmar_Speaking_LevelID"].ToString()))
                    {
                        str = dt.Rows[0]["Myanmar_RW_LevelID"].ToString();
                        lblMyanmarlanguagelisten.Text = str;
                        str = dt.Rows[0]["Myanmar_Speaking_LevelID"].ToString();
                        lblMyanmarlanguagespeak.Text = str;
                    }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["To_Japanese_RW_LevelID"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["Japanese_Speaking_LevelID"].ToString()))
                    {
                        str = dt.Rows[0]["To_Japanese_RW_LevelID"].ToString();
                        lbljapanlanguagelistenTo.Text = str;
                        str = dt.Rows[0]["To_Japanese_Speaking_LevelID"].ToString();
                        lbljapanlanguagespeakTo.Text = str;
                    }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["To_English_RW_LevelID"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["English_Speaking_LevelID"].ToString()))
                    {
                        str = dt.Rows[0]["To_English_RW_LevelID"].ToString();
                        lblEnglishlanguageto.Text = str;
                        str = dt.Rows[0]["To_English_Speaking_LevelID"].ToString();
                        lblEnglishlanguagespeakto.Text = str;
                    }

                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["To_Myanmar_RW_LevelID"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["Myanmar_Speaking_LevelID"].ToString()))
                    {
                        str = dt.Rows[0]["To_Myanmar_RW_LevelID"].ToString();
                        lblMyanmarlanguageto.Text = str;
                        str = dt.Rows[0]["To_Myanmar_Speaking_LevelID"].ToString();
                        lblMyanmarlanguagespeakto.Text = str;
                    }

                    if (dt.Rows[0]["Age_From"].ToString() != "0")
                        str1 = dt.Rows[0]["Age_From"].ToString();
                    else
                        str1 = "--";
                    if (dt.Rows[0]["Age_To"].ToString() != "0")
                        str2 = dt.Rows[0]["Age_To"].ToString();
                    else
                        str2 = "--";
                    str = str1 + " 歳 ～ " + str2+ " 歳";
                    lblAge.Text = str;

                    lblRemark.Text = dt.Rows[0]["Remarks"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Entering_Date"].ToString()))
                    {
                        lblEnterDate.Text = GlobalUI.Format_Date(dt.Rows[0]["Entering_Date"].ToString());
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Interview_Date"].ToString()))
                    {
                        lblInterviewDate.Text = GlobalUI.Format_Date(dt.Rows[0]["Interview_Date"].ToString());
                    }
                    if (dt.Rows[0]["Wanted"].ToString().ToLower() == "true")
                        lblASAP1.Text = "○";
                    if (dt.Rows[0]["ASAP1"].ToString().ToLower() == "true")
                        //chkWanted.Checked = true;
                        lblASAP2.Text = "○";
                    if (dt.Rows[0]["ASAP2"].ToString().ToLower() == "true")
                        lblWanted.Text = "○";
                }

                Session["dtClientRecruitment"] = dt;
                Client_Recruitment_DetailBL crdbl = new Client_Recruitment_DetailBL();
                dgvCareerInterview.DataSource = crdbl.SelectByRecruitmentID(rec_ID);
                dgvCareerInterview.DataBind();
            }

        }
        protected void dgvCareerInterview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int career_id = BaseLib.Convert_Int(e.CommandArgument.ToString());
                if (e.CommandName == "DataDelete")
                {
                    Client_Recruitment_DetailBL crdbl = new Client_Recruitment_DetailBL();
                    if (crdbl.Delete(rec_ID, career_id))
                    {
                        dgvCareerInterview.DataSource = null;
                        dgvCareerInterview.DataSource = crdbl.SelectByRecruitmentID(rec_ID);
                        dgvCareerInterview.DataBind();
                    }
                }

                else if (e.CommandName == "DataDetail")
                {
                    Response.Redirect("~/Employee/Career_Job_InterviewDetail.aspx?Client_RecruitmentID=" + rec_ID + "&Career_ID=" + career_id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRecruitment_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employer/Client_Recruitment.aspx?Client_ID=" + client_ID + "&Client_Recruitment_ID=" + rec_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnJobCareerInterview_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employer/Job_Career_Interview.aspx?Client_RecruitmentID=" + rec_ID + "&Client_ID=" + client_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvCareerInterview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //hide Delete Button
                UserRoleBL user = new UserRoleBL();
                int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    bool resultDelete = user.CanDelete(userID, "017");
                    if (resultDelete)
                    {

                    }
                    else
                    {
                        Button btn = e.Row.FindControl("btnEdit") as Button;
                        btn.Visible = false;
                    }

                    if (DataBinder.Eval(e.Row.DataItem, "Interview").ToString().ToLower() == "false")
                    {
                        e.Row.Cells[4].Text = String.Empty;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "Interview").ToString().ToLower() == "true")
                    {
                        e.Row.Cells[4].Text = "○";
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "Interview_Result").ToString().ToLower() == "false")
                    {
                        e.Row.Cells[6].Text = String.Empty;
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "Interview_Result").ToString().ToLower() == "true")
                    {
                        e.Row.Cells[6].Text = "○";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnMatching_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/Career_Resume_View.aspx?ClientRecuriment=" + rec_ID);
        }
    }
}