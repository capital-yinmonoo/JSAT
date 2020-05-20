﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using System.Data;
using JSAT_Common;
using System.Globalization;

namespace JSAT.Employee
{
    public partial class IntroductionListFor_Career : System.Web.UI.Page
    {
        IntroductionListForCareer_BL introbl;
        IntroductionListForCareer_Entity introentity;
        Boolean userroll;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (IsPostBack)
                {
                }

                #region for popup

                if (!String.IsNullOrWhiteSpace(hdfcompany.Value))
                {
                    String[] str = (hdfcompany.Value.Split('$'));
                    if (str.Length == 2)
                    {
                        txtName.Text = str[0];
                        txtID.Text = str[1];
                        Session["ID"] = txtName.Text;
                        hdfcompany.Value = String.Empty;
                        hdfJobNo.Value = String.Empty;
                    }
                }

                if (!String.IsNullOrWhiteSpace(hdfJobNo.Value))
                {

                    String[] str1 = (hdfJobNo.Value.Split('$'));
                    if (str1.Length == 1)
                    {

                        txtJobNo.Text = str1[0];

                        Session["JobID"] = txtJobNo.Text;
                        hdfJobNo.Value = String.Empty;

                    }

                }


                #endregion





                if (!IsPostBack)
                {
                    #region Userroll
                    UserRoleBL user = new UserRoleBL();
                    int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                    bool resultRead = user.CanRead(userID, "058");
                    if (resultRead)
                    {
                        btnsave.Visible = false;
                        btnsupdate.Visible = false;
                    }
                    bool resultEdit = user.CanSave(userID, "058");

                    if (resultEdit)
                    {
                        btnsupdate.Visible = true;
                    }
                    else

                        btnsupdate.Visible = false;
                    userroll = resultEdit;

                    #endregion

                    fillData();
                    SetIntialRow();
                    btnsupdate.Visible = false;
                    gvintroduction.Visible = false;
                    btnsave.Visible = false;
                    #region old
                    //if (Request.QueryString["ID"] != null)
                    //{

                    //    btnsupdate.Visible = true;
                    //    int updateid = int.Parse(Request.QueryString["ID"]);
                    //    DataTable dtb = new DataTable();
                    //    IntroductionListForCareer_BL introbl = new IntroductionListForCareer_BL();
                    //    dtb=introbl.SelectUpdate(updateid);
                    //    if (dtb.Rows.Count > 0)
                    //    {
                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Carrer_Code"].ToString()))
                    //        {
                    //            string[] str = dtb.Rows[0]["Carrer_Code"].ToString().Split('-');
                    //            if (str.Length == 2)
                    //            {
                    //                if (ddlemployeecode.Items.FindByText(str[0]) != null)
                    //                {
                    //                    ddlemployeecode.ClearSelection();
                    //                    ddlemployeecode.Items.FindByText(str[0]).Selected = true;
                    //                }
                    //                txtempcode.Text = str[1];
                    //            }
                    //            else
                    //            {
                    //                txtempcode.Text = str[0];
                    //            }

                    //        }
                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Name"].ToString()))
                    //        {
                    //            txtempname.Text = dtb.Rows[0]["Name"].ToString();
                    //        }

                    //        if (ddlgender.Items.FindByText(dtb.Rows[0]["gender"].ToString()) != null)
                    //        {
                    //            ddlgender.ClearSelection();
                    //            ddlgender.Items.FindByText(dtb.Rows[0]["gender"].ToString()).Selected = true;
                    //        }

                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Salary"].ToString()))
                    //        {
                    //            txtsalary.Text = dtb.Rows[0]["Salary"].ToString();
                    //        }
                    //        if (ddltype.Items.FindByText(dtb.Rows[0]["SalaryType"].ToString()) != null)
                    //        {
                    //            ddltype.ClearSelection();
                    //            ddltype.Items.FindByText(dtb.Rows[0]["SalaryType"].ToString()).Selected = true;
                    //        }
                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Start_Working_Date"].ToString()))
                    //        {
                    //            DateTime date = (DateTime)dtb.Rows[0]["Start_Working_Date"];
                    //            txtdate.Text = Convert.ToDateTime(date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                    //        }
                    //        if (Convert.ToBoolean(dtb.Rows[0]["Sign"].ToString()) == true)
                    //        {
                    //            chksing.Checked = true;
                    //        }
                    //        else
                    //        {
                    //            chksing.Checked = false;
                    //        }

                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Company_Name"].ToString()))
                    //        {
                    //            txtName.Text = dtb.Rows[0]["Company_Name"].ToString();
                    //        }
                    //        if(!String.IsNullOrWhiteSpace(dtb.Rows[0]["CompanyID"].ToString()))
                    //        {
                    //            txtID.Text=dtb.Rows[0]["CompanyID"].ToString();
                    //        }
                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Job_No"].ToString()))
                    //        {
                    //            txtJobNo.Text = dtb.Rows[0]["Job_No"].ToString();
                    //        }

                    //        if (ddlposition.Items.FindByText(dtb.Rows[0]["Position"].ToString()) != null)
                    //        {
                    //            ddlposition.ClearSelection();
                    //            ddlposition.Items.FindByText(dtb.Rows[0]["Position"].ToString()).Selected = true;
                    //        }
                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Introduction_Date"].ToString()))
                    //        {
                    //            DateTime date1 = (DateTime)dtb.Rows[0]["Introduction_Date"];
                    //            txtintro.Text = Convert.ToDateTime(date1.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                    //        }
                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Sent_CV_Date"].ToString()))
                    //        {
                    //            DateTime datecv = (DateTime)dtb.Rows[0]["Sent_CV_Date"];
                    //            txtcv.Text = Convert.ToDateTime(datecv.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                    //        }

                    //        if (ddllexpectedsalarytype.Items.FindByText(dtb.Rows[0]["ExpectedSalary_Type"].ToString()) != null)
                    //        {
                    //            ddllexpectedsalarytype.ClearSelection();
                    //            ddllexpectedsalarytype.Items.FindByText(dtb.Rows[0]["ExpectedSalary_Type"].ToString()).Selected = true;
                    //        }

                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Expected_Salary"].ToString()))
                    //        {
                    //            TextBox2.Text = dtb.Rows[0]["Expected_Salary"].ToString();
                    //        }

                    //        if (ddlcondition.Items.FindByText(dtb.Rows[0]["Condition"].ToString()) != null)
                    //        {
                    //            ddlcondition.ClearSelection();
                    //            ddlcondition.Items.FindByText(dtb.Rows[0]["Condition"].ToString()).Selected = true;
                    //        }
                    //        if (dtb.Rows[0]["NoticeType"].ToString() == "immediate")
                    //        {
                    //            lblimmediate.Visible = true;
                    //            chkimmediate.Visible = true;
                    //            chkimmediate.Checked = true;
                    //            rdocheckimmediate.Checked = true;
                    //            rdoimmediate.Visible = false;
                    //        }
                    //        else
                    //        {
                    //            string[] str = dtb.Rows[0]["NoticeType"].ToString().Split('-');
                    //            if (str.Length > 1)
                    //            {
                    //                txtnotice.Text = str[0];
                    //                if (str[1] == "m")
                    //                {
                    //                    ddlmw.SelectedIndex = 1;
                    //                    rdocheckm.Checked = true;

                    //                }
                    //                else if (str[1] == "w")
                    //                {
                    //                    ddlmw.SelectedIndex = 2;
                    //                    rdocheckw.Checked = true;
                    //                }
                    //                else
                    //                {
                    //                    ddlmw.SelectedIndex = 0;
                    //                }


                    //                txtnotice.Visible = true;
                    //                ddlmw.Visible = true;
                    //                rdomw.Visible = false;
                    //            }
                    //            else
                    //            {

                    //                txtnotice.Visible = false;
                    //                ddlmw.Visible = false;
                    //            }


                    //    }

                    //        if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Interview_Date"].ToString()))
                    //        {
                    //            DateTime dateiterview = (DateTime)dtb.Rows[0]["Interview_Date"];
                    //            txtinterviewdate.Text = Convert.ToDateTime(dateiterview.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                    //        }
                    //         if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Result"].ToString()))
                    //        {
                    //            txtresult.Text = dtb.Rows[0]["Result"].ToString();
                    //        }
                    //         lblinfoid.Text = dtb.Rows[0]["Success_Worker_ID"].ToString();

                    //         if (resultEdit)
                    //         {
                    //             btnsupdate.Visible = true;
                    //         }
                    //         else
                    //         {
                    //             btnsupdate.Visible = false;
                    //         }
                    //         btnadd.Visible = false;
                    //}
                    //}
                    #endregion
                    #region new
                    if (Request.QueryString["ID"] != null)
                    {
                        introbl = new IntroductionListForCareer_BL();
                        int id = int.Parse(Request.QueryString["ID"]);
                        DataTable dtbfil = introbl.FillData(id);
                        FillData(dtbfil);
                        BindDataForGridView(id);


                    }



                    #endregion
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void fillData()
        {
            //IntroductionListForCareer_BL introbl = new IntroductionListForCareer_BL();
            //DataTable dtbind = new DataTable();
            //dtbind = introbl.Bind();
            //ddlcondition.DataSource = dtbind;
            //ddlcondition.DataTextField = "Description";
            //ddlcondition.DataValueField = "ID";
            //ddlcondition.DataBind();
            //ddlcondition.ClearSelection();
            //ddlcondition.Items.Insert(0, "");
            //ddlcondition.Text = "";

            IntroductionListForCareer_BL introbl = new IntroductionListForCareer_BL();
            DataTable dtbind = new DataTable();
            dtbind = introbl.Bind();
            ddlcondition.DataSource = dtbind;
            ddlcondition.DataTextField = "Description";
            ddlcondition.DataValueField = "ID";
            ddlcondition.DataBind();
            ddlcondition.ClearSelection();
            ddlcondition.Items.Insert(0, "");
            ddlcondition.Text = "";


            GlobalBL global = new GlobalBL();
            ddlposition.DataSource = global.Get_Datanew("Position");
            ddlposition.DataTextField = "Description";
            ddlposition.DataValueField = "ID";
            ddlposition.DataBind();
            ddlposition.ClearSelection();
            ddlposition.Items.Insert(0, new ListItem("", "0"));
            ddlposition.Text = "";

            introbl = new IntroductionListForCareer_BL();
            DataTable bindtype = new DataTable();
            bindtype = introbl.BindDDL();
            ddltype.DataSource = bindtype;
            ddltype.DataTextField = "Description";
            ddltype.DataValueField = "ID";
            ddltype.DataBind();
            ddltype.ClearSelection();
            ddltype.Items.Insert(0, "");
            ddltype.Text = "";

            introbl = new IntroductionListForCareer_BL();
            DataTable bindexpsalary = new DataTable();
            bindexpsalary = introbl.BindDDL();
            ddllexpectedsalarytype.DataSource = bindexpsalary;
            ddllexpectedsalarytype.DataTextField = "Description";
            ddllexpectedsalarytype.DataValueField = "ID";
            ddllexpectedsalarytype.DataBind();
            ddllexpectedsalarytype.ClearSelection();
            ddllexpectedsalarytype.Items.Insert(0, "");
            ddllexpectedsalarytype.Text = "";


        }

        public void SetIntialRow()
        {
            try
            {




                #region new
                DataTable dt = new DataTable();
                DataRow dr = null;
                //FOR GRIDVIEW
                dt.Columns.Add(new DataColumn("ID", typeof(string)));
                dt.Columns.Add(new DataColumn("Success_Worker_ID", typeof(int)));//kyan
                dt.Columns.Add(new DataColumn("Job_No", typeof(int)));
                dt.Columns.Add(new DataColumn("Company_Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Position", typeof(string)));
                dt.Columns.Add(new DataColumn("Introduction_Date", typeof(string)));
                dt.Columns.Add(new DataColumn("Sent_CV_Date", typeof(string)));
                dt.Columns.Add(new DataColumn("Expected_Salary", typeof(string)));
                dt.Columns.Add(new DataColumn("Salary_Type", typeof(string)));
                dt.Columns.Add(new DataColumn("Condition", typeof(string)));
                dt.Columns.Add(new DataColumn("NoticeType", typeof(string)));
                dt.Columns.Add(new DataColumn("Interview_Date", typeof(string)));
                dt.Columns.Add(new DataColumn("Interview_Time", typeof(string)));
                dt.Columns.Add(new DataColumn("Result", typeof(string)));
                dt.Columns.Add(new DataColumn("Salary_Hidden", typeof(int)));
                //dt.Columns.Add(new DataColumn("Interview_Date", typeof(string)));
                //For insert into database
                dt.Columns.Add(new DataColumn("companyID", typeof(int)));
                dt.Columns.Add(new DataColumn("positionID", typeof(int)));
                //dt.Columns.Add(new DataColumn("expected_Salarydb", typeof(int)));
                dt.Columns.Add(new DataColumn("expectedsalarytype", typeof(string)));
                dt.Columns.Add(new DataColumn("condition", typeof(string)));
                dt.Columns.Add(new DataColumn("noticetype", typeof(string)));
                dt.Columns.Add(new DataColumn("noticeday", typeof(string)));
                dt.Columns["ID"].AutoIncrement = true;
                dt.Columns["ID"].AutoIncrementStep = 1;
                dt.Columns["ID"].AutoIncrementSeed = 1;
                ViewState["DataTableColumn"] = dt;
                #endregion g
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnadd.Text == "Add")
                {
                    AddData();
                    gvintroduction.Visible = true;
                    if (Request.QueryString["ID"] == null)
                    {
                        btnsave.Visible = true;
                    }
                    else
                    {
                        UserRoleBL user = new UserRoleBL();
                        int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                        bool resultEdit = user.CanSave(userID, "058");
                        if (resultEdit)
                        {
                            btnsupdate.Visible = true;
                        }
                        else
                        {
                            btnsupdate.Visible = false;
                        }
                    }
                    //btnsupdate.Visible = true;
                    Clear();

                }
                else
                {
                    GridViewUpdateData();
                    gvintroduction.Visible = true;
                    btnsave.Visible = true;

                    btnadd.Text = "Add";
                    Clear();
                    if (Request.QueryString["ID"] == null)
                    {
                        btnsave.Enabled = true;
                    }
                    else
                    {
                        UserRoleBL user = new UserRoleBL();
                        int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                        bool resultEdit = user.CanSave(userID, "058");
                        if (resultEdit)
                        {
                            btnsave.Visible = false;
                            btnsupdate.Visible = true;
                            btnsupdate.Enabled = true;
                        }
                        else
                        {
                            btnsave.Visible = false;
                            btnsupdate.Visible = false;
                        }

                    }



                }
                Session["ID"] = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Clear()
        {
            txtName.Text = String.Empty;
            txtID.Text = string.Empty;
            txtJobNo.Text = string.Empty;
            ddlposition.SelectedIndex = 0;
            txtintro.Text = string.Empty;
            txtcv.Text = string.Empty;
            TextBox2.Text = string.Empty;
            ddllexpectedsalarytype.SelectedIndex = 0;
            ddlcondition.SelectedIndex = 0;
            txtinterviewdate.Text = string.Empty;
            txtresult.Text = string.Empty;
            chkimmediate.Checked = false;
            rdocheckimmediate.Checked = false;
            //rdocheckw.Checked = false;
            rdocheckm.Checked = false;
            txtnotice.Text = string.Empty;
            ddlmw.SelectedIndex = 0;
            ddlmw.Visible = false;
            txtnotice.Visible = false;
            chkimmediate.Visible = false;
            lblimmediate.Visible = false;
            ddlintreviewtimehour.SelectedIndex = 0;
            ddlinterviewtimeminute.SelectedIndex = 0;


        }

        public void AddData()
        {
            AddNewRowToGrid();
        }

        public DataTable createDtColumn
        {
            set { ViewState["DataTableColumn"] = value; }

            get
            {
                if (ViewState["DataTableColumn"] == null)

                    SetIntialRow();

                return (DataTable)ViewState["DataTableColumn"];



            }
        }

        public void AddNewRowToGrid()
        {
            try
            {

                #region new
                DataTable dt = createDtColumn;
                DataRow drrow = dt.NewRow();
                //ForGridview
                drrow["companyID"] = txtID.Text;
                drrow["Job_No"] = txtJobNo.Text;
                drrow["Company_Name"] = txtName.Text;
                drrow["Position"] = ddlposition.SelectedItem.Text;
                drrow["Introduction_Date"] = txtintro.Text;
                drrow["Sent_CV_Date"] = txtcv.Text;
                if (!String.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    drrow["Expected_Salary"] = Convert.ToInt32(TextBox2.Text) + ddllexpectedsalarytype.SelectedItem.Text;
                }
                else
                {
                    drrow["Expected_Salary"] = 0;
                }
                drrow["Salary_Type"] = ddllexpectedsalarytype.SelectedItem.Text;
                drrow["Condition"] = ddlcondition.SelectedItem.Text;

                if (!String.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    drrow["Salary_Hidden"] = Convert.ToInt32(TextBox2.Text);
                }
                else
                {
                    drrow["Salary_Hidden"] = 0;
                }
                if (check())
                {


                    drrow["NoticeType"] = txtnotice.Text + "-" + ddlmw.SelectedItem.Text;
                }
                else
                {
                    if (chkimmediate.Checked)
                        drrow["NoticeType"] = "immediate";
                    else
                        drrow["NoticeType"] = "";

                }
                drrow["Interview_Date"] = txtinterviewdate.Text;
                if (!String.IsNullOrWhiteSpace(ddlintreviewtimehour.SelectedValue) || !String.IsNullOrWhiteSpace(ddlinterviewtimeminute.SelectedValue))
                {
                    drrow["Interview_Time"] = ddlintreviewtimehour.SelectedValue + ":" + ddlinterviewtimeminute.SelectedValue;
                }
                drrow["Result"] = txtresult.Text;

                //For insert intodatabase

                if (!String.IsNullOrWhiteSpace(ddlposition.SelectedValue))
                {
                    drrow["positionID"] = ddlposition.SelectedValue;
                }



                //drrow["expected_Salarydb"] = Convert.ToInt32(TextBox2.Text);
                drrow["expectedsalarytype"] = ddllexpectedsalarytype.SelectedValue;
                drrow["condition"] = ddlcondition.SelectedValue;
                if (check())
                {

                    drrow["noticetype"] = ddlmw.SelectedItem.Value;
                    drrow["noticeday"] = txtnotice.Text;
                }
                else
                {
                    if (chkimmediate.Checked)
                    {

                        drrow["noticetype"] = 0;
                        drrow["noticeday"] = null;
                    }
                    else
                        drrow["noticetype"] = null;
                    drrow["noticeday"] = null;

                }
                dt.Rows.Add(drrow);
                //ViewState["CurretnAddRow"] = dt;
                //ViewState["EmpInfo"] = dt;
                //ViewState["GVPaing"] = dt;
                gvintroduction.DataSource = dt;
                gvintroduction.DataBind();

                #endregion




            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                introbl = new IntroductionListForCareer_BL();
                introentity = new IntroductionListForCareer_Entity();
                if (btnsave.Text == "Save")
                {
                    if (CheckEmployeeExist())
                    {
                        if (!string.IsNullOrWhiteSpace(txtID.Text))
                        {
                            introentity.Id = Convert.ToInt32(txtID.Text);
                        }
                        if (ddlemployeecode.Text == "")
                        {
                            introentity.Career_code = txtempcode.Text;
                        }
                        else
                        {
                            introentity.Career_code = ddlemployeecode.Text + "-" + txtempcode.Text;
                        }
                        if (!string.IsNullOrWhiteSpace(txtempname.Text))
                        {
                            introentity.Name = txtempname.Text;
                        }
                        if (!string.IsNullOrWhiteSpace(Request.Form[txtdate.UniqueID]))
                        {
                            string strDate1 = Request.Form[txtdate.UniqueID];
                            //DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                            //dtfi.ShortDatePattern = "dd-MM-yyyy";
                            //dtfi.DateSeparator = "-";
                            //DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                            string date1 = Convert.ToDateTime(strDate1, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                            introentity.Start_working_date = DateTime.ParseExact(date1, "MM/dd/yyyy ", null);
                        }
                        if (!string.IsNullOrWhiteSpace(txtsalary.Text))
                        {
                            introentity.Salary = Convert.ToInt32(txtsalary.Text);
                        }
                        if (!string.IsNullOrWhiteSpace(ddltype.SelectedItem.Value))
                        {
                            introentity.Salary_type = Convert.ToInt32(ddltype.SelectedItem.Value);
                        }
                        if (!string.IsNullOrWhiteSpace(chksing.Checked.ToString()))
                        {
                            introentity.Sign = chksing.Checked;
                        }

                        if (!String.IsNullOrWhiteSpace(ddlgender.Text))
                        {
                            introentity.Gender = Convert.ToInt32(ddlgender.SelectedItem.Value);
                        }
                        if (CheckUniqueID())
                        {
                            //int id = introbl.Insert_IntroductionList(introentity, 0);

                            //Insert(id);
                            DataTable dt = ViewState["DataTableColumn"] as DataTable;
                            introbl.Insert(introentity, dt);





                            //if (id != 0)
                            //{
                            string script = "window.onload = function(){ alert('";
                            script += "Insert Successfully";
                            script += "');";
                            script += "window.location = '";
                            //script += "IntroductionListFor_Career.aspx";
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                            //}

                        }
                        else
                        {
                            string script = "window.onload = function(){ alert('";
                            script += " Employee_Code Already Exist";
                            script += "');";
                            script += "window.location = '";
                            //script += "IntroductionListFor_Career.aspx";
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                        }
                    }
                    else
                    {
                        string script = "window.onload = function(){ alert('";
                        script += " This Employee is not in the Register!Check Employee Code ";
                        script += "');";
                        script += "window.location = '";
                        //script += "IntroductionListFor_Career.aspx";
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean CheckEmployeeExist()
        {
            introbl = new IntroductionListForCareer_BL();
            string code;
            if (ddlemployeecode.Text == "")
            {
                code = txtempcode.Text;
            }
            else
            {
                code = ddlemployeecode.Text + "-" + txtempcode.Text;
            }
            DataTable dtb = introbl.CheckEmployeeExist(code);
            if (dtb.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Insert(int id)
        {
            DataTable dt = new DataTable();
            if (btnadd.Text == "Add")
            {
                dt = ViewState["CurretnAddRow"] as DataTable;
            }
            else
            {
                dt = ViewState["Table"] as DataTable;
            }

            var rows = dt.Select("ID=0");
            foreach (var row in rows)
                row.Delete();
            //creditNew.Insert_Employee_Credit(creditentity, dt, id);
            introbl = new IntroductionListForCareer_BL();

            //introbl.Insert_IntroductionListForCompany(dt, id);
        }

        public void gv_edit(object sender, GridViewCommandEventArgs e)
        {
            introbl = new IntroductionListForCareer_BL();
            //GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            if (e.CommandArgument != null)
            {
                if (e.CommandName == "Detail Delete")
                {

                    int id = Convert.ToInt32(e.CommandArgument.ToString());

                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;
                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["DataTableColumn"];
                    DataRow[] drs = dt.Select("ID='" + id + "'");
                    foreach (DataRow dr in drs)
                    {
                        dr.Delete();

                    }

                    //dt.Rows[rowIndex].Delete();
                    //dt.Rows.RemoveAt(rowIndex);
                    //dt.AcceptChanges();
                    //Session["CurretnAddRow"] = dt;

                    gvintroduction.DataSource = dt;
                    gvintroduction.DataBind();
                    if (Request.QueryString["ID"] == null)
                    {
                        btnsupdate.Visible = false;
                    }
                    else
                    {
                        UserRoleBL user = new UserRoleBL();
                        int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                        bool resultEdit = user.CanSave(userID, "058");
                        if (resultEdit)
                        {
                            btnsupdate.Visible = true;
                        }
                        else
                        {
                            btnsupdate.Visible = false;
                        }
                    }
                }
                else if (e.CommandName == "Detail Edit")
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    hdfEID.Value = id.ToString();

                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gvr.RowIndex;

                    Label lbl1 = gvr.FindControl("lblemolyee_code") as Label;
                    Label lbl2 = gvr.FindControl("lblEmployeeName") as Label;
                    Label lbl3 = gvr.FindControl("lblsalary") as Label;
                    Label lbl4 = gvr.FindControl("lblstartworkingdate") as Label;
                    Label lbl5 = gvr.FindControl("lblcompanyname") as Label;
                    Label lbl6 = gvr.FindControl("lblemployee_no") as Label;
                    Label lbl7 = gvr.FindControl("lblpostiionID") as Label;
                    Label lbl8 = gvr.FindControl("lblintrodction_Date") as Label;
                    Label lbl9 = gvr.FindControl("lblsentcvdate") as Label;
                    Label lbl10 = gvr.FindControl("lblexpectedsalary") as Label;
                    Label lbl11 = gvr.FindControl("lblexpectedsalarytype") as Label;//
                    Label lbl12 = gvr.FindControl("lblcondition") as Label;
                    Label lbl13 = gvr.FindControl("lblnotice") as Label;

                    Label lbl14 = gvr.FindControl("lblinterviewdate") as Label;

                    Label lbl15 = gvr.FindControl("lblresult") as Label;

                    Label lbl16 = gvr.FindControl("lblCompanyID") as Label;
                    Label lbl17 = gvr.FindControl("lbldetailID") as Label;
                    Label lbl18 = gvr.FindControl("lblinterviewtime") as Label;
                    Label lbl19 = gvr.FindControl("lblsalaryhidden") as Label;//
                    //Label lbl16 = gvr.FindControl("sakartttyope") as Label;
                    //Label lbl17 = gvr.FindControl("lblnoticeday") as Label;



                    txtID.Text = lbl16.Text;
                    txtName.Text = lbl5.Text;
                    Session["ID"] = txtName.Text;
                    txtJobNo.Text = lbl6.Text;
                    lbldetailid.Text = lbl17.Text;
                    txtintro.Text = lbl8.Text;
                    txtcv.Text = lbl9.Text;
                    TextBox2.Text = lbl19.Text;
                    txtinterviewdate.Text = lbl14.Text;
                    txtresult.Text = lbl15.Text;
                    //if (lbl7.Text != String.Empty)
                    if (!String.IsNullOrWhiteSpace(lbl7.Text))
                    {
                        ddlposition.SelectedValue = lbl7.Text;
                    }
                    else
                    {
                        ddlposition.SelectedIndex = 0;
                    }

                    if (lbl12.Text == "Jobless")
                    {
                        ddlcondition.SelectedIndex = 1;

                    }
                    else if (lbl12.Text == "Still Working")
                    {

                        ddlcondition.SelectedIndex = 2;
                    }
                    else
                    {
                        ddlcondition.SelectedIndex = 0;
                    }
                    if (lbl11.Text == "KS")
                    {
                        ddllexpectedsalarytype.SelectedIndex = 1;
                    }
                    else if (lbl11.Text == "$")
                    {
                        ddllexpectedsalarytype.SelectedIndex = 2;
                    }
                    else
                    {
                        ddllexpectedsalarytype.SelectedIndex = 0;
                    }



                    //if (!String.IsNullOrWhiteSpace(lbl10.Text))
                    //{
                    //    if (lbl10.Text.Contains(" "))
                    //    {
                    //        string[] arrsalary = (lbl10.Text.Split(' '));
                    //        TextBox2.Text = arrsalary[0];
                    //        if (arrsalary[1] == "KS")
                    //        {
                    //            ddllexpectedsalarytype.SelectedIndex = 1;
                    //        }
                    //        else if (arrsalary[1] == "$")
                    //        {
                    //            ddllexpectedsalarytype.SelectedIndex = 2;
                    //        }
                    //        else
                    //        {
                    //            ddllexpectedsalarytype.SelectedIndex = 0;
                    //        }
                    //    }

                    //}
                    if (!String.IsNullOrWhiteSpace(lbl18.Text))
                    {
                        string[] time = (lbl18.Text.Split(':'));
                        ddlintreviewtimehour.SelectedValue = time[0];
                        ddlinterviewtimeminute.SelectedValue = time[1];
                    }

                    if (lbl13.Text == "immediate")
                    {
                        lblimmediate.Visible = true;
                        rdocheckimmediate.Checked = true;
                        chkimmediate.Checked = true;
                        chkimmediate.Visible = true;
                        txtnotice.Visible = false;
                        ddlmw.Visible = false;
                        txtnotice.Text = string.Empty;
                        ddlmw.SelectedIndex = 0;



                    }
                    //else if (lbl13.Text == "1" || lbl13.Text == "2")
                    else if (lbl13.Text.Contains("m") || lbl13.Text.Contains("w"))
                    {
                        if (lbl13.Text.Contains("m"))
                        {
                            rdocheckm.Checked = true;

                            string[] cut = (lbl13.Text.Split('-'));
                            txtnotice.Text = cut[0];
                            ddlmw.SelectedIndex = 1;
                            chkimmediate.Checked = false;
                            rdocheckimmediate.Checked = false;

                        }
                        else if (lbl13.Text.Contains("w"))
                        {

                            rdocheckm.Checked = true;
                            string[] cut = (lbl13.Text.Split('-'));
                            txtnotice.Text = cut[0];
                            ddlmw.SelectedIndex = 2;
                            chkimmediate.Checked = false;
                            rdocheckimmediate.Checked = false;

                        }

                        txtnotice.Visible = true;
                        ddlmw.Visible = true;
                        //rdomw.Visible = false;

                        chkimmediate.Checked = false;
                        lblimmediate.Visible = false;
                        chkimmediate.Visible = false;
                    }

                    else
                    {
                        lblimmediate.Visible = false;
                        rdocheckimmediate.Checked = false;
                        chkimmediate.Checked = false;
                        chkimmediate.Visible = false;
                        txtnotice.Visible = false;
                        ddlmw.Visible = false;
                    }



                    btnadd.Visible = true;
                    btnadd.Text = "Update";
                    gvintroduction.DataSource = ViewState["DataTableColumn"];

                    gvintroduction.DataBind();
                    btnsave.Enabled = false;
                    btnsupdate.Enabled = false;
                }
                else { }
            }
        }
        public void rdocheckchange(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            if (rdo.Text == "Immediate")
            {
                lblimmediate.Visible = true;
                chkimmediate.Visible = true;
                txtnotice.Visible = false;
                ddlmw.Visible = false;



            }

            else
            {

                txtnotice.Visible = true;
                ddlmw.Visible = true;
                lblimmediate.Visible = false;
                chkimmediate.Visible = false;


            }


        }
        public Boolean check()
        {
            if (rdocheckimmediate.Checked)
            {

                return false;

            }
            else
            {


                return true;
            }
        }


        public void gvintroduction_rowDataBound(Object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (DataBinder.Eval(e.Row.DataItem, "ID").ToString().Equals("0"))
            //    {
            //        e.Row.Visible = false;
            //    }
            //}


        }

        protected void btnsupdate_Click(object sender, EventArgs e)
        {

            IntroductionListForCareer_BL introbl = new IntroductionListForCareer_BL();
            IntroductionListForCareer_Entity introentity = new IntroductionListForCareer_Entity();
            if (CheckEmployeeExist())
            {
                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    introentity.Id = Convert.ToInt32(txtID.Text);
                }
                if (ddlemployeecode.Text == "")
                {
                    introentity.Career_code = txtempcode.Text;
                }
                else
                {
                    introentity.Career_code = ddlemployeecode.Text + "-" + txtempcode.Text;
                }
                if (!string.IsNullOrWhiteSpace(txtempname.Text))
                {
                    introentity.Name = txtempname.Text;
                }
                if (!String.IsNullOrWhiteSpace(ddlgender.Text))
                {
                    introentity.Gender = Convert.ToInt32(ddlgender.SelectedItem.Value);
                }
                if (!string.IsNullOrWhiteSpace(Request.Form[txtdate.UniqueID]))
                {
                    string strDate1 = Request.Form[txtdate.UniqueID];
                    //DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    //dtfi.ShortDatePattern = "dd-MM-yyyy";
                    //dtfi.DateSeparator = "-";
                    //DateTime objDate = Convert.ToDateTime(strDate, dtfi);
                    string date1 = Convert.ToDateTime(strDate1, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                    introentity.Start_working_date = DateTime.ParseExact(date1, "MM/dd/yyyy ", null);
                }
                if (!string.IsNullOrWhiteSpace(txtsalary.Text))
                {
                    introentity.Salary = Convert.ToInt32(txtsalary.Text);
                }
                if (!string.IsNullOrWhiteSpace(ddltype.SelectedItem.Value))
                {
                    introentity.Salary_type = Convert.ToInt32(ddltype.SelectedItem.Value);
                }
                if (!string.IsNullOrWhiteSpace(chksing.Checked.ToString()))
                {
                    introentity.Sign = chksing.Checked;
                }
                #region old

                //if (!String.IsNullOrWhiteSpace(txtJobNo.Text))
                //{
                //    introentity.JobNo = Convert.ToInt32(txtJobNo.Text);
                //}
                //if (!String.IsNullOrWhiteSpace(txtID.Text))
                //{
                //    introentity.Company_ID = Convert.ToInt32(txtID.Text);
                //}
                //if (!String.IsNullOrWhiteSpace(ddlposition.Text))
                //{
                //    introentity.Position_ID = BaseLib.Convert_Int(ddlposition.SelectedValue);
                //}
                //if (!String.IsNullOrWhiteSpace(txtintro.Text))
                //{
                //    introentity.Introductiondate = Convert.ToDateTime(txtintro.Text);
                //}
                //if (!String.IsNullOrWhiteSpace(txtcv.Text))
                //{
                //    introentity.Sendcvdate = Convert.ToDateTime(txtcv.Text);
                //}
                //if (!String.IsNullOrWhiteSpace(TextBox2.Text))
                //{
                //    introentity.Expectedsalary = Convert.ToInt32(TextBox2.Text);
                //}
                //if (!string.IsNullOrWhiteSpace(ddllexpectedsalarytype.Text))
                //{
                //    introentity.Expectedsalarytype = BaseLib.Convert_Int(ddllexpectedsalarytype.SelectedValue);
                //}
                //if (!string.IsNullOrWhiteSpace(ddlcondition.Text))
                //{
                //    introentity.Situation = BaseLib.Convert_Int(ddlcondition.SelectedValue);
                //}

                //if (updatecheck()==1)
                //{
                //    if (!String.IsNullOrWhiteSpace(ddlmw.Text))
                //    {
                //        introentity.Notice_type = Convert.ToInt32(ddlmw.SelectedItem.Value);
                //    }
                //    if (!string.IsNullOrWhiteSpace(txtnotice.Text))
                //    {
                //        introentity.NoticeDay = txtnotice.Text;
                //    }
                //}
                //else if (updatecheck() == 2)
                //{

                //    introentity.Notice_type = 0;
                //    introentity.NoticeDay = null;
                //}
                //else
                //{
                //    introentity.Notice_type = null;
                //    introentity.NoticeDay = null;

                //}
                //if (!String.IsNullOrWhiteSpace(txtinterviewdate.Text))
                //{
                //    introentity.InterviewDate = Convert.ToDateTime(txtinterviewdate.Text);
                //}
                //if (!String.IsNullOrWhiteSpace(txtresult.Text))
                //{
                //    introentity.Result = txtresult.Text;
                //}
                #endregion
                int successworkerid = int.Parse(Request.QueryString["ID"]);
                introentity.SuccessworkerID = successworkerid;

                //introbl.UpdateEmployeeInfo(lblinfoid.Text, introentity);
                //introbl.UpdateEmployeeDetail(introentity);
                #region new
                DataTable dtemployeedetail = createDtColumn;
                introbl.Update(introentity, dtemployeedetail);
                //gvintroduction.DataSource = dtemployeedetail;
                //gvintroduction.DataBind();
                #endregion




                string script = "window.onload = function(){ alert('";
                script += "Update Successfully";
                script += "');";
                script += "window.location = '";
                //script += "IntroductionListForCareer_GoDetail.aspx";
                //script += "IntroductionForCareer_View.aspx?ID=" + Convert.ToInt32(lblinfoid.Text);
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

            }

            else
            {

                string script = "window.onload = function(){ alert('";
                script += " This Employee is not in the Register!Check Employee Code ";
                script += "');";
                script += "window.location = '";
                //script += "IntroductionListFor_Career.aspx";
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

            }
        }
        public Boolean CheckUniqueID()
        {
            introbl = new IntroductionListForCareer_BL();
            string code = ddlemployeecode.Text + "-" + txtempcode.Text;
            DataTable dtemployeecode = introbl.CheckUniqueID(code);
            if (dtemployeecode.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }
        public void GridViewUpdateData()
        {
            try
            {


                int eid = Convert.ToInt32(hdfEID.Value);
                DataTable dt = ViewState["DataTableColumn"] as DataTable;
                DataRow[] drs = dt.Select("ID='" + eid + "'");
                foreach (DataRow dr in drs)
                {
                    dr["Job_No"] = txtJobNo.Text;
                    dr["Company_Name"] = txtName.Text;
                    dr["Position"] = ddlposition.SelectedItem.Text;
                    dr["Introduction_Date"] = txtintro.Text;
                    dr["Sent_CV_Date"] = txtcv.Text;
                    if (!String.IsNullOrWhiteSpace(dr["Expected_Salary"].ToString()) && TextBox2.Text == "")
                    {
                        dr["Expected_Salary"] = 0;
                    }
                    else if (!String.IsNullOrWhiteSpace(dr["Expected_Salary"].ToString()))
                    {
                        dr["Expected_Salary"] = TextBox2.Text + ddllexpectedsalarytype.SelectedItem.Text;
                    }
                    else { }

                    if (!String.IsNullOrWhiteSpace(dr["Salary_Hidden"].ToString()) && TextBox2.Text == "")
                    {
                        dr["Salary_Hidden"] = 0;
                    }
                    else if (!String.IsNullOrWhiteSpace(dr["Salary_Hidden"].ToString()))
                    {
                        dr["Salary_Hidden"] = TextBox2.Text;
                    }
                    else { }

                    dr["Salary_Type"] = ddllexpectedsalarytype.SelectedItem.Text;
                    dr["Condition"] = ddlcondition.SelectedItem.Text;
                    if (check())
                    {


                        dr["NoticeType"] = txtnotice.Text + "-" + ddlmw.SelectedItem.Text;

                    }
                    else
                    {

                        if (chkimmediate.Checked)
                        {
                            dr["NoticeType"] = "immediate";
                        }
                        else
                        {
                            dr["NoticeType"] = "";
                        }
                    }
                    dr["Interview_Date"] = txtinterviewdate.Text;
                    if (!String.IsNullOrWhiteSpace(ddlintreviewtimehour.SelectedValue) || !String.IsNullOrWhiteSpace(ddlinterviewtimeminute.SelectedValue))
                    {

                        dr["Interview_Time"] = ddlintreviewtimehour.SelectedValue + ":" + ddlinterviewtimeminute.SelectedValue;

                    }
                    else
                    {
                        dr["Interview_Time"] = null;
                    }




                    dr["Result"] = txtresult.Text;

                    //For insert intodatabase
                    dr["companyID"] = txtID.Text; ;

                    dr["positionID"] = ddlposition.SelectedValue;




                    //if (!String.IsNullOrWhiteSpace(dr["expected_Salarydb"].ToString()) && TextBox2.Text == "")
                    //{
                    //    dr["expected_Salarydb"] = 0;
                    //}
                    //else if (!String.IsNullOrWhiteSpace(dr["expected_Salarydb"].ToString()))
                    //{
                    //    dr["expected_Salarydb"] = TextBox2.Text;
                    //}
                    //else { }

                    //dr["expected_Salarydb"] = TextBox2.Text;
                    dr["expectedsalarytype"] = ddllexpectedsalarytype.SelectedValue;
                    dr["condition"] = ddlcondition.SelectedValue;
                    if (check())
                    {

                        dr["noticetype"] = ddlmw.SelectedItem.Value;
                        dr["noticeday"] = txtnotice.Text;
                    }
                    else
                    {
                        if (chkimmediate.Checked)
                        {
                            dr["noticetype"] = 0;
                            dr["noticeday"] = null;
                        }
                        else
                        {
                            dr["noticetype"] = null;
                            dr["noticeday"] = null;
                        }
                    }
                    ViewState["CurretnAddRow"] = dt;
                    gvintroduction.DataSource = dt;
                    gvintroduction.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Come from view form


        public void FillData(DataTable dtbfill)
        {

            if (!String.IsNullOrWhiteSpace(dtbfill.Rows[0]["Carrer_Code"].ToString()))
            {
                string[] str = dtbfill.Rows[0]["Carrer_Code"].ToString().Split('-');
                if (str.Length == 2)
                {
                    if (ddlemployeecode.Items.FindByText(str[0]) != null)
                    {
                        ddlemployeecode.ClearSelection();
                        ddlemployeecode.Items.FindByText(str[0]).Selected = true;
                    }
                    txtempcode.Text = str[1];
                }
                else
                {
                    txtempcode.Text = str[0];
                }

            }

            if (!String.IsNullOrWhiteSpace(dtbfill.Rows[0]["Name"].ToString()))
            {
                txtempname.Text = dtbfill.Rows[0]["Name"].ToString();
            }

            if (ddlgender.Items.FindByText(dtbfill.Rows[0]["gender"].ToString()) != null)
            {
                ddlgender.ClearSelection();
                ddlgender.Items.FindByText(dtbfill.Rows[0]["gender"].ToString()).Selected = true;
            }

            if (!String.IsNullOrWhiteSpace(dtbfill.Rows[0]["Salary"].ToString()))
            {
                txtsalary.Text = dtbfill.Rows[0]["Salary"].ToString();
            }
            if (ddltype.Items.FindByText(dtbfill.Rows[0]["SalaryType"].ToString()) != null)
            {
                ddltype.ClearSelection();
                ddltype.Items.FindByText(dtbfill.Rows[0]["SalaryType"].ToString()).Selected = true;
            }
            if (!String.IsNullOrWhiteSpace(dtbfill.Rows[0]["Start_Working_Date"].ToString()))
            {
                DateTime date = (DateTime)dtbfill.Rows[0]["Start_Working_Date"];
                txtdate.Text = Convert.ToDateTime(date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd");
            }
            if (Convert.ToBoolean(dtbfill.Rows[0]["Sign"].ToString()) == true)
            {
                chksing.Checked = true;
            }
            else
            {
                chksing.Checked = false;
            }
        }

        public void BindDataForGridView(int id)
        {
            gvintroduction.Visible = true;
            DataTable dtb = new DataTable();
            //dtb = introbl.GetDataForGirdview(id);

            createDtColumn.Merge(introbl.GetDataForGirdview(id));

            gvintroduction.DataSource = createDtColumn;
            gvintroduction.DataBind();

        }
        #endregion

        public void gvintroductionpageindexchage(object sender, GridViewPageEventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                DataTable dt = ViewState["DataTableColumn"] as DataTable;
                gvintroduction.DataSource = dt;
                gvintroduction.PageIndex = e.NewPageIndex;
                gvintroduction.DataBind();
            }
            else
            {
                //DataTable dtb = ViewState["GVPaing"] as DataTable;
                DataTable dtb = createDtColumn;
                gvintroduction.DataSource = dtb;
                gvintroduction.PageIndex = e.NewPageIndex;
                gvintroduction.DataBind();
            }
        }

    }
}