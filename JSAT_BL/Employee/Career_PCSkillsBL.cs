using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class Career_PCSkillsBL
    {
        Career_PCSkills_DL cpdl;

        public Career_PCSkillsBL()
        {
            cpdl = new Career_PCSkills_DL();
        }

        public Boolean Insert_Update(Career_PCSkillsEntity pse, EnumBase.Save option)
        {
            return cpdl.Insert_Update(pse, option);
        }

        public DataTable SelectByID(int careerId)
        {
            return cpdl.SelectByID(careerId);
        }

        public Boolean Delete(int id)
        {
            return cpdl.Delete(id);
        }
    }
}
