using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Interview_Question_Type_BL
    {
        Interview_Question_Type_DL iqdl;

        public Interview_Question_Type_BL()
        {
            iqdl = new Interview_Question_Type_DL();
        }

        public DataTable SelectAll()
        {
            return iqdl.SelectAll();
        }

        public Interview_Question_Type_Entity SelectByID(int id)
        {
            return iqdl.SelectByID(id);
        }

        public bool Insert(Interview_Question_Type_Entity question)
        {
            bool result = false;
            result = iqdl.Insert(question);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = iqdl.Delete(id);
            return result;
        }

        public bool Update(Interview_Question_Type_Entity question)
        {
            bool result = false;
            result = iqdl.Update(question);
            return result;
        }

        public DataTable Search(string str)
        {
            return iqdl.Search(str);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = iqdl.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }
    }
}
