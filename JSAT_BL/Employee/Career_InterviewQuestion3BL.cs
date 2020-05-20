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
    public class Career_InterviewQuestion3BL
    {
        Career_InterViewQuestion3DL CareerInterview;

        public Career_InterviewQuestion3BL()
        {
            CareerInterview = new Career_InterViewQuestion3DL();
        }

        public DataTable SelectAll()
        {
            return CareerInterview.SelectAll();
        }

        public Boolean DeleteByCareerID(int id)
        {
            return CareerInterview.DeleteByCareerID(id);
        }

        public bool Delete(int id)
        {
            if (CareerInterview.CareerInterviewDelete(id) == 0)
            {
                return true;
            }
            else return false;
        }

        public DataTable SelectByID(int id)
        {
            return CareerInterview.SelectByID(id);
        }

        public void Insert(DataTable CareerInfo, int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (CareerInterview.CareerInterviewDelete(id) == 0)
                {
                    CareerInterview.Insert(CareerInfo);
                    scope.Complete();
                }
            }
        }

        public void CommentInsert(Career_InterView3Entity MJInfo, int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (CareerInterview.CommentDeleteByID(id) == 0)
                {
                    CareerInterview.CommentInsert(MJInfo);
                    scope.Complete();
                }
            }
        }

        public bool CommentUpdate(Career_InterView3Entity MJInfo)
        {
            bool result = false;
            result = CareerInterview.CommentUpdate(MJInfo);
            return result;
        }

        public Career_InterView3Entity CommentSelectByID(int id)
        {
            return CareerInterview.CommentSelectByID(id);
        }
    }
}
