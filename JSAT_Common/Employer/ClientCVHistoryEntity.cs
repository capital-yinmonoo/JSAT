using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class ClientCVHistoryEntity
    {
        private int id = 0;
        private int client_ID = 0;
        private int no_History = 0;
        private string company_Name = string.Empty;
        private string occupation = string.Empty;
        private DateTime interview_Date = DateTime.Now;
        private string result = string.Empty;
        private bool recruitment_Result = false;
        private string comment = string.Empty;
        private bool isDeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Client_ID
        {
            get { return client_ID; }
            set { client_ID = value; }
        }

        public int No_History
        {
            get { return no_History; }
            set { no_History = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string Company_Name
        {
            get { return company_Name; }
            set { company_Name = value; }
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public bool Recruitment_Result
        {
            get { return recruitment_Result; }
            set { recruitment_Result = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public DateTime Interview_Date
        {
            get { return interview_Date; }
            set { interview_Date = value; }
        }
    }
}
