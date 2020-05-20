using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class BusinessTypeEntity
    {
        private int id = 0;
        private int Industry_id = 0;
        private string description = string.Empty;
        private bool isDeleted = false;
        private int createdby;
        private DateTime createddate = DateTime.Now; 
        private int updatedby;
        private DateTime updatedate = DateTime.Now;

        public int ID
        {
            get{ return id; }
            set { id = value; }
        }

        public int Industry_ID 
        {
            get { return Industry_id; }
            set { Industry_id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted;}
            set { isDeleted = value; }
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
