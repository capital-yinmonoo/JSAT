using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;

namespace JSAT_BL
{
    public class MajorBL
    {
        MajorDL mdl;
        Major_Entity mentity;
        int totalrowcount;
        public MajorBL()
        {
            mdl = new MajorDL();
        }

        public DataTable SelectAll()
        {
            return mdl.SelectAll();
        }

        public DataTable SearchData(string major)
        {
            return mdl.SearchData(major);
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = mdl.Delete(id);
            return result;
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = mdl.CheckExistingType(id, str);
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
            return mdl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public bool Update(Major_Entity mentity)
        {
            bool result = false;
            result = mdl.Update(mentity);
            return result;
        }

        public bool Insert(Major_Entity mentity)
        {
            bool result = false;
            result = mdl.Insert(mentity);
            return result;
        }
    }
}
