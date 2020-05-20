using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Career_InterviewBL
    {
        Career_InterviewDL ci;
        public Career_InterviewBL()
        {
            ci = new Career_InterviewDL();
        }

        public string Insert(Career_InterviewEntity ciInfo)
        { 
            if(ci.Insert(ciInfo))
                return "Insert Successful!";
            else return "Insert Fail!";
        }

        public string Update(Career_InterviewEntity ciInfo)
        {
            if (ci.Update(ciInfo))
                return "Update Successful!";
            else return "Update Fail!";
        }

        public Career_InterviewEntity SelectByCarrerID(int cid)
        {
            return ci.SelectByCareerID(cid);
        }
    }
}
