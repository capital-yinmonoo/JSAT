using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;

namespace JSAT_BL
{
    public class Career_Job_InterviewBL
    {
        Career_Job_InterviewDL cji;

        public Career_Job_InterviewBL()
        {
            cji = new Career_Job_InterviewDL();
        }

        public Boolean Insert_Update(Career_Job_InterviewEntity cje, EnumBase.Save option)
        { 
            if(cji.Insert_Update(cje,option))
            {
                return true;
            }
            else return false;
        }

        public DataTable SelectByID(int Rec_ID, int Career_ID)
        {
            return cji.SelectByID(Rec_ID, Career_ID);               
        }

        public DataTable SelectByCareerID(int cid)
        {
            return cji.SelectByCareerID(cid);
        }

        public int GetCount(int Rec_ID, int Career_ID)
        {
            return cji.GetCount(Rec_ID, Career_ID);
        }
    }
}
