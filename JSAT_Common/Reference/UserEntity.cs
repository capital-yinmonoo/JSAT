using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class UserEntity
    {
        private int id = 0;
        private string user_name = string.Empty;
        private string login_id = string.Empty;
        private string password = string.Empty;
        private string image_file_name = string.Empty;
        private bool isdeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string User_Name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        public string LogIn_ID
        {
            get { return login_id; }
            set { login_id = value; }
        }

        public string Image_FileName
        {
            get { return image_file_name; }
            set { image_file_name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool isDeleted
        {
            get { return isdeleted; }
            set { isdeleted = value; }
        }
    }
}
