using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JSAT_Common
{
    public class Career_WorkingPlaceEntity
    {
        private DataTable workingPlace=new DataTable();
        public DataTable WorkingPlace
        {
            get { return workingPlace; }
            set { workingPlace = value; }
        }

        private int careerId = 0;
        public int CareerId
        {
            get { return careerId; }
            set { careerId = value; }
        }

        public Career_WorkingPlaceEntity()
        {
            workingPlace = new DataTable();
            workingPlace.Columns.Add("Career_ID", typeof(int));
            workingPlace.Columns.Add("WorkingPlace_ID", typeof(int));
        }
    }
}
