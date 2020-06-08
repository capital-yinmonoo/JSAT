using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSAT_Common;
using JSAT_BL;
using System.Data;
using JSAT_BL.Employee;
using JSAT_Ver1;

namespace JSAT
{
    public partial class WorkingHistory_Detail : System.Web.UI.Page
    {
        WorkingHistoryEntity entity = new WorkingHistoryEntity();

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
            if (!IsPostBack)
            {
                Working_History_BL workinghistorybl = new Working_History_BL();
                Career_QualificationBL cqbl = new Career_QualificationBL();
                Career_AbilityBL cabl = new Career_AbilityBL();
                if (Request.QueryString["Career_ID"] != null)
                {
                    int Career_ID = int.Parse(Request.QueryString["Career_ID"]);
                    entity = workinghistorybl.SelectedbyID(Career_ID);
                    DataTable dtpcskill = new DataTable();
                    dtpcskill = workinghistorybl.SelectedbyIDforpcskill(Career_ID);
                    DataSet dsqual = new DataSet();
                    dsqual = cqbl.Select_Qualification_Title_Item_ByID(Career_ID);
                    DataSet dsabl = new DataSet();
                    dsabl = cabl.Select_Ability_Title_Item_ByID(Career_ID);
                    DataTable dtpersonalskill = new DataTable();
                    dtpersonalskill = workinghistorybl.SelectedbyIDforpersonalskill(Career_ID);
                    DataTable dtlocation = workinghistorybl.SelectedbyIDforlocation(Career_ID);
                    FillWrokingHistory(entity, dtpersonalskill, dtpcskill, dtlocation, dsqual, dsabl);
                    DataTable dtoldjob = new DataTable();
                    dtoldjob = workinghistorybl.SelectedbyOldjobhistoryForDetail(Career_ID);
                    DataTable dtjobdescripition = new DataTable();
                    dtoldjob.Columns.Add("Job_Description", typeof(string));
                    for (int j = 0; j < dtoldjob.Rows.Count; j++)
                    {
                        string strjobd = string.Empty;
                        strjobd = dtoldjob.Rows[j]["Job_Description_ID"].ToString();
                        dtjobdescripition = workinghistorybl.SelectbyJobDescription(Career_ID, strjobd);
                        string concatjobd = string.Empty;
                        for (int i = 0; i < dtjobdescripition.Rows.Count; i++)
                        {
                            concatjobd += dtjobdescripition.Rows[i]["Description"].ToString();
                            if (i != dtjobdescripition.Rows.Count - 1)
                            {
                                concatjobd += ",";
                            }
                        }
                        dtoldjob.Rows[j]["Job_Description"] = concatjobd.ToString();
                    }
                    FillOldjobhistory(dtoldjob, Career_ID);
                }
            }
        }

        protected void DLQualification_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Qualification_Relation");
                innerDataList.DataBind();
            }
        }

        protected void DLAbility_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                DataList innerDataList = e.Item.FindControl("innerDataList1") as DataList;
                innerDataList.DataSource = drv.CreateChildView("Ability_Relation");
                innerDataList.DataBind();
            }
        }
        public void FillWrokingHistory(WorkingHistoryEntity entity, DataTable dtpersonalskill, DataTable dtpcskill, DataTable dtlocation, DataSet dsqual, DataSet dsabl)
        {
            lblcode.Text = entity.Career_code;
            
            //lblgender.Text = entity.Gender1;
            if(entity.Gender== "1")
            {
                lblgender.Text = "Male";
            }
            if (entity.Gender == "2")
            {
                lblgender.Text = "Female";
            }
            lblname.Text = entity.Name;
            lblage.Text = entity.Age.ToString();

            lblfirstinterviewer.Text = entity.FirstInt;
            lblsecondinterviewer.Text = entity.SecondInt;
            lbljapaneseinterviewer.Text = entity.JapaneseInt;
            if (!String.IsNullOrWhiteSpace(entity.Interviewdate.ToString()))
            {
                string interviewdate = entity.Interviewdate.ToString();
                lblinterviewdate.Text = GlobalUI.FormatDatenew(interviewdate);
            }
            if (entity.Drivinglicense == "True")
            {
                lbldrivinglicense.Text = "Yes";
            }
            else
            {
                lbldrivinglicense.Text = "No";
            }
            lbladdress.Text = entity.Address;
            lblPhoneNo.Text = entity.Phone;
            lblReligion.Text = entity.Religion1;
            //lblReligion.Text = entity.Religion;
            lblEcontact.Text = entity.EmergencyContactPerson;
            lblEPhone.Text = entity.EmergencyContactPhone;
            lblEmail.Text = entity.Email;
            lbldegree1.Text = entity.Degreename1;
            lbluniversity1.Text = entity.Universityname1;
            lblmajor1.Text = entity.Majorname1;
            lblyear1.Text = entity.Year1;
            lbltownship1.Text = entity.Townshipname1;
            lbldegree2.Text = entity.Degreename2;
            lbluniversity2.Text = entity.Universityname2;
            lblmajor2.Text = entity.Majorname2;
            lblyear2.Text = entity.Year2;
            lbltownship2.Text = entity.Townshipname2;
            if (entity.Workingexperience == "True")
            {
                lblworkingexp.Text = "Yes";
            }
            else
            {
                lblworkingexp.Text = "No";
            }
            lblstatus.Text = entity.Career_status;
            positionrequested.Text = entity.PositinName;
            positionrequested1.Text = entity.PositionName1;
            positionrequested2.Text = entity.PositionName2;
            postionlevel1.Text = entity.Positionlevelname1;
            postionlevel2.Text = entity.Positionlevelname2;
            postionlevel3.Text = entity.Positionlevelname3;
            if (entity.Worksatday == "True")
            {
                workonsatday.Text = "Yes";
            }
            else
            {
                workonsatday.Text = "No";
            }
            string worka = string.Empty;
            if (entity.Thilawa == 1)
            {
                worka += "Thilawa   ";
            }
            else if (entity.Thilawa == 3)
            {
                worka += "Thilawa(Ferry)     ";
            }
            else
            {
                worka += "";
            }
            if (entity.Hlaingtharyar == 1)
            {
                if (entity.Thilawa != 0 && entity.Thilawa != 2)
                {
                    worka += ",";
                }
                worka += "Hlaingtharyar  ";
            }
            else if (entity.Hlaingtharyar == 3)
            {
                if (entity.Thilawa != 0 && entity.Thilawa != 2)
                {
                    worka += ",";
                }
                worka += "Hlaingtharyar(Ferry)  ";
            }
            else
            {
                worka += "";
            }
            if (entity.Oversea == 1)
            {
                if ((entity.Thilawa != 0 && entity.Thilawa != 2) || (entity.Hlaingtharyar != 0 && entity.Hlaingtharyar != 2))
                {
                    worka += ",";
                }
                worka += "Oversea   ";
            }
            else
            {
                worka += "";
            }

            if (entity.Overseatraining == 1)
            {
                if ((entity.Thilawa != 0 && entity.Thilawa != 2) || (entity.Hlaingtharyar != 0 && entity.Hlaingtharyar != 2) || (entity.Oversea != 0 && entity.Oversea != 2))
                {
                    worka += ",";
                }
                worka += "OverSeaTraining    ";
            }
            else
            {
                worka += "";
            }
            workarea.Text = worka;
            satdaycondition.Text = entity.SatConditionName;
            expectedsalry.Text = entity.Expectedsalary.ToString();
            salarytype.Text = entity.SalaryTypeName1;
            if (!String.IsNullOrWhiteSpace(entity.Desireddate.ToString()))
            {
                string desireddate1 = entity.Desireddate.ToString();
                desireddate.Text = GlobalUI.FormatDatenew(desireddate1);
            }
            if (entity.Noticetypename != "")
            {
                if (entity.Noticetypename == "Immediate")
                {
                    NoticeType.Text = entity.Noticetypename;
                }
                else
                {
                    NoticeDay.Text = entity.Noticedayname;
                    NoticeType.Text = entity.Noticetypename;
                }
            }
            qualification.Text = entity.Qualification;
            other.Text = entity.Other;
            updatett.Text = entity.UpdateInfo;
            lblid.Text = entity.Career_ID.ToString();
            string str = string.Empty;
            for (int i = 0; i < dtpcskill.Rows.Count; i++)
            {
                str += dtpcskill.Rows[i]["PCSkills"].ToString();
                if (i != dtpcskill.Rows.Count - 1)
                {
                    str += ",";
                }
            }
            pcskill.Text = str;
            //string strqual = string.Empty;
            //for (int i = 0; i < dtqual.Rows.Count; i++)
            //{
            //    strqual += dtqual.Rows[i]["Qualification"].ToString();
            //    if (i != dtqual.Rows.Count - 1)
            //    {
            //        strqual += ",";
            //    }
            //}
            //qual.Text = strqual;
            dsqual.Relations.Add(new DataRelation("Qualification_Relation", dsqual.Tables[0].Columns["ID"], dsqual.Tables[1].Columns["QualificationTitle_id"], false));
            DLQualification.DataSource = dsqual.Tables[0];
            DLQualification.DataBind();

            //string strAbl = string.Empty;
            //for (int i = 0; i < dtabl.Rows.Count; i++)
            //{
            //    strAbl += dtabl.Rows[i]["Ability"].ToString();
            //    if (i != dtabl.Rows.Count - 1)
            //    {
            //        strAbl += " ";
            //    }
            //}
            //abl.Text = strAbl;
            dsabl.Relations.Add(new DataRelation("Ability_Relation", dsabl.Tables[0].Columns["ID"], dsabl.Tables[1].Columns["AbilityTitle_id"], false));
            DLAbility.DataSource = dsabl.Tables[0];
            DLAbility.DataBind();


            string strlocation = string.Empty;
            for (int i = 0; i < dtlocation.Rows.Count; i++)
            {
                strlocation += dtlocation.Rows[i]["WorkingPlace"].ToString();
                if (i != dtlocation.Rows.Count - 1)
                {
                    strlocation += ",";
                }
            }
            locationrequested.Text = strlocation;
            string str1 = string.Empty;
            for (int i = 0; i < dtpersonalskill.Rows.Count; i++)
            {
                if (dtpersonalskill.Rows[i]["Type"].ToString() == "Cleanliness")
                    personalskill1.Text = dtpersonalskill.Rows[i]["Type"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Respect")
                    personalskill2.Text = dtpersonalskill.Rows[i]["Type"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Positiveness")
                    personalskill3.Text = dtpersonalskill.Rows[i]["Type"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Presentation")
                    personalskill4.Text = dtpersonalskill.Rows[i]["Type"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Impression")
                    personalskill5.Text = dtpersonalskill.Rows[i]["Type"].ToString();
                total.Text = "Total_Marks";
                if (dtpersonalskill.Rows[i]["Type"].ToString() == "Cleanliness")
                    mark1.Text = dtpersonalskill.Rows[i]["Mark"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Respect")
                    mark2.Text = dtpersonalskill.Rows[i]["Mark"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Positiveness")
                    mark3.Text = dtpersonalskill.Rows[i]["Mark"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Presentation")
                    mark4.Text = dtpersonalskill.Rows[i]["Mark"].ToString();
                else if (dtpersonalskill.Rows[i]["Type"].ToString() == "Impression")
                    mark5.Text = dtpersonalskill.Rows[i]["Mark"].ToString();
                totalmarks.Text = entity.TotalMarks.ToString();
            }
            engreadwrite.Text = entity.Ereadwrite;
            engspeak.Text = entity.Espeaking;
            jpreadwrite.Text = entity.Jreadwrite;
            jpspeak.Text = entity.Jspeaking;
            string workingarea = string.Empty;
        }

        public void FillOldjobhistory(DataTable dtoldjobhistory, int Career_ID)
        {
            Working_History_BL workinghistorybl = new Working_History_BL();
            dljobhistory.DataSource = dtoldjobhistory;
            dljobhistory.DataBind();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/WorkingHistory.aspx?Career_ID=" + Career_ID);
        } 
    }
}

