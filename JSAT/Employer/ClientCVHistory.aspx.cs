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
    public partial class ClientCVHistory : System.Web.UI.Page
    {
        protected string InputValue { get; set; }
        ClientCVHistoryBL cv;
        ClientCVHistoryEntity cvInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNoHistory.Focus();
            ClientControlLink1.ClientID = Request.QueryString["Client_ID"];
            ClientControlLink1.ClientProfileLink = true;
            ClientControlLink1.RecruitmentLink = true;
            ClientControlLink1.CVHistoryLink = true;
            if (!IsPostBack)
            {
                cvInfo = new ClientCVHistoryEntity();
                cv = new ClientCVHistoryBL();
                if (Request.QueryString["Client_ID"] != null)
                {
                    cvInfo = cv.SelectByClientID(Convert.ToInt16(Request.QueryString["Client_ID"]));
                    if (cvInfo != null)
                    {
                        hdfCVID.Value = cvInfo.ID.ToString();
                        Get_CV(cvInfo);
                        btnSave.Text = "Update";
                    }
                }
            }
            

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cv = new ClientCVHistoryBL();
                cvInfo = new ClientCVHistoryEntity();

                if (Request.Form["datepicker"].ToString() == "") lblDate.Text = "*";
                else
                {
                    lblDate.Text = "";
                    if (btnSave.Text == "Save(登録する)")
                    {
                        string str = "Not Allow Charaters";
                        if (Set_CV() == true)
                            str = cv.Insert(cvInfo);
                        GlobalUI.MessageBox(str);
                    }
                    else if (btnSave.Text == "Update")
                    {
                        string str = "Not Allow Charaters";
                        cvInfo.ID = int.Parse(hdfCVID.Value);
                        if (Set_CV() == true)
                            str = cv.Update(cvInfo);
                        GlobalUI.MessageBox(str);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool Set_CV()
        {
            if (BaseLib.IsInt(txtNoHistory.Text) == false)
                return false;
            else
            {
                cvInfo.Client_ID = Convert.ToInt16(Request.QueryString["Client_ID"].ToString());
                cvInfo.No_History = int.Parse(txtNoHistory.Text);
                cvInfo.Company_Name = txtCompanyName.Text;
                cvInfo.Occupation = txtOccupation.Text;
                cvInfo.Result = txtResult.Text;
                string strDate = Request.Form["datepicker"].ToString();
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd-MM-yyyy";
                dtfi.DateSeparator = "-";
                DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                string date = Convert.ToDateTime(objDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy hh:MM:ss");
                cvInfo.Interview_Date = DateTime.ParseExact(date, "MM/dd/yyyy hh:MM:ss", null);
                cvInfo.Recruitment_Result = ckbRecruitment.Checked;
                cvInfo.Comment = txtComment.Text;
                return true;
            }
        }

        protected void Get_CV(ClientCVHistoryEntity cvInfo)
        {
            try
            {
                txtNoHistory.Text = cvInfo.No_History.ToString();
                txtCompanyName.Text = cvInfo.Company_Name;
                txtOccupation.Text = cvInfo.Occupation;
                this.InputValue = Convert.ToDateTime(cvInfo.Interview_Date.ToShortDateString(), CultureInfo.GetCultureInfo("en-US")).ToString("dd/MM/yyyy");
                txtResult.Text = cvInfo.Result;
                ckbRecruitment.Checked = cvInfo.Recruitment_Result;
                txtComment.Text = cvInfo.Comment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       
    }
}