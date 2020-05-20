using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class InstitutionBL
    {
        public InstitutionDL Institution;

        public InstitutionBL()
        {
            Institution = new InstitutionDL();
        }

        public DataTable SelectAll(int IorCRV)
        {
            return Institution.SelectAll(IorCRV);
        }
    }
}
