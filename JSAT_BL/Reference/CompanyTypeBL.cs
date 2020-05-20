using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;


namespace JSAT_BL
{
    public class CompanyTypeBL
    {
        CompanyTypeDL company;
        public CompanyTypeBL()
        {
            company = new CompanyTypeDL();
        }

        public DataTable SelectAll()
        {
            return company.SelectAll();
        }
    }
}
