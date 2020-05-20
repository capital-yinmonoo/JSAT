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
    public class IQTest_QuestionBL
    {
        IQTest_QuestionDL iqTestQuestion;

        public IQTest_QuestionBL()
        {
            iqTestQuestion = new IQTest_QuestionDL();
        }

        public DataTable SelectAll()
        {
            return iqTestQuestion.SelectAll();
        }

        public IQTest_QuestionEntity SelectByID(int id)
        {
            return iqTestQuestion.SelectByID(id);
        }
    }
}
