using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;


namespace JSAT_BL
{
    public class LanguageLevelBL
    {
        public LanguageLevelDL LanguageLevel;

        public LanguageLevelBL()
        {
            LanguageLevel = new LanguageLevelDL();
        }

        public DataTable SelectAll()
        {
            return LanguageLevel.SelectAll();
        }
    }
}
