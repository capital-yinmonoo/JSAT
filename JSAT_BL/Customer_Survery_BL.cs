using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;

namespace JSAT_BL
{
    public class Customer_Survery_BL
    {
        Customer_Survey_DL surveydl;
        public Customer_Survery_BL()
        {
            surveydl = new Customer_Survey_DL();
        }

        public DataTable Select_Survey()
        {
            return surveydl.Select_Survey();
        }


    }
}
