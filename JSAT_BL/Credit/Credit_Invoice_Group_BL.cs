using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class Credit_Invoice_Group_BL
    {
        Credit_Invoice_Group_DL cdl;
        public Credit_Invoice_Group_BL()
        {
            cdl = new Credit_Invoice_Group_DL();
        }

        public string AutoGenerate(string prefix, string suffix, bool includeDate)
        {
            return cdl.AutoGenerate(prefix, suffix, includeDate);
        }

        public void InsertByInvoiceNo1(string gname, string invoiceNo)
        {
            cdl.InsertByInvoiceNo1(gname, invoiceNo);
        }

        public DataTable SelectByGroupNameForInvoiceReport(string gname)
        {
            return cdl.SelectByGroupNameForInvoiceReport(gname);
        }

        public DataTable SelectCompany(int PID, string etype)
        {
            return cdl.SelectCompany(PID, etype);
        }

        public DataTable SelectByCompany(int PID)
        {
            return cdl.SelectByCompany(PID);
        }

        public void InsertByInvoiceNo(string eid, string invoiceNo)
        {
            cdl.InsertByInvoiceNo(eid, invoiceNo);
        }

        public DataTable Select_By_ENameBySingleGroup(string eid)
        {
            return cdl.Select_By_ENameBySingleGroup(eid);
        }

        public DataTable Select_By_Invoice_No(string invoice,int cid)
        {
            return cdl.Select_By_Invoice_No(invoice,cid);
        }
    }
}
