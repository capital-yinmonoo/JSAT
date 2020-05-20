using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;
using System.Transactions;

namespace JSAT_BL
{
    public class Career_Information_UploadBL
    {
        Career_Information_UploadDL careerInformation;
        public Career_Information_UploadBL()
        {
            careerInformation = new Career_Information_UploadDL();
        }

        public string Insert(DataTable dt, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (careerInformation.Insert(dt, Option))
                {
                    scope.Complete();
                    return "Save success!";
                }
                return "Save fail!";
            }
        }

        public string Update(DataTable dt, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (careerInformation.Update(dt, Option))
                {
                    scope.Complete();
                    return "Update success!";
                }
                return "Update fail!";
            }
        }

        public DataTable SelectByCareerID(int id, int option)
        {
            return careerInformation.SelectByCareerID(id, option);
        }

        public int Delete(int id)
        {
            return careerInformation.CareerUploadDelete(id);
        }
    }
}
