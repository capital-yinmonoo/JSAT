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
    public class Career_InformationBL
    {
        Career_InformationDL careerInformation;

        public Career_InformationBL()
        {
            careerInformation = new Career_InformationDL();
        }

        public DataTable SelectAll()
        {
            return careerInformation.SelectAll();
        }

        public Career_InformationEntity SelectByID(int id, int option)
        {
            return careerInformation.SelectByID(id, option);
        }

        public DataTable SelectByCareerID(int id, int option)
        {
            return careerInformation.SelectByCareerID(id, option);
        }

        public string Insert(Career_InformationEntity careerInformationInfo, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (careerInformation.Insert(careerInformationInfo, Option))
                {
                    scope.Complete();
                    return "Save success!";
                }
                return "Save fail!";
            }
        }

        public string Update(Career_InformationEntity careerInformationInfo, int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (careerInformation.Update(careerInformationInfo, Option))
                {
                    scope.Complete();
                    return "Update success!";
                }
                return "Update fail!";
            }
        }

        public Boolean DeletebyCareerID(int id)
        {
            return careerInformation.DeleteByCareerId(id);
        }

        public bool Delete(int ID)
        {
            string result = string.Empty;
            if (careerInformation.Delete(ID))
            {
                return true;
            }
            else
                return false;
        }

        public string DeleteAll()
        {
            string result = string.Empty;
            if (careerInformation.DeleteAll())
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }
    }
}
