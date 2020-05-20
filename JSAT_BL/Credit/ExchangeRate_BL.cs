using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;

namespace JSAT_BL
{
    public class ExchangeRate_BL
    {
        ExchangeRate_DL exdl;
        public ExchangeRate_BL()
        {
            exdl = new ExchangeRate_DL();
        }

        public void Insert(string buy,string sell)
        {
            exdl.Insert(buy,sell);
        }
    }
}
