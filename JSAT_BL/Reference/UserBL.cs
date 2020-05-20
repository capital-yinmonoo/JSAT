using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSAT_Common;
using JSAT_DL;

namespace JSAT_BL
{
    public class UserBL
    {
        UserDL user;

        public UserBL()
        {
            user = new UserDL();
        }

        public DataTable SelectAll()
        {
            return user.SelectAll();
        }

        public DataTable SelectLoggedInUsers()
        {
            return user.SelectLoggedInUsers();
        }

        public string Insert(UserEntity userInfo)
        {
            bool result = user.Insert(userInfo);
            if (result)
                return "Insert Successful!";
            else
                return "Insert Fail!";
        }

        public string Update(UserEntity userInfo)
        {
            bool result = user.Update(userInfo);
            if (result)
                return "Update Successful!";
            else
                return "Update Fail!";
        }

        public void UpdateIsLogin(int UserID, int IsLogIn)
        {
            user.UpdateIsLogin(UserID, IsLogIn);
        }

        public string Delete(int id)
        {
            bool result = user.Delete(id);
            if (result)
                return "Delete Successful!";
            else
                return "Delete Fail!";
        }

        public DataTable Search(string str)
        {
            return user.Search(str);
        }

        public UserEntity SelectedByID(int id)
        {
            return user.SelectedByID(id);
        }

        public bool Check_LogInID(int id, string logInID)
        {
            int count = user.Check_LogInID(id, logInID);
            if (count >= 1)
                return true;
            else
                return false;
        }
    }
}
