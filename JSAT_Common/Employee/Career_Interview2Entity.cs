using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace JSAT_Common
{
   public  class Career_Interview2Entity
    {
        private int id ;
        private int career_id ;
        private string company_name = string.Empty;
        private string company_Industry = string.Empty;
        private int service_years = 0;
        private string job_description = string.Empty;
        private string termination_reason = string.Empty;
        private bool Isdeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int  Career_ID
        {
            get { return career_id; }
            set {career_id = value; }
        }

        public string Company_Name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        public string Company_Industry
        {
            get { return company_Industry; }
            set { company_Industry = value; }
        }

        public int  Service_Years
        {
            get { return service_years; }
            set { service_years = value; }
        }

        public string Job_Description
        {
            get { return  job_description; }
            set { job_description = value; }
        }

        public string Termination_Reason
        {
            get { return termination_reason; }
            set { termination_reason = value; }
        }

        public bool IsDeleted
        {
            get { return Isdeleted; }
            set { Isdeleted = value; }
        }
    }
}
