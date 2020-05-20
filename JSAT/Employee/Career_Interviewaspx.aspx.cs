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
    public partial class Career_Interviewaspx : System.Web.UI.Page
    {
        Working_PlaceBL workingPlace;
        Career_InterviewBL ci;
        Career_InterviewEntity ciInfo;
        // public static string previouspage;

        public int Career_ID
        {
            get
            {
                if (Request.QueryString["Career_ID"] != null)
                    return int.Parse(Request.QueryString["Career_ID"].ToString());
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cblLocation.Attributes.Add("onclick", "radioMe(event);");
            // User Authorized 
            UserRoleBL user = new UserRoleBL();
            int userID = BaseLib.Convert_Int(Session["UserID"].ToString());

            bool resultRead = user.CanRead(userID, "026");
            if (resultRead)
            {
                btnSave.Visible = false;
                //btnDelete.Visible = false;
            }

            //bool resultDelete = user.CanDelete(userID, "026");
            //if (resultDelete)
            //    btnDelete.Visible = true;
            //else
            //    btnDelete.Visible = false;

            bool resultEdit = user.CanSave(userID, "026");
            if (resultEdit)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;


            Career_InterviewControl1.CareerID = Career_ID.ToString();
            Career_InterviewControl1.CarEmploymentlink = true;
            Career_InterviewControl1.CarInterview1link = true;
            Career_InterviewControl1.CarInterview2link = true;
            Career_InterviewControl1.CarInterview3link = true;
            Career_InterviewControl1.CarInformationlink = true;

            if (chkAbroad.Checked == false)
            {
                cblLocation.ClearSelection();
                cblLocation.Enabled = false;
            }
            else
            {
                cblLocation.Enabled = true;
            }

            if (!IsPostBack)
            {


                if (Request.UrlReferrer != null)
                {
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                    //previouspage = Request.UrlReferrer.ToString();
                }
                else ViewState["UrlReferrer"] = null;

                txtAddress.Focus();
                ci = new Career_InterviewBL();
                ciInfo = new Career_InterviewEntity();
                Get_WorkingPlace();

                if (Career_ID != 0)
                {
                    Career_ResumeBL crbl = new Career_ResumeBL();
                    DataTable dt = new DataTable();
                    dt = crbl.SelectByCareerID(Career_ID);
                    if (dt.Rows.Count > 0)
                        txtArea.Text = dt.Rows[0]["Address"].ToString();


                    ciInfo = ci.SelectByCarrerID(Career_ID);
                    //ciInfo = ci.SelectByCarrerID(2);
                    if (ciInfo.ID != 0)
                    {
                        hdfID.Value = ciInfo.ID.ToString();
                        GetData(ciInfo);
                        btnSave.Text = "更新する";
                    }
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ci = new Career_InterviewBL();
                ciInfo = new Career_InterviewEntity();
                if (hdfID.Value == "")
                {
                    if (SetData() == true)
                    {
                        CreatedDateTime();
                        UpdatedDateTime();
                        string str = ci.Insert(ciInfo);
                        if (str == "Insert Successful!")
                        {
                            Response.Write("<script>alert('Insert Successful!')</script>");
                            Response.Write("<script>window.location.href='Career_Interview.aspx?Career_ID='+Career_ID</script>");
                            //object referrer = ViewState["UrlReferrer"];
                            //string url = (string)referrer;
                            //string script = "window.onload = function(){ alert('";
                            //script += str;
                            //script += "');";
                            //script += "window.location = '";
                            //script += url;
                            //script += "'; }";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                            //Response.Redirect("Career_Interview.aspx?Career_ID="+Career_ID);
                        }
                        else
                        {
                            GlobalUI.MessageBox(str);
                        }
                        //GlobalUI.MessageBox(str);
                    }
                }
                else
                {
                    ciInfo.ID = int.Parse(hdfID.Value);

                    if (SetData() == true)
                    {
                        UpdatedDateTime();
                        SetData();
                        string str = ci.Update(ciInfo);
                        if (str == "Update Successful!")
                        {
                            //object referrer = ViewState["UrlReferrer"];
                            //string url = (string)referrer;
                            //string script = "window.onload = function(){ alert('";
                            //script += str;
                            //script += "');";
                            //script += "window.location = '";
                            //script += url;
                            //script += "'; }";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                            //Response.Redirect("Career_Interview.aspx?Career_ID?"+Career_ID);
                            Response.Write("<script>alert('Update Successful!')</script>");
                            Response.Write("<script>window.location.href='Career_Interview.aspx?Career_ID='+Career_ID</script>");
                        }
                        else
                        {
                            GlobalUI.MessageBox(str);
                        }
                        //GlobalUI.MessageBox(str);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void Get_WorkingPlace()
        {
            try
            {
                workingPlace = new Working_PlaceBL();
                cblLocation.DataSource = workingPlace.SelectAll(1);
                cblLocation.DataTextField = "Description";
                cblLocation.DataValueField = "ID";
                cblLocation.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected bool SetData()
        {
            try
            {
                ciInfo.Career_ID = Career_ID;
                //ciInfo.Career_ID = 2;
                if (chkJobIntro.Checked)
                    ciInfo.Job_Introduction = true;
                else ciInfo.Job_Introduction = false;
                ciInfo.Address = txtAddress.Text;
                ciInfo.Residential_Area = txtArea.Text;
                ciInfo.Phone_No1 = txtPhone1.Text;
                ciInfo.Phone_No2 = txtPhone2.Text;
                ciInfo.Email = txtEmail.Text;
                ciInfo.Emergency_ContactNo = txtEmergencyNo.Text;
                ciInfo.Emergency_ContactName = txtEmergencyName.Text;
                ciInfo.Family_Persons = int.Parse(ddlPersons.SelectedValue);
                ciInfo.Family_Occupation = txtOccupation.Text;
                ciInfo.Family_Income = int.Parse(ddlIncome.SelectedValue);
                if (chkAccuracy.Checked)
                    ciInfo.Apprentice_Accuracy = true;
                else ciInfo.Apprentice_Accuracy = false;
                if (chkAbroad.Checked)
                    ciInfo.Working_Abroad = true;
                else ciInfo.Working_Abroad = false;

                if (cblLocation.Items.FindByText("日本(ဂ်ပန္)").Selected == true)
                    ciInfo.Location_ID = BaseLib.Convert_Int(cblLocation.Items.FindByText("日本(ဂ်ပန္)").Value);

                if (cblLocation.Items.FindByText("タイ(ထိုင္း)").Selected == true)
                    ciInfo.LocationID2 = BaseLib.Convert_Int(cblLocation.Items.FindByText("タイ(ထိုင္း)").Value);

                if (cblLocation.Items.FindByText("シンガポール(စကၤာပူ)").Selected == true)
                    ciInfo.LocationID3 = BaseLib.Convert_Int(cblLocation.Items.FindByText("シンガポール(စကၤာပူ)").Value);

                if (cblLocation.Items.FindByText("その他(အၿခား)").Selected == true)
                    ciInfo.LocationID4 = BaseLib.Convert_Int(cblLocation.Items.FindByText("その他(အၿခား)").Value);

                ciInfo.Other_Place = txtPlace.Text;
                ciInfo.Period = int.Parse(ddlPeriod.SelectedValue);
                ciInfo.Other_Period = txtPeriod.Text;
                ciInfo.Remarks = txtRemarks.Text;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void GetData(Career_InterviewEntity ciInfo)
        {
            try
            {
                lblUpdatedBy.Visible = true;
                lblUpdatedDate.Visible = true;
                lblUpdater.Visible = true;
                lblUpdateTime.Visible = true;

                lblUpdatedBy.Text = ciInfo.Updater;
                lblUpdatedDate.Text = ciInfo.UpdateTime;

                //txtArea.Text = ciInfo.Residential_Area;

                if (ciInfo.Job_Introduction == true)
                    chkJobIntro.Checked = true;
                else chkJobIntro.Checked = false;
                txtAddress.Text = ciInfo.Address;
                txtPhone1.Text = ciInfo.Phone_No1;
                txtPhone2.Text = ciInfo.Phone_No2;
                txtEmail.Text = ciInfo.Email;
                txtEmergencyNo.Text = ciInfo.Emergency_ContactNo;
                txtEmergencyName.Text = ciInfo.Emergency_ContactName;
                ddlPersons.SelectedIndex = int.Parse(ciInfo.Family_Persons.ToString()) - 1;
                txtOccupation.Text = ciInfo.Family_Occupation;
                ddlIncome.SelectedIndex = int.Parse(ciInfo.Family_Income.ToString()) - 1;
                if (ciInfo.Apprentice_Accuracy == true)
                    chkAccuracy.Checked = true;
                else chkAccuracy.Checked = false;
                if (ciInfo.Working_Abroad == true)
                {
                    chkAbroad.Checked = true;
                    cblLocation.Enabled = true;
                }
                else
                {
                    chkAbroad.Checked = false;
                    cblLocation.Enabled = false;
                }

                if (ciInfo.Location_ID > 0)
                    cblLocation.Items.FindByValue(ciInfo.Location_ID.ToString()).Selected = true;

                if (ciInfo.LocationID2 > 0)
                    cblLocation.Items.FindByValue(ciInfo.LocationID2.ToString()).Selected = true;

                if (ciInfo.LocationID3 > 0)
                    cblLocation.Items.FindByValue(ciInfo.LocationID3.ToString()).Selected = true;

                if (ciInfo.LocationID4 > 0)
                    cblLocation.Items.FindByValue(ciInfo.LocationID4.ToString()).Selected = true;


                txtPlace.Text = ciInfo.Other_Place;
                ddlPeriod.SelectedIndex = int.Parse(ciInfo.Period.ToString()) - 1;
                txtPeriod.Text = ciInfo.Other_Period;
                txtRemarks.Text = ciInfo.Remarks;
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
                ciInfo.CreatedBy = Convert.ToInt32(Session["UserID"]);
                ciInfo.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
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
                ciInfo.UpdatedBy = Convert.ToInt32(Session["UserID"]);
                ciInfo.UpdatedDate = Convert.ToDateTime(System.DateTime.Now.ToString());
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
                ciInfo.DeletedBy = Convert.ToInt32(Session["UserID"]);
                return Convert.ToDateTime(System.DateTime.Now.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                if (e.Value.Length < 400)
                    e.IsValid = true;
                else
                {
                    e.IsValid = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnEmploymentRecord_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/CareerEmployment.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCheckComment_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Interview3.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnDataPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Information.aspx?Career_ID=" + Career_ID);
                // Response.Redirect("~/Employee/Career_Information_Upload.aspx?Career_ID=" + Career_ID,false);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void btnCareerResume_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employee/Career_Resume.aspx?Career_ID=" + Career_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}