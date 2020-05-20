using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT_Ver1.Employee
{
    public partial class Career_Job_Interview : System.Web.UI.Page
    {
        public int CareerId = 0;
        public int Rec_Id = 0;
        Client_RecruitmentBL crbl = new Client_RecruitmentBL();
        Career_Job_InterviewEntity cjie;
        protected string InputValue { get; set; }
        protected string InputValue2 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            txtInterviewDate.Text = Request.Form[txtInterviewDate.UniqueID];
            txtInterviewResultDate.Text = Request.Form[txtInterviewResultDate.UniqueID];
            // User Authorized 
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());

            bool resultRead = user.CanRead(userID, "029");
            if (resultRead)
            {
                btnSave.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
                btnDelete.Visible = true;
            }

            bool resultDelete = user.CanDelete(userID, "029");
            if (resultDelete)
                btnDelete.Visible = true;
            else
                btnDelete.Visible = false;

            bool resultEdit = user.CanSave(userID, "029");
            if (resultEdit)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;

            if (!String.IsNullOrWhiteSpace(txtValue.Text))
            {
                String[] str = (txtValue.Text.Split('$'));
                if (str.Length == 3)
                {
                    txtName.Text = str[0];
                    txtClientNo.Text = str[1];
                }
                txtValue.Text = String.Empty;
            }

            if (Request.QueryString["Career_ID"] != null)
            {
                CareerId = BaseLib.Convert_Int(Request.QueryString["Career_ID"]);
            }
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                }
                else ViewState["UrlReferrer"] = null;

                FillData();
                if (Request.QueryString["Client_RecruitmentID"] != null)
                {
                    Rec_Id = BaseLib.Convert_Int(Request.QueryString["Client_RecruitmentID"]);
                    btnSave.Text = "Update";    //更新する
                    hfMode.Value = "更新する";
                    lblUpdater.Visible = true;
                    lblUpdaterData.Visible = true;
                    lblUpdateTime.Visible = true;
                    lblUpdateTimeData.Visible = true;

                    Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                    dgvRecruitment.DataSource = crbl.SelectByID(Rec_Id);
                    dgvRecruitment.DataBind();
                    if (dgvRecruitment.Rows.Count > 0)
                    {
                        RadioButton rb = (dgvRecruitment.Rows[0].FindControl("rdoRecruitment")) as RadioButton;
                        rb.Checked = true;
                    }

                    DataTable dt = new DataTable();
                    Career_Job_InterviewBL cjibl = new Career_Job_InterviewBL();
                    dt = cjibl.SelectByID(Rec_Id, CareerId);
                    if (dt.Rows.Count > 0)
                    {
                        lblUpdaterData.Text = dt.Rows[0]["LogIn_ID"].ToString();
                        lblUpdateTimeData.Text = dt.Rows[0]["UpdatedDate"].ToString();

                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["ID"].ToString()))
                        {
                            lblID.Text = dt.Rows[0]["ID"].ToString();
                        }

                        if (dt.Rows[0]["Interview"].ToString().ToLower() == "true")
                            ddlInterview.SelectedValue = "1";
                        else if (dt.Rows[0]["Interview"].ToString().ToLower() == "false")
                            ddlInterview.SelectedValue = "2";

                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Interview_Date"].ToString()))
                        {
                            DateTime date = (DateTime)dt.Rows[0]["Interview_Date"];
                            txtInterviewDate.Text = Convert.ToDateTime(date.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
                        }

                        if (dt.Rows[0]["Interview_Result"].ToString().ToLower() == "true")
                            ddlInterviewResult.SelectedValue = "1";
                        else if (dt.Rows[0]["Interview_Result"].ToString().ToLower() == "false")
                            ddlInterviewResult.SelectedValue = "2";

                        if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Interview_Result_Date"].ToString()))
                        {
                            DateTime date = (DateTime)dt.Rows[0]["Interview_Result_Date"];
                            txtInterviewResultDate.Text = Convert.ToDateTime(date.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
                        }

                        txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                        ddlSalaryType.SelectedValue = dt.Rows[0]["Salary_TypeID"].ToString();
                        txtComment.Text = dt.Rows[0]["Comment"].ToString();
                    }
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnSave.Text = "Register";  //登録する
                    hfMode.Value = "登録する";
                    dgvRecruitment.DataSource = crbl.SelectAll();
                    dgvRecruitment.DataBind();
                }
            }
        }

        protected void FillData()
        {
            try
            {
                SalaryTypeBL sbl = new SalaryTypeBL();
                ddlSalaryType.DataSource = sbl.SelectAll();
                ddlSalaryType.DataTextField = "Description";
                ddlSalaryType.DataValueField = "ID";
                ddlSalaryType.DataBind();
                ddlSalaryType.Items.Insert(0, "");
                ddlSalaryType.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int Rec_ID = 0;
                for (int i = 0; i < dgvRecruitment.Rows.Count; i++)
                {
                    RadioButton rb = (dgvRecruitment.Rows[i].FindControl("rdoRecruitment")) as RadioButton;
                    if (rb.Checked == true)
                    {
                        Rec_ID = BaseLib.Convert_Int(dgvRecruitment.Rows[i].Cells[1].Text);
                        break;
                    }
                }
                if (Rec_ID == 0)
                {
                    GlobalUI.MessageBox("Select At least One Recruitment");
                }
                else
                {
                    cjie = new Career_Job_InterviewEntity();
                    cjie.Client_RecruitmentID = Rec_ID;
                    cjie.Career_ID = CareerId;
                    if (ddlInterview.SelectedValue == "1")
                        cjie.Interview = true;
                    else if (ddlInterview.SelectedValue == "2")
                        cjie.Interview = false;
                    else cjie.Interview = null;

                    if (!String.IsNullOrWhiteSpace(Request.Form[txtInterviewDate.UniqueID]))
                    {
                        string strDate = Request.Form[txtInterviewDate.UniqueID];
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "dd-MM-yyyy";
                        dtfi.DateSeparator = "-";
                        DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                        string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                        cjie.Interview_Date = DateTime.ParseExact(date, "MM/dd/yyyy hh:MM:ss", null);
                    }
                    if (ddlInterviewResult.SelectedValue == "1")
                        cjie.Interview_Result = true;
                    else if (ddlInterviewResult.SelectedValue == "2")
                        cjie.Interview_Result = false;
                    else cjie.Interview_Result = null;

                    if (!String.IsNullOrWhiteSpace(Request.Form[txtInterviewResultDate.UniqueID]))
                    {
                        string strDate = Request.Form[txtInterviewResultDate.UniqueID];
                        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                        dtfi.ShortDatePattern = "dd-MM-yyyy";
                        dtfi.DateSeparator = "-";
                        DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                        string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                        cjie.Interview_Result_Date = DateTime.ParseExact(date, "MM/dd/yyyy hh:MM:ss", null);
                    }

                    cjie.Salary = BaseLib.Convert_Decimal(txtSalary.Text);
                    cjie.Salary_Type = BaseLib.Convert_Int(ddlSalaryType.SelectedValue);
                    cjie.Comment = txtComment.Text;

                    Career_Job_InterviewBL cjibl = new Career_Job_InterviewBL();
                    if (hfMode.Value == "登録する")
                    {
                        if (cjibl.GetCount(cjie.Client_RecruitmentID, cjie.Career_ID) > 0)
                        {
                            GlobalUI.MessageBox("Data Already Exist");
                        }
                        else
                        {
                            CreatedDateTime();
                            UpdatedDateTime();
                            if (cjibl.Insert_Update(cjie, EnumBase.Save.Insert))
                            {
                                object referrer = ViewState["UrlReferrer"];
                                string url = (string)referrer;
                                string script = "window.onload = function(){ alert('";
                                script += "Saving Successfully";
                                script += "');";
                                script += "window.location = '";
                                script += url;
                                script += "'; }";
                                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                            }
                        }
                    }
                    else if (hfMode.Value == "更新する")
                    {
                        if (!String.IsNullOrWhiteSpace(lblID.Text))
                        {
                            cjie.Id = BaseLib.Convert_Int(lblID.Text);
                        }
                        UpdatedDateTime();
                        if (cjibl.Insert_Update(cjie, EnumBase.Save.Update))
                        {
                            object referrer = ViewState["UrlReferrer"];
                            string url = (string)referrer;
                            string script = "window.onload = function(){ alert('";
                            script += "Updating Successfully";
                            script += "');";
                            script += "window.location = '";
                            script += url;
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void dgvRecruitment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvRecruitment.PageIndex = e.NewPageIndex;
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                sr = FillForSearch();

                dgvRecruitment.DataSource = crbl.SearchData(sr);
                dgvRecruitment.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvRecruitment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[1].Visible = false;//recruitment id
                    e.Row.Cells[2].Visible = false;//client id
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvRecruitment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataDetail")
                {
                    Response.Redirect("Career_Job_InterviewDetail.aspx?Client_RecruitmentID=" + e.CommandArgument.ToString()
                                                       + "&Career_ID=" + Request.QueryString["Career_ID"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearchData_Click(object sender, EventArgs e)
        {
            try
            {
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
                sr = FillForSearch();
                dgvRecruitment.DataSource = crbl.SearchData(sr);
                dgvRecruitment.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CreatedDateTime()
        {
            try
            {
                cjie.CreatedBy = Convert.ToInt32(Session["UserID"]);
                cjie.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void UpdatedDateTime()
        {
            try
            {
                cjie.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                cjie.UpdatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected DateTime DeletedDateTime()
        {
            try
            {
                return Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            txtInterviewDate.Text = String.Empty;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            txtInterviewResultDate.Text = String.Empty;
        }

        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Length <= 400)
                e.IsValid = true;
            else
            {
                e.IsValid = false;
                return;
            }
        }

        protected Client_RecruitmentEntity.SearchRecruitment FillForSearch()
        {
            Client_RecruitmentEntity.SearchRecruitment sr = new Client_RecruitmentEntity.SearchRecruitment();
            sr.Name = txtName.Text;
            if (txtClientNo.Text == string.Empty)
                sr.ClientNo = null;
            else
                sr.ClientNo = txtClientNo.Text;

            if (txtRecruitmentNo.Text == string.Empty)
                sr.RecruitmentNo = null;
            else
                sr.RecruitmentNo = txtRecruitmentNo.Text;

            sr.PersonInCharge = string.Empty;
            sr.ContactPhoneNo = string.Empty;
            return sr;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Job_Career_InterviewBL jcibl = new Job_Career_InterviewBL();
            String result = jcibl.Delete(BaseLib.Convert_Int(lblID.Text));
            object referrer = ViewState["UrlReferrer"];
            string url = (string)referrer;
            string script = "window.onload = function(){ alert('";
            script += result;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
    }
}