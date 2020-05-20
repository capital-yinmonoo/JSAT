using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1.Usercontrol
{
    public partial class Career_InterviewControl : System.Web.UI.UserControl
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        string cid = string.Empty;

        public string CareerID
        {
            get { return cid; }
            set { cid = value; }

        }

        public bool CarEmploymentlink
        {
            get { return lnkEmployment.Enabled; }
            set { lnkEmployment.Enabled = value; }


        }
        public bool CarInterview1link
        {
            get { return lnkInterview1.Enabled; }
            set { lnkInterview1.Enabled = value; }


        }
        public bool CarInterview2link
        {
            get { return lnkInterview2.Enabled; }
            set { lnkInterview2.Enabled = value; }


        }

        public bool CarInterview3link
        {
            get { return lnkInterview3.Enabled; }
            set { lnkInterview3.Enabled = value; }


        }

        public bool CarInformationlink
        {
            get { return lnkInterview4.Enabled; }
            set { lnkInterview4.Enabled = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkCareerProfile_Click(object sender, EventArgs e)
        {
            if (CareerID == null)
            {
                Response.Redirect("~/Employee/Career_Resume.aspx");

            }
            else
                Response.Redirect("~/Employee/Career_Resume.aspx?Career_ID=" + CareerID);
        }

        protected void lnkEmployment_Click(object sender, EventArgs e)
        {
            if (CareerID == null)
            {
                Response.Redirect("~/Employee/CareerEmployment.aspx");
            }
            else
                Response.Redirect("~/Employee/CareerEmployment.aspx?Career_ID=" + CareerID);
        }

        protected void lnkInterview1_Click(object sender, EventArgs e)
        {
            if (CareerID == null)
            {
                Response.Redirect("~/Employee/Career_Interview.aspx");
            }
            else
                Response.Redirect("~/Employee/Career_Interview.aspx?Career_ID=" + CareerID);
        }

        protected void lnkInterview2_Click(object sender, EventArgs e)
        {
            if (CareerID == null)
            {
                Response.Redirect("~/Employee/Career_Interview2.aspx");
            }
            else
                Response.Redirect("~/Employee/Career_Interview2.aspx?Career_ID=" + CareerID);
        }

        protected void lnkInterview3Click(object sender, EventArgs e)
        {
            if (CareerID == null)
            {
                Response.Redirect("~/Employee/Career_Interview3.aspx");
            }
            else
                Response.Redirect("~/Employee/Career_Interview3.aspx?Career_ID=" + CareerID);
        }

        protected void lnkInterview4_Click(object sender, EventArgs e)
        {
            if (CareerID == null)
            {
                Response.Redirect("~/Employee/Career_Information.aspx");
            }
            else
                Response.Redirect("~/Employee/Career_Information.aspx?Career_ID=" + CareerID);
        }
    }
}