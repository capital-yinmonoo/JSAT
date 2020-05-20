using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class Credit_NewBL
    {
        Credit_NewDL creditNew;
        Credit_New_Entity creditentity;

        public Credit_NewBL()
        {
            creditNew = new Credit_NewDL();
        }

        public DataTable Get_Info_ByEmpID(int pid, int eid)
        {
            return  creditNew.Get_Info_ByEmpID(pid, eid);
        }

        public DataTable Get_Info_Employee(int id)
        {
            return creditNew.Get_Info_Employee(id);
        }

        public String Select_Emp_Code(String empid)
        {
            return creditNew.Select_Emp_Code(empid);
        }

        public int Insert_Company_Credit(Credit_New_Entity creditentity,int PID, int option)
        {
            return creditNew.Insert_Company_Credit(creditentity, PID, option);
        }

        public void Insert_Company_Credit_For_Update(Credit_New_Entity creditentity,int CID)
        {
            creditNew.Insert_Company_Credit_For_Update(creditentity,CID);
        }

        public void Employee_Credit_Update(int EID, int CID,DataTable dt,Credit_New_Entity creditentity)
        {
            creditNew.Employee_Credit_Update(EID, CID, dt, creditentity);
        }

        public void Insert_Employee_Credit(Credit_New_Entity creditentity, DataTable dt, int id)
        {
            creditNew.Insert_Employee_Credit(creditentity, dt, id);
        }

        public void Update_Company_Credit(Credit_New_Entity creditentity,int id)
        {
            creditNew.Update_Company_Credit(creditentity,id);
        }

        public DataTable BindDropDown()
        {
            return creditNew.BindDropDown();
        }
        
        public void Employee_Credit_Update_New(int EID, int CID,Credit_New_Entity creditentity)
        {
            creditNew.Employee_Credit_Update_New(EID, CID, creditentity);
        }
    }
}
