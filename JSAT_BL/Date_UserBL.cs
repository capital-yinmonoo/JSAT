using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using JSAT_DL;


namespace JSAT_BL
{
    public class Date_UserBL
    {

        Date_UserDL wdl;
        int totalrowcount;
        public Date_UserBL()
        {
            wdl = new Date_UserDL();
        }
        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return wdl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }
    }
}
