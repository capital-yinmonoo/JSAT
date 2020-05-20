using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using JSAT_Common.Reference;
using JSAT_DL.Reference;


namespace JSAT_BL.Reference
{
    public class AbilityTitleBL
    {
        AbilityTitleDL ablTitledl;
        bool search = true;
        int totalrowcount;
        public AbilityTitleBL()
        {
            ablTitledl = new AbilityTitleDL();
        }

        public DataTable SelectAll(int IDorDescription)
        {
            return ablTitledl.SelectAll(IDorDescription);
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return ablTitledl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public AbilityTitleEntity SelectByID(int id)
        {
            return ablTitledl.SelectByID(id);
        }

        public bool Insert(AbilityTitleEntity AblTitleInfo)
        {
            bool result = false;
            result = ablTitledl.Insert(AblTitleInfo);
            return result;
        }

        public bool Update(AbilityTitleEntity AblTitleInfo)
        {
            bool result = false;
            result = ablTitledl.Update(AblTitleInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = ablTitledl.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return ablTitledl.Search(str);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = ablTitledl.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }
    }
}
