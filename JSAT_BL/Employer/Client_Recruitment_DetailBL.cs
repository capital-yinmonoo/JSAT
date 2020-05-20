using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
   public class Client_Recruitment_DetailBL
    {
       Client_Recruitment_DetailDL crddl;

       public Client_Recruitment_DetailBL()
       {
           crddl = new Client_Recruitment_DetailDL();
       }

       public DataTable SelectByRecruitmentID(int rec_ID)
       {
           return crddl.SelectByRecruitmentID(rec_ID);
       }

       public Boolean Delete(int rec_ID, int career_ID)
       {
           return crddl.Delete(rec_ID, career_ID);
       }
    }
}
