using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;
using System.Transactions;

namespace JSAT_BL
{
    public class Person_TypeBL
    {
        Person_TypeDL personType;

        public Person_TypeBL()
        {
            personType = new Person_TypeDL();
        }

        public DataTable SelectAll()
        {
            return personType.SelectAll();
        }
    }
}
