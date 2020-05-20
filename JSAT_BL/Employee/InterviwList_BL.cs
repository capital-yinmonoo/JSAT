using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;
namespace JSAT_BL
{
     public class InterviwList_BL
    {
         InterviewList_DL listdl;
         public InterviwList_BL()
         {
             listdl = new InterviewList_DL();
         }

         public DataTable SelectbyJobno(int jobno)
         {
             return listdl.SelectbyJobno(jobno);
         }

         public DataTable SelectPersonForInterview(string companyname, int jobno)
         {
             return listdl.SelectPersonForInterview(companyname, jobno);
         }

         public void UpdateComfirm(InterviewList_Entity listentity)
         {
             listdl.UpdateComfirm(listentity);
         }

         public DataTable GetCareer_Code(string careercode,string companyname,int jobno)
         {
             return listdl.GetCareer_Code(careercode,companyname,jobno);
         }
    }
}
