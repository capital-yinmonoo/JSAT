using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class popup_BL
    {
        popup_DL popup;

        public popup_BL()
        {
            popup = new popup_DL();
        }

        public DataTable SearchByGroupName()
        {
            return popup.SearchByGroupName();
        }

        public DataTable PopupSearchGroupName(String name, int code)
        {
            return popup.PopupSearchGroupName(name, code);
        }

        public DataTable SearchByName()
        {
            return popup.SearchByName();
        }

        public DataTable PopupSearchEmployeeName(String name, String code)
        {
            return popup.PopupSearchEmployeeName(name, code);
        }

        public DataTable SearchByEmploeeName()
        {
            return popup.SearchByEmploeeName();
        }

        public DataTable Select_Employee_Name(string chkid)
        {
            return popup.Select_Employee_Name(chkid);
        }

        public DataTable SearchByGroup()
        {
            return popup.SearchByGroup();
        }

        public DataTable SearchByInvoiceNo()
        {
            return popup.SearchByInvoiceNo();
        }

        public DataTable PopupSearchJobCode(string code)
        {
            return popup.PopupSearchJobCode(code);
        }

        public DataTable SearchByJobNo(string cname)
        {
            return popup.SearchByJobNo(cname);
        }

        public DataTable PopupSearchName(string code)
        {
            return popup.PopupSearchName(code);
        }

        public DataTable SearchByInvoiceName()
        {
            return popup.SearchByInvoiceName();
        }

        public DataTable SearchByJobName(int id)
        {
            return popup.SearchByJobName(id);
        }

        public DataTable SearchByJobName1()
        {
            return popup.SearchByJobName1();
        }

        public DataTable PopupSearchJobPosition(String name, int code)
        {
            return popup.PopupSearchJobPosition(name, code);
        }

        public DataTable SearchByCName()
        {
            return popup.SearchByCName();
        }

        public DataTable PopupSearchCName(String name)
        {
            return popup.PopupSearchCName(name);
        }
    }
}
