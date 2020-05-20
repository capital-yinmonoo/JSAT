using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class CareerEmploymentEntity
    {
        private int id = 0;
        private int career_ID = 0;
        private string company_Name = string.Empty;
        private string fromDate = string.Empty;
        private string toDate = string.Empty;
        private string business_Type = string.Empty;
        private int locationID = 0;
        private string Other_location = string.Empty;
        private string position = string.Empty;
        private decimal last_Salary = 0;
        private string salarytype = string.Empty;
        private string responsibility = string.Empty;
        private string leave_Reason = string.Empty;
        private int createdBy = 0;
        private int updatedBy = 0;
        private int deletedBy = 0;
        private DateTime createdDate = DateTime.Now;
        private DateTime updatedDate = DateTime.Now;
        private DateTime deletedDate = DateTime.Now;
        private bool isDeleted = false;

        private int? industryID = null;
        public int? IndustryID
        {
            get { return industryID; }
            set { industryID = value; }
        }

        private int? businessID = null;
        public int? BusinessID
        {
            get { return businessID; }
            set { businessID = value; }
        }

        private int? departmentID = null;
        public int? DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        private int? positoinID = null;
        public int? PositionID
        {
            get { return positoinID; }
            set { positoinID = value; }
        }

        private String updater = String.Empty;
        public String Updater
        {
            get { return updater; }
            set { updater = value; }
        }

        private String updateTime = String.Empty;
        public String UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Career_ID
        {
            get { return career_ID; }
            set { career_ID = value; }
        }

        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }

        public string Other_Location
        {
            get { return Other_location; }
            set { Other_location = value; }
        }

        public string Company_Name
        {
            get { return company_Name; }
            set { company_Name = value; }
        }

        public string Business_Type
        {
            get { return business_Type; }
            set { business_Type = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string Responsibility
        {
            get { return responsibility; }
            set { responsibility = value; }
        }

        public string Leave_Reason
        {
            get { return leave_Reason; }
            set { leave_Reason = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public string FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

        public string ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        public decimal Last_Salary
        {
            get { return last_Salary; }
            set { last_Salary = value; }
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
            set { createdDate = value; }
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

        public string SalaryType
        {
            get { return salarytype; }
            set { salarytype = value; }
        }
    }
}
