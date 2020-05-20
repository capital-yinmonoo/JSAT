using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Client_ProfileEntity
    {
        private int id = 0;
        private string client_name = string.Empty;
        private int client_code = 0;
        private int person_typeID = 0;
        private string personInCharge_name = string.Empty;
        private string telephone_no = string.Empty;
        private string fax_no = string.Empty;
        private string website = string.Empty;
        private string location = string.Empty;        
        private int business_typeID = 0;
        private int industry_typeID = 0;
        private int total_employees = 0;
        private int noofClubs = 0;
        private string establishment_date = string.Empty;
        private string remarks = string.Empty;
        private string consent = string.Empty;
        private string agreement_data = string.Empty;
        private int createdBy = 0;
        private DateTime createdDate = DateTime.Now;
        private int updatedBy = 0;
        private DateTime updatedDate =DateTime.Now;
        private int deletedBy = 0;
        private DateTime deletedDate = DateTime.Now;
        private bool isDeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Client_Name
        {
            get { return client_name; }
            set { client_name = value; }
        }

        public int Client_Code
        {
            get { return client_code; }
            set { client_code = value; }
        }

        public int Person_TypeID
        {
            get { return person_typeID; }
            set { person_typeID = value; }
        }

        public string PersonInCharge_Name
        {
            get { return personInCharge_name; }
            set { personInCharge_name = value; }
        }

        public string Telephone_No
        {
            get { return telephone_no; }
            set { telephone_no = value; }
        }

        public string Fax_No
        {
            get { return fax_no; }
            set { fax_no = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int Business_TypeID
        {
            get { return business_typeID; }
            set { business_typeID = value; }
        }

        public int Industry_TypeID
        {
            get { return industry_typeID; }
            set { industry_typeID = value; }
        }

        public int Total_Employees
        {
            get { return total_employees; }
            set { total_employees = value; }
        }

        public int NoofClubs
        {
            get { return noofClubs; }
            set { noofClubs = value; }
        }

        public string Establishment_Date 
        {
            get { return establishment_date; }
            set { establishment_date = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public string Consent
        {
            get { return consent; }
            set { consent = value; }
        }

        public string Agreement_Data
        {
            get { return agreement_data; }
            set { agreement_data = value; }
        }

        public int UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public int DeletedBy
        {
            get { return deletedBy; }
            set { deletedBy = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set{createdDate = value;}
        }

        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }

        public DateTime DeletedDate
        {
            get { return deletedDate; }
            set { deletedDate = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
