using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JSAT_Common
{
    public class DepartmentEntity
    {
        private int id = 0;
        private string description = string.Empty;
        private bool Isdeleted = false;
        private int createdby;
        private DateTime createddate = DateTime.Now;
        private int updatedby;
        private DateTime updatedate = DateTime.Now;

        public DepartmentEntity()
        { }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsDeleted
        {
            get { return Isdeleted; }
            set { Isdeleted = value; }
        }

        public int CreatedBy
        {
            get { return createdby; }
            set { createdby = value; }
        }

        public DateTime CreatedDate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        public int UpdatedBy
        {
            get { return updatedby; }
            set { updatedby = value; }
        }

        public DateTime UpdatedDate
        {
            get { return updatedate; }
            set { updatedate = value; }
        }
    }
}
