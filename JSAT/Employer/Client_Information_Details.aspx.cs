using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_Common;
using JSAT_Ver1;

namespace JSAT_Ver1.Employer
{
    public partial class Client_Information_Details : System.Web.UI.Page
    {
        public int Client_ID
        {
            get
            {
                if (Request.QueryString["ClientID"] != null)
                    return int.Parse(Request.QueryString["ClientID"].ToString());
                return 2;
            }
        }

        JSAT_BL.Client_ProfileBL clientProfile;
        Client_RecruitmentBL clientRecruitment;
        Client_ProfileEntity clientProfileInfo;
        Industry_TypeBL industry;
        Industry_TypeEntity industryInfo;
        BusinessTypeBL business;
        BusinessTypeEntity businessInfo;
        Client_RecruitmentEntity cr;

        string Client_DataPath = ConfigurationManager.AppSettings["Client_DataPath"].ToString();

        //Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Client_ID != 0)
                {
                    BindGrid();
                    FillClientProfile();
                    FillClientRecruitment();
                }

            }

        }

        protected void gvClientRecruitment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                int ID = int.Parse(gvClientRecruitment.DataKeys[e.NewEditIndex].Value.ToString());
                Response.Redirect("~/Employer/Client_Recruitment_Detail.aspx?Client_Recruitment_ID=" + ID + "&Client_ID=" + Client_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvClientRecruitment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int ID = int.Parse(gvClientRecruitment.DataKeys[e.RowIndex].Value.ToString());
                Response.Redirect("~/Employer/Client_Recruitment.aspx?Client_Recruitment_ID=" + ID + "&Client_ID=" + Client_ID + "&EditMode=true");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEditClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client_ID != 0)
                {
                    Response.Redirect("~/Employer/Client_Profile.aspx?Client_ID=" + Client_ID);
                }
                else
                {
                    GlobalUI.MessageBox("There is no Client Profile to Edit!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnRegisterRecruitmentApplication_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Employer/Client_Recruitment.aspx?Client_ID=" + Client_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void lnkAgreementData_Click(object sender, EventArgs e)
        {
            try
            {
                string strURL = lnkAgreementData.Text;
                string FileToCheck = Client_DataPath + strURL;
                if (File.Exists(Server.MapPath(FileToCheck)))
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileToCheck + "\"");
                    response.ContentType = "application/octet-stream";
                    byte[] data = req.DownloadData(Server.MapPath(FileToCheck));
                    response.BinaryWrite(data);
                    response.End();
                }
                else
                {
                    GlobalUI.MessageBox("File doesn't exist!");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Functions
        private void BindGrid()
        {
            try
            {
                clientRecruitment = new Client_RecruitmentBL();
                DataTable dtClientRecruitment = clientRecruitment.SelectByProfileID(Client_ID);

                gvClientRecruitment.DataSource = dtClientRecruitment;
                gvClientRecruitment.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void FillClientProfile()
        {
            try
            {
                clientProfile = new Client_ProfileBL();
                clientProfileInfo = new Client_ProfileEntity();
                clientProfileInfo = clientProfile.SelectByID(Client_ID);

                if (clientProfileInfo != null)
                {
                    lblClientNo.Text = clientProfileInfo.Client_Code.ToString();
                    lblCompanyName.Text = clientProfileInfo.Client_Name;
                    lblPhoneNo.Text = clientProfileInfo.Telephone_No;
                    lblFax.Text = clientProfileInfo.Fax_No;
                    hlWebsite.Text = clientProfileInfo.Website;
                    if (!clientProfileInfo.Website.Contains("http://"))
                    {
                        hlWebsite.NavigateUrl = "http://" + clientProfileInfo.Website;
                    }
                    else
                        hlWebsite.NavigateUrl = clientProfileInfo.Website;

                    lblLocation.Text = clientProfileInfo.Location;
                    int Industry_TypeID = clientProfileInfo.Industry_TypeID;
                    if (Industry_TypeID != 0)
                    {
                        industry = new Industry_TypeBL();
                        industryInfo = new Industry_TypeEntity();
                        industryInfo = industry.SelectByID(Industry_TypeID);
                        lblIndustry.Text = industryInfo.Description;
                    }
                    int Business_TypeID = clientProfileInfo.Business_TypeID;
                    if (Business_TypeID != 0)
                    {
                        business = new BusinessTypeBL();
                        businessInfo = new BusinessTypeEntity();
                        businessInfo = business.SelectByID(Business_TypeID);
                        lblBuisness.Text = businessInfo.Description;
                    }
                    lblNoOfEmployees.Text = clientProfileInfo.Total_Employees.ToString();
                    lblJapHouseNo.Text = clientProfileInfo.NoofClubs.ToString();
                    if (!string.IsNullOrWhiteSpace(clientProfileInfo.Establishment_Date.ToString()))
                    {
                        lblEstablishmentDate.Text = clientProfileInfo.Establishment_Date.ToString();
                    }

                    lblRemark.Text = clientProfileInfo.Remarks;
                    if (clientProfileInfo.Consent.ToLower() == "yes")
                        lblConsent.Text = "○";
                    else if (clientProfileInfo.Consent.ToLower() == "no")
                        lblConsent.Text = String.Empty;
                    lnkAgreementData.Text = clientProfileInfo.Agreement_Data;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void FillClientRecruitment()
        {
            try
            {
                clientRecruitment = new Client_RecruitmentBL();
                DataTable dt = clientRecruitment.SelectByProfileID(Client_ID);


                BoundField bfield = new BoundField();
                bfield.HeaderText = "Wanted";
                bfield.DataField = "Wanted";

                gvClientRecruitment.Columns.Add(bfield);

                if (dt.Rows.Count > 0)
                {
                    lblUpdatedBy.Text = dt.Rows[0]["UpdatedBy"].ToString();
                    lblUpdatedDate.Text = dt.Rows[0]["UpdatedDate"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void gvClientRecruitment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DataBinder.Eval(e.Row.DataItem, "Wanted").ToString().ToLower() == "true")
                    {
                        e.Row.Cells[5].Text = "○";
                    }
                    else if (DataBinder.Eval(e.Row.DataItem, "Wanted").ToString().ToLower() == "false")
                    {
                        e.Row.Cells[5].Text = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvClientRecruitment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientRecruitment.PageIndex = e.NewPageIndex;
            BindGrid();
        }

    }
}