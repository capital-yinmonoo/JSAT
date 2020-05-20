using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_DL;
using JSAT_Common;

namespace JSAT_BL
{
  public   class DepartmentBL
    {
        bool search = true;
        DepartmentDL department;
        int totalrowcount;

        public DepartmentBL()
        {
            department = new DepartmentDL();
        }

        public DataTable SelectAll(int DorCRV)
        {
            return department.SelectAll(DorCRV);
        }

        public DataTable SelectByID(int id)
        {
            return department.SelectByID(id);
        }

        public bool Insert(DepartmentEntity depInfo )
        {
            bool result = false;
           result = department.Insert(depInfo);
          return result;
        }

        public bool Delete(int id)
        {
            return department.DeleteByID(id);
        }

        public bool Update(DepartmentEntity depInfo)
        {
            bool result = false;
            result = department.Update(depInfo);
            return result;
        }

        public DataTable Search(string str) 
        {
            return department.Search(str);
        }

        public bool Check_ExistingRecord(int id ,string description) 
        {
            int count = department.Check_DepartmentName(id,description);
            if (count >= 1)
                return true;
            else
                return false;
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return department.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }
    }
}
