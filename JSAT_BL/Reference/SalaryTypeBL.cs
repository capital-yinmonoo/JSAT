using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;

namespace JSAT_BL
{
   public class SalaryTypeBL
    {
       public SalaryTypeDL stdl;

       public SalaryTypeBL()
       {
           stdl = new SalaryTypeDL();
       }

       public DataTable SelectAll()
       {
           return stdl.SelectAll();
       }
    }
}
