using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;

namespace JSAT_BL
{
    public class Career_InterviewQuestion1BL
    {
        Career_InterviewQuestion1DL ciqdl;

        public Career_InterviewQuestion1BL()
        {
            ciqdl = new Career_InterviewQuestion1DL();
        }

        public Boolean Insert_Update(Career_InterviewQuestion1Entity ciqe, EnumBase.Save option)
        {
            return ciqdl.Insert_Update(ciqe, option);
        }

        public DataTable SelectByID(int careerId)
        {
            return ciqdl.SelectByID(careerId);
        }
    }
}
