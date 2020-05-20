using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_DL.Employee;
using JSAT_Common.Employee;
using JSAT_Common;
using System.Data;
namespace JSAT_BL.Employee
{
    public class Career_AbilityBL
    {
        Career_AbilityDL cadl;

        public Career_AbilityBL()
        {
            cadl = new Career_AbilityDL();
        }

        public Boolean Insert_Update(Career_AbilityEntity ae, EnumBase.Save option)
        {
            return cadl.Insert_Update(ae, option);
        }

        public DataTable SelectByID(int careerId)
        {
            return cadl.SelectByID(careerId);
        }

        public DataSet Select_Ability_Title_Item_ByID(int careerId)
        {
            return cadl.Select_Ability_Title_Item_ByID(careerId);
        }


        public Boolean Delete(int id)
        {
            return cadl.Delete(id);
        }
    }
}

