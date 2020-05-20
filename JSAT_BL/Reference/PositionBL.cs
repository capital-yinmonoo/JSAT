using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
   public class PositionBL
    {

       PositionDL position;

       public PositionBL()
       {
            position = new PositionDL();
       }

       public DataTable SelectByDepartmentID(int dept_id)
       {
           return position.SelectByDepartmentID(dept_id);
       }

       public PositionEntity SelectedByID(int id)
       {
           return position.SelectByID(id);
       }

       public bool Insert(PositionEntity positionInfo)
       {
           bool result = false;
           result=position.Insert(positionInfo);
           return result;
       }

       public bool Update(PositionEntity positionInfo)
       {
           bool result = false;
           result = position.Update(positionInfo);
           return result;
       }

       public bool Delete(int id)
       {
           bool result = false;
           result = position.Delete(id);
           return result;
       }

       public DataTable Search(int id,string str)
       {
           return position.Search(id,str);
       }

       public DataTable SelectAll(int PorCRV)
       {
           return position.SelectAll(PorCRV);
       }

       public bool CheckExistingType(int id,int departmentid, string str)
       {
           int count = position.CheckExistingType(id,departmentid, str);
           if (count > 0)
               return true;
           else return false;
       }

       public DataTable GetDepartmentID(int department_id)
       {
           return position.GetDepartmentID(department_id);
       }

       public DataTable GetDepartment(int bbid)
       {
           return position.GetDepartment(bbid);
       }
    }
}
