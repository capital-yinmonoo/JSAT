using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;

namespace JSAT_BL
{
    public class Working_PlaceBL
    {
        Working_PlaceDL workingPlace;
        int totalrowcount;
        public Working_PlaceBL()
        {
            workingPlace = new Working_PlaceDL();
        }

        public DataTable SelectAll(int type)
        {
            return workingPlace.SelectAll(type);
        }

        public DataTable SelectAllWorkAbleArea()
        {
            return workingPlace.SelectAllWorkAbleArea();
        }

        public DataTable SearchData(string workarea)
        {
            return workingPlace.SearchData(workarea);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = workingPlace.CheckExistingType(id, str);
            if (count > 0)
                return true;
            else return false;
        }

        public bool Update(Working_PlaceEntity workalbeentity)
        {
            bool result = false;
            result = workingPlace.Update(workalbeentity);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = workingPlace.Delete(id);
            return result;
        }

        public bool Insert(Working_PlaceEntity workableentity)
        {
            bool result = false;
            result = workingPlace.Insert(workableentity);
            return result;
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return workingPlace.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }
    }
}
