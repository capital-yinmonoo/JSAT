using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
   public class GenderBL
    {
        GenderDL gdl;

        public GenderBL()
        {
            gdl = new GenderDL();
        }

        public DataTable SelectAll()
        {
            return gdl.SelectAll();
        }

        public DataTable SelectAllData()
        {
            return gdl.SelectAllData();
        }
    }
}
