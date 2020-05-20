using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Job_InterviewEntity
    {
        private int id = 0;
        private int client_Recruitment_ID =0;
        private bool interview = false;
        private DateTime? interview_Date = null;
        private bool interview_Result = false;
        private DateTime? interview_Result_Date = null;
        private string comment = string.Empty;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Client_Recruitment_ID
        {
            get { return client_Recruitment_ID; }
            set { client_Recruitment_ID = value; }
        }

        public bool  Interview
        {
            get { return  interview; }
            set { interview = value; }
        }

        public DateTime? Interview_Date
        {
            get { return interview_Date; }
            set { interview_Date = value; }
        }

        public bool  Interview_Result
        {
            get { return  interview_Result; }
            set { interview_Result = value; }
        }

        public DateTime? Interview_Result_Date
        {
            get { return interview_Result_Date; }
            set { interview_Result_Date = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
