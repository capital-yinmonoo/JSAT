using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
   public  class InterviewList_Entity
    {
        private Boolean before = false;
        public Boolean Before
        {
            get { return before; }
            set { before = value; }
        }

        private Boolean theday = false;
        public Boolean Theday
        {
            get { return theday; }
            set { theday = value; }
        }

        private int career_ID = 0;
        public int Career_ID
        {
            get { return career_ID; }
            set { career_ID = value; }
        }

        private string compnanyname = string.Empty;
        public string Compnanyname
        {
            get { return compnanyname; }
            set { compnanyname = value; }
        }

        private int jobno = 0;
        public int Jobno
        {
            get { return jobno; }
            set { jobno = value; }
        }
    }
}
