using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
    public class Excel_BL
    {
        Excel_DL edl;
        public Excel_BL()
        {
            edl = new Excel_DL();
        }

        public DataTable Read(string path, string extension)
        {
            return edl.Read(path, extension);
        }

        public void Insert(DataTable dt)
        {
            edl.Insert(dt);
        }
    }
}
