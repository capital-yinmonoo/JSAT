using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;

namespace JSAT_BL
{
    public class Career_Profile_QuestionBL
    {
        Career_Profile_QuestionDL career_profile_question;

        public Career_Profile_QuestionBL()
        {
            career_profile_question = new Career_Profile_QuestionDL();
        }

        public DataTable SelectByID(int Career_ID)
        {
            return career_profile_question.SelectByCareerProfileID(Career_ID);
        }

        public void Insert(DataTable dt, int Career_ID)
        {
            //to update ProfileID
            foreach (DataRow dr in dt.Rows)
            {
                dr["Career_ID"] = Career_ID;
            }
            career_profile_question.Insert(dt);
        }

        public void Update(DataTable dt, int Career_ID)
        {
            //to update ProfileID
            foreach (DataRow dr in dt.Rows)
            {
                dr["Career_ID"] = Career_ID;
            }
            career_profile_question.Update(dt);
        }

        public bool Delete(int Career_ID)
        {
            return career_profile_question.DeleteByProfileID(Career_ID);
        }
    }
}
