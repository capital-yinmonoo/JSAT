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
    public class Profile_QuestionBL
    {
        Profile_QuestionDL profileQuestion;

        public Profile_QuestionBL()
        {
            profileQuestion = new Profile_QuestionDL();
        }

        public DataTable SelectAll()
        {
            return profileQuestion.SelectAll();
        }

        public Profile_QuestionEntity SelectByID(int id)
        {
            return profileQuestion.SelectByID(id);
        }
    }
}
