using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common.Reference;
using JSAT_DL.Reference;
using System.Data;

namespace JSAT.Reference
{
    public class CountryBL
    {
         CountryDL countrydl;
        bool search = true;
        int totalrowcount;
        public CountryBL()
        {
            countrydl = new CountryDL();
        }

        public DataTable SelectAll()
        {
            return countrydl.SelectAll();
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return countrydl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public CountryEntity SelectByID(int id)
        {
            return countrydl.SelectByID(id);
        }

        public bool  Insert( CountryEntity  countryInfo)
        {
            bool result = false;
            result = countrydl.Insert(countryInfo);
            return result;
        }

        public bool Update(CountryEntity countryInfo)
        {
            bool result = false;
            result = countrydl.Update(countryInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result=countrydl.Delete(id);
            return result;   
        }

        public DataTable Search(string str)
        {
            return countrydl.Search(str);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = countrydl.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }

        public DataTable GetByCompanyID(int Company_id)
        {
            return countrydl.GetByCompanyID(Company_id);
        }

        public DataTable GetCompanyType(int bbid)
        {
            return countrydl.GetCompanyType(bbid);
        }
    }
}
