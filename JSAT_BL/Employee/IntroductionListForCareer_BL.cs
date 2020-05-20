using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;
namespace JSAT_BL
{
    public class IntroductionListForCareer_BL
    {
        IntroductionListForCareer_DL introdl;
        private int totalrowcount;

        public IntroductionListForCareer_BL()
        {
            introdl = new IntroductionListForCareer_DL();
        }

        public DataTable Bind()
        {
            return introdl.Bind();
        }

        public int Insert(IntroductionListForCareer_Entity introentity, DataTable dt)
        {
            introdl = new IntroductionListForCareer_DL();
            introdl.BeginTransaction();
           int id = introdl.Insert_IntroductionList(introentity);
            introdl.Insert_IntroductionListForCompany(dt, id);
            introdl.CommitTransaction();
            return id;
        }

        public DataTable BindDDL()
        {
            return introdl.BindDDL();
        }

        public DataTable GetDataForGirdview(int id)
        {
            return introdl.GetDataForGridView(id);
        }

        public DataTable FillData(int id)
        {
            return introdl.FillData(id);
        }

        public void DeleteSuccessWorkerInfo(int id)
        {
            introdl.DeleteSuccessWorkerInfo(id);

        }

        public DataTable SelectUpdate(int id)
        {
            return introdl.SelectUpdate(id);
        }

        public void Update(IntroductionListForCareer_Entity introentity, DataTable dtemployeedetail)
        {
            introdl = new IntroductionListForCareer_DL();
            introdl.BeginTransaction();
           int id= introdl.UpdateEmployeeInfo(introentity);
           foreach (DataRow dr in dtemployeedetail.Rows)
           {
               switch (dr.RowState)
               {
                   case DataRowState.Added:
                       introdl.AddNewDetail(id, Convert.ToInt32(dr["Job_No"].ToString()),
                           Convert.ToInt32(dr["companyID"].ToString()),
                           Convert.ToInt32(dr["positionID"].ToString()),
                           dr["Introduction_Date"].ToString(),
                           dr["Sent_CV_Date"].ToString(), 
                           Convert.ToInt32(dr["Salary_Hidden"].ToString()),
                           dr["expectedsalarytype"].ToString(),
                           dr["condition"].ToString(), 
                           dr["noticetype"].ToString(), 
                           dr["noticeday"].ToString(),
                           dr["Interview_Date"].ToString(),
                           dr["Interview_Time"].ToString(),
                           dr["Result"].ToString());
                       break;
                   case DataRowState.Modified:
                       introdl.UpdateEmployeeDetail(Convert.ToInt32(dr["Success_Worker_ID"].ToString()), 
                           Convert.ToInt32(dr["Job_No"].ToString()),
                           Convert.ToInt32(dr["companyID"].ToString()), 
                           Convert.ToInt32(dr["positionID"].ToString()),
                           dr["Introduction_Date"].ToString(), 
                           dr["Sent_CV_Date"].ToString(),
                           Convert.ToInt32(dr["Salary_Hidden"].ToString()), 
                           dr["expectedsalarytype"].ToString(),
                           dr["condition"].ToString(),
                           dr["noticetype"].ToString(),
                           dr["noticeday"].ToString(), 
                           dr["Interview_Date"].ToString(),
                           dr["Interview_Time"].ToString(),
                           dr["Result"].ToString(),
                           dr["ID"].ToString());
                       break;
                   case DataRowState.Deleted:
                       dr.RejectChanges();
                       introdl.DeleteDataForGridView(Convert.ToInt32(dr["ID"].ToString()));
                       break;
               }
           }
           introdl.CommitTransaction();
        }

        public DataTable CheckUniqueID(string code)
        {
            return introdl.CheckUniqueID(code);
        }

        public DataTable  CheckEmployeeExist(string code)
        {
            return introdl.CheckEmployeeExist(code);
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public DataTable Paging(string search, string sort, int startIndex, int pagesize)
        {
            return introdl.Paging(search, sort, startIndex, pagesize, out totalrowcount);
        }
    }
}
