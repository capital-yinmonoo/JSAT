using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL;

namespace JSAT_BL
{
	public class Employee_Preview_BL
	{
        Employee_Preview_DL edl;

        public Employee_Preview_BL()
        {
            edl = new Employee_Preview_DL();
        }

        public DataTable Get_Info_ByEmpID(int eid)
        {
            return edl.Get_Info_ByEmpID(eid);
        }
	}
}
