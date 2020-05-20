using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Career_Interview2BL
    {
        Career_Interview2DL CareerInt2;

        public Career_Interview2BL()
        {
            CareerInt2 = new Career_Interview2DL();
        }

        public bool Insert(Career_Interview2Entity CareerInt2Info)
        {
            bool result = false;
            result = CareerInt2.Insert(CareerInt2Info);
            return result;
        }

        public bool Delete(int id)
        {
            return CareerInt2.DeleteByID(id);
        }

        public bool Update(Career_Interview2Entity CareerInt2Info)
        {
            bool result = false;
            result = CareerInt2.Update(CareerInt2Info);
            return result;
        }

        public Career_Interview2Entity SelectedByID(int id)
        {
            return CareerInt2.SelectedByID(id);
        }

        public DataTable SelectAll()
        {
            return CareerInt2.SelectAll();
        }
    }
}
