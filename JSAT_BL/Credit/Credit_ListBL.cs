using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Credit_ListBL
    {
       Credit_ListDL creditList;
        public Credit_ListBL()
        {
            creditList = new Credit_ListDL() ;
        }

        public int SelectStartWorkingCount()
        {
            return creditList.SelectStartWorkingCount();
        }

        public int SelectOneMonthCount()
        {
            return creditList.SelectOneMonthCount();
        }

        public int SelectTwoMonthCount()
        {
            return creditList.SelectTwoMonthCount();
        }

        public int SelectThreeMonthCount()
        {
            return creditList.SelectThreeMonthCount();
        }

        public int SelectFPaymentPerson()
        {
            return creditList.SelectFPaymentPerson();
        }

        public int SelectSPaymentPerson()
        {
            return creditList.SelectSPaymentPerson();
        }

        public DataTable SelectAll()
        {
            return creditList.SelectAll();
        }

        public DataTable PopupSearchName(Credit_List_Entity creditentity)
        {
            return creditList.PopupSearchName(creditentity);
        }

        public void UpdatePaymentTerm()
        {
            creditList.UpdatePaymentTerm();
        }
    }
}
