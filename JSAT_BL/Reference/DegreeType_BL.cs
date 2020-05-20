using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;
using System.ComponentModel;

namespace JSAT_BL
{
    public class DegreeType_BL
    {
        DegreeType_DL ddl;
        int totalrowcount;
        public DegreeType_BL()
        {
            ddl = new DegreeType_DL();
        }

        public DataTable SelectAll()
        {
            return ddl.SelectAll();
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return ddl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public bool Insert(DegreeType_Entity degree)
        {
            bool result = false;
            result = ddl.Insert(degree);
            return result;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(DegreeType_Entity degree)
        {
            bool result = false;
            result = ddl.Update(degree);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = ddl.Delete(id);
            return result;
        }

        public DataTable Search(int id, string str)
        {
            return ddl.Search(id, str);
        }

        public bool CheckExistingType(int institutionid, string str, int id)
        {
            int count = ddl.CheckExistingType(institutionid, str, id);
            if (count > 0)
                return true;
            else return false;
        }

        public DegreeType_Entity SelectByID(int id)
        {
            return ddl.SelectByID(id);
        }

        public DataTable SelectByInstitutionID(int institution_id)
        {
            return ddl.SelectByInstitutionID(institution_id);
        }

        public DataTable GetByInstitutionID(int institution_id)
        {
            return ddl.GetByInstitutionID(institution_id);
        }

        public DataTable GetInstituation(int bbid)
        {
            return ddl.GetInstituation(bbid);
        }
    }
}
