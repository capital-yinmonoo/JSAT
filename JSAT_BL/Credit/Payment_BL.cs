using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL;

namespace JSAT_BL
{
    public class Payment_BL
    {
        Payment_DL pdl;
        public Payment_BL()
        {
            pdl = new Payment_DL();
        }

        public DataTable SelectDataForTextbox2(string cname, string invoice)
        {
            return pdl.SelectDataForTextbox2(cname, invoice);
        }

        public DataTable Select_Company_Credit_ID(string invoice,int comid)
        {
            return pdl.Select_Company_Credit_ID(invoice,comid);
        }

        public void Insertdata(int companyid, int cid,int eid, string invoice, int status, string invoicedate, int amount)
        {
            pdl.Insertdata(companyid, cid,eid, invoice, status, invoicedate, amount);
        }
    }
}
