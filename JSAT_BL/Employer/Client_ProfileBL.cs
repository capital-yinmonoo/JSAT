﻿using System;
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
    public class Client_ProfileBL
    {
        Client_ProfileDL clientProfile;
        int totalrowcount;

        public Client_ProfileBL()
        {
            clientProfile = new Client_ProfileDL();
        }

        public DataTable SelectAll()
        {
            return clientProfile.SelectAll();
        }

        public int TotalRowCount(string search)
        {
            return totalrowcount;
        }

        public int AutoGenerated_ClientCode()
        {
            return clientProfile.AutoGenerated_ClientCode();
        }

        public Client_ProfileEntity SelectByID(int id)
        {
            return clientProfile.SelectByID(id);
        }

        public DataTable SelectById(int id)
        {
            return clientProfile.SelectById(id);
        }

        public string Insert(Client_ProfileEntity clientProfileInfo,int Option)
        {             
            using (TransactionScope scope = new TransactionScope())
            {
                if (!Check_Record(clientProfileInfo.Client_Code,clientProfileInfo.ID))//if no record found ,
                {
                    if (clientProfile.Insert(clientProfileInfo, Option))
                    {
                        scope.Complete();
                        return "Save success!";
                    }
                }
                else
                    return "Record already exists";
                return "Save fail!";
            }
        }

        public string Update(Client_ProfileEntity clientProfileInfo,int Option)
        {
            using (TransactionScope scope = new TransactionScope())
            {               
                if (!Check_Record(clientProfileInfo.Client_Code, clientProfileInfo.ID))//if no record found ,
                {
                    if (clientProfile.Update(clientProfileInfo, Option))
                    {
                        scope.Complete();
                        return "Update success!";
                    }
                }
                else
                    return "Record already exists";
                return "Update fail!";
            }
        }

        public string Delete(int ID , int sessionID , DateTime date)
        {
            string result = string.Empty;
            if (clientProfile.Delete(ID, sessionID , date))
            {                
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public string DeleteAll()
        {
            string result = string.Empty;
            if (clientProfile.DeleteAll())
            {
                result = "Delete success!";
            }
            else
                result = "Delete fail!";
            return result;
        }

        public bool Check_Record(int code, int ID)
        {
            int count = clientProfile.Check_ExistingCode(code,ID);
            if (count >= 1)
                return true;//records exist.
            else
                return false;
        }

        public DataTable SelectByCriteria(string search, string sort, int startIndex, int pagesize)
        {
            return clientProfile.SelectByCriteria(search, sort, startIndex, pagesize, out totalrowcount);
        }

        public DataTable SelectByIndustryID(int id)
        {
            return clientProfile.SelectByIndustryID(id);
        }

        public DataTable SearchByName(String Name,int? Code)
        {
            return clientProfile.SearchByName(Name,Code);
        }
    }
}