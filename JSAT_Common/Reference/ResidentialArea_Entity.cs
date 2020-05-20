using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSAT_Common.Reference
{
    public class ResidentialArea_Entity
    {
        private int id = 0;        
        private string Township_description = string.Empty;
        private bool isdeleted = false;        

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
     
        public string Township_Description
        {
            get { return Township_description; }
            set { Township_description = value; }
        }

        public bool IsDeleted
        {
            get { return isdeleted; }
            set { isdeleted = value; }
        }
  
    }
}
