using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;
using System.ComponentModel;

namespace JSAT_BL
{
    public class BusinessTypeBL
    {
        BusinessTypeDL business;
        bool search = true;
        int totalrowcount;
        public BusinessTypeBL()
        {
            business = new BusinessTypeDL();
        }

        public DataTable SelectAll()
        {
            return business.SelectAll();
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return business.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public BusinessTypeEntity SelectByID(int id)
        {
            return business.SelectByID(id);
        }

        public bool  Insert( BusinessTypeEntity  businessInfo)
        {
            bool result = false;
            result = business.Insert(businessInfo);
            return result;
        }

        public bool Update(BusinessTypeEntity businessInfo)
        {
            bool result = false;
            result = business.Update(businessInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result=business.Delete(id);
            return result;   
        }

        public DataTable Search(int id,string str)
        {
            return business.Search(id,str);
        }

        public bool CheckExistingType(int Industryid,string str , int id)
        {
            int count = business.CheckExistingType(Industryid,str,id);
            if (count > 0)
                return true;
            else return false;
        }

        public DataTable SelectByIndustryID(int Industry_id) 
        {
            return business.SlectByIndustryID(Industry_id);
        }

        public DataTable GetByIndustryID(int Industry_id)
        {
            return business.GetByIndustryID(Industry_id);
        }

        public DataTable SelectedbyTypeofBusiness(int dept_id)
        {
            return business.SelectedbyTypeofBusiness(dept_id);
        }

        public DataTable GetIndustryType(int bbid)
        {
            return business.GetIndustryType(bbid);
        }

        public DataTable Selectedbycompanytype(int type)
        {
            return business.Selectedbycompanytype(type);    
        }
    }
}
