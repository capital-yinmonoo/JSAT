using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
    public class Career_InterviewQuestion1Entity
    {
        private DataTable question1;

        public Career_InterviewQuestion1Entity()
        {
            question1 = new DataTable();
            question1.Columns.Add("Carrer_ID", typeof(int));
            question1.Columns.Add("Interview_Question1_ID", typeof(int));
        }

        public DataTable Question1
        {
            get { return question1; }
            set { question1 = value; }
        }
    }
}
