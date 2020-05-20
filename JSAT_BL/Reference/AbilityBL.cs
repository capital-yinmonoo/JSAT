using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_DL.Reference;
using JSAT_Common;
using JSAT_Common.Reference;

namespace JSAT_BL.Reference
{
   public class AbilityBL
    {
        AbilityDL qdl;
        int totalrowcount;
        public AbilityBL()
        {
            qdl = new AbilityDL();
        }

        public DataTable SelectAll()
        {
            return qdl.SelectAll();
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = qdl.Delete(id);
            return result;
        }

        public bool Insert(AbilityEntity qentity)
        {
            bool result = false;
            result = qdl.Insert(qentity);
            return result;
        }

        public DataTable SelectBytitle(int title_id)
        {
            return qdl.SelectBytitle(title_id);
        }

        public bool CheckExistingType(int id, int title_id, string description)
        {
            int count = qdl.CheckExistingType(id, title_id, description);
            if (count > 0)
                return true;
            else return false;
        }

        public DataTable Search(int id, string str)
        {
            return qdl.Search(id, str);
        }

        public DataTable GetTitleID(int id)
        {
            return qdl.GetTitleID(id);
        }

        public bool Update(AbilityEntity ablEntity)
        {
            bool result = false;
            result = qdl.Update(ablEntity);
            return result;
        }
    }
}
