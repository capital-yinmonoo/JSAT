using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;


namespace JSAT_BL
{
    
    public class EducationBL
    {
        EducationDL education;

        public EducationBL()
        {
            education = new EducationDL();
        }

        public DataTable SelectByID(int ID)
        {
            return education.SelectByID(ID);
        }

        public void Insert(DataTable dt,int profileID)
        {
            //to update ProfileID
            foreach (DataRow dr in dt.Rows)
            {
                dr["ProfileID"] = profileID;
            }
            education.Insert(dt);
        }

        public bool Delete(int profileID)
        {
           return education.DeleteByProfileID(profileID);
        }
    }
}
