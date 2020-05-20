using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL.Reference;
using System.Data;
using JSAT_Common.Reference;
using JSAT_Common;
using JSAT_DL;
using System.Transactions;
using System.Data.SqlClient;

namespace JSAT_BL
{
   public class Career_Interview1BL
    {
       CareerInterview1DL cidl;

       public Career_Interview1BL()
       {
           cidl = new CareerInterview1DL();
       }

       public DataTable SelectAll()
       {
           return cidl.SelectAll();
       }

       public DataTable SelectByID(int id)
       {
           return cidl.SelectByID(id); 
       }

       public DataTable SelectByCareerID(int careerId)
       {
           return cidl.SelectByCareerID(careerId);
       }

       public int Insert_Update(CareerInterview1Entity cie,Career_QualificationEntity cq, EnumBase.Save option)
       {
           using (TransactionScope scope = new TransactionScope())
           {
               int career_Id=cidl.Insert_Update(cie, option);
               if (career_Id>0)
               {
                   Career_QualificationBL cqbl1 = new Career_QualificationBL();
                   if (cqbl1.Insert_Update(cq, option))
                   {
                       scope.Complete();
                   }
               }
              return career_Id;
           }
       }

       public bool Delete(int id)
       {
           if (cidl.Delete(id))
               return true;
           else return false;
       }

       public Boolean DeleteByCareerID(int id)
       {
           if (cidl.DeleteByCareerID(id))
           {
               return true;
           }
           else return false;
       }
    }
}
