using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JSAT_Common.Employee
{
    public class Career_AbilityEntity
    {
        private DataTable ability = new DataTable();
        public DataTable Ability
        {
            get { return ability; }
            set { ability = value; }
        }

        private int careerId = 0;
        public int CareerId
        {
            get { return careerId; }
            set { careerId = value; }
        }

        public Career_AbilityEntity()
        {
            ability = new DataTable();
            ability.Columns.Add("Career_ID", typeof(int));
            ability.Columns.Add("Ability_ID", typeof(int));
        }
    }
}
