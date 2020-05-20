using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL.Reference;
using System.Data;

namespace JSAT_BL
{
   public class SituationBL
    {
       SituationDL sbl;

       public SituationBL()
       {
           sbl = new SituationDL();
       }

       public DataTable SelectAll()
       {
           return sbl.SelectAll();
       }
    }
}
