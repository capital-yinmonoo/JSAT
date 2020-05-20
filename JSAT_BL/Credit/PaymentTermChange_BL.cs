using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class PaymentTermChange_BL
    {
        PaymentTermChange_DL pdl;
        public PaymentTermChange_BL()
        {
            pdl = new PaymentTermChange_DL();
        }

        public DataTable SelectAll()
        {
            return pdl.SelectAll();
        }

        public DataTable SelectByGroupNameForInvoiceReport(string gname)
        {
            return pdl.SelectByGroupNameForInvoiceReport(gname);
        }

        public void UpdatePaymentTerm(int id)
        {
            pdl.UpdatePaymentTerm(id);
        }

        public void UpdatePaymentTerm1(int id)
        {
            pdl.UpdatePaymentTerm1(id);
        }

        public DataTable Select_By_EName(int empid)
        {
            return pdl.Select_By_EName(empid);
        }

        public DataTable SelectByNameForInvoiceReport(string name, int empid)
        {
            return pdl.SelectByNameForInvoiceReport(name, empid);
        }
    }
}
