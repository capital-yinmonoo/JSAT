using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_DL;

namespace JSAT_BL
{
    public class MenuBL
    {
        MenuDL menu;

        public MenuBL()
        {
            menu = new MenuDL();
        }

        public DataTable SelectAll()
        {
            return menu.SelectAll();
        }
    }
}
