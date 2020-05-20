using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL.Reference;

namespace JSAT_BL.Reference
{
    public class InterviewQuestion1BL
    {
        Interview_Question1DL iq1d;

        public InterviewQuestion1BL()
        {
            iq1d = new Interview_Question1DL();
        }

        public DataTable SelectAll()
        {
            return iq1d.SelectAll();
        }
    }
}
