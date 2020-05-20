using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_Common;
using JSAT_DL;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_BL
{
    public class InstituationBL
    {
        InstituationDL Instituation;
        public InstituationBL()
        {
            Instituation = new InstituationDL();
        }

        public DataTable SelectAll(int IorCRV)
        {
            return Instituation.SelectAll(IorCRV);
        }

        public InstituationEntity SelectByID(int id)
        {
            return Instituation.SelectByID(id);
        }

        public bool Insert(InstituationEntity InstituationInfo)
        {
            bool result = false;
            result = Instituation.Insert(InstituationInfo);
            return result;
        }

        public bool InsertInstituation(InstituationEntity InstituationInfo)
        {
            bool result = false;
            result = Instituation.InsertInstituation(InstituationInfo);
            return result;
        }

        public bool Update(InstituationEntity InstituationInfo)
        {
            bool result = false;
            result = Instituation.Update(InstituationInfo);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            result = Instituation.Delete(id);
            return result;
        }

        public DataTable Search(string str)
        {
            return Instituation.Search(str);
        }

        public bool CheckExistingType(int id, string str)
        {
            int count = Instituation.CheckExistingType(str, id);
            if (count > 0)
                return true;
            else return false;
        }

        public bool CheckExistingInstituation(int id, int instid)
        {
            int count = Instituation.CheckExistingInstituation(id, instid);
            if (count > 0)
                return true;
            else return false;
        }

        public DataTable SelectByIndustryID(int Instituation_id)
        {
            return Instituation.SlectByInstituationID(Instituation_id);
        }

        public DataTable GetIndustyID(int instituation_id)
        {
            return Instituation.GetIndustyID(instituation_id);
        }

        public DataTable GetInstitutionAreaSelectByID(int instituation_id)
        {
            return Instituation.GetInstitutionAreaSelectByID(instituation_id);
        }
    }
}
