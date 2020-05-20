using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class Credit_Success_BL
    {
        Credit_Success_DL cbl;
        public Credit_Success_BL()
        {
            cbl=new Credit_Success_DL();
        }

        public DataTable SelectTotalPaidAmount(string From_Date,string To_Date,string name,int option)
        {
            return cbl.SelectTotalPaidAmount(From_Date,To_Date,name,option);
        }
    }
}
