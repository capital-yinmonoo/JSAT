using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using JSAT_Common;
using System.Data;

namespace JSAT_BL
{
    public class ClientCVHistoryBL
    {
        ClientCVHistoryDL cv;
        public ClientCVHistoryBL()
        {
             cv = new ClientCVHistoryDL();
        }

        public string Insert(ClientCVHistoryEntity cvInfo)
        {
            if (cv.Insert(cvInfo))
                return "Insert Successful";
            else return "Insert Fail!";
        }

        public ClientCVHistoryEntity SelectByClientID(int cid)
        {
            return cv.SelectByClientID(cid);
        }

        public string Update(ClientCVHistoryEntity cvInfo)
        {
            if (cv.Update(cvInfo))
                return "Update Successful";
            else return "Update Fail!";
        }

        public ClientCVHistoryEntity SelectByID(int id)
        {
            return cv.SelectByID(id);
        }
    }
}
