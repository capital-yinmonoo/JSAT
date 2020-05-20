using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class DayServiceBL
    {
        DayServiceDL dsdl;

        public DayServiceBL()
        {
            dsdl = new DayServiceDL();
        }

        public DataTable SelectAll()
        {
           return dsdl.SelectAll();
        }
    }
}
