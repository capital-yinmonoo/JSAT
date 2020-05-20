using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common.Reference
{
    public class AbilityEntity
    {
        private int id = 0;
        private int title_id = 0;
        private string description = string.Empty;
        private bool isDeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Title_ID
        {
            get { return title_id; }
            set { title_id = value; }
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
