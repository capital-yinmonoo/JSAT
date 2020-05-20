using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;
using JSAT_Common;
using JSAT_DL.Reference;



namespace JSAT_BL
{
    public class InterViewQuestion3BL
    {
        InterviewQuestion3DL InvQuestion;
        public InterViewQuestion3BL()
        {
            InvQuestion = new InterviewQuestion3DL();
        }

        public DataTable SelectAll()
        {
            return InvQuestion.SelectAll();
        }
    }
}
