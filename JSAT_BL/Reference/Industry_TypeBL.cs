using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;
using System.Data;

namespace JSAT_BL
{
   public  class Industry_TypeBL
    {

        Industry_TypeDL industry;
        int totalrowcount;
        public Industry_TypeBL() 
        {
            industry = new Industry_TypeDL();
        }

        public DataTable SelectAll() 
        {
            return industry.SelectAll();
        }

        public Industry_TypeEntity SelectByID(int id)
        {
            return industry.SelectByID(id);
        }

        public bool  Insert( Industry_TypeEntity IndustryInfo)
        {
            bool result = false; 
           result = industry.Insert(IndustryInfo);
            return result;           
        }

        public bool Update(Industry_TypeEntity IndustryInfo)
        {
            bool result = false;
            result = industry.Update(IndustryInfo);
            return result;   
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = industry.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return industry.Search(str);
        }

        public bool CheckExistingType(int id,string str)
        {
            int count = industry.CheckExistingType(id,str);
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
            return industry.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }
    }
}
