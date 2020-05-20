using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class EnumBase
    {
        public enum Gender
        {
            Male = 1,
            Female = 2
        }

        public enum Save
        {
            Insert = 0,
            Update = 1
        }

        public enum Report
        {
            Client_Rpt = 0,
            Career_Rpt = 1
        }
    }
}
