using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;

namespace JSAT_BL
{
    public class Client_RecruitmentBL
    {
        ClientRecruitmentDL crDl;

        public Client_RecruitmentBL()
        {
            crDl = new ClientRecruitmentDL();    
        }

        public DataTable SelectAll()
        {
            return crDl.SelectAll();
        }

        public DataTable SelectByID(int id)
        {
            return crDl.SelectByID(id);
        }

        public DataTable SelectByProfileID(int id)
        {
            return crDl.SelectByProfileID(id);
        }

        public Boolean Insert_Update(Client_RecruitmentEntity crEntity,EnumBase.Save option)
        {
            if (crDl.Insert_Update(crEntity, option))
                return true;
            else
                return false;
        }

        public DataTable Checkupdate(int jobno)
        {
            return crDl.Checkupdate(jobno);
        }

        public DataTable SearchData(Client_RecruitmentEntity.SearchRecruitment sr)
        {
            return crDl.SearchData(sr);
        }

        public Boolean Delete(int id, int sessionID, DateTime date)
        {
            if (crDl.Delete(id,sessionID,date))
                return true;
            else
                return false;
        }

        public Boolean DeleteByClientID(int ClientID)
        {
            if (crDl.DeleteByClientID(ClientID))
                return true;
            else
                return false;
        }
    }
}
