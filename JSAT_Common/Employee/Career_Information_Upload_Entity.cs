using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JSAT_Common
{
   public  class Career_Information_Upload_Entity
    {
        private int id = 0;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int career_ID = 0;
        public int Career_ID
        {
            get { return career_ID; }
            set { career_ID = value; }
        }

        public int UploadtypeID = 0;
        public int UploadID
        {
            get { return UploadtypeID; }
            set { UploadtypeID = value; }
        }

        public String filename = String.Empty;
        public String Filename
        {
            get { return filename; }
            set { filename = value; }
        }
    }
}
