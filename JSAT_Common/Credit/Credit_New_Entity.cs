using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Credit_New_Entity
    {
        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int name = 0;
        public int Name
        {
            get { return name; }
            set { name = value; }
        }

        private string group = string.Empty;
        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        private string ename = string.Empty;
        public string EName
        {
            get { return ename; }
            set { ename = value; }
        }

        private string ecode = string.Empty;
        public string ECode
        {
            get { return ecode; }
            set { ecode = value; }
        }

        private string jobdesc = string.Empty;
        public string JobDesc
        {
            get { return jobdesc; }
            set { jobdesc = value; }
        }

        private int jid = 0;
        public int JobID
        {
            get { return jid; }
            set { jid = value; }
        }

        private int jno = 0;
        public int JobNo
        {
            get { return jno; }
            set { jno = value; }
        }

        private string currency = string.Empty;
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        private int sid = 0;
        public int SubID
        {
            get { return sid; }
            set { sid = value; }
        }

        private int status = 0;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int payment = 0;
        public int Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private DateTime startworkingdate;
        public DateTime StartWorkingDate
        {
            get { return startworkingdate; }
            set { startworkingdate = value; }
        }

        private DateTime endworkingdate;
        public DateTime EndWorkingDate
        {
            get { return endworkingdate; }
            set { endworkingdate = value; }
        }

        private DateTime firstinvoicedate;
        public DateTime FirstInvoiceDate
        {
            get { return firstinvoicedate; }
            set { firstinvoicedate = value; }
        }

        private DateTime secondinvoicedate;
        public DateTime SecondInvoiceDate
        {
            get { return secondinvoicedate; }
            set { secondinvoicedate = value; }
        }

        private int salary = 0;
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private string subname = string.Empty;
        public string SubName
        {
            get { return subname; }
            set { subname = value; }
        }

        private int firstamount = 0;
        public int FirstAmount
        {
            get { return firstamount; }
            set { firstamount = value; }
        }

        private int secondamount = 0;
        public int SecondAmount
        {
            get { return secondamount; }
            set { secondamount = value; }
        }
    }
}
