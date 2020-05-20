using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;

namespace JSAT_BL
{
    public class QualificationBL
    {
        QualificationDL qdl;
        int totalrowcount;
        public QualificationBL()
        {
            qdl = new QualificationDL();
        }

        public DataTable SelectAll(int QorCRV)
        {
            return qdl.SelectAll(QorCRV);
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = qdl.Delete(id);
            return result;
        }

        public bool Insert(Qualification_Entity qentity)
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

        public bool Update(Qualification_Entity qentity)
        {
            bool result = false;
            result = qdl.Update(qentity);
            return result;
        }
    }
}
