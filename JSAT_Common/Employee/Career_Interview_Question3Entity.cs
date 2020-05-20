using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
   public  class Career_Interview_Question3Entity
    {
       DataTable dtCareerintview3;

        public DataTable Career_Interview3 
        {
            get { return dtCareerintview3; }
            set { dtCareerintview3 = value; }
        }

        public Career_Interview_Question3Entity() 
        {
            dtCareerintview3 = new DataTable();
            dtCareerintview3.Columns.Add("ID", typeof(int));
            dtCareerintview3.Columns.Add("Career_ID", typeof(int));
            dtCareerintview3.Columns.Add("Interview_Question3_ID", typeof(int));
        }
    }
}
