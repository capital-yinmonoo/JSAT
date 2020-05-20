using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;

namespace JSAT_BL
{
    public class Employee_SelfEntry_BL
    {
        Employee_SelfEntry_Entity see;
        Employee_SelfEntry_DL edl;
        public Employee_SelfEntry_BL()
        {
            edl = new Employee_SelfEntry_DL();
        }

        public int Insert(Employee_SelfEntry_Entity see)
        {
            return edl.Insert(see);
        }

        public DataTable SelectPhotoData(string code)
        {
            return edl.SelectPhotoData(code);
        }

        public void Update(Employee_SelfEntry_Entity see,string code)
        {
            edl.Update(see,code);
        }

        public void DeleteWorkingPlace(int id)
        {
            edl.DeleteWorkingPlace(id);
        }

        public DataTable GetWorkingDescription(int workingplace)
        {
            return edl.GetWorkingDescription(workingplace);
        }

        public DataTable SelectByWorkingPlace(string AutoCode)
        {
            return edl.SelectByWorkingPlace(AutoCode);
        }

        public void InsertWorkingPlace(int id, int workingplace)
        {
            edl.InsertWorkingPlace(id, workingplace);
        }

        public DataTable GetEmpInfo(string autocode)
        {
            return edl.GetEmpInfo(autocode);
        }

        public DataTable GetDOB(string code)
        {
            return edl.GetDOB(code);
        }

        public DataTable GetAddress(int id)
        {
            return edl.GetAddress(id);
        }

        public DataTable GetReligion(int id)
        {
            return edl.GetReligion(id);
        }

        public DataTable GetEducation(int id)
        {
            return edl.GetEducation(id);
        }

        public DataTable GetMajor(int id)
        {
            return edl.GetMajor(id);
        }

        public DataTable GetInstitution(int id)
        {
            return edl.GetInstitution(id);
        }

        public DataTable GetSituation(int id)
        {
            return edl.GetSituation(id);
        }
    }
}
