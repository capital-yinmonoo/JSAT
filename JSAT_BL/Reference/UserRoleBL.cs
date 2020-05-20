using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JSAT_DL;
using System.Data;
using JSAT_Common;
using System.Transactions;

namespace JSAT_BL
{
    public class UserRoleBL
    {
        UserRoleDL user;

        public UserRoleBL()
        {
            user = new UserRoleDL();
        }

        public DataTable SelectUserRole()
        {
            return user.UserRoleSelect();
        }

        public DataTable SelectByID(int id)
        {
            return user.UserRoleSelectByID(id);
        }

        public void Insert(DataTable userInfo, int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (user.UserRoleDelete(id)==0)
                {
                    user.UserRoleInsert(userInfo);
                    scope.Complete();
                }
            }
        }

        public string SelectName(int id)
        {
            return  user.SelectName(id);
        }

        public bool CanRead(int userID, string pageCode)
        {
            return user.CanRead(userID, pageCode);
        }

        public bool CanSave(int userID, string pageCode)
        {
            return user.CanSave(userID,pageCode);
        }

        public bool CanDelete(int userID, string pageCode)
        {
            return user.CanDelete(userID, pageCode);
        }
    }
}
