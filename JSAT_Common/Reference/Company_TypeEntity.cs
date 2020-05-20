using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common.Reference
{
    public class Company_TypeEntity
    {
        private int id = 0;
        private string description = string.Empty;
        private bool isDeleted = false;
        private int Country_id = 0;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Country_ID
        {
            get { return Country_id; }
            set { Country_id = value; }
        }

        public string Company_Type
        {
            get { return company_type; }
            set { company_type = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public string company_type { get; set; }
    }
}
