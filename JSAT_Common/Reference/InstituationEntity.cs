using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common
{
   public  class InstituationEntity
    {
        private int id = 0;
        private int Instituation_id = 0;
        private string description = string.Empty;
        private bool isDeleted = false;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Instituation_ID
        {
            get { return Instituation_id; }
            set { Instituation_id = value; }
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

        public object Country { get; set; }
    }
}
