using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class LogInBL
    {
        LogInDL LogIn;
        public LogInBL()
        {
            LogIn = new LogInDL();
        }

        public int LogInCheck(string username, string password)
        {
            int ID = LogIn.LogIn(username, password);
            return ID;
        }

        public UserEntity SelectPassword(string LogIn_ID)
        {
            return LogIn.SelectPassword(LogIn_ID);
        }

        public bool Check_PageAccess(int id, string url, string pagecode)
        {
            return LogIn.Check_PageAccess(id, url, pagecode);
        }
    }
}
