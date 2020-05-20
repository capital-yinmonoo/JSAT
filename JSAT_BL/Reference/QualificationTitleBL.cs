using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL.Reference;
using System.Data;
using JSAT_Common.Reference;

namespace JSAT_BL.Reference
{
    public class QualificationTitleBL
    {
        QualificationTitleDL qTitledl;
        bool search = true;
        int totalrowcount;
        public QualificationTitleBL()
        {
            qTitledl = new QualificationTitleDL();
        }

        public DataTable SelectAll(int IDorDescription)
        {
            return qTitledl.SelectAll(IDorDescription);
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return qTitledl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public QualificationTitleEntity SelectByID(int id)
        {
            return qTitledl.SelectByID(id);
        }

        public bool Insert(QualificationTitleEntity qTitleInfo)
        {
            bool result = false;
            result = qTitledl.Insert(qTitleInfo);
            return result;
        }

        public bool Update(QualificationTitleEntity qTitleInfo)
        {
            bool result = false;
            result = qTitledl.Update(qTitleInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = qTitledl.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return qTitledl.Search(str);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = qTitledl.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }
    }
}
