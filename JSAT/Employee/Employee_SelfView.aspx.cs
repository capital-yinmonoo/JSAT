using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSAT_Ver1.Employee
{
    public partial class Employee_SelfView : System.Web.UI.Page
    {
        Employee_SelfEntry_Entity see1;
        Employee_SelfEntry_BL ebl;
        string CareerID;
        string imagePath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            CareerID = (Session["CareerID"]).ToString();
            Session["CareerID"] = CareerID;
            Employee_SelfEntry_Entity see1 = Session["EmpInfo"] as Employee_SelfEntry_Entity;
            Confirm(see1);
        }

        public void Confirm(Employee_SelfEntry_Entity see1)
        {
            ebl = new Employee_SelfEntry_BL();
            lblAutoNo.Text = Convert.ToString(see1.AutoCode);
            lblName1.Text = see1.Name;
            DataTable dtDOB = ebl.GetDOB(lblAutoNo.Text);
            lblDOB.Text = Convert.ToString(dtDOB.Rows[0]["DOB"]);
            if (see1.Gender == 1)
            {
                lblGender1.Text = "Male";
            }
            else
            {
                lblGender1.Text = "Female";
            }
            DataTable dt = ebl.GetReligion(see1.Religion);
            lblReligion1.Text = Convert.ToString(dt.Rows[0]["Description"]);
            DataTable dt1 = ebl.GetAddress(see1.Address);
            lblAddress1.Text = Convert.ToString(dt1.Rows[0]["Description"]);
            lblPhone1.Text = see1.Phone;
            lblEPhone1.Text = see1.EmergencyPhone;
            lblEmail1.Text = see1.Email;
            if((see1.Photo_Data == "_01_") || (String.IsNullOrWhiteSpace(see1.Photo_Data)))
            {
                lblimage.Text = "";
                Image1.Visible = false;
            }
            else
            {
                lblimage.Text = see1.Photo_Data;
                Image1.ImageUrl = imagePath + lblimage.Text;
            }
            lblEName1.Text = see1.Emergencycontantperson;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_SelfEntry.aspx?AutoCode=" + lblAutoNo.Text + "& CareerID=" + CareerID);
        }
    }
}