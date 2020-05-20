using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;
using System.Transactions;
using JSAT_Common.Employee;
using JSAT_BL.Employee;

namespace JSAT_BL
{
    public class Career_ResumeBL
    {
        Career_ResumeDL careerResume;
        int totalrowcount;

        public Career_ResumeBL()
        {
            careerResume = new Career_ResumeDL();
        }

        public DataTable GetPDF(int Career_ID)
        {
            return careerResume.GetPDF(Career_ID);
        }

        public DataTable BindReligion()
        {
            return careerResume.BindReligion();
        }

        public DataTable SelectByCareerID(int id)
        {
            return careerResume.SelectByCareerID(id);
        }
        public DataTable SelectByTownship()
        {
            return careerResume.SelectTownship();
        }

        public DataTable SelectbyBusinessType()
        {
            return careerResume.SelectbyBusinessType();
        }

        public DataTable SelectedbyIndustry()
        {
            return careerResume.SelectedbyIndustry();
        }

        public DataTable Ability()
        {
            return careerResume.GetAbility();
        }

        public DataSet SelectAbility()
        {
            return careerResume.AbilitySelect();
        }

        public DataSet BindDataForAbility()
        {
            return careerResume.BindDataForAbiltity();
        }

        public DataTable AbilityTitle()
        {
            return careerResume.GetAbilityTitle();
        }

        public DataTable SelectAll()
        {
            return careerResume.SelectAll(0);
        }

        public DataTable SelectCareerCode()
        {
            return careerResume.SelectCareerCode(1);
        }

        public Career_ResumeEntity SelectByID(int id)
        {
            return careerResume.SelectByID(id);
        }

        public DataTable SelectByIDReport(int id)
        {
            return careerResume.SelectByIDReport(id);
        }

        public DataSet Report(int id)
        {
            return careerResume.Report(id);
        }

        public DataTable SelectQualificationByCareerID(int CareerID)
        {
            return careerResume.SelectQualificationByCareerID(CareerID);
        }

        public Career_ResumeEntity SelectByCareerCode(string Career_Code)
        {
            return careerResume.SelectByCareerCode(Career_Code);
        }

        public DataTable SelectByClientRecruitment(Career_ResumeEntity cre, int age1, int age2, int salary1, int salary2, int salaryformat)
        {
            return careerResume.SelectByClientRecruitment(cre, age1, age2, salary1, salary2, salaryformat);
        }

        public int Insert_Update(Career_ResumeEntity careerResumeInfo, Career_QualificationEntity cq, Career_AbilityEntity cae, Career_PCSkillsEntity cpe, Career_WorkingPlaceEntity cwpe, EnumBase.Save option, DataTable dtnew, DataTable dttext)
        {
            int id = 0;
            using (TransactionScope scope = new TransactionScope())
            {
                id = careerResume.Insert_Update(careerResumeInfo, option);
                careerResume.Insert_Update_Salary(dtnew, option, id);
                if (EnumBase.Save.Update == option)
                {
                    careerResume.Insert_Update_WorkingHistory(dttext, id);
                }
                if (id > 0)
                {
                    WorkingHistoryDL wdl = new WorkingHistoryDL();
                    for (int i = 0; i < cpe.PcSkills.Rows.Count; i++)
                    {
                        cpe.PcSkills.Rows[i]["Career_ID"] = id;
                    }
                    cpe.CareerId = Convert.ToInt32(id);
                    if (wdl.GetCheckboxlistData(cpe, id, option))
                    {
                        for (int i = 0; i < cwpe.WorkingPlace.Rows.Count; i++)
                        {
                            cwpe.WorkingPlace.Rows[i]["Career_ID"] = id;
                        }
                        cwpe.CareerId = Convert.ToInt32(id);
                        if (wdl.InsertLocationrequest(cwpe, id, option))
                        {
                        }
                    }
                    //For Qualification
                    Career_QualificationBL cqbl = new Career_QualificationBL();
                    for (int i = 0; i < cq.Qualification.Rows.Count; i++)
                    {
                        cq.Qualification.Rows[i]["Career_ID"] = id;
                    }
                    cq.CareerId = id;
                    if (cqbl.Insert_Update(cq, option))
                    {
                        Career_AbilityBL caebl = new Career_AbilityBL();

                        for (int i = 0; i < cae.Ability.Rows.Count; i++)
                        {
                            cae.Ability.Rows[i]["Career_ID"] = id;
                        }
                        cae.CareerId = id;
                        caebl.Insert_Update(cae, option);
                    }
                }
                scope.Complete();
            }
            return id;
        }

        public string Delete(int ID, int sessionID, DateTime date)
        {
            string result = string.Empty;
            if (careerResume.Delete(ID, sessionID, date))
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public string DeleteAll()
        {
            string result = string.Empty;
            if (careerResume.DeleteAll())
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public bool DeleteFromAllCareerTable(int id, int sessionID, DateTime date)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (careerResume.Delete(id, sessionID, date))
                {
                    CareerEmploymentBL employmentBL = new CareerEmploymentBL();
                    if (employmentBL.DeleteByCareerID(id))
                    {
                        Career_InformationBL careerInfoBL = new Career_InformationBL();
                        if (careerInfoBL.DeletebyCareerID(id))
                        {
                            Career_Interview1BL interview1 = new Career_Interview1BL();
                            if (interview1.DeleteByCareerID(id))
                            {
                                Career_InterviewQuestion3BL interview3 = new Career_InterviewQuestion3BL();
                                if (interview3.DeleteByCareerID(id))
                                {
                                    Career_PCSkillsBL pcSkillBL = new Career_PCSkillsBL();
                                    if (pcSkillBL.Delete(id))
                                    {
                                        Career_QualificationBL cqbl = new Career_QualificationBL();
                                        if (cqbl.Delete(id))
                                        {
                                            Career_WorkingPlaceBL cwpbl = new Career_WorkingPlaceBL();
                                            if (cwpbl.Delete(id))
                                            {
                                                Job_Career_InterviewBL jcibl = new Job_Career_InterviewBL();
                                                if (jcibl.DeleteByCareerID(id))
                                                {
                                                    scope.Complete();
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }
        }

        public bool Check_Record(string code, int ID)
        {
            int count = careerResume.Check_ExistingCode(code, ID);
            if (count >= 1)
                return true;//records exist.
            else
                return false;
        }

        public DataTable SelectByCriteria(ref Career_ResumeEntity.Criterias Criteria)
        {
            return careerResume.SelectByCriteria(ref Criteria);
        }

        public DataTable SearchData(ref Career_ResumeEntity.Criterias Criteria, int pindex, int psize)
        {
            return careerResume.SearchData(ref Criteria, pindex, psize);
        }

        public DataTable SearchAndPaging(string search, int exptype, string sort, int startIndex, int pagesize)
        {
            return careerResume.SearchAndPaging(search, exptype, sort, startIndex, pagesize, out totalrowcount);
        }

        public int TotalRowCount(string search, int exptype)
        {
            return totalrowcount;
        }

        public DataTable SearchByName(String Name, String Code1, String Code)
        {
            return careerResume.SearchByName(Name, Code1, Code);
        }

        public int InsertCareerInterviewInfo(Career_ResumeEntity careerResumeInfo, Career_QualificationEntity cq, Career_PCSkillsEntity cpe, Career_WorkingPlaceEntity cwpe, EnumBase.Save option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                int id = 0;
                if (!Check_Record(careerResumeInfo.Career_Code, careerResumeInfo.ID))//if no record found ,
                {
                    id = careerResume.Insert_Update(careerResumeInfo, option);
                    if (id > 0)
                    {
                        Career_QualificationBL cqbl = new Career_QualificationBL();
                        for (int i = 0; i < cq.Qualification.Rows.Count; i++)
                        {
                            cq.Qualification.Rows[i]["Career_ID"] = id;
                        }
                        cq.CareerId = id;
                        if (cqbl.Insert_Update(cq, option))
                        {
                            Career_PCSkillsBL cpbl = new Career_PCSkillsBL();
                            for (int i = 0; i < cpe.PcSkills.Rows.Count; i++)
                            {
                                cpe.PcSkills.Rows[i]["Career_ID"] = id;
                            }
                            cpe.CareerId = id;
                            if (cpbl.Insert_Update(cpe, option))
                            {
                                Career_WorkingPlaceBL cwpbl = new Career_WorkingPlaceBL();
                                for (int i = 0; i < cwpe.WorkingPlace.Rows.Count; i++)
                                {
                                    cwpe.WorkingPlace.Rows[i]["Career_ID"] = id;
                                }
                                cwpe.CareerId = id;
                                if (cwpbl.Insert_Update(cwpe, option))
                                {
                                    if (option == EnumBase.Save.Insert)
                                    {
                                        Career_InterviewEntity cie = new Career_InterviewEntity();
                                        Career_InterviewBL ci = new Career_InterviewBL();
                                        cie.Career_ID = id;
                                    }
                                    scope.Complete();
                                }
                            }
                        }
                    }
                }
                return id;
            }
        }

        public DataTable SelectBycareerInterview(int cid)
        {
            return careerResume.SelectByInterview(cid);
        }

        public void Insert_Career_Status(int cid, int careerstatusid)
        {
            careerResume.Insert_Career_Status(cid, careerstatusid);
        }

        public DataTable SelectBySalary_CareerID(int careerid)
        {
            return careerResume.SelectBySalary_CareerID(careerid);
        }

        public DataTable SelectedbySalaryIDDetail(int careerid)
        {
            return careerResume.SelectedbySalaryIDdetail(careerid);
        }

        public DataTable SelectedByWorkingHistoryForCareer_Resume(int careerid)
        {
            return careerResume.SelectedByWorkingHistoryForCareer_Resume(careerid);
        }

        public DataTable GetImpressionData(string impression)
        {
            return careerResume.GetImpressionData(impression);
        }

        public DataTable GetOtherData(string other)
        {
            return careerResume.GetOtherData(other);
        }

    }
}
