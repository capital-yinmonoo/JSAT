using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
    public class Profile_QuestionEntity
    {
        private int id;
        private string description;
        private bool isDeleted;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
    }
}
