using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;
using System.Transactions;
using JSAT_Common.Employee;
using JSAT_BL.Employee;
namespace JSAT_BL
{
    public class Working_History_BL
    {

        private int totalrowcount;
        WorkingHistoryDL wdl;

        public Working_History_BL()
        {
            wdl = new WorkingHistoryDL();
        }

        public DataTable GetBindData(string code1, string code2)
        {
            return wdl.GetBindData(code1, code2);
        }

        public DataSet BindDataForQualification()
        {
            return wdl.BindDataForQualification();
        }

        public DataSet BindDataForAbility()
        {
            return wdl.BindDataForAbiltity();
        }


        public int InsertData1(WorkingHistoryEntity entity1)
        {                   
            return wdl.InsertData1(entity1);
        }


        public void UpdateData(WorkingHistoryEntity entity, Career_PCSkillsEntity cpe, int id, Career_PersonalSkill cps, EnumBase.Save option, int careerid, DataTable dtnew, Career_WorkingPlaceEntity cwpe, Career_QualificationEntity cq, Career_AbilityEntity cae)
        {
            try
            {
                wdl = new WorkingHistoryDL();
                using (TransactionScope scope = new TransactionScope())
                {
                    wdl.UpdateData(entity, option, careerid);
                    if (option == EnumBase.Save.Update)
                    {
                        wdl.Deleteforupdate(careerid);
                    }
                    wdl.InsertOldJobHistory(dtnew, option, id);
                    for (int i = 0; i < cpe.PcSkills.Rows.Count; i++)
                    {
                        cpe.PcSkills.Rows[i]["Career_ID"] = id;
                    }
                    cpe.CareerId = Convert.ToInt32(id);
                    if (wdl.GetCheckboxlistData(cpe, id, option))
                    {
                        for (int i = 0; i < cps.Personal_skill.Rows.Count; i++)
                        {
                            cps.Personal_skill.Rows[i]["Career_ID"] = id;
                        }
                        cps.CareerId1 = Convert.ToInt32(id);
                        if (wdl.Getpersonalskill(cps, id, option))
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
                        //for Qualification
                        Career_QualificationBL cqbl = new Career_QualificationBL();
                        for (int i = 0; i < cq.Qualification.Rows.Count; i++)
                        {
                            cq.Qualification.Rows[i]["Career_ID"] = id;
                        }
                        cq.CareerId = id;
                        cqbl.Insert_Update(cq, option);
                        //for Ability
                        Career_AbilityBL caebl = new Career_AbilityBL();
                        for (int i = 0; i < cae.Ability.Rows.Count; i++)
                        {
                            cae.Ability.Rows[i]["Career_ID"] = id;
                        }
                        cae.CareerId = id;
                        caebl.Insert_Update(cae, option);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable GetDegree()
        {
            return wdl.GetDegree();
        }

        public WorkingHistoryEntity SelectedbyID(int id)
        {
            return wdl.SelectedbyID(id);
        }

        public DataTable SelectedbyIDforpcskill(int careerid)
        {
            return wdl.SelectedbyIDforpcskill(careerid);
        }

        public DataTable SelectbyIDForLocation(int careerid)
        {
            return wdl.SelectbyIDForLocation(careerid);
        }

        public DataTable SelectedbyIDforpersonalskill(int career_id)
        {
            return wdl.SelectedbyIDforpersonalskill(career_id);
        }

        public DataTable SelectedbyIDforlocation(int career_id)
        {
            return wdl.SelectedbyIDforlocation(career_id);
        }

        public DataTable SelectedbyOldjobhistory(int careerid)
        {
            return wdl.SelectedbyOldjobhistory(careerid);
        }

        public DataTable SelectedbyOldjobhistoryForDetail(int careerid)
        {
            return wdl.SelectedbyOldjobhistoryForDetail(careerid);
        }

        public DataTable SelectbyJobDescription(int careerid, string strjobd)
        {
            return wdl.SelectbyJobDescription(careerid, strjobd);
        }

        public DataTable Selectforedit(int careerid)
        {
            return wdl.Selectforedit(careerid);
        }

        public DataTable CheckCareerid(int id)
        {
            return wdl.CheckCareerid(id);
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return wdl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public bool DeleteSelectedID(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (wdl.DeleteWorkingHistroy(id))
                {
                    if (wdl.PCskillDelete(id))
                    {
                        if (wdl.PersonalSkillDelete(id))
                        {
                            scope.Complete();
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public DataTable BindIndustry()
        {
            return wdl.BindIndustry();
        }

        public DataTable SelectbyPosition(string positionid)
        {
            return wdl.SelectbyPosition(positionid);
        }

        public DataTable BindPositionLevel()
        {
            return wdl.BindPositionLevel();
        }

        public DataTable SelectedByPosition(int pos_id)
        {
            return wdl.SelectedByPosition(pos_id);
        }

        public DataTable Getlocationrequested(int type)
        {
            return wdl.Getlocationrequested(type);
        }

        public DataTable SelectedbyUniversityID(int index)
        {
            return wdl.SelectedbyUniversityID(index);
        }
    }
}
