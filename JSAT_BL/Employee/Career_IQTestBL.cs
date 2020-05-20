using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;

namespace JSAT_BL
{
    public class Career_IQTestBL
    {
        Career_IQTestDL career_iqtest;

        public Career_IQTestBL()
        {
            career_iqtest = new Career_IQTestDL();
        }

        public DataTable SelectByID(int Career_ID)
        {
            return career_iqtest.SelectByCareerProfileID(Career_ID);
        }

        public void Insert(DataTable dt, int Career_ID)
        {
            //to update ProfileID
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IsCorrect"].ToString().ToLower() == "true")
                {
                    dr["IsCorrect"] = 1;
                }
                dr["Career_ID"] = Career_ID;
            }
            career_iqtest.Insert(dt);
        }

        public void Update(DataTable dt, int Career_ID)
        {
            //to update ProfileID
            foreach (DataRow dr in dt.Rows)
            {
                dr["Career_ID"] = Career_ID;
            }
            career_iqtest.Update(dt);
        }

        public bool Delete(int Career_ID)
        {
            return career_iqtest.DeleteByProfileID(Career_ID);
        }
    }
}
