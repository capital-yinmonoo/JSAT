using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Job_Career_InterviewEntity
    {
        private DateTime? interview_date = null;
        private DateTime? interview_result_date = null;
        private Decimal salary;
        private int salary_Type;

        public int ID { get; set; }

        public int Client_RecruitmentID { get; set; }

        public int Career_ID { get; set; }

        public bool? Interview { get; set; }

        public DateTime? Interview_Date
        {
            get { return interview_date; }
            set { interview_date = value; }
        }

        public bool? Interview_Result { get; set; }

        public DateTime? Interview_Result_Date
        {
            get { return interview_result_date; }
            set { interview_result_date = value; }
        }

        public Decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public int Salary_Type
        {
            get { return salary_Type; }
            set { salary_Type = value; }
        }
    }
}
