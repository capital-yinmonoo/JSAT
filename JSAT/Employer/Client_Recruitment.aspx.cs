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

namespace JSAT_Ver1.Employer
{
    public partial class Client_Recruitment : System.Web.UI.Page
    {
        public int Client_ID = 0;
        public int Rec_ID = 0;
        protected string InputValue { get; set; }
        Client_RecruitmentEntity cre;
             protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = false;
            txtSubDate.Text = Request.Form[txtSubDate.UniqueID];
            //User Authorize
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());

            bool resultRead = user.CanRead(userID, "018");
            if (resultRead)
            {
                btnSave_Update.Visible = false;
                btnDelete.Visible = false;
            }

            bool resultEdit = user.CanSave(userID, "018");
            if (resultEdit)
                btnSave_Update.Visible = true;
            else
                btnSave_Update.Visible = false;

            bool resultDelete = user.CanDelete(userID, "018");
            if (resultDelete)
                btnDelete.Visible = true;
            else
                btnDelete.Visible = false;

            if (Request.QueryString["Client_ID"] != null)
            {
                ClientControlLink1.ClientID = Request.QueryString["Client_ID"];
                Client_ID = BaseLib.Convert_Int(Request.QueryString["Client_ID"]);
            }
            if (Request.QueryString["Client_Recruitment_ID"] != null)
            {
                Rec_ID = BaseLib.Convert_Int(Request.QueryString["Client_Recruitment_ID"]);
                lblTitle.Text = "人材紹介申込編集(Recruitment Application Edit)";
                lblRecruitment.Visible = true;
                lblRecruitmentNo.Visible = true;
                lblRecruitmentNo.Text = Request.QueryString["Client_Recruitment_ID"].ToString();
            }
            else
            {
                lblTitle.Text = "人材紹介申込登録(Recruitment Application Registration)";
            }
            BindDate();
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                    //previouspage = Request.UrlReferrer.ToString();
                }
                else ViewState["UrlReferrer"] = null;

                ClientControlLink1.ClientProfileLink = true;
                ClientControlLink1.RecruitmentLink = true;
                ClientControlLink1.CVHistoryLink = true;
                FillData();
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                DataTable dt = crbl.SelectByID(Rec_ID);

                if (dt.Rows.Count > 0)
                {
                    btnSave_Update.Text = "Update"; //更新する
                    hfMode.Value = "Update";    //更新する
                                        FillForEdit(dt);
                }
                else
                {
                    btnSave_Update.Text = "Register";   //登録する
                    hfMode.Value = "Register";  //登録する
                    Client_ProfileBL cpbl1 = new Client_ProfileBL();
                    Client_ProfileEntity cpe = new Client_ProfileEntity();
                    crbl = new Client_RecruitmentBL();
                   
                    int id = BaseLib.Convert_Int(Request.QueryString["Client_ID"]);
                    cpe = cpbl1.SelectByID(BaseLib.Convert_Int(Request.QueryString["Client_ID"]));
                    ShowGrid(id);
                }
            }
        }

        protected void dgvClientRecruitment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;//recruitment id
            e.Row.Cells[3].Visible = false;//clientid

            for (int i = 1; i < e.Row.Cells.Count; i++)
                e.Row.Cells[i].Wrap = false;
        }

        protected void dgvClientRecruitment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DataEdit")
            {
                FillData();
                btnSave_Update.Text = "Update";   //更新する
                hfMode.Value = "Update";  //更新する
                Rec_ID = Convert.ToInt32(e.CommandArgument.ToString());
                Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                DataTable dt = crbl.SelectByID(Rec_ID);
                if (dt.Rows.Count > 0)
                {
                    FillForEdit(dt);
                }
            }
            else if (e.CommandName == "DataDelete")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue.Equals("Yes"))
                {
                    Rec_ID = Convert.ToInt32(e.CommandArgument.ToString());
                    Client_RecruitmentBL crbl = new Client_RecruitmentBL();
                    crbl.Delete(Rec_ID, Convert.ToInt32(Session["ID"]), DeletedDateTime());
                    btnSave_Update.Text = "Register";   //登録する
                    hfMode.Value = "Register";  //登録する
                    ShowGrid(Client_ID);
                }
            }
        }

        protected void btnSave_Update_Click(object sender, EventArgs e)
        {
            if (txtRemarks.Text.Length <= 400 && String.Equals(txtEmail.Text, txtEmailConfirm.Text) && (BaseLib.Convert_Int(txtSalaryFrom.Text) <= BaseLib.Convert_Int(txtSalaryTo.Text)))
            {
                cre = new Client_RecruitmentEntity();

                if (Request.QueryString["ID"] != null)
                    cre.Id = JSAT_Common.BaseLib.Convert_Int(Request.QueryString["ID"]);

                cre.ClientId = Client_ID;

                if (!String.IsNullOrWhiteSpace(Request.Form[txtSubDate.UniqueID]))
                {
                    string strDate = Request.Form[txtSubDate.UniqueID];
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd-MM-yyyy";
                    dtfi.DateSeparator = "-";
                    DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                    string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    cre.SubDate = DateTime.ParseExact(date, "MM/dd/yyyy hh:MM:ss", null);
                }
                if (!String.IsNullOrWhiteSpace(txtjobno.Text))
                {
                    cre.Jobno = Convert.ToInt32(txtjobno.Text);
                }
                cre.MajorIndustryId = BaseLib.Convert_Int(ddlMajorIndustry.SelectedValue);
                cre.SmallIndustryId = BaseLib.Convert_Int(ddlSmallIndustry.SelectedValue);
                cre.OtherIndustry = txtOtherIndustry.Text;
                cre.PostId = BaseLib.Convert_Int(ddlPost.SelectedValue);
                cre.OtherPost = txtOtherPost.Text;
                cre.GenderId = BaseLib.Convert_Int(ddlGender.SelectedValue);
                if (!String.IsNullOrWhiteSpace(txtSalaryFrom.Text))
                    cre.SalaryFrom = int.Parse(txtSalaryFrom.Text);

                if (!String.IsNullOrWhiteSpace(txtSalaryTo.Text))
                    cre.SalaryTo = int.Parse(txtSalaryTo.Text);

                if (txtOtherSalary.Text.Trim().Length > 0)
                {
                    if (int.Parse(txtOtherSalary.Text) > 0)
                        cre.OtherSalary = int.Parse(txtOtherSalary.Text);
                }
                else cre.OtherSalary = 0;

                cre.SalaryTypeId = BaseLib.Convert_Int(ddlSalaryType.SelectedValue);
                cre.Salary_Format = BaseLib.Convert_Int(ddlSalaryFormat.SelectedValue);
                cre.WorkingPlaceId = BaseLib.Convert_Int(ddlWorkingPlace.SelectedValue);
                cre.OtherWorkingPlace = txtOtherWorkingPlace.Text;
                cre.DayServiceId = BaseLib.Convert_Int(ddlDayService.SelectedValue);
                cre.Starting = ddlStartHours.Text;
                cre.Closing = ddlCloseHours.Text;
                cre.LanguageId = BaseLib.Convert_Int(ddlLanguage.SelectedValue);
                cre.EnglishRWId = BaseLib.Convert_Int(ddlLanguageLevel1.SelectedValue);
                cre.EnglishSpeakID = BaseLib.Convert_Int(ddlLanguageLevel2.SelectedValue);
                cre.JapanRWId = BaseLib.Convert_Int(ddlJapaneselisting.SelectedValue);
                cre.JapanSpeakID = BaseLib.Convert_Int(ddlJapansepeaking.SelectedValue);
                cre.MyanmarRWId = BaseLib.Convert_Int(ddlmyanmarlistening.SelectedValue);
                cre.MyanmarSpeakID = BaseLib.Convert_Int(ddlmyanmarspeaking.SelectedValue);
                cre.ToEnglishRWID = BaseLib.Convert_Int(ddlenglishlistiningto.SelectedValue);
                cre.ToEnglishspeakID = BaseLib.Convert_Int(ddlenglishspeakingto.SelectedValue);
                cre.ToJapanRWID = BaseLib.Convert_Int(ddlJapaneselistingto.SelectedValue);
                cre.ToJapanspeakID = BaseLib.Convert_Int(ddlJapansepeakingto.SelectedValue);
                cre.ToMyanmarRWID = BaseLib.Convert_Int(ddlmyanmarlisteningto.SelectedValue);
                cre.ToMyanmarspeakID = BaseLib.Convert_Int(ddlmyanmarspeakingto.SelectedValue);
                if (ddlAgeFrom.Text.Trim() != "--")
                    cre.AgeFrom = BaseLib.Convert_Int(ddlAgeFrom.Text);
                else
                    cre.AgeFrom = 0;
                if (ddlAgeTo.Text.Trim() != "--")
                    cre.AgeTo = BaseLib.Convert_Int(ddlAgeTo.Text);
                else
                    cre.AgeTo = 0;
                cre.PersonInChargeId = BaseLib.Convert_Int(ddlPersonInCharge.SelectedValue);
                cre.PersonInCharge = txtPersonInCharge.Text;
                cre.PersonInChargeId1 = BaseLib.Convert_Int(ddlPersonInCharge1.SelectedValue);
                cre.PersonInCharge1 = txtPersonInCharge1.Text;
                cre.PersonInChargeId2 = BaseLib.Convert_Int(ddlPersonInCharge2.SelectedValue);
                cre.PersonInCharge2 = txtPersonInCharge2.Text;
                cre.Department = txtUnit.Text;
                cre.TelePhoneNo = txtPhoneNo.Text;
                cre.TelePhoneNo1 = txtPhoneNo1.Text;
                cre.TelePhoneNo2 = txtPhoneNo2.Text;
                cre.Email = txtEmail.Text;
                cre.Email1 = txtEmail1.Text;
                cre.Email2 = txtEmail2.Text;
                cre.EmailConfirm = txtEmailConfirm.Text;
                cre.EmailConfirm1 = txtEmailConfirm1.Text;
                cre.EmailConfirm2 = txtEmailConfirm2.Text;
                cre.Remark = txtRemarks.Text;
                if (chkWanted.Checked == true)
                    cre.Wanted = true;
                if (chkASAP1.Checked == true)
                    cre.ASAP1 = true;
                if (chkASAP2.Checked == true)
                    cre.ASAP2 = true;
                if (!String.IsNullOrWhiteSpace(Request.Form[txtEnterDate.UniqueID]))
                {
                    string strDate = Request.Form[txtEnterDate.UniqueID];
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd-MM-yyyy";
                    dtfi.DateSeparator = "-";
                    DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                    string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    cre.EnterDate = DateTime.ParseExact(date, "MM/dd/yyyy hh:MM:ss", null);
                }

                if (!String.IsNullOrWhiteSpace(Request.Form[txtInterviewDay.UniqueID]))
                {
                    string strDate = Request.Form[txtInterviewDay.UniqueID];
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "dd-MM-yyyy";
                    dtfi.DateSeparator = "-";
                    DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                    string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                    cre.InterviewDate = DateTime.ParseExact(date, "MM/dd/yyyy hh:MM:ss", null);
                }

                Client_RecruitmentBL crbl = new Client_RecruitmentBL();

                if (hfMode.Value == "Update")   //更新する
                {
                    UpdatedDateTime();
                    cre.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                    cre.Id = Rec_ID;
                    DataTable dtbcheck = new DataTable();
                    dtbcheck = crbl.Checkupdate(cre.Jobno);
                    if (crbl.Insert_Update(cre, EnumBase.Save.Update))
                    {
                        string url = "Client_Recruitment_Detail.aspx?Client_Recruitment_ID=" + cre.Jobno;
                        string script = "window.onload = function(){ alert('";
                        script += "Update Successfully";
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);



                        Client_ID = BaseLib.Convert_Int(Request.QueryString["Client_ID"]);
                        ShowGrid(Client_ID);
                    }
                }
                else
                {
                    CreatedDateTime();
                    UpdatedDateTime();
                    cre.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    cre.UpdatedBy = Convert.ToInt32(Session["UserID"]);

                    DataTable dtbcheck = new DataTable();
                    dtbcheck = crbl.Checkupdate(cre.Jobno);
                    if (dtbcheck.Rows.Count > 0)
                    {
                        string script = "window.onload = function(){ alert('";
                        script += "Job No Already Exist";
                        script += "');";
                        script += "window.location = '";
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                    else
                    {
                        if (crbl.Insert_Update(cre, EnumBase.Save.Insert))
                        {
                            object referrer = ViewState["UrlReferrer"];
                            string url = (string)referrer;
                            string script = "window.onload = function(){ alert('";
                            script += "Saving Successfully!";
                            script += "');";
                            script += "window.location = '";
                            script += url;
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                            int id = BaseLib.Convert_Int(Request.QueryString["Client_ID"]);
                            ShowGrid(id);
                            clearData();
                        }
                    }
                }
            }
        }

        public void BindDate()
        {
            if(!String.IsNullOrWhiteSpace(txtSubDate.Text))
            {
                string subdate = txtSubDate.Text;
                string date2 = Convert.ToDateTime(subdate, CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
                txtSubDate.Text = date2;
            }
            if (!String.IsNullOrWhiteSpace(txtEnterDate.Text))
            {
                string enterdate = txtEnterDate.Text;
                string date2 = Convert.ToDateTime(enterdate, CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
                txtEnterDate.Text = date2;
            }
            if (!String.IsNullOrWhiteSpace(txtInterviewDay.Text))
            {
                string interviewdate = txtInterviewDay.Text;
                string date2 = Convert.ToDateTime(interviewdate, CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
                txtInterviewDay.Text = date2;
            }
        }


        protected void ddlMajorIndustry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = BaseLib.Convert_Int(ddlMajorIndustry.SelectedValue);

            DataTable dt = new DataTable();
            PositionBL pbl = new PositionBL();
            dt = pbl.SelectByDepartmentID(index);
            ddlSmallIndustry.DataSource = dt;
            ddlSmallIndustry.DataTextField = "Description";
            ddlSmallIndustry.DataValueField = "ID";
            ddlSmallIndustry.DataBind();
            UPanelMajorIndustry.Update();
        }

        protected void FillForEdit(DataTable dt)
        {
            lblUpdater.Visible = true;
            lblUpdaterData.Visible = true;
            lblUpdateTime.Visible = true;
            lblUpdateTimeData.Visible = true;

            lblUpdaterData.Text = dt.Rows[0]["UpdateBy"].ToString();
            lblUpdateTimeData.Text = dt.Rows[0]["UpdateDate"].ToString();

            txtjobno.Text = dt.Rows[0]["ID"].ToString();
            txtjobno.Enabled = false;

            if (ddlMajorIndustry.Items.FindByText(dt.Rows[0]["DivitionOrDepartment"].ToString()) != null)
            {
                ddlMajorIndustry.ClearSelection();
                ddlMajorIndustry.Items.FindByText(dt.Rows[0]["DivitionOrDepartment"].ToString()).Selected = true;

                PositionBL pb = new PositionBL();
                ddlSmallIndustry.DataSource = pb.SelectByDepartmentID(BaseLib.Convert_Int(ddlMajorIndustry.SelectedValue));
                ddlSmallIndustry.DataTextField = "Description";
                ddlSmallIndustry.DataValueField = "ID";
                ddlSmallIndustry.DataBind();
                ddlSmallIndustry.ClearSelection();
            }
            if (ddlSmallIndustry.Items.FindByText(dt.Rows[0]["Position"].ToString()) != null)
            {
                ddlSmallIndustry.ClearSelection();
                ddlSmallIndustry.Items.FindByText(dt.Rows[0]["Position"].ToString()).Selected = true;
            }

            txtOtherIndustry.Text = dt.Rows[0]["Other_Position"].ToString();

            if (ddlPost.Items.FindByText(dt.Rows[0]["Post"].ToString()) != null)
            {
                ddlPost.ClearSelection();
                ddlPost.Items.FindByText(dt.Rows[0]["Post"].ToString()).Selected = true;
            }

            txtOtherPost.Text = dt.Rows[0]["Other_Post"].ToString();

            if (ddlGender.Items.FindByText(dt.Rows[0]["Gender"].ToString()) != null)
            {
                ddlGender.ClearSelection();
                ddlGender.Items.FindByText(dt.Rows[0]["Gender"].ToString()).Selected = true;
            }
            if (ddlSalaryType.Items.FindByText(dt.Rows[0]["Salary"].ToString()) != null)
            {
                ddlSalaryType.ClearSelection();
                ddlSalaryType.Items.FindByText(dt.Rows[0]["Salary"].ToString()).Selected = true;
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Salary_Format"].ToString()))
                    ddlSalaryFormat.Items.FindByValue(dt.Rows[0]["Salary_Format"].ToString()).Selected = true;
                else
                    ddlSalaryFormat.Items.FindByValue("0").Selected = true;
            }

            txtSalaryFrom.Text = dt.Rows[0]["Salary_From"].ToString();
            txtSalaryTo.Text = dt.Rows[0]["Salary_To"].ToString();
            txtOtherSalary.Text = dt.Rows[0]["Other_Salary"].ToString();

            if (ddlWorkingPlace.Items.FindByText(dt.Rows[0]["Working_Place"].ToString()) != null)
            {
                ddlWorkingPlace.ClearSelection();
                ddlWorkingPlace.Items.FindByText(dt.Rows[0]["Working_Place"].ToString()).Selected = true;
            }
            txtOtherWorkingPlace.Text = dt.Rows[0]["Other_WorkingPlace"].ToString();
            if (ddlDayService.Items.FindByText(dt.Rows[0]["Day_Service"].ToString()) != null)
            {
                ddlDayService.ClearSelection();
                ddlDayService.Items.FindByText(dt.Rows[0]["Day_Service"].ToString()).Selected = true;
            }

            if (ddlStartHours.Items.FindByText(dt.Rows[0]["Start_time"].ToString()) != null)
            {
                ddlStartHours.Items.FindByText(dt.Rows[0]["Start_time"].ToString()).Selected = true;
            }

            if (ddlCloseHours.Items.FindByText(dt.Rows[0]["Closing_time"].ToString()) != null)
            {
                ddlCloseHours.Items.FindByText(dt.Rows[0]["Closing_time"].ToString()).Selected = true;
            }

            if (ddlLanguageLevel1.Items.FindByText(dt.Rows[0]["English_RW_LevelID"].ToString()) != null)
            {
                ddlLanguageLevel1.ClearSelection();
                ddlLanguageLevel1.Items.FindByText(dt.Rows[0]["English_RW_LevelID"].ToString()).Selected = true;
            }

            if (ddlLanguageLevel2.Items.FindByText(dt.Rows[0]["English_Speaking_LevelID"].ToString()) != null)
            {
                ddlLanguageLevel2.ClearSelection();
                ddlLanguageLevel2.Items.FindByText(dt.Rows[0]["English_Speaking_LevelID"].ToString()).Selected = true;
            }
            if (ddlJapaneselisting.Items.FindByText(dt.Rows[0]["Japanese_RW_LevelID"].ToString()) != null)
            {
                ddlJapaneselisting.ClearSelection();
                ddlJapaneselisting.Items.FindByText(dt.Rows[0]["Japanese_RW_LevelID"].ToString()).Selected = true;
            }
            if (ddlJapansepeaking.Items.FindByText(dt.Rows[0]["Japanese_Speaking_LevelID"].ToString()) != null)
            {
                ddlJapansepeaking.ClearSelection();
                ddlJapansepeaking.Items.FindByText(dt.Rows[0]["Japanese_Speaking_LevelID"].ToString()).Selected = true;
            }
            if (ddlmyanmarlistening.Items.FindByText(dt.Rows[0]["Myanmar_RW_LevelID"].ToString()) != null)
            {
                ddlmyanmarlistening.ClearSelection();
                ddlmyanmarlistening.Items.FindByText(dt.Rows[0]["Myanmar_RW_LevelID"].ToString()).Selected = true;
            }
            if (ddlmyanmarspeaking.Items.FindByText(dt.Rows[0]["Myanmar_Speaking_LevelID"].ToString()) != null)
            {
                ddlmyanmarspeaking.ClearSelection();
                ddlmyanmarspeaking.Items.FindByText(dt.Rows[0]["Myanmar_Speaking_LevelID"].ToString()).Selected = true;
            }


            if (ddlJapaneselistingto.Items.FindByText(dt.Rows[0]["To_Japanese_RW_LevelID"].ToString()) != null)
            {
                ddlJapaneselistingto.ClearSelection();
                ddlJapaneselistingto.Items.FindByText(dt.Rows[0]["To_Japanese_RW_LevelID"].ToString()).Selected = true;
            }
            if (ddlJapansepeakingto.Items.FindByText(dt.Rows[0]["To_Japanese_Speaking_LevelID"].ToString()) != null)
            {
                ddlJapansepeakingto.ClearSelection();
                ddlJapansepeakingto.Items.FindByText(dt.Rows[0]["To_Japanese_Speaking_LevelID"].ToString()).Selected = true;
            }

            if (ddlenglishlistiningto.Items.FindByText(dt.Rows[0]["To_English_RW_LevelID"].ToString()) != null)
            {
                ddlenglishlistiningto.ClearSelection();
                ddlenglishlistiningto.Items.FindByText(dt.Rows[0]["To_English_RW_LevelID"].ToString()).Selected = true;
            }
            if (ddlenglishspeakingto.Items.FindByText(dt.Rows[0]["To_English_Speaking_LevelID"].ToString()) != null)
            {
                ddlenglishspeakingto.ClearSelection();
                ddlenglishspeakingto.Items.FindByText(dt.Rows[0]["To_English_Speaking_LevelID"].ToString()).Selected = true;
            }

            if (ddlmyanmarlisteningto.Items.FindByText(dt.Rows[0]["To_Myanmar_RW_LevelID"].ToString()) != null)
            {
                ddlmyanmarlisteningto.ClearSelection();
                ddlmyanmarlisteningto.Items.FindByText(dt.Rows[0]["To_Myanmar_RW_LevelID"].ToString()).Selected = true;
            }
            if (ddlmyanmarspeakingto.Items.FindByText(dt.Rows[0]["To_Myanmar_Speaking_LevelID"].ToString()) != null)
            {
                ddlmyanmarspeakingto.ClearSelection();
                ddlmyanmarspeakingto.Items.FindByText(dt.Rows[0]["To_Myanmar_Speaking_LevelID"].ToString()).Selected = true;
            }

            if (ddlLanguage.Items.FindByText(dt.Rows[0]["Languages"].ToString()) != null)
            {
                ddlLanguage.ClearSelection();
                ddlLanguage.Items.FindByText(dt.Rows[0]["Languages"].ToString()).Selected = true;
            }

            if (ddlAgeFrom.Items.FindByText(dt.Rows[0]["Age_From"].ToString()) != null)
            {
                ddlAgeFrom.ClearSelection();
                ddlAgeFrom.Items.FindByText(dt.Rows[0]["Age_From"].ToString()).Selected = true;
            }

            if (ddlAgeTo.Items.FindByText(dt.Rows[0]["Age_To"].ToString()) != null)
            {
                ddlAgeTo.ClearSelection();
                ddlAgeTo.Items.FindByText(dt.Rows[0]["Age_To"].ToString()).Selected = true;
            }

            if (!dt.Rows[0]["PType"].ToString().Equals("0"))
            {
                ddlPersonInCharge.ClearSelection();
                ddlPersonInCharge.SelectedValue = dt.Rows[0]["PType"].ToString();
            }
            if (!dt.Rows[0]["PType1"].ToString().Equals("0"))
            {
                ddlPersonInCharge1.ClearSelection();
                ddlPersonInCharge1.SelectedValue = dt.Rows[0]["PType"].ToString();
            }
            if (!dt.Rows[0]["PType2"].ToString().Equals("0"))
            {
                ddlPersonInCharge2.ClearSelection();
                ddlPersonInCharge2.SelectedValue = dt.Rows[0]["PType"].ToString();
            }

            if (!String.IsNullOrWhiteSpace(dt.Rows[0]["SubDate"].ToString()))
            {
                DateTime d = (DateTime)dt.Rows[0]["SubDate"];
                txtSubDate.Text = Convert.ToDateTime(d.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
            }
            if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Entering_Date"].ToString()))
            {
                DateTime d = (DateTime)dt.Rows[0]["Entering_Date"];
                txtEnterDate.Text = Convert.ToDateTime(d.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
            }
            if (!String.IsNullOrWhiteSpace(dt.Rows[0]["Interview_Date"].ToString()))
            {
                DateTime d = (DateTime)dt.Rows[0]["Interview_Date"];
                txtInterviewDay.Text = Convert.ToDateTime(d.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MMM/yyyy");
            }
            txtPersonInCharge.Text = dt.Rows[0]["Person_Name"].ToString();
            txtPersonInCharge1.Text = dt.Rows[0]["Person_Name1"].ToString();
            txtPersonInCharge2.Text = dt.Rows[0]["Person_Name2"].ToString();
            txtUnit.Text = dt.Rows[0]["Department"].ToString();
            txtPhoneNo.Text = dt.Rows[0]["Phone_No"].ToString();
            txtPhoneNo1.Text = dt.Rows[0]["Phone_No1"].ToString();
            txtPhoneNo2.Text = dt.Rows[0]["Phone_No2"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtEmail1.Text = dt.Rows[0]["Email1"].ToString();
            txtEmail2.Text = dt.Rows[0]["Email2"].ToString();
            txtEmailConfirm.Text = dt.Rows[0]["Email_Confirm"].ToString();
            txtEmailConfirm1.Text = dt.Rows[0]["Email_Confirm1"].ToString();
            txtEmailConfirm2.Text = dt.Rows[0]["Email_Confirm2"].ToString();
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
            if (dt.Rows[0]["Wanted"].ToString().ToLower() == "true")
                chkWanted.Checked = true;
            if (dt.Rows[0]["ASAP1"].ToString().ToLower() == "true")
                chkASAP1.Checked = true;
            if (dt.Rows[0]["ASAP2"].ToString().ToLower() == "true")
                chkASAP2.Checked = true;
            Client_ID = BaseLib.Convert_Int(dt.Rows[0]["Client_ID"].ToString());
            ShowGrid(Client_ID);
        }

        protected void ShowGrid(int id)
        {
            Client_RecruitmentBL crbl = new Client_RecruitmentBL();
            dgvClientRecruitment.DataSource = null;
            dgvClientRecruitment.DataSource = crbl.SelectByProfileID(id);
            dgvClientRecruitment.DataBind();
        }

        protected void FillData()
        {
            Client_ProfileBL cpbl = new Client_ProfileBL();
            Client_ProfileEntity cpe = new Client_ProfileEntity();

            cpe = cpbl.SelectByID(Client_ID);

            lblClientNo.Text = cpe.Client_Code.ToString();
            lblName.Text = cpe.Client_Name;
            lblPhoneNo.Text = cpe.Telephone_No;
            lblLocation.Text = cpe.Location;

            BusinessTypeBL btbl = new BusinessTypeBL();
            BusinessTypeEntity bte = new BusinessTypeEntity();
            bte = btbl.SelectByID(cpe.Business_TypeID);
            lblMajorSmall.Text = bte.Description;

            Industry_TypeBL itbl = new Industry_TypeBL();
            Industry_TypeEntity ite = new Industry_TypeEntity();
            ite = itbl.SelectByID(cpe.Industry_TypeID);
            lblMajorDivision.Text = ite.Description;

            DepartmentBL dbl = new DepartmentBL();
            ddlMajorIndustry.DataSource = dbl.SelectAll(1);
            ddlMajorIndustry.DataTextField = "Description";
            ddlMajorIndustry.DataValueField = "ID";
            ddlMajorIndustry.DataBind();
            ddlMajorIndustry.ClearSelection();
            ddlMajorIndustry.Items.Insert(0, "");
            ddlMajorIndustry.Text = "";

            GlobalBL gb = new GlobalBL();
            ddlPost.DataSource = gb.Get_Data("Post");
            ddlPost.DataTextField = "Description";
            ddlPost.DataValueField = "ID";
            ddlPost.DataBind();
            ddlPost.ClearSelection();
            ddlPost.Items.Insert(0, "");
            ddlPost.Text = "";

            GenderBL gbl = new GenderBL();
            ddlGender.DataSource = gbl.SelectAllData();
            ddlGender.DataTextField = "Description";
            ddlGender.DataValueField = "ID";
            ddlGender.DataBind();
            ddlGender.ClearSelection();
            ddlGender.Items.Insert(0, "");
            ddlGender.Text = "";

            SalaryTypeBL stbl = new SalaryTypeBL();
            ddlSalaryType.DataSource = stbl.SelectAll();
            ddlSalaryType.DataTextField = "Description";
            ddlSalaryType.DataValueField = "ID";
            ddlSalaryType.DataBind();
            ddlSalaryType.ClearSelection();
            ddlSalaryType.Items.Insert(0, "");
            ddlSalaryType.Text = "";

            Working_PlaceBL wpbl = new Working_PlaceBL();
            ddlWorkingPlace.DataSource = wpbl.SelectAll(0);
            ddlWorkingPlace.DataTextField = "Description";
            ddlWorkingPlace.DataValueField = "ID";
            ddlWorkingPlace.DataBind();
            ddlWorkingPlace.ClearSelection();
            ddlWorkingPlace.Items.Insert(0, "");
            ddlWorkingPlace.Text = "";

            DayServiceBL dsbl = new DayServiceBL();
            ddlDayService.DataSource = dsbl.SelectAll();
            ddlDayService.DataTextField = "Description";
            ddlDayService.DataValueField = "ID";
            ddlDayService.DataBind();
            ddlDayService.ClearSelection();
            ddlDayService.Items.Insert(0, "");
            ddlDayService.Text = "";

            gb = new GlobalBL();
            DataTable PersonInCharge = gb.Get_Data("Person_Type");
            ddlPersonInCharge.DataSource = PersonInCharge;
            ddlPersonInCharge.DataTextField = "Description";
            ddlPersonInCharge.DataValueField = "ID";
            ddlPersonInCharge.DataBind();
            ddlPersonInCharge.ClearSelection();

            ddlPersonInCharge1.DataSource = PersonInCharge;
            ddlPersonInCharge1.DataTextField = "Description";
            ddlPersonInCharge1.DataValueField = "ID";
            ddlPersonInCharge1.DataBind();
            ddlPersonInCharge1.ClearSelection();

            ddlPersonInCharge2.DataSource = PersonInCharge;
            ddlPersonInCharge2.DataTextField = "Description";
            ddlPersonInCharge2.DataValueField = "ID";
            ddlPersonInCharge2.DataBind();
            ddlPersonInCharge2.ClearSelection();

            LanguageBL lbl = new LanguageBL();
            ddlLanguage.DataSource = lbl.SelectAll();
            ddlLanguage.DataTextField = "Description";
            ddlLanguage.DataValueField = "ID";
            ddlLanguage.DataBind();
            ddlLanguage.ClearSelection();
            ddlLanguage.Items.Insert(0, "");
            ddlLanguage.Text = "";

            gb = new GlobalBL();
            ddlLanguageLevel1.DataSource = gb.Get_Data("Language_Level");
            ddlLanguageLevel1.DataTextField = "Description";
            ddlLanguageLevel1.DataValueField = "ID";
            ddlLanguageLevel1.DataBind();
            ddlLanguageLevel1.ClearSelection();
            ddlLanguageLevel1.Items.Insert(0, "");
            ddlLanguageLevel1.Text = "";

            ddlLanguageLevel2.DataSource = gb.Get_Data("Language_Level");
            ddlLanguageLevel2.DataTextField = "Description";
            ddlLanguageLevel2.DataValueField = "ID";
            ddlLanguageLevel2.DataBind();
            ddlLanguageLevel2.ClearSelection();
            ddlLanguageLevel2.Items.Insert(0, "");
            ddlLanguageLevel2.Text = "";

            ddlJapaneselisting.DataSource = gb.Get_Data("Language_Level");
            ddlJapaneselisting.DataTextField = "Description";
            ddlJapaneselisting.DataValueField = "ID";
            ddlJapaneselisting.DataBind();
            ddlJapaneselisting.ClearSelection();
            ddlJapaneselisting.Items.Insert(0, "");
            ddlJapaneselisting.Text = "";

            ddlJapansepeaking.DataSource = gb.Get_Data("Language_Level");
            ddlJapansepeaking.DataTextField = "Description";
            ddlJapansepeaking.DataValueField = "ID";
            ddlJapansepeaking.DataBind();
            ddlJapansepeaking.ClearSelection();
            ddlJapansepeaking.Items.Insert(0, "");
            ddlJapansepeaking.Text = "";

            ddlmyanmarlistening.DataSource = gb.Get_Data("Language_Level");
            ddlmyanmarlistening.DataTextField = "Description";
            ddlmyanmarlistening.DataValueField = "ID";
            ddlmyanmarlistening.DataBind();
            ddlmyanmarlistening.ClearSelection();
            ddlmyanmarlistening.Items.Insert(0, "");
            ddlmyanmarlistening.Text = "";

            ddlmyanmarspeaking.DataSource = gb.Get_Data("Language_Level");
            ddlmyanmarspeaking.DataTextField = "Description";
            ddlmyanmarspeaking.DataValueField = "ID";
            ddlmyanmarspeaking.DataBind();
            ddlmyanmarspeaking.ClearSelection();
            ddlmyanmarspeaking.Items.Insert(0, "");
            ddlmyanmarspeaking.Text = "";

            ddlJapaneselistingto.DataSource = gb.Get_Data("Language_Level");
            ddlJapaneselistingto.DataTextField = "Description";
            ddlJapaneselistingto.DataValueField = "ID";
            ddlJapaneselistingto.DataBind();
            ddlJapaneselistingto.ClearSelection();
            ddlJapaneselistingto.Items.Insert(0, "");
            ddlJapaneselistingto.Text = "";

            ddlJapansepeakingto.DataSource = gb.Get_Data("Language_Level");
            ddlJapansepeakingto.DataTextField = "Description";
            ddlJapansepeakingto.DataValueField = "ID";
            ddlJapansepeakingto.DataBind();
            ddlJapansepeakingto.ClearSelection();
            ddlJapansepeakingto.Items.Insert(0, "");
            ddlJapansepeakingto.Text = "";

            ddlenglishlistiningto.DataSource = gb.Get_Data("Language_Level");
            ddlenglishlistiningto.DataTextField = "Description";
            ddlenglishlistiningto.DataValueField = "ID";
            ddlenglishlistiningto.DataBind();
            ddlenglishlistiningto.ClearSelection();
            ddlenglishlistiningto.Items.Insert(0, "");
            ddlenglishlistiningto.Text = "";

            ddlenglishspeakingto.DataSource = gb.Get_Data("Language_Level");
            ddlenglishspeakingto.DataTextField = "Description";
            ddlenglishspeakingto.DataValueField = "ID";
            ddlenglishspeakingto.DataBind();
            ddlenglishspeakingto.ClearSelection();
            ddlenglishspeakingto.Items.Insert(0, "");
            ddlenglishspeakingto.Text = "";

            ddlmyanmarlisteningto.DataSource = gb.Get_Data("Language_Level");
            ddlmyanmarlisteningto.DataTextField = "Description";
            ddlmyanmarlisteningto.DataValueField = "ID";
            ddlmyanmarlisteningto.DataBind();
            ddlmyanmarlisteningto.ClearSelection();
            ddlmyanmarlisteningto.Items.Insert(0, "");
            ddlmyanmarlisteningto.Text = "";

            ddlmyanmarspeakingto.DataSource = gb.Get_Data("Language_Level");
            ddlmyanmarspeakingto.DataTextField = "Description";
            ddlmyanmarspeakingto.DataValueField = "ID";
            ddlmyanmarspeakingto.DataBind();
            ddlmyanmarspeakingto.ClearSelection();
            ddlmyanmarspeakingto.Items.Insert(0, "");
            ddlmyanmarspeakingto.Text = "";

            txtOtherIndustry.Text = String.Empty;
            txtOtherPost.Text = String.Empty;
            txtSalaryFrom.Text = String.Empty;
            txtSalaryTo.Text = String.Empty;
            txtOtherSalary.Text = String.Empty;
            txtOtherWorkingPlace.Text = String.Empty;
            txtPersonInCharge.Text = String.Empty;
            txtPersonInCharge1.Text = String.Empty;
            txtPersonInCharge2.Text = String.Empty;
            txtUnit.Text = String.Empty;
            txtPhoneNo.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtEmailConfirm.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            chkWanted.Checked = false;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            clearData();
            btnSave_Update.Text = "Register";   //登録する
            hfMode.Value = "Register";  //登録する
        }

        protected void clearData()
        {
            ddlMajorIndustry.SelectedIndex = 0;
            ddlSmallIndustry.Items.Clear();
            txtOtherIndustry.Text = String.Empty;
            ddlPost.SelectedIndex = 0;
            txtOtherPost.Text = String.Empty;
            ddlGender.SelectedIndex = 0;
            txtSalaryFrom.Text = String.Empty;
            txtSalaryTo.Text = String.Empty;
            ddlSalaryType.SelectedIndex = 0;
            ddlSalaryFormat.SelectedIndex = 0;
            txtOtherSalary.Text = String.Empty;
            ddlWorkingPlace.SelectedIndex = 0;
            txtOtherWorkingPlace.Text = String.Empty;
            ddlDayService.SelectedIndex = 0;
            ddlStartHours.SelectedIndex = 0;
            ddlCloseHours.SelectedIndex = 0;
            ddlLanguage.SelectedIndex = 0;
            ddlLanguageLevel1.SelectedIndex = 0;
            ddlLanguageLevel2.SelectedIndex = 0;
            ddlJapansepeaking.SelectedIndex = 0;
            ddlJapaneselisting.SelectedIndex = 0;
            ddlmyanmarlistening.SelectedIndex = 0;
            ddlmyanmarspeaking.SelectedIndex = 0;
            ddlenglishlistiningto.SelectedIndex = 0;
            ddlenglishspeakingto.SelectedIndex = 0;
            ddlJapaneselistingto.SelectedIndex = 0;
            ddlJapansepeakingto.SelectedIndex = 0;
            ddlmyanmarlisteningto.SelectedIndex = 0;
            ddlmyanmarspeakingto.SelectedIndex = 0;
            ddlAgeFrom.SelectedIndex = 0;
            ddlAgeTo.SelectedIndex = 0;
            ddlPersonInCharge.SelectedIndex = 0;
            ddlPersonInCharge1.SelectedIndex = 0;
            ddlPersonInCharge2.SelectedIndex = 0;
            txtPersonInCharge.Text = String.Empty;
            txtPersonInCharge1.Text = String.Empty;
            txtPersonInCharge2.Text = String.Empty;
            txtUnit.Text = String.Empty;
            txtPhoneNo.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtEmailConfirm.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            chkWanted.Checked = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Client_RecruitmentBL crbl = new Client_RecruitmentBL();
            if (crbl.Delete(Rec_ID, Convert.ToInt32(Session["UserID"]), DeletedDateTime()))
            {
                string url = "Client_Recruitment_View.aspx";
                string script = "window.onload = function(){ alert('";
                script += "Delete Successfully";
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
            else GlobalUI.MessageBox("Deleted Fail!");
        }

        protected void CreatedDateTime()
        {
            cre.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
        }

        protected void UpdatedDateTime()
        {
            cre.UpdatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
        }

        protected DateTime DeletedDateTime()
        {
            return Convert.ToDateTime(System.DateTime.Now.ToString());
        }

        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (String.Equals(txtEmail.Text, txtEmailConfirm.Text))
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                return;
            }
        }

        protected void cusCustom_ServerValidate1(object sender, ServerValidateEventArgs e)
        {
            if (String.Equals(txtEmail1.Text, txtEmailConfirm1.Text))
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                return;
            }
        }

        protected void cusCustom_ServerValidate2(object sender, ServerValidateEventArgs e)
        {
            if (String.Equals(txtEmail2.Text, txtEmailConfirm2.Text))
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                return;
            }
        }

        protected void cusCustom_ServerValidateSalary(object sender, ServerValidateEventArgs e)
        {
            if (BaseLib.Convert_Int(txtSalaryFrom.Text) > BaseLib.Convert_Int(txtSalaryTo.Text))
            {
                e.IsValid = false;
            }
            else e.IsValid = true;
        }

        protected void cusCustom_ServerValidateRemark(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Length <= 400)
                e.IsValid = true;
            else
            {
                e.IsValid = false;
                return;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            txtSubDate.Text = String.Empty;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            txtEnterDate.Text = String.Empty;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            txtInterviewDay.Text = String.Empty;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            DepartmentBL dbl = new DepartmentBL();
            ddlMajorIndustry.DataSource = dbl.SelectAll(1);
            ddlMajorIndustry.DataTextField = "Description";
            ddlMajorIndustry.DataValueField = "ID";
            ddlMajorIndustry.DataBind();
            ddlMajorIndustry.ClearSelection();

            PositionBL pb = new PositionBL();
            ddlSmallIndustry.DataSource = pb.SelectByDepartmentID(BaseLib.Convert_Int(ddlMajorIndustry.SelectedValue));
            ddlSmallIndustry.DataTextField = "Description";
            ddlSmallIndustry.DataValueField = "ID";
            ddlSmallIndustry.DataBind();
            ddlSmallIndustry.ClearSelection();
            UPanelMajorIndustry.Update();
        }
    }
}