using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
	public class Payment_ListBL
	{
        Payment_ListDL payment;
        public Payment_ListBL()
        {
            payment = new Payment_ListDL();
        }

        public DataTable Select_First_Payment_Person()
        {
            return payment.Select_First_Payment_Person();
        }

        public DataTable Select_Second_Payment_Person()
        {
            return payment.Select_Second_Payment_Person();
        }
	}
}
