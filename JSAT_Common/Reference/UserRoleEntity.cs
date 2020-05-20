using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
    public class UserRoleEntity
    {
        DataTable dtUserRole;
        public DataTable UserRole
        {
            get { return dtUserRole; }
            set { dtUserRole = value; }
        }

        public UserRoleEntity()
        {
            dtUserRole = new DataTable();
            dtUserRole.Columns.Add("ID", typeof(int));
            dtUserRole.Columns.Add("UserID", typeof(int));
            dtUserRole.Columns.Add("MenuID", typeof(int));
            dtUserRole.Columns.Add("CanRead", typeof(bool));
            dtUserRole.Columns.Add("CanEdit", typeof(bool));
            dtUserRole.Columns.Add("CanDelete", typeof(bool));
        }
    }
}
