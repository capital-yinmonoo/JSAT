using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL;


namespace JSAT_BL
{
    public class Client_Profile_Excel_BL
    {
        Client_Profile_Excel_DL exedl;
        public Client_Profile_Excel_BL()
        {
            exedl = new Client_Profile_Excel_DL();   
        }

        public DataTable Read(string path, string extension)
        {
            return exedl.Read(path, extension);
        }

        public void Insert(DataTable dt)
        {
            exedl.Insert(dt);
        }
    }
}
