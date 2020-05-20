using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Township_Type_Entity
    {
        private int id = 0;
        private int institutionarea_id = 0;
        private string Township_description = string.Empty;
        private bool isdeleted = false;
        private int createdby;
        private DateTime createddate = DateTime.Now;
        private int updatedby;
        private DateTime updateddate = DateTime.Now;

        public int ID
        {
            get{return id;}
            set{id=value;}
        }

        public int InstitutionArea_ID
        {
            get { return institutionarea_id; }
            set { institutionarea_id = value; }
        }

        public string Township_Description
        {
            get { return Township_description; }
            set { Township_description = value; }
        }

        public bool IsDeleted
        {
            get { return isdeleted; }
            set { isdeleted = value; }
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
            get { return updateddate; }
            set { updateddate = value; }
        }
    }
}
    

