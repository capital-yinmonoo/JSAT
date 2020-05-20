using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;


namespace JSAT_BL
{
    public class CareerEmploymentBL
    {
        CareerEmploymentDL ce;
        public CareerEmploymentBL()
        {
            ce = new CareerEmploymentDL();
        }

        public string Insert(CareerEmploymentEntity ceInfo)
        {
                if (ce.Insert(ceInfo))
                    return "Insert Sucessful!";
                else
                    return "Insert Fail!";
        }

        public string Update(CareerEmploymentEntity ceInfo)
        {
            if (ce.Update(ceInfo))
                return "Update Sucessful!";
            else
                return "Update Fail!";
        }

        public Boolean DeleteByCareerID(int id)
        {
            return ce.DeleteByCareerID(id);
        }

        public bool Delete(int id)
        {
            if (ce.Delete(id))
                return true;
            else
                return false;
        }

        public DataTable SelectAll()
        {
            return ce.SelectAll();
        }

        public DataTable SelectByCareerID(int cid)
        {
            return ce.SelectByCareerID(cid);
        }

        public CareerEmploymentEntity SelectByID(int id)
        {
            return ce.SelectByID(id);
        }
    }
}
