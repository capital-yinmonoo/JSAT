using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Township_Type_BL
    {
        Township_Type_DL tdl;
        public Township_Type_BL()
        {
            tdl = new Township_Type_DL();
        }

        public DataTable SelectAll()
        {
            return tdl.SelectAll();
        }

        public bool Insert(Township_Type_Entity township)
        {
            bool result = false;
            result = tdl.Insert(township);
            return result;
        }

        public bool Update(Township_Type_Entity township)
        {
            bool result = false;
            result = tdl.Update(township);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = tdl.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return tdl.Search(str);
        }

        public bool CheckExistingType(string str, int id)
        {
            int count = tdl.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }

        public Township_Type_Entity SelectByID(int id)
        {
            return tdl.SelectByID(id);
        }

        public DataTable SelectByInstitutionID(int institutionarea_id)
        {
            return tdl.SelectByInstitutionAreaID(institutionarea_id);
        }

        public DataTable Get_InstitutionAreaID(int ID)
        {
            return tdl.Get_InstitutionAreaID(ID);
        }
    }
}
