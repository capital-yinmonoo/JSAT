using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Career_Job_InterviewEntity
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int client_RecruitmentID = 0;
        public int Client_RecruitmentID
        {
            get { return client_RecruitmentID; }
            set { client_RecruitmentID = value; }
        }

        private int career_ID = 0;
        public int Career_ID
        {
            get { return career_ID; }
            set { career_ID = value; }
        }

        private Boolean? interview = null;
        public Boolean? Interview
        {
            get { return interview; }
            set { interview = value; }
        }

        private DateTime? interview_Date = null;
        public DateTime? Interview_Date
        {
            get { return interview_Date; }
            set
            {
                interview_Date = value;
            }
        }

        private Boolean? interview_Result = null;
        public Boolean? Interview_Result
        {
            get { return interview_Result; }
            set { interview_Result = value; }
        }

        private DateTime? interview_Result_Date = null;
        public DateTime? Interview_Result_Date
        {
            get { return interview_Result_Date; }
            set { interview_Result_Date = value; }
        }

        private Decimal salary = 0;
        public Decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private int salary_Type = 0;
        public int Salary_Type
        {
            get { return salary_Type; }
            set { salary_Type = value; }
        }

        private String comment = String.Empty;
        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private string companyName = string.Empty;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private string jobType = string.Empty;
        public string JobType
        {
            get { return jobType; }
            set { jobType = value; }
        }

        private int updatedBy = 0;
        public int UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        private int createdBy = 0;
        public int CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        private int deletedBy = 0;
        public int DeletedBy
        {
            get { return deletedBy; }
            set { deletedBy = value; }
        }

        private DateTime createdDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        private DateTime updatedDate = DateTime.Now;
        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }

        private DateTime deletedDate = DateTime.Now;
        public DateTime DeletedDate
        {
            get { return deletedDate; }
            set { deletedDate = value; }
        }

        private bool isDeleted = false;
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
