using JSAT_BL;
using JSAT_Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JSAT_BL.Reference;
using JSAT_Common.Reference;
using JSAT_Ver1;

namespace JSAT_Ver1.Employee
{
    public partial class Employee_SelfEntry : System.Web.UI.Page
    {
        Employee_SelfEntry_BL ebl;
        Employee_SelfEntry_Entity see;

        string Photo_DataPath = ConfigurationManager.AppSettings["Photo_DataPath"].ToString();
        int gm; int gy; int day; int month; int checkdobyear;
        string File;
        string careerID;

        public string CareerID
        {
            get
            {
                if (Session["CareerID"] != null)
                {
                    return Convert.ToString(Session["CareerID"]);
                }
                else
                {
                    return null;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["AutoCode"] != null)
                {
                    string autocode = Request.QueryString["AutoCode"];
                    currentdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    currentdate.ReadOnly = true;
                    Bind_Religion();
                    Bind_Address();
                    GetData();
                    btnSave.Text = "Update";
                }
                else
                {
                    currentdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    currentdate.ReadOnly = true;
                    Bind_Religion();
                    Bind_Address();
                }
            }
            if (Session["FileUpload1"] == null && FileUpload1.HasFile)
            {
                see = new Employee_SelfEntry_Entity();
                Session["FileUpload1"] = FileUpload1;
                lblimage.Text = FileUpload1.FileName;
                see.Photo_Data = lblimage.Text;
            }
            // Next time submit and Session has values but FileUpload is Blank 
            // Return the values from session to FileUpload 
            else if (Session["FileUpload1"] != null && (!FileUpload1.HasFile))
            {
                FileUpload1 = (FileUpload)Session["FileUpload1"];
                lblimage.Text = FileUpload1.FileName;
            }
            // Now there could be another sictution when Session has File but user want to change the file 
            // In this case we have to change the file in session object 
            else if (FileUpload1.HasFile)
            {
                Session["FileUpload1"] = FileUpload1;
                lblimage.Text = FileUpload1.FileName;
            }
        }

        public void GetData()
        {
            ebl = new Employee_SelfEntry_BL();
            Employee_SelfEntry_Entity see1 = Session["EmpInfo"] as Employee_SelfEntry_Entity;
            txtday.Text = Convert.ToString(see1.Day);
            txtmonth.Text = Convert.ToString(see1.Month);
            txtyear.Text = Convert.ToString(see1.Year);
            lblAutoNo.Text = Convert.ToString(see1.AutoCode);
            txtName.Text = see1.Name;
            ddlGender.SelectedValue = Convert.ToString(see1.Gender);
            txtPhone.Text = see1.Phone;
            txtEPhone.Text = see1.EmergencyPhone;
            txtEmail.Text = see1.Email;
            txtEName.Text = see1.Emergencycontantperson;
            DataTable dt = ebl.GetReligion(see1.Religion);
            if (ddlReligion.Items.FindByText(dt.Rows[0]["Description"].ToString()) != null)
            {
                ddlReligion.ClearSelection();
                ddlReligion.Items.FindByText(dt.Rows[0]["Description"].ToString()).Selected = true;
            }
            DataTable dt1 = ebl.GetAddress(see1.Address);
            if (ddlAddress.Items.FindByText(dt1.Rows[0]["Description"].ToString()) != null)
            {
                ddlAddress.ClearSelection();
                ddlAddress.Items.FindByText(dt1.Rows[0]["Description"].ToString()).Selected = true;
            }
            if (dt1.Rows[0]["Description"].ToString() == "Other")
            {
                txtAddress.Style.Add("display", "block");
                txtAddress.Text = see1.Detail_Add;
            }
            else
                txtAddress.Style.Add("display", "none");
            lblimage.Text = see1.Photo_Data;
            ImagePreview.Visible = true;
            ImagePreview.ImageUrl = Photo_DataPath + lblimage.Text;
            if (see1.Photo_Data == "_01_") lblimage.Text = "";
        }

        public void Bind_Religion()
        {
            try
            {
                GlobalBL gb = new GlobalBL();
                ddlReligion.DataSource = gb.Get_Data("Religion");
                ddlReligion.DataTextField = "Description";
                ddlReligion.DataValueField = "ID";
                ddlReligion.DataBind();
                ddlReligion.Items.Insert(0, "--Select--");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Bind_Address()
        {
            try
            {
                GlobalBL gb = new GlobalBL();
                ddlAddress.DataSource = gb.Get_Data("Residential_Area");
                ddlAddress.DataTextField = "Description";
                ddlAddress.DataValueField = "ID";
                ddlAddress.DataBind();
                //ddlAddress.Items.Insert(0, "--Select--");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlAddress.SelectedValue != "")
            {
                lblAddrequire.Style.Add("display", "none");
                Session.Remove("EmpInfo");
                ebl = new Employee_SelfEntry_BL();
                see = new Employee_SelfEntry_Entity();
                DataTable dt = new DataTable();
                see.Name = txtName.Text;
                see.Gender = Convert.ToInt32(ddlGender.SelectedValue);
                if (!string.IsNullOrWhiteSpace(txtday.Text) && !String.IsNullOrWhiteSpace(txtmonth.Text) && !String.IsNullOrWhiteSpace(txtyear.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtday.Text))
                        day = Int32.Parse(txtday.Text.Trim());
                    see.Day = day;
                    if (!string.IsNullOrWhiteSpace(txtmonth.Text))
                        month = Int32.Parse(txtmonth.Text.Trim());
                    see.Month = month;
                    int years = Int32.Parse(txtyear.Text.Trim());
                    see.Year = years;
                    int checkdate = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                    int checkyear = (checkdate - 16);
                    if (years >= 1950 && years <= checkyear)
                    {
                        if (day <= 31 && month <= 12)
                        {
                            if (month == 9 || month == 4 || month == 6 || month == 11)
                            {
                                if (day > 30)
                                {
                                    day = 30;
                                }
                            }
                            else if (month == 2)
                            {
                                if (((years % 4 == 0 && years % 100 != 0) || (years % 400 == 0)) && day > 29)
                                {
                                    day = 29;
                                }
                                else if (day > 28)
                                {
                                    day = 28;
                                }
                                else
                                {
                                    day = Convert.ToInt32(txtday.Text.Trim());
                                    month = Convert.ToInt32(txtmonth.Text.Trim());
                                }
                            }
                            else
                            {
                                if (day > 31)
                                {
                                    day = 31;
                                }
                            }
                            string dbdate = month + "-" + day + "-" + years;
                            DateTime dateofbirth = Convert.ToDateTime(dbdate);
                            string date = Convert.ToDateTime(dateofbirth, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                            see.DOB = DateTime.ParseExact(date, "MM/dd/yyyy", null);
                            //Calculating Age using DOB
                            if (!String.IsNullOrWhiteSpace(see.DOB.ToString()))
                            {
                                DateTime? DOB = see.DOB;
                                DateTime today = DateTime.Today;
                                int age = today.Year - DOB.Value.Year;
                                if (DOB > today.AddYears(-age)) age--;
                                see.Age = age;
                            }
                        }
                    }
                }
                else
                {
                    checkdobyear = 15;
                }
                see.Religion = Convert.ToInt32(ddlReligion.SelectedValue);
                see.Address = Convert.ToInt32(ddlAddress.SelectedValue);
                if (ddlAddress.SelectedItem.Text == "Other")
                    see.Detail_Add = txtAddress.Text.Trim();
                else
                    see.Detail_Add = string.Empty;
                see.Phone = txtPhone.Text;
                see.Emergencycontantperson = txtEName.Text;
                see.EmergencyPhone = txtEPhone.Text;
                see.Email = txtEmail.Text;
                see.Currentdate = Convert.ToDateTime(currentdate.Text);
                if (btnSave.Text == "Save")
                {
                    if (FileUpload1.HasFile)
                    {
                        string File = FileUpload1.FileName;
                        see.Photo_Data = "_01" + "_" + File;
                        FileUpload1.SaveAs(Photo_DataPath + "_01" + "_" + File);
                    }
                }
                else
                {
                    if (FileUpload1.HasFile)
                    {
                        string File = FileUpload1.FileName;
                        see.Photo_Data = "_01" + "_" + File;
                        FileUpload1.SaveAs(Server.MapPath(Photo_DataPath) + "_01" + "_" + File);
                    }
                }
                if (btnSave.Text == "Save")
                {
                    int autoCode = ebl.Insert(see);
                    int id = see.CareerId;
                    hfCareerID.Value = id.ToString();
                    see.AutoCode = autoCode;
                    lblAutoNo.Text = autoCode.ToString();
                    Session["EmpInfo"] = see;
                    Session["CareerID"] = id;
                    Session.Remove("FileUpload1");
                    if (id != 0)
                    {
                        object referrer = ViewState["UrlReferrer"];
                        string url = (string)referrer;
                        string script = "window.onload = function(){ alert('";
                        script += "Thank You for your registration!";
                        script += "Client Code is " + lblAutoNo.Text;
                        script += "');";
                        script += "window.location = '";
                        script += "Employee_SelfView.aspx";
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                }
                else
                {
                    ebl.Update(see, lblAutoNo.Text);
                    int id = Convert.ToInt32(CareerID);
                    Session["EmpInfo"] = see;
                    Session.Remove("FileUpload1");
                    if (id != 0)
                    {
                        object referrer = ViewState["UrlReferrer"];
                        string url = (string)referrer;
                        string script = "window.onload = function(){ alert('";
                        script += "Update Successfully!";
                        script += "Client Code is " + lblAutoNo.Text;
                        script += "');";
                        script += "window.location = '";
                        script += "Employee_SelfEntry.aspx";
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                }
            }
            else
                lblAddrequire.Style.Add("display", "block");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            FileUpload1.PostedFile.InputStream.Dispose();
            lblimage.Text = "";
            Response.Redirect("Employee_SelfEntry.aspx");
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                File = FileUpload1.FileName;
                ImagePreview.Visible = true;
                Session["ImageBytes"] = FileUpload1.FileBytes;
                ImagePreview.ImageUrl = "ImageHandler.ashx";
            }
        }
    }
}
