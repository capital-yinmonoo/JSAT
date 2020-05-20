using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;

namespace JSAT_BL
{
    public class Career_QualificationBL
    {
        Career_QualificationDL cqdl;

        public Career_QualificationBL()
        {
            cqdl = new Career_QualificationDL();
        }

        public Boolean Insert_Update(Career_QualificationEntity qe, EnumBase.Save option)
        {
            return cqdl.Insert_Update(qe, option);
        }

        public DataTable SelectByID(int careerId)
        {
            return cqdl.SelectByID(careerId);
        }
        public DataSet Select_Qualification_Title_Item_ByID(int careerId)
        {
            return cqdl.Select_Qualification_Title_Item_ByID(careerId);
        }

        public Boolean Delete(int id)
        {
            return cqdl.Delete(id);
        }
    }
}
