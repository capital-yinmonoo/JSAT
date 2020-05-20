using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class JobDescription_Entity
    {
        private int id = 0;
        private int pid = 0;
        private int createdby = 0;       
        private DateTime createddate = DateTime.Now;
        private string description = string.Empty;
        private bool isDeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
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

        public int PositionID
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
