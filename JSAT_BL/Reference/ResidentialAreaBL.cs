using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL.Reference;
using System.Data;
using JSAT_Common.Reference;


namespace JSAT_BL.Reference
{
    public class ResidentialAreaBL
    {
        ResidentialAreaDL radl;

        public ResidentialAreaBL()
        {
            radl = new ResidentialAreaDL();
        }

        public bool Insert(ResidentialArea_Entity township)
        {
            bool result = false;
            result = radl.Insert(township);
            return result;
        }

        public bool Update(ResidentialArea_Entity township)
        {
            bool result = false;
            result = radl.Update(township);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = radl.Delete(id);
            return result;
        }

        public DataTable SelectAll()
        {
            return radl.SelectAll();
        }

        public DataTable Search(string str)
        {
            return radl.Search(str);
        }

        public bool CheckExistingType(string str, int id)
        {
            int count = radl.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }
    }
}
