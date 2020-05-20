using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class IntroductionListForCareer_Entity
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string career_code = string.Empty;
        public string Career_code
        {
            get { return career_code; }
            set { career_code = value; }
        }

        private string careercode1 = string.Empty;
        public string Careercode1
        {
            get { return careercode1; }
            set { careercode1 = value; }
        }

        private string careercode2 = string.Empty;
        public string Careercode2
        {
            get { return careercode2; }
            set { careercode2 = value; }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int gender = 0;
        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private int salary = 0;
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private int salary_type = 0;
        public int Salary_type
        {
            get { return salary_type; }
            set { salary_type = value; }
        }

        private DateTime? start_working_date = null;
        public DateTime? Start_working_date
        {
            get { return start_working_date; }
            set { start_working_date = value; }
        }

        private Boolean sign = false;
        public Boolean Sign
        {
            get { return sign; }
            set { sign = value; }
        }

        private int successworkerID = 0;
        public int SuccessworkerID
        {
            get { return successworkerID; }
            set { successworkerID = value; }
        }

        private int jobNo = 0;
        public int JobNo
        {
            get { return jobNo; }
            set { jobNo = value; }
        }

        private int company_ID = 0;
        public int Company_ID
        {
            get { return company_ID; }
            set { company_ID = value; }
        }

        private string company_Name = string.Empty;
        public string companyName
        {
            get { return company_Name; }
            set {company_Name =value;}
        }

        private int position_ID = 0;
        public int Position_ID
        {
            get { return position_ID; }
            set { position_ID = value; }
        }

        private DateTime? introductiondate = null;
        public DateTime? Introductiondate
        {
            get { return introductiondate; }
            set { introductiondate = value; }
        }

        private DateTime? sendcvdate = null;
        public DateTime? Sendcvdate
        {
            get { return sendcvdate; }
            set { sendcvdate = value; }
        }

        private int expectedsalary = 0;
        public int Expectedsalary
        {
            get { return expectedsalary; }
            set { expectedsalary = value; }
        }

        private int expectedsalarytype = 0;
        public int Expectedsalarytype
        {
            get { return expectedsalarytype; }
            set { expectedsalarytype = value; }
        }

        private int situation = 0;
        public int Situation
        {
            get { return situation; }
            set { situation = value; }
        }

        private int? notice_type = 0;
        public int? Notice_type
        {
            get { return notice_type; }
            set { notice_type = value; }
        }

        private DateTime? interviewDate = null;
        public DateTime? InterviewDate
        {
            get { return interviewDate; }
            set { interviewDate = value; }
        }

        private string result = string.Empty;
        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private string noticeDay = string.Empty;
        public string NoticeDay
        {
            get { return noticeDay; }
            set { noticeDay = value; }
        }
    }
}
