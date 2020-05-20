using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_BL;
using JSAT_BL.Employee;
using JSAT_Common;
using JSAT_Common.Employee;
using JSAT_Ver1;

namespace JSAT.Employee
{
    public partial class WorkingHistory : System.Web.UI.Page
    {
        Working_History_BL webbl;
        BaseLib bb;
        WorkingHistoryEntity webentity;
        int count;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDate();
            if (!IsPostBack)
            {
                UserRoleBL user = new UserRoleBL();
                int userID = BaseLib.Convert_Int(Session["UserID"].ToString());
                bool resultRead = user.CanRead(userID, "055");
                if (resultRead)
                {
                    Button1.Visible = false;
                    btndelete.Visible = false;
                }
                bool resultDelete = user.CanDelete(userID, "055");
                if (resultDelete && !String.IsNullOrWhiteSpace(Request.QueryString["ID"]))
                    btndelete.Visible = true;
                else
                    btndelete.Visible = false;

                bool resultEdit = user.CanSave(userID, "055");
                if (resultEdit)
                    Button1.Visible = true;
                else
                    Button1.Visible = false;
                fillData();

                ViewState["PreviousTable"] = null;
                SetInitialRow();
                if (Request.QueryString["Career_ID"] != null)
                {
                    try
                    {
                        int careerid = int.Parse(Request.QueryString["Career_ID"]);
                        DataTable dtb = new DataTable();
                        Working_History_BL workbl = new Working_History_BL();
                        dtb = workbl.Selectforedit(careerid);
                        if (dtb.Rows.Count > 0)
                        {
                            Button1.Text = "Update";
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Career_Code"].ToString()))
                            {
                                string[] str = dtb.Rows[0]["Career_Code"].ToString().Split('-');
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
                            if (ddlfirsint.Items.FindByValue(dtb.Rows[0]["FirstInterviewer"].ToString()) != null)
                            {
                                ddlfirsint.ClearSelection();
                                ddlfirsint.Items.FindByValue(dtb.Rows[0]["FirstInterviewer"].ToString()).Selected = true;
                            }
                            if (ddlsecondint.Items.FindByValue(dtb.Rows[0]["SecondInterviewer"].ToString()) != null)
                            {
                                ddlsecondint.ClearSelection();
                                ddlsecondint.Items.FindByValue(dtb.Rows[0]["SecondInterviewer"].ToString()).Selected = true;
                            }
                            if (ddljapan.Items.FindByValue(dtb.Rows[0]["JapaneseInterviewer"].ToString()) != null)
                            {
                                ddljapan.ClearSelection();
                                ddljapan.Items.FindByValue(dtb.Rows[0]["JapaneseInterviewer"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["SalaryID"].ToString()))
                            {
                                salaryID.Text = dtb.Rows[0]["SalaryID"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Gender"].ToString()))
                            {
                                if (dtb.Rows[0]["Gender"].ToString() == "1")
                                {
                                    male.Checked = true;
                                }
                                else
                                {
                                    female.Checked = true;
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Name"].ToString()))
                            {
                                txtname.Text = dtb.Rows[0]["Name"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Age"].ToString()))
                            {
                                txtage.Text = dtb.Rows[0]["Age"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Interview_Date"].ToString()))
                            {
                                DateTime date = (DateTime)dtb.Rows[0]["Interview_Date"];
                                txtdate.Text = Convert.ToDateTime(date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd");
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["UpdatedDate"].ToString()))
                            {
                                DateTime? updatedate = (DateTime)dtb.Rows[0]["UpdatedDate"];
                                txtupdatedate.Text = Convert.ToDateTime(updatedate.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd");
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Driving_License"].ToString()))
                            {
                                if (dtb.Rows[0]["Driving_License"].ToString() == "True")
                                {
                                    rdoAvaliable.Checked = true;
                                }
                                else
                                {
                                    rdoNot.Checked = true;
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Address"].ToString()))
                            {
                                lblfilladdress.Text = dtb.Rows[0]["Address"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_Experience"].ToString()))
                            {
                                if (dtb.Rows[0]["Working_Experience"].ToString() == "True")
                                {
                                    rdoexperience.Items[0].Selected = true;
                                }
                                else
                                {
                                    rdoexperience.Items[1].Selected = true;
                                }
                            }
                            if (rdostatus.Items.FindByText(dtb.Rows[0]["Career_Status"].ToString()) != null)
                            {
                                rdostatus.Items.FindByText(dtb.Rows[0]["Career_Status"].ToString()).Selected = true;
                            }
                            if (ddlpositionrequsted.Items.FindByText(dtb.Rows[0]["Positionrequested"].ToString()) != null)
                            {
                                ddlpositionrequsted.ClearSelection();
                                ddlpositionrequsted.Items.FindByText(dtb.Rows[0]["Positionrequested"].ToString()).Selected = true;
                            }
                            if (ddlpositionrequested1.Items.FindByText(dtb.Rows[0]["Positionrequested1"].ToString()) != null)
                            {
                                ddlpositionrequested1.ClearSelection();
                                ddlpositionrequested1.Items.FindByText(dtb.Rows[0]["Positionrequested1"].ToString()).Selected = true;
                            }
                            if (ddlpositionrequested2.Items.FindByText(dtb.Rows[0]["Positionrequested2"].ToString()) != null)
                            {
                                ddlpositionrequested2.ClearSelection();
                                ddlpositionrequested2.Items.FindByText(dtb.Rows[0]["Positionrequested2"].ToString()).Selected = true;
                            }
                            if (ddlpositionlevel1.Items.FindByText(dtb.Rows[0]["Positionlevel1"].ToString()) != null)
                            {
                                ddlpositionlevel1.ClearSelection();
                                ddlpositionlevel1.Items.FindByText(dtb.Rows[0]["Positionlevel1"].ToString()).Selected = true;
                            }
                            if (ddlpositionlevel2.Items.FindByText(dtb.Rows[0]["Positionlevel2"].ToString()) != null)
                            {
                                ddlpositionlevel2.ClearSelection();
                                ddlpositionlevel2.Items.FindByText(dtb.Rows[0]["Positionlevel2"].ToString()).Selected = true;
                            }
                            if (ddlpositionlevel3.Items.FindByText(dtb.Rows[0]["Positionlevel3"].ToString()) != null)
                            {
                                ddlpositionlevel3.ClearSelection();
                                ddlpositionlevel3.Items.FindByText(dtb.Rows[0]["Positionlevel3"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Career_Salary"].ToString()))
                            {
                                txtexpectedsalary.Text = dtb.Rows[0]["Career_Salary"].ToString();
                            }
                            if (ddlsalarytype.Items.FindByText(dtb.Rows[0]["Career_Salary_Type"].ToString()) != null)
                            {
                                ddlsalarytype.ClearSelection();
                                ddlsalarytype.Items.FindByText(dtb.Rows[0]["Career_Salary_Type"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_On_Saturday"].ToString()))
                            {
                                if (dtb.Rows[0]["Working_On_Saturday"].ToString() == "True")
                                {
                                    rdosatyes.Checked = true;
                                }
                                else
                                {
                                    rdosatno.Checked = true;
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Saturday_Condition"].ToString()))
                            {
                                ddlsatdaycondition.ClearSelection();
                                ddlsatdaycondition.SelectedValue = dtb.Rows[0]["Saturday_Condition"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["NoticeType"].ToString()))
                            {
                                if (dtb.Rows[0]["NoticeType"].ToString() == "Immediate")
                                {
                                    rdocheckimmediate.Checked = true;
                                }
                                else
                                {
                                    txtnoticeday.Visible = true;
                                    ddlnoticetype.Visible = true;
                                    rdocheckm.Checked = true;
                                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Notice_Day"].ToString()))
                                    {
                                        txtnoticeday.Text = dtb.Rows[0]["Notice_Day"].ToString();
                                    }
                                    if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["NoticeType"].ToString()))
                                    {
                                        ddlnoticetype.ClearSelection();
                                        ddlnoticetype.Items.FindByText(dtb.Rows[0]["NoticeType"].ToString()).Selected = true;
                                    }
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Other_Qualification"].ToString()))
                            {
                                txtqualification.Text = dtb.Rows[0]["Other_Qualification"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Impression"].ToString()))
                            {
                                txtimpression.Text = dtb.Rows[0]["Impression"].ToString();
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Updating_Info"].ToString()))
                            {
                                txtupdateinfo.Text = dtb.Rows[0]["Updating_Info"].ToString();
                            }
                            lblid.Text = dtb.Rows[0]["ID"].ToString();
                            txtTotalMark.Text = dtb.Rows[0]["Total_Marks"].ToString();
                            EditData(dtb);
                            DataTable dtbindpcskil = new DataTable();
                            webbl = new Working_History_BL();
                            dtbindpcskil = webbl.SelectedbyIDforpcskill(careerid);
                            for (int i = 0; i < dtbindpcskil.Rows.Count; i++)
                            {
                                if (chkPcSkill.Items.FindByText(dtbindpcskil.Rows[i]["PCSkills"].ToString()) != null)
                                {
                                    chkPcSkill.Items.FindByText(dtbindpcskil.Rows[i]["PCSkills"].ToString()).Selected = true;
                                }
                            }

                            Qualification_SelectedByID(careerid);
                            Ability_SelectedByID(careerid);
                            DataTable dtbindlocation = webbl.SelectbyIDForLocation(careerid);
                            for (int i = 0; i < dtbindlocation.Rows.Count; i++)
                            {
                                if (chklocationrequested.Items.FindByText(dtbindlocation.Rows[i]["LocationRequest"].ToString()) != null)
                                {
                                    chklocationrequested.Items.FindByText(dtbindlocation.Rows[i]["LocationRequest"].ToString()).Selected = true;
                                }
                            }
                            if (Convert.ToInt16(dtb.Rows[0]["Thilawa"]) != 0)
                            {
                                chkthilawa.Items.FindByValue(dtb.Rows[0]["Thilawa"].ToString()).Selected = true;
                            }
                            if (Convert.ToInt16(dtb.Rows[0]["Hlaing_Thar_Yar"]) != 0)
                            {
                                chkhty.Items.FindByValue(dtb.Rows[0]["Hlaing_Thar_Yar"].ToString()).Selected = true;
                            }
                            if (Convert.ToInt16(dtb.Rows[0]["Oversea"]) != 0)
                            {
                                chkoversea.Items.FindByValue(dtb.Rows[0]["Oversea"].ToString()).Selected = true;
                            }
                            if (Convert.ToInt16(dtb.Rows[0]["Overseatraining"]) != 0)
                            {
                                chkoverseatraining.Items.FindByValue(dtb.Rows[0]["Overseatraining"].ToString()).Selected = true;
                            }
                            DataTable dtbbindpersonalskill = new DataTable();
                            dtbbindpersonalskill = webbl.SelectedbyIDforpersonalskill(careerid);
                            for (int i = 0; i < dtbbindpersonalskill.Rows.Count; i++)
                            {
                                if (chkpersonalskill.Items.FindByValue(dtbbindpersonalskill.Rows[i]["Skill_Type"].ToString()) != null)
                                {
                                    chkpersonalskill.Items.FindByValue(dtbbindpersonalskill.Rows[i]["Skill_Type"].ToString()).Selected = true;
                                }
                            }
                            if (ddldegree1.Items.FindByText(dtb.Rows[0]["Degree1"].ToString()) != null)
                            {
                                ddldegree1.ClearSelection();
                                ddldegree1.Items.FindByText(dtb.Rows[0]["Degree1"].ToString()).Selected = true;
                            }
                            if (ddluniversity1.Items.FindByText(dtb.Rows[0]["University1"].ToString()) != null)
                            {
                                ddluniversity1.ClearSelection();
                                ddluniversity1.Items.FindByText(dtb.Rows[0]["University1"].ToString()).Selected = true;
                                DataTable dtbtownship = new DataTable();
                                webbl = new Working_History_BL();
                                dtbtownship = webbl.SelectedbyUniversityID(BaseLib.Convert_Int(ddluniversity1.SelectedValue));
                                ddltownship1.DataSource = dtbtownship;
                                ddltownship1.DataTextField = "AreaDescription";
                                ddltownship1.DataValueField = "AreaID";
                                ddltownship1.DataBind();
                                ddltownship1.Focus();
                            }
                            if (ddltownship1.Items.FindByText(dtb.Rows[0]["Instituation_Area1"].ToString()) != null)
                            {
                                ddltownship1.ClearSelection();
                                ddltownship1.Items.FindByText(dtb.Rows[0]["Instituation_Area1"].ToString()).Selected = true;

                            }
                            if (ddlmajor1.Items.FindByText(dtb.Rows[0]["Major1"].ToString()) != null)
                            {
                                ddlmajor1.ClearSelection();
                                ddlmajor1.Items.FindByText(dtb.Rows[0]["Major1"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Year1"].ToString()))
                            {
                                txtyear1.Text = dtb.Rows[0]["Year1"].ToString();
                            }
                            if (ddldegree2.Items.FindByText(dtb.Rows[0]["Degree2"].ToString()) != null)
                            {
                                ddldegree2.ClearSelection();
                                ddldegree2.Items.FindByText(dtb.Rows[0]["Degree2"].ToString()).Selected = true;
                            }
                            if (ddluniversity2.Items.FindByText(dtb.Rows[0]["University2"].ToString()) != null)
                            {
                                ddluniversity2.ClearSelection();
                                ddluniversity2.Items.FindByText(dtb.Rows[0]["University2"].ToString()).Selected = true;
                                DataTable dtbtownship2 = new DataTable();
                                webbl = new Working_History_BL();
                                dtbtownship2 = webbl.SelectedbyUniversityID(BaseLib.Convert_Int(ddluniversity2.SelectedValue));
                                ddltownship2.DataSource = dtbtownship2;
                                ddltownship2.DataTextField = "AreaDescription";
                                ddltownship2.DataValueField = "AreaID";
                                ddltownship2.DataBind();
                                ddltownship2.Focus();
                            }
                            if (ddltownship2.Items.FindByText(dtb.Rows[0]["Instituation_Area2"].ToString()) != null)
                            {
                                ddltownship2.ClearSelection();
                                ddltownship2.Items.FindByText(dtb.Rows[0]["Instituation_Area2"].ToString()).Selected = true;

                            }
                            if (ddlmajor2.Items.FindByText(dtb.Rows[0]["Major2"].ToString()) != null)
                            {
                                ddlmajor2.ClearSelection();
                                ddlmajor2.Items.FindByText(dtb.Rows[0]["Major2"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Year2"].ToString()))
                            {
                                txtyear2.Text = dtb.Rows[0]["Year2"].ToString();
                            }
                            DataTable bindoldjobhistory = new DataTable();
                            bindoldjobhistory = webbl.SelectedbyOldjobhistory(careerid);
                            FillDataInTextboxforOldjobhistory(bindoldjobhistory);
                            if (resultDelete)
                                btndelete.Visible = true;
                            else btndelete.Visible = false;
                            if (Button1.Text == "Update")
                            {
                                Button1.Enabled = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            if (rdosatyes.Checked)
            {
                ddlsatdaycondition.Visible = true;
            }
            if (rdocheckm.Checked)
            {
                txtnoticeday.Visible = true;
                ddlnoticetype.Visible = true;
            }
        }

        protected void BindDate()
        {
            foreach (GridViewRow rowdata in Gridview1.Rows)
            {
                TextBox fromdate = rowdata.FindControl("txtFromDate") as TextBox;
                TextBox todate = rowdata.FindControl("txtToDate") as TextBox;
                if (!String.IsNullOrWhiteSpace(Request.Form[fromdate.UniqueID]))
                {
                    string strDate = Request.Form[fromdate.UniqueID];
                    string date2 = Convert.ToDateTime(strDate, CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd ");
                    fromdate.Text = date2;
                }
                if (!String.IsNullOrWhiteSpace(Request.Form[todate.UniqueID]))
                {
                    string strToDate = Request.Form[todate.UniqueID];
                    string date3 = Convert.ToDateTime(strToDate, CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd");
                    todate.Text = date3;
                }
            }
        }

        protected void Qualification_SelectedByID(int careerid)
        {
            Career_QualificationBL cqbl = new Career_QualificationBL();
            DataTable dtbindqual = cqbl.SelectByID(careerid);
            int itemCount1 = 0;

            for (int i = 0; i < dtbindqual.Rows.Count; i++)
            {
                for (itemCount1 = 0; itemCount1 < outerDataList.Items.Count; itemCount1++)
                {

                    DataList childdl = outerDataList.Items[itemCount1].FindControl("innerDataList") as System.Web.UI.WebControls.DataList;
                    foreach (DataListItem dl in childdl.Items)
                    {
                        CheckBox chkQ = (CheckBox)dl.FindControl("chkQ");
                        if ((chkQ.Text).ToString() == dtbindqual.Rows[i]["Qualification"].ToString())
                        {
                            chkQ.Checked = true;
                        }
                    }

                }
            }
        }

        protected void Ability_SelectedByID(int careerid)
        {
            Career_AbilityBL cabl = new Career_AbilityBL();
            DataTable dtbindqual = cabl.SelectByID(careerid);
            int itemCount1 = 0;
            for (int i = 0; i < dtbindqual.Rows.Count; i++)
            {
                for (itemCount1 = 0; itemCount1 < outerDataList1.Items.Count; itemCount1++)
                {
                    DataList childdl1 = outerDataList1.Items[itemCount1].FindControl("innerDataList1") as System.Web.UI.WebControls.DataList;
                    foreach (DataListItem dl in childdl1.Items)
                    {
                        CheckBox chkAbl = (CheckBox)dl.FindControl("chkAbl");
                        if ((chkAbl.Text).ToString() == dtbindqual.Rows[i]["Ability"].ToString())
                        {
                            chkAbl.Checked = true;
                        }
                    }
                }
            }
        }

        public void FillDataInTextboxforOldjobhistory(DataTable bindoldjobhistory)
        {
            try
            {
                GlobalBL global = new GlobalBL();
                Working_History_BL workbl = new Working_History_BL();
                if (bindoldjobhistory != null && bindoldjobhistory.Rows.Count > 0)
                {
                    int rowIndex = 0;
                    if (bindoldjobhistory.Rows.Count > 0)
                    {
                        Gridview1.DataSource = bindoldjobhistory;
                        Gridview1.DataBind();
                        foreach (GridViewRow row in Gridview1.Rows)
                        {
                            TextBox TextBox1 = row.FindControl("txtcompanyname") as TextBox;
                            TextBox TextBox2 = row.FindControl("txtcomapnyaddress") as TextBox;
                            TextBox TextBox3 = row.FindControl("txtFromDate") as TextBox;
                            TextBox TextBox4 = row.FindControl("txtToDate") as TextBox;
                            TextBox TextBox6 = row.FindControl("txtreasonforleaving") as TextBox;
                            TextBox TextBox7 = row.FindControl("txtother") as TextBox;
                            Label lbl1 = (Label)row.FindControl("lblotherjp") as Label;
                            Label lbl2 = (Label)row.FindControl("lblreasonforleavingjp") as Label;
                            DropDownList ddlIndustry = row.FindControl("ddlindustrytype") as DropDownList;
                            DropDownList ddlbusiness = row.FindControl("ddltypeofbusiness") as DropDownList;
                            DropDownList ddldepartment = row.FindControl("ddldepartment") as DropDownList;
                            DropDownList ddlposition = row.FindControl("ddlPosition") as DropDownList;
                            DropDownList ddlpositonlevel = row.FindControl("ddlpositionlevel") as DropDownList;
                            DropDownList ddlcompanytype = row.FindControl("ddlcompanytype") as DropDownList;
                            DropDownList ddlcountry = row.FindControl("ddlcountry") as DropDownList;
                            CheckBoxList chkjobdescription = row.FindControl("chkjobdescription") as CheckBoxList;
                            TextBox1.Text = bindoldjobhistory.Rows[rowIndex]["Company_Name"].ToString();
                            TextBox2.Text = bindoldjobhistory.Rows[rowIndex]["Company_Address"].ToString();
                            TextBox3.Text = bindoldjobhistory.Rows[rowIndex]["Duration_From"].ToString();
                            TextBox4.Text = bindoldjobhistory.Rows[rowIndex]["Duration_To"].ToString();
                            TextBox6.Text = bindoldjobhistory.Rows[rowIndex]["Reason_For_Leaving"].ToString();
                            TextBox7.Text = bindoldjobhistory.Rows[rowIndex]["Other"].ToString();
                            lbl1.Text = bindoldjobhistory.Rows[rowIndex]["Other_Japan"].ToString();
                            lbl2.Text = bindoldjobhistory.Rows[rowIndex]["Reason_For_Leaving_Japan"].ToString();
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Position_Level"].ToString()))
                            {
                                ddlpositonlevel.ClearSelection();
                                ddlpositonlevel.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Position_Level"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Company_Type"].ToString()))
                            {
                                ddlcompanytype.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Company_Type"].ToString()).Selected = true;
                                DataTable dtb = new DataTable();
                                BusinessTypeBL bussinessbl = new BusinessTypeBL();
                                dtb = bussinessbl.Selectedbycompanytype(BaseLib.Convert_Int(ddlcompanytype.SelectedValue));
                                ddlcountry.DataSource = dtb;
                                ddlcountry.DataTextField = "Description";
                                ddlcountry.DataValueField = "ID";
                                ddlcountry.DataBind();
                                ddlcountry.Focus();
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Country"].ToString()))
                            {
                                ddlcountry.ClearSelection();
                                ddlcountry.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Country"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Industry"].ToString()))
                            {
                                ddlIndustry.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Industry"].ToString()).Selected = true;
                                DataTable dtb = new DataTable();
                                BusinessTypeBL bussinessbl = new BusinessTypeBL();
                                dtb = bussinessbl.SelectedbyTypeofBusiness(BaseLib.Convert_Int(ddlIndustry.SelectedValue));
                                ddlbusiness.DataSource = dtb;
                                ddlbusiness.DataTextField = "Description";
                                ddlbusiness.DataValueField = "ID";
                                ddlbusiness.DataBind();
                                ddlbusiness.Focus();
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Business_Type"].ToString()))
                            {
                                ddlbusiness.ClearSelection();
                                ddlbusiness.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Business_Type"].ToString()).Selected = true;
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Department"].ToString()))
                            {
                                ddldepartment.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Department"].ToString()).Selected = true;
                                DataTable dtDep = new DataTable();
                                PositionBL pbl = new PositionBL();
                                dtDep = pbl.SelectByDepartmentID(BaseLib.Convert_Int(ddldepartment.SelectedValue));
                                ddlposition.DataSource = dtDep;
                                ddlposition.DataTextField = "Description";
                                ddlposition.DataValueField = "ID";
                                ddlposition.DataBind();
                                ddlposition.Items.Insert(0, "");
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Position"].ToString()))
                            {
                                ddlposition.Items.FindByText(bindoldjobhistory.Rows[rowIndex]["Position"].ToString()).Selected = true;
                                int type = BaseLib.Convert_Int(ddlposition.SelectedValue);
                                Working_History_BL webbl = new Working_History_BL();
                                DataTable dtb = new DataTable();
                                dtb = webbl.SelectedByPosition(type);
                                chkjobdescription.DataSource = dtb;
                                chkjobdescription.DataTextField = "Description";
                                chkjobdescription.DataValueField = "ID";
                                chkjobdescription.DataBind();
                                chkjobdescription.Focus();
                            }
                            if (!String.IsNullOrWhiteSpace(bindoldjobhistory.Rows[rowIndex]["Job_Description_ID"].ToString()))
                            {
                                string[] strarr = (bindoldjobhistory.Rows[rowIndex]["Job_Description_ID"].ToString().Split(','));
                                for (int i = 0; i < strarr.Length; i++)
                                {
                                    if (chkjobdescription.Items.FindByValue(strarr[i]) != null)
                                    {
                                        chkjobdescription.Items.FindByValue(strarr[i]).Selected = true;
                                    }
                                }
                            }
                            rowIndex++;
                        }
                        if (bindoldjobhistory.Rows.Count > 1)
                        {
                            LinkButton LinkButton1 = Gridview1.HeaderRow.FindControl("LinkButton1") as LinkButton;
                            LinkButton1.Visible = true;
                        }
                        ViewState["PreviousTable"] = bindoldjobhistory;
                    }
                    else
                    {
                        Gridview1.DataSource = null;
                        Gridview1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditData(DataTable dtb)
        {
            try
            {
                if (ddlEngreadwrite.Items.FindByText(dtb.Rows[0]["Engreadwrite"].ToString()) != null)
                {
                    ddlEngreadwrite.ClearSelection();
                    ddlEngreadwrite.Items.FindByText(dtb.Rows[0]["Engreadwrite"].ToString()).Selected = true;
                }
                if (ddlEngspeaking.Items.FindByText(dtb.Rows[0]["Engspeak"].ToString()) != null)
                {
                    ddlEngspeaking.ClearSelection();
                    ddlEngspeaking.Items.FindByText(dtb.Rows[0]["Engspeak"].ToString()).Selected = true;
                }
                if (ddljpreadwrite.Items.FindByText(dtb.Rows[0]["JPreadwrite"].ToString()) != null)
                {
                    ddljpreadwrite.ClearSelection();
                    ddljpreadwrite.Items.FindByText(dtb.Rows[0]["JPreadwrite"].ToString()).Selected = true;
                }
                if (ddljpspeaking.Items.FindByText(dtb.Rows[0]["JPspeak"].ToString()) != null)
                {
                    ddljpspeaking.ClearSelection();
                    ddljpspeaking.Items.FindByText(dtb.Rows[0]["JPspeak"].ToString()).Selected = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Qualification()
        {
            Working_History_BL webbl = new Working_History_BL();
            DataSet dsdata = new DataSet();
            dsdata = webbl.BindDataForQualification();
            dsdata.Relations.Add(new DataRelation("Qualification_Relation", dsdata.Tables[0].Columns["ID"], dsdata.Tables[1].Columns["QualificationTitle_id"], false));
            outerDataList.DataSource = dsdata.Tables[0];
            outerDataList.DataBind();
        }

        public void Ability()
        {
            Working_History_BL webbl = new Working_History_BL();
            DataSet dsdata = new DataSet();
            dsdata = webbl.BindDataForAbility();
            dsdata.Relations.Add(new DataRelation("Ability_Relation", dsdata.Tables[0].Columns["ID"], dsdata.Tables[1].Columns["AbilityTitle_id"], false));
            outerDataList1.DataSource = dsdata.Tables[0];
            outerDataList1.DataBind();
        }

        protected void outerRep_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Qualification_Relation");
                innerDataList.DataBind();
            }

        }

        protected void outerRep_ItemDataBound1(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList1") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Ability_Relation");
                innerDataList.DataBind();
            }
        }

        public void fillData()
        {
            GlobalBL global = new GlobalBL();
            chkPcSkill.DataSource = global.Get_Data("PC_Skill");
            chkPcSkill.DataTextField = "Description";
            chkPcSkill.DataValueField = "ID";
            chkPcSkill.DataBind();
            chkpersonalskill.DataSource = global.Getpresonalskill();
            chkpersonalskill.DataTextField = "Mark";
            chkpersonalskill.DataValueField = "Skill_ID";
            chkpersonalskill.DataBind();
            Qualification();
            Ability();
            ddlpositionrequsted.DataSource = global.Get_Datanew("Position");
            ddlpositionrequsted.DataTextField = "Description";
            ddlpositionrequsted.DataValueField = "ID";
            ddlpositionrequsted.DataBind();
            ddlpositionrequsted.ClearSelection();
            ddlpositionrequsted.Items.Insert(0, "");
            ddlpositionrequsted.Text = "";
            ddlpositionrequested1.DataSource = global.Get_Datanew("Position");
            ddlpositionrequested1.DataTextField = "Description";
            ddlpositionrequested1.DataValueField = "ID";
            ddlpositionrequested1.DataBind();
            ddlpositionrequested1.ClearSelection();
            ddlpositionrequested1.Items.Insert(0, "");
            ddlpositionrequested2.DataSource = global.Get_Datanew("Position");
            ddlpositionrequested2.DataTextField = "Description";
            ddlpositionrequested2.DataValueField = "ID";
            ddlpositionrequested2.DataBind();
            ddlpositionrequested2.ClearSelection();
            ddlpositionrequested2.Items.Insert(0, "");
            ddlEngreadwrite.DataSource = global.Get_Datanew("Language_Level");
            ddlEngreadwrite.DataTextField = "Description";
            ddlEngreadwrite.DataValueField = "ID";
            ddlEngreadwrite.DataBind();
            ddlEngreadwrite.ClearSelection();
            ddlEngreadwrite.Items.Insert(0, "");
            ddlEngreadwrite.Text = "";
            ddlEngspeaking.DataSource = global.Get_Datanew("Language_Level");
            ddlEngspeaking.DataTextField = "Description";
            ddlEngspeaking.DataValueField = "ID";
            ddlEngspeaking.DataBind();
            ddlEngspeaking.ClearSelection();
            ddlEngspeaking.Items.Insert(0, "");
            ddlEngspeaking.Text = "";
            ddljpreadwrite.DataSource = global.Get_Datanew("Language_Level");
            ddljpreadwrite.DataTextField = "Description";
            ddljpreadwrite.DataValueField = "ID";
            ddljpreadwrite.DataBind();
            ddljpreadwrite.ClearSelection();
            ddljpreadwrite.Items.Insert(0, "");
            ddljpreadwrite.Text = "";
            ddljpspeaking.DataSource = global.Get_Datanew("Language_Level");
            ddljpspeaking.DataTextField = "Description";
            ddljpspeaking.DataValueField = "ID";
            ddljpspeaking.DataBind();
            ddljpspeaking.ClearSelection();
            ddljpspeaking.Items.Insert(0, "");
            ddljpspeaking.Text = "";
            ddlsalarytype.DataSource = global.Get_Datanew("Salary_Type");
            ddlsalarytype.DataTextField = "Description";
            ddlsalarytype.DataValueField = "ID";
            ddlsalarytype.DataBind();
            ddlsalarytype.ClearSelection();
            ddlmajor1.DataSource = global.Get_Datanew("Major");
            ddlmajor1.DataTextField = "Description";
            ddlmajor1.DataValueField = "ID";
            ddlmajor1.DataBind();
            ddlmajor1.ClearSelection();
            ddlmajor1.Items.Insert(0, "");
            ddlmajor1.Text = "";
            ddlmajor2.DataSource = global.Get_Datanew("Major");
            ddlmajor2.DataTextField = "Description";
            ddlmajor2.DataValueField = "ID";
            ddlmajor2.DataBind();
            ddlmajor2.ClearSelection();
            ddlmajor2.Items.Insert(0, "");
            ddlmajor2.Text = "";
            webbl = new Working_History_BL();
            ddldegree1.DataSource = webbl.GetDegree();
            ddldegree1.DataTextField = "Description";
            ddldegree1.DataValueField = "Degree_ID";
            ddldegree1.DataBind();
            ddldegree1.ClearSelection();
            ddldegree1.Items.Insert(0, "");
            ddldegree1.Text = "";
            ddldegree2.DataSource = webbl.GetDegree();
            ddldegree2.DataTextField = "Description";
            ddldegree2.DataValueField = "Degree_ID";
            ddldegree2.DataBind();
            ddldegree2.ClearSelection();
            ddldegree2.Items.Insert(0, "");
            ddldegree2.Text = "";
            chklocationrequested.DataSource = webbl.Getlocationrequested(3);
            chklocationrequested.DataTextField = "Description";
            chklocationrequested.DataValueField = "ID";
            chklocationrequested.DataBind();
            ddluniversity2.DataSource = global.Get_Datanew("Institution");
            ddluniversity2.DataTextField = "Description";
            ddluniversity2.DataValueField = "ID";
            ddluniversity2.DataBind();
            ddluniversity2.ClearSelection();
            ddluniversity2.Items.Insert(0, "");
            ddluniversity2.Text = "";
            ddluniversity1.DataSource = global.Get_Datanew("Institution");
            ddluniversity1.DataTextField = "Description";
            ddluniversity1.DataValueField = "ID";
            ddluniversity1.DataBind();
            ddluniversity1.ClearSelection();
            ddluniversity1.Items.Insert(0, "");
            ddluniversity1.Text = "";
            ddlfirsint.DataSource = global.Get_Datanew("Interviewer_Name");
            ddlfirsint.DataTextField = "Interviewer_Name";
            ddlfirsint.DataValueField = "ID";
            ddlfirsint.DataBind();
            ddlfirsint.ClearSelection();
            ddlfirsint.Items.Insert(0, "");
            ddlfirsint.Text = "";
            ddlsecondint.DataSource = global.Get_Datanew("Interviewer_Name");
            ddlsecondint.DataTextField = "Interviewer_Name";
            ddlsecondint.DataValueField = "ID";
            ddlsecondint.DataBind();
            ddlsecondint.ClearSelection();
            ddlsecondint.Items.Insert(0, "");
            ddlsecondint.Text = "";
            ddljapan.DataSource = global.Get_Datanew("Interviewer_Name");
            ddljapan.DataTextField = "Interviewer_Name";
            ddljapan.DataValueField = "ID";
            ddljapan.DataBind();
            ddljapan.ClearSelection();
            ddljapan.Items.Insert(0, "");
            ddljapan.Text = "";
            rdostatus.DataSource = global.Get_Datanew("Situation");
            rdostatus.DataBind();
            rdostatus.DataValueField = "ID";
            rdostatus.DataTextField = "Description";
            rdostatus.DataBind();
            ddlpositionlevel1.DataSource = BindPositionLevel();
            ddlpositionlevel1.DataTextField = "Description";
            ddlpositionlevel1.DataValueField = "ID";
            ddlpositionlevel1.DataBind();
            ddlpositionlevel1.Items.Insert(0, "");
            ddlpositionlevel2.DataSource = BindPositionLevel();
            ddlpositionlevel2.DataTextField = "Description";
            ddlpositionlevel2.DataValueField = "ID";
            ddlpositionlevel2.DataBind();
            ddlpositionlevel2.Items.Insert(0, "");
            ddlpositionlevel3.DataSource = BindPositionLevel();
            ddlpositionlevel3.DataTextField = "Description";
            ddlpositionlevel3.DataValueField = "ID";
            ddlpositionlevel3.DataBind();
            ddlpositionlevel3.Items.Insert(0, "");
        }

        public void BindData(DataTable dtdata)
        {
            try
            {
                string gender = dtdata.Rows[0]["GenderID"].ToString();
                if (gender == "1")
                {
                    male.Checked = true;
                }
                else
                {
                    female.Checked = true;
                }
                txtname.Text = dtdata.Rows[0]["Name"].ToString();
                txtage.Text = dtdata.Rows[0]["Age"].ToString();
                if (!String.IsNullOrWhiteSpace(dtdata.Rows[0]["Interview_Date"].ToString()))
                {
                    DateTime date = (DateTime)dtdata.Rows[0]["Interview_Date"];
                    txtdate.Text = Convert.ToDateTime(date.ToString(), CultureInfo.GetCultureInfo("en-US")).ToString("yyyy/MM/dd");
                }
                lblfilladdress.Text = dtdata.Rows[0]["address"].ToString();
                lblid.Text = dtdata.Rows[0]["ID"].ToString();
                Working_History_BL workbl = new Working_History_BL();
                DataTable dtb = workbl.Selectforedit(Convert.ToInt32(lblid.Text));
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Driving_License"].ToString()))
                {
                    if (dtb.Rows[0]["Driving_License"].ToString() == "True")
                    {
                        rdoAvaliable.Checked = true;
                    }
                    else if (String.IsNullOrWhiteSpace(dtb.Rows[0]["Driving_License"].ToString()))
                    {
                    }
                    else
                    {
                        rdoNot.Checked = true;
                    }
                }
                if (ddlpositionrequsted.Items.FindByText(dtb.Rows[0]["Positionrequested"].ToString()) != null)
                {
                    ddlpositionrequsted.ClearSelection();
                    ddlpositionrequsted.Items.FindByText(dtb.Rows[0]["Positionrequested"].ToString()).Selected = true;
                }
                if (ddlpositionrequested1.Items.FindByText(dtb.Rows[0]["Positionrequested1"].ToString()) != null)
                {
                    ddlpositionrequested1.ClearSelection();
                    ddlpositionrequested1.Items.FindByText(dtb.Rows[0]["Positionrequested1"].ToString()).Selected = true;
                }
                if (ddlpositionrequested2.Items.FindByText(dtb.Rows[0]["Positionrequested2"].ToString()) != null)
                {
                    ddlpositionrequested2.ClearSelection();
                    ddlpositionrequested2.Items.FindByText(dtb.Rows[0]["Positionrequested2"].ToString()).Selected = true;
                }
                if (ddlpositionlevel1.Items.FindByText(dtb.Rows[0]["Positionlevel1"].ToString()) != null)
                {
                    ddlpositionlevel1.ClearSelection();
                    ddlpositionlevel1.Items.FindByText(dtb.Rows[0]["Positionlevel1"].ToString()).Selected = true;
                }
                if (ddlpositionlevel2.Items.FindByText(dtb.Rows[0]["Positionlevel2"].ToString()) != null)
                {
                    ddlpositionlevel2.ClearSelection();
                    ddlpositionlevel2.Items.FindByText(dtb.Rows[0]["Positionlevel2"].ToString()).Selected = true;
                }
                if (ddlpositionlevel3.Items.FindByText(dtb.Rows[0]["Positionlevel3"].ToString()) != null)
                {
                    ddlpositionlevel3.ClearSelection();
                    ddlpositionlevel3.Items.FindByText(dtb.Rows[0]["Positionlevel3"].ToString()).Selected = true;
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Salary"].ToString()))
                {
                    txtexpectedsalary.Text = dtb.Rows[0]["Salary"].ToString();
                }
                if (rdostatus.Items.FindByText(dtb.Rows[0]["Career_Status"].ToString()) != null)
                {
                    rdostatus.Items.FindByText(dtb.Rows[0]["Career_Status"].ToString()).Selected = true;
                }
                if (ddlsalarytype.Items.FindByText(dtb.Rows[0]["SalaryType"].ToString()) != null)
                {
                    ddlsalarytype.ClearSelection();
                    ddlsalarytype.Items.FindByText(dtb.Rows[0]["SalaryType"].ToString()).Selected = true;
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_On_Saturday"].ToString()))
                {
                    if (dtb.Rows[0]["Working_On_Saturday"].ToString() == "True")
                    {
                        rdosatyes.Checked = true;
                    }
                    else
                    {
                        rdosatno.Checked = true;
                    }
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Other_Qualification"].ToString()))
                {
                    txtqualification.Text = dtb.Rows[0]["Other_Qualification"].ToString();
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Impression"].ToString()))
                {
                    txtimpression.Text = dtb.Rows[0]["Impression"].ToString();
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Updating_Info"].ToString()))
                {
                    txtupdateinfo.Text = dtb.Rows[0]["Updating_Info"].ToString();
                }
                lblid.Text = dtb.Rows[0]["ID"].ToString();
                EditData(dtb);
                DataTable dtbindpcskil = new DataTable();
                webbl = new Working_History_BL();
                dtbindpcskil = webbl.SelectedbyIDforpcskill(Convert.ToInt32(lblid.Text));
                for (int i = 0; i < dtbindpcskil.Rows.Count; i++)
                {
                    if (chkPcSkill.Items.FindByText(dtbindpcskil.Rows[i]["PCSkills"].ToString()) != null)
                    {
                        chkPcSkill.Items.FindByText(dtbindpcskil.Rows[i]["PCSkills"].ToString()).Selected = true;
                    }
                }
                Career_QualificationBL cqbl = new Career_QualificationBL();
                DataTable dtbindqual = cqbl.SelectByID(Convert.ToInt32(lblid.Text));
                int itemCount1 = 0;
                for (int i = 0; i < dtbindqual.Rows.Count; i++)
                {
                    for (itemCount1 = 0; itemCount1 < outerDataList.Items.Count; itemCount1++)
                    {

                        DataList childdl = outerDataList.Items[itemCount1].FindControl("innerDataList") as System.Web.UI.WebControls.DataList;
                        foreach (DataListItem dl in childdl.Items)
                        {
                            CheckBox chkQ = (CheckBox)dl.FindControl("chkQ");
                            if ((chkQ.Text).ToString() == dtbindqual.Rows[i]["Qualification"].ToString())
                            {
                                chkQ.Checked = true;
                            }
                        }
                    }
                }
                DataTable dtbbindpersonalskill = new DataTable();
                dtbbindpersonalskill = webbl.SelectedbyIDforpersonalskill(Convert.ToInt32(lblid.Text));
                for (int i = 0; i < dtbbindpersonalskill.Rows.Count; i++)
                {
                    if (chkpersonalskill.Items.FindByText(dtbbindpersonalskill.Rows[i]["Skill_Type"].ToString()) != null)
                    {
                        chkpersonalskill.Items.FindByText(dtbbindpersonalskill.Rows[i]["Skill_Type"].ToString()).Selected = true;
                    }
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_Experience"].ToString()))
                {
                    if (dtb.Rows[0]["Working_Experience"].ToString() == "True")
                    {
                        rdoexperience.Items[0].Selected = true;
                    }
                    else if (String.IsNullOrWhiteSpace(dtb.Rows[0]["Working_Experience"].ToString()))
                    {
                    }
                    else
                    {
                        rdoexperience.Items[1].Selected = true;
                    }
                }
                if (ddldegree1.Items.FindByText(dtb.Rows[0]["Degree1"].ToString()) != null)
                {
                    ddldegree1.ClearSelection();
                    ddldegree1.Items.FindByText(dtb.Rows[0]["Degree1"].ToString()).Selected = true;
                }
                if (ddluniversity1.Items.FindByText(dtb.Rows[0]["University1"].ToString()) != null)
                {
                    ddluniversity1.ClearSelection();
                    ddluniversity1.Items.FindByText(dtb.Rows[0]["University1"].ToString()).Selected = true;
                    DataTable dtbtownship = new DataTable();
                    webbl = new Working_History_BL();
                    dtbtownship = webbl.SelectedbyUniversityID(BaseLib.Convert_Int(ddluniversity1.SelectedValue));
                    ddltownship1.DataSource = dtbtownship;
                    ddltownship1.DataTextField = "AreaDescription";
                    ddltownship1.DataValueField = "AreaID";
                    ddltownship1.DataBind();
                    ddltownship1.Focus();
                }
                if (ddlmajor1.Items.FindByText(dtb.Rows[0]["Major1"].ToString()) != null)
                {
                    ddlmajor1.ClearSelection();
                    ddlmajor1.Items.FindByText(dtb.Rows[0]["Major1"].ToString()).Selected = true;
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Year1"].ToString()))
                {
                    txtyear1.Text = dtb.Rows[0]["Year1"].ToString();
                }
                if (ddldegree2.Items.FindByText(dtb.Rows[0]["Degree2"].ToString()) != null)
                {
                    ddldegree2.ClearSelection();
                    ddldegree2.Items.FindByText(dtb.Rows[0]["Degree2"].ToString()).Selected = true;
                }
                if (ddluniversity2.Items.FindByText(dtb.Rows[0]["University2"].ToString()) != null)
                {
                    ddluniversity2.ClearSelection();
                    ddluniversity2.Items.FindByText(dtb.Rows[0]["University2"].ToString()).Selected = true;
                    DataTable dtbtownship2 = new DataTable();
                    webbl = new Working_History_BL();
                    dtbtownship2 = webbl.SelectedbyUniversityID(BaseLib.Convert_Int(ddluniversity2.SelectedValue));
                    ddltownship2.DataSource = dtbtownship2;
                    ddltownship2.DataTextField = "AreaDescription";
                    ddltownship2.DataValueField = "AreaID";
                    ddltownship2.DataBind();
                    ddltownship2.Focus();
                }
                if (ddlmajor2.Items.FindByText(dtb.Rows[0]["Major2"].ToString()) != null)
                {
                    ddlmajor2.ClearSelection();
                    ddlmajor2.Items.FindByText(dtb.Rows[0]["Major2"].ToString()).Selected = true;
                }
                if (!String.IsNullOrWhiteSpace(dtb.Rows[0]["Year2"].ToString()))
                {
                    txtyear2.Text = dtb.Rows[0]["Year2"].ToString();
                }
                DataTable bindoldjobhistory = new DataTable();
                bindoldjobhistory = webbl.SelectedbyOldjobhistory(Convert.ToInt32(lblid.Text));
                FillDataInTextboxforOldjobhistory(bindoldjobhistory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnserach_Click(object sender, EventArgs e)
        {
            try
            {
                string code1 = ddlemployeecode.SelectedItem.ToString();
                string code2 = txtempcode.Text;
                Working_History_BL webbl = new Working_History_BL();
                DataTable dtdata = new DataTable();
                dtdata = webbl.GetBindData(code1, code2);
                if (!String.IsNullOrWhiteSpace(code2))
                {
                    if (dtdata.Rows.Count > 0)
                    {
                        BindData(dtdata);
                        if (Button1.Text == "Save")
                        {
                            Button1.Enabled = true;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Your Employee Code in not correct')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('You must first enter the Employee_Code')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    #region insert EWH
                    WorkingHistoryEntity webentity = new WorkingHistoryEntity();
                    webentity.Career_code = ddlemployeecode.Text + "-" + txtempcode.Text;
                    webentity.Career_ID = Convert.ToInt32(lblid.Text);
                    CheckCondition(webentity);
                    if (!string.IsNullOrWhiteSpace(Request.Form[txtdate.UniqueID]))
                    {
                        string strDate1 = Request.Form[txtdate.UniqueID];
                        string date1 = Convert.ToDateTime(strDate1, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                        webentity.Interviewdate = DateTime.ParseExact(date1, "MM/dd/yyyy ", null);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionrequsted.Text))
                    {
                        webentity.Positionrequested = BaseLib.Convert_Int(ddlpositionrequsted.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(txtname.Text))
                    {
                        webentity.Name = txtname.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(txtage.Text))
                    {
                        webentity.Age = Convert.ToInt16(txtage.Text);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlfirsint.SelectedValue))
                    {
                        webentity.FirstInterviewer = BaseLib.Convert_Int(ddlfirsint.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlsecondint.SelectedValue))
                    {
                        webentity.SecondInterviewer = BaseLib.Convert_Int(ddlsecondint.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddljapan.SelectedValue))
                    {
                        webentity.Japanese_Interviewer = BaseLib.Convert_Int(ddljapan.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionrequsted.Text))
                    {
                        webentity.Positionrequested = BaseLib.Convert_Int(ddlpositionrequsted.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionrequested1.Text))
                    {
                        webentity.Positionrequested1 = BaseLib.Convert_Int(ddlpositionrequested1.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionrequested2.Text))
                    {
                        webentity.Positionrequested2 = BaseLib.Convert_Int(ddlpositionrequested2.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionlevel1.Text))
                    {
                        webentity.Positionlevel1 = BaseLib.Convert_Int(ddlpositionlevel1.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionlevel2.Text))
                    {
                        webentity.Positionlevel2 = BaseLib.Convert_Int(ddlpositionlevel2.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlpositionlevel3.Text))
                    {
                        webentity.Positionlevel3 = BaseLib.Convert_Int(ddlpositionlevel3.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(txtTotalMark.Text))
                    {
                        webentity.TotalMark1 = Convert.ToInt32(txtTotalMark.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(txtexpectedsalary.Text))
                    {
                        webentity.Expectedsalary = int.Parse(txtexpectedsalary.Text);
                    }
                    else
                    {
                        webentity.Expectedsalary = 0;
                    }

                    if (!String.IsNullOrWhiteSpace(ddlsalarytype.Text))
                    {
                        webentity.SalarytypeID = BaseLib.Convert_Int(ddlsalarytype.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(salaryID.Text))
                    {
                        webentity.SalaryID1 = int.Parse(salaryID.Text);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlsatdaycondition.Text))
                    {
                        if (rdosatno.Checked)
                        {
                            webentity.Saturday_Condition1 = 0;
                        }
                        else
                        {
                            webentity.Saturday_Condition1 = BaseLib.Convert_Int(ddlsatdaycondition.SelectedValue);
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(ddldegree1.Text))
                    {
                        webentity.Degree1 = BaseLib.Convert_Int(ddldegree1.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddluniversity1.Text))
                    {
                        webentity.University1 = BaseLib.Convert_Int(ddluniversity1.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddltownship1.Text))
                    {
                        webentity.TownshipID1 = BaseLib.Convert_Int(ddltownship1.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlmajor1.Text))
                    {
                        webentity.Major1 = BaseLib.Convert_Int(ddlmajor1.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(txtyear1.Text))
                    {
                        webentity.Year1 = txtyear1.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(ddldegree2.Text))
                    {
                        webentity.Degree2 = BaseLib.Convert_Int(ddldegree2.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddluniversity2.Text))
                    {
                        webentity.University2 = BaseLib.Convert_Int(ddluniversity2.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddltownship2.Text))
                    {
                        webentity.TownshipID2 = BaseLib.Convert_Int(ddltownship2.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(ddlmajor2.Text))
                    {
                        webentity.Major2 = BaseLib.Convert_Int(ddlmajor2.SelectedValue);
                    }
                    if (!String.IsNullOrWhiteSpace(txtyear2.Text))
                    {
                        webentity.Year2 = txtyear2.Text;
                    }
                    if (!String.IsNullOrWhiteSpace(ddldegree1.Text))
                    {
                        webentity.Degree1 = BaseLib.Convert_Int(ddldegree1.SelectedValue);
                    }
                    if (rdocheckimmediate.Checked)
                    {
                        webentity.Notice_type = 3;
                    }
                    else if (rdocheckm.Checked)
                    {
                        if (!String.IsNullOrWhiteSpace(txtnoticeday.Text))
                        {
                            webentity.Notice_day = BaseLib.Convert_Int(txtnoticeday.Text);
                        }
                        if (!String.IsNullOrWhiteSpace(ddlnoticetype.Text))
                        {
                            webentity.Notice_type = BaseLib.Convert_Int(ddlnoticetype.SelectedValue);
                        }
                    }
                    else
                    {
                    }
                    Career_WorkingPlaceEntity cwpe = new Career_WorkingPlaceEntity();
                    int rowworking = 0;
                    foreach (ListItem list in chklocationrequested.Items)
                    {
                        if (list.Selected)
                        {
                            cwpe.WorkingPlace.Rows.Add();
                            cwpe.WorkingPlace.Rows[rowworking]["WorkingPlace_ID"] = list.Value;
                            rowworking++;
                        }
                    }
                    Career_PCSkillsEntity cpe = new Career_PCSkillsEntity();
                    int row = 0;
                    foreach (ListItem item in chkPcSkill.Items)
                    {
                        if (item.Selected)
                        {
                            cpe.PcSkills.Rows.Add();
                            cpe.PcSkills.Rows[row]["PCSkill_ID"] = item.Value;
                            row++;
                        }
                    }

                    Career_QualificationEntity cq = new Career_QualificationEntity();
                    int itemCount1 = 0;
                    row = 0;
                    for (itemCount1 = 0; itemCount1 < outerDataList.Items.Count; itemCount1++)
                    {
                        DataList childdl = outerDataList.Items[itemCount1].FindControl("innerDataList") as System.Web.UI.WebControls.DataList;
                        foreach (DataListItem dl in childdl.Items)
                        {
                            CheckBox chkQ = (CheckBox)dl.FindControl("chkQ");
                            Label lblQ_id = (Label)dl.FindControl("lblQ_id");

                            if (chkQ.Checked)
                            {
                                cq.Qualification.Rows.Add();
                                cq.Qualification.Rows[row]["Qualification_ID"] = Int32.Parse(lblQ_id.Text);
                                row++;
                            }
                        }
                    }
                    //Career_Ability
                    Career_AbilityEntity cae = new Career_AbilityEntity();
                    int itemCount = 0;
                    row = 0;
                    for (itemCount = 0; itemCount < outerDataList1.Items.Count; itemCount++)
                    {
                        DataList childdl = outerDataList1.Items[itemCount].FindControl("innerDataList1") as System.Web.UI.WebControls.DataList;
                        foreach (DataListItem dl in childdl.Items)
                        {
                            CheckBox chkAbl = (CheckBox)dl.FindControl("chkAbl");
                            Label lblAbl_id = (Label)dl.FindControl("lblAbl_id");

                            if (chkAbl.Checked)
                            {
                                cae.Ability.Rows.Add();
                                cae.Ability.Rows[row]["Ability_ID"] = Int32.Parse(lblAbl_id.Text);
                                row++;
                            }
                        }
                    }
                    Career_PersonalSkill cps = new Career_PersonalSkill();
                    int row1 = 0;
                    foreach (ListItem item in chkpersonalskill.Items)
                    {
                        if (item.Selected)
                        {
                            cps.Personal_skill.Rows.Add();
                            cps.Personal_skill.Rows[row1]["PersonaSkill_ID"] = item.Value;
                            row1++;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(txtqualification.Text))
                    {
                        webentity.Qualification = txtqualification.Text;
                    }
                    else
                    {
                        webentity.Qualification = " ";
                    }
                    webentity.Other = txtimpression.Text;
                    webentity.UpdateInfo = txtupdateinfo.Text;
                    if (!String.IsNullOrWhiteSpace(txtTotalMark.Text))
                    {
                        webentity.TotalMarks = Convert.ToInt32(txtTotalMark.Text);
                    }
                    webbl = new Working_History_BL();
                    int careerid;
                    if (Request.QueryString["Career_ID"] != null)
                    {
                        careerid = int.Parse(Request.QueryString["Career_ID"]);
                    }
                    else
                    {
                        careerid = 0;
                    }
                    #endregion
                    #region update
                    if (Button1.Text == "Update")
                    {
                        CreatenewDataTable();
                        DataTable dtnew = (DataTable)ViewState["DataTablenew"];
                        DataRow dr = null;
                        foreach (GridViewRow rowdata in Gridview1.Rows)
                        {
                            TextBox comanyname = rowdata.FindControl("txtcompanyname") as TextBox;
                            TextBox companyaddress = rowdata.FindControl("txtcomapnyaddress") as TextBox;
                            TextBox fromdate = rowdata.FindControl("txtFromDate") as TextBox;
                            TextBox todate = rowdata.FindControl("txtToDate") as TextBox;
                            TextBox reasonforleaving = rowdata.FindControl("txtreasonforleaving") as TextBox;
                            TextBox other = rowdata.FindControl("txtother") as TextBox;
                            CheckBoxList chkjobdescription = rowdata.FindControl("chkjobdescription") as CheckBoxList;
                            Label lblotherjp = (Label)rowdata.FindControl("lblotherjp") as Label;
                            Label lblreasongjp = (Label)rowdata.FindControl("lblreasonforleavingjp") as Label;
                            DropDownList ddlpositionlevel = rowdata.FindControl("ddlpositionlevel") as DropDownList;
                            DropDownList ddlIndustry = rowdata.FindControl("ddlindustrytype") as DropDownList;
                            DropDownList ddlbusiness = rowdata.FindControl("ddltypeofbusiness") as DropDownList;
                            DropDownList ddldepartment = rowdata.FindControl("ddldepartment") as DropDownList;
                            DropDownList ddlposition = rowdata.FindControl("ddlPosition") as DropDownList;
                            DropDownList ddlcompanytype = rowdata.FindControl("ddlcompanytype") as DropDownList;
                            DropDownList ddlcountry = rowdata.FindControl("ddlcountry") as DropDownList;
                            WorkingHistoryEntity workingentity = new WorkingHistoryEntity();
                            workingentity.Company_name = comanyname.Text;
                            workingentity.Companyaddress = companyaddress.Text;
                            if (!String.IsNullOrWhiteSpace(Request.Form[fromdate.UniqueID]))
                            {
                                string strDate = Request.Form[fromdate.UniqueID];
                                string date2 = Convert.ToDateTime(strDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                                workingentity.Duration_from = DateTime.ParseExact(date2, "MM/dd/yyyy ", null);
                            }
                            if (!String.IsNullOrWhiteSpace(Request.Form[todate.UniqueID]))
                            {
                                string strToDate = Request.Form[todate.UniqueID];
                                string date3 = Convert.ToDateTime(strToDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                                workingentity.Duration_to = DateTime.ParseExact(date3, "MM/dd/yyyy ", null);
                            }
                            int jbrow = 0;
                            string strjb = String.Empty;
                            foreach (ListItem item in chkjobdescription.Items)
                            {
                                if (item.Selected)
                                {

                                    strjb += item.Value + ",";
                                    jbrow++;
                                }
                            }
                            workingentity.Jobdescription = strjb;
                            workingentity.Othernew = other.Text;
                            workingentity.Reasonforleaving = reasonforleaving.Text;
                            workingentity.Other_Japan1 = lblotherjp.Text;
                            workingentity.ReasonForLeaving_Japan1 = lblreasongjp.Text;
                            if (!String.IsNullOrWhiteSpace(ddlcompanytype.Text))
                            {
                                workingentity.Company_Type_ID = BaseLib.Convert_Int(ddlcompanytype.SelectedValue);
                            }
                            if (!String.IsNullOrWhiteSpace(ddlcountry.Text))
                            {
                                workingentity.Country_ID = BaseLib.Convert_Int(ddlcountry.SelectedValue);
                            }
                            if (!String.IsNullOrWhiteSpace(ddlIndustry.Text))
                            {
                                workingentity.IndustryType_ID = BaseLib.Convert_Int(ddlIndustry.SelectedValue);
                            }
                            if (!String.IsNullOrWhiteSpace(ddlbusiness.Text))
                            {
                                workingentity.Business_type = BaseLib.Convert_Int(ddlbusiness.SelectedValue);
                            }
                            if (!String.IsNullOrWhiteSpace(ddldepartment.Text))
                            {
                                workingentity.Department_ID = BaseLib.Convert_Int(ddldepartment.SelectedValue);
                            }
                            if (!String.IsNullOrWhiteSpace(ddlposition.Text))
                            {
                                workingentity.Position_id = BaseLib.Convert_Int(ddlposition.SelectedValue);
                            }

                            if (!String.IsNullOrWhiteSpace(ddlpositionlevel.Text))
                            {
                                workingentity.Positionlevel = BaseLib.Convert_Int(ddlpositionlevel.SelectedValue);
                            }
                            dr = dtnew.NewRow();
                            dr["companyname"] = workingentity.Company_name;
                            dr["companyaddress"] = workingentity.Companyaddress;
                            dr["fromdate"] = workingentity.Duration_from;
                            dr["todate"] = workingentity.Duration_to;
                            dr["jobdescripition"] = workingentity.Jobdescription;
                            dr["reason"] = workingentity.Reasonforleaving;
                            dr["companytype"] = workingentity.Company_Type_ID;
                            dr["country"] = workingentity.Country_ID;
                            dr["industry"] = workingentity.IndustryType_ID;
                            dr["business"] = workingentity.Business_type;
                            dr["deparment"] = workingentity.Department_ID;
                            dr["position"] = workingentity.Position_id;
                            dr["other"] = workingentity.Othernew;
                            dr["positionlevel"] = workingentity.Positionlevel;
                            dr["otherjp"] = workingentity.Other_Japan1;
                            dr["reasonjp"] = workingentity.ReasonForLeaving_Japan1;
                            dtnew.Rows.Add(dr);
                        }
                        webbl.InsertData(webentity, cpe, Convert.ToInt32(lblid.Text), cps, EnumBase.Save.Update, careerid, dtnew, cwpe, cq, cae);
                        string url = "WorkingHistory_Detail.aspx?Career_ID=" + careerid;
                        string script = "window.onload = function(){ alert('";
                        script += "Update Successfully";
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                    }
                    #endregion
                    else
                    {
                        #region insert
                        if (CheckCareerid())
                        {
                            int str = Convert.ToInt32(lblid.Text);
                            CreatenewDataTable();
                            DataTable dtnew = (DataTable)ViewState["DataTablenew"];
                            DataRow dr = null;
                            //For Job Description
                            DataTable dtjobd = (DataTable)ViewState["JobD1"];
                            foreach (GridViewRow rowdata in Gridview1.Rows)
                            {
                                TextBox comanyname = rowdata.FindControl("txtcompanyname") as TextBox;
                                TextBox companyaddress = rowdata.FindControl("txtcomapnyaddress") as TextBox;
                                TextBox fromdate = rowdata.FindControl("txtFromDate") as TextBox;
                                TextBox todate = rowdata.FindControl("txtToDate") as TextBox;
                                TextBox reasonforleaving = rowdata.FindControl("txtreasonforleaving") as TextBox;
                                TextBox other = rowdata.FindControl("txtother") as TextBox;
                                Label lblotherjp = (Label)rowdata.FindControl("lblotherjp") as Label;
                                Label lblreasongjp = (Label)rowdata.FindControl("lblreasonforleavingjp") as Label;
                                CheckBoxList chkjobdescription = rowdata.FindControl("chkjobdescription") as CheckBoxList;
                                DropDownList ddlpositionlevel = rowdata.FindControl("ddlpositionlevel") as DropDownList;
                                DropDownList ddlIndustry = rowdata.FindControl("ddlindustrytype") as DropDownList;
                                DropDownList ddlbusiness = rowdata.FindControl("ddltypeofbusiness") as DropDownList;
                                DropDownList ddldepartment = rowdata.FindControl("ddldepartment") as DropDownList;
                                DropDownList ddlposition = rowdata.FindControl("ddlPosition") as DropDownList;
                                DropDownList ddlcompanytype = rowdata.FindControl("ddlcompanytype") as DropDownList;
                                DropDownList ddlcountry = rowdata.FindControl("ddlcountry") as DropDownList;
                                WorkingHistoryEntity workingentity = new WorkingHistoryEntity();
                                workingentity.Company_name = comanyname.Text;
                                workingentity.Companyaddress = companyaddress.Text;
                                workingentity.Othernew = other.Text;
                                if (!String.IsNullOrWhiteSpace(Request.Form[fromdate.UniqueID]))
                                {
                                    string strDate = Request.Form[fromdate.UniqueID];
                                    string date2 = Convert.ToDateTime(strDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                                    workingentity.Duration_from = DateTime.ParseExact(date2, "MM/dd/yyyy ", null);
                                }
                                if (!String.IsNullOrWhiteSpace(Request.Form[todate.UniqueID]))
                                {
                                    string strToDate = Request.Form[todate.UniqueID];
                                    string date3 = Convert.ToDateTime(strToDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy ");
                                    workingentity.Duration_to = DateTime.ParseExact(date3, "MM/dd/yyyy ", null);
                                }
                                workingentity.Other_Japan1 = lblotherjp.Text;
                                workingentity.ReasonForLeaving_Japan1 = lblreasongjp.Text;
                                int jbrow = 0;
                                string strjb = String.Empty;
                                foreach (ListItem item in chkjobdescription.Items)
                                {
                                    if (item.Selected)
                                    {
                                        strjb += item.Value + ",";
                                        jbrow++;
                                    }
                                }
                                workingentity.Jobdescription = strjb;
                                workingentity.Reasonforleaving = reasonforleaving.Text;
                                if (!String.IsNullOrWhiteSpace(ddlcompanytype.Text))
                                {
                                    workingentity.Company_Type_ID = BaseLib.Convert_Int(ddlcompanytype.SelectedValue);
                                }
                                if (!String.IsNullOrWhiteSpace(ddlcountry.Text))
                                {
                                    workingentity.Country_ID = BaseLib.Convert_Int(ddlcountry.SelectedValue);
                                }
                                if (!String.IsNullOrWhiteSpace(ddlIndustry.Text))
                                {
                                    workingentity.IndustryType_ID = BaseLib.Convert_Int(ddlIndustry.SelectedValue);
                                }
                                if (!String.IsNullOrWhiteSpace(ddlbusiness.Text))
                                {
                                    workingentity.Business_type = BaseLib.Convert_Int(ddlbusiness.SelectedValue);
                                }
                                if (!String.IsNullOrWhiteSpace(ddldepartment.Text))
                                {
                                    workingentity.Department_ID = BaseLib.Convert_Int(ddldepartment.SelectedValue);
                                }
                                if (!String.IsNullOrWhiteSpace(ddlposition.Text))
                                {
                                    workingentity.Position_id = BaseLib.Convert_Int(ddlposition.SelectedValue);
                                }
                                if (!String.IsNullOrWhiteSpace(ddlpositionlevel.Text))
                                {
                                    workingentity.Positionlevel = BaseLib.Convert_Int(ddlpositionlevel.SelectedValue);
                                }
                                dr = dtnew.NewRow();
                                dr["companyname"] = workingentity.Company_name;
                                dr["companyaddress"] = workingentity.Companyaddress;
                                dr["fromdate"] = workingentity.Duration_from;
                                dr["todate"] = workingentity.Duration_to;
                                dr["jobdescripition"] = workingentity.Jobdescription;
                                dr["reason"] = workingentity.Reasonforleaving;
                                dr["companytype"] = workingentity.Company_Type_ID;
                                dr["country"] = workingentity.Country_ID;
                                dr["industry"] = workingentity.IndustryType_ID;
                                dr["business"] = workingentity.Business_type;
                                dr["deparment"] = workingentity.Department_ID;
                                dr["position"] = workingentity.Position_id;
                                dr["other"] = workingentity.Othernew;
                                dr["positionlevel"] = workingentity.Positionlevel;
                                dr["otherjp"] = workingentity.Other_Japan1;
                                dr["reasonjp"] = workingentity.ReasonForLeaving_Japan1;
                                dtnew.Rows.Add(dr);
                            }
                            webbl.InsertData(webentity, cpe, Convert.ToInt32(lblid.Text), cps, EnumBase.Save.Insert, careerid, dtnew, cwpe, cq, cae);
                            string url = "WorkingHistory_Detail.aspx?Career_ID=" + str;
                            string script = "window.onload = function(){ alert('";
                            script += "Save Successfully";
                            script += "');";
                            script += "window.location = '";
                            script += url;
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                        }
                        #endregion
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Career_Id already Register')", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Please first select Employee_Code')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckCondition(WorkingHistoryEntity webentity)
        {
            try
            {
                if (rdoAvaliable.Checked)
                {
                    webentity.Drivinglicense = "1";
                }
                else
                {
                    webentity.Drivinglicense = "0";
                }

                if (!String.IsNullOrWhiteSpace(rdoexperience.SelectedValue))
                {
                    webentity.Workingexperience = Convert.ToString(rdoexperience.SelectedValue);
                }
                if (rdosatyes.Checked)
                {
                    webentity.Worksatday = "1";
                }
                else
                {
                    webentity.Worksatday = "0";
                }
                if (!String.IsNullOrWhiteSpace(rdostatus.SelectedValue))
                {
                    webentity.Status1 = Convert.ToInt32(rdostatus.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(ddlEngreadwrite.Text))
                {
                    webentity.Engreadingwrite = BaseLib.Convert_Int(ddlEngreadwrite.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(ddlEngspeaking.Text))
                {
                    webentity.Engspeaking = BaseLib.Convert_Int(ddlEngspeaking.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(ddljpreadwrite.Text))
                {
                    webentity.Jpreadwrite = BaseLib.Convert_Int(ddljpreadwrite.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(ddljpspeaking.Text))
                {
                    webentity.Jpspeaking = BaseLib.Convert_Int(ddljpspeaking.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(chkthilawa.SelectedValue))
                {
                    webentity.Thilawa = Convert.ToInt32(chkthilawa.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(chkhty.SelectedValue))
                {
                    webentity.Hlaingtharyar = Convert.ToInt32(chkhty.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(chkoversea.SelectedValue))
                {
                    webentity.Oversea = Convert.ToInt32(chkoversea.SelectedValue);
                }
                if (!String.IsNullOrWhiteSpace(chkoverseatraining.SelectedValue))
                {
                    webentity.Overseatraining = Convert.ToInt32(chkoverseatraining.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Check()
        {
            string careercode = txtempcode.Text;
            if (String.IsNullOrWhiteSpace(careercode))
                return false;
            else
                return true;
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                Working_History_BL wbl = new Working_History_BL();
                if (wbl.DeleteSelectedID(BaseLib.Convert_Int(Request.QueryString["Career_ID"].ToString())))
                {
                    string url = "WorkingHistory_View.aspx";
                    string script = "window.onload = function(){ alert('";
                    script += "Delete Successfully";
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                }
                else
                {
                    GlobalUI.MessageBox("Delete Failed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckCareerid()
        {
            webbl = new Working_History_BL();
            DataTable dtcheckcareerid = webbl.CheckCareerid(Convert.ToInt32(lblid.Text));
            if (dtcheckcareerid.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void ddlindustrytype_selectedindexchange(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;
                DropDownList ddlindustry = (DropDownList)row.Cells[0].FindControl("ddlindustrytype");
                DropDownList ddlbusiness = (DropDownList)row.Cells[0].FindControl("ddltypeofbusiness");
                int type = BaseLib.Convert_Int(ddlindustry.SelectedValue);
                DataTable dtb = new DataTable();
                BusinessTypeBL bussinessbl = new BusinessTypeBL();
                dtb = bussinessbl.SelectedbyTypeofBusiness(type);
                ddlbusiness.DataSource = dtb;
                ddlbusiness.DataTextField = "Description";
                ddlbusiness.DataValueField = "ID";
                ddlbusiness.DataBind();
                ddlbusiness.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlcompanytype_selectedindexchange(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;
                DropDownList ddlcompanytype = (DropDownList)row.Cells[0].FindControl("ddlcompanytype");
                DropDownList ddlcountry = (DropDownList)row.Cells[0].FindControl("ddlcountry");
                int type = BaseLib.Convert_Int(ddlcompanytype.SelectedValue);
                DataTable dtb = new DataTable();
                BusinessTypeBL bussinessbl = new BusinessTypeBL();
                dtb = bussinessbl.Selectedbycompanytype(type);
                ddlcountry.DataSource = dtb;
                ddlcountry.DataTextField = "Description";
                ddlcountry.DataValueField = "ID";
                ddlcountry.DataBind();
                ddlcountry.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddldepartment_selectedindexchange(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;
                DropDownList ddldepartment = (DropDownList)row.Cells[0].FindControl("ddldepartment");
                DropDownList ddlposition = (DropDownList)row.Cells[0].FindControl("ddlPosition");
                int type = BaseLib.Convert_Int(ddldepartment.SelectedValue);
                PositionBL pbl = new PositionBL();
                DataTable dtb = new DataTable();
                dtb = pbl.SelectByDepartmentID(type);
                ddlposition.DataSource = dtb;
                ddlposition.DataTextField = "Description";
                ddlposition.DataValueField = "ID";
                ddlposition.DataBind();
                ddlposition.Items.Insert(0, "");
                ddlposition.Text = "";
                //for JobDescriptionCheckBox(when change the departemtn,the position is change but jobdescriptin base on position isn't change)
                DropDownList ddl1 = (DropDownList)sender;
                GridViewRow row1 = (GridViewRow)ddl.Parent.Parent;
                int idex = row.RowIndex;
                DropDownList ddlposition1 = (DropDownList)row.Cells[0].FindControl("ddlposition");
                CheckBoxList chkjobdescription = (CheckBoxList)row.Cells[0].FindControl("chkjobdescription");
                if (!String.IsNullOrWhiteSpace(ddlposition.SelectedValue))
                {
                    int type1 = BaseLib.Convert_Int(ddlposition.SelectedValue);
                    Working_History_BL webbl = new Working_History_BL();
                    DataTable dtb1 = new DataTable();
                    dtb = webbl.SelectedByPosition(type1);
                    chkjobdescription.DataSource = dtb1;
                    chkjobdescription.DataTextField = "Description";
                    chkjobdescription.DataValueField = "ID";
                    chkjobdescription.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlposition_selectedindexchange(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;
                DropDownList ddlposition = (DropDownList)row.Cells[0].FindControl("ddlposition");
                CheckBoxList chkjobdescription = (CheckBoxList)row.Cells[0].FindControl("chkjobdescription");
                int type = BaseLib.Convert_Int(ddlposition.SelectedValue);
                Working_History_BL webbl = new Working_History_BL();
                DataTable dtb = new DataTable();
                dtb = webbl.SelectedByPosition(type);
                chkjobdescription.DataSource = dtb;
                chkjobdescription.DataTextField = "Description";
                chkjobdescription.DataValueField = "ID";
                chkjobdescription.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Selected_Township(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddluniversity1.SelectedValue);
                DataTable dt = new DataTable();
                webbl = new Working_History_BL();
                dt = webbl.SelectedbyUniversityID(index);
                ddltownship1.DataSource = dt;
                ddltownship1.DataTextField = "AreaDescription";
                ddltownship1.DataValueField = "AreaID";
                ddltownship1.DataBind();
                ddltownship1.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Selected_Township2(object sender, EventArgs e)
        {
            try
            {
                int index = BaseLib.Convert_Int(ddluniversity2.SelectedValue);
                DataTable dt = new DataTable();
                webbl = new Working_History_BL();
                dt = webbl.SelectedbyUniversityID(index);
                ddltownship2.DataSource = dt;
                ddltownship2.DataTextField = "AreaDescription";
                ddltownship2.DataValueField = "AreaID";
                ddltownship2.DataBind();
                ddltownship2.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkpersonalskill_OnCheck_Changed(object sender, EventArgs e)
        {
            int id;
            int totalmarks = 0;
            foreach (ListItem item in chkpersonalskill.Items)
            {
                if (item.Selected)
                {
                    id = Convert.ToInt32(item.Text);
                    totalmarks += id;
                }
            }
            txtTotalMark.Text = totalmarks.ToString();
        }

        protected void addnewtext_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dt.Columns.Add(new DataColumn("Column5", typeof(string)));
            dt.Columns.Add(new DataColumn("Column6", typeof(string)));
            dt.Columns.Add(new DataColumn("companytype", typeof(string)));
            dt.Columns.Add(new DataColumn("country", typeof(string)));
            dt.Columns.Add(new DataColumn("industry", typeof(string)));
            dt.Columns.Add(new DataColumn("business", typeof(string)));
            dt.Columns.Add(new DataColumn("deparment", typeof(string)));
            dt.Columns.Add(new DataColumn("position", typeof(string)));
            dt.Columns.Add(new DataColumn("other", typeof(string)));
            dt.Columns.Add(new DataColumn("positionlevel", typeof(string)));
            dt.Columns.Add(new DataColumn("otherjp", typeof(string)));
            dt.Columns.Add(new DataColumn("reasonjp", typeof(string)));
            dt.Columns.Add(new DataColumn("Column7", typeof(string)));
            dt.Columns.Add(new DataColumn("Column8", typeof(string)));
            dt.Columns.Add(new DataColumn("Column9", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Column10", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Column11", typeof(string)));
            dt.Columns.Add(new DataColumn("Column12", typeof(string)));
            dr = dt.NewRow();

            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dr["Column5"] = string.Empty;
            dr["Column6"] = string.Empty;
            dr["companytype"] = string.Empty;
            dr["country"] = string.Empty;
            dr["industry"] = string.Empty;
            dr["business"] = string.Empty;
            dr["deparment"] = string.Empty;
            dr["position"] = string.Empty;
            dr["other"] = string.Empty;
            dr["positionlevel"] = string.Empty;
            dr["otherjp"] = string.Empty;
            dr["reasonjp"] = string.Empty;
            dr["Column7"] = "Company_Name";
            dr["Column8"] = "Company_Address";
            dr["Column9"] = DateTime.Now;
            dr["Column10"] = DateTime.Now;
            dr["Column11"] = "Job_Description";
            dr["Column12"] = "Reason_For_Leaving";
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["PreviousTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["PreviousTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcompanyname");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcomapnyaddress");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtFromDate");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtToDate");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtreasonforleaving");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtother");
                        DropDownList ddlIndustry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlindustrytype") as DropDownList;
                        DropDownList ddlbusiness = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddltypeofbusiness") as DropDownList;
                        DropDownList ddldepartment = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddldepartment") as DropDownList;
                        DropDownList ddlposition = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlPosition") as DropDownList;
                        DropDownList ddlpositionlevel = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlpositionlevel") as DropDownList;
                        DropDownList ddlcompanytype = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcompanytype") as DropDownList;
                        DropDownList ddlcountry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcountry") as DropDownList;
                        Label lblotherjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblotherjp") as Label;
                        Label lblreasongjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleavingjp") as Label;
                        CheckBoxList chkjobdescription = Gridview1.Rows[rowIndex].Cells[0].FindControl("chkjobdescription") as CheckBoxList;
                        Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyname");
                        Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyaddress");
                        Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl7 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl8 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lbljobdescription");
                        Label lbl9 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleaving");
                        Label lbl10 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblother");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Company_Name"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Company_Address"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Duration_From"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Duration_To"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Reason_For_Leaving"] = box6.Text;
                        int jbrow = 0;
                        string strjb = String.Empty;
                        foreach (ListItem item in chkjobdescription.Items)
                        {
                            if (item.Selected)
                            {
                                strjb += item.Value + ",";
                                jbrow++;
                            }
                        }
                        dtCurrentTable.Rows[i - 1]["Job_Description_ID"] = strjb;
                        dtCurrentTable.Rows[i - 1]["Company_Type"] = ddlcompanytype.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Country"] = ddlcountry.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Industry"] = ddlIndustry.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Business_Type"] = ddlbusiness.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Department"] = ddldepartment.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Position"] = ddlposition.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Other"] = box7.Text;
                        dtCurrentTable.Rows[i - 1]["Position_Level"] = ddlpositionlevel.SelectedItem;
                        dtCurrentTable.Rows[i - 1]["Other_Japan"] = lblotherjp.Text;
                        dtCurrentTable.Rows[i - 1]["Reason_For_Leaving_Japan"] = lblreasongjp.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["PreviousTable"] = dtCurrentTable;
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                    SetPreviousDB();
                }
            }
            else if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcompanyname");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcomapnyaddress");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtFromDate");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtToDate");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtother");

                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtreasonforleaving");
                        DropDownList ddlIndustry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlindustrytype") as DropDownList;
                        DropDownList ddlbusiness = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddltypeofbusiness") as DropDownList;
                        DropDownList ddldepartment = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddldepartment") as DropDownList;
                        DropDownList ddlposition = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlPosition") as DropDownList;
                        DropDownList ddlpositionlevel = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlpositionlevel") as DropDownList;
                        DropDownList ddlcompanytype = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcompanytype") as DropDownList;
                        DropDownList ddlcountry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcountry") as DropDownList;
                        CheckBoxList chkjobdescription = Gridview1.Rows[rowIndex].Cells[0].FindControl("chkjobdescription") as CheckBoxList;
                        Label lblotherjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblotherjp") as Label;
                        Label lblreasongjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleavingjp") as Label;

                        Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyname");
                        Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyaddress");
                        Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl7 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl8 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lbljobdescription");
                        Label lbl9 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleaving");
                        Label lbl10 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblother");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;
                        dtCurrentTable.Rows[i - 1]["other"] = box7.Text;
                        dtCurrentTable.Rows[i - 1]["otherjp"] = lblotherjp.Text;
                        dtCurrentTable.Rows[i - 1]["reasonjp"] = lblreasongjp.Text;
                        int jbrow = 0;
                        string strjb = String.Empty;
                        foreach (ListItem item in chkjobdescription.Items)
                        {
                            if (item.Selected)
                            {
                                strjb += item.Value + ",";
                                jbrow++;
                            }
                        }
                        dtCurrentTable.Rows[i - 1]["Column5"] = strjb;
                        dtCurrentTable.Rows[i - 1]["companytype"] = ddlcompanytype.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["country"] = ddlcountry.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["industry"] = ddlIndustry.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["business"] = ddlbusiness.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["deparment"] = ddldepartment.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["position"] = ddlposition.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["positionlevel"] = ddlpositionlevel.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Column7"] = "Company_Name";
                        dtCurrentTable.Rows[i - 1]["Column8"] = "Company_Address";
                        dtCurrentTable.Rows[i - 1]["Column9"] = DateTime.Now;
                        dtCurrentTable.Rows[i - 1]["Column10"] = DateTime.Now;
                        dtCurrentTable.Rows[i - 1]["Column11"] = "Job_Description";
                        dtCurrentTable.Rows[i - 1]["Column12"] = "Reason_For_Leaving";
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                    SetPreviousData();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        private void SetPreviousDB()
        {
            int rowIndex = 0;
            if (ViewState["PreviousTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["PreviousTable"];
                if (dt.Rows.Count > 0)
                {
                    Response.Write(Gridview1.Rows.Count);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcompanyname");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcomapnyaddress");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtFromDate");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtToDate");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtreasonforleaving");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtother");
                        DropDownList ddlIndustry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlindustrytype") as DropDownList;
                        DropDownList ddlbusiness = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddltypeofbusiness") as DropDownList;
                        DropDownList ddldepartment = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddldepartment") as DropDownList;
                        DropDownList ddlposition = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlPosition") as DropDownList;
                        DropDownList ddlpositionlevel = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlpositionlevel") as DropDownList;
                        DropDownList ddlcompanytype = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcompanytype") as DropDownList;
                        DropDownList ddlcountry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcountry") as DropDownList;
                        CheckBoxList chkjobdescription = Gridview1.Rows[rowIndex].Cells[0].FindControl("chkjobdescription") as CheckBoxList;
                        Label lblotherjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblotherjp") as Label;
                        Label lblreasongjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleavingjp") as Label;
                        Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyname");
                        Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyaddress");
                        Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl7 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl8 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lbljobdescription");
                        Label lbl9 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleaving");
                        Label lbl10 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblother");

                        box1.Text = dt.Rows[i]["Company_Name"].ToString();
                        box2.Text = dt.Rows[i]["Company_Address"].ToString();
                        box3.Text = dt.Rows[i]["Duration_From"].ToString();
                        box4.Text = dt.Rows[i]["Duration_To"].ToString();
                        box6.Text = dt.Rows[i]["Reason_For_Leaving"].ToString();
                        box7.Text = dt.Rows[i]["Other"].ToString();
                        lblotherjp.Text = dt.Rows[i]["Other_Japan"].ToString();
                        lblreasongjp.Text = dt.Rows[i]["Reason_For_Leaving_Japan"].ToString();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Position_Level"].ToString()))
                        {
                            ddlpositionlevel.Items.FindByText(dt.Rows[i]["Position_Level"].ToString()).Selected = true;
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Company_Type"].ToString()))
                        {
                            ddlcompanytype.Items.FindByText(dt.Rows[i]["Company_Type"].ToString()).Selected = true;
                            DataTable dtb = new DataTable();
                            BusinessTypeBL bussinessbl = new BusinessTypeBL();
                            dtb = bussinessbl.Selectedbycompanytype(BaseLib.Convert_Int(ddlcompanytype.SelectedValue));
                            ddlcountry.DataSource = dtb;
                            ddlcountry.DataTextField = "Description";
                            ddlcountry.DataValueField = "ID";
                            ddlcountry.DataBind();
                            ddlcountry.Focus();
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Country"].ToString()))
                            {
                                ddlcountry.Items.FindByText(dt.Rows[i]["Country"].ToString()).Selected = true;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Industry"].ToString()))
                        {
                            ddlIndustry.Items.FindByText(dt.Rows[i]["Industry"].ToString()).Selected = true;
                            DataTable dtb = new DataTable();
                            BusinessTypeBL bussinessbl = new BusinessTypeBL();
                            dtb = bussinessbl.SelectedbyTypeofBusiness(BaseLib.Convert_Int(ddlIndustry.SelectedValue));
                            ddlbusiness.DataSource = dtb;
                            ddlbusiness.DataTextField = "Description";
                            ddlbusiness.DataValueField = "ID";
                            ddlbusiness.DataBind();
                            ddlbusiness.Focus();
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Business_Type"].ToString()))
                            {
                                ddlbusiness.Items.FindByText(dt.Rows[i]["Business_Type"].ToString()).Selected = true;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Department"].ToString()))
                        {
                            ddldepartment.Items.FindByText(dt.Rows[i]["Department"].ToString()).Selected = true;
                            DataTable dtDep = new DataTable();
                            PositionBL pbl = new PositionBL();
                            dtDep = pbl.SelectByDepartmentID(BaseLib.Convert_Int(ddldepartment.SelectedValue));
                            ddlposition.DataSource = dtDep;
                            ddlposition.DataTextField = "Description";
                            ddlposition.DataValueField = "ID";
                            ddlposition.DataBind();
                            ddlposition.Items.Insert(0, "");
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["Position"].ToString()))
                            {
                                ddlposition.Items.FindByText(dt.Rows[i]["Position"].ToString()).Selected = true;
                                if (!String.IsNullOrWhiteSpace(ddlposition.SelectedValue))
                                {
                                    int type = BaseLib.Convert_Int(ddlposition.SelectedValue);
                                    Working_History_BL webbl = new Working_History_BL();
                                    DataTable dtb = new DataTable();
                                    dtb = webbl.SelectedByPosition(type);
                                    chkjobdescription.DataSource = dtb;
                                    chkjobdescription.DataTextField = "Description";
                                    chkjobdescription.DataValueField = "ID";
                                    chkjobdescription.DataBind();
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Job_Description_ID"].ToString()))
                            {
                                string[] strarr = (dt.Rows[rowIndex]["Job_Description_ID"].ToString().Split(','));
                                for (int j = 0; j < strarr.Length; j++)
                                {
                                    if (chkjobdescription.Items.FindByValue(strarr[j]) != null)
                                    {
                                        chkjobdescription.Items.FindByValue(strarr[j]).Selected = true;
                                    }
                                }
                            }
                        }
                        lbl4.Text = "Company Name";
                        lbl5.Text = "Company Address";
                        lbl6.Text = "Duration From";
                        lbl7.Text = "Duration To";
                        lbl8.Text = "Job Description";
                        lbl9.Text = "Reason For Leaving";
                        rowIndex++;
                    }
                }
            }
            DataTable dt1 = (DataTable)ViewState["PreviousTable"];
            if (dt1.Rows.Count > 1)
            {
                LinkButton LinkButton1 = Gridview1.HeaderRow.FindControl("LinkButton1") as LinkButton;
                LinkButton1.Visible = true;
            }
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcompanyname");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcomapnyaddress");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtFromDate");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtToDate");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtreasonforleaving");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtother");
                        DropDownList ddlIndustry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlindustrytype") as DropDownList;
                        DropDownList ddlbusiness = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddltypeofbusiness") as DropDownList;
                        DropDownList ddldepartment = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddldepartment") as DropDownList;
                        DropDownList ddlposition = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlPosition") as DropDownList;
                        DropDownList ddlpositionlevel = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlpositionlevel") as DropDownList;
                        DropDownList ddlcompanytype = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcompanytype") as DropDownList;
                        DropDownList ddlcountry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcountry") as DropDownList;
                        CheckBoxList chkjobdescription = (CheckBoxList)Gridview1.Rows[rowIndex].Cells[0].FindControl("chkjobdescription") as CheckBoxList;
                        Label lblotherjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblotherjp") as Label;
                        Label lblreasongjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleavingjp") as Label;
                        Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyname");
                        Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyaddress");
                        Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl7 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                        Label lbl8 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lbljobdescription");
                        Label lbl9 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleaving");
                        Label lbl10 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblother");

                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();
                        box6.Text = dt.Rows[i]["Column6"].ToString();
                        box7.Text = dt.Rows[i]["other"].ToString();
                        lblotherjp.Text = dt.Rows[i]["otherjp"].ToString();
                        lblreasongjp.Text = dt.Rows[i]["reasonjp"].ToString();
                        lbl4.Text = "Company_Name";
                        lbl5.Text = "Company_Address";
                        lbl6.Text = "Duration_From";
                        lbl7.Text = "Duration_To";
                        lbl8.Text = "Job_Description";
                        lbl9.Text = "Reason_For_Leaving";
                        lbl10.Text = "Other";
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["positionlevel"].ToString()))
                        {
                            ddlpositionlevel.Items.FindByValue(dt.Rows[i]["positionlevel"].ToString()).Selected = true;
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["companytype"].ToString()))
                        {
                            ddlcompanytype.Items.FindByValue(dt.Rows[i]["companytype"].ToString()).Selected = true;
                            DataTable dtb = new DataTable();
                            BusinessTypeBL bussinessbl = new BusinessTypeBL();
                            dtb = bussinessbl.Selectedbycompanytype(BaseLib.Convert_Int(ddlcompanytype.SelectedValue));
                            ddlcountry.DataSource = dtb;
                            ddlcountry.DataTextField = "Description";
                            ddlcountry.DataValueField = "ID";
                            ddlcountry.DataBind();
                            ddlcountry.Focus();
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["country"].ToString()))
                            {
                                ddlcountry.Items.FindByValue(dt.Rows[i]["country"].ToString()).Selected = true;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["industry"].ToString()))
                        {
                            ddlIndustry.Items.FindByValue(dt.Rows[i]["industry"].ToString()).Selected = true;
                            DataTable dtb = new DataTable();
                            BusinessTypeBL bussinessbl = new BusinessTypeBL();
                            dtb = bussinessbl.SelectedbyTypeofBusiness(BaseLib.Convert_Int(ddlIndustry.SelectedValue));
                            ddlbusiness.DataSource = dtb;
                            ddlbusiness.DataTextField = "Description";
                            ddlbusiness.DataValueField = "ID";
                            ddlbusiness.DataBind();
                            ddlbusiness.Focus();
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["business"].ToString()))
                            {
                                ddlbusiness.Items.FindByValue(dt.Rows[i]["business"].ToString()).Selected = true;
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[i]["deparment"].ToString()))
                        {
                            ddldepartment.Items.FindByValue(dt.Rows[i]["deparment"].ToString()).Selected = true;
                            DataTable dtDep = new DataTable();
                            PositionBL pbl = new PositionBL();
                            dtDep = pbl.SelectByDepartmentID(BaseLib.Convert_Int(ddldepartment.SelectedValue));
                            ddlposition.DataSource = dtDep;
                            ddlposition.DataTextField = "Description";
                            ddlposition.DataValueField = "ID";
                            ddlposition.DataBind();
                            ddlposition.Items.Insert(0, "");
                            if (!String.IsNullOrWhiteSpace(dt.Rows[i]["position"].ToString()))
                            {
                                ddlposition.Items.FindByValue(dt.Rows[i]["position"].ToString()).Selected = true;
                                if (!String.IsNullOrWhiteSpace(ddlposition.SelectedValue))
                                {
                                    int type = BaseLib.Convert_Int(ddlposition.SelectedValue);
                                    Working_History_BL webbl = new Working_History_BL();
                                    DataTable dtb = new DataTable();
                                    dtb = webbl.SelectedByPosition(type);
                                    chkjobdescription.DataSource = dtb;
                                    chkjobdescription.DataTextField = "Description";
                                    chkjobdescription.DataValueField = "ID";
                                    chkjobdescription.DataBind();
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Column5"].ToString()))
                            {
                                string[] strarr = (dt.Rows[rowIndex]["Column5"].ToString().Split(','));
                                for (int j = 0; j < strarr.Length; j++)
                                {
                                    if (chkjobdescription.Items.FindByValue(strarr[j]) != null)
                                    {
                                        chkjobdescription.Items.FindByValue(strarr[j]).Selected = true;
                                    }
                                }
                            }
                        }
                        rowIndex++;
                    }
                }
                DataTable dt1 = (DataTable)ViewState["CurrentTable"];
                if (dt1.Rows.Count > 1)
                {
                    LinkButton LinkButton1 = Gridview1.HeaderRow.FindControl("LinkButton1") as LinkButton;
                    LinkButton1.Visible = true;
                }
            }
        }

        protected void Gridview1_On_Row_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlIndustry = (e.Row.FindControl("ddlindustrytype") as DropDownList);
                ddlIndustry.DataSource = BindIndustry();
                ddlIndustry.DataTextField = "Description";
                ddlIndustry.DataValueField = "ID";
                ddlIndustry.DataBind();
                ddlIndustry.Items.Insert(0, "");

                DropDownList ddldepartment = (e.Row.FindControl("ddldepartment") as DropDownList);
                ddldepartment.DataSource = BindDepartment();
                ddldepartment.DataTextField = "Description";
                ddldepartment.DataValueField = "ID";
                ddldepartment.DataBind();
                ddldepartment.Items.Insert(0, "");

                DropDownList ddlpositionlevel = (e.Row.FindControl("ddlpositionlevel") as DropDownList);
                ddlpositionlevel.DataSource = BindPositionLevel();
                ddlpositionlevel.DataTextField = "Description";
                ddlpositionlevel.DataValueField = "ID";
                ddlpositionlevel.DataBind();
                ddlpositionlevel.Items.Insert(0, "");

                DropDownList ddlcompanytype = (e.Row.FindControl("ddlcompanytype") as DropDownList);
                ddlcompanytype.DataSource = BindCompanyType();
                ddlcompanytype.DataTextField = "Description";
                ddlcompanytype.DataValueField = "ID";
                ddlcompanytype.DataBind();
                ddlcompanytype.Items.Insert(0, "");
            }
        }

        public DataTable BindIndustry()
        {
            DataTable dtb = new DataTable();
            try
            {
                Working_History_BL webbl = new Working_History_BL();
                dtb = webbl.BindIndustry();
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BindDepartment()
        {
            try
            {
                GlobalBL global = new GlobalBL();
                DataTable dtbdeparment = global.Get_Datanew("Department");
                return dtbdeparment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BindCompanyType()
        {
            try
            {
                GlobalBL global = new GlobalBL();
                DataTable dttype = global.Get_Datanew("Company_Type");
                return dttype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BindPositionLevel()
        {
            DataTable dtb = new DataTable();
            try
            {
                Working_History_BL webbl = new Working_History_BL();
                dtb = webbl.BindPositionLevel();
                return dtb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["PreviousTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["PreviousTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
                    }
                }
                ViewState["PreviousTable"] = dt;
                //Re bind the GridView for the updated data
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                int rowIndex = 0;
                foreach (GridViewRow row in Gridview1.Rows)
                {
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcompanyname");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtcomapnyaddress");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtFromDate");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtToDate");
                    TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtreasonforleaving");
                    TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtother");
                    DropDownList ddlIndustry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlindustrytype") as DropDownList;
                    DropDownList ddlbusiness = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddltypeofbusiness") as DropDownList;
                    DropDownList ddldepartment = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddldepartment") as DropDownList;
                    DropDownList ddlposition = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlPosition") as DropDownList;
                    DropDownList ddlpositionlevel = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlpositionlevel") as DropDownList;
                    DropDownList ddlcompanytype = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcompanytype") as DropDownList;
                    DropDownList ddlcountry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcountry") as DropDownList;
                    CheckBoxList chkjobdescription = (CheckBoxList)Gridview1.Rows[rowIndex].Cells[0].FindControl("chkjobdescription") as CheckBoxList;
                    Label lblotherjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblotherjp") as Label;
                    Label lblreasongjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleavingjp") as Label;
                    Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyname");
                    Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblcompanyaddress");
                    Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                    Label lbl7 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblduration");
                    Label lbl8 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lbljobdescription");
                    Label lbl9 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleaving");
                    Label lbl10 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblother");

                    box1.Text = dt.Rows[rowIndex]["Company_Name"].ToString();
                    box2.Text = dt.Rows[rowIndex]["Company_Address"].ToString();
                    box3.Text = dt.Rows[rowIndex]["Duration_From"].ToString();
                    box4.Text = dt.Rows[rowIndex]["Duration_To"].ToString();
                    box6.Text = dt.Rows[rowIndex]["Reason_For_Leaving"].ToString();
                    box7.Text = dt.Rows[rowIndex]["Other"].ToString();
                    lblotherjp.Text = dt.Rows[rowIndex]["Other_Japan"].ToString();
                    lblreasongjp.Text = dt.Rows[rowIndex]["Reason_For_Leaving_Japan"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Position_Level"].ToString()))
                    {
                        ddlpositionlevel.Items.FindByText(dt.Rows[rowIndex]["Position_Level"].ToString()).Selected = true;
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Company_Type"].ToString()))
                    {
                        ddlcompanytype.Items.FindByText(dt.Rows[rowIndex]["Company_Type"].ToString()).Selected = true;
                        DataTable dtb = new DataTable();
                        BusinessTypeBL bussinessbl = new BusinessTypeBL();
                        dtb = bussinessbl.Selectedbycompanytype(BaseLib.Convert_Int(ddlcompanytype.SelectedValue));
                        ddlcountry.DataSource = dtb;
                        ddlcountry.DataTextField = "Description";
                        ddlcountry.DataValueField = "ID";
                        ddlcountry.DataBind();
                        ddlcountry.Focus();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Country"].ToString()))
                        {
                            ddlcountry.Items.FindByText(dt.Rows[rowIndex]["Country"].ToString()).Selected = true;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Industry"].ToString()))
                    {
                        ddlIndustry.Items.FindByText(dt.Rows[rowIndex]["Industry"].ToString()).Selected = true;
                        DataTable dtb = new DataTable();
                        BusinessTypeBL bussinessbl = new BusinessTypeBL();
                        dtb = bussinessbl.SelectedbyTypeofBusiness(BaseLib.Convert_Int(ddlIndustry.SelectedValue));
                        ddlbusiness.DataSource = dtb;
                        ddlbusiness.DataTextField = "Description";
                        ddlbusiness.DataValueField = "ID";
                        ddlbusiness.DataBind();
                        ddlbusiness.Focus();
                        if (!string.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Business_Type"].ToString()))
                        {
                            ddlbusiness.Items.FindByText(dt.Rows[rowIndex]["Business_Type"].ToString()).Selected = true;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Department"].ToString()))
                    {
                        ddldepartment.Items.FindByText(dt.Rows[rowIndex]["Department"].ToString()).Selected = true;
                        DataTable dtDep = new DataTable();
                        PositionBL pbl = new PositionBL();
                        dtDep = pbl.SelectByDepartmentID(BaseLib.Convert_Int(ddldepartment.SelectedValue));
                        ddlposition.DataSource = dtDep;
                        ddlposition.DataTextField = "Description";
                        ddlposition.DataValueField = "ID";
                        ddlposition.DataBind();
                        ddlposition.Items.Insert(0, "");
                        if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Position"].ToString()))
                        {
                            ddlposition.Items.FindByText(dt.Rows[rowIndex]["Position"].ToString()).Selected = true;
                            if (!String.IsNullOrWhiteSpace(ddlposition.SelectedValue))
                            {
                                int type = BaseLib.Convert_Int(ddlposition.SelectedValue);
                                Working_History_BL webbl = new Working_History_BL();
                                DataTable dtb = new DataTable();
                                dtb = webbl.SelectedByPosition(type);
                                chkjobdescription.DataSource = dtb;
                                chkjobdescription.DataTextField = "Description";
                                chkjobdescription.DataValueField = "ID";
                                chkjobdescription.DataBind();
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Job_Description_ID"].ToString()))
                        {
                            string[] strarr = (dt.Rows[rowIndex]["Job_Description_ID"].ToString().Split(','));
                            for (int j = 0; j < strarr.Length; j++)
                            {
                                if (chkjobdescription.Items.FindByValue(strarr[j]) != null)
                                {
                                    chkjobdescription.Items.FindByValue(strarr[j]).Selected = true;
                                }
                            }
                        }
                        rowIndex++;
                    }
                }
                if (dt.Rows.Count > 1)
                {
                    LinkButton LinkButton1 = Gridview1.HeaderRow.FindControl("LinkButton1") as LinkButton;
                    LinkButton1.Visible = true;
                }
            }
            else if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
                    }
                }
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
                int rowIndex = 0;
                foreach (GridViewRow row in Gridview1.Rows)
                {
                    TextBox comanyname = row.FindControl("txtcompanyname") as TextBox;
                    TextBox companyaddress = row.FindControl("txtcomapnyaddress") as TextBox;
                    TextBox fromdate = row.FindControl("txtFromDate") as TextBox;
                    TextBox todate = row.FindControl("txtToDate") as TextBox;
                    TextBox reasonforleaving = row.FindControl("txtreasonforleaving") as TextBox;
                    TextBox other = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txtother");
                    DropDownList ddlIndustry = row.FindControl("ddlindustrytype") as DropDownList;
                    DropDownList ddlbusiness = row.FindControl("ddltypeofbusiness") as DropDownList;
                    DropDownList ddldepartment = row.FindControl("ddldepartment") as DropDownList;
                    DropDownList ddlposition = row.FindControl("ddlPosition") as DropDownList;
                    DropDownList ddlpositionlevel = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlpositionlevel") as DropDownList;
                    DropDownList ddlcompanytype = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcompanytype") as DropDownList;
                    DropDownList ddlcountry = (DropDownList)Gridview1.Rows[rowIndex].Cells[0].FindControl("ddlcountry") as DropDownList;
                    CheckBoxList chkjobdescription = (CheckBoxList)Gridview1.Rows[rowIndex].Cells[0].FindControl("chkjobdescription") as CheckBoxList;
                    Label lblotherjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblotherjp") as Label;
                    Label lblreasongjp = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("lblreasonforleavingjp") as Label;
                    comanyname.Text = dt.Rows[rowIndex]["Column1"].ToString();
                    companyaddress.Text = dt.Rows[rowIndex]["Column2"].ToString();
                    fromdate.Text = dt.Rows[rowIndex]["Column3"].ToString();
                    todate.Text = dt.Rows[rowIndex]["Column4"].ToString();
                    reasonforleaving.Text = dt.Rows[rowIndex]["Column6"].ToString();
                    other.Text = dt.Rows[rowIndex]["other"].ToString();
                    lblotherjp.Text = dt.Rows[rowIndex]["otherjp"].ToString();
                    lblreasongjp.Text = dt.Rows[rowIndex]["reasonjp"].ToString();
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["positionlevel"].ToString()))
                    {
                        ddlpositionlevel.Items.FindByValue(dt.Rows[rowIndex]["positionlevel"].ToString()).Selected = true;
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["companytype"].ToString()))
                    {
                        ddlcompanytype.Items.FindByValue(dt.Rows[rowIndex]["companytype"].ToString()).Selected = true;
                        DataTable dtb = new DataTable();
                        BusinessTypeBL bussinessbl = new BusinessTypeBL();
                        dtb = bussinessbl.Selectedbycompanytype(BaseLib.Convert_Int(ddlcompanytype.SelectedValue));
                        ddlcountry.DataSource = dtb;
                        ddlcountry.DataTextField = "Description";
                        ddlcountry.DataValueField = "ID";
                        ddlcountry.DataBind();
                        ddlcountry.Focus();
                        if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["country"].ToString()))
                        {
                            ddlcountry.Items.FindByValue(dt.Rows[rowIndex]["country"].ToString()).Selected = true;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["industry"].ToString()))
                    {
                        ddlIndustry.Items.FindByValue(dt.Rows[rowIndex]["industry"].ToString()).Selected = true;
                        DataTable dtb = new DataTable();
                        BusinessTypeBL bussinessbl = new BusinessTypeBL();
                        dtb = bussinessbl.SelectedbyTypeofBusiness(BaseLib.Convert_Int(ddlIndustry.SelectedValue));
                        ddlbusiness.DataSource = dtb;
                        ddlbusiness.DataTextField = "Description";
                        ddlbusiness.DataValueField = "ID";
                        ddlbusiness.DataBind();
                        ddlbusiness.Focus();
                        ddlbusiness.Items.FindByValue(dt.Rows[rowIndex]["business"].ToString()).Selected = true;
                    }
                    if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["deparment"].ToString()))
                    {
                        ddldepartment.Items.FindByValue(dt.Rows[rowIndex]["deparment"].ToString()).Selected = true;
                        DataTable dtDep = new DataTable();
                        PositionBL pbl = new PositionBL();
                        dtDep = pbl.SelectByDepartmentID(BaseLib.Convert_Int(ddldepartment.SelectedValue));
                        ddlposition.DataSource = dtDep;
                        ddlposition.DataTextField = "Description";
                        ddlposition.DataValueField = "ID";
                        ddlposition.DataBind();
                        ddlposition.Items.Insert(0, "");
                        ddlposition.Items.FindByValue(dt.Rows[rowIndex]["position"].ToString()).Selected = true;
                        if (!String.IsNullOrWhiteSpace(dt.Rows[rowIndex]["Column5"].ToString()))
                        {
                            string[] strarr = (dt.Rows[rowIndex]["Column5"].ToString().Split(','));
                            for (int j = 0; j < strarr.Length; j++)
                            {
                                if (chkjobdescription.Items.FindByValue(strarr[j]) != null)
                                {
                                    chkjobdescription.Items.FindByValue(strarr[j]).Selected = true;
                                }
                            }
                        }
                    }
                    rowIndex++;
                }
                if (dt.Rows.Count > 1)
                {
                    LinkButton LinkButton1 = Gridview1.HeaderRow.FindControl("LinkButton1") as LinkButton;
                    LinkButton1.Visible = true;
                }
            }
        }

        public void CreatenewDataTable()
        {
            DataTable dtnew = new DataTable();
            DataRow dr = null;
            dtnew.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dtnew.Columns.Add(new DataColumn("companyname", typeof(string)));
            dtnew.Columns.Add(new DataColumn("companyaddress", typeof(string)));
            dtnew.Columns.Add(new DataColumn("companytype", typeof(string)));
            dtnew.Columns.Add(new DataColumn("country", typeof(string)));
            dtnew.Columns.Add(new DataColumn("fromdate", typeof(string)));
            dtnew.Columns.Add(new DataColumn("todate", typeof(string)));
            dtnew.Columns.Add(new DataColumn("jobdescripition", typeof(string)));
            dtnew.Columns.Add(new DataColumn("reason", typeof(string)));
            dtnew.Columns.Add(new DataColumn("industry", typeof(string)));
            dtnew.Columns.Add(new DataColumn("business", typeof(string)));
            dtnew.Columns.Add(new DataColumn("deparment", typeof(string)));
            dtnew.Columns.Add(new DataColumn("position", typeof(string)));
            dtnew.Columns.Add(new DataColumn("other", typeof(string)));
            dtnew.Columns.Add(new DataColumn("positionlevel", typeof(string)));
            dtnew.Columns.Add(new DataColumn("otherjp", typeof(string)));
            dtnew.Columns.Add(new DataColumn("reasonjp", typeof(string)));
            ViewState["DataTablenew"] = dtnew;
        }

        public void rdocheckchange(object sender, EventArgs e)
        {
            if (rdocheckimmediate.Checked)
            {
                txtnoticeday.Visible = false;
                ddlnoticetype.Visible = false;
            }
            else
            {
                txtnoticeday.Visible = true;
                ddlnoticetype.Visible = true;
            }
        }

        protected void rdosatyes_oncheckchanged(object sender, EventArgs e)
        {
            if (rdosatyes.Checked)
            {
                ddlsatdaycondition.Visible = true;
            }
            else
            {
                ddlsatdaycondition.Visible = false;
            }
        }
    }
}