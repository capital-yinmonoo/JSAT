using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class One_Month_PersonBL
    {
        One_Month_PersonDL monthperson;
        public One_Month_PersonBL()
        {
            monthperson = new One_Month_PersonDL();
        }

        public DataTable Select_OneMonth_Working_Person()
        {
            return monthperson.Select_OneMonth_Working_Person();
        }

        public DataTable Select_TwoMonth_Working_Person()
        {
            return monthperson.Select_TwoMonth_Working_Person();
        }

        public DataTable Select_ThreeMonth_Working_Person()
        {
            return monthperson.Select_ThreeMonth_Working_Person();
        }

        public void Update(int id,int option)
        {
             monthperson.Update(id,option);
        }
    }
}
