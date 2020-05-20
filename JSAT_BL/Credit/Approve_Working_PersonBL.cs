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
    public class Approve_Working_PersonBL
    {
        Approve_Working_PersonDL appworking;

        public Approve_Working_PersonBL()
        {
            appworking = new Approve_Working_PersonDL();
        }

        public DataTable Select_Start_Working_Person()
        {
            return appworking.Select_Start_Working_Person();
        }

        public void Update_Status_And_PaymentTerm(int id)
        {
            appworking.Update_Status_And_PaymentTerm(id);
        }

        public void Update_Status_And_PaymentTerm1(int id)
        {
            appworking.Update_Status_And_PaymentTerm1(id);
        }

        public DataTable PopupSearchName(string name, string startdate, string enddate, string status)
        {
            return appworking.PopupSearchName(name, startdate, enddate, status);
        }
    }
}
