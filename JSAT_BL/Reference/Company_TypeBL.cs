using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JSAT_Common.Reference;
using System.Data;
using JSAT_DL.Reference;

namespace JSAT_BL.Reference
{
   public class Company_TypeBL
    {
        Company_TypeDL companydl;
        int totalrowcount;
        public Company_TypeBL() 
        {
            companydl = new Company_TypeDL();
        }

        public DataTable SelectAll() 
        {
            return companydl.SelectAll();
        }

        public Company_TypeEntity SelectByID(int id)
        {
            return companydl.SelectByID(id);
        }

        public bool Insert( Company_TypeEntity CompanyInfo)
        {
            bool result = false;
            result = companydl.Insert(CompanyInfo);
            return result;
        }

        public bool InsertCompanyType(Company_TypeEntity CompanyInfo)
        {
            bool result = false;
            result = companydl.InsertCompanyType(CompanyInfo);
            return result;
        }

        public bool Update(Company_TypeEntity CompanyInfo)
        {
            bool result = false;
            result = companydl.Update(CompanyInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = companydl.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return companydl.Search(str);
        }

        public bool CheckExistingType( int id,string str)
        {
            int count = companydl.CheckExistingType(id,str);
            if (count > 0)
                return true;
            else return false;
        }

        public bool CheckExistingCompany_Type(int company_id, int id)
        {
            int count = companydl.CheckExistingCompany_Type(company_id, id);
            if (count > 0)
                return true;
            else return false;
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return companydl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }
    }
}
