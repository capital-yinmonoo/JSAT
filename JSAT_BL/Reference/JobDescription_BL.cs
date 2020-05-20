using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;
namespace JSAT_BL
{
   public class JobDescription_BL
    {
       JobDescription_DL descriptindl;
       JobDescription_Entity descriptionentity;
       bool search = true;
       int totalrowcount;
       public JobDescription_BL()
       {
           descriptindl = new JobDescription_DL();
       }

       public DataTable SelectAll()
       {
           return descriptindl.SelectAll();
       }

       public DataTable SelectByPosition(int positition_id)
       {
           return descriptindl.SelectByPosition(positition_id);
       }

       public DataTable GetPositionID(int id)
       {
           return descriptindl.GetPositionID(id);
       }

       public bool Delete(int id)
       {
           bool result = false;
           result = descriptindl.Delete(id);
           return result;
       }

       public bool CheckExistingType(int posid, string str, int id)
       {
           int count = descriptindl.CheckExistingType(posid, str, id);
           if (count > 0)
               return true;
           else return false;
       }

       public int TotalRowCount(string search)
       {
           return totalrowcount;
       }

       public DataTable Paging(string search, string sort, int startIndex, int pagesize)
       {
           return descriptindl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
       }

       public bool Update(JobDescription_Entity descriptionentity)
       {
           bool result = false;
           result = descriptindl.Update(descriptionentity);
           return result;
       }

       public bool Insert(JobDescription_Entity descriptionentity)
       {
           bool result = false;
           result = descriptindl.Insert(descriptionentity);
           return result;
       }

       public DataTable Search(int id, string str)
       {
           return descriptindl.Search(id, str);
       }
    }
}
