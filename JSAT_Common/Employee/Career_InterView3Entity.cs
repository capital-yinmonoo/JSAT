using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
   public  class Career_InterView3Entity
    {
        private int id;
        private int career_id;
        private string MComment = string.Empty;
        private string MCommentDisadvantage = string.Empty;
        private string JComment = string.Empty;
        private string JCommentDisadvantage = string.Empty;
        private int createdBy = 0;
        private DateTime createdDate = DateTime.Now;
        private int updatedBy = 0;
        private DateTime updatedDate = DateTime.Now;
        private int deletedBy = 0;
        private DateTime deletedDate = DateTime.Now;
        private string updater = string.Empty;

        public string Updater
        {
            get { return updater; }
            set { updater = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Career_ID
        {
            get { return career_id; }
            set { career_id = value; }
        }

        public string Myanmar_Interviewer_Comment
        {
            get { return MComment; }
            set { MComment = value; }
        }

        public string Myanmar_Interviewer_Comment_Disadvantage
        {
            get { return MCommentDisadvantage; }
            set { MCommentDisadvantage = value; }
        }

        public string Japense_Interviewer_Comment
        {
            get { return JComment; }
            set { JComment = value; }
        }

        public string Japanese_Interviewerr_Comment_Disadvantage
        {
            get { return JCommentDisadvantage; }
            set { JCommentDisadvantage = value; }
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
    }
}
