using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;
using System.Transactions;

namespace JSAT_BL
{
    public class Job_Career_InterviewBL
    {
        Job_Career_InterviewDL jobCareerInterview;

        public Job_Career_InterviewBL()
        {
            jobCareerInterview = new Job_Career_InterviewDL();
        }

        public DataTable SelectAll()
        {
            return jobCareerInterview.SelectAll();
        }

        public DataTable SelectByCareerIDAndClientRecruitment(int Client_RecruitmentID, int Client_ID)
        {
            return jobCareerInterview.SelectByCareerIDAndClientRecruitment(Client_RecruitmentID, Client_ID);
        }

        public DataTable SelectByID(int ID)
        {
            return jobCareerInterview.SelectByID(ID);
        }

        public DataTable SelectByClientRecruitmentID(int ClientRecruitmentID)
        {
            return jobCareerInterview.SelectByClientRecruitmentID(ClientRecruitmentID);
        }

        public string Insert(Job_Career_InterviewEntity jobCareerInterviewInfo, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (jobCareerInterview.Insert(jobCareerInterviewInfo, Option))
                {
                    scope.Complete();
                    return "Save success!";
                }
                return "Save fail!";
            }
        }

        public string Update(Job_Career_InterviewEntity jobCareerInterviewInfo, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (jobCareerInterview.Update(jobCareerInterviewInfo, Option))
                {
                    scope.Complete();
                    return "Save success!";
                }
                return "Save fail!";
            }
        }

        public Boolean DeleteByCareerID(int id)
        {
            return jobCareerInterview.DeleteByCareerID(id);
        }

        public string Delete(int ID)
        {
            string result = string.Empty;
            if (jobCareerInterview.Delete(ID))
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
            if (jobCareerInterview.DeleteAll())
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public int Check_ExistingCode(int ID, int Client_RecruitmentID, int Career_ID)
        {
            return jobCareerInterview.Check_ExistingCode(ID, Client_RecruitmentID, Career_ID);
        }

        public DataTable SelectByCriteria(string ClientName, string ClientCode, int? MajorIndustryID, int? SmallIndustryID)
        {
            return jobCareerInterview.SelectByCriteria(ClientName, ClientCode, MajorIndustryID, SmallIndustryID);
        }
    }
}
