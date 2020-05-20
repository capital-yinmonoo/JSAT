using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL;

namespace JSAT_BL
{
    public class SubstitudeHistory_BL
    {
        SubstitudeHistory_DL sdl;
        public SubstitudeHistory_BL()
        {
            sdl = new SubstitudeHistory_DL();
        }

        public DataTable Get_Payment_ID(int pid)
        {
            return sdl.Get_Payment_ID(pid);
        }
    }
}
