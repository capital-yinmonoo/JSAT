using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1.Usercontrol
{
    public partial class ClientControlLink : System.Web.UI.UserControl
    {
        

        string cid = string.Empty;

        public string ClientID
        {
            get { return cid; }
            set { cid = value; }
        }

        public bool ClientProfileLink
        {
            get { return lnkProfile.Enabled; }
            set { lnkProfile.Enabled = value; }
        }

        public bool RecruitmentLink
        {
            get { return lnkRecruitment.Enabled; }
            set { lnkRecruitment.Enabled = value; }
        }

        public bool CVHistoryLink
        {
            get { return lnkCVHistory.Enabled; }
            set { lnkCVHistory.Enabled = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Client_Profile.aspx?Client_ID=" + ClientID);
        }

        protected void lnkRecruitment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Client_Recruitment.aspx?Client_ID=" + ClientID);
        }

        protected void InkCVHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employer/Job_Interview.aspx?Client_ID=" + ClientID);
        }
    }
}