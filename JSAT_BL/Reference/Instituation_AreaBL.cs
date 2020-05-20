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
    public class Instituation_AreaBL
    {
        Instituation_AreaDL instituation;
        bool search = true;

        public Instituation_AreaBL()
        {
            instituation = new Instituation_AreaDL();
        }

        public DataTable SelectAll()
        {
            return instituation.SelectAll();
        }

        public Instituation_AreaEntity SelectByID(int id)
        {
            return instituation.SelectByID(id);
        }

        public bool Insert(Instituation_AreaEntity instituationInfo)
        {
            bool result = false;
            result = instituation.Insert(instituationInfo);
            return result;
        }

        public bool Update(Instituation_AreaEntity instituationInfo)
        {
            bool result = false;
            result = instituation.Update(instituationInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = true;
            result = instituation.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return instituation.Search(str);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = instituation.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }
    }
}
