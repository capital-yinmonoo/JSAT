using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
    public class Career_QualificationEntity
    {
        private DataTable qualification = new DataTable();
        public DataTable Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        private int careerId = 0;
        public int CareerId
        {
            get { return careerId; }
            set { careerId = value; }
        }

        public Career_QualificationEntity()
        {
            qualification = new DataTable();
            qualification.Columns.Add("Career_ID", typeof(int));
            qualification.Columns.Add("Qualification_ID", typeof(int));
        }
    }
}
