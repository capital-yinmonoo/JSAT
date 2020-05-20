using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using System.Data;
using JSAT_DL;

namespace JSAT_BL
{
    public class Career_WorkingPlaceBL
    {
        Career_WorkingPlaceDL cwpdl;

        public Career_WorkingPlaceBL()
        {
            cwpdl = new Career_WorkingPlaceDL();
        }

        public Boolean Insert_Update(Career_WorkingPlaceEntity cwpe, EnumBase.Save option)
        {
            return cwpdl.Insert_Update(cwpe, option);
        }

        public DataTable SelectByID(int careerId)
        {
            return cwpdl.SelectByID(careerId);
        }

        public Boolean Delete(int id)
        {
            return cwpdl.Delete(id);
        }
    }
}
