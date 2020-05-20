using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
   public class LanguageBL
    {

       public LanguageDL ldl;

       public LanguageBL()
       {
           ldl = new LanguageDL();
       }

       public DataTable SelectAll()
       {
           return ldl.SelectAll();
       }
    }
}
