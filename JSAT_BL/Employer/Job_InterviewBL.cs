using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Job_InterviewBL
    {
        Job_InterviewDL ji;

        public Job_InterviewBL() 
        {
            ji = new Job_InterviewDL();
        }

        public string Insert(Job_InterviewEntity jiInfo)
        {
            if (ji.Insert(jiInfo))
                return "Save Successful ! ";
            return "Save Fail ! ";
        }

        public string Update(Job_InterviewEntity jiInfo)
        {
            if (ji.Update(jiInfo))
                return "Update Successful ! ";
            return "Update Fail ! ";
        }

        public Job_InterviewEntity SelectByClientRecruitmentID(int ceid)
        {
           return  ji.SelectByClientRecruitmentID(ceid);
        }
    }
}
