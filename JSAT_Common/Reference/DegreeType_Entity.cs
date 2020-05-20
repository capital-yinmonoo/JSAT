using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class DegreeType_Entity
    {
        private int id = 0;
        private int university_id = 0;
        private string degree_description = string.Empty;
        private bool isdeleted = false;
        private int createdby;
        private DateTime createddate = DateTime.Now;
        private int updatedby;
        private DateTime updateddate = DateTime.Now;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int University_ID
        {
            get { return university_id; }
            set { university_id = value; }
        }

        public string Degree_Description
        {
            get { return degree_description; }
            set { degree_description = value; }
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
