using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Approve_Working_Person_Entity
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime sdate;
        public DateTime Sdate
        {
            get { return sdate; }
            set { sdate = value; }
        }

        private DateTime edate;
        public DateTime Edate
        {
            get { return edate; }
            set { edate = value; }
        }
    }
}
